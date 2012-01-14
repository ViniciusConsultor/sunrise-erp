using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Sunrise.ERP.BaseForm;
using Sunrise.ERP.Lang;

namespace SunriseERP
{
    public partial class frmSysConnSet : Sunrise.ERP.BaseForm.frmForm
    {
        public frmSysConnSet()
        {
            InitializeComponent();
        }

        private void frmSysConnSet_Load(object sender, EventArgs e)
        {
            //读取配置文件中的数据库连接设置
            txtServer.Text = Sunrise.ERP.BaseControl.ConnectSetting.GetAppConfig("ServerName", true);
            txtDataBase.Text = Sunrise.ERP.BaseControl.ConnectSetting.GetAppConfig("DataBase", true);
            txtUser.Text = Sunrise.ERP.BaseControl.ConnectSetting.GetAppConfig("UserName", true);
            txtPassword.Text = Sunrise.ERP.BaseControl.ConnectSetting.GetAppConfig("Password", true);
            LoadLangSetting();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //非空验证
            if (Sunrise.ERP.BasePublic.SysPublic.CheckNotNull(txtServer, lblServer.Text)) { return; }
            if (Sunrise.ERP.BasePublic.SysPublic.CheckNotNull(txtDataBase, lblDataBase.Text)) { return; }
            if (Sunrise.ERP.BasePublic.SysPublic.CheckNotNull(txtUser, lblUser.Text)) { return; }
            if (Sunrise.ERP.BasePublic.SysPublic.CheckNotNull(txtPassword, lblPassword.Text)) { return; }

            string sConn = "Data Source=" + txtServer.Text + ";Initial Catalog=" + txtDataBase.Text + ";User ID=" + txtUser.Text + ";Password=" + txtPassword.Text;
            SqlConnection conn = new SqlConnection(sConn);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    Sunrise.ERP.BaseControl.Public.SystemInfo(LangCenter.Instance.GetSystemMessage("ConnectSuccess"));
                }
            }
            catch (Exception ex)
            {
                Sunrise.ERP.BaseControl.Public.SystemInfo(LangCenter.Instance.GetSystemMessage("ConnectFailed") + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //非空验证
            if (Sunrise.ERP.BasePublic.SysPublic.CheckNotNull(txtServer, lblServer.Text)) { return; }
            if (Sunrise.ERP.BasePublic.SysPublic.CheckNotNull(txtDataBase, lblDataBase.Text)) { return; }
            if (Sunrise.ERP.BasePublic.SysPublic.CheckNotNull(txtUser, lblUser.Text)) { return; }
            if (Sunrise.ERP.BasePublic.SysPublic.CheckNotNull(txtPassword, lblPassword.Text)) { return; }

            //保存连接字符串
            try
            {
                Sunrise.ERP.BaseControl.ConnectSetting.SaveSqlConnString(txtServer.Text, txtDataBase.Text, txtUser.Text, txtPassword.Text);
                this.Close();

            }
            catch (Exception ex)
            {
                Sunrise.ERP.BaseControl.Public.SystemInfo(LangCenter.Instance.GetSystemMessage("SaveFailed") + ex.Message);
            }        
        }
        /// <summary>
        /// 加载多语言
        /// </summary>
        private void LoadLangSetting()
        {
            this.Text = LangCenter.Instance.GetFormLangInfo("frmSysConnSet", this.Name);
            lblServer.Text = LangCenter.Instance.GetFormLangInfo("frmSysConnSet", lblServer.Name);
            lblDataBase.Text = LangCenter.Instance.GetFormLangInfo("frmSysConnSet", lblDataBase.Name);
            lblUser.Text = LangCenter.Instance.GetFormLangInfo("frmSysConnSet", lblUser.Name);
            lblPassword.Text = LangCenter.Instance.GetFormLangInfo("frmSysConnSet", lblPassword.Name);
            btnTest.Text = LangCenter.Instance.GetFormLangInfo("frmSysConnSet", btnTest.Name);
            btnOk.Text = LangCenter.Instance.GetFormLangInfo("frmSysConnSet", btnOk.Name);
            btnCancel.Text = LangCenter.Instance.GetFormLangInfo("frmSysConnSet", btnCancel.Name);
            this.Refresh();
        }
    }
}
