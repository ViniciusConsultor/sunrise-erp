namespace Sunrise.ERP.BaseForm
{
    partial class frmSearchForm
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
            this.txtSearchValue = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.txtBtnSearchValue = new DevExpress.XtraEditors.ButtonEdit();
            this.cbxSearchValue = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.detSearchValue = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxSearchWhere = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxSearchItem = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.txtSearchText = new DevExpress.XtraEditors.MemoEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnOr = new DevExpress.XtraEditors.SimpleButton();
            this.btnAnd = new DevExpress.XtraEditors.SimpleButton();
            this.lkpSearchValue = new Sunrise.ERP.Controls.SunriseLookUp();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBtnSearchValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxSearchValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detSearchValue.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detSearchValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxSearchWhere.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxSearchItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl4);
            this.panelControl1.Controls.Add(this.pnlTop);
            this.panelControl1.Size = new System.Drawing.Size(515, 328);
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Location = new System.Drawing.Point(370, 13);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(131, 21);
            this.txtSearchValue.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "查询项目";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lkpSearchValue);
            this.pnlTop.Controls.Add(this.txtSearchValue);
            this.pnlTop.Controls.Add(this.txtBtnSearchValue);
            this.pnlTop.Controls.Add(this.cbxSearchValue);
            this.pnlTop.Controls.Add(this.detSearchValue);
            this.pnlTop.Controls.Add(this.label4);
            this.pnlTop.Controls.Add(this.cbxSearchWhere);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.cbxSearchItem);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(2, 2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(511, 47);
            this.pnlTop.TabIndex = 2;
            // 
            // txtBtnSearchValue
            // 
            this.txtBtnSearchValue.Location = new System.Drawing.Point(370, 13);
            this.txtBtnSearchValue.Name = "txtBtnSearchValue";
            this.txtBtnSearchValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtBtnSearchValue.Size = new System.Drawing.Size(131, 21);
            this.txtBtnSearchValue.TabIndex = 8;
            // 
            // cbxSearchValue
            // 
            this.cbxSearchValue.Location = new System.Drawing.Point(370, 13);
            this.cbxSearchValue.Name = "cbxSearchValue";
            this.cbxSearchValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxSearchValue.Size = new System.Drawing.Size(131, 21);
            this.cbxSearchValue.TabIndex = 7;
            // 
            // detSearchValue
            // 
            this.detSearchValue.EditValue = null;
            this.detSearchValue.Location = new System.Drawing.Point(370, 13);
            this.detSearchValue.Name = "detSearchValue";
            this.detSearchValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.detSearchValue.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.detSearchValue.Size = new System.Drawing.Size(131, 21);
            this.detSearchValue.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "查询值";
            // 
            // cbxSearchWhere
            // 
            this.cbxSearchWhere.Location = new System.Drawing.Point(247, 13);
            this.cbxSearchWhere.Name = "cbxSearchWhere";
            this.cbxSearchWhere.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxSearchWhere.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("等于", "=", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("大于", ">", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("大于等于", ">=", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("小于", "<", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("小于等于", "<=", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("类似于", "LIKE", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("为空", "IS NULL", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("不为空", "IS NOT NULL", -1)});
            this.cbxSearchWhere.Size = new System.Drawing.Size(69, 21);
            this.cbxSearchWhere.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "查询条件";
            // 
            // cbxSearchItem
            // 
            this.cbxSearchItem.Location = new System.Drawing.Point(62, 13);
            this.cbxSearchItem.Name = "cbxSearchItem";
            this.cbxSearchItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxSearchItem.Size = new System.Drawing.Size(123, 21);
            this.cbxSearchItem.TabIndex = 2;
            this.cbxSearchItem.SelectedIndexChanged += new System.EventHandler(this.cbxSearchItem_SelectedIndexChanged);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.txtSearchText);
            this.panelControl3.Controls.Add(this.label2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 49);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(511, 237);
            this.panelControl3.TabIndex = 3;
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(10, 23);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSearchText.Properties.Appearance.Options.UseBackColor = true;
            this.txtSearchText.Properties.ReadOnly = true;
            this.txtSearchText.Size = new System.Drawing.Size(494, 208);
            this.txtSearchText.TabIndex = 2;
            this.txtSearchText.TextChanged += new System.EventHandler(this.txtSearchText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "组合的查询结果";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.btnOk);
            this.panelControl4.Controls.Add(this.btnCancel);
            this.panelControl4.Controls.Add(this.btnClear);
            this.panelControl4.Controls.Add(this.btnOr);
            this.panelControl4.Controls.Add(this.btnAnd);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(2, 286);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(511, 40);
            this.panelControl4.TabIndex = 4;
            // 
            // btnOk
            // 
            this.btnOk.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.yes;
            this.btnOk.Location = new System.Drawing.Point(349, 9);
            this.btnOk.LookAndFeel.SkinName = "Blue";
            this.btnOk.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(425, 9);
            this.btnCancel.LookAndFeel.SkinName = "Blue";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消(&C)";
            // 
            // btnClear
            // 
            this.btnClear.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.clear;
            this.btnClear.Location = new System.Drawing.Point(163, 9);
            this.btnClear.LookAndFeel.SkinName = "Blue";
            this.btnClear.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "清除(&X)";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOr
            // 
            this.btnOr.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.or;
            this.btnOr.Location = new System.Drawing.Point(88, 9);
            this.btnOr.LookAndFeel.SkinName = "Blue";
            this.btnOr.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOr.Name = "btnOr";
            this.btnOr.Size = new System.Drawing.Size(70, 23);
            this.btnOr.TabIndex = 1;
            this.btnOr.Text = "或者(&R)";
            this.btnOr.Click += new System.EventHandler(this.btnOr_Click);
            // 
            // btnAnd
            // 
            this.btnAnd.Image = global::Sunrise.ERP.BaseForm.Properties.Resources.and;
            this.btnAnd.Location = new System.Drawing.Point(13, 9);
            this.btnAnd.LookAndFeel.SkinName = "Blue";
            this.btnAnd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAnd.Name = "btnAnd";
            this.btnAnd.Size = new System.Drawing.Size(70, 23);
            this.btnAnd.TabIndex = 0;
            this.btnAnd.Text = "并且(&A)";
            this.btnAnd.Click += new System.EventHandler(this.btnAnd_Click);
            // 
            // lkpSearchValue
            // 
            this.lkpSearchValue.AutoSize = true;
            this.lkpSearchValue.DataField = null;
            this.lkpSearchValue.DisplayField = null;
            this.lkpSearchValue.EditFormFilter = null;
            this.lkpSearchValue.EditFormID = 0;
            this.lkpSearchValue.EditFormName = null;
            this.lkpSearchValue.EditValue = "";
            this.lkpSearchValue.GridColumnText = null;
            this.lkpSearchValue.GridDisplayField = null;
            this.lkpSearchValue.Location = new System.Drawing.Point(370, 13);
            this.lkpSearchValue.Name = "lkpSearchValue";
            this.lkpSearchValue.SearchFormFilter = "";
            this.lkpSearchValue.SearchFormText = "";
            this.lkpSearchValue.Size = new System.Drawing.Size(131, 21);
            this.lkpSearchValue.SQL = null;
            this.lkpSearchValue.TabIndex = 9;
            this.lkpSearchValue.TextFont = new System.Drawing.Font("Tahoma", 9F);
            // 
            // frmSearchForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(515, 328);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单据查询";
            this.Load += new System.EventHandler(this.frmSearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBtnSearchValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxSearchValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detSearchValue.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detSearchValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxSearchWhere.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxSearchItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtSearchValue;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl pnlTop;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.MemoEdit txtSearchText;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbxSearchWhere;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbxSearchItem;
        private DevExpress.XtraEditors.SimpleButton btnAnd;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnOr;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbxSearchValue;
        private DevExpress.XtraEditors.DateEdit detSearchValue;
        private DevExpress.XtraEditors.ButtonEdit txtBtnSearchValue;
        private Sunrise.ERP.Controls.SunriseLookUp lkpSearchValue;
    }
}
