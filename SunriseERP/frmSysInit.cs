using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Sunrise.ERP.BaseForm;

namespace SunriseERP
{
    public partial class frmSysInit : Form
    {
        public frmSysInit()
        {
            InitializeComponent();
        }

        private void frmSysInit_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckConn()) { return; }
            this.Hide();
            //frmLogin frm = new frmLogin();
            frmMain frm = new frmMain();
            frm.ShowDialog();
            this.Close();
        }

        private bool CheckConn()
        {
            try
            {
                string sServer = Sunrise.ERP.BaseControl.ConnectSetting.GetAppConfig("ServerName", true);
                string sDataBase = Sunrise.ERP.BaseControl.ConnectSetting.GetAppConfig("DataBase", true);
                string sUser = Sunrise.ERP.BaseControl.ConnectSetting.GetAppConfig("UserName", true);
                string sPassword = Sunrise.ERP.BaseControl.ConnectSetting.GetAppConfig("Password", true);
                string sConn = "Data Source=" + sServer + ";Initial Catalog=" + sDataBase + ";User ID=" + sUser + ";Password=" + sPassword;
                if (sServer != "" && sDataBase != "" && sUser != "" && sPassword != "")
                {
                    SqlConnection conn = new SqlConnection(sConn);
                    conn.Open();
                    timer1.Enabled = false;
                    return false;

                }
                else
                {
                    frmSysConnSet frm = new frmSysConnSet();
                    timer1.Enabled = false;
                    frm.ShowDialog();
                    return false;
                }
            }
            catch
            {
                frmSysConnSet frm = new frmSysConnSet();
                timer1.Enabled = false;
                frm.ShowDialog();
                return false;

            }
        }

    }
}
