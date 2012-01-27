using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sunrise.ERP.Lang;

namespace SunriseERP
{
    static class Program
    {
        /// <summary>
        /// Ӧ�ó��������ڵ㡣
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AutoUpdate.AppUpdater au = new AutoUpdate.AppUpdater();
            if (au.CheckForUpdate() > 0)
            {
                System.Diagnostics.Process.Start(Application.StartupPath + @"\AutoUpdate.exe", "FromERP");
            }
            else
            {
                LangCenter.Instance.LoadLangXmlDocument(System.Configuration.ConfigurationManager.AppSettings["Lang"]);
                Application.Run(new frmSysInit());
                //Sunrise.ERP.Security.SecurityCenter.CurrentUserID = "admin";
                //Sunrise.ERP.Module.Test.frmTest2 frm = new Sunrise.ERP.Module.Test.frmTest2(9002, "����2");
                //Sunrise.ERP.Module.Test.frmTest frm = new Sunrise.ERP.Module.Test.frmTest(9001, "����");
                //Sunrise.ERP.Module.Test.frmMasterDetailTest frm = new Sunrise.ERP.Module.Test.frmMasterDetailTest(9003, "������");
                //Application.Run(frm);
            }
        }
    }
}
