namespace Sunrise.ERP.Report
{
    partial class frmSaveReport
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnSetDefault = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtReportName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcReport = new Sunrise.ERP.Controls.BoyeeGridControl();
            this.gvReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsReportName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbIsDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dsReport = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReportName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gcReport);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Size = new System.Drawing.Size(608, 335);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnSetDefault);
            this.panelControl2.Controls.Add(this.btnDelete);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Controls.Add(this.btnEdit);
            this.panelControl2.Controls.Add(this.btnAdd);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.LookAndFeel.SkinName = "Blue";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(604, 33);
            this.panelControl2.TabIndex = 2;
            // 
            // btnSetDefault
            // 
            this.btnSetDefault.Image = global::Sunrise.ERP.Report.Properties.Resources.insert;
            this.btnSetDefault.Location = new System.Drawing.Point(431, 4);
            this.btnSetDefault.LookAndFeel.SkinName = "Blue";
            this.btnSetDefault.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSetDefault.Name = "btnSetDefault";
            this.btnSetDefault.Size = new System.Drawing.Size(101, 24);
            this.btnSetDefault.TabIndex = 9;
            this.btnSetDefault.Text = "设置默认报表";
            this.btnSetDefault.ToolTip = "关闭";
            this.btnSetDefault.Click += new System.EventHandler(this.btnSetDefault_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Sunrise.ERP.Report.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(147, 4);
            this.btnDelete.LookAndFeel.SkinName = "Blue";
            this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 24);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.ToolTip = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Sunrise.ERP.Report.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(360, 4);
            this.btnClose.LookAndFeel.SkinName = "Blue";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 24);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭(&X)";
            this.btnClose.ToolTip = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Sunrise.ERP.Report.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(218, 4);
            this.btnCancel.LookAndFeel.SkinName = "Blue";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.ToolTip = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Sunrise.ERP.Report.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(289, 4);
            this.btnSave.LookAndFeel.SkinName = "Blue";
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 24);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.ToolTip = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Sunrise.ERP.Report.Properties.Resources.edit;
            this.btnEdit.Location = new System.Drawing.Point(76, 4);
            this.btnEdit.LookAndFeel.SkinName = "Blue";
            this.btnEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(70, 24);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "修改(&E)";
            this.btnEdit.ToolTip = "修改";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Sunrise.ERP.Report.Properties.Resources.add;
            this.btnAdd.Location = new System.Drawing.Point(5, 4);
            this.btnAdd.LookAndFeel.SkinName = "Blue";
            this.btnAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 24);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "新增(&A)";
            this.btnAdd.ToolTip = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.txtRemark);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.txtReportName);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 35);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(604, 81);
            this.panelControl3.TabIndex = 3;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(60, 35);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(370, 38);
            this.txtRemark.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "备      注";
            // 
            // txtReportName
            // 
            this.txtReportName.Location = new System.Drawing.Point(60, 8);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Size = new System.Drawing.Size(370, 21);
            this.txtReportName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(8, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "报表名称";
            // 
            // gcReport
            // 
            this.gcReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcReport.Location = new System.Drawing.Point(2, 116);
            this.gcReport.MainView = this.gvReport;
            this.gcReport.Name = "gcReport";
            this.gcReport.Size = new System.Drawing.Size(604, 217);
            this.gcReport.TabIndex = 4;
            this.gcReport.UseDisabledStatePainter = false;
            this.gcReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReport});
            // 
            // gvReport
            // 
            this.gvReport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsReportName,
            this.colbIsDefault,
            this.colsRemark});
            this.gvReport.GridControl = this.gcReport;
            this.gvReport.Name = "gvReport";
            this.gvReport.OptionsBehavior.Editable = false;
            this.gvReport.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvReport.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvReport.OptionsView.ColumnAutoWidth = false;
            this.gvReport.OptionsView.ShowFooter = true;
            this.gvReport.OptionsView.ShowGroupPanel = false;
            this.gvReport.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvReport_RowStyle);
            // 
            // colsReportName
            // 
            this.colsReportName.Caption = "报表名称";
            this.colsReportName.FieldName = "sReportName";
            this.colsReportName.Name = "colsReportName";
            this.colsReportName.Visible = true;
            this.colsReportName.VisibleIndex = 0;
            this.colsReportName.Width = 130;
            // 
            // colbIsDefault
            // 
            this.colbIsDefault.Caption = "是否默认";
            this.colbIsDefault.FieldName = "bIsDefault";
            this.colbIsDefault.Name = "colbIsDefault";
            this.colbIsDefault.Visible = true;
            this.colbIsDefault.VisibleIndex = 1;
            this.colbIsDefault.Width = 81;
            // 
            // colsRemark
            // 
            this.colsRemark.Caption = "备注";
            this.colsRemark.FieldName = "sRemark";
            this.colsRemark.Name = "colsRemark";
            this.colsRemark.Visible = true;
            this.colsRemark.VisibleIndex = 2;
            this.colsRemark.Width = 238;
            // 
            // frmSaveReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(608, 335);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmSaveReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "保存报表";
            this.Load += new System.EventHandler(this.frmSaveReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReportName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.PanelControl panelControl2;
        protected DevExpress.XtraEditors.SimpleButton btnClose;
        protected DevExpress.XtraEditors.SimpleButton btnDelete;
        protected DevExpress.XtraEditors.SimpleButton btnCancel;
        protected DevExpress.XtraEditors.SimpleButton btnSave;
        protected DevExpress.XtraEditors.SimpleButton btnEdit;
        protected DevExpress.XtraEditors.SimpleButton btnAdd;
        private Sunrise.ERP.Controls.BoyeeGridControl gcReport;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReport;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        protected DevExpress.XtraEditors.SimpleButton btnSetDefault;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtReportName;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn colsReportName;
        private DevExpress.XtraGrid.Columns.GridColumn colbIsDefault;
        private DevExpress.XtraGrid.Columns.GridColumn colsRemark;
        private System.Windows.Forms.BindingSource dsReport;

    }
}
