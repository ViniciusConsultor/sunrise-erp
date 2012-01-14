using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sunrise.ERP.Security;
using Sunrise.ERP.BaseControl;
using Sunrise.ERP.DataAccess;
using Sunrise.ERP.Lang;

namespace SunriseERP
{
    public partial class frmUpdatePassword : Sunrise.ERP.BaseForm.frmForm
    {
        public frmUpdatePassword()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtOldPwd.Text=="")
            {
                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("InputOldPassword"));
                txtOldPwd.Focus();
                return;
            }
            if (txtNewPwd.Text == "")
            {
                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("InputNewPassword"));
                txtNewPwd.Focus();
                return;
            }
            if (txtNewPwd2.Text == "")
            {
                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("InputNewPasswordAgain"));
                txtNewPwd2.Focus();
                return;
            }
            if (txtNewPwd.Text.Trim() != txtNewPwd2.Text.Trim())
            {
                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("NewPasswordNotMatch"));
                txtNewPwd.Text = "";
                txtNewPwd2.Text = "";
                txtNewPwd.Focus();
                return;
            }
            try
            {
                if (SecurityCenter.CheckSystemLogin(SecurityCenter.CurrentUserID, txtOldPwd.Text.Trim()) == 1)
                {
                    string sSql = "UPDATE sysUser SET sPassword='" + SysEncrypt.EncryptStr(txtNewPwd.Text.Trim()) + "' WHERE sUserID='" + SecurityCenter.CurrentUserID + "'";
                    DbHelperSQL.ExecuteSql(sSql);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    Public.SystemInfo(LangCenter.Instance.GetSystemMessage("OldPasswordNotMatch"));
                }
            }
            catch (Exception ex)
            {
                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("UpdatePasswordFailed") + ex.Message, true);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmUpdatePassword_Load(object sender, EventArgs e)
        {
            lblsUserID.Text = Sunrise.ERP.Security.SecurityCenter.CurrentUserID;
            LoadLangSetting();
        }
        private void LoadLangSetting()
        {
            this.Text = LangCenter.Instance.GetFormLangInfo("frmUpdatePassword", this.Name);
            lblUserName.Text = LangCenter.Instance.GetFormLangInfo("frmUpdatePassword", lblUserName.Name);
            lblOldPassword.Text = LangCenter.Instance.GetFormLangInfo("frmUpdatePassword", lblOldPassword.Name);
            lblNewPassword.Text = LangCenter.Instance.GetFormLangInfo("frmUpdatePassword", lblNewPassword.Name);
            lblNewPassword2.Text = LangCenter.Instance.GetFormLangInfo("frmUpdatePassword", lblNewPassword2.Name);
            btnOk.Text = LangCenter.Instance.GetFormLangInfo("frmUpdatePassword", btnOk.Name);
            btnCancel.Text = LangCenter.Instance.GetFormLangInfo("frmUpdatePassword", btnCancel.Name);
        }
    }
}
