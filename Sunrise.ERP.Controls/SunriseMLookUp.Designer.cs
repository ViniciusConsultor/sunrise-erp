namespace Sunrise.ERP.Controls
{
    partial class SunriseMLookUp
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
            this.mlkpDataNo = new DevExpress.XtraEditors.PopupContainerEdit();
            this.mlkpPopup = new DevExpress.XtraEditors.PopupContainerControl();
            this.mlkpPopupGird = new Sunrise.ERP.Controls.SunriseGridControl();
            this.mlkpPopuoGirdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.mlkpDataName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.mlkpDataNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlkpPopup)).BeginInit();
            this.mlkpPopup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mlkpPopupGird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlkpPopuoGirdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlkpDataName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mlkpDataNo
            // 
            this.mlkpDataNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.mlkpDataNo.Location = new System.Drawing.Point(0, 0);
            this.mlkpDataNo.Name = "mlkpDataNo";
            this.mlkpDataNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.mlkpDataNo.Properties.LookAndFeel.SkinName = "Blue";
            this.mlkpDataNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.mlkpDataNo.Properties.PopupControl = this.mlkpPopup;
            this.mlkpDataNo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.mlkpDataNo.Properties.Leave += new System.EventHandler(this.mlkpDataNo_Properties_Leave);
            this.mlkpDataNo.Size = new System.Drawing.Size(113, 21);
            this.mlkpDataNo.TabIndex = 0;
            this.mlkpDataNo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.mlkpDataNo_ButtonClick);
            this.mlkpDataNo.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.mlkpDataNo_Closed);
            this.mlkpDataNo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.mlkpDataNo_PreviewKeyDown);
            this.mlkpDataNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mlkpDataNo_KeyDown);
            this.mlkpDataNo.Popup += new System.EventHandler(this.mlkpDataNo_Popup);
            this.mlkpDataNo.TextChanged += new System.EventHandler(this.mlkpDataNo_TextChanged);
            // 
            // mlkpPopup
            // 
            this.mlkpPopup.Controls.Add(this.mlkpPopupGird);
            this.mlkpPopup.Location = new System.Drawing.Point(0, 21);
            this.mlkpPopup.Name = "mlkpPopup";
            this.mlkpPopup.Size = new System.Drawing.Size(418, 252);
            this.mlkpPopup.TabIndex = 1;
            // 
            // mlkpPopupGird
            // 
            this.mlkpPopupGird.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlkpPopupGird.Location = new System.Drawing.Point(0, 0);
            this.mlkpPopupGird.LookAndFeel.SkinName = "Blue";
            this.mlkpPopupGird.LookAndFeel.UseDefaultLookAndFeel = false;
            this.mlkpPopupGird.MainView = this.mlkpPopuoGirdView;
            this.mlkpPopupGird.Name = "mlkpPopupGird";
            this.mlkpPopupGird.Size = new System.Drawing.Size(418, 252);
            this.mlkpPopupGird.TabIndex = 0;
            this.mlkpPopupGird.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mlkpPopuoGirdView});
            // 
            // mlkpPopuoGirdView
            // 
            this.mlkpPopuoGirdView.GridControl = this.mlkpPopupGird;
            this.mlkpPopuoGirdView.Name = "mlkpPopuoGirdView";
            this.mlkpPopuoGirdView.OptionsBehavior.Editable = false;
            this.mlkpPopuoGirdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.mlkpPopuoGirdView.OptionsView.ColumnAutoWidth = false;
            this.mlkpPopuoGirdView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.mlkpPopuoGirdView.OptionsView.ShowGroupPanel = false;
            this.mlkpPopuoGirdView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mlkpPopuoGirdView_KeyDown);
            this.mlkpPopuoGirdView.DoubleClick += new System.EventHandler(this.mlkpPopuoGirdView_DoubleClick);
            // 
            // mlkpDataName
            // 
            this.mlkpDataName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlkpDataName.Location = new System.Drawing.Point(113, 0);
            this.mlkpDataName.Name = "mlkpDataName";
            this.mlkpDataName.Properties.LookAndFeel.SkinName = "Blue";
            this.mlkpDataName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.mlkpDataName.Properties.ReadOnly = true;
            this.mlkpDataName.Size = new System.Drawing.Size(87, 21);
            this.mlkpDataName.TabIndex = 2;
            this.mlkpDataName.Tag = "99";
            // 
            // SunriseMLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mlkpDataName);
            this.Controls.Add(this.mlkpDataNo);
            this.Controls.Add(this.mlkpPopup);
            this.Name = "SunriseMLookUp";
            this.Size = new System.Drawing.Size(200, 21);
            this.Load += new System.EventHandler(this.SunriseMLookup_Load);
            this.Controls.SetChildIndex(this.mlkpPopup, 0);
            this.Controls.SetChildIndex(this.mlkpDataNo, 0);
            this.Controls.SetChildIndex(this.mlkpDataName, 0);
            ((System.ComponentModel.ISupportInitialize)(this.mlkpDataNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlkpPopup)).EndInit();
            this.mlkpPopup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mlkpPopupGird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlkpPopuoGirdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlkpDataName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PopupContainerEdit mlkpDataNo;
        private DevExpress.XtraGrid.Views.Grid.GridView mlkpPopuoGirdView;
        private DevExpress.XtraEditors.TextEdit mlkpDataName;
        public DevExpress.XtraEditors.PopupContainerControl mlkpPopup;
        public SunriseGridControl mlkpPopupGird;
    }
}
