using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.Module.SystemBase
{
    public partial class frmsalGoodInfo : Sunrise.ERP.BaseForm.frmMasterDetail
    {
        string sDefaultShop = "";
        string sDefaultUnit = "";
        string sDefaultType = "";
        public frmsalGoodInfo(int formid, string formtext)
            : base(formid, "Sunrise.ERP.SystemModule.DAL", "salGoodInfoMasterDAL", "AND 1=1", "sGoodID")
        {
            InitializeComponent();
            if (formtext != "")
            {
                this.Text = formtext;
            }
            txtsGoodCName.DataBindings.Add("EditValue", dsMain, "sGoodCName");
            txtsGoodEName.DataBindings.Add("EditValue", dsMain, "sGoodEName");
            txtsGoodID.DataBindings.Add("EditValue", dsMain, "sGoodID");
            txtsRemark.DataBindings.Add("EditValue", dsMain, "sRemark");
            lkpsGoodTypeID.DataBindings.Add("EditValue", dsMain, "sGoodTypeID");
            lkpsUnitID.DataBindings.Add("EditValue", dsMain, "sUnitID");
            chkbIsStop.DataBindings.Add("EditValue", dsMain, "bIsStop");
            lkpsShopID.DataBindings.Add("EditValue", dsMain, "sShopID");
            Sunrise.ERP.Common.SystemPublic.InitLkpDataDict(lkpsUnitID, "1015");
            Sunrise.ERP.Common.SystemPublic.InitLkpDataDict(lkpsGoodTypeID, "1014");
            Sunrise.ERP.Common.SystemPublic.InitLkpShopID(lkpsShopID);

            //获取参数值
            sDefaultShop = Sunrise.ERP.BasePublic.BasePublic.FormParaList(FormID)["DefaultShop"] == null ? "" : Sunrise.ERP.BasePublic.BasePublic.FormParaList(FormID)["DefaultShop"].ToString();
            sDefaultType = Sunrise.ERP.BasePublic.BasePublic.FormParaList(FormID)["DefaultType"] == null ? "" : Sunrise.ERP.BasePublic.BasePublic.FormParaList(FormID)["DefaultType"].ToString();
            sDefaultUnit = Sunrise.ERP.BasePublic.BasePublic.FormParaList(FormID)["DefaultUnit"] == null ? "" : Sunrise.ERP.BasePublic.BasePublic.FormParaList(FormID)["DefaultUnit"].ToString();

        }

        private void frmsalGoodInfo_Load(object sender, EventArgs e)
        {
            //Sunrise.ERP.Common.FormStyleSetting.LoadFormStyle(FormID, new List<Control> { layoutControl1, gcMain, gcDetail });
            AddDetailData("salGoodInfoDetailDAL", "MainID", "ID");
            gcDetail.DataSource = LDetailDataSet[LDetailDALName.IndexOf("salGoodInfoDetailDAL")];
            gcDetail.DataMember = "ds";
            DataStateChange(sender, e);
        }

        public override void initBase()
        {
            AddNotNullFields(new string[] { "txtsGoodCName", "txtsGoodID", "lkpsGoodTypeID", "lkpsUnitID", "lkpsShopID" });
            base.initBase();
        }

        public override bool DoAppend()
        {
            base.DoAppend();
            ((DataRowView)dsMain.Current).Row["bIsStop"] = 0;
            if (sDefaultUnit != "")
            {
                ((DataRowView)dsMain.Current).Row["sUnitID"] = sDefaultUnit;
            }
            if (sDefaultType != "")
            {
                ((DataRowView)dsMain.Current).Row["sGoodTypeID"] = sDefaultType;
            }
            if (sDefaultShop != "")
            {
                ((DataRowView)dsMain.Current).Row["sShopID"] = sDefaultShop;
            }
            dsMain.EndEdit();
            return true;
        }
        public override void MasterAllScroll(object sender, EventArgs e)
        {
            base.MasterAllScroll(sender, e);
            gcDetail.DataSource = LDetailDataSet[LDetailDALName.IndexOf("salGoodInfoDetailDAL")];
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

        private void gvDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvDetail.GetFocusedDataRow()["sUserID"] = Sunrise.ERP.Security.SecurityCenter.CurrentUserID;
            gvDetail.GetFocusedDataRow()["bIsStop"] = 0;
            gvDetail.GetFocusedDataRow()["fDiscount"] = 100;
            gvDetail.GetFocusedDataRow()["fBasePrice"] = 0;
            gvDetail.GetFocusedDataRow()["fSalePrice"] = 0;
            gvDetail.GetFocusedDataRow()["fSupplierSalePrice"] = 0;
            gvDetail.GetFocusedDataRow()["dPriceDate"] = DateTime.Now.Date;
            gvDetail.GetFocusedDataRow()["iSort"] = gvDetail.RowCount;
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

        public override bool DoBeforeSave()
        {
            base.DoBeforeSave();
            if (LDetailDataSet[LDetailDALName.IndexOf("salGoodInfoDetailDAL")].Tables[0].Select("bIsStop=0").Length > 1)
            {
                Sunrise.ERP.BaseControl.Public.SystemInfo("明细数据中不允许存在多条可用价格，请确认！", true);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void frmsalGoodInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Sunrise.ERP.Common.FormStyleSetting.SaveFormStyle(FormID, new List<Control> { gcMain, gcDetail });
        }

    }
}
