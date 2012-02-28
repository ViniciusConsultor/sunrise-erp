namespace Sunrise.ERP.Module.SystemManage
{
    partial class frmsysQueryReport
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
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            this.grbFilter = new DevExpress.XtraEditors.GroupControl();
            this.grbGroup = new DevExpress.XtraEditors.GroupControl();
            this.btnSet = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.tbDetail = new DevExpress.XtraTab.XtraTabControl();
            this.tpDetail = new DevExpress.XtraTab.XtraTabPage();
            this.gcSearch = new Sunrise.ERP.Controls.SunriseGridControl();
            this.gvSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpChart = new DevExpress.XtraTab.XtraTabPage();
            this.chtMain = new DevExpress.XtraCharts.ChartControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cbxValueType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cbxField = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cbxChartType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbltype = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbFilter)).BeginInit();
            this.grbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDetail)).BeginInit();
            this.tbDetail.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).BeginInit();
            this.tpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxValueType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxChartType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tbDetail);
            this.panelControl1.Controls.Add(this.splitterControl1);
            this.panelControl1.Controls.Add(this.grbFilter);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Size = new System.Drawing.Size(879, 498);
            // 
            // grbFilter
            // 
            this.grbFilter.Controls.Add(this.grbGroup);
            this.grbFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbFilter.Location = new System.Drawing.Point(2, 35);
            this.grbFilter.Name = "grbFilter";
            this.grbFilter.Size = new System.Drawing.Size(875, 143);
            this.grbFilter.TabIndex = 0;
            this.grbFilter.Text = "查询条件";
            // 
            // grbGroup
            // 
            this.grbGroup.Location = new System.Drawing.Point(10, 97);
            this.grbGroup.Name = "grbGroup";
            this.grbGroup.Size = new System.Drawing.Size(200, 34);
            this.grbGroup.TabIndex = 0;
            this.grbGroup.Text = "分组字段";
            // 
            // btnSet
            // 
            this.btnSet.Image = global::Sunrise.ERP.Module.SystemManage.Properties.Resources.insert;
            this.btnSet.Location = new System.Drawing.Point(218, 5);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(70, 24);
            this.btnSet.TabIndex = 5;
            this.btnSet.Text = "执行(&R)";
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::Sunrise.ERP.Module.SystemManage.Properties.Resources.print;
            this.btnPrint.Location = new System.Drawing.Point(147, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(70, 24);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Sunrise.ERP.Module.SystemManage.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(289, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 24);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭(&X)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = global::Sunrise.ERP.Module.SystemManage.Properties.Resources.cancel;
            this.btnClear.Location = new System.Drawing.Point(76, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 24);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "清除(&C)";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnView
            // 
            this.btnView.Image = global::Sunrise.ERP.Module.SystemManage.Properties.Resources.view;
            this.btnView.Location = new System.Drawing.Point(5, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(70, 24);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "过滤(&V)";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(2, 178);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(875, 6);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // tbDetail
            // 
            this.tbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDetail.Location = new System.Drawing.Point(2, 184);
            this.tbDetail.Name = "tbDetail";
            this.tbDetail.SelectedTabPage = this.tpDetail;
            this.tbDetail.Size = new System.Drawing.Size(875, 312);
            this.tbDetail.TabIndex = 2;
            this.tbDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpDetail,
            this.tpChart});
            this.tbDetail.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tbDetail_SelectedPageChanged);
            // 
            // tpDetail
            // 
            this.tpDetail.Controls.Add(this.gcSearch);
            this.tpDetail.Name = "tpDetail";
            this.tpDetail.Size = new System.Drawing.Size(868, 283);
            this.tpDetail.Text = "明细";
            // 
            // gcSearch
            // 
            this.gcSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSearch.Location = new System.Drawing.Point(0, 0);
            this.gcSearch.MainView = this.gvSearch;
            this.gcSearch.Name = "gcSearch";
            this.gcSearch.Size = new System.Drawing.Size(868, 283);
            this.gcSearch.TabIndex = 5;
            this.gcSearch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSearch});
            // 
            // gvSearch
            // 
            this.gvSearch.GridControl = this.gcSearch;
            this.gvSearch.Name = "gvSearch";
            this.gvSearch.OptionsBehavior.Editable = false;
            this.gvSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvSearch.OptionsView.ColumnAutoWidth = false;
            this.gvSearch.OptionsView.ShowFooter = true;
            this.gvSearch.OptionsView.ShowGroupPanel = false;
            this.gvSearch.DoubleClick += new System.EventHandler(this.gvSearch_DoubleClick);
            // 
            // tpChart
            // 
            this.tpChart.Controls.Add(this.chtMain);
            this.tpChart.Controls.Add(this.panelControl2);
            this.tpChart.Name = "tpChart";
            this.tpChart.Size = new System.Drawing.Size(746, 283);
            this.tpChart.Text = "图表";
            // 
            // chtMain
            // 
            this.chtMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtMain.Location = new System.Drawing.Point(104, 0);
            this.chtMain.Name = "chtMain";
            this.chtMain.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            sideBySideBarSeriesLabel1.LineVisible = true;
            this.chtMain.SeriesTemplate.Label = sideBySideBarSeriesLabel1;
            this.chtMain.Size = new System.Drawing.Size(642, 283);
            this.chtMain.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.cbxValueType);
            this.panelControl2.Controls.Add(this.cbxField);
            this.panelControl2.Controls.Add(this.cbxChartType);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.lbltype);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(104, 283);
            this.panelControl2.TabIndex = 0;
            // 
            // cbxValueType
            // 
            this.cbxValueType.EditValue = "柱图";
            this.cbxValueType.Location = new System.Drawing.Point(8, 135);
            this.cbxValueType.Name = "cbxValueType";
            this.cbxValueType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxValueType.Size = new System.Drawing.Size(73, 21);
            this.cbxValueType.TabIndex = 8;
            this.cbxValueType.SelectedIndexChanged += new System.EventHandler(this.cbxChartType_SelectedIndexChanged);
            // 
            // cbxField
            // 
            this.cbxField.EditValue = "柱图";
            this.cbxField.Location = new System.Drawing.Point(8, 82);
            this.cbxField.Name = "cbxField";
            this.cbxField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxField.Size = new System.Drawing.Size(73, 21);
            this.cbxField.TabIndex = 7;
            this.cbxField.SelectedIndexChanged += new System.EventHandler(this.cbxChartType_SelectedIndexChanged);
            // 
            // cbxChartType
            // 
            this.cbxChartType.EditValue = "柱图";
            this.cbxChartType.Location = new System.Drawing.Point(8, 27);
            this.cbxChartType.Name = "cbxChartType";
            this.cbxChartType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxChartType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("柱图", "柱图", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("饼图", "饼图", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("线图", "线图", -1)});
            this.cbxChartType.Size = new System.Drawing.Size(73, 21);
            this.cbxChartType.TabIndex = 6;
            this.cbxChartType.SelectedIndexChanged += new System.EventHandler(this.cbxChartType_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 115);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "比较值：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 62);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "比较字段：";
            // 
            // lbltype
            // 
            this.lbltype.Location = new System.Drawing.Point(8, 7);
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(60, 14);
            this.lbltype.TabIndex = 1;
            this.lbltype.Text = "图表类型：";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnEdit);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Controls.Add(this.btnClose);
            this.panelControl3.Controls.Add(this.btnSet);
            this.panelControl3.Controls.Add(this.btnView);
            this.panelControl3.Controls.Add(this.btnPrint);
            this.panelControl3.Controls.Add(this.btnClear);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(875, 33);
            this.panelControl3.TabIndex = 3;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Sunrise.ERP.Module.SystemManage.Properties.Resources.edit;
            this.btnEdit.Location = new System.Drawing.Point(596, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(70, 24);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "修改(&E)";
            this.btnEdit.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Sunrise.ERP.Module.SystemManage.Properties.Resources.add;
            this.btnAdd.Location = new System.Drawing.Point(525, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 24);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "新增(&A)";
            this.btnAdd.Visible = false;
            // 
            // frmsysQueryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(879, 498);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmsysQueryReport";
            this.Load += new System.EventHandler(this.frmsysQueryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbFilter)).EndInit();
            this.grbFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDetail)).EndInit();
            this.tbDetail.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).EndInit();
            this.tpChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxValueType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxChartType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grbFilter;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraTab.XtraTabControl tbDetail;
        private DevExpress.XtraTab.XtraTabPage tpDetail;
        private DevExpress.XtraTab.XtraTabPage tpChart;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraCharts.ChartControl chtMain;
        private Sunrise.ERP.Controls.SunriseGridControl gcSearch;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSearch;
        private DevExpress.XtraEditors.GroupControl grbGroup;
        private DevExpress.XtraEditors.LabelControl lbltype;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbxChartType;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbxValueType;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbxField;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.SimpleButton btnSet;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;

    }
}
