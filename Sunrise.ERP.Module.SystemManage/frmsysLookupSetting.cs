using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sunrise.ERP.Common;
using Sunrise.ERP.BasePublic;
using Sunrise.ERP.Lang;
using Sunrise.ERP.Security;

namespace Sunrise.ERP.Module.SystemManage
{
    public partial class frmsysLookupSetting : Sunrise.ERP.BaseForm.frmSingleForm
    {
        public frmsysLookupSetting(int formid, string formtext)
            : base(formid, "Sunrise.ERP.SystemManage.DAL", "sysLookupSettingDAL")
        {
            InitializeComponent();
            if (formtext != "")
            {
                this.Text = formtext;
            }
            txtsDataField.DataBindings.Add("EditValue", dsMain, "sDataField");
            txtsDisplayField.DataBindings.Add("EditValue", dsMain, "sDisplayField");
            txtsEnGridColumnText.DataBindings.Add("EditValue", dsMain, "sEnGridColumnText");
            txtsEnSearchFormText.DataBindings.Add("EditValue", dsMain, "sEnSearchFormText");
            txtsGridColumnText.DataBindings.Add("EditValue", dsMain, "sGridColumnText");
            txtsGridDisplayField.DataBindings.Add("EditValue", dsMain, "sGridDisplayField");
            txtsLookupNo.DataBindings.Add("EditValue", dsMain, "sLookupNo");
            txtsSearchFormText.DataBindings.Add("EditValue", dsMain, "sSearchFormText");
            mtxtsSQL.DataBindings.Add("EditValue", dsMain, "sSQL");
            mtxtsRemark.DataBindings.Add("EditValue", dsMain, "sRemark");
            cbxsType.DataBindings.Add("EditValue", dsMain, "sType");
        }
        public override void initBase()
        {
            AddNotNullFields(new string[] { "txtsLookupNo", "cbxsType" });
            AddNotCopyFields(new string[] { "sLookupNo", "sUserID", "iFlag" });
            base.initBase();
        }
        public override bool DoAppend()
        {
            base.DoAppend();
            //新增默认值
            SystemPublic.GetBillNo(FormID, (DataRowView)dsMain.Current);
            ((DataRowView)dsMain.Current).Row["sType"] = "LookUp";
            dsMain.EndEdit();
            return true;
        }

        private void cbxsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxsType.SelectedIndex == 0)
            {
                txtsDataField.Enabled = true;
                txtsDisplayField.Enabled = true;
                txtsEnSearchFormText.Enabled = true;
                txtsSearchFormText.Enabled = true;
                mtxtsSQL.Enabled = true;
                lblsGridDisplayField.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsGridDisplayField.Name);
                lblsGridColumnText.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsGridColumnText.Name);
                lblsEnGridColumnText.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsEnGridColumnText.Name);
                lblsLookupNo.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsLookupNo.Name);
            }
            else
            {
                txtsDataField.Enabled = false;
                txtsDisplayField.Enabled = false;
                txtsEnSearchFormText.Enabled = false;
                txtsSearchFormText.Enabled = false;
                mtxtsSQL.Enabled = false;
                lblsGridDisplayField.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsGridDisplayField.Name + "ComboBox");
                lblsGridColumnText.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsGridColumnText.Name + "ComboBox");
                lblsEnGridColumnText.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsEnGridColumnText.Name + "ComboBox");
                lblsLookupNo.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsLookupNo.Name + "ComboBox");
            }
        }
        /// <summary>
        /// 加载语言数据
        /// </summary>
        private void LoadLangSetting()
        {
            colsDataField.Caption = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", colsDataField.Name);
            colsDisplayField.Caption = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", colsDisplayField.Name);
            colsEnSearchFormText.Caption = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", colsEnSearchFormText.Name);
            colsLookupNo.Caption = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", colsLookupNo.Name);
            colsSearchFormText.Caption = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", colsSearchFormText.Name);
            colsType.Caption = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", colsType.Name);
            lblsLookupNo.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsLookupNo.Name);
            lblsRemark.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsRemark.Name);
            lblsSearchFormText.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsSearchFormText.Name);
            lblsType.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsType.Name);
            lblsGridDisplayField.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsGridDisplayField.Name);
            lblsGridColumnText.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsGridColumnText.Name);
            lblsEnSearchFormText.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsEnSearchFormText.Name);
            lblsEnGridColumnText.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsEnGridColumnText.Name);
            lblsDisplayField.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsDisplayField.Name);
            lblsDataField.Text = LangCenter.Instance.GetFormLangInfo("frmsysLookupSetting", lblsDataField.Name);
        }

        private void frmsysLookupSetting_Load(object sender, EventArgs e)
        {
            LoadLangSetting();
        }
        public override bool DoBeforeSave()
        {
            SystemPublic.GetBillNo(FormID, (DataRowView)dsMain.Current);
            return base.DoBeforeSave();
        }
        public override bool DoAfterSave()
        {
            base.DoAfterSave();
            try
            {
                SysPublic.AddBillLog(FormID, SecurityCenter.CurrentUserID, txtsLookupNo.Text);
            }
            catch { }
            return true;
        }


    }
}
