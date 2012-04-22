using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FastReport;
using System.Collections;
using System.Configuration;
using System.IO;
namespace Sunrise.ERP.Report
{
    public class InitReport
    {
        private DataTable dtReport;
        private byte[] bt;
        private int iDefaultChecked;
        private int iOldID;
        /// <summary>
        /// 报表菜单
        /// </summary>
        public ContextMenuStrip ReportMenu;
        private ToolStripMenuItem tsmPrintReport;
        private ToolStripMenuItem tsmChooseReport;
        private ToolStripMenuItem tsmDesginReport;
        private ToolStripMenuItem tsmAddReport;
        private ToolStripMenuItem tsmPreviewReport;
        private ToolStripMenuItem[] tsmChooseDetail;
        private FastReport.Report report;
        //设置报表数据集，支持DataSet,DataTable,DataView，还可以扩展支持
        List<DataSet> LDataSet = new List<DataSet>();
        List<string> LDataSetName = new List<string>();
        List<DataTable> LDataTable = new List<DataTable>();
        List<string> LDataTableName = new List<string>();
        List<DataView> LDataView = new List<DataView>();
        List<string> LDataViewName = new List<string>();
        List<IEnumerable> LEnumerable = new List<IEnumerable>();
        List<string> LEnumerableName = new List<string>();
        List<DataRowView> LDataRowView = new List<DataRowView>();
        List<string> LDataRowViewName = new List<string>();
        List<BindingSource> LBindingSource = new List<BindingSource>();
        List<string> LBindingSourceName = new List<string>();
        SqlConnection conn = new SqlConnection(Sunrise.ERP.BaseControl.ConnectSetting.GetSqlConnString());
        private string rpGUID;

