namespace SunriseERP
{
    partial class frmUpdatePassword
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
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.lblsUserID = new DevExpress.XtraEditors.LabelControl();
            this.lblOldPassword = new DevExpress.XtraEditors.LabelControl();
            this.lblNewPassword = new DevExpress.XtraEditors.LabelControl();
            this.lblNewPassword2 = new DevExpress.XtraEditors.LabelControl();
            this.txtOldPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtNewPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtNewPwd2 = new DevExpress.XtraEditors.TextEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.btnOk);
            this.panelControl1.Controls.Add(this.txtNewPwd2);
            this.panelControl1.Controls.Add(this.txtNewPwd);
            this.panelControl1.Controls.Add(this.txtOldPwd);
            this.panelControl1.Controls.Add(this.lblNewPassword2);
            this.panelControl1.Controls.Add(this.lblNewPassword);
            this.panelControl1.Controls.Add(this.lblOldPassword);
            this.panelControl1.Controls.Add(this.lblsUserID);
            this.panelControl1.Controls.Add(this.lblUserName);
            this.panelControl1.Size = new System.Drawing.Size(361, 195);
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(28, 22);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(84, 14);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "当前登录帐号：";
            // 
            // lblsUserID
            // 
            this.lblsUserID.Location = new System.Drawing.Point(129, 22);
            this.lblsUserID.Name = "lblsUserID";
            this.lblsUserID.Size = new System.Drawing.Size(70, 14);
            this.lblsUserID.TabIndex = 1;
            this.lblsUserID.Text = "labelControl2";
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.Location = new System.Drawing.Point(28, 52);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(48, 14);
            this.lblOldPassword.TabIndex = 2;
            this.lblOldPassword.Text = "原密码：";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.Location = new System.Drawing.Point(28, 84);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(48, 14);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "新密码：";
            // 
            // lblNewPassword2
            // 
            this.lblNewPassword2.Location = new System.Drawing.Point(28, 114);
            this.lblNewPassword2.Name = "lblNewPassword2";
            this.lblNewPassword2.Size = new System.Drawing.Size(60, 14);
            this.lblNewPassword2.TabIndex = 4;
            this.lblNewPassword2.Text = "确认密码：";
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(129, 49);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.Properties.PasswordChar = '*';
            this.txtOldPwd.Size = new System.Drawing.Size(168, 21);
            this.txtOldPwd.TabIndex = 5;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(129, 81);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Properties.PasswordChar = '*';
            this.txtNewPwd.Size = new System.Drawing.Size(168, 21);
            this.txtNewPwd.TabIndex = 6;
            // 
            // txtNewPwd2
            // 
            this.txtNewPwd2.Location = new System.Drawing.Point(129, 111);
            this.txtNewPwd2.Name = "txtNewPwd2";
            this.txtNewPwd2.Properties.PasswordChar = '*';
            this.txtNewPwd2.Size = new System.Drawing.Size(168, 21);
            this.txtNewPwd2.TabIndex = 7;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(90, 148);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "确认(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(203, 148);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmUpdatePassword
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(361, 195);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmUpdatePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.frmUpdatePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblOldPassword;
        private DevExpress.XtraEditors.LabelControl lblsUserID;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.TextEdit txtNewPwd2;
        private DevExpress.XtraEditors.TextEdit txtNewPwd;
        private DevExpress.XtraEditors.TextEdit txtOldPwd;
        private DevExpress.XtraEditors.LabelControl lblNewPassword2;
        private DevExpress.XtraEditors.LabelControl lblNewPassword;
    }
}
