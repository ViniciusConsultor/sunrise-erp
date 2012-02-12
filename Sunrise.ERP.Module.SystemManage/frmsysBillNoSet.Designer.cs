namespace Sunrise.ERP.Module.SystemManage
{
    partial class frmsysBillNoSet
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtsFieldName = new DevExpress.XtraEditors.TextEdit();
            this.txtPreFormatStr = new DevExpress.XtraEditors.TextEdit();
            this.lkpDateFormatStr = new Sunrise.ERP.Controls.SunriseLookUp();
            this.lkpTableName = new Sunrise.ERP.Controls.SunriseLookUp();
            this.txtNoFormatStr = new DevExpress.XtraEditors.TextEdit();
            this.lkpFormID = new Sunrise.ERP.Controls.SunriseLookUp();
            this.txtFormID = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcMain = new Sunrise.ERP.Controls.SunriseGridControl();
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coliFormID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsMenuName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsTableName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsFieldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsDateType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsSerialType = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfo)).BeginInit();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtsFieldName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreFormatStr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoFormatStr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.layoutControl1);
            this.pnlInfo.Size = new System.Drawing.Size(753, 130);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gcMain);
            this.pnlGrid.Location = new System.Drawing.Point(2, 171);
            this.pnlGrid.Size = new System.Drawing.Size(753, 325);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(2, 165);
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
            this.btnPrint.Location = new System.Drawing.Point(613, 3);
            this.btnPrint.LookAndFeel.SkinName = "Blue";
            this.btnPrint.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPrint.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(502, 4);
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
            this.btnProperty.LookAndFeel.SkinName = "Blue";
            this.btnProperty.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // panelControl1
            // 
            this.panelControl1.LookAndFeel.SkinName = "Blue";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtsFieldName);
            this.layoutControl1.Controls.Add(this.txtPreFormatStr);
            this.layoutControl1.Controls.Add(this.lkpDateFormatStr);
            this.layoutControl1.Controls.Add(this.lkpTableName);
            this.layoutControl1.Controls.Add(this.txtNoFormatStr);
            this.layoutControl1.Controls.Add(this.lkpFormID);
            this.layoutControl1.Controls.Add(this.txtFormID);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.LookAndFeel.SkinName = "Blue";
            this.layoutControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(749, 126);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtsFieldName
            // 
            this.txtsFieldName.Location = new System.Drawing.Point(64, 37);
            this.txtsFieldName.Name = "txtsFieldName";
            this.txtsFieldName.Size = new System.Drawing.Size(287, 21);
            this.txtsFieldName.StyleController = this.layoutControl1;
            this.txtsFieldName.TabIndex = 11;
            // 
            // txtPreFormatStr
            // 
            this.txtPreFormatStr.Location = new System.Drawing.Point(64, 62);
            this.txtPreFormatStr.Name = "txtPreFormatStr";
            this.txtPreFormatStr.Size = new System.Drawing.Size(287, 21);
            this.txtPreFormatStr.StyleController = this.layoutControl1;
            this.txtPreFormatStr.TabIndex = 8;
            // 
            // lkpDateFormatStr
            // 
            this.lkpDateFormatStr.DataField = null;
            this.lkpDateFormatStr.DisplayField = null;
            this.lkpDateFormatStr.EditFormFilter = null;
            this.lkpDateFormatStr.EditFormID = 0;
            this.lkpDateFormatStr.EditFormName = null;
            this.lkpDateFormatStr.EditValue = "";
            this.lkpDateFormatStr.GridColumnText = null;
            this.lkpDateFormatStr.GridDisplayField = null;
            this.lkpDateFormatStr.Location = new System.Drawing.Point(407, 37);
            this.lkpDateFormatStr.Name = "lkpDateFormatStr";
            this.lkpDateFormatStr.SearchFormFilter = "";
            this.lkpDateFormatStr.SearchFormText = "";
            this.lkpDateFormatStr.Size = new System.Drawing.Size(330, 21);
            this.lkpDateFormatStr.SQL = null;
            this.lkpDateFormatStr.TabIndex = 7;
            this.lkpDateFormatStr.TextFont = new System.Drawing.Font("Tahoma", 9F);
            // 
            // lkpTableName
            // 
            this.lkpTableName.DataField = null;
            this.lkpTableName.DisplayField = null;
            this.lkpTableName.EditFormFilter = null;
            this.lkpTableName.EditFormID = 0;
            this.lkpTableName.EditFormName = null;
            this.lkpTableName.EditValue = "";
            this.lkpTableName.GridColumnText = null;
            this.lkpTableName.GridDisplayField = null;
            this.lkpTableName.Location = new System.Drawing.Point(407, 12);
            this.lkpTableName.Name = "lkpTableName";
            this.lkpTableName.SearchFormFilter = "";
            this.lkpTableName.SearchFormText = "";
            this.lkpTableName.Size = new System.Drawing.Size(330, 21);
            this.lkpTableName.SQL = null;
            this.lkpTableName.TabIndex = 5;
            this.lkpTableName.TextFont = new System.Drawing.Font("Tahoma", 9F);
            // 
            // txtNoFormatStr
            // 
            this.txtNoFormatStr.Location = new System.Drawing.Point(407, 62);
            this.txtNoFormatStr.Name = "txtNoFormatStr";
            this.txtNoFormatStr.Size = new System.Drawing.Size(330, 21);
            this.txtNoFormatStr.StyleController = this.layoutControl1;
            this.txtNoFormatStr.TabIndex = 9;
            // 
            // lkpFormID
            // 
            this.lkpFormID.DataField = null;
            this.lkpFormID.DisplayField = null;
            this.lkpFormID.EditFormFilter = null;
            this.lkpFormID.EditFormID = 0;
            this.lkpFormID.EditFormName = null;
            this.lkpFormID.EditValue = "";
            this.lkpFormID.GridColumnText = null;
            this.lkpFormID.GridDisplayField = null;
            this.lkpFormID.Location = new System.Drawing.Point(64, 12);
            this.lkpFormID.Name = "lkpFormID";
            this.lkpFormID.SearchFormFilter = "";
            this.lkpFormID.SearchFormText = "";
            this.lkpFormID.Size = new System.Drawing.Size(222, 21);
            this.lkpFormID.SQL = null;
            this.lkpFormID.TabIndex = 4;
            this.lkpFormID.TextFont = new System.Drawing.Font("Tahoma", 9F);
            // 
            // txtFormID
            // 
            this.txtFormID.Location = new System.Drawing.Point(290, 12);
            this.txtFormID.Name = "txtFormID";
            this.txtFormID.Properties.ReadOnly = true;
            this.txtFormID.Properties.Tag = "99";
            this.txtFormID.Size = new System.Drawing.Size(61, 21);
            this.txtFormID.StyleController = this.layoutControl1;
            this.txtFormID.TabIndex = 10;
            this.txtFormID.Tag = "99";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(749, 126);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lkpTableName;
            this.layoutControlItem2.CustomizationFormText = "数据表名";
            this.layoutControlItem2.Location = new System.Drawing.Point(343, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(386, 25);
            this.layoutControlItem2.Text = "数据表名";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtPreFormatStr;
            this.layoutControlItem5.CustomizationFormText = "前缀字符";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(343, 25);
            this.layoutControlItem5.Text = "前缀字符";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtNoFormatStr;
            this.layoutControlItem6.CustomizationFormText = "序号格式";
            this.layoutControlItem6.Location = new System.Drawing.Point(343, 50);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(386, 25);
            this.layoutControlItem6.Text = "序号格式";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 75);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(729, 31);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtsFieldName;
            this.layoutControlItem3.CustomizationFormText = "字段名称";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(343, 25);
            this.layoutControlItem3.Text = "字段名称";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lkpDateFormatStr;
            this.layoutControlItem4.CustomizationFormText = "日期格式";
            this.layoutControlItem4.Location = new System.Drawing.Point(343, 25);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(386, 25);
            this.layoutControlItem4.Text = "日期格式";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lkpFormID;
            this.layoutControlItem1.CustomizationFormText = "单据名称";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(278, 25);
            this.layoutControlItem1.Text = "单据名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtFormID;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(278, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(65, 25);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // gcMain
            // 
            this.gcMain.DataSource = this.dsMain;
            this.gcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMain.Location = new System.Drawing.Point(2, 2);
            this.gcMain.MainView = this.gvMain;
            this.gcMain.Name = "gcMain";
            this.gcMain.Size = new System.Drawing.Size(749, 321);
            this.gcMain.TabIndex = 2;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coliFormID,
            this.colsMenuName,
            this.colsTableName,
            this.colsFieldName,
            this.colsDateType,
            this.colsPrefix,
            this.colsSerialType});
            this.gvMain.GridControl = this.gcMain;
            this.gvMain.Name = "gvMain";
            this.gvMain.OptionsBehavior.Editable = false;
            this.gvMain.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvMain.OptionsView.ColumnAutoWidth = false;
            this.gvMain.OptionsView.ShowAutoFilterRow = true;
            this.gvMain.OptionsView.ShowFooter = true;
            this.gvMain.OptionsView.ShowGroupPanel = false;
            // 
            // coliFormID
            // 
            this.coliFormID.Caption = "FormID";
            this.coliFormID.FieldName = "iFormID";
            this.coliFormID.Name = "coliFormID";
            this.coliFormID.Visible = true;
            this.coliFormID.VisibleIndex = 0;
            // 
            // colsMenuName
            // 
            this.colsMenuName.Caption = "单据名称";
            this.colsMenuName.FieldName = "sMenuName";
            this.colsMenuName.Name = "colsMenuName";
            this.colsMenuName.Visible = true;
            this.colsMenuName.VisibleIndex = 1;
            this.colsMenuName.Width = 120;
            // 
            // colsTableName
            // 
            this.colsTableName.Caption = "数据表名";
            this.colsTableName.FieldName = "sTableName";
            this.colsTableName.Name = "colsTableName";
            this.colsTableName.Visible = true;
            this.colsTableName.VisibleIndex = 2;
            this.colsTableName.Width = 134;
            // 
            // colsFieldName
            // 
            this.colsFieldName.Caption = "字段名称";
            this.colsFieldName.FieldName = "sFieldName";
            this.colsFieldName.Name = "colsFieldName";
            this.colsFieldName.Visible = true;
            this.colsFieldName.VisibleIndex = 3;
            this.colsFieldName.Width = 107;
            // 
            // colsDateType
            // 
            this.colsDateType.Caption = "日期格式";
            this.colsDateType.FieldName = "sDateType";
            this.colsDateType.Name = "colsDateType";
            this.colsDateType.Visible = true;
            this.colsDateType.VisibleIndex = 4;
            this.colsDateType.Width = 136;
            // 
            // colsPrefix
            // 
            this.colsPrefix.Caption = "前缀字符";
            this.colsPrefix.FieldName = "sPrefix";
            this.colsPrefix.Name = "colsPrefix";
            this.colsPrefix.Visible = true;
            this.colsPrefix.VisibleIndex = 5;
            // 
            // colsSerialType
            // 
            this.colsSerialType.Caption = "序号格式";
            this.colsSerialType.FieldName = "sSerialType";
            this.colsSerialType.Name = "colsSerialType";
            this.colsSerialType.Visible = true;
            this.colsSerialType.VisibleIndex = 6;
            // 
            // frmsysBillNoSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(757, 498);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmsysBillNoSet";
            this.Text = "单据编号规则";
            this.Load += new System.EventHandler(this.frmsysBillNoSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfo)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDataFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtsFieldName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreFormatStr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoFormatStr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private Sunrise.ERP.Controls.SunriseLookUp lkpTableName;
        private Sunrise.ERP.Controls.SunriseLookUp lkpFormID;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtPreFormatStr;
        private Sunrise.ERP.Controls.SunriseLookUp lkpDateFormatStr;
        private DevExpress.XtraEditors.TextEdit txtNoFormatStr;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.TextEdit txtFormID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private Sunrise.ERP.Controls.SunriseGridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMain;
        private DevExpress.XtraGrid.Columns.GridColumn coliFormID;
        private DevExpress.XtraGrid.Columns.GridColumn colsTableName;
        private DevExpress.XtraGrid.Columns.GridColumn colsFieldName;
        private DevExpress.XtraGrid.Columns.GridColumn colsDateType;
        private DevExpress.XtraGrid.Columns.GridColumn colsPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colsSerialType;
        private DevExpress.XtraEditors.TextEdit txtsFieldName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn colsMenuName;
    }
}
