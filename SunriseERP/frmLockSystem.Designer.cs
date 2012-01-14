namespace SunriseERP
{
    partial class frmLockSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLockSystem));
            this.btnUnLock = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.lblTip = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblTip);
            this.panelControl1.Controls.Add(this.txtPassword);
            this.panelControl1.Controls.Add(this.btnUnLock);
            this.panelControl1.Size = new System.Drawing.Size(460, 167);
            // 
            // btnUnLock
            // 
            this.btnUnLock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUnLock.ImageIndex = 0;
            this.btnUnLock.ImageList = this.imageList1;
            this.btnUnLock.Location = new System.Drawing.Point(171, 112);
            this.btnUnLock.Name = "btnUnLock";
            this.btnUnLock.Size = new System.Drawing.Size(85, 23);
            this.btnUnLock.TabIndex = 5;
            this.btnUnLock.Text = "解锁(&U)";
            this.btnUnLock.Click += new System.EventHandler(this.btnUnLock_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "password.gif");
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(106, 72);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(240, 21);
            this.txtPassword.TabIndex = 6;
            // 
            // lblTip
            // 
            this.lblTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTip.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTip.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblTip.Appearance.Options.UseFont = true;
            this.lblTip.Appearance.Options.UseForeColor = true;
            this.lblTip.Appearance.Options.UseTextOptions = true;
            this.lblTip.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTip.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTip.Location = new System.Drawing.Point(0, 31);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(460, 14);
            this.lblTip.TabIndex = 7;
            this.lblTip.Text = "系统已锁定，请输入当前用户密码进行解锁！";
            // 
            // frmLockSystem
            // 
            this.AcceptButton = this.btnUnLock;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(460, 167);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmLockSystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLockSystem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnUnLock;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.LabelControl lblTip;
    }
}
