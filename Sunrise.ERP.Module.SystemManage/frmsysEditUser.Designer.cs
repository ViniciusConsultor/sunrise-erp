namespace Sunrise.ERP.Module.SystemManage
{
    partial class frmsysEditUser
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
            this.cbxUserType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lkpParantID = new Sunrise.ERP.Controls.SunriseLookUp();
            this.txtsUserEName = new DevExpress.XtraEditors.TextEdit();
            this.txtsUserCName = new DevExpress.XtraEditors.TextEdit();
            this.txtsPassword = new DevExpress.XtraEditors.TextEdit();
            this.lkpsUserID = new Sunrise.ERP.Controls.SunriseLookUp();
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
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gcMain = new Sunrise.ERP.Controls.SunriseGridControl();
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsUserCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsUserEName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsParentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsUserTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbIsLock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsRemark = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.cbxUserType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsUserEName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsUserCName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsPassword.Properties)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
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
            this.btnCopy.LookAndFeel.SkinName = "Blue";
            this.btnCopy.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(653, 3);
            this.btnPrint.LookAndFeel.SkinName = "Blue";
            this.btnPrint.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPrint.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(502, 4);
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
            this.btnSettings.LookAndFeel.SkinName = "Blue";
            this.btnSettings.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // panelControl1
            // 
            this.panelControl1.LookAndFeel.SkinName = "Blue";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.chkbIsLock);
            this.layoutControl1.Controls.Add(this.cbxUserType);
            this.layoutControl1.Controls.Add(this.lkpParantID);
            this.layoutControl1.Controls.Add(this.txtsUserEName);
            this.layoutControl1.Controls.Add(this.txtsUserCName);
            this.layoutControl1.Controls.Add(this.txtsPassword);
            this.layoutControl1.Controls.Add(this.lkpsUserID);
            this.layoutControl1.Controls.Add(this.txtsRemark);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.LookAndFeel.SkinName = "Blue";
            this.layoutControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(749, 197);
            this.layoutControl1.TabIndex = 1;
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
            // cbxUserType
            // 
            this.cbxUserType.Location = new System.Drawing.Point(434, 80);
            this.cbxUserType.Name = "cbxUserType";
            this.cbxUserType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxUserType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("一般用户", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("超级用户", 1, -1)});
            this.cbxUserType.Size = new System.Drawing.Size(287, 21);
            this.cbxUserType.StyleController = this.layoutControl1;
            this.cbxUserType.TabIndex = 13;
            // 
            // lkpParantID
            // 
            this.lkpParantID.DataField = null;
            this.lkpParantID.DisplayField = null;
            this.lkpParantID.EditFormFilter = null;
            this.lkpParantID.EditFormID = 0;
            this.lkpParantID.EditFormName = null;
            this.lkpParantID.EditValue = "";
            this.lkpParantID.GridColumnText = null;
            this.lkpParantID.GridDisplayField = null;
            this.lkpParantID.Location = new System.Drawing.Point(72, 80);
            this.lkpParantID.Name = "lkpParantID";
            this.lkpParantID.SearchFormFilter = "";
            this.lkpParantID.SearchFormText = "";
            this.lkpParantID.Size = new System.Drawing.Size(294, 21);
            this.lkpParantID.SQL = null;
            this.lkpParantID.TabIndex = 12;
            this.lkpParantID.TextFont = new System.Drawing.Font("Tahoma", 9F);
            // 
            // txtsUserEName
            // 
            this.txtsUserEName.Location = new System.Drawing.Point(434, 55);
            this.txtsUserEName.Name = "txtsUserEName";
            this.txtsUserEName.Size = new System.Drawing.Size(287, 21);
            this.txtsUserEName.StyleController = this.layoutControl1;
            this.txtsUserEName.TabIndex = 11;
            // 
            // txtsUserCName
            // 
            this.txtsUserCName.Location = new System.Drawing.Point(72, 55);
            this.txtsUserCName.Name = "txtsUserCName";
            this.txtsUserCName.Size = new System.Drawing.Size(294, 21);
            this.txtsUserCName.StyleController = this.layoutControl1;
            this.txtsUserCName.TabIndex = 10;
            // 
            // txtsPassword
            // 
            this.txtsPassword.Location = new System.Drawing.Point(434, 30);
            this.txtsPassword.Name = "txtsPassword";
            this.txtsPassword.Properties.PasswordChar = '*';
            this.txtsPassword.Size = new System.Drawing.Size(287, 21);
            this.txtsPassword.StyleController = this.layoutControl1;
            this.txtsPassword.TabIndex = 9;
            this.txtsPassword.TextChanged += new System.EventHandler(this.txtsPassword_TextChanged);
            // 
            // lkpsUserID
            // 
            this.lkpsUserID.DataField = null;
            this.lkpsUserID.DisplayField = null;
            this.lkpsUserID.EditFormFilter = null;
            this.lkpsUserID.EditFormID = 0;
            this.lkpsUserID.EditFormName = null;
            this.lkpsUserID.EditValue = "";
            this.lkpsUserID.GridColumnText = null;
            this.lkpsUserID.GridDisplayField = null;
            this.lkpsUserID.Location = new System.Drawing.Point(72, 30);
            this.lkpsUserID.Name = "lkpsUserID";
            this.lkpsUserID.SearchFormFilter = "";
            this.lkpsUserID.SearchFormText = "";
            this.lkpsUserID.Size = new System.Drawing.Size(294, 21);
            this.lkpsUserID.SQL = null;
            this.lkpsUserID.TabIndex = 8;
            this.lkpsUserID.TextFont = new System.Drawing.Font("Tahoma", 9F);
            // 
            // txtsRemark
            // 
            this.txtsRemark.Location = new System.Drawing.Point(72, 128);
            this.txtsRemark.Name = "txtsRemark";
            this.txtsRemark.Size = new System.Drawing.Size(649, 58);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(749, 197);
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
            this.tabbedControlGroup1.Size = new System.Drawing.Size(745, 193);
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
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(734, 160);
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
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lkpsUserID;
            this.layoutControlItem2.CustomizationFormText = "登录用户名";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(362, 25);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(362, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(362, 25);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "登录用户名";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtsPassword;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(362, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(355, 25);
            this.layoutControlItem3.Text = "登录密码";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtsUserCName;
            this.layoutControlItem4.CustomizationFormText = "用户名称";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(362, 25);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(362, 25);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(362, 25);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "用户名称";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtsUserEName;
            this.layoutControlItem5.CustomizationFormText = "用户英文名";
            this.layoutControlItem5.Location = new System.Drawing.Point(362, 25);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(355, 25);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(355, 25);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(355, 25);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "用户英文名";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lkpParantID;
            this.layoutControlItem6.CustomizationFormText = "所属上级";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(362, 25);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(362, 25);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(362, 25);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "所属上级";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.cbxUserType;
            this.layoutControlItem7.CustomizationFormText = "用户类型";
            this.layoutControlItem7.Location = new System.Drawing.Point(362, 50);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(355, 25);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(355, 25);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(355, 25);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "用户类型";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(60, 14);
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
            this.emptySpaceItem1.Size = new System.Drawing.Size(17, 160);
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
            this.gcMain.Size = new System.Drawing.Size(749, 250);
            this.gcMain.TabIndex = 1;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsUserID,
            this.colsUserCName,
            this.colsUserEName,
            this.colsParentName,
            this.colsUserTypeName,
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
            this.gvMain.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvMain_CustomDrawCell);
            // 
            // colsUserID
            // 
            this.colsUserID.Caption = "登录用户名";
            this.colsUserID.FieldName = "sUserID";
            this.colsUserID.Name = "colsUserID";
            this.colsUserID.Visible = true;
            this.colsUserID.VisibleIndex = 0;
            this.colsUserID.Width = 89;
            // 
            // colsUserCName
            // 
            this.colsUserCName.Caption = "用户名称";
            this.colsUserCName.FieldName = "sUserCName";
            this.colsUserCName.Name = "colsUserCName";
            this.colsUserCName.Visible = true;
            this.colsUserCName.VisibleIndex = 1;
            // 
            // colsUserEName
            // 
            this.colsUserEName.Caption = "用户英文名";
            this.colsUserEName.FieldName = "sUserEName";
            this.colsUserEName.Name = "colsUserEName";
            this.colsUserEName.Visible = true;
            this.colsUserEName.VisibleIndex = 2;
            this.colsUserEName.Width = 110;
            // 
            // colsParentName
            // 
            this.colsParentName.Caption = "所属上级";
            this.colsParentName.FieldName = "sParentCName";
            this.colsParentName.Name = "colsParentName";
            this.colsParentName.Visible = true;
            this.colsParentName.VisibleIndex = 3;
            // 
            // colsUserTypeName
            // 
            this.colsUserTypeName.Caption = "用户类型";
            this.colsUserTypeName.FieldName = "sUserTypeName";
            this.colsUserTypeName.Name = "colsUserTypeName";
            this.colsUserTypeName.Visible = true;
            this.colsUserTypeName.VisibleIndex = 4;
            this.colsUserTypeName.Width = 100;
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
            this.colsRemark.Width = 126;
            // 
            // frmsysEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(757, 498);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmsysEditUser";
            this.Text = "编辑系统用户";
            this.Load += new System.EventHandler(this.frmsysEditUser_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.cbxUserType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsUserEName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsUserCName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsPassword.Properties)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtsPassword;
        private Sunrise.ERP.Controls.SunriseLookUp lkpsUserID;
        private DevExpress.XtraEditors.MemoEdit txtsRemark;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.CheckEdit chkbIsLock;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbxUserType;
        private Sunrise.ERP.Controls.SunriseLookUp lkpParantID;
        private DevExpress.XtraEditors.TextEdit txtsUserEName;
        private DevExpress.XtraEditors.TextEdit txtsUserCName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private Sunrise.ERP.Controls.SunriseGridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMain;
        private DevExpress.XtraGrid.Columns.GridColumn colsUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colsUserCName;
        private DevExpress.XtraGrid.Columns.GridColumn colsUserEName;
        private DevExpress.XtraGrid.Columns.GridColumn colsParentName;
        private DevExpress.XtraGrid.Columns.GridColumn colsUserTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colbIsLock;
        private DevExpress.XtraGrid.Columns.GridColumn colsRemark;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
