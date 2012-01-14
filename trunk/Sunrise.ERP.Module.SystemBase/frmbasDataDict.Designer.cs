namespace Sunrise.ERP.Module.SystemBase
{
    partial class frmbasDataDict
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
            this.txtsRemark = new DevExpress.XtraEditors.MemoEdit();
            this.txtsDictCategoryNo = new DevExpress.XtraEditors.TextEdit();
            this.txtsDictCategoryCName = new DevExpress.XtraEditors.TextEdit();
            this.txtsDictCategoryEName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcMain = new Sunrise.ERP.Controls.BoyeeGridControl();
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsDictCategoryNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsDictCategoryCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsDictCategoryEName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlDetailMenu = new DevExpress.XtraEditors.PanelControl();
            this.btnDetailCopy = new DevExpress.XtraEditors.SimpleButton();
            this.btnDetailCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnDetailDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnDetailAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gcDetail = new Sunrise.ERP.Controls.BoyeeGridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsDictDataNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsDictDataCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsDictDataEName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbIsStop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsRemark = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtsRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsDictCategoryNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsDictCategoryCName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsDictCategoryEName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetailMenu)).BeginInit();
            this.pnlDetailMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.gcDetail);
            this.pnlDetail.Controls.Add(this.pnlDetailMenu);
            this.pnlDetail.Location = new System.Drawing.Point(212, 235);
            this.pnlDetail.Size = new System.Drawing.Size(543, 261);
            // 
            // splitterControl2
            // 
            this.splitterControl2.Location = new System.Drawing.Point(206, 35);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.layoutControl1);
            this.pnlInfo.Location = new System.Drawing.Point(212, 35);
            this.pnlInfo.Size = new System.Drawing.Size(543, 194);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gcMain);
            this.pnlGrid.Size = new System.Drawing.Size(204, 461);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(212, 229);
            this.splitterControl1.Size = new System.Drawing.Size(543, 6);
            // 
            // panelControl2
            // 
            this.panelControl2.LookAndFeel.SkinName = "Blue";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Size = new System.Drawing.Size(753, 33);
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
            this.btnPrint.Location = new System.Drawing.Point(604, 5);
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
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
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
            this.panelControl1.Size = new System.Drawing.Size(757, 498);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtsRemark);
            this.layoutControl1.Controls.Add(this.txtsDictCategoryNo);
            this.layoutControl1.Controls.Add(this.txtsDictCategoryCName);
            this.layoutControl1.Controls.Add(this.txtsDictCategoryEName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.LookAndFeel.SkinName = "Blue";
            this.layoutControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(539, 190);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtsRemark
            // 
            this.txtsRemark.Location = new System.Drawing.Point(61, 106);
            this.txtsRemark.Name = "txtsRemark";
            this.txtsRemark.Size = new System.Drawing.Size(469, 75);
            this.txtsRemark.StyleController = this.layoutControl1;
            this.txtsRemark.TabIndex = 7;
            this.txtsRemark.Tag = "NoTab";
            // 
            // txtsDictCategoryNo
            // 
            this.txtsDictCategoryNo.Location = new System.Drawing.Point(61, 31);
            this.txtsDictCategoryNo.Name = "txtsDictCategoryNo";
            this.txtsDictCategoryNo.Size = new System.Drawing.Size(469, 21);
            this.txtsDictCategoryNo.StyleController = this.layoutControl1;
            this.txtsDictCategoryNo.TabIndex = 6;
            // 
            // txtsDictCategoryCName
            // 
            this.txtsDictCategoryCName.Location = new System.Drawing.Point(61, 56);
            this.txtsDictCategoryCName.Name = "txtsDictCategoryCName";
            this.txtsDictCategoryCName.Size = new System.Drawing.Size(469, 21);
            this.txtsDictCategoryCName.StyleController = this.layoutControl1;
            this.txtsDictCategoryCName.TabIndex = 5;
            // 
            // txtsDictCategoryEName
            // 
            this.txtsDictCategoryEName.Location = new System.Drawing.Point(61, 81);
            this.txtsDictCategoryEName.Name = "txtsDictCategoryEName";
            this.txtsDictCategoryEName.Size = new System.Drawing.Size(469, 21);
            this.txtsDictCategoryEName.StyleController = this.layoutControl1;
            this.txtsDictCategoryEName.TabIndex = 4;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(539, 190);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.CustomizationFormText = "tabbedControlGroup1";
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup2;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(535, 186);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.tabbedControlGroup1.Text = "tabbedControlGroup1";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "分类信息";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(525, 154);
            this.layoutControlGroup2.Text = "分类信息";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtsDictCategoryNo;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(525, 25);
            this.layoutControlItem3.Text = "分类编号";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtsDictCategoryCName;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(525, 25);
            this.layoutControlItem2.Text = "中文名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtsDictCategoryEName;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(525, 25);
            this.layoutControlItem1.Text = "英文名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtsRemark;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 75);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(525, 79);
            this.layoutControlItem4.Text = "备注";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // gcMain
            // 
            this.gcMain.DataSource = this.dsMain;
            this.gcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMain.Location = new System.Drawing.Point(2, 2);
            this.gcMain.MainView = this.gvMain;
            this.gcMain.Name = "gcMain";
            this.gcMain.Size = new System.Drawing.Size(200, 457);
            this.gcMain.TabIndex = 0;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsDictCategoryNo,
            this.colsDictCategoryCName,
            this.colsDictCategoryEName});
            this.gvMain.GridControl = this.gcMain;
            this.gvMain.Name = "gvMain";
            this.gvMain.OptionsBehavior.Editable = false;
            this.gvMain.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvMain.OptionsView.ColumnAutoWidth = false;
            this.gvMain.OptionsView.ShowAutoFilterRow = true;
            this.gvMain.OptionsView.ShowFooter = true;
            // 
            // colsDictCategoryNo
            // 
            this.colsDictCategoryNo.Caption = "分类编号";
            this.colsDictCategoryNo.FieldName = "sDictCategoryNo";
            this.colsDictCategoryNo.Name = "colsDictCategoryNo";
            this.colsDictCategoryNo.Visible = true;
            this.colsDictCategoryNo.VisibleIndex = 0;
            this.colsDictCategoryNo.Width = 80;
            // 
            // colsDictCategoryCName
            // 
            this.colsDictCategoryCName.Caption = "中文名称";
            this.colsDictCategoryCName.FieldName = "sDictCategoryCName";
            this.colsDictCategoryCName.Name = "colsDictCategoryCName";
            this.colsDictCategoryCName.Visible = true;
            this.colsDictCategoryCName.VisibleIndex = 1;
            this.colsDictCategoryCName.Width = 80;
            // 
            // colsDictCategoryEName
            // 
            this.colsDictCategoryEName.Caption = "英文名称";
            this.colsDictCategoryEName.FieldName = "sDictCategoryEName";
            this.colsDictCategoryEName.Name = "colsDictCategoryEName";
            this.colsDictCategoryEName.Visible = true;
            this.colsDictCategoryEName.VisibleIndex = 2;
            this.colsDictCategoryEName.Width = 80;
            // 
            // pnlDetailMenu
            // 
            this.pnlDetailMenu.Controls.Add(this.btnDetailCopy);
            this.pnlDetailMenu.Controls.Add(this.btnDetailCancel);
            this.pnlDetailMenu.Controls.Add(this.btnDetailDelete);
            this.pnlDetailMenu.Controls.Add(this.btnDetailAdd);
            this.pnlDetailMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailMenu.Location = new System.Drawing.Point(2, 2);
            this.pnlDetailMenu.LookAndFeel.SkinName = "Blue";
            this.pnlDetailMenu.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlDetailMenu.Name = "pnlDetailMenu";
            this.pnlDetailMenu.Size = new System.Drawing.Size(539, 33);
            this.pnlDetailMenu.TabIndex = 2;
            // 
            // btnDetailCopy
            // 
            this.btnDetailCopy.Image = global::Sunrise.ERP.Module.SystemBase.Properties.Resources.copy;
            this.btnDetailCopy.Location = new System.Drawing.Point(80, 4);
            this.btnDetailCopy.LookAndFeel.SkinName = "Blue";
            this.btnDetailCopy.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDetailCopy.Name = "btnDetailCopy";
            this.btnDetailCopy.Size = new System.Drawing.Size(24, 24);
            this.btnDetailCopy.TabIndex = 3;
            this.btnDetailCopy.ToolTip = "删除";
            // 
            // btnDetailCancel
            // 
            this.btnDetailCancel.Image = global::Sunrise.ERP.Module.SystemBase.Properties.Resources.cancel;
            this.btnDetailCancel.Location = new System.Drawing.Point(55, 4);
            this.btnDetailCancel.LookAndFeel.SkinName = "Blue";
            this.btnDetailCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDetailCancel.Name = "btnDetailCancel";
            this.btnDetailCancel.Size = new System.Drawing.Size(24, 24);
            this.btnDetailCancel.TabIndex = 2;
            this.btnDetailCancel.ToolTip = "修改";
            // 
            // btnDetailDelete
            // 
            this.btnDetailDelete.Image = global::Sunrise.ERP.Module.SystemBase.Properties.Resources.delete;
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
            this.btnDetailAdd.Image = global::Sunrise.ERP.Module.SystemBase.Properties.Resources.add;
            this.btnDetailAdd.Location = new System.Drawing.Point(5, 4);
            this.btnDetailAdd.LookAndFeel.SkinName = "Blue";
            this.btnDetailAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDetailAdd.Name = "btnDetailAdd";
            this.btnDetailAdd.Size = new System.Drawing.Size(24, 24);
            this.btnDetailAdd.TabIndex = 0;
            this.btnDetailAdd.ToolTip = "查询";
            this.btnDetailAdd.Click += new System.EventHandler(this.btnDetailAdd_Click);
            // 
            // gcDetail
            // 
            this.gcDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetail.Location = new System.Drawing.Point(2, 35);
            this.gcDetail.MainView = this.gvDetail;
            this.gcDetail.Name = "gcDetail";
            this.gcDetail.Size = new System.Drawing.Size(539, 224);
            this.gcDetail.TabIndex = 3;
            this.gcDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // gvDetail
            // 
            this.gvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsDictDataNo,
            this.colsDictDataCName,
            this.colsDictDataEName,
            this.colbIsStop,
            this.colsRemark});
            this.gvDetail.GridControl = this.gcDetail;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvDetail.OptionsView.ColumnAutoWidth = false;
            this.gvDetail.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvDetail_InitNewRow);
            // 
            // colsDictDataNo
            // 
            this.colsDictDataNo.Caption = "数据编号";
            this.colsDictDataNo.FieldName = "sDictDataNo";
            this.colsDictDataNo.Name = "colsDictDataNo";
            this.colsDictDataNo.Visible = true;
            this.colsDictDataNo.VisibleIndex = 0;
            this.colsDictDataNo.Width = 80;
            // 
            // colsDictDataCName
            // 
            this.colsDictDataCName.Caption = "中文名称";
            this.colsDictDataCName.FieldName = "sDictDataCName";
            this.colsDictDataCName.Name = "colsDictDataCName";
            this.colsDictDataCName.Visible = true;
            this.colsDictDataCName.VisibleIndex = 1;
            this.colsDictDataCName.Width = 80;
            // 
            // colsDictDataEName
            // 
            this.colsDictDataEName.Caption = "英文名称";
            this.colsDictDataEName.FieldName = "sDictDataEName";
            this.colsDictDataEName.Name = "colsDictDataEName";
            this.colsDictDataEName.Visible = true;
            this.colsDictDataEName.VisibleIndex = 2;
            this.colsDictDataEName.Width = 80;
            // 
            // colbIsStop
            // 
            this.colbIsStop.Caption = "是否停用";
            this.colbIsStop.FieldName = "bIsStop";
            this.colbIsStop.Name = "colbIsStop";
            this.colbIsStop.Visible = true;
            this.colbIsStop.VisibleIndex = 3;
            this.colbIsStop.Width = 80;
            // 
            // colsRemark
            // 
            this.colsRemark.Caption = "备注";
            this.colsRemark.FieldName = "sRemark";
            this.colsRemark.Name = "colsRemark";
            this.colsRemark.Visible = true;
            this.colsRemark.VisibleIndex = 4;
            this.colsRemark.Width = 80;
            // 
            // frmbasDataDict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(757, 498);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmbasDataDict";
            this.Text = "基础数据字典";
            this.Load += new System.EventHandler(this.frmbasDictData_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtsRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsDictCategoryNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsDictCategoryCName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsDictCategoryEName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetailMenu)).EndInit();
            this.pnlDetailMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private Sunrise.ERP.Controls.BoyeeGridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMain;
        protected DevExpress.XtraEditors.PanelControl pnlDetailMenu;
        protected DevExpress.XtraEditors.SimpleButton btnDetailCopy;
        protected DevExpress.XtraEditors.SimpleButton btnDetailCancel;
        protected DevExpress.XtraEditors.SimpleButton btnDetailDelete;
        protected DevExpress.XtraEditors.SimpleButton btnDetailAdd;
        private Sunrise.ERP.Controls.BoyeeGridControl gcDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colsDictCategoryNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsDictCategoryCName;
        private DevExpress.XtraGrid.Columns.GridColumn colsDictCategoryEName;
        private DevExpress.XtraEditors.MemoEdit txtsRemark;
        private DevExpress.XtraEditors.TextEdit txtsDictCategoryNo;
        private DevExpress.XtraEditors.TextEdit txtsDictCategoryCName;
        private DevExpress.XtraEditors.TextEdit txtsDictCategoryEName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colsDictDataNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsDictDataCName;
        private DevExpress.XtraGrid.Columns.GridColumn colsDictDataEName;
        private DevExpress.XtraGrid.Columns.GridColumn colbIsStop;
        private DevExpress.XtraGrid.Columns.GridColumn colsRemark;
    }
}
