using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.Report
{
    public partial class frmReportDesign : Sunrise.ERP.BaseForm.frmForm
    {
        private FastReport.Report report;
        private string rpGUID;
        private int ReportID;
        public frmReportDesign()
        {
            InitializeComponent();
        }
        public frmReportDesign(FastReport.Report rp,int reportid)
        {
            InitializeComponent();
            report = rp;
            ReportID = reportid;
            //设置报表控件新增数据源连接字符串
            FastReport.Utils.Config.DesignerSettings.ApplicationConnection = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection;
        }
        private void frmReportDesign_Load(object sender, EventArgs e)
        {
            //designerControl1.cmdPreview.CustomAction += new EventHandler(DesignerSettings_CustomPreviewReport);
            designerControl1.cmdSave.CustomAction += new EventHandler(cmdSave_CustomAction);
          
            //FastReport.Utils.Config.DesignerSettings.CustomPreviewReport += new EventHandler(DesignerSettings_CustomPreviewReport);
            designerControl1.Report = report;
            designerControl1.RefreshLayout();
        }

        void DesignerSettings_CustomPreviewReport(object sender, EventArgs e)
        {
            frmReportPreview rp = new frmReportPreview(report);
            rp.ShowDialog();
        }

        void cmdSave_CustomAction(object sender, EventArgs e)
        {
            frmSaveReport sr = new frmSaveReport(report, rpGUID,ReportID);
            sr.ShowDialog();
        }
        /// <summary>
        /// 当前报表模块GUID
        /// </summary>
        public string ReportGUID
        {
            set
            {
                rpGUID = value;
            }
        }
    }
}
