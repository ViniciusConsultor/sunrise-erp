namespace Sunrise.ERP.BaseForm
{
    partial class frmCommSelectForm
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
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.grbFilter = new DevExpress.XtraEditors.GroupControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.gcSearch = new Sunrise.ERP.Controls.SunriseGridControl();
            this.gvSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdvView = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gcSearch);
            this.panelControl1.Controls.Add(this.splitterControl1);
            this.panelControl1.Controls.Add(this.grbFilter);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Size = new System.Drawing.Size(686, 447);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnAdvView);
            this.panelControl3.Controls.Add(this.btnView);
            this.panelControl3.Controls.Add(this.btnClear);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(682, 33);
            this.panelControl3.TabIndex = 4;
            // 
            // btnView
            // 
            this.btnView.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.view;
            this.btnView.Location = new System.Drawing.Point(5, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(70, 24);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "过滤(&V)";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.clear;
            this.btnClear.Location = new System.Drawing.Point(147, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 24);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "清除(&L)";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grbFilter
            // 
            this.grbFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbFilter.Location = new System.Drawing.Point(2, 35);
            this.grbFilter.Name = "grbFilter";
            this.grbFilter.Size = new System.Drawing.Size(682, 113);
            this.grbFilter.TabIndex = 5;
            this.grbFilter.Text = "查询条件";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(2, 148);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(682, 6);
            this.splitterControl1.TabIndex = 6;
            this.splitterControl1.TabStop = false;
            // 
            // gcSearch
            // 
            this.gcSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSearch.Location = new System.Drawing.Point(2, 154);
            this.gcSearch.MainView = this.gvSearch;
            this.gcSearch.Name = "gcSearch";
            this.gcSearch.Size = new System.Drawing.Size(682, 258);
            this.gcSearch.TabIndex = 5;
            this.gcSearch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSearch});
            // 
            // gvSearch
            // 
            this.gvSearch.GridControl = this.gcSearch;
            this.gvSearch.Name = "gvSearch";
            this.gvSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvSearch.OptionsView.ColumnAutoWidth = false;
            this.gvSearch.OptionsView.ShowFooter = true;
            this.gvSearch.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.chkAll);
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.btnOk);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 412);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(682, 33);
            this.panelControl2.TabIndex = 7;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(10, 9);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "全选";
            this.chkAll.Size = new System.Drawing.Size(53, 19);
            this.chkAll.TabIndex = 4;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(602, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.yes;
            this.btnOk.Location = new System.Drawing.Point(526, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 24);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAdvView
            // 
            this.btnAdvView.Location = new System.Drawing.Point(76, 5);
            this.btnAdvView.Name = "btnAdvView";
            this.btnAdvView.Size = new System.Drawing.Size(70, 24);
            this.btnAdvView.TabIndex = 3;
            this.btnAdvView.Text = "高级查询";
            this.btnAdvView.Click += new System.EventHandler(this.btnAdvView_Click);
            // 
            // frmCommSelectForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(686, 447);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmCommSelectForm";
            this.Text = "通用查询选择窗体";
            this.Load += new System.EventHandler(this.frmCommSelectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.GroupControl grbFilter;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private Sunrise.ERP.Controls.SunriseGridControl gcSearch;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSearch;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.SimpleButton btnAdvView;
    }
}
