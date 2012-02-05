namespace Sunrise.ERP.BaseForm
{
    partial class frmBaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseForm));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dataNav = new DevExpress.XtraEditors.DataNavigator();
            this.btnSettings = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnInsert = new DevExpress.XtraEditors.SimpleButton();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.txtDataFlag = new DevExpress.XtraEditors.TextEdit();
            this.btnAction = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataFlag.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.txtDataFlag);
            this.panelControl1.LookAndFeel.SkinName = "Blue";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Size = new System.Drawing.Size(1055, 498);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnAction);
            this.panelControl2.Controls.Add(this.dataNav);
            this.panelControl2.Controls.Add(this.btnSettings);
            this.panelControl2.Controls.Add(this.btnRefresh);
            this.panelControl2.Controls.Add(this.btnInsert);
            this.panelControl2.Controls.Add(this.btnCopy);
            this.panelControl2.Controls.Add(this.btnPrint);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnDelete);
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Controls.Add(this.btnEdit);
            this.panelControl2.Controls.Add(this.btnAdd);
            this.panelControl2.Controls.Add(this.btnView);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.LookAndFeel.SkinName = "Blue";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1051, 33);
            this.panelControl2.TabIndex = 1;
            // 
            // dataNav
            // 
            this.dataNav.Buttons.Append.Visible = false;
            this.dataNav.Buttons.CancelEdit.Visible = false;
            this.dataNav.Buttons.EndEdit.Visible = false;
            this.dataNav.Buttons.NextPage.Visible = false;
            this.dataNav.Buttons.PrevPage.Visible = false;
            this.dataNav.Buttons.Remove.Visible = false;
            this.dataNav.Location = new System.Drawing.Point(727, 4);
            this.dataNav.Name = "dataNav";
            this.dataNav.Size = new System.Drawing.Size(126, 24);
            this.dataNav.TabIndex = 13;
            this.dataNav.Visible = false;
            // 
            // btnSettings
            // 
            this.btnSettings.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.settings;
            this.btnSettings.Location = new System.Drawing.Point(854, 4);
            this.btnSettings.LookAndFeel.SkinName = "Blue";
            this.btnSettings.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 24);
            this.btnSettings.TabIndex = 11;
            this.btnSettings.Text = "设置(&T)";
            this.btnSettings.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(904, 4);
            this.btnRefresh.LookAndFeel.SkinName = "Blue";
            this.btnRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 24);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.insert;
            this.btnInsert.Location = new System.Drawing.Point(872, 4);
            this.btnInsert.LookAndFeel.SkinName = "Blue";
            this.btnInsert.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(70, 24);
            this.btnInsert.TabIndex = 9;
            this.btnInsert.Text = "插入(&I)";
            this.btnInsert.Visible = false;
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.copy;
            this.btnCopy.Location = new System.Drawing.Point(289, 4);
            this.btnCopy.LookAndFeel.SkinName = "Blue";
            this.btnCopy.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(70, 24);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "复制(&O)";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.print;
            this.btnPrint.Location = new System.Drawing.Point(502, 4);
            this.btnPrint.LookAndFeel.SkinName = "Blue";
            this.btnPrint.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(70, 24);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(656, 4);
            this.btnClose.LookAndFeel.SkinName = "Blue";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 24);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭(&X)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(218, 4);
            this.btnDelete.LookAndFeel.SkinName = "Blue";
            this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 24);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(360, 4);
            this.btnCancel.LookAndFeel.SkinName = "Blue";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(431, 4);
            this.btnSave.LookAndFeel.SkinName = "Blue";
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 24);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.edit;
            this.btnEdit.Location = new System.Drawing.Point(147, 4);
            this.btnEdit.LookAndFeel.SkinName = "Blue";
            this.btnEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(70, 24);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "修改(&E)";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(76, 4);
            this.btnAdd.LookAndFeel.SkinName = "Blue";
            this.btnAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 24);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "新增(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnView
            // 
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.Location = new System.Drawing.Point(5, 4);
            this.btnView.LookAndFeel.SkinName = "Blue";
            this.btnView.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(70, 24);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "过滤(&Q)";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtDataFlag
            // 
            this.txtDataFlag.Location = new System.Drawing.Point(532, 59);
            this.txtDataFlag.Name = "txtDataFlag";
            this.txtDataFlag.Size = new System.Drawing.Size(100, 21);
            this.txtDataFlag.TabIndex = 2;
            this.txtDataFlag.Visible = false;
            // 
            // btnAction
            // 
            this.btnAction.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.refresh;
            this.btnAction.Location = new System.Drawing.Point(573, 4);
            this.btnAction.LookAndFeel.SkinName = "Blue";
            this.btnAction.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(82, 24);
            this.btnAction.TabIndex = 14;
            this.btnAction.Text = "Action(&N)";
            this.btnAction.Visible = false;
            // 
            // frmBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1055, 498);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmBaseForm";
            this.Text = "frmBaseForm";
            this.Load += new System.EventHandler(this.frmBaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDataFlag.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.PanelControl panelControl2;
        protected DevExpress.XtraEditors.SimpleButton btnInsert;
        protected DevExpress.XtraEditors.SimpleButton btnCopy;
        protected DevExpress.XtraEditors.SimpleButton btnPrint;
        protected DevExpress.XtraEditors.SimpleButton btnClose;
        protected DevExpress.XtraEditors.SimpleButton btnDelete;
        protected DevExpress.XtraEditors.SimpleButton btnCancel;
        protected DevExpress.XtraEditors.SimpleButton btnSave;
        protected DevExpress.XtraEditors.SimpleButton btnEdit;
        protected DevExpress.XtraEditors.SimpleButton btnAdd;
        protected DevExpress.XtraEditors.SimpleButton btnView;
        protected DevExpress.XtraEditors.SimpleButton btnRefresh;
        protected DevExpress.XtraEditors.TextEdit txtDataFlag;
        protected DevExpress.XtraEditors.SimpleButton btnSettings;
        protected DevExpress.XtraEditors.DataNavigator dataNav;
        protected DevExpress.XtraEditors.SimpleButton btnAction;
    }
}
