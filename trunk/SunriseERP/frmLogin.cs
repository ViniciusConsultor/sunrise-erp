using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sunrise.ERP.BaseControl;
using Sunrise.ERP.Lang;
using Sunrise.ERP.Security;

namespace SunriseERP
{
    public partial class frmLogin : Sunrise.ERP.BaseForm.frmForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isrelogin">是否重新登录，重新登录数据库设置按钮不可用</param>
        public frmLogin(bool isrelogin)
        {
            InitializeComponent();
            btnSet.Enabled = !isrelogin;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            frmSysConnSet frm = new frmSysConnSet();
            frm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserID.Text.Trim() == "")
                {
                    Public.SystemInfo(LangCenter.Instance.GetSystemMessage("UserNameNotNull"));
                    txtUserID.Focus();
                    return;
                }
                if (txtPassword.Text.Trim() == "")
                {
                    Public.SystemInfo(LangCenter.Instance.GetSystemMessage("PasswordNotNull"));
                    txtPassword.Focus();
                    return;
                }
                int iLoginResult = Sunrise.ERP.Security.SecurityCenter.CheckSystemLogin(txtUserID.Text, txtPassword.Text.Trim());
                if (iLoginResult == 1)
                {
                    ConnectSetting.SaveAppConfig("LastUserID", txtUserID.Text, true);
                    lblLoadingRight.Visible = true;
                    this.Refresh();
                    SysMenuData = Sunrise.ERP.DataAccess.DbHelperSQL.Query(SecurityCenter.GetMenuAuthSQL());
                    DialogResult = DialogResult.OK;
                }
                else if (iLoginResult == 0)
                {
                    Sunrise.ERP.BaseControl.Public.SystemInfo(LangCenter.Instance.GetSystemMessage("UserNotExist"));
                    txtUserID.Focus();
                }
                else if (iLoginResult == 2)
                {
                    Public.SystemInfo(LangCenter.Instance.GetSystemMessage("PasswordWrong"));
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("LoginWrong") + ex.Message + "\r\n" + LangCenter.Instance.GetSystemMessage("TryToRelogin"));
            }            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                txtUserID.Text = ConnectSetting.GetAppConfig("LastUserID", true);
                cbxLang.EditValue = ConnectSetting.GetAppConfig("Lang", false).ToLower();
                new DevExpressLang(cbxLang.EditValue.ToString());
                LoadLangSetting();
                if (!string.IsNullOrEmpty(txtUserID.Text))
                {
                    //设置为输入焦点
                    txtPassword.TabIndex = 0;
                }
            }
            catch
            {
                txtUserID.Text = "";
            }
        }

        private void cbxLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LangType = cbxLang.EditValue.ToString();
            ConnectSetting.SaveAppConfig("Lang", LangType, false);
            LangCenter.Instance.LoadLangXmlDocument(LangType);
            new DevExpressLang(LangType);
            LoadLangSetting();
        }

        private void LoadLangType()
        {
            string[] langTypes = ConnectSetting.GetAppConfig("LangType", false).Split(new string[] { ",", "|" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < langTypes.Length; i++)
            {
                DevExpress.XtraEditors.Controls.ImageComboBoxItem item=new DevExpress.XtraEditors.Controls.ImageComboBoxItem();
                item.Description = langTypes[i];
                item.Value = langTypes[i + 1];
                cbxLang.Properties.Items.Add(item);
                i++;
            }
        }

        private string _LangType;
        /// <summary>
        /// 多语言类型
        /// </summary>
        private string LangType
        {
            get { return _LangType; }
            set { _LangType = value; }
        }

        private DataSet _dsMenu;
        /// <summary>
        /// 菜单权限数据
        /// </summary>
        public DataSet SysMenuData
        {
            get { return _dsMenu; }
            set { _dsMenu = value; }
        }

        /// <summary>
        /// 加载多语言
        /// </summary>
        private void LoadLangSetting()
        {
            lblLang.Text = LangCenter.Instance.GetFormLangInfo("LoginForm", lblLang.Name);
            lblLoadingRight.Text = LangCenter.Instance.GetFormLangInfo("LoginForm", lblLoadingRight.Name);
            lblPassword.Text = LangCenter.Instance.GetFormLangInfo("LoginForm", lblPassword.Name);
            lblUserName.Text = LangCenter.Instance.GetFormLangInfo("LoginForm", lblUserName.Name);
            btnLogin.Text = LangCenter.Instance.GetFormLangInfo("LoginForm", btnLogin.Name);
            btnLogin.ToolTip = LangCenter.Instance.GetFormLangInfo("LoginForm", btnLogin.Name + "Tip");
            btnCancel.Text = LangCenter.Instance.GetFormLangInfo("LoginForm", btnCancel.Name);
            btnCancel.ToolTip = LangCenter.Instance.GetFormLangInfo("LoginForm", btnCancel.Name + "Tip");
            btnSet.Text = LangCenter.Instance.GetFormLangInfo("LoginForm", btnSet.Name);
            btnSet.ToolTip = LangCenter.Instance.GetFormLangInfo("LoginForm", btnSet.Name + "Tip");
            this.Refresh();
        }

    }
}
