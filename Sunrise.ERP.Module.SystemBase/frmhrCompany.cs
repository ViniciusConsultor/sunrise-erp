using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.Module.SystemBase
{
    public partial class frmhrCompany : Sunrise.ERP.BaseForm.frmMasterDetail
    {
        bool IsShowShopInfo = true;
        public frmhrCompany(int formid, string formtext)
            : base(formid, "Sunrise.ERP.SystemBase.DAL", "hrCompanyMasterDAL", "AND 1=1", "sCompanyID")
        {
            InitializeComponent();
            if (formtext != "")
            {
                this.Text = formtext;
            }
            txtsCompanyID.DataBindings.Add("EditValue", dsMain, "sCompanyID");
            txtsCompanySName.DataBindings.Add("EditValue", dsMain, "sCompanySName");
            txtsCompanyCName.DataBindings.Add("EditValue", dsMain, "sCompanyCName");
            txtsCompanyEName.DataBindings.Add("EditValue", dsMain, "sCompanyEName");
            txtsCorporation.DataBindings.Add("EditValue", dsMain, "sCorporation");
            txtsTel.DataBindings.Add("EditValue", dsMain, "sTel");
            txtsChnAddr.DataBindings.Add("EditValue", dsMain, "sChnAddr");
            txtsChnTitle.DataBindings.Add("EditValue", dsMain, "sChnTitle");
            txtsEmail.DataBindings.Add("EditValue", dsMain, "sEmail");
            txtsEngAddr.DataBindings.Add("EditValue", dsMain, "sEngAddr");
            txtsEngTitle.DataBindings.Add("EditValue", dsMain, "sEngTitle");
            txtsFax.DataBindings.Add("EditValue", dsMain, "sFax");
            txtsHomepage.DataBindings.Add("EditValue", dsMain, "sHomePage");
            txtsPostCode.DataBindings.Add("EditValue", dsMain, "sPostCode");
            txtsRemark.DataBindings.Add("EditValue", dsMain, "sRemark");
            txtsTax.DataBindings.Add("EditValue", dsMain, "sTax");
            picmlogo.DataBindings.Add("EditValue", dsMain, "mlogo");
            Sunrise.ERP.Common.SystemPublic.InitLkpCurrency(lkpsCurrency);
            lkpsCurrency.AutoSetValue(ref gvDetail, "sCurrencyCName", "sCurrencyCName");

            IsShowShopInfo = bool.Parse(Sunrise.ERP.BasePublic.Base.GetFormParaList(FormID)["IsShowShop"].ToString().ToLower());
            //通过参数来控制是否显示门店信息
            if (!IsShowShopInfo)
            {
                tcDetail.TabPages.Remove(tpShopInfo);
            }
        }

        private void frmhrCompany_Load(object sender, EventArgs e)
        {
            AddDetailData("hrCompanyDetailDAL", "MainID", "ID");
            AddDetailData("hrCompanyShopInfoDAL", "MainID", "ID");
            gcDetail.DataSource = LDetailDataSet[LDetailDALName.IndexOf("hrCompanyDetailDAL")];
            gcDetail.DataMember = "ds";
            gcShopInfo.DataSource = LDetailDataSet[LDetailDALName.IndexOf("hrCompanyShopInfoDAL")];
            gcShopInfo.DataMember = "ds";
            lkpsCurrency.DataBindings.Add("EditValue", LDetailDataSet[LDetailDALName.IndexOf("hrCompanyDetailDAL")], "ds.sCurrency");
            colbtnsCurrency.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(colbtnsCurrency_ButtonClick);
            
            DataStateChange(sender, e);
        }

        void colbtnsCurrency_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            lkpsCurrency.LookUpSelfClick(sender, e);
        }

        public override void initBase()
        {
            AddNotNullFields(new string[] { "txtsCompanyID", "txtsCompanySName", "txtsCompanyCName" });
            base.initBase();
        }
        public override void MasterAllScroll(object sender, EventArgs e)
        {
            base.MasterAllScroll(sender, e);
            gcDetail.DataSource = LDetailDataSet[LDetailDALName.IndexOf("hrCompanyDetailDAL")];
            gcShopInfo.DataSource = LDetailDataSet[LDetailDALName.IndexOf("hrCompanyShopInfoDAL")];
            lkpsCurrency.DataBindings.Clear();
            lkpsCurrency.DataBindings.Add("EditValue", LDetailDataSet[LDetailDALName.IndexOf("hrCompanyDetailDAL")], "ds.sCurrency");
        }

        public override void DataStateChange(object sender, EventArgs e)
        {
            base.DataStateChange(sender, e);
            if (FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsEdit || FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsInsert)
            {
                gvDetail.OptionsBehavior.Editable = true;
                gvShopInfo.OptionsBehavior.Editable = true;
                pnlDetailMenu.Enabled = true;
            }
            else
            {
                gvDetail.OptionsBehavior.Editable = false;
                gvShopInfo.OptionsBehavior.Editable = false;
                pnlDetailMenu.Enabled = false;
            }

        }

        private void btnDetailAdd_Click(object sender, EventArgs e)
        {
            switch (tcDetail.SelectedTabPageIndex)
            {
                case 0:
                    {
                        gvDetail.AddNewRow();
                        break;
                    }
                case 1:
                    {
                        gvShopInfo.AddNewRow();
                        break;
                    }
            }            
        }

        private void btnDetailDelete_Click(object sender, EventArgs e)
        {
            switch (tcDetail.SelectedTabPageIndex)
            {
                case 0:
                    {
                        if (gvDetail.FocusedRowHandle >= 0)
                        {
                            gvDetail.DeleteRow(gvDetail.FocusedRowHandle);
                        }
                        break;
                    }
                case 1:
                    {
                        if (gvShopInfo.FocusedRowHandle >= 0)
                        {
                            gvShopInfo.DeleteRow(gvShopInfo.FocusedRowHandle);
                        }
                        break;
                    }
            }     
        }

        private void picmlogo_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            if (picmlogo.Image == null)
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore;
                ((DataRowView)dsMain.Current).Row["mlogo"] = null;
            }
        }

        private void gvDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvDetail.GetFocusedDataRow()["sUserID"] = Sunrise.ERP.Security.SecurityCenter.CurrentUserID;
        }

        private void gvShopInfo_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvShopInfo.GetFocusedDataRow()["sUserID"] = Sunrise.ERP.Security.SecurityCenter.CurrentUserID;
        }
    }
}
