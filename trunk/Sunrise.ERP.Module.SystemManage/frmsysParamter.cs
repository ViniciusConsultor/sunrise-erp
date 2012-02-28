using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.Module.SystemManage
{
    public partial class frmsysParamter : Sunrise.ERP.BaseForm.frmSingleForm
    {
        public frmsysParamter(int formid, string formtext) :
            base(formid, "Sunrise.ERP.SystemManage.DAL", "sysParamterDAL", 100000, " AND 1=1", "sSysParamNo")
        {
            InitializeComponent();
            Text = formtext;

            txtsSysParamNo.DataBindings.Add("EditValue", dsMain, "sSysParamNo");
            txtsSysParamValue.DataBindings.Add("EditValue", dsMain, "sSysParamValue");
            chkbActive.DataBindings.Add("EditValue", dsMain, "bActive");
            mtxtsRemark.DataBindings.Add("EditValue", dsMain, "sRemark");
        }

        public override void initBase()
        {
            AddNotCopyFields(new string[] { "sSysParamNo", "sUserID", "iFlag" });
            AddNotNullFields(new string[] { "txtsSysParamNo", "txtsSysParamValue", "chkbActive" });
            base.initBase();
        }
    }
}
