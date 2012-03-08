using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using DevExpress.XtraCharts;
using DevExpress.XtraGrid.Columns;

using Sunrise.ERP.BaseControl;
using Sunrise.ERP.Report;
using Sunrise.ERP.Controls;
using Sunrise.ERP.Security;
using Sunrise.ERP.Lang;
using Sunrise.ERP.BaseForm;
using System.Reflection;


namespace Sunrise.ERP.Module.SystemManage
{
    public partial class frmsysQueryReport : Sunrise.ERP.BaseForm.frmForm
    {
        DataTable dtMain = new DataTable();
        DataTable dtDetail = new DataTable();
        DataTable dtSearch = new DataTable();
        /// <summary>
        /// 主查询SQL
        /// </summary>
        string sMainSQL = "";
        /// <summary>
        /// 处理字段
        /// </summary>
        string sDealFields = "*";
        /// <summary>
        /// 排序字段
        /// </summary>
        string sSortFields = "";
        /// <summary>
        /// 设置SQL
        /// </summary>
        string sExecSQL = "";
        /// <summary>
        /// 是否存在分组
        /// </summary>
        bool IsGroup = false;
        /// <summary>
        /// 是否显示图表
        /// </summary>
        bool IsChart = false;
        /// <summary>
        /// 是否自动运行查询
        /// </summary>
        bool IsAutoRun = false;

        /// <summary>
        /// 打印报表
        /// </summary>
        InitReport report;

        public frmsysQueryReport(int formid, string formtext)
            : base(formid, formtext)
        {
            InitializeComponent();
            if (formtext != "")
            {
                this.Text = formtext;
            }
        }

        private void frmsysQueryReport_Load(object sender, EventArgs e)
        {
            InitBaseData();
            CreatSearchControl();
            CreateGridColumn();
            //控制是否自动执行查询
            if (IsAutoRun)
            {
                InitGridData("1=1 " + GetSearchFilterSQL());
                if (tbDetail.SelectedTabPageIndex == 1)
                {
                    ShowChart();
                }
            }
            else
            {
                InitGridData("1=2");
            }

            report = new InitReport(ReportNo);
        }


