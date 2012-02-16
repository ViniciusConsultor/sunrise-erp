using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sunrise.ERP.BasePublic;
using Sunrise.ERP.Security;
using Sunrise.ERP.Lang;

namespace Sunrise.ERP.Module.Test
{
    public partial class frmTest : Sunrise.ERP.BaseForm.frmDynamicSingleForm
    {
        public frmTest(int formid, string formtext)
            : base(formid, "salTest")
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(formtext))
                Text = formtext;
            //创建自定义字段列
            CreateDynamicControl();
            CreateMasterGridColumn(gvMain);

        }

        public override bool DoAfterSave()
        {
            base.DoAfterSave();
            try
            {
                SysPublic.AddIPLog(FormID, SecurityCenter.CurrentUserID, string.Format(LangCenter.Instance.GetSystemMessage("AddNewBill"), ""));
            }
            catch { }
            return true;
        }
    }
}
