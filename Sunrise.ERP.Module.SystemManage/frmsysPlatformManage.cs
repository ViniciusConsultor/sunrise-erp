using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sunrise.ERP.Module.SystemManage
{
    public partial class frmsysPlatformManage : Sunrise.ERP.BaseForm.frmForm
    {
        Sunrise.ERP.SystemModule.DAL.sysMenuDAL dalMenu = new Sunrise.ERP.SystemModule.DAL.sysMenuDAL();
        Sunrise.ERP.SystemModule.DAL.sysMenuNodeDAL dalMenuNode = new Sunrise.ERP.SystemModule.DAL.sysMenuNodeDAL();
        Sunrise.ERP.SystemModule.DAL.sysMenuParamDAL dalMenuParam = new Sunrise.ERP.SystemModule.DAL.sysMenuParamDAL();

        //bool IsFirstLoad = false;
        DataSet dsMenu = new DataSet();
        DataSet dsDeletedMenu = new DataSet();
        DataSet dsMenuPara = new DataSet();
        DataSet dsModule = new DataSet();
        int iSort = 0;

        //模块文件信息

        public frmsysPlatformManage(int formid, string formtext)
            : base(formid, formtext)
        {
            InitializeComponent();
        }

        private void frmsysPaltformManage_Load(object sender, EventArgs e)
        {
            //系统菜单
            initMenu();
            //系统模块升级菜单
            initModule();
            initModuleBingding();
            txtModuleUpdatePath.ToolTip = txtModuleUpdatePath.Text;
            IsFirstLoad = true;
        }

        private void initMenu()
        {
            //系统菜单列表
            dsMenu = dalMenu.GetList(10000, "", "iSort");
            tvMenu.DataSource = dsMenu;
            tvMenu.DataMember = "ds";
            tvMenu.KeyFieldName = "ID";
            tvMenu.ParentFieldName = "iParentID";

            //已删除菜单列表
            string MenuSql = "SELECT A.ID,A.sMenuName,A.iParentID FROM sysMenu A WHERE 1=2 ORDER BY A.iSort";
            dsDeletedMenu = Sunrise.ERP.DataAccess.DbHelperSQL.Query(MenuSql);
            tvDeletedMenu.DataSource = dsDeletedMenu;
            tvDeletedMenu.DataMember = "ds";
            tvDeletedMenu.KeyFieldName = "ID";
            tvDeletedMenu.ParentFieldName = "iParentID";

            //初始化菜单参数列表
            dsMenuPara = dalMenuParam.GetList("");
            gcPara.DataSource = dsMenuPara;
            gcPara.DataMember = "ds";
            gvPara.Columns["MenuID"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo("MenuID<0");
        }

        private void initModule()
        {
            //系统菜单列表
            dsModule = dalMenuNode.GetList(10000, "", "iSort");
            dsModule.Tables[0].ColumnChanged += new DataColumnChangeEventHandler(frmsysPaltformManage_ColumnChanged);
            tvModule.DataSource = dsModule;
            tvModule.DataMember = "ds";
            tvModule.KeyFieldName = "ID";
            tvModule.ParentFieldName = "iParentID";

        }

        void frmsysPaltformManage_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            e.Row.EndEdit();
        }

        private void initModuleBingding()
        {
            txtMenuName.DataBindings.Clear();
            txtModuleName.DataBindings.Clear();
            txtFormClassName.DataBindings.Clear();
            txtFormID.DataBindings.Clear();
            txtModuleUpdateDate.DataBindings.Clear();

            txtMenuName.DataBindings.Add("EditValue", dsModule, "ds.sMenuName");
            txtModuleName.DataBindings.Add("EditValue", dsModule, "ds.sModuleName");
            txtFormClassName.DataBindings.Add("EditValue", dsModule, "ds.sFormClassName");
            txtFormID.DataBindings.Add("EditValue", dsModule, "ds.iFormID");
            txtModuleUpdateDate.DataBindings.Add("EditValue", dsModule, "ds.dDLLLastTime");
            txtModuleUpdatePath.Text = Application.StartupPath + @"\Update\";
        }

        private void tvMenu_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (e.Node.HasChildren)
                e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            else e.NodeImageIndex = 0;
        }

        private void tvMenu_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (tvMenu.FocusedNode != null)
            {
                btnAddPara.Enabled = true;
                btnDeletePara.Enabled = true;
                btnEditPara.Enabled = true;

                if (IsFirstLoad && tvMenu.FocusedNode.GetValue("ID").ToString() != "")
                {
                    //刷新菜单参数列表(设置过滤条件)
                    gvPara.Columns["MenuID"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo("MenuID=" + tvMenu.FocusedNode.GetValue("ID").ToString());

                }
            }
            else
            {
                btnAddPara.Enabled = false;
                btnDeletePara.Enabled = false;
                btnEditPara.Enabled = false;
            }

        }

        private void tvMenu_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                if (tvMenu.FocusedNode != null)
                {
                    cmsMenu.Show(this.tvMenu, ((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                }
            }
        }

        private void tsmRename_Click(object sender, EventArgs e)
        {
            tvMenu.OptionsBehavior.Editable = true;
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            tvMenu.Nodes.Remove(tvMenu.FocusedNode);
            //将删除菜单添加到已删除列表
            DataTable dtTemp = dsDeletedMenu.Tables[0].Clone();
            dtTemp.Rows.Clear();
            string sFilter = "1=1";
            foreach (DataRow dr in dsMenu.Tables[0].GetChanges(DataRowState.Deleted).Rows)
            {
                DataRow drNew = dtTemp.NewRow();
                drNew["ID"] = dr["ID", DataRowVersion.Original];
                drNew["iParentID"] = dr["iParentID", DataRowVersion.Original];
                drNew["sMenuName"] = dr["sMenuName", DataRowVersion.Original];
                dtTemp.Rows.Add(drNew);
            }
            //设置过滤条件
            foreach (DataRow dr in dsDeletedMenu.Tables[0].Rows)
            {
                sFilter += " AND ID<>" + dr["ID"].ToString() + " ";
            }

            //添加至已删除列表
            foreach (DataRow dr in dtTemp.Select(sFilter))
            {
                DataRow drNew = dsDeletedMenu.Tables[0].NewRow();
                drNew["ID"] = dr["ID"];
                drNew["iParentID"] = dr["iParentID"];
                drNew["sMenuName"] = dr["sMenuName"];
                dsDeletedMenu.Tables[0].Rows.Add(drNew);
            }
            tvDeletedMenu.DataSource = dsDeletedMenu;
            tvDeletedMenu.DataMember = "ds";
        }

        private void tvDeletedMenu_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (e.Node.HasChildren)
                e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            else e.NodeImageIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            initMenu();
            tvMenu.OptionsBehavior.Editable = false;
        }

        private void btnAddPara_Click(object sender, EventArgs e)
        {
            frmsysMenuPara frm = new frmsysMenuPara();
            frm.Flag = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.MenuPara.Count == 2)
                {
                    DataRow dr = dsMenuPara.Tables[0].NewRow();
                    dr["MenuID"] = tvMenu.FocusedNode.GetValue("ID");
                    dr["sParamName"] = frm.MenuPara["ParamName"];
                    dr["sParamValue"] = frm.MenuPara["ParamValue"];
                    dr["sUserID"] = Sunrise.ERP.Security.SecurityCenter.CurrentUserID;
                    dsMenuPara.Tables[0].Rows.Add(dr);
                }
            }
        }

        private void btnEditPara_Click(object sender, EventArgs e)
        {
            if (gvPara.FocusedRowHandle >= 0)
            {
                frmsysMenuPara frm = new frmsysMenuPara();
                frm.Flag = false;
                frm.MenuPara["ParamName"] = gvPara.GetFocusedDataRow()["sParamName"].ToString();
                frm.MenuPara["ParamValue"] = gvPara.GetFocusedDataRow()["sParamValue"].ToString();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.MenuPara.Count == 2)
                    {
                        dsMenuPara.Tables[0].Rows[gvPara.GetFocusedDataSourceRowIndex()]["sParamName"] = frm.MenuPara["ParamName"];
                        dsMenuPara.Tables[0].Rows[gvPara.GetFocusedDataSourceRowIndex()]["sParamValue"] = frm.MenuPara["ParamValue"];
                    }
                }
            }
        }

        private void btnDeletePara_Click(object sender, EventArgs e)
        {
            if (gvPara.FocusedRowHandle >= 0)
            {
                gvPara.DeleteRow(gvPara.FocusedRowHandle);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tvMenu.FocusedNode != null)
            {
                tsmDelete_Click(sender, e);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection.BeginTransaction();
            try
            {
                //重建菜单顺序
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in tvMenu.Nodes)
                {
                    AutoSetMenuSort(node);
                }
                //下次保存前将顺序号清空为0
                iSort = 0;
                foreach (DataRow  item in dsMenu.Tables[0].Rows )
                {
                    if (item.RowState == DataRowState.Added)
                    {
                        item["ID"]=dalMenu.Add(item, trans);
                    }
                    if (item.RowState == DataRowState.Modified)
                    {
                        dalMenu.Update(item, trans);
                    }
                    if (item.RowState == DataRowState.Deleted)
                    {
                        dalMenu.Delete(Convert.ToInt32(item["ID", DataRowVersion.Original]), trans);
                    }
                }

                //保存菜单参数表
                foreach (DataRow item in dsMenuPara.Tables[0].Rows)
                {
                    if (item.RowState == DataRowState.Added)
                    {
                        item["ID"] = dalMenuParam.Add(item, trans);
                    }
                    if (item.RowState == DataRowState.Modified)
                    {
                        dalMenuParam.Update(item, trans);
                    }
                    if (item.RowState == DataRowState.Deleted)
                    {
                        dalMenuParam.Delete(Convert.ToInt32(item["ID", DataRowVersion.Original]), trans);
                    }
                }

                trans.Commit();
                //刷新菜单
                initMenu();
                tvMenu.OptionsBehavior.Editable = false;
                Sunrise.ERP.BaseControl.Public.SystemInfo("保存成功!");
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Sunrise.ERP.BaseControl.Public.SystemInfo("保存失败!" + ex.Message, true);
            }
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            if (txtMenuList.Text.Trim() == "")
            {
                Sunrise.ERP.BaseControl.Public.SystemInfo("请输入菜单名称!");
                return;
            }
            //在当前节点下添加
            if (rdgNode.SelectedIndex == 0)
            {
                if (tvMenu.FocusedNode != null)
                {
                    foreach (string str in txtMenuList.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        DataRow drNew = dsMenu.Tables[0].NewRow();
                        drNew["iParentID"] = tvMenu.FocusedNode.GetValue("ID");
                        drNew["sMenuName"] = str;
                        drNew["sUserID"] = Sunrise.ERP.Security.SecurityCenter.CurrentUserID;
                        dsMenu.Tables[0].Rows.Add(drNew);
                    }
                }
                else
                {
                    Sunrise.ERP.BaseControl.Public.SystemInfo("您还没有选择节点!");
                    return;
                }
            }
            else
            {
                //在根节点下添加
                foreach (string str in txtMenuList.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    DataRow drNew = dsMenu.Tables[0].NewRow();
                    drNew["sMenuName"] = str;
                    drNew["iParentID"] = 0;
                    drNew["sUserID"] = Sunrise.ERP.Security.SecurityCenter.CurrentUserID;
                    dsMenu.Tables[0].Rows.Add(drNew);
                }

            }
        }

        private void AutoSetMenuSort(DevExpress.XtraTreeList.Nodes.TreeListNode node)
        {
            node.SetValue("iSort", iSort);
            iSort++;
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode item in node.Nodes)
            {
                item.SetValue("iSort", iSort);
                iSort++;
                if (item.HasChildren && item.HasAsParent(node))
                {
                    AutoSetMenuSort(item);
                }
            }
        }

        private void tvModule_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (e.Node.HasChildren)
                e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            else e.NodeImageIndex = 0;
        }

        private void tvModule_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            AutoChiledNodeCheck(e.Node, e.Node.Checked);
        }

        private void AutoChiledNodeCheck(DevExpress.XtraTreeList.Nodes.TreeListNode node, bool check)
        {
            node.Checked = check;
            if (node.ParentNode != null)
            {
                node.ParentNode.Checked = check;
            }
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode item in node.Nodes)
            {
                item.Checked = check;
                if (item.ParentNode != null)
                {
                    item.ParentNode.Checked = check;
                }
                if (item.HasChildren)
                {
                    AutoChiledNodeCheck(item, item.Checked);
                }
            }
        }

        private void btnRefrshModule_Click(object sender, EventArgs e)
        {
            initModule();
            initModuleBingding();
        }

        private void txtModuleUpdatePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtModuleUpdatePath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void txtModuleName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0:
                    {
                        //MessageBox.Show("Select");
                        openFileDialog1.Filter = "系统模块(*.dll)|*.dll";
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            //读取文件最后修改日期
                            FileInfo fi = new FileInfo(openFileDialog1.FileName);
                            tvModule.FocusedNode.SetValue("sModuleName", openFileDialog1.SafeFileName);
                            tvModule.FocusedNode.SetValue("dDLLLastTime", fi.LastWriteTime.ToString());
                            //tvModule.FocusedNode.SetValue("mCurrentDLL", File.ReadAllBytes(openFileDialog1.FileName));
                        }
                        break;
                    }
                case 1:
                    {
                        if (txtModuleName.Text != "" && (Sunrise.ERP.BaseControl.Public.SystemInfo("是否清除当前模块？", 4) == DialogResult.Yes))
                        {
                            tvModule.FocusedNode.SetValue("iFormID", 0);
                            tvModule.FocusedNode.SetValue("sFormClassName", null);
                            tvModule.FocusedNode.SetValue("sModuleName", null);
                            tvModule.FocusedNode.SetValue("dDLLLastTime", null);
                            //tvModule.FocusedNode.SetValue("mCurrentDLL", null);
                        }
                        break;
                    }
            }
        }

        private void btnUpdateModule_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection.BeginTransaction();
            try
            {
                foreach (DataRow item in dsModule.Tables[0].Rows)
                {
                    if (item.RowState == DataRowState.Added)
                    {
                        item["ID"] = dalMenuNode.Add(item, trans);
                    }
                    if (item.RowState == DataRowState.Modified)
                    {
                        dalMenuNode.Update(item, trans);
                    }
                    if (item.RowState == DataRowState.Deleted)
                    {
                        dalMenuNode.Delete(Convert.ToInt32(item["ID", DataRowVersion.Original]), trans);
                    }
                }
                trans.Commit();
                //刷新菜单
                initModule();
                initModuleBingding();
                Sunrise.ERP.BaseControl.Public.SystemInfo("升级成功!");
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Sunrise.ERP.BaseControl.Public.SystemInfo("升级失败!" + ex.Message, true);
            }
        }
    }
}
