using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sunrise.ERP.BasePublic;
using Sunrise.ERP.Security;

namespace Sunrise.ERP.Module.Test
{
    public partial class frmMasterDetailTest : Sunrise.ERP.BaseForm.frmDynamicMasterDetail
    {
        public frmMasterDetailTest(int formid, string formtext)
            : base(formid, "salTestMaster")
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(formtext))
                this.Text = formtext;
            CreateDynamicControl();
            CreateMasterGridColumn(gvMain);
        }

        private void frmMasterDetailTest_Load(object sender, EventArgs e)
        {
            AddDetailData("salTestDetail", "MainID", "ID");
            CreateDetailGridColumn(gvDetail, "salTestDetail");
            gcDetail.DataSource = LDetailBindingSource[LDetailTableName.IndexOf("salTestDetail")];
            DataStateChange(sender, e);
        }

        public override void DataStateChange(object sender, EventArgs e)
        {
            base.DataStateChange(sender, e);
            if (FormDataFlag == DataFlag.dsEdit || FormDataFlag == DataFlag.dsInsert)
            {
                gvDetail.OptionsBehavior.Editable = true;
                pnlDetailMenu.Enabled = true;
            }
            else
            {
                gvDetail.OptionsBehavior.Editable = false;
                pnlDetailMenu.Enabled = false;
            }
        }

        public override void initBase()
        {
            AddNotCopyFields(new string[] { "sUserID", "iFlag" });
            base.initBase();
        }

        private void btnDetailAdd_Click(object sender, EventArgs e)
        {
            gvDetail.AddNewRow();
        }

        private void btnDetailDelete_Click(object sender, EventArgs e)
        {
            if (gvDetail.FocusedRowHandle >= 0)
                gvDetail.DeleteRow(gvDetail.FocusedRowHandle);
        }

        private void gvDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvDetail.GetFocusedDataRow()["sUserID"] = SecurityCenter.CurrentUserID;
        }
    }
}
