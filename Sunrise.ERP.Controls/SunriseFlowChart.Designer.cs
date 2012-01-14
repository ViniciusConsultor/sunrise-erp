namespace Sunrise.ERP.Controls
{
    partial class SunriseFlowChart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tipMsg = new DevExpress.Utils.ToolTipController(this.components);
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tspSetItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLine = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmSetLine = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteLine = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMenu.SuspendLayout();
            this.cmsLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspSetItem,
            this.tsmDeleteItem});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(118, 48);
            // 
            // tspSetItem
            // 
            this.tspSetItem.Name = "tspSetItem";
            this.tspSetItem.Size = new System.Drawing.Size(117, 22);
            this.tspSetItem.Text = "设置(&S)";
            this.tspSetItem.Click += new System.EventHandler(this.tsmSetItem_Click);
            // 
            // tsmDeleteItem
            // 
            this.tsmDeleteItem.Name = "tsmDeleteItem";
            this.tsmDeleteItem.Size = new System.Drawing.Size(117, 22);
            this.tsmDeleteItem.Text = "删除(&D)";
            this.tsmDeleteItem.Click += new System.EventHandler(this.tsmDeleteItem_Click);
            // 
            // cmsLine
            // 
            this.cmsLine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSetLine,
            this.tsmDeleteLine});
            this.cmsLine.Name = "cmsMenu";
            this.cmsLine.Size = new System.Drawing.Size(118, 48);
            // 
            // tsmSetLine
            // 
            this.tsmSetLine.Name = "tsmSetLine";
            this.tsmSetLine.Size = new System.Drawing.Size(117, 22);
            this.tsmSetLine.Text = "设置(&S)";
            this.tsmSetLine.Click += new System.EventHandler(this.tsbLineSet_Click);
            // 
            // tsmDeleteLine
            // 
            this.tsmDeleteLine.Name = "tsmDeleteLine";
            this.tsmDeleteLine.Size = new System.Drawing.Size(117, 22);
            this.tsmDeleteLine.Text = "删除(&D)";
            this.tsmDeleteLine.Click += new System.EventHandler(this.tsmDeleteLine_Click);
            // 
            // BWSFlowChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BWSFlowChart";
            this.Size = new System.Drawing.Size(485, 282);
            this.Load += new System.EventHandler(this.SunriseFlowChart_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SunriseFlowChart_Paint);
            this.Click += new System.EventHandler(this.SunriseFlowChart_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SunriseFlowChart_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SunriseFlowChart_MouseDown);
            this.cmsMenu.ResumeLayout(false);
            this.cmsLine.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController tipMsg;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem tspSetItem;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteItem;
        private System.Windows.Forms.ContextMenuStrip cmsLine;
        private System.Windows.Forms.ToolStripMenuItem tsmSetLine;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteLine;
    }
}
