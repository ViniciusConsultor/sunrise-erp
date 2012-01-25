using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sunrise.ERP.Common;

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
    }
}
