using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTabbedMdi;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

using Sunrise.ERP.BaseForm;
using Sunrise.ERP.SysBase;
using Sunrise.ERP.Lang;
using Sunrise.ERP.BaseControl;
using Sunrise.ERP.DataAccess;
using Sunrise.ERP.Security;

namespace SunriseERP
{
    public partial class frmMain : Sunrise.ERP.BaseForm.frmForm
    {
        Cursor currentCursor;
        bool firstExit = false;
        public frmMain()
        {
            InitializeComponent();
            //窗体样式
            barManager1.GetController().LookAndFeel.UseDefaultLookAndFeel = false;
            barManager1.GetController().LookAndFeel.SkinName = "Blue";

            pnlWait.Location = new Point(pnlMenu.Width + 200, this.Height / 2);

        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadLangSetting();
                firstExit = true;
                sptMenu.Visible = true;
                pnlMenu.Visible = true;
                pnlMenu.Width = 200;
                tvMenu.Visible = true;
                bar1.Visible = true;
                bar2.Visible = true;
                bar3.Visible = true;
                #region 菜单相关
                //初始化菜单
                initMenu(frm.SysMenuData);
                #endregion

                #region 底部状态栏显示
                //底部状态栏显示

                barServerName.Caption = string.Format(LangCenter.Instance.GetSystemMessage("SysServer"), Sunrise.ERP.BaseControl.ConnectSetting.GetAppConfig("ServerName", true));
                barDataBase.Caption = string.Format(LangCenter.Instance.GetSystemMessage("SysDataBase"), Sunrise.ERP.BaseControl.ConnectSetting.GetAppConfig("DataBase", true));
                barDate.Caption = string.Format(LangCenter.Instance.GetSystemMessage("SysDate"),
                    (LangCenter.Instance.IsDefaultLanguage ? DateTime.Now.Date.ToString("yyyy年MM月dd") + " "
                    + Sunrise.ERP.BasePublic.SysPublic.ChsWeek(DateTime.Now.Date)
                    + " 农历：" + Sunrise.ERP.BasePublic.SysPublic.CNDate() : DateTime.Now.Date.ToString("yyyy/MM/dd")
                    + " " + DateTime.Now.Date.DayOfWeek.ToString()));
                barUserName.Caption = string.Format(LangCenter.Instance.GetSystemMessage("SysUserName") , Sunrise.ERP.Security.SecurityCenter.CurrentUserName);
                barDeptName.Caption = string.Format(LangCenter.Instance.GetSystemMessage("SysDept"), Sunrise.ERP.Security.SecurityCenter.CurrentDeptName);
                barSoftVer.Caption = string.Format(LangCenter.Instance.GetSystemMessage("SysVersion"), Assembly.GetExecutingAssembly().GetName().Version.ToString());
                #endregion

                /* 2012-01-07 
                 * 快捷操作 后续再完善此功能
                //将当前菜单数据中的快捷操作添加到快捷菜单中
                DataTable dtQuickMenu = frm.SysMenuData.Tables[0].Clone();
                foreach(DataRow dr in frm.SysMenuData.Tables[0].Select("sQuickMenu<>''"))
                {
                    DataRow dr2 = dtQuickMenu.NewRow();
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        dr2[i] = dr[i];
                    }
                    dtQuickMenu.Rows.Add(dr2);
                }
                if (dtQuickMenu.Rows.Count > 0)
                {
                    lkpQuickMenu.DataSource = dtQuickMenu;
                }
                 */
            }
            else
            {
                this.Close();
            }
        }

        private void initMenu(DataSet ds)
        {
            DataSet dsMenu = ds;
            dsMenu.Tables[0].TableName = "ds";
            tvMenu.DataSource = dsMenu;
            tvMenu.DataMember = "ds";
            tvMenu.KeyFieldName = "ID";
            tvMenu.ParentFieldName = "iParentID";
            tvMenu.Columns["iFormID"].Visible = false;
            tvMenu.Columns["sModuleName"].Visible = false;
            tvMenu.Columns["sFormClassName"].Visible = false;
            tvMenu.Columns["iSort"].Visible = false;
            tvMenu.Columns["sQuickMenu"].Visible = false;
        }