        #region 私有方法
        /// <summary>
        /// 创建查询条件控件
        /// </summary>
        private void CreatSearchControl()
        {
            try
            {
                if (dtDetail != null && dtMain != null && dtMain.Rows.Count > 0)
                {
                    //每行控件数
                    int iControlColumn = Convert.ToInt32(dtMain.Rows[0]["iControlColumn"]);
                    //控件间距
                    int iControlSpace = Convert.ToInt32(dtMain.Rows[0]["iControlSpace"]);
                    //先计算需要生成查询的数据
                    DataRow[] dr = dtDetail.Select("bIsQuery=1");
                    //计算控件总共行数
                    int iRows = 0;
                    if (dr.Length > 0)
                    {
                        if (dr.Length % iControlColumn != 0)
                        {
                            iRows = (int)Math.Floor(Convert.ToDecimal(dr.Length / iControlColumn)) + 1;
                        }
                        else
                        {
                            iRows = Convert.ToInt32(dr.Length / iControlColumn);
                        }


                        //设置控件数计数
                        int iControl = 0;
                        for (int j = 0; j < iRows; j++)
                        {
                            for (int i = 0; i < iControlColumn; i++)
                            {
                                //控件类型
                                string sColumnType = dr[iControl]["sColumnType"].ToString();
                                //取得查询条件默认值
                                object oColumnDefaultValue = dr[iControl]["sDefaultValue"];
                                if (oColumnDefaultValue.ToString().ToLower() == "<userid>")
                                {
                                    oColumnDefaultValue = Sunrise.ERP.Security.SecurityCenter.CurrentUserID;
                                }
                                //默认值中日期类型解析
                                if (oColumnDefaultValue.ToString().ToLower().Contains("<getdate>") && sColumnType == "D")
                                {
                                    if (oColumnDefaultValue.ToString().Length == 9)
                                    {
                                        oColumnDefaultValue = DateTime.Now.ToShortDateString();
                                    }
                                    else if (oColumnDefaultValue.ToString().ToLower().Contains("+"))
                                    {
                                        int iDays = Convert.ToInt32(oColumnDefaultValue.ToString().Trim().Substring(10));
                                        oColumnDefaultValue = DateTime.Now.AddDays(iDays);
                                    }
                                    else if (oColumnDefaultValue.ToString().ToLower().Contains("-"))
                                    {
                                        int iDays = Convert.ToInt32(oColumnDefaultValue.ToString().Trim().Substring(10));
                                        oColumnDefaultValue = DateTime.Now.AddDays(-iDays);
                                    }
                                }
                                if (oColumnDefaultValue.ToString() != "" && sColumnType == "K" && Convert.ToInt32(oColumnDefaultValue.ToString()) == 1)
                                {
                                    oColumnDefaultValue = true;
                                }
                                else if (oColumnDefaultValue.ToString() != "" && sColumnType == "K" && Convert.ToInt32(oColumnDefaultValue.ToString()) == 0)
                                {
                                    oColumnDefaultValue = false;
                                }


                                //创建控件
                                //Lable大小控制为80X21，其他输入控件大小为120X21
                                Label lbl = new Label();
                                lbl.AutoSize = false;
                                lbl.Size = new Size(80, 21);
                                lbl.Location = new Point(10 + (80 + 120 + iControlSpace) * i, 25 + (21 + 10) * j);
                                //控件命名规则：lbl+字段名+数据行号
                                lbl.Name = "lbl" + dr[iControl]["sColumnFieldName"].ToString() + iControl.ToString();
                                lbl.TextAlign = ContentAlignment.BottomLeft;
                                //当控件类型为复选框时不创建Lable控件
                                if (sColumnType != "K")
                                {
                                    lbl.Text = dr[iControl]["sColumnCaption"].ToString();
                                }
                                grbFilter.Controls.Add(lbl);
                                //不同类型创建不同控件
                                switch (sColumnType)
                                {
                                    //字符型,数字型
                                    case "S":
                                    case "N":
                                        {
                                            DevExpress.XtraEditors.TextEdit txt = new DevExpress.XtraEditors.TextEdit();
                                            txt.Size = new Size(120, 21);
                                            txt.Name = "txt" + dr[iControl]["sColumnFieldName"].ToString() + iControl.ToString();
                                            txt.Location = new Point(10 + (80 + 120 + iControlSpace) * i + 80, 28 + (21 + 10) * j);
                                            txt.Text = oColumnDefaultValue.ToString();
                                            //用Tag来存储查询类型
                                            txt.Tag = dr[iControl]["sColumnFieldName"].ToString() + " " + dr[iControl]["sSearchType"].ToString();
                                            grbFilter.Controls.Add(txt);
                                            break;
                                        }
                                    //ComboBox类型
                                    case "C":
                                        {
                                            DevExpress.XtraEditors.ComboBoxEdit cbx = new DevExpress.XtraEditors.ComboBoxEdit();
                                            cbx.Size = new Size(120, 21);
                                            cbx.Name = "cbx" + dr[iControl]["sColumnFieldName"].ToString() + iControl.ToString();
                                            cbx.Location = new Point(10 + (80 + 120 + iControlSpace) * i + 80, 28 + (21 + 10) * j);
                                            cbx.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                                            //写入ComboBox选择值
                                            foreach (var item in dr[iControl]["sReturnValue"].ToString().Replace("，", ",").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                                            {
                                                cbx.Properties.Items.Add(item);
                                            }


                                            if (dr[iControl]["sReturnValue"].ToString() != "")
                                            {
                                                if (oColumnDefaultValue.ToString() != "" && dr[iControl]["sReturnValue"].ToString().Contains(oColumnDefaultValue.ToString()))
                                                {
                                                    cbx.Text = oColumnDefaultValue.ToString();
                                                }
                                                else
                                                {
                                                    cbx.SelectedIndex = -1;
                                                }
                                            }
                                            //用Tag来存储查询类型
                                            cbx.Tag = dr[iControl]["sColumnFieldName"].ToString() + " " + dr[iControl]["sSearchType"].ToString();
                                            grbFilter.Controls.Add(cbx);
                                            break;
                                        }
                                    //日期型
                                    case "D":
                                        {
                                            DevExpress.XtraEditors.DateEdit det = new DevExpress.XtraEditors.DateEdit();
                                            det.Size = new Size(120, 21);
                                            det.Name = "det" + dr[iControl]["sColumnFieldName"].ToString() + iControl.ToString();
                                            det.Location = new Point(10 + (80 + 120 + iControlSpace) * i + 80, 28 + (21 + 10) * j);
                                            det.Tag = dr[iControl]["sColumnFieldName"].ToString() + " " + dr[iControl]["sSearchType"].ToString();
                                            if (oColumnDefaultValue.ToString() != "")
                                            {
                                                det.DateTime = Convert.ToDateTime(oColumnDefaultValue);
                                            }
                                            else
                                            {
                                                det.EditValue = null;
                                            }
                                            grbFilter.Controls.Add(det);
                                            break;
                                        }
                                    //复选框
                                    case "K":
                                        {
                                            DevExpress.XtraEditors.CheckEdit chk = new DevExpress.XtraEditors.CheckEdit();
                                            chk.Size = new Size(120, 21);
                                            chk.Name = "chk" + dr[iControl]["sColumnFieldName"].ToString() + iControl.ToString();
                                            chk.Location = new Point(10 + (80 + 120 + iControlSpace) * i + 80, 28 + (21 + 10) * j);
                                            //CheckBox过滤条件特殊处理
                                            string sReturnValue = "";
                                            if (dr[iControl]["sSearchType"].ToString().Contains("LIKE"))
                                            {
                                                sReturnValue = " '%" + dr[iControl]["sReturnValue"].ToString() + "%'";
                                            }
                                            else
                                            {
                                                sReturnValue = " '" + dr[iControl]["sReturnValue"].ToString() + "'";
                                            }
                                            chk.Tag = dr[iControl]["sColumnFieldName"].ToString() + " " + dr[iControl]["sSearchType"].ToString() + sReturnValue;
                                            if (oColumnDefaultValue.ToString() != "")
                                            {
                                                chk.Checked = Convert.ToBoolean(oColumnDefaultValue);
                                            }
                                            else
                                            {
                                                chk.CheckState = CheckState.Unchecked;
                                            }
                                            chk.Text = dr[iControl]["sColumnCaption"].ToString();
                                            grbFilter.Controls.Add(chk);
                                            break;
                                        }
                                    case "L":
                                        {
                                            SunriseLookUp lkp = new SunriseLookUp();
                                            lkp.Size = new Size(120, 21);
                                            lkp.Name = "chk" + dr[iControl]["sColumnFieldName"].ToString() + iControl.ToString();
                                            lkp.Location = new Point(10 + (80 + 120 + iControlSpace) * i + 80, 28 + (21 + 10) * j);
                                            lkp.Tag = dr[iControl]["sColumnFieldName"].ToString() + " " + dr[iControl]["sSearchType"].ToString();
                                            //初始化Lkp

                                            break;
                                        }


                                }
                                iControl++;
                                //当计数大于等于要创建的控件数量时则退出循环
                                if (iControl >= dr.Length)
                                {
                                    break;
                                }


                            }
                        }
                        
                    }
                    //分组条件控件设置
                    grbGroup.Visible = IsGroup;
                    //grbGroup.Location = new Point(10, iRows * 31 + toolStrip1.Height);
                    grbGroup.Location = new Point(10, iRows * 31 + 30);
                    grbGroup.Controls.Clear();
                    for (int i = 0; i < dtDetail.Select("bIsGroup=1").Length; i++)
                    {
                        DevExpress.XtraEditors.CheckEdit chk = new DevExpress.XtraEditors.CheckEdit();
                        chk.Size = new Size(80, 21);
                        chk.Location = new Point(5 + (80 + 5) * i, 25);
                        chk.Name = "chkGrp" + dtDetail.Select("bIsGroup=1")[i]["sColumnFieldName"].ToString() + i.ToString();
                        chk.Text = dtDetail.Select("bIsGroup=1")[i]["sColumnCaption"].ToString();
                        chk.Tag = dtDetail.Select("bIsGroup=1")[i]["sColumnFieldName"].ToString();
                        chk.Checked = true;
                        grbGroup.Controls.Add(chk);
                    }
                    grbGroup.Height = 45;
                    grbGroup.Width = dtDetail.Select("bIsGroup=1").Length * 85 + 10;


                    //设置查询条件面板高度
                    grbFilter.Height = iRows * 31 + 55 + (IsGroup == true ? grbGroup.Height : 0);
                }
            }
            catch (Exception ex)
            {
                Public.SystemInfo("创建查询条件控件错误！" + ex.Message, true);
            }
        }


        /// <summary>
        /// 通过ReportNo初始化基础数据
        /// </summary>
        private void InitBaseData()
        {
            try
            {
                if (ReportNo != "")
                {
                    string sSql = "SELECT * FROM sysQueryReportMaster WHERE sReportNo='" + ReportNo + "'";
                    dtMain = Sunrise.ERP.DataAccess.DbHelperSQL.Query(sSql).Tables[0];
                    if (dtMain.Rows.Count > 0)
                    {
                        sMainSQL = dtMain.Rows[0]["sReportSQL"].ToString();
                        //解析查询SQL
                        if (sMainSQL.ToLower().Contains("<userid>"))
                        {
                            sMainSQL = sMainSQL.Replace("<UserID>", Sunrise.ERP.Security.SecurityCenter.CurrentUserID);
                        }
                        if (sMainSQL.ToLower().Contains("<getdate>"))
                        {
                            sMainSQL = sMainSQL.Replace("<GetDate>", DateTime.Now.ToShortDateString());
                        }
                        sExecSQL = dtMain.Rows[0]["sExecSQL"].ToString();
                        sDealFields = dtMain.Rows[0]["sDealFields"].ToString();
                        sSortFields = dtMain.Rows[0]["sSortFields"].ToString();
                        //控制界面布局显示
                        //控制按钮是否可用
                        btnSet.Enabled = Convert.ToBoolean(dtMain.Rows[0]["bIsShowExecBtn"]);
                        btnSet.Text = dtMain.Rows[0]["sExecBtnText"].ToString() == "" ? "执行(&R)" : dtMain.Rows[0]["sExecBtnText"].ToString();
                        btnPrint.Enabled = Convert.ToBoolean(dtMain.Rows[0]["bIsShowPrintBtn"]);

                        //this.Text = this.Text == "" ? dtMain.Rows[0]["sReportName"].ToString() : this.Text;
                        IsChart = Convert.ToBoolean(dtMain.Rows[0]["bIsChart"].ToString());
                        IsAutoRun = Convert.ToBoolean(dtMain.Rows[0]["bIsAutoRun"].ToString());
                        if (!IsChart)
                        {
                            tbDetail.TabPages.Remove(tpChart);
                        }


                        sSql = "SELECT * FROM sysQueryReportDetail WHERE MainID=" + dtMain.Rows[0]["ID"].ToString() + " ORDER BY iSort";
                        dtDetail = Sunrise.ERP.DataAccess.DbHelperSQL.Query(sSql).Tables[0];
                        //检测是否含有分组情况
                        if (dtDetail != null)
                        {
                            IsGroup = dtDetail.Select("bIsGroup").Length > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Public.SystemInfo("初始化数据错误！" + ex.Message, true);
                
            }
        }


        /// <summary>
        /// 创建Grid列
        /// </summary>
        private void CreateGridColumn()
        {
            try
            {
                gvSearch.Columns.Clear();
                int i = 0;
                List<DataRow> LDataRows = dtDetail.Select("bIsShow=1").ToList();
                if (IsGroup)
                {
                    string sDisGroupField = "";
                    foreach (var item in GetGroupFields().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        sDisGroupField += "'" + item + "',";
                    }
                    if (sDisGroupField != "")
                    {
                        sDisGroupField = "(" + sDisGroupField.Substring(0, sDisGroupField.Length - 1) + ")";
                        //将统计字段也加入Grid列中
                        LDataRows = dtDetail.Select("bIsShow=1 AND bIsGroup=1 AND sColumnFieldName IN " + sDisGroupField).Union(dtDetail.Select("bIsStat=1")).ToList();
                    }
                    else
                    {
                        Public.SystemInfo("必须至少选择一列分组字段!");
                        return;
                    }

                }
                foreach (DataRow dr in LDataRows)
                {
                    DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                    col.FieldName = dr["sColumnFieldName"].ToString();
                    col.Caption = dr["sColumnCaption"].ToString();
                    col.Name = "col" + dr["sColumnFieldName"].ToString() + i.ToString();
                    col.Width = 100;
                    col.Visible = true;
                    col.VisibleIndex = i;
                    if (dr["sColumnType"].ToString() == "K")
                    {
                        DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit colItem = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                        colItem.AutoHeight = false;
                        colItem.Name = "repositoryItem" + dr["sColumnFieldName"].ToString() + i.ToString();
                        colItem.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
                        col.ColumnEdit = colItem;
                        gcSearch.RepositoryItems.Add(colItem);
                    }
                    //Grid Footer显示
                    if (dr["sFooterType"].ToString() != "001")
                    {
                        //001	无
                        //002	求和
                        //003	计数
                        //004	平均值
                        //005	最大值
                        //006	最小值                   
                        col.SummaryItem.FieldName = dr["sColumnFieldName"].ToString();
                        if (dr["sFooterType"].ToString() == "002")
                            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        else if (dr["sFooterType"].ToString() == "003")
                            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                        else if (dr["sFooterType"].ToString() == "004")
                            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Average;
                        else if (dr["sFooterType"].ToString() == "005")
                            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Max;
                        else if (dr["sFooterType"].ToString() == "006")
                            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Min;

                        gvSearch.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, dr["sColumnFieldName"].ToString(), col);
                    }
                    gvSearch.Columns.Add(col);
                    i++;
                }

                //添加图表值字段到ComboBox中
                if (IsChart)
                {
                    //数据值
                    cbxValueType.Properties.Items.Clear();
                    DataTable dtTemp = dtDetail.Clone();
                    foreach (DataRow item in dtDetail.Select("bChartValue"))
                    {
                        //DataRow dr = dtTemp.NewRow();
                        //dr["sColumnFieldName"] = item["sColumnFieldName"];
                        //dr["sColumnCaption"] = item["sColumnCaption"];
                        //dtTemp.Rows.Add(dr);
                        cbxValueType.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(item["sColumnCaption"].ToString(), item["sColumnFieldName"]));
                    }
                    cbxValueType.SelectedIndex = 0;
                    //cbxValueType.DataSource = dtTemp;
                    //cbxValueType.ValueMember = "sColumnFieldName";
                    //cbxValueType.DisplayMember = "sColumnCaption";


                    //比较值
                    cbxField.Properties.Items.Clear();
                    DataTable dtField = dtDetail.Clone();
                    foreach (DataRow item in dtDetail.Select("bChartField"))
                    {
                        //DataRow dr = dtField.NewRow();
                        //dr["sColumnFieldName"] = item["sColumnFieldName"];
                        //dr["sColumnCaption"] = item["sColumnCaption"];
                        //dtField.Rows.Add(dr);
                        cbxField.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(item["sColumnCaption"].ToString(), item["sColumnFieldName"]));
                    }
                    cbxField.SelectedIndex = 0;
                    //cbxField.DataSource = dtField;
                    //cbxField.ValueMember = "sColumnFieldName";
                    //cbxField.DisplayMember = "sColumnCaption";
                }
            }
            catch (Exception ex)
            {
                Public.SystemInfo("创建查询Grid列错误！" + ex.Message, true);
            }
        }



        /// <summary>
        /// 初始化Grid数据
        /// </summary>
        /// <param name="pwhere">查询条件</param>
        private void InitGridData(string pwhere)
        {
            try
            {
                string sSql = "";
                if (IsGroup)
                {
                    string sGroup = GetGroupFields();
                    if (sGroup.Length > 0)
                    {
                        sSql = "SELECT " + sGroup + sDealFields + " FROM (" + sMainSQL + ") A WHERE " + pwhere + " GROUP BY " + sGroup.Substring(0, sGroup.Length - 1) + (sSortFields == "" ? "" : (" ORDER BY " + sSortFields));
                    }
                    else
                    {
                        Public.SystemInfo("必须至少选择一列分组字段!");
                        return;
                    }


                }
                else
                {
                    sSql = "SELECT " + sDealFields + " FROM (" + sMainSQL + ") A WHERE " + pwhere + (sSortFields == "" ? "" : (" ORDER BY " + sSortFields));
                }
                pnlWait.Location = new Point(this.Width / 2 - 200, this.Height / 2 - 90);
                pnlWait.Visible = true;
                RefreshForm(true);
                dtSearch = Sunrise.ERP.DataAccess.DbHelperSQL.Query(sSql).Tables[0];
                gcSearch.DataSource = dtSearch;
                pnlWait.Visible = false;
                RefreshForm(true);

            }
            catch (Exception ex)
            {
                Public.SystemInfo("创建查询Grid数据错误！" + ex.Message, true);
            }
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            if (IsGroup)
            {
                if (GetGroupFields() == "")
                {
                    Public.SystemInfo("如果存在分组统计查询，则必须至少选择一列分组字段！");
                    return;
                }
                CreateGridColumn();
            }
            InitGridData("1=1 " + GetSearchFilterSQL());
            if (tbDetail.SelectedTabPageIndex == 1)
            {
                ShowChart();
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control item in grbFilter.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                    else if (item is DevExpress.XtraEditors.DateEdit)
                    {
                        ((DevExpress.XtraEditors.DateEdit)item).EditValue = null;
                        //item.Text = "";
                    }
                    else if (item is DevExpress.XtraEditors.TextEdit)
                    {
                        item.Text = "";
                    }
                    else if (item is DevExpress.XtraEditors.ComboBoxEdit)
                    {
                        ((DevExpress.XtraEditors.ComboBoxEdit)item).SelectedIndex = -1;
                    }
                    else if (item is DevExpress.XtraEditors.CheckEdit)
                    {
                        ((DevExpress.XtraEditors.CheckEdit)item).Checked = false;
                    }


                }
            }
            catch (Exception ex)
            {
                Public.SystemInfo("清除过滤条件错误！" + ex.Message, true);
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtSearch.Rows.Count > 0)
                {
                    report.AddReportData(dtSearch, "查询数据");
                    report.ReportMenu.Show(btnPrint, new Point(0, btnPrint.Height));
                }
                else
                {
                    Public.SystemInfo("请先查询出数据后再打印！");
                }
            }
            catch (Exception ex)
            {
                Public.SystemInfo("打印错误，请关闭窗口重试！" + ex.Message, true);
            }
        }


        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtSearch.Rows.Count > 0)
                {
                    if (gvSearch.FocusedRowHandle >= 0 && sExecSQL != "")
                    {
                        if (Public.SystemInfo("确认执行？",MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //解析执行SQL
                            foreach (DataColumn item in dtSearch.Columns)
                            {
                                if (sExecSQL.ToLower().Contains("<userid>"))
                                {
                                    sExecSQL = sExecSQL.Replace("<UserID>", Sunrise.ERP.Security.SecurityCenter.CurrentUserID);
                                }
                                if (sExecSQL.ToLower().Contains("<getdate>"))
                                {
                                    sExecSQL = sExecSQL.Replace("<GetDate>", DateTime.Now.ToShortDateString());
                                }
                                string sReplaceField = "<" + item.ColumnName + ">";
                                if (sExecSQL.Contains(sReplaceField))
                                {
                                    sExecSQL = sExecSQL.Replace(sReplaceField, gvSearch.GetDataRow(gvSearch.FocusedRowHandle)[item.ColumnName].ToString());
                                }
                            }
                            Sunrise.ERP.DataAccess.DbHelperSQL.ExecuteSql(sExecSQL);
                            Public.SystemInfo("执行成功，请重新查询数据！");
                            sExecSQL = dtMain.Rows[0]["sExecSQL"].ToString();
                        }
                    }
                }
                else
                {
                    Public.SystemInfo("请先查询出数据后再执行！");
                }
            }
            catch (Exception ex)
            {
                Public.SystemInfo("执行错误，请关闭窗口重试！" + ex.Message,true);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 生成过滤条件
        /// </summary>
        /// <returns></returns>
        private string GetSearchFilterSQL()
        {
            try
            {
                string sResult = "";
                foreach (Control item in grbFilter.Controls)
                {
                    if (item is TextBox && item.Text != "")
                    {
                        if (item.Tag.ToString().Contains("LIKE"))
                        {
                            sResult += " AND " + item.Tag.ToString() + " '%" + item.Text + "%'";
                        }
                        else
                        {
                            sResult += " AND " + item.Tag.ToString() + " '" + item.Text + "'";
                        }
                    }
                    else if (item is DevExpress.XtraEditors.TextEdit && item.Text != "")
                    {
                        if (item.Tag.ToString().Contains("LIKE"))
                        {
                            sResult += " AND " + item.Tag.ToString() + " '%" + item.Text + "%'";
                        }
                        else
                        {
                            sResult += " AND " + item.Tag.ToString() + " '" + item.Text + "'";
                        }
                    }
                    else if (item is DevExpress.XtraEditors.DateEdit)
                    {
                        if (item.Text != "")
                        {
                            sResult += " AND " + item.Tag.ToString() + " '" + item.Text + "'";
                        }
                    }
                    else if (item is DevExpress.XtraEditors.CheckEdit)
                    {
                        if (((DevExpress.XtraEditors.CheckEdit)item).Checked)
                        {
                            sResult += " AND " + item.Tag.ToString();
                        }
                    }


                }
                return sResult;
            }
            catch (Exception ex)
            {
                Public.SystemInfo("生成过滤条件错误！" + ex.Message, true);
                return "1=2";
            }
        }


        /// <summary>
        /// 界面上选择分组字段
        /// </summary>
        /// <returns></returns>
        private string GetGroupFields()
        {
            string sResult = "";
            try
            {
                //返回界面上选择分组字段
                foreach (Control item in grbGroup.Controls)
                {
                    if (item is DevExpress.XtraEditors.CheckEdit)
                    {
                        if (((DevExpress.XtraEditors.CheckEdit)item).Checked)
                        {
                            sResult += item.Tag.ToString() + ",";
                        }
                    }
                }
                return sResult;
            }
            catch (Exception)
            {
                //异常则返回所有分组字段
                if (dtDetail != null)
                {
                    foreach (DataRow item in dtDetail.Select("bIsShow=1 AND bIsGroup=1"))
                    {
                        sResult += item["sColumnFieldName"].ToString() + ",";
                    }
                }
                return sResult;
            }
        }

        /// <summary>
        /// 显示图表
        /// </summary>
        private void ShowChart()
        {
            try
            {
                switch (cbxChartType.EditValue.ToString())
                {
                    case "柱图":
                        {
                            ShowBar();
                            break;
                        }
                    case "饼图":
                        {
                            ShowPie();
                            break;
                        }
                    case "线图":
                        {
                            ShowLine();
                            break;
                        }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 显示柱图
        /// </summary>
        private void ShowBar()
        {
            if (cbxValueType.Text != null && cbxValueType.Text != "")
            {
                if (dtSearch != null && dtSearch.Rows.Count > 0)
                {
                    chtMain.DataSource = dtSearch;
                    chtMain.Series.Clear();
                    //chtMain.Titles.Clear();
                    //ChartTitle title = new ChartTitle();
                    //title.Text = dtMain.Rows[0]["ReportName"].ToString();
                    //chtMain.Titles.Add(title);
                    foreach (DataRow item in dtDetail.Select("bChartValue AND sColumnFieldName='" + cbxValueType.EditValue.ToString()+"'"))
                    {
                        Series series = new Series(item["sColumnCaption"].ToString(), ViewType.Bar);
                        series.ArgumentDataMember = cbxField.EditValue.ToString();
                        series.ValueDataMembers[0] = item["sColumnFieldName"].ToString();
                        chtMain.Series.Add(series);
                    }
                }



            }
        }


        /// <summary>
        /// 显示饼图
        /// </summary>
        private void ShowPie()
        {
            if (cbxValueType.Text != null && cbxValueType.Text != "")
            {
                if (dtSearch != null && dtSearch.Rows.Count > 0)
                {
                    chtMain.DataSource = dtSearch;
                    chtMain.Series.Clear();
                    //chtMain.Titles.Clear();
                    //ChartTitle title = new ChartTitle();
                    //title.Text = dtMain.Rows[0]["ReportName"].ToString();
                    //chtMain.Titles.Add(title);
                    foreach (DataRow item in dtDetail.Select("bChartValue AND sColumnFieldName='" + cbxValueType.EditValue.ToString() + "'"))
                    {
                        Series series = new Series(item["sColumnCaption"].ToString(), ViewType.Pie);
                        ((PiePointOptions)series.PointOptions).PointView = PointView.ArgumentAndValues;
                        ((PiePointOptions)series.PointOptions).PercentOptions.ValueAsPercent = false;
                        series.ArgumentDataMember = cbxField.EditValue.ToString();
                        series.ValueDataMembers[0] = item["sColumnFieldName"].ToString();
                        chtMain.Series.Add(series);
                    }
                }
            }
        }


        /// <summary>
        /// 显示线图
        /// </summary>
        private void ShowLine()
        {
            if (cbxValueType.Text != null && cbxValueType.Text != "")
            {
                if (dtSearch != null && dtSearch.Rows.Count > 0)
                {
                    chtMain.DataSource = dtSearch;
                    chtMain.Series.Clear();


                    //chtMain.Titles.Clear();
                    //ChartTitle title = new ChartTitle();
                    //title.Text = dtMain.Rows[0]["ReportName"].ToString();
                    //chtMain.Titles.Add(title);
                    foreach (DataRow item in dtDetail.Select("bChartValue AND sColumnFieldName='" + cbxValueType.EditValue.ToString() + "'"))
                    {
                        Series series = new Series(item["sColumnCaption"].ToString(), ViewType.Line);
                        series.ArgumentDataMember = cbxField.EditValue.ToString();
                        series.ValueDataMembers[0] = item["sColumnFieldName"].ToString();
                        chtMain.Series.Add(series);
                    }
                }
            }
        }


        private void cbxChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbDetail.SelectedTabPageIndex == 1)
            {
                ShowChart();
            }
        }


        #endregion


        #region 属性设置
        private string reportno = "";
        /// <summary>
        /// 查询报表编号
        /// </summary>
        public string ReportNo
        {
            get
            {
                if (reportno == "")
                    reportno = Sunrise.ERP.BasePublic.Base.GetFormParaList(FormID)["ReportNo"].ToString();
                return reportno;
            }
            set
            {
                reportno = value;
            }
        }
        #endregion


        private void tbDetail_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tbDetail.SelectedTabPageIndex == 1)
            {
                ShowChart();
            }
        }

        private void gvSearch_DoubleClick(object sender, EventArgs e)
        {
            //
            int iFormID = 0;
            if (gvSearch.GetFocusedDataRow() != null && CheckCanOpenFormField(gvSearch.FocusedColumn.FieldName,ref iFormID))
            {
                string sFormText = "";
                string sModuleName = "";//tvMenu.FocusedNode.GetValue("sModuleName").ToString();
                string sPath = "";
                string sClassName = "";                

                bool HasUserIDField = false;
                //先检测是否存在sUserID字段，如果没有则无法打开模块，sUserID是制单人，用于检测权限的，必须要存在
                foreach (DataRow dr in dtDetail.Rows)
                {
                    if (dr["sColumnFieldName"].ToString().ToLower() == "suserid")
                    {
                        HasUserIDField = true;
                        break;
                    }
                }
                if (!HasUserIDField)
                {
                    Public.SystemInfo("不存在sUserID字段，请检查查询配置！");
                    return;
                }

                //先判断当前用户是否含有此模块的权限，取得菜单表中信息，检查是否含有此模块
                bool HasFormID = false;
                foreach (DataRow dr in SecurityCenter.SysMenuDataSet.Tables[0].Rows)
                {
                    if (dr["iFormID"].ToString() == iFormID.ToString())
                    {
                        HasFormID = true;
                        //加载菜单信息中相关打开窗体需要的数据
                        sFormText = dr["sMenuName"].ToString();
                        sModuleName = dr["sModuleName"].ToString();
                        sPath = Application.StartupPath + @"\Modules\" + sModuleName;
                        if (System.IO.File.Exists(sPath))
                        {
                            sClassName = dr["sModuleName"].ToString().Replace("dll", dr["sFormClassName"].ToString());
                        }
                        else
                        {
                            return;
                        }

                        break;
                    }
                }

                if (!HasFormID)
                {
                    Public.SystemInfo("您没有此模块的查询权限，请联系管理员！");
                    return;
                }

                //打开窗体前，先检测当前用户是否具有此条数据的查询权限
                SecurityCenter SC = new SecurityCenter();
                if (!SC.CheckAuth(SecurityOperation.View, iFormID, gvSearch.GetFocusedDataRow()["sUserID"].ToString()))
                {
                    Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "NoQueryAuth"));
                    return;
                }

                //打开模块窗体
                if (HaveOpened(sFormText, gvSearch.FocusedColumn.FieldName, gvSearch.GetFocusedValue().ToString()))
                {
                    pnlWait.Location = new Point(this.Width / 2 - 200, this.Height / 2 - 90);
                    pnlWait.Visible = true;
                    RefreshForm(true);
                    Cursor = Cursors.Default;
                    try
                    {
                        Form frmobject = (Form)Assembly.LoadFile(sPath).CreateInstance(sClassName, true, BindingFlags.CreateInstance, null, new object[] { iFormID, sFormText }, null, null);
                        frmobject.MdiParent = (Form)this.Parent.Parent;
                        frmobject.Show();
                        ((frmDynamicSingleForm)frmobject).LoadFormData(gvSearch.FocusedColumn.FieldName, gvSearch.GetFocusedValue().ToString());
                        //picBack.Visible = false;

                    }
                    catch (Exception)
                    {
                        Public.SystemInfo(LangCenter.Instance.GetSystemMessage("SysModuleError"), true);
                    }
                    pnlWait.Visible = false;
                    RefreshForm(true);
                }


            }
        }
        //((Form)this.Parent.Parent).MdiChildren[0].BringToFront();
        //((BaseForm.frmDynamicSingleForm)((Form)this.Parent.Parent).MdiChildren[0]).LoadFormData(2);
        private bool HaveOpened(string childname,string billnofield, string billno)
        {
            //查看窗口是否已经被打开
            bool bReturn = true;
            for (int i = 0; i < ((Form)this.Parent.Parent).MdiChildren.Length; i++)
            {
                if (((Form)this.Parent.Parent).MdiChildren[i].Text == childname)
                {
                    ((Form)this.Parent.Parent).MdiChildren[i].BringToFront();
                    ((frmDynamicSingleForm)((Form)this.Parent.Parent).MdiChildren[i]).LoadFormData(billnofield, billno);
                    bReturn = false;
                    break;
                }
            }
            return bReturn;
        }

        /// <summary>
        /// 检查当前字段是否设置了iFormID确定可以打开模块窗体
        /// </summary>
        /// <param name="focusedfield"></param>
        /// <returns></returns>
        private bool CheckCanOpenFormField(string focusedfield, ref int formid)
        {
            string FieldsList = "";
            foreach (DataRow dr in dtDetail.Select("iFormID<>NULL OR iFormID<>0"))
            {
                FieldsList += dr["sColumnFieldName"].ToString() + ",";
                if (dr["sColumnFieldName"].ToString() == focusedfield)
                    formid = Convert.ToInt32(dr["iFormID"]);
            }

            return FieldsList.ToLower().Contains(focusedfield.ToLower());
        }

        Cursor currentCursor;
        private void RefreshForm(bool b)
        {
            if (b)
            {
                currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                Refresh();
            }
            else
                Cursor.Current = currentCursor;
        }
    }
}