        /// <summary>
        /// 初始化报表类
        /// </summary>
        public InitReport()
        {

        }
        /// <summary>
        /// 初始化报表类
        /// </summary>
        /// <param name="ReportGUID">报表模块GUID</param>
        /// <param name="Auth">权限字符串</param>
        public InitReport(string ReportGUID)
        {
            rpGUID = ReportGUID;
            //初始化菜单
            CreateMenu();
        }
        /// <summary>
        /// 初始化报表菜单
        /// </summary>
        private void CreateMenu()
        {
            //初始化报表类型
            conn.Open();
            dtReport = new DataTable();
            dtReport.Load(new SqlCommand("SELECT ID,sReportName,mReport,bIsDefault FROM sysReport WHERE sReportGUID='" + rpGUID + "' ORDER BY sReportName", conn).ExecuteReader());
            tsmChooseDetail = new ToolStripMenuItem[dtReport.Rows.Count];
            for (int i = 0; i < dtReport.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtReport.Rows[i]["bIsDefault"]))
                {
                    tsmChooseDetail.SetValue(new ToolStripMenuItem(dtReport.Rows[i]["sReportName"].ToString() + "(默认)"),i);
                    tsmChooseDetail[i].Name = dtReport.Rows[i]["ID"].ToString();
                    tsmChooseDetail[i].Checked = true;
                    iDefaultChecked = i;
                    iOldID = i;
                    bt = (byte[])dtReport.Rows[i]["mReport"];
                }
                else
                {
                    tsmChooseDetail.SetValue(new ToolStripMenuItem(dtReport.Rows[i]["sReportName"].ToString()), i);
                    tsmChooseDetail[i].Name = dtReport.Rows[i]["ID"].ToString();

                }
            }
            conn.Close();
            ReportMenu = new ContextMenuStrip();
            tsmPrintReport = new ToolStripMenuItem("打印(&P)");
            tsmChooseReport = new ToolStripMenuItem("选择报表(&S)");
            tsmDesginReport = new ToolStripMenuItem("设计报表(&D)");
            tsmAddReport = new ToolStripMenuItem("新增报表(&N)");
            tsmPreviewReport = new ToolStripMenuItem("打印预览(&V)");
            ToolStripSeparator tss1 = new ToolStripSeparator();
            ToolStripSeparator tss2 = new ToolStripSeparator();
            tsmChooseReport.DropDownItems.AddRange(tsmChooseDetail);
            ReportMenu.Items.Add(tsmPrintReport);
            ReportMenu.Items.Add(tss1);
            ReportMenu.Items.Add(tsmChooseReport);
            //权限控制，只有管理员才拥有设计报表和新增报表权限
            if (Sunrise.ERP.Security.SecurityCenter.IsAdmin)
            {
                ReportMenu.Items.Add(tsmDesginReport);
                ReportMenu.Items.Add(tsmAddReport);
            }
            ReportMenu.Items.Add(tss2);
            ReportMenu.Items.Add(tsmPreviewReport);
            //代理打印预览事件
            tsmPreviewReport.Click += new EventHandler(tsmPreviewReport_Click);
            //代理报表设计事件
            tsmDesginReport.Click += new EventHandler(tsmDesginReport_Click);
            //代理选择报表事件
            tsmChooseReport.DropDown.ItemClicked += new ToolStripItemClickedEventHandler(DropDown_ItemClicked);
            //代理打印事件
            tsmPrintReport.Click += new EventHandler(tsmPrintReport_Click);
            //代理新增事件
            tsmAddReport.Click += new EventHandler(tsmAddReport_Click);
        }

        private void GetData(string id)
        {
            if (iOldID != iDefaultChecked)
            {
                conn.Open();
                dtReport = new DataTable();
                dtReport.Load(new SqlCommand("SELECT mReport FROM sysReport WHERE ID=" + id, conn).ExecuteReader());
                bt = (byte[])dtReport.Rows[0]["mReport"];
                iOldID = iDefaultChecked;
                conn.Close();
            }
        }
        /// <summary>
        /// 新增报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tsmAddReport_Click(object sender, EventArgs e)
        {
            report = new FastReport.Report();
            RegReportData();
            frmReportDesign rp = new frmReportDesign(report,0);
            rp.ReportGUID = rpGUID;
            rp.ShowDialog();
            report.Dispose();
            //ClearListData();
            CreateMenu();
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tsmPrintReport_Click(object sender, EventArgs e)
        {
            if (tsmChooseReport.HasDropDownItems)
            {
                report = new FastReport.Report();
                if (!report.IsPrinting)
                {
                    GetData(tsmChooseDetail[iDefaultChecked].Name);
                    report.Load(new MemoryStream(bt));
                    RegReportData();
                }
                //是否显示打印机选择对话框
                report.PrintSettings.ShowDialog = ShowPrintDialog;
                report.Print();
                report.Dispose();
            }
        }
        /// <summary>
        /// 设计报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tsmDesginReport_Click(object sender, EventArgs e)
        {
            if (tsmChooseReport.HasDropDownItems)
            {
                report = new FastReport.Report();
                if (!report.IsDesigning)
                {
                    GetData(tsmChooseDetail[iDefaultChecked].Name);
                    report.Load(new MemoryStream(bt));
                    RegReportData();
                }
                frmReportDesign rp = new frmReportDesign(report, Convert.ToInt32(tsmChooseDetail[iDefaultChecked].Name));
                rp.ReportGUID = rpGUID;
                rp.ShowDialog();
                report.Dispose();
                //刷新菜单
                CreateMenu();
            }
        }
        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tsmPreviewReport_Click(object sender, EventArgs e)
        {
            if (tsmChooseReport.HasDropDownItems)
            {
                report = new FastReport.Report();
                if (!report.IsRunning)
                {
                    GetData(tsmChooseDetail[iDefaultChecked].Name);
                    report.Load(new MemoryStream(bt));
                    RegReportData();
                }
                frmReportPreview rp = new frmReportPreview(report);
                rp.ShowDialog();
                report.Dispose();
            }
        }

        /// <summary>
        /// 选择报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DropDown_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            for (int i = 0; i < tsmChooseReport.DropDownItems.Count; i++)
            {
                if (tsmChooseDetail[i].Name == e.ClickedItem.Name)
                {
                    iDefaultChecked = i;
                    tsmChooseDetail[i].Checked = true;
                }
                else
                {
                    tsmChooseDetail[i].Checked = false;
                }
            }
            //选择报表后立即打印预览
            tsmPreviewReport_Click(sender, e);
        }
        /// <summary>
        /// 添加报表数据集
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="dsName">数据集别名</param>
        public void AddReportData(DataSet ds, string dsName)
        {
            LDataSet.Add(ds);
            LDataSetName.Add(dsName);
        }
        /// <summary>
        /// 添加报表数据集
        /// </summary>
        /// <param name="ds">DataSet</param>
        public void AddReportData(DataSet ds)
        {
            LDataSet.Add(ds);
            LDataSetName.Add("");
        }
        /// <summary>
        /// 添加报表数据集
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="dtName">数据集别名</param>
        public void AddReportData(DataTable dt, string dtName)
        {
            LDataTable.Add(dt);
            LDataTableName.Add(dtName);
        }
        /// <summary>
        /// 添加报表数据集
        /// </summary>
        /// <param name="dt">DataTable</param>
        public void AddReportData(DataTable dt)
        {
            LDataTable.Add(dt);
            LDataTableName.Add("");
        }
        /// <summary>
        /// 添加报表数据集
        /// </summary>
        /// <param name="dv">DataView</param>
        /// <param name="dvName">数据集别名</param>
        public void AddReportData(DataView dv, string dvName)
        {
            LDataView.Add(dv);
            LDataViewName.Add(dvName);
        }
        /// <summary>
        /// 添加报表数据集
        /// </summary>
        /// <param name="dv">DataView</param>
        public void AddReportData(DataView dv)
        {
            LDataView.Add(dv);
            LDataViewName.Add("");
        }
        /// <summary>
        /// 添加报表数据集
        /// </summary>
        /// <param name="data">Enumerable数据</param>
        public void AddReportData(IEnumerable data)
        {
            LEnumerable.Add(data);
            LEnumerableName.Add("");
        }

        /// <summary>
        /// 添加报表数据集
        /// </summary>
        /// <param name="data">Enumerable数据</param>
        /// <param name="dataname">数据集别名</param>
        public void AddReportData(IEnumerable data,string dataname)
        {
            LEnumerable.Add(data);
            LEnumerableName.Add(dataname);
        }

        /// <summary>
        /// 添加报表数据集
        /// </summary>
        /// <param name="data">DataRowView数据</param>
        /// <param name="dataname">数据集别名</param>
        public void AddReportData(DataRowView data, string dataname)
        {
            LDataRowView.Add(data);
            LDataRowViewName.Add(dataname);
        }

        /// <summary>
        /// 添加报表数据集
        /// </summary>
        /// <param name="data">BindingSource数据源</param>
        /// <param name="dataname">数据集别名</param>
        public void AddReportData(BindingSource data, string dataname)
        {
            LBindingSource.Add(data);
            LBindingSourceName.Add(dataname);
        }

        /// <summary>
        /// 注册报表数据集
        /// </summary>
        private void RegReportData()
        {
            //report.RegisterData(FData);
            if (LDataSet.Count > 0)
            {
                for (int i = 0; i < LDataSet.Count; i++)
                {
                    report.RegisterData(LDataSet[i], LDataSetName[i]);
                }
            }
            if (LDataTable.Count > 0)
            {
                for (int i = 0; i < LDataTable.Count; i++)
                {
                    report.RegisterData(LDataTable[i], LDataTableName[i]);
                }
            }
            if (LDataView.Count > 0)
            {
                for (int i = 0; i < LDataView.Count; i++)
                {
                    report.RegisterData(LDataView[i], LDataViewName[i]);
                }
            }
            if (LEnumerable.Count > 0)
            {
                for (int i = 0; i < LEnumerable.Count; i++)
                {
                    report.RegisterData(LEnumerable[i], LEnumerableName[i]);
                }
            }
            if (LBindingSource.Count > 0)
            {
                for (int i = 0; i < LBindingSource.Count; i++)
                {
                    DataTable dtTmp = ((DataSet)LBindingSource[i].DataSource).Tables[0];
                    report.RegisterData(dtTmp, LBindingSourceName[i]);
                }
            }
            for (int i = 0; i < LDataRowView.Count; i++)
            {
                report.RegisterData(Sunrise.ERP.BasePublic.SysPublic.ConvertDataRowViewToTable(LDataRowView[i]), LDataRowViewName[i]);
            }
            //默认添加公司信息
            DataTable dtCompany = Sunrise.ERP.DataAccess.DbHelperSQL.Query("SELECT TOP 1 * FROM hrCompanyMaster ORDER BY sCompanyID").Tables[0];
            report.RegisterData(dtCompany, "公司信息");
        }
        /// <summary>
        /// 打印预览
        /// </summary>
        public void PreviewReport()
        {
            tsmPreviewReport_Click(null, null);
        }
        /// <summary>
        /// 打印
        /// </summary>
        public void PrintReport()
        {
            tsmPrintReport_Click(null, null);
        }

        private bool _isShowPrintDlg = true;
        /// <summary>
        /// 直接打印时是否显示选择打印机对话框
        /// </summary>
        public bool ShowPrintDialog
        {
            get
            {
                return _isShowPrintDlg;
            }
            set
            {
                _isShowPrintDlg = value;
            }
        }
    }
}
