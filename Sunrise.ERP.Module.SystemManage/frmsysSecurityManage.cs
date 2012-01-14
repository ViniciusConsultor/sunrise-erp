using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.Module.SystemManage
{
    public partial class frmsysSecurityManage : Sunrise.ERP.BaseForm.frmMasterDetail
    {
        //菜单拖动结果
        string MenuSelectResult = "";
        List<string> LMenuID = new List<string>();
        List<string> LMenuName = new List<string>();
        List<string> LMenuParentID = new List<string>();
        string sOperationColumn = "";

        private readonly string ReportGUID = "2F7EFE15-60BB-4FDB-9BEF-ECE14669622A";
        Sunrise.ERP.Report.InitReport report;

        public frmsysSecurityManage(int formid, string formtext)
            : base(formid, "Sunrise.ERP.SystemModule.DAL", "sysRolesDAL")
        {
            InitializeComponent();
            if (formtext != "")
            {
                this.Text = formtext;
            }
            txtsRoleNo.DataBindings.Add("EditValue", dsMain, "sRoleNo");
            txtsRoleCName.DataBindings.Add("EditValue", dsMain, "sRoleCName");
            txtsRoleEName.DataBindings.Add("EditValue", dsMain, "sRoleEName");
            txtsRemark.DataBindings.Add("EditValue", dsMain, "sRemark");
            groupControl1.Width = 200;

        }

        public override void initBase()
        {
            //添加非空验证
            AddNotNullFields(new string[] { "txtsRoleNo", "txtsRoleCName" });
            base.initBase();
        }

        private void frmsysSecurityManage_Load(object sender, EventArgs e)
        {
            //添加明细逻辑层处理
            AddDetailData("sysRolesUserDAL", "RoleID", "ID", "sUserID");
            AddDetailData("sysRolesRightsDAL", "RoleID", "ID", "iSort");

            //绑定数据集
            //角色用户
            gcRoleUser.DataSource = LDetailDataSet[LDetailDALName.IndexOf("sysRolesUserDAL")];
            gcRoleUser.DataMember = "ds";

            //角色权限-树形菜单
            tvRoleRight.DataSource = LDetailDataSet[LDetailDALName.IndexOf("sysRolesRightsDAL")];
            tvRoleRight.DataMember = "ds";
            tvRoleRight.KeyFieldName = "MenuID";
            tvRoleRight.ParentFieldName = "iParentID";

            //初始化选择菜单
            initSystemMenu();

            //初始化LookUp控件
            Sunrise.ERP.Common.SystemPublic.InitLkpSystemUser(lkpUser);

            report = new Sunrise.ERP.Report.InitReport(ReportGUID);
            pnlDetailMenu.Visible = false;
            DataStateChange(sender, e);
        }

        public override void DoPrint()
        {
            base.DoPrint();
            report.AddReportData(Sunrise.ERP.DataAccess.DbHelperSQL.Query("SELECT * FROM sysRoles WHERE ID=" + BillID.ToString()).Tables[0], "主表");
            //report.AddReportData((IEnumerable)dsMain.Current, "主表");
            report.AddReportData(LDetailDataSet[LDetailDALName.IndexOf("sysRolesRightsDAL")].Tables[0], "角色权限");
            report.AddReportData(LDetailDataSet[LDetailDALName.IndexOf("sysRolesUserDAL")].Tables[0], "角色用户");
            report.ReportMenu.Show(btnPrint, new Point(0, btnPrint.Height));
        }

        public override void DataStateChange(object sender, EventArgs e)
        {
            base.DataStateChange(sender, e);
            if (FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsEdit || FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsInsert)
            {
                this.tvRoleRight.OptionsBehavior.Editable = true;
                pnlDetailMenu.Enabled = true;
                tvMenu.AllowDrop = true;
                tvRoleRight.AllowDrop = true;
                tvRoleRight.OptionsSelection.MultiSelect = true;
            }
            else
            {
                this.tvRoleRight.OptionsBehavior.Editable = false;
                pnlDetailMenu.Enabled = false;
                tvMenu.AllowDrop = false;
                tvRoleRight.AllowDrop = false;
                tvRoleRight.OptionsSelection.MultiSelect = false;
            }
        }

        private void initSystemMenu()
        {
            DataSet dsMenu = Sunrise.ERP.DataAccess.DbHelperSQL.Query("SELECT A.ID,A.iFormID,A.sMenuName,A.iParentID,A.sModuleName,A.sFormClassName FROM sysMenu A ORDER BY A.iSort");
            dsMenu.Tables[0].TableName = "ds";
            tvMenu.DataSource = dsMenu;
            tvMenu.DataMember = "ds";
            tvMenu.KeyFieldName = "ID";
            tvMenu.ParentFieldName = "iParentID";
            tvMenu.Columns["iFormID"].Visible = false;
            tvMenu.Columns["sModuleName"].Visible = false;
            tvMenu.Columns["sFormClassName"].Visible = false;
        }

        public override void MasterAllScroll(object sender, EventArgs e)
        {
            base.MasterAllScroll(sender, e);
            gcRoleUser.DataSource = LDetailDataSet[LDetailDALName.IndexOf("sysRolesUserDAL")];
            tvRoleRight.DataSource = LDetailDataSet[LDetailDALName.IndexOf("sysRolesRightsDAL")];
        }

        private void tvRoleRight_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (e.Node.HasChildren)
                e.NodeImageIndex = e.Node.Expanded ? 0 : 1;
            else e.NodeImageIndex = 1;
        }

        private void tvMenu_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (e.Node.HasChildren)
                e.NodeImageIndex = e.Node.Expanded ? 0 : 1;
            else e.NodeImageIndex = 1;
        }

        private void tvRoleRight_DragDrop(object sender, DragEventArgs e)
        {
            for (int i = 0; i < LMenuID.Count; i++)
            {
                if (!GetRoleMenuIDList().Contains(LMenuID[i]))
                {
                    DataRow drNew = LDetailDataSet[LDetailDALName.IndexOf("sysRolesRightsDAL")].Tables[0].NewRow();
                    drNew["MenuID"] = int.Parse(LMenuID[i]);
                    drNew["iParentID"] = int.Parse(LMenuParentID[i]);
                    drNew["sMenuName"] = LMenuName[i];
                    LDetailDataSet[LDetailDALName.IndexOf("sysRolesRightsDAL")].Tables[0].Rows.Add(drNew);
                }
            }
            tvRoleRight.Refresh();

        }

        private void tvRoleRight_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Text"))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private string GetRoleMenuIDList()
        {
            string sResult = "";
            foreach (DataRow dr in LDetailDataSet[LDetailDALName.IndexOf("sysRolesRightsDAL")].Tables[0].Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    sResult += dr["MenuID"].ToString() + ",";
                }
            }
            if (sResult != "")
            {
                sResult = sResult.Substring(0, sResult.Length - 1);
            }
            return sResult;
        }

        private void tvMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (FormDataFlag != Sunrise.ERP.BasePublic.DataFlag.dsBrowse)
                {
                    //cmsSystemMenu.Show(tvMenu, ((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                }
            }
            else
            {
                if (tvMenu.FocusedNode != null)
                {
                    MenuSelectResult = "";
                    LMenuID.Clear();
                    LMenuName.Clear();
                    LMenuParentID.Clear();
                    tvMenu.DoDragDrop(GetNodesID(tvMenu.FocusedNode), DragDropEffects.Move);
                }
            }

        }
        /// <summary>
        /// 遍历选择拖动的菜单ID
        /// </summary>
        /// <param name="node">选择的菜单节点</param>
        /// <returns></returns>
        private string GetNodesID(DevExpress.XtraTreeList.Nodes.TreeListNode node)
        {
            //如果本节点有父节点，那么也一起选择进来,先找父节点，再找本节点，再找下面的子节点
            GetNodesParentID(node);
            if (!MenuSelectResult.Contains(node.GetValue("ID").ToString()))
            {
                MenuSelectResult += node.GetValue("ID").ToString() + ",";
                LMenuID.Add(node.GetValue("ID").ToString());
                LMenuName.Add(node.GetValue("sMenuName").ToString());
                LMenuParentID.Add(node.GetValue("iParentID").ToString());                
            }
            
            //遍历当前节点下面所有的菜单，也一起选择
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode n in node.Nodes)
            {
                MenuSelectResult += n.GetValue("ID").ToString() + ",";
                LMenuID.Add(n.GetValue("ID").ToString());
                LMenuName.Add(n.GetValue("sMenuName").ToString());
                LMenuParentID.Add(n.GetValue("iParentID").ToString());
                if (n.HasChildren)
                {
                    GetNodesID(n);
                }
            }
            return MenuSelectResult.Substring(0, MenuSelectResult.Length - 1);
        }

        private void GetNodesParentID(DevExpress.XtraTreeList.Nodes.TreeListNode node)
        {
            if (node.ParentNode != null)
            {
                if (!MenuSelectResult.Contains(node.ParentNode.GetValue("ID").ToString()))
                {
                    MenuSelectResult += node.ParentNode.GetValue("ID").ToString() + ",";
                    LMenuID.Add(node.ParentNode.GetValue("ID").ToString());
                    LMenuName.Add(node.ParentNode.GetValue("sMenuName").ToString());
                    LMenuParentID.Add(node.ParentNode.GetValue("iParentID").ToString());
                }
                GetNodesParentID(node.ParentNode);
            }
            
        }

        private void tcRoleDetail_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tcRoleDetail.SelectedTabPageIndex == 1)
            {
                pnlDetailMenu.Visible = true;
            }
            else
            {
                pnlDetailMenu.Visible = false;
            }
        }

        private void btnDetailAdd_Click(object sender, EventArgs e)
        {
            lkpUser.SearchFormFilter = BulitLkpFilterString();
            lkpUser.LookUpSelfClick(sender, null);
            if (lkpUser.ReturnData.Rows.Count > 0)
            {
                foreach (DataRow dr in lkpUser.ReturnData.Rows)
                {
                    DataRow dtNew = LDetailDataSet[LDetailDALName.IndexOf("sysRolesUserDAL")].Tables[0].NewRow();
                    dtNew["UserID"] = dr["ID"];
                    dtNew["sRoleUserID"] = dr["sUserID"];
                    dtNew["sRoleUserCName"] = dr["sUserCName"];
                    LDetailDataSet[LDetailDALName.IndexOf("sysRolesUserDAL")].Tables[0].Rows.Add(dtNew);
                }
            }
        }

        //过滤已选择的用户
        private string BulitLkpFilterString()
        {
            string s = "";
            for (int i = 0; i < gvRoleUser.RowCount; i++)
            {
                if (i == gvRoleUser.RowCount - 1)
                {
                    s += "'" + gvRoleUser.GetDataRow(i)["sRoleUserID"].ToString() + "'";
                }
                else
                {
                    s += "'" + gvRoleUser.GetDataRow(i)["sRoleUserID"].ToString() + "',";
                }
            }
            if (s != "")
            {
                s = "sUserID NOT IN(" + s + ")";
            }
            return s;
        }

        private void btnDetailDelete_Click(object sender, EventArgs e)
        {
            if (gvRoleUser.FocusedRowHandle >= 0)
            {
                gvRoleUser.DeleteRow(gvRoleUser.FocusedRowHandle);
            }
        }

        private void tvRoleRight_Click(object sender, EventArgs e)
        {
            DevExpress.XtraTreeList.TreeListHitInfo tvHit = tvRoleRight.CalcHitInfo(tvRoleRight.PointToClient(Control.MousePosition));//((Control)sender).PointToClient(Control.MousePosition));
            if (tvRoleRight.Nodes.Count > 0 && FormDataFlag != Sunrise.ERP.BasePublic.DataFlag.dsBrowse)
            {
                if (tvRoleRight.FocusedNode != null && tvHit.Column != null)
                {
                    if (((MouseEventArgs)e).Button == MouseButtons.Right && tvHit.Column.FieldName == "sMenuName")
                    {
                        cmsRoleRight.Show(tvRoleRight, ((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                    }
                    else
                    {
                        if (Control.ModifierKeys == Keys.Control && tvHit.Column.FieldName == "iView")
                        {
                            BatchDetail("iView", ((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                        }
                        else if (Control.ModifierKeys == Keys.Control && tvHit.Column.FieldName == "iAdd")
                        {
                            BatchDetail("iAdd", ((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                        }
                        else if (Control.ModifierKeys == Keys.Control && tvHit.Column.FieldName == "iEdit")
                        {
                            BatchDetail("iEdit", ((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                        }
                        else if (Control.ModifierKeys == Keys.Control && tvHit.Column.FieldName == "iDelete")
                        {
                            BatchDetail("iDelete", ((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                        }
                        else if (Control.ModifierKeys == Keys.Control && tvHit.Column.FieldName == "iPrint")
                        {
                            BatchDetail("iPrint", ((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                        }
                        else if (Control.ModifierKeys == Keys.Control && tvHit.Column.FieldName == "iNum")
                        {
                            BatchDetail("iNum", ((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                        }
                        else if (Control.ModifierKeys == Keys.Control && tvHit.Column.FieldName == "iPrice")
                        {
                            BatchDetail("iPrice", ((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                        }

                    }
                }
            }
        }
        private void BatchDetail(string columnname, int x, int y)
        {
            if (columnname == "iAdd")
            {
                sOperationColumn = columnname;
                cmsOperationTrueOrFalse.Show(tvRoleRight, x, y);
            }
            else
            {
                sOperationColumn = columnname;
                cmsOperation.Show(tvRoleRight, x, y);
            }
        }

        private void tsmNone_Click(object sender, EventArgs e)
        {
            switch (((ToolStripMenuItem)sender).Name)
            {
                case "tsmNone":
                    {
                        SetAllValue(0);
                        break;
                    }
                case "tsmSelf":
                    {
                        SetAllValue(1);
                        break;
                    }
                case "tsmUnderling":
                    {
                        SetAllValue(2);
                        break;
                    }
                case "tsmSelfAndUnderling":
                    {
                        SetAllValue(3);
                        break;
                    }
                case "tsmDepartment":
                    {
                        SetAllValue(4);
                        break;
                    }
                case "tsmAll":
                    {
                        SetAllValue(5);
                        break;
                    }
            }
        }

         /// <summary>
        /// 批量设置权限值
        /// </summary>
        /// <param name="value">权限值</param>
        private void SetAllValue(int value)
        {
            switch (sOperationColumn)
            {
                case "iView":
                    {
                        if (tvRoleRight.Selection.Count > 1)
                        {
                            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode item in tvRoleRight.Selection)
                            {
                                item.SetValue("iView", value);
                            }
                        }
                        else
                        {
                            foreach (DataRow item in LDetailDataSet[LDetailDALName.IndexOf("sysRolesRightsDAL")].Tables[0].Rows)
                            {
                                if (item.RowState != DataRowState.Deleted)
                                {
                                    item["iView"] = value;
                                }
                            }
                        }
                        break;
                    }
                case "iAdd":
                    {
                        if (tvRoleRight.Selection.Count > 1)
                        {
                            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode item in tvRoleRight.Selection)
                            {
                                item.SetValue("iAdd", value);
                            }
                        }
                        else
                        {
                            foreach (DataRow item in LDetailDataSet[LDetailDALName.IndexOf("sysRolesRightsDAL")].Tables[0].Rows)
                            {
                                if (item.RowState != DataRowState.Deleted)
                                {
                                    item["iAdd"] = value;
                                }
                            }
                        }
                        break;
                    }
                case "iEdit":
                    {
                        if (tvRoleRight.Selection.Count > 1)
                        {
                            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode item in tvRoleRight.Selection)
                            {
                                item.SetValue("iEdit", value);
                            }
                        }
                        else
                        {
                            foreach (DataRow item in LDetailDataSet[LDetailDALName.IndexOf("sysRolesRightsDAL")].Tables[0].Rows)
                            {
                                if (item.RowState != DataRowState.Deleted)
                                {
                                    item["iEdit"] = value;
                                }
                            }
                        }
                        break;
                    }
                case "iDelete":
                    {
                        if (tvRoleRight.Selection.Count > 1)
                        {
                            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode item in tvRoleRight.Selection)
                            {
                                item.SetValue("iDelete", value);
                            }
                        }
                        else
                        {
                            foreach (DataRow item in LDetailDataSet[LDetailDALName.IndexOf("sysRolesRightsDAL")].Tables[0].Rows)
                            {
                                if (item.RowState != DataRowState.Deleted)
                                {
                                    item["iDelete"] = value;
                                }
                            }
                        }
                        break;
                    }
                case "iPrint":
                    {
                        if (tvRoleRight.Selection.Count > 1)
                        {
                            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode item in tvRoleRight.Selection)
                            {
                                item.SetValue("iPrint", value);
                            }
                        }
                        else
                        {
                            foreach (DataRow item in LDetailDataSet[LDetailDALName.IndexOf("sysRolesRightsDAL")].Tables[0].Rows)
                            {
                                if (item.RowState != DataRowState.Deleted)
                                {
                                    item["iPrint"] = value;
                                }
                            }
                        }
                        break;
                    }
                case "iNum":
                    {
                        if (tvRoleRight.Selection.Count > 1)
                        {
                            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode item in tvRoleRight.Selection)
                            {
                                item.SetValue("iNum", value);
                            }
                        }
                        else
                        {
                            foreach (DataRow item in LDetailDataSet[LDetailDALName.IndexOf("sysRolesRightsDAL")].Tables[0].Rows)
                            {
                                if (item.RowState != DataRowState.Deleted)
                                {
                                    item["iNum"] = value;
                                }
                            }
                        }
                        break;
                    }
                case "iPrice":
                    {
                        if (tvRoleRight.Selection.Count > 1)
                        {
                            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode item in tvRoleRight.Selection)
                            {
                                item.SetValue("iPrice", value);
                            }
                        }
                        else
                        {
                            foreach (DataRow item in LDetailDataSet[LDetailDALName.IndexOf("sysRolesRightsDAL")].Tables[0].Rows)
                            {
                                if (item.RowState != DataRowState.Deleted)
                                {
                                    item["iPrice"] = value;
                                }
                            }
                        }
                        break;
                    }
            }
        }

        private void tsmTrue_Click(object sender, EventArgs e)
        {
            switch (((ToolStripMenuItem)sender).Name)
            {
                case "tsmTrue":
                    {
                        SetAllValue(1);
                        break;
                    }
                case "tsmFalse":
                    {
                        SetAllValue(0);
                        break;
                    }
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            tvRoleRight.Nodes.Remove(tvRoleRight.FocusedNode);
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            frmsysEditUser frm = new frmsysEditUser();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }


    }
}
