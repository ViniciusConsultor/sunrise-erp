using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sunrise.ERP.BasePublic;
using Sunrise.ERP.Security;
using Sunrise.ERP.DataAccess;
using Sunrise.ERP.BaseForm;

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
            ShowLeft();
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

            //Input(gvDetail,"QR002","a=b;dsa=sa;"
        }

        private void gvDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvDetail.GetFocusedDataRow()["sUserID"] = SecurityCenter.CurrentUserID;
            gvDetail.GetFocusedDataRow()["iSort"] = gvDetail.RowCount;
        }

        private void gvMain_DoubleClick(object sender, EventArgs e)
        {
            if (gvMain.GetFocusedDataRow() != null)
                ShowRight();
        }

        public override bool DoBeforceSaveInTrans(System.Data.SqlClient.SqlTransaction trans)
        {
            string sSql = "update salTest2 set sTest='Masteraabbcc1' where id=1";
            DbHelperSQL.ExecuteSql(sSql, trans);

            return base.DoBeforceSaveInTrans(trans);
        }

        public override bool DoAfterSaveInTrans(System.Data.SqlClient.SqlTransaction trans)
        {
            string sSql = "update salTest2 set sTest='Masteraabbcc13' where id=13";
            //throw new Exception();
            DbHelperSQL.ExecuteSql(sSql, trans);


            return base.DoAfterSaveInTrans(trans);

            
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            //CommonSelect.Instance.SelectData(LDetailBindingSource[LDetailTableName.IndexOf("salTestDetail")], 
            //    "QR003", 
            //    "sIPAddress=sLoginIP,sAction=sAction,sDetail=sAction", "", true);
            List<DataRow> datas = CommonSelect.Instance.SelectData("QRsalTestDetail9003", "", false);
        }
    }
}
