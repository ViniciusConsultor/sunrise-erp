using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.Module.SystemBase
{
    public partial class frmbasDataDict : Sunrise.ERP.BaseForm.frmMasterDetail
    {
        public frmbasDataDict(int formid, string formtext)
            : base(formid, "Sunrise.ERP.SystemModule.DAL", "basDataDictMasterDAL")
        {
            InitializeComponent();
            if (formtext != "")
            {
                this.Text = formtext;
            }
            txtsDictCategoryNo.DataBindings.Add("EditValue", dsMain, "sDictCategoryNo");
            txtsDictCategoryCName.DataBindings.Add("EditValue", dsMain, "sDictCategoryCName");
            txtsDictCategoryEName.DataBindings.Add("EditValue", dsMain, "sDictCategoryEName");
        }

        public override void initBase()
        {
            AddNotNullFields(new string[] { "txtsDictCategoryNo", "txtsDictCategoryCName" });
            base.initBase();
        }

        private void frmbasDictData_Load(object sender, EventArgs e)
        {
            AddDetailData("basDataDictDetailDAL", "MainID", "ID", "sDictDataNo");
            gcDetail.DataSource = LDetailDataSet[LDetailDALName.IndexOf("basDataDictDetailDAL")];
            gcDetail.DataMember = "ds";
            DataStateChange(sender, e);
        }

        public override void MasterAllScroll(object sender, EventArgs e)
        {
            base.MasterAllScroll(sender, e);
            gcDetail.DataSource = LDetailDataSet[LDetailDALName.IndexOf("basDataDictDetailDAL")];
        }

        public override void DataStateChange(object sender, EventArgs e)
        {
            base.DataStateChange(sender, e);
            if (FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsEdit || FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsInsert)
            {
                this.gvDetail.OptionsBehavior.Editable = true;
                pnlDetailMenu.Enabled = true;
            }
            else
            {
                this.gvDetail.OptionsBehavior.Editable = false;
                pnlDetailMenu.Enabled = false;
            }

        }

        private void btnDetailAdd_Click(object sender, EventArgs e)
        {
            gvDetail.AddNewRow();
        }

        private void btnDetailDelete_Click(object sender, EventArgs e)
        {
            if (gvDetail.FocusedRowHandle >= 0)
            {
                gvDetail.DeleteRow(gvDetail.FocusedRowHandle);
            }
        }

        public override void btnView_Click(object sender, EventArgs e)
        {
            base.btnView_Click(sender, e);
            //RegisterMethod("basDataDictMasterDAL", true);
            //dsMain.DataSource = GetModelList(pWhere);
        }

        private void gvDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvDetail.GetFocusedDataRow()["sUserID"] = Sunrise.ERP.Security.SecurityCenter.CurrentUserID;
            gvDetail.GetFocusedDataRow()["bIsStop"] = 0;
        }
    }
}
