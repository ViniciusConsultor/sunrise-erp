namespace Sunrise.ERP.Report
{
    partial class frmReportDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportDesign));
            this.designerControl1 = new FastReport.Design.StandardDesigner.DesignerControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.designerControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.designerControl1);
            // 
            // designerControl1
            // 
            this.designerControl1.AskSave = true;
            this.designerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.designerControl1.LayoutState = resources.GetString("designerControl1.LayoutState");
            this.designerControl1.Location = new System.Drawing.Point(2, 2);
            this.designerControl1.Name = "designerControl1";
            this.designerControl1.Size = new System.Drawing.Size(753, 494);
            this.designerControl1.TabIndex = 0;
            // 
            // frmReportDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(757, 498);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ImeMode = System.Windows.Forms.ImeMode.OnHalf;
            this.Name = "frmReportDesign";
            this.Text = "设计报表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportDesign_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.designerControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastReport.Design.StandardDesigner.DesignerControl designerControl1;
    }
}
