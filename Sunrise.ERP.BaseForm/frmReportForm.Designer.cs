namespace Sunrise.ERP.BaseForm
{
    partial class frmReportForm
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
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSet = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdvanceView = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnAdvanceView);
            this.panelControl3.Controls.Add(this.btnClose);
            this.panelControl3.Controls.Add(this.btnSet);
            this.panelControl3.Controls.Add(this.btnView);
            this.panelControl3.Controls.Add(this.btnPrint);
            this.panelControl3.Controls.Add(this.btnClear);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(753, 33);
            this.panelControl3.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(357, 5);
            this.btnClose.LookAndFeel.SkinName = "Blue";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 24);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭(&X)";
            // 
            // btnSet
            // 
            this.btnSet.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.insert;
            this.btnSet.Location = new System.Drawing.Point(286, 5);
            this.btnSet.LookAndFeel.SkinName = "Blue";
            this.btnSet.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(70, 24);
            this.btnSet.TabIndex = 5;
            this.btnSet.Text = "执行(&R)";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.print;
            this.btnPrint.Location = new System.Drawing.Point(215, 5);
            this.btnPrint.LookAndFeel.SkinName = "Blue";
            this.btnPrint.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(70, 24);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "打印(&P)";
            // 
            // btnClear
            // 
            this.btnClear.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.cancel;
            this.btnClear.Location = new System.Drawing.Point(144, 5);
            this.btnClear.LookAndFeel.SkinName = "Blue";
            this.btnClear.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 24);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "清除(&C)";
            // 
            // btnView
            // 
            this.btnView.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.view;
            this.btnView.Location = new System.Drawing.Point(73, 5);
            this.btnView.LookAndFeel.SkinName = "Blue";
            this.btnView.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(70, 24);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "过滤(&V)";
            // 
            // btnAdvanceView
            // 
            this.btnAdvanceView.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.view;
            this.btnAdvanceView.Location = new System.Drawing.Point(2, 5);
            this.btnAdvanceView.LookAndFeel.SkinName = "Blue";
            this.btnAdvanceView.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAdvanceView.Name = "btnAdvanceView";
            this.btnAdvanceView.Size = new System.Drawing.Size(70, 24);
            this.btnAdvanceView.TabIndex = 6;
            this.btnAdvanceView.Text = "高级(&A)";
            // 
            // frmReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(757, 498);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmReportForm";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSet;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnAdvanceView;
    }
}
