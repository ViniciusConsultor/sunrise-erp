using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sunrise.ERP.Common;
using Sunrise.ERP.BasePublic;
using Sunrise.ERP.Security;
using Sunrise.ERP.DataAccess;
using DevExpress.XtraEditors.Controls;
using Sunrise.ERP.Lang;

namespace Sunrise.ERP.BaseForm
{
    public partial class frmDynamicFormSetting : Sunrise.ERP.BaseForm.frmMasterDetail
    {
        public frmDynamicFormSetting(int formid)
            : base(0, "Sunrise.ERP.BaseForm.DAL", "sysDynamicFormMasterDAL", " AND FormID=" + formid.ToString(), false)
        {
            InitializeComponent();
            txtFormID.DataBindings.Add("EditValue", dsMain, "FormID");
            txtiControlColumn.DataBindings.Add("EditValue", dsMain, "iControlColumn");
            txtiControlSpace.DataBindings.Add("EditValue", dsMain, "iControlSpace");
            txtiDefaultQueryCount.DataBindings.Add("EditValue", dsMain, "iDefaultQueryCount");
            txtsQueryViewName.DataBindings.Add("EditValue", dsMain, "sQueryViewName");
            txtsTableName.DataBindings.Add("EditValue", dsMain, "sTableName");
            lkpsFormType.DataBindings.Add("EditValue", dsMain, "sFormType");
            chkbCreateLookUp.DataBindings.Add("EditValue", dsMain, "bCreateLookUp");
            chkbSyncLookUp.DataBindings.Add("EditValue", dsMain, "bSyncLookUp");

            SystemPublic.InitLkpDataDict(lkpsFormType, "1018");

            //sFiledType
            InitDetailComboBox("1009");
            //sControlType
            InitDetailComboBox("1017");
        }

        private void frmDynamicFormSetting_Load(object sender, EventArgs e)
        {
            AddDetailData("sysDynamicFormDetailDAL", "MainID", "ID", "iSort");
            gcDetail.DataSource = LDetailDataSet[LDetailDALName.IndexOf("sysDynamicFormDetailDAL")];
            gcDetail.DataMember = "ds";

            DataStateChange(sender, e);
        }

        public override void MasterAllScroll(object sender, EventArgs e)
        {
            base.MasterAllScroll(sender, e);
            gcDetail.DataSource = LDetailDataSet[LDetailDALName.IndexOf("sysDynamicFormDetailDAL")];
        }

        public override void DataStateChange(object sender, EventArgs e)
        {
            base.DataStateChange(sender, e);
            if (FormDataFlag == DataFlag.dsEdit || FormDataFlag ==DataFlag.dsInsert)
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
            AddNotNullFields(new string[] { "txtFormID", "lkpsFormType", "txtsTableName", "txtiDefaultQueryCount" });
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
            {
                if (gvDetail.GetFocusedDataRow()["bSystemColumn"].ToString().ToLower() == "false")
                    gvDetail.DeleteRow(gvDetail.FocusedRowHandle);
            }
        }

        private void gvDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvDetail.Columns["sFieldName"].OptionsColumn.AllowEdit = true;
            gvDetail.Columns["sFieldType"].OptionsColumn.AllowEdit = true;
            gvDetail.Columns["sControlType"].OptionsColumn.AllowEdit = true;
            gvDetail.GetFocusedDataRow()["sUserID"] = SecurityCenter.CurrentUserID;
            gvDetail.GetFocusedDataRow()["iSort"] = gvDetail.RowCount;
            gvDetail.GetFocusedDataRow()["bSaveData"] = 1;
            gvDetail.GetFocusedDataRow()["bQuery"] = 0;
            gvDetail.GetFocusedDataRow()["bSystemColumn"] = 0;
            gvDetail.GetFocusedDataRow()["bNotNull"] = 0;
            gvDetail.GetFocusedDataRow()["bHistory"] = 0;
            gvDetail.GetFocusedDataRow()["bShowInGrid"] = 1;
        }

