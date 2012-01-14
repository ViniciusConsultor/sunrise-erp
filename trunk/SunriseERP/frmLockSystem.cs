using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sunrise.ERP.BaseControl;
using Sunrise.ERP.Security;
using Sunrise.ERP.Lang;

namespace SunriseERP
{
    public partial class frmLockSystem : Sunrise.ERP.BaseForm.frmForm
    {
        public frmLockSystem()
        {
            InitializeComponent();
        }

        private void btnUnLock_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "")
            {
                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("PasswordNotNull"));
                txtPassword.Focus();
                return;
            }
            if (SecurityCenter.CheckSystemLogin(SecurityCenter.CurrentUserID, txtPassword.Text.Trim()) == 1)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("PasswordWrong"));
                txtPassword.Focus();
                return;
            }
        }

        private void frmLockSystem_Load(object sender, EventArgs e)
        {
            LoadLangSetting();
        }
        private void LoadLangSetting()
        {
            lblTip.Text = LangCenter.Instance.GetFormLangInfo("frmLockSystem", lblTip.Name);
            btnUnLock.Text = LangCenter.Instance.GetFormLangInfo("frmLockSystem", btnUnLock.Name);
        }
    }
}
