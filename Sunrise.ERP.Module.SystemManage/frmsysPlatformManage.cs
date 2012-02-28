using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

using Sunrise.ERP.Security;
using Sunrise.ERP.BaseControl;
using Sunrise.ERP.BasePublic;
using Sunrise.ERP.DataAccess;

using DevExpress.XtraTreeList.Nodes;


namespace Sunrise.ERP.Module.SystemManage
{
    public partial class frmsysPlatformManage : Sunrise.ERP.BaseForm.frmMasterDetail
    {
        int iSort = 0;
        TreeListNode CurrentNode;
        bool NodeChanged = true;
        public frmsysPlatformManage(int formid, string formtext)
            : base(formid, "Sunrise.ERP.SystemManage.DAL", "sysMenuDAL", " AND 1=1", "iSort", false)
        {
            InitializeComponent();
            Text = formtext;

            txtsMenuName.DataBindings.Add("EditValue", dsMain, "sMenuName");
            txtMenuEngName.DataBindings.Add("EditValue", dsMain, "sMenuEngName");
            txtModuleFile.DataBindings.Add("EditValue", dsMain, "sModuleName");
            txtFormClassName.DataBindings.Add("EditValue", dsMain, "sFormClassName");
            txtFileDate.DataBindings.Add("EditValue", dsMain, "dDLLLastTime");
            txtFormID.DataBindings.Add("EditValue", dsMain, "iFormID");
            txtsQuickMenu.DataBindings.Add("EditValue", dsMain, "sQuickMenu");
        }

        private void frmsysPlatformManage2_Load(object sender, EventArgs e)
        {
            AddDetailData("sysMenuParamDAL", "MenuID", "ID");
            gcDetail.DataSource = LDetailDataSet[LDetailDALName.IndexOf("sysMenuParamDAL")];
            gcDetail.DataMember = "ds";

            DataStateChange(sender, e);
        }

        public override void DataStateChange(object sender, EventArgs e)
        {
            base.DataStateChange(sender, e);
            if (FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsEdit || FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsInsert)
            {
                gvDetail.OptionsBehavior.Editable = true;
                pnlDetailMenu.Enabled = true;
            }
            else
            {
                gvDetail.OptionsBehavior.Editable = false;
                pnlDetailMenu.Enabled = false;
            }
        }
        public override void initBase()
        {
            AddNotNullFields(new string[] { "txtsMenuName", "txtMenuEngName", "txtFormID" });
            AddNotCopyFields(new string[] { "sUserID", "iFlag" });
            base.initBase();
        }

        public override bool DoAppend()
        {
            NodeChanged = false;
            base.DoAppend();
            //新增默认值
            if (radRoot.SelectedIndex == 0)
            {
                ((DataRowView)dsMain.Current).Row["iParentID"] = CurrentNode["ID"];
                NodeChanged = true;
            }
            else
                ((DataRowView)dsMain.Current).Row["iParentID"] = 0;
            ((DataRowView)dsMain.Current).Row["iSort"] = dsMain.CurrencyManager.Count + 1;
            ((DataRowView)dsMain.Current).Row["iFormID"] = DbHelperSQL.GetMaxID("iFormID", "sysMenu");
            dsMain.EndEdit();
            return true;
        }

        public override void MasterAllScroll(object sender, EventArgs e)
        {
            base.MasterAllScroll(sender, e);
            gcDetail.DataSource = LDetailDataSet[LDetailDALName.IndexOf("sysMenuParamDAL")];
        }

        private void btnDetailAdd_Click(object sender, EventArgs e)
        {
            gvDetail.AddNewRow();
        }

        private void btnDetailDelete_Click(object sender, EventArgs e)
        {
            if (gvDetail.RowCount > 0 && gvDetail.FocusedRowHandle >= 0)
            {
                gvDetail.DeleteRow(gvDetail.FocusedRowHandle);
            }
        }

        private void gvDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvDetail.GetFocusedDataRow()["sUserID"] = SecurityCenter.CurrentUserID;
        }

        private void tvMenu_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (e.Node.HasChildren)
                e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            else e.NodeImageIndex = 0;
        }

        private void btnSaveSort_Click(object sender, EventArgs e)
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
                //注册主表数据层操作方法
                RegisterMethod(MasterDALPath, MasterDALName, true);
                foreach (DataRow item in ((DataTable)dsMain.DataSource).Rows)
                {
                    if (item.RowState == DataRowState.Modified)
                    {
                        Update(item, trans);
                    }
                }
                trans.Commit();
                //刷新菜单
                base.DoAfterSave();
                btnSaveSort.Enabled = false;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                btnSaveSort.Enabled = true;
            }
        }

        private void AutoSetMenuSort(DevExpress.XtraTreeList.Nodes.TreeListNode node)
        {
            node.SetValue("iSort", iSort);
            iSort++;
            foreach (TreeListNode item in node.Nodes)
            {
                item.SetValue("iSort", iSort);
                iSort++;
                if (item.HasChildren && item.HasAsParent(node))
                {
                    AutoSetMenuSort(item);
                }
            }
        }

        private void tvMenu_DragEnter(object sender, DragEventArgs e)
        {
            btnSaveSort.Enabled = true;
        }

        public override bool DoDelete()
        {
            if (BillID > 0)
            {
                if (Public.SystemInfo("是否删除该节点？删除该节点时，其子节点也一同删除！", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tvMenu.Nodes.Remove(tvMenu.FocusedNode);
                    SqlTransaction trans = ConnectSetting.SysSqlConnection.BeginTransaction();
                    try
                    {
                        RegisterMethod(MasterDALPath, MasterDALName, true);
                        foreach (DataRow item in ((DataTable)dsMain.DataSource).Rows)
                        {
                            if (item.RowState == DataRowState.Deleted)        
                                Delete(Convert.ToInt32(item["ID", DataRowVersion.Original]), trans);
                        }
                        trans.Commit();
                        IsDataChange = false;
                        if (dsMain.Current == null)
                            initButtonsState(OperateFlag.None);
                        else
                            initButtonsState(OperateFlag.Delete);
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

        private void txtModuleFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            openFileDialog1.Filter = "系统模块(*.dll,*.exe)|*.dll;*.exe";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //读取文件最后修改日期
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                txtModuleFile.Text = openFileDialog1.SafeFileName;
                txtFileDate.Text = fi.LastWriteTime.ToString();
                dsMain.EndEdit();
            }
        }

        private void tvMenu_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (tvMenu.FocusedNode != null && NodeChanged)
                CurrentNode = tvMenu.FocusedNode;
        }

    }
}