        private void InitDetailComboBox(string dictNo)
        {
            string sSql = "SELECT A.sDictDataNo, A.sDictDataCName, A.sDictDataEName "
                        + "FROM vwbasDataDictDetail A "
                        + "WHERE A.sDictCategoryNo='" + dictNo + "'";
            DataTable dtTmp = DbHelperSQL.Query(sSql).Tables[0];
            if (dictNo == "1009")
            {
                foreach (DataRow dr in dtTmp.Rows)
                {
                    ImageComboBoxItem item = new ImageComboBoxItem();
                    item.Description = LangCenter.Instance.IsDefaultLanguage ? dr["sDictDataCName"].ToString() : dr["sDictDataEName"].ToString();
                    item.Value = dr["sDictDataNo"];
                    cbxsFieldType.Items.Add(item);
                }
            }
            else if (dictNo == "1017")
            {
                foreach (DataRow dr in dtTmp.Rows)
                {
                    ImageComboBoxItem item = new ImageComboBoxItem();
                    item.Description = LangCenter.Instance.IsDefaultLanguage ? dr["sDictDataCName"].ToString() : dr["sDictDataEName"].ToString();
                    item.Value = dr["sDictDataNo"];
                    cbxsControlType.Items.Add(item);
                }
            }
        }

        private void gvDetail_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            //设置sFieldName,sFieldType,sControlType,字段不可编辑
            if (e.FocusedColumn.FieldName == "sFieldName" ||
                e.FocusedColumn.FieldName == "sFieldType" ||
                e.FocusedColumn.FieldName == "sControlType")
            {
                if ((!string.IsNullOrEmpty(gvDetail.GetFocusedRowCellValue("sFieldName").ToString()) ||
                    !string.IsNullOrEmpty(gvDetail.GetFocusedRowCellValue("sFieldType").ToString()) ||
                    !string.IsNullOrEmpty(gvDetail.GetFocusedRowCellValue("sControlType").ToString())) &&
                    !string.IsNullOrEmpty(gvDetail.GetFocusedDataRow()["ID"].ToString()))
                    e.FocusedColumn.OptionsColumn.AllowEdit = false;
                else
                    e.FocusedColumn.OptionsColumn.AllowEdit = true;
            }
        }

        private void gvDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                //设置sFieldName字段不可编辑
                if (gvDetail.GetFocusedRowCellValue("sFieldName") != null && 
                    !string.IsNullOrEmpty(gvDetail.GetFocusedRowCellValue("sFieldName").ToString()) &&
                    !string.IsNullOrEmpty(gvDetail.GetFocusedDataRow()["ID"].ToString()))
                    gvDetail.Columns["sFieldName"].OptionsColumn.AllowEdit = false;
                else
                    gvDetail.Columns["sFieldName"].OptionsColumn.AllowEdit = true;
                //设置sFieldType字段不可编辑
                if (gvDetail.GetFocusedRowCellValue("sFieldType") != null &&
                    !string.IsNullOrEmpty(gvDetail.GetFocusedRowCellValue("sFieldType").ToString()) &&
                    !string.IsNullOrEmpty(gvDetail.GetFocusedDataRow()["ID"].ToString()))
                    gvDetail.Columns["sFieldType"].OptionsColumn.AllowEdit = false;
                else
                    gvDetail.Columns["sFieldType"].OptionsColumn.AllowEdit = true;
                //设置sControlType字段不可编辑
                if (gvDetail.GetFocusedRowCellValue("sControlType") != null &&
                    !string.IsNullOrEmpty(gvDetail.GetFocusedRowCellValue("sControlType").ToString()) &&
                    !string.IsNullOrEmpty(gvDetail.GetFocusedDataRow()["ID"].ToString()))
                    gvDetail.Columns["sControlType"].OptionsColumn.AllowEdit = false;
                else
                    gvDetail.Columns["sControlType"].OptionsColumn.AllowEdit = true;
            }
        }

        public override bool DoAfterSave()
        {
            base.DoAfterSave();
            //创建LookUp
            CreateLookUp();
            //同步LookUp
            SyncLookUp();
            //创建自定义表信息
            CreateSubTable();
            return true;
        }

        private void CreateLookUp()
        {
        }

        private void SyncLookUp()
        {
        }

        private void CreateSubTable()
        {
            //先检测是否已经创建过自定义表
            string TableName=((DataRowView)dsMain.Current).Row["sTableName"].ToString();
            DataRow[] drTmp = LDetailDataSet[LDetailDALName.IndexOf("sysDynamicFormDetailDAL")].Tables[0].Select("bSystemColumn=0");
            if (drTmp != null && drTmp.Length > 0)
            {
                if (Base.IsHasSubTable(TableName))
                {
                    Base.CreateSubTableColumns(drTmp, TableName);
                }
                else
                {
                    Base.CreateSubTable(drTmp, TableName);
                }
            }
            else
            {
                Base.DeleteSubTable(TableName);
            }
        }

    }
}
