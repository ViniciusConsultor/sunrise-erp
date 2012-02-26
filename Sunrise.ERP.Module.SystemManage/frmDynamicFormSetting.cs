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
using Sunrise.ERP.Lang;
using Sunrise.ERP.BaseControl;

using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace Sunrise.ERP.Module.SystemManage
{
    public partial class frmDynamicFormSetting : Sunrise.ERP.BaseForm.frmMasterDetail
    {
        bool FieldAllowEdit = false;

        public frmDynamicFormSetting(int formid, string formtext)
            : base(formid, "Sunrise.ERP.BaseForm.DAL", "sysDynamicFormMasterDAL", false)
        {
            InitializeComponent();
            Text = formtext;
            txtsMenuName.DataBindings.Add("EditValue", dsMain, "sMenuName");
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
            InitDetailComboBox("1009", cbxsFieldType);
            //sControlType
            InitDetailComboBox("1017", cbxsControlType);
            //sColumnType
            InitDetailComboBox("1019", cbxsColumnType);
            //sFooterType
            InitDetailComboBox("1020", cbxsFooterType);

            try
            {
                //加载窗体参数控制字段名称，字段类型，控件类型是否允许编辑
                FieldAllowEdit = bool.Parse(Base.GetFormParaList(FormID)["FieldAllowEdit"].ToString());
            }
            catch { }
        }

        private void frmDynamicFormSetting_Load(object sender, EventArgs e)
        {
            LoadLangSetting();

            AddDetailData("sysDynamicFormDetailDAL", "MainID", "ID", "iSort");
            gcDetail.DataSource = LDetailDataSet[LDetailDALName.IndexOf("sysDynamicFormDetailDAL")];
            gcDetail.DataMember = "ds";

            DataStateChange(sender, e);
        }

        public override void MasterAllScroll(object sender, EventArgs e)
        {
            base.MasterAllScroll(sender, e);
            if (LDetailDataSet.Count > 0)
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
            gvDetail.GetFocusedDataRow()["bShowInPanel"] = 1;
            gvDetail.GetFocusedDataRow()["sFooterType"] = "001";
            gvDetail.GetFocusedDataRow()["bEdit"] = 1;
            //默认为数据字段，价格和数量用于控制权限是否显示此列
            gvDetail.GetFocusedDataRow()["sColumnType"] = "001";
        }

        /// <summary>
        /// 初始化Grid中ComboBox数据
        /// </summary>
        /// <param name="dictNo"></param>
        /// <param name="combobox"></param>
        private void InitDetailComboBox(string dictNo, RepositoryItemComboBox combobox)
        {
            DataTable dtTmp = SystemPublic.GetDictData(dictNo);
            combobox.Items.Clear();
            foreach (DataRow dr in dtTmp.Rows)
            {
                ImageComboBoxItem item = new ImageComboBoxItem();
                item.Description = LangCenter.Instance.IsDefaultLanguage ? dr["sDictDataCName"].ToString() : dr["sDictDataEName"].ToString();
                item.Value = dr["sDictDataNo"];
                combobox.Items.Add(item);
            }
        }

        private void gvDetail_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (!FieldAllowEdit)
            {
                //设置sFieldName,sFieldType,sControlType,字段不可编辑
                if (e.FocusedColumn.FieldName == "sFieldName" ||
                    e.FocusedColumn.FieldName == "sFieldType" ||
                    e.FocusedColumn.FieldName == "sControlType")
                {
                    if (gvDetail.GetFocusedDataRow() != null && 
                        (!string.IsNullOrEmpty(gvDetail.GetFocusedRowCellValue("sFieldName").ToString()) ||
                        !string.IsNullOrEmpty(gvDetail.GetFocusedRowCellValue("sFieldType").ToString()) ||
                        !string.IsNullOrEmpty(gvDetail.GetFocusedRowCellValue("sControlType").ToString())) &&
                        !string.IsNullOrEmpty(gvDetail.GetFocusedDataRow()["ID"].ToString()))
                        e.FocusedColumn.OptionsColumn.AllowEdit = false;
                    else
                        e.FocusedColumn.OptionsColumn.AllowEdit = true;
                }
            }
        }

        private void gvDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                if (!FieldAllowEdit)
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
        }

        public override bool DoBeforeSave()
        {
            bool result= base.DoBeforeSave();
            if (result)
            {
                //验证明细数据中字段名称不能够重复
                string sFieldName = string.Empty;
                DataTable dtTmp = LDetailDataSet[LDetailDALName.IndexOf("sysDynamicFormDetailDAL")].Tables[0];
                for (int i = 0; i < dtTmp.Rows.Count; i++)
                {
                    for (int j = i + 1; j < dtTmp.Rows.Count; j++)
                    {
                        //如果是已经删除的字段则不验证
                        if (dtTmp.Rows[i].RowState != DataRowState.Deleted && dtTmp.Rows[j].RowState != DataRowState.Deleted)
                            if (dtTmp.Rows[i]["sFieldName"].ToString() == dtTmp.Rows[j]["sFieldName"].ToString())
                            {
                                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("SQLDataIsRepeat"), true);
                                result = false;
                            }
                    }
                }
            }
            return result;
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
            //自定义表命名规则为原表+FormID+_Z,e.g: salTest9001_Z
            string TableName = ((DataRowView)dsMain.Current).Row["sTableName"].ToString();
            int formID = (int)((DataRowView)dsMain.Current).Row["FormID"];
            //不是系统列，并且不保存数据的列
            DataRow[] drTmp = LDetailDataSet[LDetailDALName.IndexOf("sysDynamicFormDetailDAL")].Tables[0].Select("bSystemColumn=0 AND bSaveData=1");
            if (drTmp != null && drTmp.Length > 0)
            {
                if (Base.IsHasSubTable(TableName, formID))
                    Base.CreateSubTableColumns(drTmp, TableName, formID);
                else
                    Base.CreateSubTable(drTmp, TableName, formID);
            }
            else
                Base.DeleteSubTable(TableName, formID);
        }

        /// <summary>
        /// 加载语言数据
        /// </summary>
        private void LoadLangSetting()
        {
            this.Text = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", this.Name);
            lblGroup.Text = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", lblGroup.Name);
            colbHistory.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colbHistory.Name);
            colbNotNull.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colbNotNull.Name);
            colbQuery.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colbQuery.Name);
            colbSaveData.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colbSaveData.Name);
            colbShowInGrid.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colbShowInGrid.Name);
            colbShowInPanel.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colbShowInPanel.Name);
            colsFooterType.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colsFooterType.Name);
            colbSystemColumn.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colbSystemColumn.Name);
            coliFieldLength.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", coliFieldLength.Name);
            coliSort.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", coliSort.Name);
            colsCaption.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colsCaption.Name);
            colsControlType.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colsControlType.Name);
            colsFieldName.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colsFieldName.Name);
            colsEngCaption.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colsEngCaption.Name);
            colsFormType.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colsFormType.Name);
            colsLocation.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colsLocation.Name);
            colsLookupNo.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colsLookupNo.Name);
            colsQueryViewName.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colsQueryViewName.Name);
            colsSize.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colsSize.Name);
            colsTableName.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colsTableName.Name);
            colsLookupAutoSetControl.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colsLookupAutoSetControl.Name);
            colsLookupAutoSetGrid.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colsLookupAutoSetGrid.Name);
            colsFieldType.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colsFieldType.Name);
            btnDetailAdd.Text = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", btnDetailAdd.Name);
            btnDetailDelete.Text = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", btnDetailDelete.Name);
            lbliControlColumn.Text = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", lbliControlColumn.Name);
            lbliControlSpace.Text = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", lbliControlSpace.Name);
            lbliDefaultQueryCount.Text = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", lbliDefaultQueryCount.Name);
            lblsFormType.Text = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", lblsFormType.Name);
            lblsQueryViewName.Text = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", lblsQueryViewName.Name);
            lblsTableName.Text = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", lblsTableName.Name);
            chkbCreateLookUp.Text = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", chkbCreateLookUp.Name);
            chkbSyncLookUp.Text = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", chkbSyncLookUp.Name);
            colbEdit.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colbEdit.Name);
            colsColumnType.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colsColumnType.Name);
            colbCopy.Caption = LangCenter.Instance.GetFormLangInfo("frmDynamicFormSetting", colbCopy.Name);
        }

    }
}
