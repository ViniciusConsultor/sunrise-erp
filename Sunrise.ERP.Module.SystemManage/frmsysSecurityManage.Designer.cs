namespace Sunrise.ERP.Module.SystemManage
{
    partial class frmsysSecurityManage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsysSecurityManage));
            this.gcRole = new Sunrise.ERP.Controls.SunriseGridControl();
            this.gvRole = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsRoleNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsRoleCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsRoleEName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtsRemark = new DevExpress.XtraEditors.MemoEdit();
            this.txtsRoleCName = new DevExpress.XtraEditors.TextEdit();
            this.txtsRoleNo = new DevExpress.XtraEditors.TextEdit();
            this.txtsRoleEName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.pnlDetailMenu = new DevExpress.XtraEditors.PanelControl();
            this.btnDetailDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnDetailAdd = new DevExpress.XtraEditors.SimpleButton();
            this.tcRoleDetail = new DevExpress.XtraTab.XtraTabControl();
            this.tpRolesRight = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.tvRoleRight = new DevExpress.XtraTreeList.TreeList();
            this.trcolsMenuName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcoliView = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cbxAuth = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.trcoliAdd = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkiAdd = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.trcoliEdit = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcoliDelete = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcoliPrint = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcoliPrice = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcoliNum = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcoliProperty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcoliOutPut = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lkpUser = new Sunrise.ERP.Controls.SunriseLookUp();
            this.splitterControl3 = new DevExpress.XtraEditors.SplitterControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tvMenu = new DevExpress.XtraTreeList.TreeList();
            this.tpRolesUser = new DevExpress.XtraTab.XtraTabPage();
            this.gcRoleUser = new Sunrise.ERP.Controls.SunriseGridControl();
            this.gvRoleUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsRoleUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsRoleUserCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmNone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSelf = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUnderling = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSelfAndUnderling = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeptUnder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeptAndDeptUnder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsOperationTrueOrFalse = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmTrue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFalse = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRoleRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditUser = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetail)).BeginInit();
            this.pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfo)).BeginInit();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtsRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsRoleCName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsRoleNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsRoleEName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetailMenu)).BeginInit();
            this.pnlDetailMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcRoleDetail)).BeginInit();
            this.tcRoleDetail.SuspendLayout();
            this.tpRolesRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvRoleRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxAuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkiAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvMenu)).BeginInit();
            this.tpRolesUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRoleUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRoleUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            this.cmsOperation.SuspendLayout();
            this.cmsOperationTrueOrFalse.SuspendLayout();
            this.cmsRoleRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.tcRoleDetail);
            this.pnlDetail.Controls.Add(this.pnlDetailMenu);
            this.pnlDetail.Location = new System.Drawing.Point(208, 198);
            this.pnlDetail.Size = new System.Drawing.Size(651, 298);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.layoutControl1);
            this.pnlInfo.Size = new System.Drawing.Size(651, 157);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gcRole);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(208, 192);
            this.splitterControl1.Size = new System.Drawing.Size(651, 6);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnEditUser);
            this.panelControl2.LookAndFeel.SkinName = "Blue";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Size = new System.Drawing.Size(857, 33);
            this.panelControl2.Controls.SetChildIndex(this.dataNav, 0);
            this.panelControl2.Controls.SetChildIndex(this.btnAction, 0);
            this.panelControl2.Controls.SetChildIndex(this.btnProperty, 0);
            this.panelControl2.Controls.SetChildIndex(this.btnView, 0);
            this.panelControl2.Controls.SetChildIndex(this.btnAdd, 0);
            this.panelControl2.Controls.SetChildIndex(this.btnEdit, 0);
            this.panelControl2.Controls.SetChildIndex(this.btnSave, 0);
            this.panelControl2.Controls.SetChildIndex(this.btnCancel, 0);
            this.panelControl2.Controls.SetChildIndex(this.btnDelete, 0);
            this.panelControl2.Controls.SetChildIndex(this.btnClose, 0);
            this.panelControl2.Controls.SetChildIndex(this.btnPrint, 0);
            this.panelControl2.Controls.SetChildIndex(this.btnCopy, 0);
            this.panelControl2.Controls.SetChildIndex(this.btnInsert, 0);
            this.panelControl2.Controls.SetChildIndex(this.btnRefresh, 0);
            this.panelControl2.Controls.SetChildIndex(this.btnEditUser, 0);
            // 
            // btnInsert
            // 
            this.btnInsert.LookAndFeel.SkinName = "Blue";
            this.btnInsert.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnCopy
            // 
            this.btnCopy.LookAndFeel.SkinName = "Blue";
            this.btnCopy.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnPrint
            // 
            this.btnPrint.LookAndFeel.SkinName = "Blue";
            this.btnPrint.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnClose
            // 
            this.btnClose.LookAndFeel.SkinName = "Blue";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnDelete
            // 
            this.btnDelete.LookAndFeel.SkinName = "Blue";
            this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnCancel
            // 
            this.btnCancel.LookAndFeel.SkinName = "Blue";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnSave
            // 
            this.btnSave.LookAndFeel.SkinName = "Blue";
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnEdit
            // 
            this.btnEdit.LookAndFeel.SkinName = "Blue";
            this.btnEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnAdd
            // 
            this.btnAdd.LookAndFeel.SkinName = "Blue";
            this.btnAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnView
            // 
            this.btnView.LookAndFeel.SkinName = "Blue";
            this.btnView.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.LookAndFeel.SkinName = "Blue";
            this.btnRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // txtDataFlag
            // 
            // 
            // btnSettings
            // 
            this.btnProperty.LookAndFeel.SkinName = "Blue";
            this.btnProperty.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // dataNav
            // 
            this.dataNav.Buttons.Append.Visible = false;
            this.dataNav.Buttons.CancelEdit.Visible = false;
            this.dataNav.Buttons.EndEdit.Visible = false;
            this.dataNav.Buttons.NextPage.Visible = false;
            this.dataNav.Buttons.PrevPage.Visible = false;
            this.dataNav.Buttons.Remove.Visible = false;
            // 
            // btnAction
            // 
            this.btnAction.LookAndFeel.SkinName = "Blue";
            this.btnAction.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // panelControl1
            // 
            this.panelControl1.LookAndFeel.SkinName = "Blue";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Size = new System.Drawing.Size(861, 498);
            // 
            // gcRole
            // 
            this.gcRole.DataSource = this.dsMain;
            this.gcRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcRole.Location = new System.Drawing.Point(2, 2);
            this.gcRole.MainView = this.gvRole;
            this.gcRole.Name = "gcRole";
            this.gcRole.Size = new System.Drawing.Size(196, 457);
            this.gcRole.TabIndex = 0;
            this.gcRole.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRole});
            // 
            // gvRole
            // 
            this.gvRole.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsRoleNo,
            this.colsRoleCName,
            this.colsRoleEName});
            this.gvRole.GridControl = this.gcRole;
            this.gvRole.Name = "gvRole";
            this.gvRole.OptionsBehavior.Editable = false;
            this.gvRole.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvRole.OptionsView.ColumnAutoWidth = false;
            this.gvRole.OptionsView.ShowAutoFilterRow = true;
            this.gvRole.OptionsView.ShowFooter = true;
            this.gvRole.OptionsView.ShowGroupPanel = false;
            // 
            // colsRoleNo
            // 
            this.colsRoleNo.Caption = "角色编号";
            this.colsRoleNo.FieldName = "sRoleNo";
            this.colsRoleNo.Name = "colsRoleNo";
            this.colsRoleNo.Visible = true;
            this.colsRoleNo.VisibleIndex = 0;
            this.colsRoleNo.Width = 80;
            // 
            // colsRoleCName
            // 
            this.colsRoleCName.Caption = "中文名称";
            this.colsRoleCName.FieldName = "sRoleCName";
            this.colsRoleCName.Name = "colsRoleCName";
            this.colsRoleCName.Visible = true;
            this.colsRoleCName.VisibleIndex = 1;
            this.colsRoleCName.Width = 80;
            // 
            // colsRoleEName
            // 
            this.colsRoleEName.Caption = "英文名称";
            this.colsRoleEName.FieldName = "sRoleEName";
            this.colsRoleEName.Name = "colsRoleEName";
            this.colsRoleEName.Visible = true;
            this.colsRoleEName.VisibleIndex = 2;
            this.colsRoleEName.Width = 80;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtsRemark);
            this.layoutControl1.Controls.Add(this.txtsRoleCName);
            this.layoutControl1.Controls.Add(this.txtsRoleNo);
            this.layoutControl1.Controls.Add(this.txtsRoleEName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.LookAndFeel.SkinName = "Blue";
            this.layoutControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(647, 153);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtsRemark
            // 
            this.txtsRemark.Location = new System.Drawing.Point(60, 105);
            this.txtsRemark.Name = "txtsRemark";
            this.txtsRemark.Size = new System.Drawing.Size(576, 37);
            this.txtsRemark.StyleController = this.layoutControl1;
            this.txtsRemark.TabIndex = 7;
            this.txtsRemark.Tag = "NoTab";
            // 
            // txtsRoleCName
            // 
            this.txtsRoleCName.Location = new System.Drawing.Point(60, 55);
            this.txtsRoleCName.Name = "txtsRoleCName";
            this.txtsRoleCName.Size = new System.Drawing.Size(576, 21);
            this.txtsRoleCName.StyleController = this.layoutControl1;
            this.txtsRoleCName.TabIndex = 6;
            // 
            // txtsRoleNo
            // 
            this.txtsRoleNo.Location = new System.Drawing.Point(60, 30);
            this.txtsRoleNo.Name = "txtsRoleNo";
            this.txtsRoleNo.Size = new System.Drawing.Size(576, 21);
            this.txtsRoleNo.StyleController = this.layoutControl1;
            this.txtsRoleNo.TabIndex = 5;
            // 
            // txtsRoleEName
            // 
            this.txtsRoleEName.Location = new System.Drawing.Point(60, 80);
            this.txtsRoleEName.Name = "txtsRoleEName";
            this.txtsRoleEName.Size = new System.Drawing.Size(576, 21);
            this.txtsRoleEName.StyleController = this.layoutControl1;
            this.txtsRoleEName.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(647, 153);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.CustomizationFormText = "tabbedControlGroup1";
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup2;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(643, 149);
            this.tabbedControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.tabbedControlGroup1.Text = "tabbedControlGroup1";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "角色信息";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(632, 116);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Text = "角色信息";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtsRemark;
            this.layoutControlItem1.CustomizationFormText = "备注";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 75);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(632, 41);
            this.layoutControlItem1.Text = "备注";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtsRoleEName;
            this.layoutControlItem2.CustomizationFormText = "英文名称";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(632, 25);
            this.layoutControlItem2.Text = "英文名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtsRoleCName;
            this.layoutControlItem3.CustomizationFormText = "中文名称";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(632, 25);
            this.layoutControlItem3.Text = "中文名称";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtsRoleNo;
            this.layoutControlItem4.CustomizationFormText = "角色编号";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(632, 25);
            this.layoutControlItem4.Text = "角色编号";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // pnlDetailMenu
            // 
            this.pnlDetailMenu.Controls.Add(this.btnDetailDelete);
            this.pnlDetailMenu.Controls.Add(this.btnDetailAdd);
            this.pnlDetailMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailMenu.Location = new System.Drawing.Point(2, 2);
            this.pnlDetailMenu.LookAndFeel.SkinName = "Blue";
            this.pnlDetailMenu.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlDetailMenu.Name = "pnlDetailMenu";
            this.pnlDetailMenu.Size = new System.Drawing.Size(647, 33);
            this.pnlDetailMenu.TabIndex = 3;
            // 
            // btnDetailDelete
            // 
            this.btnDetailDelete.Image = global::Sunrise.ERP.Module.SystemManage.Properties.Resources.delete;
            this.btnDetailDelete.Location = new System.Drawing.Point(30, 4);
            this.btnDetailDelete.LookAndFeel.SkinName = "Blue";
            this.btnDetailDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDetailDelete.Name = "btnDetailDelete";
            this.btnDetailDelete.Size = new System.Drawing.Size(24, 24);
            this.btnDetailDelete.TabIndex = 1;
            this.btnDetailDelete.ToolTip = "新增";
            this.btnDetailDelete.Click += new System.EventHandler(this.btnDetailDelete_Click);
            // 
            // btnDetailAdd
            // 
            this.btnDetailAdd.Image = global::Sunrise.ERP.Module.SystemManage.Properties.Resources.add;
            this.btnDetailAdd.Location = new System.Drawing.Point(5, 4);
            this.btnDetailAdd.LookAndFeel.SkinName = "Blue";
            this.btnDetailAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDetailAdd.Name = "btnDetailAdd";
            this.btnDetailAdd.Size = new System.Drawing.Size(24, 24);
            this.btnDetailAdd.TabIndex = 0;
            this.btnDetailAdd.ToolTip = "查询";
            this.btnDetailAdd.Click += new System.EventHandler(this.btnDetailAdd_Click);
            // 
            // tcRoleDetail
            // 
            this.tcRoleDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcRoleDetail.Location = new System.Drawing.Point(2, 35);
            this.tcRoleDetail.Name = "tcRoleDetail";
            this.tcRoleDetail.SelectedTabPage = this.tpRolesRight;
            this.tcRoleDetail.Size = new System.Drawing.Size(647, 261);
            this.tcRoleDetail.TabIndex = 4;
            this.tcRoleDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpRolesRight,
            this.tpRolesUser});
            this.tcRoleDetail.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tcRoleDetail_SelectedPageChanged);
            // 
            // tpRolesRight
            // 
            this.tpRolesRight.Controls.Add(this.groupControl2);
            this.tpRolesRight.Controls.Add(this.splitterControl3);
            this.tpRolesRight.Controls.Add(this.groupControl1);
            this.tpRolesRight.Name = "tpRolesRight";
            this.tpRolesRight.Size = new System.Drawing.Size(640, 232);
            this.tpRolesRight.Text = "角色权限";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.tvRoleRight);
            this.groupControl2.Controls.Add(this.lkpUser);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(495, 232);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "权限分配";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(64, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "(按住Ctrl+鼠标右键可快速设置权限)";
            // 
            // tvRoleRight
            // 
            this.tvRoleRight.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.trcolsMenuName,
            this.trcoliView,
            this.trcoliAdd,
            this.trcoliEdit,
            this.trcoliDelete,
            this.trcoliPrint,
            this.trcoliPrice,
            this.trcoliNum,
            this.trcoliProperty,
            this.trcoliOutPut});
            this.tvRoleRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRoleRight.KeyFieldName = "";
            this.tvRoleRight.Location = new System.Drawing.Point(2, 23);
            this.tvRoleRight.LookAndFeel.SkinName = "Blue";
            this.tvRoleRight.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tvRoleRight.Name = "tvRoleRight";
            this.tvRoleRight.OptionsBehavior.PopulateServiceColumns = true;
            this.tvRoleRight.OptionsMenu.EnableColumnMenu = false;
            this.tvRoleRight.OptionsMenu.EnableFooterMenu = false;
            this.tvRoleRight.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tvRoleRight.OptionsSelection.MultiSelect = true;
            this.tvRoleRight.OptionsSelection.UseIndicatorForSelection = true;
            this.tvRoleRight.OptionsView.AutoWidth = false;
            this.tvRoleRight.OptionsView.ShowHorzLines = false;
            this.tvRoleRight.OptionsView.ShowVertLines = false;
            this.tvRoleRight.ParentFieldName = "";
            this.tvRoleRight.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkiAdd,
            this.cbxAuth});
            this.tvRoleRight.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            this.tvRoleRight.Size = new System.Drawing.Size(491, 207);
            this.tvRoleRight.StateImageList = this.imageList1;
            this.tvRoleRight.TabIndex = 3;
            this.tvRoleRight.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.tvRoleRight.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.tvRoleRight_GetStateImage);
            this.tvRoleRight.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvRoleRight_DragDrop);
            this.tvRoleRight.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvRoleRight_DragEnter);
            this.tvRoleRight.Click += new System.EventHandler(this.tvRoleRight_Click);
            // 
            // trcolsMenuName
            // 
            this.trcolsMenuName.Caption = "模块名称";
            this.trcolsMenuName.FieldName = "sMenuName";
            this.trcolsMenuName.Name = "trcolsMenuName";
            this.trcolsMenuName.OptionsColumn.AllowEdit = false;
            this.trcolsMenuName.OptionsColumn.AllowSort = false;
            this.trcolsMenuName.Visible = true;
            this.trcolsMenuName.VisibleIndex = 0;
            this.trcolsMenuName.Width = 164;
            // 
            // trcoliView
            // 
            this.trcoliView.Caption = "查询权限";
            this.trcoliView.ColumnEdit = this.cbxAuth;
            this.trcoliView.FieldName = "iView";
            this.trcoliView.Name = "trcoliView";
            this.trcoliView.OptionsColumn.AllowSort = false;
            this.trcoliView.Visible = true;
            this.trcoliView.VisibleIndex = 1;
            this.trcoliView.Width = 78;
            // 
            // cbxAuth
            // 
            this.cbxAuth.AutoHeight = false;
            this.cbxAuth.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxAuth.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("禁用", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("个人", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("下属", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("个人及下属", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("部门", 4, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("下属部门", 6, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("部门及下属部门", 7, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("所有", 5, -1)});
            this.cbxAuth.Name = "cbxAuth";
            // 
            // trcoliAdd
            // 
            this.trcoliAdd.Caption = "新增权限";
            this.trcoliAdd.ColumnEdit = this.chkiAdd;
            this.trcoliAdd.FieldName = "iAdd";
            this.trcoliAdd.Name = "trcoliAdd";
            this.trcoliAdd.OptionsColumn.AllowSort = false;
            this.trcoliAdd.Visible = true;
            this.trcoliAdd.VisibleIndex = 2;
            this.trcoliAdd.Width = 62;
            // 
            // chkiAdd
            // 
            this.chkiAdd.AutoHeight = false;
            this.chkiAdd.Name = "chkiAdd";
            // 
            // trcoliEdit
            // 
            this.trcoliEdit.Caption = "编辑权限";
            this.trcoliEdit.ColumnEdit = this.cbxAuth;
            this.trcoliEdit.FieldName = "iEdit";
            this.trcoliEdit.Name = "trcoliEdit";
            this.trcoliEdit.OptionsColumn.AllowSort = false;
            this.trcoliEdit.Visible = true;
            this.trcoliEdit.VisibleIndex = 3;
            this.trcoliEdit.Width = 80;
            // 
            // trcoliDelete
            // 
            this.trcoliDelete.Caption = "删除权限";
            this.trcoliDelete.ColumnEdit = this.cbxAuth;
            this.trcoliDelete.FieldName = "iDelete";
            this.trcoliDelete.Name = "trcoliDelete";
            this.trcoliDelete.OptionsColumn.AllowSort = false;
            this.trcoliDelete.Visible = true;
            this.trcoliDelete.VisibleIndex = 4;
            this.trcoliDelete.Width = 80;
            // 
            // trcoliPrint
            // 
            this.trcoliPrint.Caption = "打印权限";
            this.trcoliPrint.ColumnEdit = this.cbxAuth;
            this.trcoliPrint.FieldName = "iPrint";
            this.trcoliPrint.Name = "trcoliPrint";
            this.trcoliPrint.OptionsColumn.AllowSort = false;
            this.trcoliPrint.Visible = true;
            this.trcoliPrint.VisibleIndex = 5;
            this.trcoliPrint.Width = 80;
            // 
            // trcoliPrice
            // 
            this.trcoliPrice.Caption = "价格权限";
            this.trcoliPrice.ColumnEdit = this.chkiAdd;
            this.trcoliPrice.FieldName = "iPrice";
            this.trcoliPrice.Name = "trcoliPrice";
            this.trcoliPrice.OptionsColumn.AllowSort = false;
            this.trcoliPrice.Visible = true;
            this.trcoliPrice.VisibleIndex = 6;
            this.trcoliPrice.Width = 80;
            // 
            // trcoliNum
            // 
            this.trcoliNum.Caption = "数量权限";
            this.trcoliNum.ColumnEdit = this.chkiAdd;
            this.trcoliNum.FieldName = "iNum";
            this.trcoliNum.Name = "trcoliNum";
            this.trcoliNum.OptionsColumn.AllowSort = false;
            this.trcoliNum.Visible = true;
            this.trcoliNum.VisibleIndex = 7;
            this.trcoliNum.Width = 80;
            // 
            // trcoliProperty
            // 
            this.trcoliProperty.Caption = "属性权限";
            this.trcoliProperty.ColumnEdit = this.chkiAdd;
            this.trcoliProperty.FieldName = "iProperty";
            this.trcoliProperty.Name = "trcoliProperty";
            this.trcoliProperty.OptionsColumn.AllowSort = false;
            this.trcoliProperty.Visible = true;
            this.trcoliProperty.VisibleIndex = 8;
            // 
            // trcoliOutPut
            // 
            this.trcoliOutPut.Caption = "导出权限";
            this.trcoliOutPut.ColumnEdit = this.chkiAdd;
            this.trcoliOutPut.FieldName = "iOutPut";
            this.trcoliOutPut.Name = "trcoliOutPut";
            this.trcoliOutPut.OptionsColumn.AllowSort = false;
            this.trcoliOutPut.Visible = true;
            this.trcoliOutPut.VisibleIndex = 9;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "folderopen.gif");
            this.imageList1.Images.SetKeyName(1, "folder.gif");
            this.imageList1.Images.SetKeyName(2, "file.png");
            // 
            // lkpUser
            // 
            this.lkpUser.AutoSize = true;
            this.lkpUser.DataField = null;
            this.lkpUser.DisplayField = null;
            this.lkpUser.EditFormFilter = null;
            this.lkpUser.EditFormID = 0;
            this.lkpUser.EditFormName = null;
            this.lkpUser.EditValue = "";
            this.lkpUser.FormID = 0;
            this.lkpUser.GridColumnText = null;
            this.lkpUser.GridDisplayField = null;
            this.lkpUser.Location = new System.Drawing.Point(153, -51);
            this.lkpUser.Name = "lkpUser";
            this.lkpUser.SearchFormFilter = "";
            this.lkpUser.SearchFormText = "";
            this.lkpUser.Size = new System.Drawing.Size(132, 21);
            this.lkpUser.SQL = null;
            this.lkpUser.TabIndex = 2;
            this.lkpUser.TextFont = new System.Drawing.Font("Tahoma", 9F);
            // 
            // splitterControl3
            // 
            this.splitterControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl3.Location = new System.Drawing.Point(495, 0);
            this.splitterControl3.Name = "splitterControl3";
            this.splitterControl3.Size = new System.Drawing.Size(6, 232);
            this.splitterControl3.TabIndex = 5;
            this.splitterControl3.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tvMenu);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl1.Location = new System.Drawing.Point(501, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(139, 232);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "系统菜单";
            // 
            // tvMenu
            // 
            this.tvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMenu.KeyFieldName = "";
            this.tvMenu.Location = new System.Drawing.Point(2, 23);
            this.tvMenu.LookAndFeel.SkinName = "Blue";
            this.tvMenu.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tvMenu.Name = "tvMenu";
            this.tvMenu.OptionsBehavior.DragNodes = true;
            this.tvMenu.OptionsBehavior.Editable = false;
            this.tvMenu.OptionsMenu.EnableColumnMenu = false;
            this.tvMenu.OptionsMenu.EnableFooterMenu = false;
            this.tvMenu.OptionsSelection.MultiSelect = true;
            this.tvMenu.OptionsView.ShowColumns = false;
            this.tvMenu.OptionsView.ShowHorzLines = false;
            this.tvMenu.OptionsView.ShowIndicator = false;
            this.tvMenu.OptionsView.ShowVertLines = false;
            this.tvMenu.ParentFieldName = "";
            this.tvMenu.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            this.tvMenu.Size = new System.Drawing.Size(135, 207);
            this.tvMenu.StateImageList = this.imageList1;
            this.tvMenu.TabIndex = 2;
            this.tvMenu.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.tvMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvMenu_MouseDown);
            this.tvMenu.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.tvMenu_GetStateImage);
            // 
            // tpRolesUser
            // 
            this.tpRolesUser.Controls.Add(this.gcRoleUser);
            this.tpRolesUser.Name = "tpRolesUser";
            this.tpRolesUser.Size = new System.Drawing.Size(536, 232);
            this.tpRolesUser.Text = "角色用户";
            // 
            // gcRoleUser
            // 
            this.gcRoleUser.DataSource = this.dsMain;
            this.gcRoleUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcRoleUser.Location = new System.Drawing.Point(0, 0);
            this.gcRoleUser.MainView = this.gvRoleUser;
            this.gcRoleUser.Name = "gcRoleUser";
            this.gcRoleUser.Size = new System.Drawing.Size(536, 232);
            this.gcRoleUser.TabIndex = 1;
            this.gcRoleUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRoleUser});
            // 
            // gvRoleUser
            // 
            this.gvRoleUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsRoleUserID,
            this.colsRoleUserCName});
            this.gvRoleUser.GridControl = this.gcRoleUser;
            this.gvRoleUser.Name = "gvRoleUser";
            this.gvRoleUser.OptionsBehavior.Editable = false;
            this.gvRoleUser.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvRoleUser.OptionsView.ColumnAutoWidth = false;
            this.gvRoleUser.OptionsView.ShowFooter = true;
            this.gvRoleUser.OptionsView.ShowGroupPanel = false;
            this.gvRoleUser.OptionsView.ShowIndicator = false;
            // 
            // colsRoleUserID
            // 
            this.colsRoleUserID.Caption = "用户编号";
            this.colsRoleUserID.FieldName = "sRoleUserID";
            this.colsRoleUserID.Name = "colsRoleUserID";
            this.colsRoleUserID.Visible = true;
            this.colsRoleUserID.VisibleIndex = 0;
            this.colsRoleUserID.Width = 80;
            // 
            // colsRoleUserCName
            // 
            this.colsRoleUserCName.Caption = "用户名称";
            this.colsRoleUserCName.FieldName = "sRoleUserCName";
            this.colsRoleUserCName.Name = "colsRoleUserCName";
            this.colsRoleUserCName.Visible = true;
            this.colsRoleUserCName.VisibleIndex = 1;
            this.colsRoleUserCName.Width = 80;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsBehavior.Editable = false;
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowColumnHeaders = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // cmsOperation
            // 
            this.cmsOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNone,
            this.tsmSelf,
            this.tsmUnderling,
            this.tsmSelfAndUnderling,
            this.tsmDepartment,
            this.tsmDeptUnder,
            this.tsmDeptAndDeptUnder,
            this.tsmAll});
            this.cmsOperation.Name = "cmsOperation";
            this.cmsOperation.Size = new System.Drawing.Size(161, 180);
            // 
            // tsmNone
            // 
            this.tsmNone.Name = "tsmNone";
            this.tsmNone.Size = new System.Drawing.Size(160, 22);
            this.tsmNone.Text = "禁用";
            this.tsmNone.Click += new System.EventHandler(this.tsmNone_Click);
            // 
            // tsmSelf
            // 
            this.tsmSelf.Name = "tsmSelf";
            this.tsmSelf.Size = new System.Drawing.Size(160, 22);
            this.tsmSelf.Text = "个人";
            this.tsmSelf.Click += new System.EventHandler(this.tsmNone_Click);
            // 
            // tsmUnderling
            // 
            this.tsmUnderling.Name = "tsmUnderling";
            this.tsmUnderling.Size = new System.Drawing.Size(160, 22);
            this.tsmUnderling.Text = "下属";
            this.tsmUnderling.Click += new System.EventHandler(this.tsmNone_Click);
            // 
            // tsmSelfAndUnderling
            // 
            this.tsmSelfAndUnderling.Name = "tsmSelfAndUnderling";
            this.tsmSelfAndUnderling.Size = new System.Drawing.Size(160, 22);
            this.tsmSelfAndUnderling.Text = "个人及下属";
            this.tsmSelfAndUnderling.Click += new System.EventHandler(this.tsmNone_Click);
            // 
            // tsmDepartment
            // 
            this.tsmDepartment.Name = "tsmDepartment";
            this.tsmDepartment.Size = new System.Drawing.Size(160, 22);
            this.tsmDepartment.Text = "部门";
            this.tsmDepartment.Click += new System.EventHandler(this.tsmNone_Click);
            // 
            // tsmDeptUnder
            // 
            this.tsmDeptUnder.Name = "tsmDeptUnder";
            this.tsmDeptUnder.Size = new System.Drawing.Size(160, 22);
            this.tsmDeptUnder.Text = "部门下属";
            this.tsmDeptUnder.Click += new System.EventHandler(this.tsmNone_Click);
            // 
            // tsmDeptAndDeptUnder
            // 
            this.tsmDeptAndDeptUnder.Name = "tsmDeptAndDeptUnder";
            this.tsmDeptAndDeptUnder.Size = new System.Drawing.Size(160, 22);
            this.tsmDeptAndDeptUnder.Text = "部门及下属部门";
            this.tsmDeptAndDeptUnder.Click += new System.EventHandler(this.tsmNone_Click);
            // 
            // tsmAll
            // 
            this.tsmAll.Name = "tsmAll";
            this.tsmAll.Size = new System.Drawing.Size(160, 22);
            this.tsmAll.Text = "所有";
            this.tsmAll.Click += new System.EventHandler(this.tsmNone_Click);
            // 
            // cmsOperationTrueOrFalse
            // 
            this.cmsOperationTrueOrFalse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmTrue,
            this.tsmFalse});
            this.cmsOperationTrueOrFalse.Name = "cmsOperation";
            this.cmsOperationTrueOrFalse.Size = new System.Drawing.Size(89, 48);
            // 
            // tsmTrue
            // 
            this.tsmTrue.Name = "tsmTrue";
            this.tsmTrue.Size = new System.Drawing.Size(88, 22);
            this.tsmTrue.Text = "是";
            this.tsmTrue.Click += new System.EventHandler(this.tsmTrue_Click);
            // 
            // tsmFalse
            // 
            this.tsmFalse.Name = "tsmFalse";
            this.tsmFalse.Size = new System.Drawing.Size(88, 22);
            this.tsmFalse.Text = "否";
            this.tsmFalse.Click += new System.EventHandler(this.tsmTrue_Click);
            // 
            // cmsRoleRight
            // 
            this.cmsRoleRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDelete});
            this.cmsRoleRight.Name = "cmsRoleRight";
            this.cmsRoleRight.Size = new System.Drawing.Size(125, 26);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(124, 22);
            this.tsmDelete.Text = "删除权限";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(644, 4);
            this.btnEditUser.LookAndFeel.SkinName = "Blue";
            this.btnEditUser.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(91, 24);
            this.btnEditUser.TabIndex = 11;
            this.btnEditUser.Text = "编辑系统用户";
            this.btnEditUser.ToolTip = "编辑系统用户";
            this.btnEditUser.Visible = false;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // frmsysSecurityManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(861, 498);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmsysSecurityManage";
            this.Text = "系统权限设置";
            this.Load += new System.EventHandler(this.frmsysSecurityManage_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetail)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfo)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDataFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtsRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsRoleCName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsRoleNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsRoleEName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetailMenu)).EndInit();
            this.pnlDetailMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcRoleDetail)).EndInit();
            this.tcRoleDetail.ResumeLayout(false);
            this.tpRolesRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvRoleRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxAuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkiAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvMenu)).EndInit();
            this.tpRolesUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRoleUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRoleUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            this.cmsOperation.ResumeLayout(false);
            this.cmsOperationTrueOrFalse.ResumeLayout(false);
            this.cmsRoleRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunrise.ERP.Controls.SunriseGridControl gcRole;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRole;
        private DevExpress.XtraGrid.Columns.GridColumn colsRoleNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsRoleCName;
        private DevExpress.XtraGrid.Columns.GridColumn colsRoleEName;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.MemoEdit txtsRemark;
        private DevExpress.XtraEditors.TextEdit txtsRoleCName;
        private DevExpress.XtraEditors.TextEdit txtsRoleNo;
        private DevExpress.XtraEditors.TextEdit txtsRoleEName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        protected DevExpress.XtraEditors.PanelControl pnlDetailMenu;
        protected DevExpress.XtraEditors.SimpleButton btnDetailDelete;
        protected DevExpress.XtraEditors.SimpleButton btnDetailAdd;
        private DevExpress.XtraTab.XtraTabControl tcRoleDetail;
        private DevExpress.XtraTab.XtraTabPage tpRolesUser;
        private DevExpress.XtraTab.XtraTabPage tpRolesRight;
        private Sunrise.ERP.Controls.SunriseGridControl gcRoleUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRoleUser;
        private DevExpress.XtraGrid.Columns.GridColumn colsRoleUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colsRoleUserCName;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTreeList.TreeList tvMenu;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SplitterControl splitterControl3;
        private DevExpress.XtraTreeList.TreeList tvRoleRight;
        private System.Windows.Forms.ImageList imageList1;
        private Sunrise.ERP.Controls.SunriseLookUp lkpUser;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcolsMenuName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcoliView;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcoliAdd;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcoliEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkiAdd;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcoliDelete;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcoliPrint;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcoliPrice;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcoliNum;
        private System.Windows.Forms.ContextMenuStrip cmsOperation;
        private System.Windows.Forms.ToolStripMenuItem tsmNone;
        private System.Windows.Forms.ToolStripMenuItem tsmSelf;
        private System.Windows.Forms.ToolStripMenuItem tsmUnderling;
        private System.Windows.Forms.ToolStripMenuItem tsmSelfAndUnderling;
        private System.Windows.Forms.ToolStripMenuItem tsmDepartment;
        private System.Windows.Forms.ToolStripMenuItem tsmAll;
        private System.Windows.Forms.ContextMenuStrip cmsOperationTrueOrFalse;
        private System.Windows.Forms.ToolStripMenuItem tsmTrue;
        private System.Windows.Forms.ToolStripMenuItem tsmFalse;
        private System.Windows.Forms.ContextMenuStrip cmsRoleRight;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cbxAuth;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnEditUser;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcoliProperty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcoliOutPut;
        private System.Windows.Forms.ToolStripMenuItem tsmDeptUnder;
        private System.Windows.Forms.ToolStripMenuItem tsmDeptAndDeptUnder;
    }
}
