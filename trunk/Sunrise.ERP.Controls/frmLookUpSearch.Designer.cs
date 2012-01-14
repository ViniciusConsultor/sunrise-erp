namespace Sunrise.ERP.Controls
{
    partial class frmLookUpSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLookUpSearch));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.gcSearch = new Sunrise.ERP.Controls.SunriseGridControl();
            this.gvSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnEdit);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.btnSelect);
            this.panelControl1.Controls.Add(this.btnView);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinName = "Blue";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(603, 32);
            this.panelControl1.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Sunrise.ERP.Controls.Properties.Resources.edit;
            this.btnEdit.Location = new System.Drawing.Point(289, 5);
            this.btnEdit.LookAndFeel.SkinName = "Blue";
            this.btnEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(70, 24);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "编辑(&E)";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Sunrise.ERP.Controls.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(218, 5);
            this.btnClose.LookAndFeel.SkinName = "Blue";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 24);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭(&X)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Sunrise.ERP.Controls.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(147, 5);
            this.btnCancel.LookAndFeel.SkinName = "Blue";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = global::Sunrise.ERP.Controls.Properties.Resources.ok;
            this.btnSelect.Location = new System.Drawing.Point(76, 5);
            this.btnSelect.LookAndFeel.SkinName = "Blue";
            this.btnSelect.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(70, 24);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "选择(&S)";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnView
            // 
            this.btnView.Image = global::Sunrise.ERP.Controls.Properties.Resources.view;
            this.btnView.Location = new System.Drawing.Point(5, 5);
            this.btnView.LookAndFeel.SkinName = "Blue";
            this.btnView.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(70, 24);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "查询(&Q)";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // gcSearch
            // 
            this.gcSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSearch.Location = new System.Drawing.Point(0, 32);
            this.gcSearch.MainView = this.gvSearch;
            this.gcSearch.Name = "gcSearch";
            this.gcSearch.Size = new System.Drawing.Size(603, 284);
            this.gcSearch.TabIndex = 1;
            this.gcSearch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSearch});
            // 
            // gvSearch
            // 
            this.gvSearch.GridControl = this.gcSearch;
            this.gvSearch.Name = "gvSearch";
            this.gvSearch.OptionsBehavior.Editable = false;
            this.gvSearch.OptionsView.ColumnAutoWidth = false;
            this.gvSearch.OptionsView.ShowAutoFilterRow = true;
            this.gvSearch.OptionsView.ShowFooter = true;
            this.gvSearch.OptionsView.ShowGroupPanel = false;
            this.gvSearch.DoubleClick += new System.EventHandler(this.gcSearch_DoubleClick);
            // 
            // frmLookUpSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 316);
            this.Controls.Add(this.gcSearch);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmLookUpSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择";
            this.Load += new System.EventHandler(this.frmLookUpSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Sunrise.ERP.Controls.SunriseGridControl gcSearch;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSearch;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
    }
}