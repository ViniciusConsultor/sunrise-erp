namespace Sunrise.ERP.Module.SystemBase
{
    partial class frmhrDepartment
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.chkbIsLock = new DevExpress.XtraEditors.CheckEdit();
            this.lkpParentID = new Sunrise.ERP.Controls.SunriseLookUp();
            this.txtsDeptEName = new DevExpress.XtraEditors.TextEdit();
            this.txtsDeptName = new DevExpress.XtraEditors.TextEdit();
            this.txtsDeptNo = new DevExpress.XtraEditors.TextEdit();
            this.lkpiCompanyID = new Sunrise.ERP.Controls.SunriseLookUp();
            this.txtsRemark = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gcMain = new Sunrise.ERP.Controls.SunriseGridControl();
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsCompanyCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsDeptName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsDeptEName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsParentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbIsLock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsDeptNo = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkbIsLock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsDeptEName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsDeptName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsDeptNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.layoutControl1);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gcMain);
            // 
            // panelControl2
            // 
            this.panelControl2.LookAndFeel.SkinName = "Blue";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnInsert
            // 
            this.btnInsert.LookAndFeel.SkinName = "Blue";
            this.btnInsert.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(219, 4);
            this.btnCopy.LookAndFeel.SkinName = "Blue";
            this.btnCopy.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(734, 5);
            this.btnPrint.LookAndFeel.SkinName = "Blue";
            this.btnPrint.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPrint.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(432, 4);
            this.btnClose.LookAndFeel.SkinName = "Blue";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(148, 4);
            this.btnDelete.LookAndFeel.SkinName = "Blue";
            this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(290, 4);
            this.btnCancel.LookAndFeel.SkinName = "Blue";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(361, 4);
            this.btnSave.LookAndFeel.SkinName = "Blue";
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(77, 4);
            this.btnEdit.LookAndFeel.SkinName = "Blue";
            this.btnEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 4);
            this.btnAdd.LookAndFeel.SkinName = "Blue";
            this.btnAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(678, 4);
            this.btnView.LookAndFeel.SkinName = "Blue";
            this.btnView.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnView.Visible = false;
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
            this.btnSettings.LookAndFeel.SkinName = "Blue";
            this.btnSettings.LookAndFeel.UseDefaultLookAndFeel = false;
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
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.chkbIsLock);
            this.layoutControl1.Controls.Add(this.lkpParentID);
            this.layoutControl1.Controls.Add(this.txtsDeptEName);
            this.layoutControl1.Controls.Add(this.txtsDeptName);
            this.layoutControl1.Controls.Add(this.txtsDeptNo);
            this.layoutControl1.Controls.Add(this.lkpiCompanyID);
            this.layoutControl1.Controls.Add(this.txtsRemark);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.LookAndFeel.SkinName = "Blue";
            this.layoutControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(940, 197);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // chkbIsLock
            // 
            this.chkbIsLock.Location = new System.Drawing.Point(8, 105);
            this.chkbIsLock.Name = "chkbIsLock";
            this.chkbIsLock.Properties.Caption = "是否锁定";
            this.chkbIsLock.Size = new System.Drawing.Size(713, 19);
            this.chkbIsLock.StyleController = this.layoutControl1;
            this.chkbIsLock.TabIndex = 14;
            // 
            // lkpParentID
            // 
            this.lkpParentID.DataField = null;
            this.lkpParentID.DisplayField = null;
            this.lkpParentID.EditFormFilter = null;
            this.lkpParentID.EditFormID = 0;
            this.lkpParentID.EditFormName = null;
            this.lkpParentID.EditValue = "";
            this.lkpParentID.FormID = 0;
            this.lkpParentID.GridColumnText = null;
            this.lkpParentID.GridDisplayField = null;
            this.lkpParentID.Location = new System.Drawing.Point(84, 80);
            this.lkpParentID.Name = "lkpParentID";
            this.lkpParentID.SearchFormFilter = "";
            this.lkpParentID.SearchFormText = "";
            this.lkpParentID.Size = new System.Drawing.Size(282, 21);
            this.lkpParentID.SQL = null;
            this.lkpParentID.TabIndex = 12;
            this.lkpParentID.TextFont = new System.Drawing.Font("Tahoma", 9F);
            // 
            // txtsDeptEName
            // 
            this.txtsDeptEName.Location = new System.Drawing.Point(446, 55);
            this.txtsDeptEName.Name = "txtsDeptEName";
            this.txtsDeptEName.Size = new System.Drawing.Size(275, 21);
            this.txtsDeptEName.StyleController = this.layoutControl1;
            this.txtsDeptEName.TabIndex = 11;
            // 
            // txtsDeptName
            // 
            this.txtsDeptName.Location = new System.Drawing.Point(84, 55);
            this.txtsDeptName.Name = "txtsDeptName";
            this.txtsDeptName.Size = new System.Drawing.Size(282, 21);
            this.txtsDeptName.StyleController = this.layoutControl1;
            this.txtsDeptName.TabIndex = 10;
            // 
            // txtsDeptNo
            // 
            this.txtsDeptNo.Location = new System.Drawing.Point(446, 30);
            this.txtsDeptNo.Name = "txtsDeptNo";
            this.txtsDeptNo.Size = new System.Drawing.Size(275, 21);
            this.txtsDeptNo.StyleController = this.layoutControl1;
            this.txtsDeptNo.TabIndex = 9;
            // 
            // lkpiCompanyID
            // 
            this.lkpiCompanyID.DataField = null;
            this.lkpiCompanyID.DisplayField = null;
            this.lkpiCompanyID.EditFormFilter = null;
            this.lkpiCompanyID.EditFormID = 0;
            this.lkpiCompanyID.EditFormName = null;
            this.lkpiCompanyID.EditValue = "";
            this.lkpiCompanyID.FormID = 0;
            this.lkpiCompanyID.GridColumnText = null;
            this.lkpiCompanyID.GridDisplayField = null;
            this.lkpiCompanyID.Location = new System.Drawing.Point(84, 30);
            this.lkpiCompanyID.Name = "lkpiCompanyID";
            this.lkpiCompanyID.SearchFormFilter = "";
            this.lkpiCompanyID.SearchFormText = "";
            this.lkpiCompanyID.Size = new System.Drawing.Size(282, 21);
            this.lkpiCompanyID.SQL = null;
            this.lkpiCompanyID.TabIndex = 8;
            this.lkpiCompanyID.TextFont = new System.Drawing.Font("Tahoma", 9F);
            // 
            // txtsRemark
            // 
            this.txtsRemark.Location = new System.Drawing.Point(84, 128);
            this.txtsRemark.Name = "txtsRemark";
            this.txtsRemark.Size = new System.Drawing.Size(637, 58);
            this.txtsRemark.StyleController = this.layoutControl1;
            this.txtsRemark.TabIndex = 7;
            this.txtsRemark.Tag = "NoTab";
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(940, 197);
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
            this.tabbedControlGroup1.Size = new System.Drawing.Size(936, 193);
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
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem8,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(925, 160);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Text = "用户信息";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtsRemark;
            this.layoutControlItem1.CustomizationFormText = "备注";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 98);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(717, 62);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(717, 62);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(717, 62);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "备注";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lkpiCompanyID;
            this.layoutControlItem2.CustomizationFormText = "登录用户名";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(362, 25);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(362, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(362, 25);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "所属公司";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtsDeptNo;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(362, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(355, 25);
            this.layoutControlItem3.Text = "部门编号";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtsDeptName;
            this.layoutControlItem4.CustomizationFormText = "用户名称";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(362, 25);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(362, 25);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(362, 25);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "部门名称";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtsDeptEName;
            this.layoutControlItem5.CustomizationFormText = "用户英文名";
            this.layoutControlItem5.Location = new System.Drawing.Point(362, 25);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(355, 25);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(355, 25);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(355, 25);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "部门英文名称";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lkpParentID;
            this.layoutControlItem6.CustomizationFormText = "所属上级";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(362, 25);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(362, 25);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(717, 25);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "上级部门";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.chkbIsLock;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 75);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(717, 23);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(717, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(208, 160);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gcMain
            // 
            this.gcMain.DataSource = this.dsMain;
            this.gcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMain.Location = new System.Drawing.Point(2, 2);
            this.gcMain.MainView = this.gvMain;
            this.gcMain.Name = "gcMain";
            this.gcMain.Size = new System.Drawing.Size(940, 250);
            this.gcMain.TabIndex = 2;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsCompanyCName,
            this.colsDeptNo,
            this.colsDeptName,
            this.colsDeptEName,
            this.colsParentName,
            this.colbIsLock,
            this.colsRemark});
            this.gvMain.GridControl = this.gcMain;
            this.gvMain.Name = "gvMain";
            this.gvMain.OptionsBehavior.Editable = false;
            this.gvMain.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvMain.OptionsView.ColumnAutoWidth = false;
            this.gvMain.OptionsView.ShowAutoFilterRow = true;
            this.gvMain.OptionsView.ShowFooter = true;
            this.gvMain.OptionsView.ShowGroupPanel = false;
            // 
            // colsCompanyCName
            // 
            this.colsCompanyCName.Caption = "所属公司";
            this.colsCompanyCName.FieldName = "sCompanyCName";
            this.colsCompanyCName.Name = "colsCompanyCName";
            this.colsCompanyCName.Visible = true;
            this.colsCompanyCName.VisibleIndex = 0;
            this.colsCompanyCName.Width = 159;
            // 
            // colsDeptName
            // 
            this.colsDeptName.Caption = "部门名称";
            this.colsDeptName.FieldName = "sDeptName";
            this.colsDeptName.Name = "colsDeptName";
            this.colsDeptName.Visible = true;
            this.colsDeptName.VisibleIndex = 2;
            this.colsDeptName.Width = 138;
            // 
            // colsDeptEName
            // 
            this.colsDeptEName.Caption = "部门英文名称";
            this.colsDeptEName.FieldName = "sDeptEName";
            this.colsDeptEName.Name = "colsDeptEName";
            this.colsDeptEName.Visible = true;
            this.colsDeptEName.VisibleIndex = 3;
            this.colsDeptEName.Width = 153;
            // 
            // colsParentName
            // 
            this.colsParentName.Caption = "上级部门";
            this.colsParentName.FieldName = "sParentCName";
            this.colsParentName.Name = "colsParentName";
            this.colsParentName.Visible = true;
            this.colsParentName.VisibleIndex = 4;
            this.colsParentName.Width = 122;
            // 
            // colbIsLock
            // 
            this.colbIsLock.Caption = "是否锁定";
            this.colbIsLock.FieldName = "bIsLock";
            this.colbIsLock.Name = "colbIsLock";
            this.colbIsLock.Visible = true;
            this.colbIsLock.VisibleIndex = 5;
            // 
            // colsRemark
            // 
            this.colsRemark.Caption = "备注";
            this.colsRemark.FieldName = "sRemark";
            this.colsRemark.Name = "colsRemark";
            this.colsRemark.Visible = true;
            this.colsRemark.VisibleIndex = 6;
            this.colsRemark.Width = 199;
            // 
            // colsDeptNo
            // 
            this.colsDeptNo.Caption = "部门编号";
            this.colsDeptNo.FieldName = "sDeptNo";
            this.colsDeptNo.Name = "colsDeptNo";
            this.colsDeptNo.Visible = true;
            this.colsDeptNo.VisibleIndex = 1;
            this.colsDeptNo.Width = 103;
            // 
            // frmhrDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(948, 498);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmhrDepartment";
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkbIsLock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsDeptEName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsDeptName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsDeptNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.CheckEdit chkbIsLock;
        private Sunrise.ERP.Controls.SunriseLookUp lkpParentID;
        private DevExpress.XtraEditors.TextEdit txtsDeptEName;
        private DevExpress.XtraEditors.TextEdit txtsDeptName;
        private DevExpress.XtraEditors.TextEdit txtsDeptNo;
        private Sunrise.ERP.Controls.SunriseLookUp lkpiCompanyID;
        private DevExpress.XtraEditors.MemoEdit txtsRemark;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Sunrise.ERP.Controls.SunriseGridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMain;
        private DevExpress.XtraGrid.Columns.GridColumn colsDeptName;
        private DevExpress.XtraGrid.Columns.GridColumn colsDeptEName;
        private DevExpress.XtraGrid.Columns.GridColumn colsParentName;
        private DevExpress.XtraGrid.Columns.GridColumn colbIsLock;
        private DevExpress.XtraGrid.Columns.GridColumn colsRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colsCompanyCName;
        private DevExpress.XtraGrid.Columns.GridColumn colsDeptNo;
    }
}
