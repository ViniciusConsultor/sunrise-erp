namespace Sunrise.ERP.Controls
{
    partial class SunriseLookUp
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
            this.txtDisplayText = new DevExpress.XtraEditors.ButtonEdit();
            this.txtValueText = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisplayText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValueText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDisplayText
            // 
            this.txtDisplayText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDisplayText.Location = new System.Drawing.Point(0, 0);
            this.txtDisplayText.Name = "txtDisplayText";
            this.txtDisplayText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDisplayText.Properties.LookAndFeel.SkinName = "Blue";
            this.txtDisplayText.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtDisplayText.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.LookUpSelfClick);
            this.txtDisplayText.Size = new System.Drawing.Size(132, 21);
            this.txtDisplayText.TabIndex = 0;
            this.txtDisplayText.Click += new System.EventHandler(this.txtDisplayText_Click);
            // 
            // txtValueText
            // 
            this.txtValueText.Location = new System.Drawing.Point(22, 0);
            this.txtValueText.Name = "txtValueText";
            this.txtValueText.Properties.LookAndFeel.SkinName = "Blue";
            this.txtValueText.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtValueText.Size = new System.Drawing.Size(43, 21);
            this.txtValueText.TabIndex = 1;
            this.txtValueText.Visible = false;
            this.txtValueText.TextChanged += new System.EventHandler(this.txtValueText_TextChanged);
            // 
            // SunriseLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.txtValueText);
            this.Controls.Add(this.txtDisplayText);
            this.Name = "SunriseLookUp";
            this.Size = new System.Drawing.Size(132, 24);
            this.Load += new System.EventHandler(this.SunriseLookUp_Load);
            this.SizeChanged += new System.EventHandler(this.SunriseLookUp_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.txtDisplayText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValueText.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit txtDisplayText;
        private DevExpress.XtraEditors.TextEdit txtValueText;
    }
}
