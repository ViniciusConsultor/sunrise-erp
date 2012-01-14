using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.Module.SystemBase
{
    public partial class frmbasSupplier : Sunrise.ERP.BaseForm.frmMasterDetail
    {
        public frmbasSupplier(int formid, string formtext)
            : base(formid, "Sunrise.ERP.SystemModule.DAL", "basSupplierMasterDAL", " AND 1=1", "sSupplierID")
        {
            InitializeComponent();
            if (formtext != "")
            {
                this.Text = formtext;
            }
            txtCEOMobile.DataBindings.Add("EditValue", dsMain, "sSupplierCEOMobile");
            txtCEOName.DataBindings.Add("EditValue", dsMain, "sSupplierCEOName");
            txtsBankAccount.DataBindings.Add("EditValue", dsMain, "sBankAccount");
            txtsBankAdrr.DataBindings.Add("EditValue", dsMain, "sBankAdrr");
            txtsBankName.DataBindings.Add("EditValue", dsMain, "sBankName");
            txtsChnAddr.DataBindings.Add("EditValue", dsMain, "sChnAddr");
            txtsContactMan.DataBindings.Add("EditValue", dsMain, "sContactMan");
            txtsContactMobile.DataBindings.Add("EditValue", dsMain, "sContactMobile");
            txtsEmail.DataBindings.Add("EditValue", dsMain, "sEmail");
            txtsEngAddr.DataBindings.Add("EditValue", dsMain, "sEngAddr");
            txtsFax.DataBindings.Add("EditValue", dsMain, "sFax");
            txtsHomepage.DataBindings.Add("EditValue", dsMain, "sHomePage");
            txtsPostCode.DataBindings.Add("EditValue", dsMain, "sPostCode");
            txtsRemark.DataBindings.Add("EditValue", dsMain, "sRemark");
            txtsSupplierCName.DataBindings.Add("EditValue", dsMain, "sSupplierCName");
            txtsSupplierEName.DataBindings.Add("EditValue", dsMain, "sSupplierEName");
            txtsSupplierID.DataBindings.Add("EditValue", dsMain, "sSupplierID");
            txtsSupplierSName.DataBindings.Add("EditValue", dsMain, "sSupplierSName");
            txtsTax.DataBindings.Add("EditValue", dsMain, "sTax");
            txtsTel.DataBindings.Add("EditValue", dsMain, "sTel");
            lkpsSupplierTypeID.DataBindings.Add("EditValue", dsMain, "sSupplierTypeID");
            Sunrise.ERP.Common.SystemPublic.InitLkpDataDict(lkpsSupplierTypeID, "1013");

        }

        private void frmbasSupplier_Load(object sender, EventArgs e)
        {
            AddDetailData("basSupplierDetailDAL", "MainID", "ID");
            gcDetail.DataSource = LDetailDataSet[LDetailDALName.IndexOf("basSupplierDetailDAL")];
            gcDetail.DataMember = "ds";
            DataStateChange(sender, e);
        }
        public override bool DoAppend()
        {
            base.DoAppend();
            Sunrise.ERP.Common.SystemPublic.GetBillNo(FormID, (DataRowView)dsMain.Current);
            dsMain.EndEdit();
            return true;
        }
        public override void initBase()
        {
            AddNotNullFields(new string[] { "txtsSupplierID", "txtsSupplierCName", "txtsSupplierSName", "lkpsSupplierTypeID" });
            base.initBase();
        }
        public override void MasterAllScroll(object sender, EventArgs e)
        {
            base.MasterAllScroll(sender, e);
            gcDetail.DataSource = LDetailDataSet[LDetailDALName.IndexOf("basSupplierDetailDAL")];
        }

        public override void DataStateChange(object sender, EventArgs e)
        {
            base.DataStateChange(sender, e);
            if (FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsEdit || FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsInsert)
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

        private void gvDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvDetail.GetFocusedDataRow()["sUserID"] = Sunrise.ERP.Security.SecurityCenter.CurrentUserID;
        }
    }
}
