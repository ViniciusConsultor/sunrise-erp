using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using Sunrise.ERP.BaseControl;
using Sunrise.ERP.DataAccess;
using Sunrise.ERP.Controls;

namespace Sunrise.ERP.BaseForm
{
    public partial class frmCommSelectForm : Sunrise.ERP.BaseForm.frmForm
    {
        DataTable dtMain = new DataTable();
        DataTable dtDetail = new DataTable();
        DataTable dtSearch = new DataTable();
        private bool AutoSelect = false;
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
        /// 是否自动运行查询
        /// </summary>
        bool IsAutoRun = false;

        public frmCommSelectForm(string reportno)
        {
            InitializeComponent();
            ReportNo = reportno;
        }

        public frmCommSelectForm(string reportno, string pwhere)
        {
            InitializeComponent();
            ReportNo = reportno;
            AuthSQL = pwhere;
        }

        public frmCommSelectForm(string reportno, string pwhere,bool autoselect)
        {
            InitializeComponent();
            ReportNo = reportno;
            AuthSQL = pwhere;
            AutoSelect = autoselect;
        }

        #region 属性设置
        private string reportno = "";
        /// <summary>
        /// 查询报表编号
        /// </summary>
        public string ReportNo
        {
            get { return reportno; }
            set { reportno = value; }
        }

        private DataRow[] dtResult;
        /// <summary>
        /// 返回的数据结果
        /// </summary>
        public DataRow[] ResultData
        {
            get { return dtResult; }
            set { dtResult = value; }
        }

        private string authsql = "";
        /// <summary>
        /// 权限SQL
        /// </summary>
        public string AuthSQL
        {
            get { return authsql; }
            set { authsql = value; }
        }
        #endregion

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

                    //设置查询条件面板高度
                    grbFilter.Height = iRows * 31 + 55;
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
                    dtMain = DbHelperSQL.Query(sSql).Tables[0];
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
                        sDealFields = dtMain.Rows[0]["sDealFields"].ToString();
                        sSortFields = dtMain.Rows[0]["sSortFields"].ToString();
                        IsAutoRun = Convert.ToBoolean(dtMain.Rows[0]["bIsAutoRun"].ToString());
                        this.Text = dtMain.Rows[0]["sReportName"].ToString();
                        sSql = "SELECT * FROM sysQueryReportDetail WHERE MainID=" + dtMain.Rows[0]["ID"].ToString() + " ORDER BY iSort";
                        dtDetail = DbHelperSQL.Query(sSql).Tables[0];
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
                int i = 1;
                List<DataRow> LDataRows = dtDetail.Select("bIsShow=1").ToList();

                //创建选择列
                DevExpress.XtraGrid.Columns.GridColumn col0 = new DevExpress.XtraGrid.Columns.GridColumn();
                col0.FieldName = "bCheck";
                col0.Caption = "选择";
                col0.Name = "colbCheck0";
                col0.Width = 50;
                col0.Visible = true;
                col0.VisibleIndex = 0;
                col0.OptionsColumn.AllowEdit = true;
                DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit colItemCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                colItemCheck.AutoHeight = false;
                colItemCheck.Name = "repositoryItembCheck0";
                colItemCheck.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
                col0.ColumnEdit = colItemCheck;
                
                gcSearch.RepositoryItems.Add(colItemCheck);
                gvSearch.Columns.Add(col0);

                foreach (DataRow dr in LDataRows)
                {
                    DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                    col.FieldName = dr["sColumnFieldName"].ToString();
                    col.Caption = dr["sColumnCaption"].ToString();
                    col.Name = "col" + dr["sColumnFieldName"].ToString() + i.ToString();
                    col.Width = 100;
                    col.Visible = true;
                    col.VisibleIndex = i;
                    col.OptionsColumn.AllowEdit = false;
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
                string sSql = "SELECT " + sDealFields + " FROM (" + sMainSQL + ") A WHERE " + pwhere + (sSortFields == "" ? "" : (" ORDER BY " + sSortFields));
                dtSearch = DbHelperSQL.Query(sSql).Tables[0];

                //是否自动全部选择
                if (AutoSelect)
                {
                    foreach (DataRow dr in dtSearch.Rows)
                    {
                        dr["bCheck"] = 1;
                    }
                }
                chkAll.Checked = AutoSelect;
                gcSearch.DataSource = dtSearch;
            }
            catch (Exception ex)
            {
                Public.SystemInfo("创建查询Grid数据错误！" + ex.Message, true);
            }
        }

