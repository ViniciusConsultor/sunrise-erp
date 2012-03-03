using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            gvDetail.GetFocusedDataRow()["bCopy"] = 1;
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

        private void btnInsertQuerySetting_Click(object sender, EventArgs e)
        {
            if (BillID == 0) return;
            string sFormType = lkpsFormType.EditValue;
            
            //生成的查询配置编号为QR+表名+FormID
            string ReportNo = "QR" + txtsTableName.Text + txtFormID.Text;
            string ReportName = txtsMenuName.Text;
            
            bool isHaveUserColumn = false;
            bool isMasterHaveUserColumn = false;

            DataTable dtDetailData = new DataTable();
            dtDetailData.Columns.Add("sFieldName");
            dtDetailData.Columns.Add("sCaption");
            dtDetailData.Columns.Add("sFieldType");
            dtDetailData.Columns.Add("bIsQuery");
            dtDetailData.Columns.Add("bIsShow");
            dtDetailData.Columns.Add("sSearchType");
            dtDetailData.Columns.Add("sDefaultValue");
            dtDetailData.Columns.Add("sReturnValue");
            dtDetailData.Columns.Add("sFooterType");

            //查询配置历史数据
            string sHistorySql = "SELECT A.* FROM sysQueryReportDetail A LEFT JOIN sysQueryReportMaster B ON A.MainID=B.ID WHERE B.sReportNo='" + ReportNo + "'";
            DataTable dtQueryReportHistory = DbHelperSQL.Query(sHistorySql).Tables[0];

            //窗体类型为单表
            if (sFormType == "001")
            {
                string sTableName = txtsQueryViewName.Text != "" ? txtsQueryViewName.Text : txtsTableName.Text;
                string sUserTableName = txtsTableName.Text + txtFormID.Text + "_Z";
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.AppendLine();
                foreach (DataRow dr in LDetailDataSet[0].Tables[0].Rows)
                {
                    bool isSystemColumn = Convert.ToBoolean(dr["bSystemColumn"]);
                    //tabel1.name AS table1_name
                    //如果该列为自定义列，则该字段的前缀是自定义表
                    if (!isSystemColumn)
                    {
                        strSql.Append(sUserTableName + "." + dr["sFieldName"].ToString() + " AS " + sTableName + "_" + dr["sFieldName"].ToString() + ",");

                        isHaveUserColumn = true;
                    }
                    else
                        strSql.Append(sTableName + "." + dr["sFieldName"].ToString() + " AS " + sTableName + "_" + dr["sFieldName"].ToString() + ",");
                    
                    //计算要生成的明细列
                    DataRow drTmp = dtDetailData.NewRow();
                    drTmp["sFieldName"] = sTableName + "_" + dr["sFieldName"].ToString();
                    drTmp["sCaption"] = dr["sCaption"];
                    drTmp["bIsQuery"] = false;
                    drTmp["bIsShow"] = true;
                    drTmp["sSearchType"] = string.Empty;
                    drTmp["sDefaultValue"] = string.Empty;
                    drTmp["sReturnValue"] = string.Empty;
                    drTmp["sFooterType"] = "001";

                    switch (dr["sFieldType"].ToString())
                    {
                        case "S":
                        case "M":
                            {
                                drTmp["sFieldType"] = "S";
                                break;
                            }
                        case "D":
                            {
                                drTmp["sFieldType"] = "D";
                                break;
                            }
                        case "B":
                            {
                                drTmp["sFieldType"] = "K";
                                break;
                            }
                        case "I":
                        case "F":
                            {
                                drTmp["sFieldType"] = "N";
                                break;
                            }
                        default:
                            {
                                drTmp["sFieldType"] = "S";
                                break;
                            }
                    }

                    //合并历史数据
                    foreach (DataRow drHistory in dtQueryReportHistory.Rows)
                    {
                        if (drHistory["sColumnFieldName"].ToString() == sTableName + "_" + dr["sFieldName"].ToString())
                        {
                            drTmp["bIsQuery"] = drHistory["bIsQuery"];
                            drTmp["bIsShow"] = drHistory["bIsShow"];
                            drTmp["sSearchType"] = drHistory["sSearchType"];
                            drTmp["sDefaultValue"] = drHistory["sDefaultValue"];
                            drTmp["sReturnValue"] = drHistory["sReturnValue"];
                            drTmp["sFooterType"] = drHistory["sFooterType"];
                        }
                    }

                    dtDetailData.Rows.Add(drTmp);

                }
                //加入bCheck字段
                strSql.Append("basCheck.bCheck FROM " + sTableName);
                strSql.AppendLine();
                //只有含有自定义列时才将自定义表关联进来
                if (isHaveUserColumn)
                {
                    strSql.Append("LEFT JOIN " + sUserTableName + " ON " + sTableName + ".ID=" + sUserTableName + ".MainTableID");
                    strSql.AppendLine();
                }
                strSql.Append("LEFT JOIN basCheck ON " + sTableName + ".ID=basCheck.Code");

                //写入数据到查询配置中
                InsertQuertReportData(ReportNo, ReportName, strSql.ToString(), dtDetailData);

            }
            //窗体类型为Grid的时候，需要同时生成起主表信息
            else if (sFormType == "002")
            {
                string sMasterSql = "SELECT A.*,B.sTableName,B.sQueryViewName FROM sysDynamicFormDetail A LEFT JOIN sysDynamicFormMaster B ON A.MainID=B.ID WHERE B.sFormType='001' AND B.FormID=" + txtFormID.Text;
                DataTable dtMaster = DbHelperSQL.Query(sMasterSql).Tables[0];

                string sMasterTableName = "";
                string sMasterUserTableName = "";
                string sTableName = txtsQueryViewName.Text != "" ? txtsQueryViewName.Text : txtsTableName.Text;
                string sUserTableName = txtsTableName.Text + txtFormID.Text + "_Z";
                string sFKFieldName=Base.GetTableFKFieldName(sTableName);

                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.AppendLine();

                //主表字段信息
                if (dtMaster != null && dtMaster.Rows.Count > 0)
                {
                    sMasterTableName = dtMaster.Rows[0]["sQueryViewName"].ToString() != "" ? dtMaster.Rows[0]["sQueryViewName"].ToString() : dtMaster.Rows[0]["sTableName"].ToString();
                    sMasterUserTableName = dtMaster.Rows[0]["sTableName"].ToString() + txtFormID.Text + "_Z";

                    foreach (DataRow dr in dtMaster.Rows)
                    {
                        bool isSystemColumn = Convert.ToBoolean(dr["bSystemColumn"]);
                        //tabel1.name AS table1_name
                        //如果该列为自定义列，则该字段的前缀是自定义表
                        if (!isSystemColumn)
                        {
                            strSql.Append(sMasterUserTableName + "." + dr["sFieldName"].ToString() + " AS " + sMasterTableName + "_" + dr["sFieldName"].ToString() + ",");

                            isMasterHaveUserColumn = true;
                        }
                        else
                            strSql.Append(sMasterTableName + "." + dr["sFieldName"].ToString() + " AS " + sMasterTableName + "_" + dr["sFieldName"].ToString() + ",");

                        //计算要生成的明细列
                        DataRow drTmp = dtDetailData.NewRow();
                        drTmp["sFieldName"] = sMasterTableName + "_" + dr["sFieldName"].ToString();
                        drTmp["sCaption"] = dr["sCaption"];
                        drTmp["bIsQuery"] = false;
                        drTmp["bIsShow"] = true;
                        drTmp["sSearchType"] = string.Empty;
                        drTmp["sDefaultValue"] = string.Empty;
                        drTmp["sReturnValue"] = string.Empty;
                        drTmp["sFooterType"] = "001";

                        switch (dr["sFieldType"].ToString())
                        {
                            case "S":
                            case "M":
                                {
                                    drTmp["sFieldType"] = "S";
                                    break;
                                }
                            case "D":
                                {
                                    drTmp["sFieldType"] = "D";
                                    break;
                                }
                            case "B":
                                {
                                    drTmp["sFieldType"] = "K";
                                    break;
                                }
                            case "I":
                            case "F":
                                {
                                    drTmp["sFieldType"] = "N";
                                    break;
                                }
                            default:
                                {
                                    drTmp["sFieldType"] = "S";
                                    break;
                                }
                        }

                        //合并历史数据
                        foreach (DataRow drHistory in dtQueryReportHistory.Rows)
                        {
                            if (drHistory["sColumnFieldName"].ToString() == sMasterTableName + "_" + dr["sFieldName"].ToString())
                            {
                                drTmp["bIsQuery"] = drHistory["bIsQuery"];
                                drTmp["bIsShow"] = drHistory["bIsShow"];
                                drTmp["sSearchType"] = drHistory["sSearchType"];
                                drTmp["sDefaultValue"] = drHistory["sDefaultValue"];
                                drTmp["sReturnValue"] = drHistory["sReturnValue"];
                                drTmp["sFooterType"] = drHistory["sFooterType"];
                            }
                        }
                        dtDetailData.Rows.Add(drTmp);
                    }
                }
               
                //当前明细自定义配置信息
                foreach (DataRow dr in LDetailDataSet[0].Tables[0].Rows)
                {
                    bool isSystemColumn = Convert.ToBoolean(dr["bSystemColumn"]);
                    //tabel1.name AS table1_name
                    //如果该列为自定义列，则该字段的前缀是自定义表
                    if (!isSystemColumn)
                    {
                        strSql.Append(sUserTableName + "." + dr["sFieldName"].ToString() + " AS " + sTableName + "_" + dr["sFieldName"].ToString() + ",");

                        isHaveUserColumn = true;
                    }
                    else
                        strSql.Append(sTableName + "." + dr["sFieldName"].ToString() + " AS " + sTableName + "_" + dr["sFieldName"].ToString() + ",");

                    //计算要生成的明细列
                    DataRow drTmp = dtDetailData.NewRow();
                    drTmp["sFieldName"] = sTableName + "_" + dr["sFieldName"].ToString();
                    drTmp["sCaption"] = dr["sCaption"];
                    drTmp["bIsQuery"] = false;
                    drTmp["bIsShow"] = true;
                    drTmp["sSearchType"] = string.Empty;
                    drTmp["sDefaultValue"] = string.Empty;
                    drTmp["sReturnValue"] = string.Empty;
                    drTmp["sFooterType"] = "001";

                    switch (dr["sFieldType"].ToString())
                    {
                        case "S":
                        case "M":
                            {
                                drTmp["sFieldType"] = "S";
                                break;
                            }
                        case "D":
                            {
                                drTmp["sFieldType"] = "D";
                                break;
                            }
                        case "B":
                            {
                                drTmp["sFieldType"] = "K";
                                break;
                            }
                        case "I":
                        case "F":
                            {
                                drTmp["sFieldType"] = "N";
                                break;
                            }
                        default:
                            {
                                drTmp["sFieldType"] = "S";
                                break;
                            }
                    }

                    //合并历史数据
                    foreach (DataRow drHistory in dtQueryReportHistory.Rows)
                    {
                        if (drHistory["sColumnFieldName"].ToString() == sTableName + "_" + dr["sFieldName"].ToString())
                        {
                            drTmp["bIsQuery"] = drHistory["bIsQuery"];
                            drTmp["bIsShow"] = drHistory["bIsShow"];
                            drTmp["sSearchType"] = drHistory["sSearchType"];
                            drTmp["sDefaultValue"] = drHistory["sDefaultValue"];
                            drTmp["sReturnValue"] = drHistory["sReturnValue"];
                            drTmp["sFooterType"] = drHistory["sFooterType"];
                        }
                    }

                    dtDetailData.Rows.Add(drTmp);

                }
                //加入bCheck字段
                strSql.Append("basCheck.bCheck FROM " + sTableName);
                strSql.AppendLine();

                //关联主表
                strSql.Append("LEFT JOIN " + sMasterTableName + " ON " + sMasterTableName + ".ID=" + sTableName + "." + sFKFieldName);
                strSql.AppendLine();

                if (isMasterHaveUserColumn)
                {
                    strSql.Append("LEFT JOIN " + sMasterUserTableName + " ON " + sMasterTableName + ".ID=" + sMasterUserTableName + ".MainTableID");
                    strSql.AppendLine();
                }

                //只有含有自定义列时才将自定义表关联进来
                if (isHaveUserColumn)
                {
                    strSql.Append("LEFT JOIN " + sUserTableName + " ON " + sTableName + ".ID=" + sUserTableName + ".MainTableID");
                    strSql.AppendLine();
                }
                strSql.Append("LEFT JOIN basCheck ON " + sTableName + ".ID=basCheck.Code");

                //写入数据到查询配置中
                InsertQuertReportData(ReportNo, ReportName + "明细", strSql.ToString(), dtDetailData);
            }
        }

        private void InsertQuertReportData(string reportno,string reportname,string reportsql,DataTable detaildata)
        {
            bool isExistReport = DbHelperSQL.Exists("SELECT 1 FROM sysQueryReportMaster WHERE sReportNo='" + reportno + "'");
            string sOptionSQL;
            //事务开始
            SqlTransaction trans = ConnectSetting.SysSqlConnection.BeginTransaction();
            try
            {
                //先判断是否已经存在，如果存在数据,则提示是否覆盖以前数据
                if (isExistReport)
                {
                    if (Public.SystemInfo("查询配置已经存在，继续生成将覆盖之前数据，是否继续？", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //先删除旧数据
                        sOptionSQL = "DELETE FROM sysQueryReportMaster WHERE sReportNo='" + reportno + "'";
                        DbHelperSQL.ExecuteSql(sOptionSQL, trans);
                    }
                    else
                    {
                        trans.Dispose();
                        return;
                    }
                }
                //插入查询配置主表
                sOptionSQL = "INSERT INTO sysQueryReportMaster(sReportNo, sReportName, sReportSQL,"
                           + "iControlSpace, iControlColumn, bIsShowPrintBtn, bIsShowExecBtn, "
                           + "bIsChart, bOptionData, sExecBtnText, sExecSQL, sDealFields, "
                           + "sSortFields, iFlag, sUserID, bIsAutoRun) "
                           + "VALUES( "
                           + "'" + reportno + "',"
                           + "'" + reportname + "',"
                           + "'" + reportsql + "',"
                           + "10,3,0,0,0,null,null,null,'*',null,0,'" + SecurityCenter.CurrentUserID + "',1) ;SELECT @@IDENTITY";
                int MasterID = 0;
                object id = DbHelperSQL.GetSingle(sOptionSQL, trans);
                MasterID = id == null ? 0 : Convert.ToInt32(id);
                if (MasterID != 0 && detaildata!=null)
                {
                    for (int i = 0; i < detaildata.Rows.Count; i++)
                    {
                        //插入查询配置明细表
                        sOptionSQL = "INSERT INTO sysQueryReportDetail(MainID, iSort, sColumnFieldName, sColumnCaption, "
                                   + "sColumnType, bIsQuery, bIsShow, bChartField, bChartValue, sSearchType, "
                                   + "sDefaultValue, sReturnValue, bIsGroup, sFooterType, bIsStat, iFormID, sUserID) "
                                   + "VALUES( " + MasterID.ToString() + "," + (i + 1).ToString() + ","
                                   + "'" + detaildata.Rows[i]["sFieldName"].ToString() + "',"
                                   + "'" + detaildata.Rows[i]["sCaption"].ToString() + "',"
                                   + "'" + detaildata.Rows[i]["sFieldType"].ToString() + "',"
                                   + (Convert.ToBoolean(detaildata.Rows[i]["bIsQuery"]) ? "1" : "0") + ","
                                   + (Convert.ToBoolean(detaildata.Rows[i]["bIsShow"]) ? "1" : "0") + ","
                                   + "0,0,"
                                   + "'" + detaildata.Rows[i]["sSearchType"].ToString() + "',"
                                   + "'" + detaildata.Rows[i]["sDefaultValue"].ToString() + "',"
                                   + "'" + detaildata.Rows[i]["sReturnValue"].ToString() + "',"
                                   + "0,"
                                   + "'" + detaildata.Rows[i]["sFooterType"].ToString() + "',"
                                   + "0,NULL,'" + SecurityCenter.CurrentUserID + "')";
                        DbHelperSQL.GetSingle(sOptionSQL, trans);
                    }
                }
                trans.Commit();
                Public.SystemInfo("写入查询配置数据成功！");
            }
            catch(Exception ex)
            {
                Public.SystemInfo("写入查询配置数据失败！" + ex.Message, true);
                trans.Rollback();
            }
        }

    }
}
