namespace Sunrise.ERP.Module.Test
{
    partial class frmTest
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
            this.gcMain = new Sunrise.ERP.Controls.SunriseGridControl();
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblsTest = new DevExpress.XtraEditors.LabelControl();
            this.txtsTest = new DevExpress.XtraEditors.TextEdit();
            this.lblsRemark = new DevExpress.XtraEditors.LabelControl();
            this.mtxtsRemark = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfo)).BeginInit();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsTest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtsRemark.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gcMain);
            this.pnlGrid.Location = new System.Drawing.Point(2, 200);
            this.pnlGrid.Size = new System.Drawing.Size(867, 296);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(2, 194);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.mtxtsRemark);
            this.pnlInfo.Controls.Add(this.lblsRemark);
            this.pnlInfo.Controls.Add(this.txtsTest);
            this.pnlInfo.Controls.Add(this.lblsTest);
            this.pnlInfo.Size = new System.Drawing.Size(867, 159);
            // 
            // panelControl2
            // 
            this.panelControl2.LookAndFeel.SkinName = "Blue";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnInsert
            // 
            this.btnInsert.LookAndFeel.SkinName = "Blue";
            this.btnInsert.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnCopy
            // 
            this.btnCopy.LookAndFeel.SkinName = "Blue";
            this.btnCopy.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnPrint
            // 
            this.btnPrint.LookAndFeel.SkinName = "Blue";
            this.btnPrint.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnClose
            // 
            this.btnClose.LookAndFeel.SkinName = "Blue";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnDelete
            // 
            this.btnDelete.LookAndFeel.SkinName = "Blue";
            this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnCancel
            // 
            this.btnCancel.LookAndFeel.SkinName = "Blue";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnSave
            // 
            this.btnSave.LookAndFeel.SkinName = "Blue";
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnEdit
            // 
            this.btnEdit.LookAndFeel.SkinName = "Blue";
            this.btnEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnAdd
            // 
            this.btnAdd.LookAndFeel.SkinName = "Blue";
            this.btnAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnView
            // 
            this.btnView.LookAndFeel.SkinName = "Blue";
            this.btnView.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.LookAndFeel.SkinName = "Blue";
            this.btnRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // txtDataFlag
            // 
            // 
            // btnSettings
            // 
            this.btnSettings.LookAndFeel.SkinName = "Blue";
            this.btnSettings.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // panelControl1
            // 
            this.panelControl1.LookAndFeel.SkinName = "Blue";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // gcMain
            // 
            this.gcMain.DataSource = this.dsMain;
            this.gcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMain.Location = new System.Drawing.Point(2, 2);
            this.gcMain.MainView = this.gvMain;
            this.gcMain.Name = "gcMain";
            this.gcMain.Size = new System.Drawing.Size(863, 292);
            this.gcMain.TabIndex = 3;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.GridControl = this.gcMain;
            this.gvMain.Name = "gvMain";
            this.gvMain.OptionsBehavior.Editable = false;
            this.gvMain.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvMain.OptionsView.ColumnAutoWidth = false;
            this.gvMain.OptionsView.ShowAutoFilterRow = true;
            this.gvMain.OptionsView.ShowFooter = true;
            this.gvMain.OptionsView.ShowGroupPanel = false;
            // 
            // lblsTest
            // 
            this.lblsTest.Location = new System.Drawing.Point(10, 16);
            this.lblsTest.Name = "lblsTest";
            this.lblsTest.Size = new System.Drawing.Size(24, 14);
            this.lblsTest.TabIndex = 6;
            this.lblsTest.Text = "测试";
            // 
            // txtsTest
            // 
            this.txtsTest.Location = new System.Drawing.Point(76, 13);
            this.txtsTest.Name = "txtsTest";
            this.txtsTest.Size = new System.Drawing.Size(290, 21);
            this.txtsTest.TabIndex = 7;
            // 
            // lblsRemark
            // 
            this.lblsRemark.Location = new System.Drawing.Point(10, 55);
            this.lblsRemark.Name = "lblsRemark";
            this.lblsRemark.Size = new System.Drawing.Size(24, 14);
            this.lblsRemark.TabIndex = 8;
            this.lblsRemark.Text = "备注";
            // 
            // mtxtsRemark
            // 
            this.mtxtsRemark.Location = new System.Drawing.Point(76, 53);
            this.mtxtsRemark.Name = "mtxtsRemark";
            this.mtxtsRemark.Size = new System.Drawing.Size(290, 96);
            this.mtxtsRemark.TabIndex = 9;
            this.mtxtsRemark.EditValueChanged += new System.EventHandler(this.mtxtsRemark_EditValueChanged);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(871, 498);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmTest";
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfo)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDataFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsTest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtsRemark.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunrise.ERP.Controls.SunriseGridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMain;
        private DevExpress.XtraEditors.TextEdit txtsTest;
        private DevExpress.XtraEditors.LabelControl lblsTest;
        private DevExpress.XtraEditors.MemoEdit mtxtsRemark;
        private DevExpress.XtraEditors.LabelControl lblsRemark;
    }
}