        private void RefreshForm(bool b)
        {
            if (b)
            {
                currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                Refresh();
            }
            else
                Cursor.Current = currentCursor;
        }

        /// <summary>
        /// 数据库连接设置
        /// </summary>
        private void barDataBaseLinkSet_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSysConnSet frm = new frmSysConnSet();
            frm.ShowDialog();
        }

        private void barCalc_ItemClick(object sender, ItemClickEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\WINDOWS\system32\calc.exe";
            Process.Start(startInfo);
        }

        private void barPrintSet_ItemClick(object sender, ItemClickEventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void barModifyPassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUpdatePassword frm = new frmUpdatePassword();
            frm.ShowDialog();
        }

        private void barExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void toolCloseCurrent_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        private void toolCloseAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                foreach (Form frm in this.MdiChildren)
                {
                    frm.Close();
                }
            }
        }

        private void pnlMenu_SizeChanged(object sender, EventArgs e)
        {
            if (pnlMenu.Width != 0)
            {
                barTreeMenu.Checked = true;
                tooTreeMenu.Checked = true;
            }
            else 
            {
                barTreeMenu.Checked = false;
                tooTreeMenu.Checked = false;
            }
        }

        private void tooTreeMenu_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (!tooTreeMenu.Checked)
            {
                pnlMenu.Width = 0;
            }
            else
            {
                pnlMenu.Width = 200;
            }
        }

        private void barTreeMenu_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (!barTreeMenu.Checked)
            {
                pnlMenu.Width = 0;
            }
            else
            {
                pnlMenu.Width = 200;
            }
        }

        private void tvMenu_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (e.Node.HasChildren)
                e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            else e.NodeImageIndex = 2;
        }

        private void tvMenu_DoubleClick(object sender, EventArgs e)
        {
            if (tvMenu.FocusedNode != null && !tvMenu.FocusedNode.HasChildren)
            {
                if (HaveOpened(tvMenu.FocusedNode.GetValue("sMenuName").ToString()))
                {
                    string sModuleName = tvMenu.FocusedNode.GetValue("sModuleName").ToString();
                    string sPath = Application.StartupPath + @"\Modules\" + sModuleName;
                    string sClassName = "";
                    if (System.IO.File.Exists(sPath))
                    {
                        sClassName = tvMenu.FocusedNode.GetValue("sModuleName").ToString().Replace("dll", tvMenu.FocusedNode.GetValue("sFormClassName").ToString());
                    }
                    else
                    {
                        return;
                    }
                    pnlWait.Location = new Point(pnlMenu.Width + 200, this.Height / 2 - 90);
                    pnlWait.Visible = true;
                    RefreshForm(true);
                    Cursor = Cursors.Default;
                    try
                    {
                        Form frmobject = (Form)Assembly.LoadFile(sPath).CreateInstance(sClassName, true, BindingFlags.CreateInstance, null, new object[] { GetFormID(Convert.ToInt32(tvMenu.FocusedNode.GetValue("ID"))), tvMenu.FocusedNode.GetValue("sMenuName") }, null, null);
                        frmobject.MdiParent = this;
                        frmobject.Show();
                        picBack.Visible = false;

                    }
                    catch (Exception)
                    {
                        Public.SystemInfo(LangCenter.Instance.GetSystemMessage("SysModuleError"), true);
                    }
                    pnlWait.Visible = false;
                    RefreshForm(true);
                }                
            }
        }
        private bool HaveOpened(string childname)
        {
            //查看窗口是否已经被打开
            bool bReturn = true;
            for (int i = 0; i < MdiChildren.Length; i++)
            {
                if (MdiChildren[i].Text == childname)
                {
                    this.MdiChildren[i].BringToFront();
                    bReturn = false;
                    break;
                }
            }
            return bReturn;
        }
        private void barAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void barReLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Data.SqlClient.SqlConnection conn = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection;
            if (conn.State == ConnectionState.Open)
            {
                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("SysReConnect"));
            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!firstExit)
            {
                base.OnFormClosing(e);
            }
            else
            {
                if (Public.SystemInfo(LangCenter.Instance.GetSystemMessage("SysExit"), 4) == DialogResult.Yes)
                {
                    if (e.CloseReason == CloseReason.MdiFormClosing)
                    {
                        base.OnFormClosing(e);
                        //释放所有UI线程
                        Application.Exit();
                        return;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void xtraTabbedMdiManager1_PageRemoved(object sender, MdiTabPageEventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                picBack.Visible = true;
            }
            else
            {
                picBack.Visible = false;
            }

        }

        private void barPicBack_ItemClick(object sender, ItemClickEventArgs e)
        {
            openFileDialog1.Filter = LangCenter.Instance.GetSystemMessage("SysImageFilter");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picBack.Image = Image.FromFile(openFileDialog1.FileName);
                }
                catch
                {
                    Public.SystemInfo(LangCenter.Instance.GetSystemMessage("SysOpenImageFileFailed"), true);
                }
            }

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //保存背景图片
            if (openFileDialog1.FileName != "")
            {
                ConnectSetting.SaveAppConfig("BackImg", openFileDialog1.FileName, false);
            }

        }

        private void barClearPicBack_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (openFileDialog1.FileName != "")
            {
                openFileDialog1.FileName = "";
            }
            else
            {
                ConnectSetting.SaveAppConfig("BackImg", "", false);
            }
            if (picBack.EditValue != global::SunriseERP.Properties.Resources.sysbackimg)
            {
                picBack.EditValue = global::SunriseERP.Properties.Resources.sysbackimg;
            }
        }

        /// <summary>
        /// 获取FormID
        /// </summary>
        /// <param name="moudleid">模块id</param>
        /// <returns></returns>
        private int GetFormID(int moudleid)
        {
            int iResult = 0;
            try
            {
                //返回FormID，如果FormID不存在或等于0则由系统自动创建FormID
                if (Convert.ToInt32(tvMenu.FocusedNode.GetValue("iFormID").ToString() == "" ? "0" : tvMenu.FocusedNode.GetValue("iFormID").ToString()) > 0)
                {
                    return Convert.ToInt32(tvMenu.FocusedNode.GetValue("iFormID"));
                }
                else
                {
                    iResult = DbHelperSQL.GetMaxID("iFormID", "sysMenu");
                    string sSql = "UPDATE sysMenu SET iFormID =" + iResult.ToString()
                                + " WHERE ID=" + Convert.ToInt32(tvMenu.FocusedNode.GetValue("ID")) + " AND ISNULL(iFormID,0)<=0";
                    if (DbHelperSQL.ExecuteSql(sSql) > 0)
                    {
                        //自动创建完FormID后刷新菜单
                        initMenu(DbHelperSQL.Query(SecurityCenter.GetMenuAuthSQL()));
                        return iResult;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("SysGetFormIDFailed") + ex.Message, true);
                return 0;
            }
        }

        private void LoadLangSetting()
        {
            tbAllWork.Text = LangCenter.Instance.GetFormLangInfo("MainForm", tbAllWork.Name);
            barSubSystem.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barSubSystem.Name);
            barModifyPassword.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barModifyPassword.Name);
            barPrintSet.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barPrintSet.Name);
            barExit.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barExit.Name);
            barSubTool.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barSubTool.Name);
            barLockSystem.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barLockSystem.Name);
            barReLink.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barReLink.Name);
            barDataBaseLinkSet.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barDataBaseLinkSet.Name);
            barCalc.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barCalc.Name);
            barShortMessage.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barShortMessage.Name);
            barPicBack.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barPicBack.Name);
            barClearPicBack.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barClearPicBack.Name);
            barSubWindow.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barSubWindow.Name);
            barTreeMenu.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barTreeMenu.Name);
            barCloseCurrent.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barCloseCurrent.Name);
            barCloseAll.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barCloseAll.Name);
            barSubHelp.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barSubHelp.Name);
            barHelp.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barHelp.Name);
            barAbout.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barAbout.Name);
            barQuickMenu.Caption = LangCenter.Instance.GetFormLangInfo("MainForm", barQuickMenu.Name);
            
            toolModifyPassword.SuperTip.Items.Clear();
            toolLockSystem.SuperTip.Items.Clear();
            toolReLink.SuperTip.Items.Clear();
            toolDataBaseLinkSet.SuperTip.Items.Clear();
            toolCalc.SuperTip.Items.Clear();
            toolShortMessage.SuperTip.Items.Clear();
            toolPicBack.SuperTip.Items.Clear();
            tooTreeMenu.SuperTip.Items.Clear();
            toolCloseCurrent.SuperTip.Items.Clear();
            toolCloseAll.SuperTip.Items.Clear();
            toolHelp.SuperTip.Items.Clear();
            toolAbout.SuperTip.Items.Clear();
            toolExit.SuperTip.Items.Clear();

            toolModifyPassword.SuperTip.Items.Add(LangCenter.Instance.GetFormLangInfo("MainForm", toolModifyPassword.Name));
            toolLockSystem.SuperTip.Items.Add(LangCenter.Instance.GetFormLangInfo("MainForm", toolLockSystem.Name));
            toolReLink.SuperTip.Items.Add(LangCenter.Instance.GetFormLangInfo("MainForm", toolReLink.Name));
            toolDataBaseLinkSet.SuperTip.Items.Add(LangCenter.Instance.GetFormLangInfo("MainForm", toolDataBaseLinkSet.Name));
            toolCalc.SuperTip.Items.Add(LangCenter.Instance.GetFormLangInfo("MainForm", toolCalc.Name));
            toolShortMessage.SuperTip.Items.Add(LangCenter.Instance.GetFormLangInfo("MainForm", toolShortMessage.Name));
            toolPicBack.SuperTip.Items.Add(LangCenter.Instance.GetFormLangInfo("MainForm", toolPicBack.Name));
            tooTreeMenu.SuperTip.Items.Add(LangCenter.Instance.GetFormLangInfo("MainForm", tooTreeMenu.Name));
            toolCloseCurrent.SuperTip.Items.Add(LangCenter.Instance.GetFormLangInfo("MainForm", toolCloseCurrent.Name));
            toolCloseAll.SuperTip.Items.Add(LangCenter.Instance.GetFormLangInfo("MainForm", toolCloseAll.Name));
            toolHelp.SuperTip.Items.Add(LangCenter.Instance.GetFormLangInfo("MainForm", toolHelp.Name));
            toolAbout.SuperTip.Items.Add(LangCenter.Instance.GetFormLangInfo("MainForm", toolAbout.Name));
            toolExit.SuperTip.Items.Add(LangCenter.Instance.GetFormLangInfo("MainForm", toolExit.Name));
        }

        private void barLockSystem_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLockSystem frm = new frmLockSystem();
            frm.ShowDialog();
        }

        //private void InitQuickMenuData(DataSet ds)
        //{
        //    string sSql = "SELECT iFormID, sMenuName, sMenuEngName, sModuleName, sFormClassName, sQuickMenu FROM sysMenu WHERE iParentID <> 0 AND " + sFilter;
        //    DataTable dtQuickMenu = DbHelperSQL.Query(sSql).Tables[0];
        //    if (dtQuickMenu != null && dtQuickMenu.Rows.Count > 0)
        //    {
        //        //gcQuickMenu.Visible = true;
        //        lkpQuickMenu.DataSource = dtQuickMenu;
        //    }
        //}

        private void barQuickEditor_ItemPress(object sender, ItemClickEventArgs e)
        {
            //Public.SystemInfo("Press");
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (toolQuickMenu.EditValue.ToString() != "" && gvQuickMenu.GetFocusedDataRow() != null)
                {
                    Public.SystemInfo(toolQuickMenu.EditValue.ToString());
                }
            }
        }

        private void lkpQuickMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (e.KeyChar == 13)
            {
                if (toolQuickMenu.EditValue.ToString() != "" && gvQuickMenu.GetFocusedDataRow() != null)
                {
                    Public.SystemInfo(toolQuickMenu.EditValue.ToString());
                }
            }
        }
    }
}