        /// <summary>
        /// 生成过滤条件
        /// </summary>
        /// <returns></returns>
        private string GetSearchFilterSQL()
        {
            try
            {
                string sResult = " ";
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
                return " 1=2 ";
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

        private void frmCommSelectForm_Load(object sender, EventArgs e)
        {
            InitBaseData();
            CreatSearchControl();
            CreateGridColumn();
            //控制是否自动执行查询
            if (IsAutoRun)
                InitGridData(" 1=1 " + AuthSQL + GetSearchFilterSQL());
            else
                InitGridData("1=2");
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            InitGridData(" 1=1 " + AuthSQL + GetSearchFilterSQL());
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dtSearch != null && dtSearch.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSearch.Rows)
                {
                    dr["bCheck"] = chkAll.Checked ? 1 : 0;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool isSelectedData=false;
            if (dtSearch != null && dtSearch.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSearch.Rows)
                {
                    if (Convert.ToBoolean(dr["bCheck"]))
                    {
                        isSelectedData = true;
                        break;
                    }
                }
                if (!isSelectedData)
                {
                    Public.SystemInfo("没有选择数据，请选择数据！");
                    return;
                }
            }
            else
            {
                Public.SystemInfo("没有查询出数据，请先查询数据后再选择数据！");
                return;
            }
            
            ResultData = dtSearch.Select("bCheck=1");
            DialogResult = DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }

    /// <summary>
    /// 通用选择查询
    /// </summary>
    public class CommonSelect
    {
        public CommonSelect()
        {
        }

        public static CommonSelect Instance
        {
            get { return Nested.instance; }
        }

        class Nested
        {
            static Nested() { }
            internal static readonly CommonSelect instance = new CommonSelect();
        }

        /// <summary>
        /// 选择导入数据
        /// </summary>
        /// <param name="dsDetail">导入目标数据源</param>
        /// <param name="reportno">查询编号</param>
        /// <param name="fields">导入的字段，e.g: a=b,c=d 其中a和c为目标数据源中的字段，b和d为选择数据源中的字段，多个用英文逗号“,”进行分割</param>
        /// <param name="where">选择数据源的过滤条件</param>
        /// <param name="isautoselect">是否默认选中所有数据</param>
        public void SelectData(BindingSource dsDetail, string reportno, string fields, string where,bool isautoselect)
        {
            //数据选择窗体
            frmCommSelectForm frm = new frmCommSelectForm(reportno, where, isautoselect);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.WindowState = FormWindowState.Normal;
            frm.ReportNo = reportno;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //解析需要设置值的字段
                string[] fieldstring = Public.GetSplitString(fields, ",");
                List<string> ValueFields = new List<string>();
                List<string> DataFields = new List<string>();
                foreach (string s in fieldstring)
                {
                    string[] ss = Public.GetSplitString(s, "=");
                    DataFields.Add(ss[0]);
                    ValueFields.Add(ss[1]);
                }

                //插入数据
                foreach (DataRow dr in frm.ResultData)
                {
                    dsDetail.AddNew();                    
                    for (int i = 0; i < DataFields.Count; i++)
                    {
                        ((DataRowView)dsDetail.Current).Row[DataFields[i]] = dr[ValueFields[i]];
                    }
                    dsDetail.EndEdit();
                }
            }
        }

        /// <summary>
        /// 选择导入数据
        /// </summary>
        /// <param name="dtDetail">导入目标数据源</param>
        /// <param name="reportno">查询编号</param>
        /// <param name="fields">导入的字段，e.g: a=b,c=d 其中a和c为目标数据源中的字段，b和d为选择数据源中的字段，多个用英文逗号“,”进行分割</param>
        /// <param name="where">选择数据源的过滤条件</param>
        /// <param name="isautoselect">是否默认选中所有数据</param>
        public void SelectData(DataTable dtDetail, string reportno, string fields, string where, bool isautoselect)
        {
            //数据选择窗体
            frmCommSelectForm frm = new frmCommSelectForm(reportno, where, isautoselect);
            frm.ReportNo = reportno;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.WindowState = FormWindowState.Normal;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //解析需要设置值的字段
                string[] fieldstring = Public.GetSplitString(fields, ",");
                List<string> ValueFields = new List<string>();
                List<string> DataFields = new List<string>();
                foreach (string s in fieldstring)
                {
                    string[] ss = Public.GetSplitString(fields, "=");
                    DataFields.Add(ss[0]);
                    ValueFields.Add(ss[1]);
                }

                //插入数据
                foreach (DataRow dr in frm.ResultData)
                {
                    DataRow drTmp = dtDetail.NewRow();
                    for (int i = 0; i < DataFields.Count; i++)
                    {
                        drTmp[DataFields[i]] = dr[ValueFields[i]];
                    }
                    dtDetail.Rows.Add(drTmp);
                }
            }
        }
    }
}

