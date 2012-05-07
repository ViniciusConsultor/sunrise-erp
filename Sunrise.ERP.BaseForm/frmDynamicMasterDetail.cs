using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Sunrise.ERP.Security;
using Sunrise.ERP.BasePublic;
using Sunrise.ERP.Lang;
using Sunrise.ERP.BaseControl;
using Sunrise.ERP.BaseForm.DAL;
using Sunrise.ERP.DataAccess;
using Sunrise.ERP.Controls;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;

namespace Sunrise.ERP.BaseForm
{
    public partial class frmDynamicMasterDetail : frmDynamicSingleForm
    {
        #region 定义
        /// <summary>
        /// 明细数据集集合
        /// </summary>
        public List<BindingSource> LDetailBindingSource = new List<BindingSource>();
        /// <summary>
        /// 从表字段集合
        /// </summary>
        public List<string> LDetailField = new List<string>();
        /// <summary>
        /// 主表字段集合
        /// </summary>
        public List<string> LMasterField = new List<string>();
        /// <summary>
        /// 明细表数据表名集合
        /// </summary>
        public List<string> LDetailTableName = new List<string>();
        /// <summary>
        /// 明细数据操作层集合
        /// </summary>
        public List<DynamicDALSetting> LDetailDynamicDAL = new List<DynamicDALSetting>();
        /// <summary>
        /// 动态明细表结构数据集合
        /// </summary>
        public List<DataTable> LDynamicDetailTableData = new List<DataTable>();
        /// <summary>
        /// 明细表排序字段集合
        /// </summary>
        public Hashtable DetailOrderField = new Hashtable();

        private bool CanCloseWindow = true;

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmDynamicMasterDetail()
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        public frmDynamicMasterDetail(int formid, string tablename)
            : base(formid, tablename)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmDynamicMasterDetail(int formid, string tablename, bool ischeckauth)
            : base(formid, tablename, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmDynamicMasterDetail(int formid, string tablename, string pwhere, bool ischeckauth)
            : base(formid, tablename, pwhere, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        public frmDynamicMasterDetail(int formid, string tablename, string pwhere)
            : base(formid, tablename, pwhere)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="sortfield">排序字段</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmDynamicMasterDetail(int formid, string tablename, string pwhere, string sortfield, bool ischeckauth)
            : base(formid, tablename, pwhere, sortfield, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="sortfield">排序字段</param>
        public frmDynamicMasterDetail(int formid, string tablename, string pwhere, string sortfield)
            : base(formid, tablename, pwhere, sortfield)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="top">前多少数据</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="sortfield">排序字段</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmDynamicMasterDetail(int formid, string tablename, int top, string pwhere, string sortfield, bool ischeckauth)
            : base(formid, tablename, top, pwhere, sortfield, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="top">前多少数据</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="sortfield">排序字段</param>
        public frmDynamicMasterDetail(int formid, string tablename, int top, string pwhere, string sortfield)
            : base(formid, tablename, top, pwhere, sortfield)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        #endregion

        #region 窗体公共设置方法
        /// <summary>
        /// 增加明细数据表
        /// 关联字段一定是要一一对应，否则系统无法建立其关系
        /// </summary>
        /// <param name="tablename">明细表名称</param>
        /// <param name="detailfield">主从表关联字段-从表字段</param>
        /// <param name="masterfield">主从表关联字段-主表字段</param>
        public void AddDetailData(string tablename, string detailfield, string masterfield)
        {
            LDetailTableName.Add(tablename);
            LDetailField.Add(detailfield);
            LMasterField.Add(masterfield);
            DataTable dtTmp = Base.GetDynamicTableData(FormID, tablename);
            LDynamicDetailTableData.Add(dtTmp);
            DynamicDALSetting DALobj = new DynamicDALSetting(dtTmp);
            LDetailDynamicDAL.Add(DALobj);
            LDetailBindingSource.Add(new BindingSource(GetDataSet(DALobj, detailfield + "=" + GetMasterLinkValue(masterfield)), "ds"));
        }

        /// <summary>
        /// 增加明细数据表
        /// 关联字段一定是要一一对应，否则系统无法建立其关系
        /// </summary>
        /// <param name="tablename">明细表名称</param>
        /// <param name="detailfield">主从表关联字段-从表字段</param>
        /// <param name="masterfield">主从表关联字段-主表字段</param>
        /// <param name="sortfield">明细表排序字段，可以多个，e.g:ID DESC,OrderNo</param>
        public void AddDetailData(string tablename, string detailfield, string masterfield, string sortfield)
        {
            LDetailTableName.Add(tablename);
            LDetailField.Add(detailfield);
            LMasterField.Add(masterfield);
            DataTable dtTmp = Base.GetDynamicTableData(FormID, tablename);
            LDynamicDetailTableData.Add(dtTmp);
            DynamicDALSetting DALobj = new DynamicDALSetting(dtTmp);
            LDetailDynamicDAL.Add(DALobj);
            string swhere = sortfield != "" ? detailfield + "=" + GetMasterLinkValue(masterfield) + " ORDER BY " + sortfield : detailfield + "=" + GetMasterLinkValue(masterfield);
            LDetailBindingSource.Add(new BindingSource(GetDataSet(DALobj, swhere), "ds"));
        }

        /// <summary>
        /// 主表数据滚动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void MasterAllScroll(object sender, EventArgs e)
        {
            try
            {
                if (dsMain.Current != null)
                {
                    BillID = ((DataRowView)(dsMain.Current))["ID"].ToString() == "" ? 0 : Convert.ToInt32(((DataRowView)(dsMain.Current))["ID"]);
                    //根据主表与从表的关系字段刷新从表数据
                    if (LDetailBindingSource.Count > 0)
                    {
                        for (int i = 0; i < LDetailBindingSource.Count; i++)
                        {
                            string swhere = "";
                            swhere = LDetailField[i] + "=" + GetMasterLinkValue(LMasterField[i]);
                            if (DetailOrderField[LDetailTableName[i]] != null && DetailOrderField[LDetailTableName[i]].ToString() != "")
                                swhere += " ORDER BY " + DetailOrderField[LDetailTableName[i]].ToString();
                            
                            //很奇怪的问题，必须先清除再重新设置其数据源
                            ((DataSet)LDetailBindingSource[i].DataSource).Tables.Clear();
                            LDetailBindingSource[i].DataSource = GetDataSet(LDetailDynamicDAL[i], swhere);
                        }
                    }
                    else
                        return;
                }
                else
                {
                    //当主表数据为空时清空所有明细数据
                    for (int i = 0; i < LDetailBindingSource.Count; i++)
                    {
                        ((DataSet)LDetailBindingSource[i].DataSource).Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Public.SystemInfo("MasterAllScroll-" + ex.Message, true);
            }
        }
        /// <summary>
        /// 取得主从连接主表连接字段值
        /// </summary>
        /// <param name="masterfield">主表连接字段</param>
        /// <returns></returns>
        public string GetMasterLinkValue(string masterfield)
        {
            string sResult = "";
            if (masterfield.Trim().ToUpper() == "ID")
                sResult = BillID.ToString();
            else
            {
                try
                {
                    sResult = GetDataSet(MasterDynamicDAL, 1, "ID=" + BillID.ToString(), "ID").Tables[0].Rows[0][masterfield].ToString();
                }
                catch (Exception)
                {
                    Public.SystemInfo("主从表连接字段设置错误！", true);
                }
            }
            return sResult;
        }

        /// <summary>
        /// 显示主表Grid
        /// </summary>
        public void ShowLeft()
        {
            SetButtonVisiable(true);
            pnlDetail.Visible = false;
            sptUpDown.Visible = false;
            pnlMain.Visible = false;
            pnlGrid.Visible = true;
            pnlGrid.Dock = DockStyle.Fill;
            sptLeftRight.Visible = false;
            CanCloseWindow = true;
        }
        /// <summary>
        /// 显示数据操作部分
        /// </summary>
        public void ShowRight()
        {
            SetButtonVisiable(false);
            pnlMain.Visible = true;
            sptUpDown.Visible = true;
            pnlDetail.Visible = true;
            pnlGrid.Visible = false;
            sptLeftRight.Visible = false;
            CanCloseWindow = false;
        }

        private void SetButtonVisiable(bool isMaster)
        {
            if (isMaster)
            {
                btnView.Visible = true;
                btnView.Location = new Point(5, 4);
                btnAdd.Visible = true;
                btnAdd.Location = new Point(76, 4);
                btnEdit.Visible = true;
                btnEdit.Location = new Point(147, 4);
                btnDelete.Visible = false;
                btnCopy.Visible = true;
                btnCopy.Location = new Point(218, 4);
                btnCancel.Visible = false;
                btnSave.Visible = false;
                btnPrint.Visible = false;
                btnAction.Visible = true;
                btnAction.Location = new Point(289, 4);
                btnClose.Visible = true;
                btnClose.Location = new Point(372, 4);
                dataNav.Visible = true;
                dataNav.Location = new Point(443, 4);

                btnProperty.Location = new Point(570, 4);
            }
            else
            {
                btnView.Visible = false;
                btnAdd.Visible = true;
                btnAdd.Location = new Point(5, 4);
                btnEdit.Visible = true;
                btnEdit.Location = new Point(76, 4);
                btnDelete.Visible = true;
                btnDelete.Location = new Point(147, 4);
                btnCopy.Visible = true;
                btnCopy.Location = new Point(218, 4);
                btnCancel.Visible = true;
                btnCancel.Location = new Point(289, 4);
                btnSave.Visible = true;
                btnSave.Location = new Point(360, 4);
                btnPrint.Visible = true;
                btnPrint.Location = new Point(431, 4);
                btnAction.Visible = true;
                btnAction.Location = new Point(502, 4);
                btnClose.Visible = true;
                btnClose.Location = new Point(585, 4);
                dataNav.Visible = true;
                dataNav.Location = new Point(656, 4);

                btnProperty.Location = new Point(783, 4);
            }
        }

        #endregion

        #region 数据操作方法
        public override bool DoSave()
        {
            try
            {
                //先保存主表
                if (FormDataFlag == DataFlag.dsInsert)
                    BillID = Add(MasterDynamicDAL, ((DataRowView)dsMain.Current).Row, SqlTrans);
                else
                    Update(MasterDynamicDAL, ((DataRowView)dsMain.Current).Row, SqlTrans);
                //保存从表
                for (int i = 0; i < LDetailBindingSource.Count; i++)
                {
                    foreach (DataRow dr in ((DataSet)LDetailBindingSource[i].DataSource).Tables[0].Rows)
                    {
                        //增加
                        if (dr.RowState == DataRowState.Added && dr["ID"].ToString()=="")
                        {
                            dr[LDetailField[i]] = GetMasterLinkValue(LMasterField[i]);
                            dr["ID"] = Add(LDetailDynamicDAL[i], dr, SqlTrans);
                        }
                        //更新
                        else if (dr.RowState == DataRowState.Modified && dr["ID"].ToString() != "")
                            Update(LDetailDynamicDAL[i], dr, SqlTrans);
                        //删除
                        else if (dr.RowState == DataRowState.Deleted && dr["ID", DataRowVersion.Original].ToString() != "")
                            Delete(LDetailDynamicDAL[i], Convert.ToInt32(dr["ID", DataRowVersion.Original]), SqlTrans);
                    }
                }
                return true;
            }
            catch
            {
                //回收Trans
                if (SqlTrans != null)
                    SqlTrans.Dispose();
                return false;
            }
        }

        public override void DoEdit()
        {
            ShowRight();
            base.DoEdit();
        }

        public override void DoAdd()
        {
            ShowRight();
            base.DoAdd();
        }

        public override void DoCopy()
        {
            ShowRight();
            base.DoCopy();
        }

        public override bool DoBeforeClose()
        {
            if (!CanCloseWindow)
            {
                if (FormDataFlag != DataFlag.dsBrowse)
                {
                    if (base.DoBeforeCancel())
                    {
                        ShowLeft();
                        base.DoCancel();
                        FormDataFlag = DataFlag.dsBrowse;
                        txtDataFlag.Text = FormDataFlag.ToString();
                        IsDataChange = false;
                    }
                }
                else
                    ShowLeft();
                return false;
            }
            else
                return base.DoBeforeClose();
        }

        public override bool DoBeforeSave()
        {
            bool result = false;
            //非空验证
            if (dsMain.Current != null)
            {
                //主表非空验证
                foreach (DataRow dr in DynamicMasterTableData.Select("bSaveData=1 AND bNotNull=1"))
                {
                    if (string.IsNullOrEmpty(((DataRowView)dsMain.Current).Row[dr["sFieldName"].ToString()].ToString()))
                    {
                        string sMsg = string.Format("{0} {1}", LangCenter.Instance.IsDefaultLanguage ? dr["sCaption"].ToString() : dr["sEngCaption"].ToString(),
                                      LangCenter.Instance.GetSystemMessage("NotNull"));
                        Public.SystemInfo(sMsg);
                        return false;
                    }
                }
                //从表的非空验证
                for (int i = 0; i < LDynamicDetailTableData.Count; i++)
                {
                    foreach (DataRow dr in LDynamicDetailTableData[i].Select("bSaveData=1 AND bNotNull=1"))
                    {
                        foreach (DataRow drData in ((DataSet)LDetailBindingSource[i].DataSource).Tables[0].Rows)
                        {
                            if (string.IsNullOrEmpty(drData[dr["sFieldName"].ToString()].ToString()))
                            {
                                string sMsg = string.Format("{0} {1}", LangCenter.Instance.IsDefaultLanguage ? dr["sCaption"].ToString() : dr["sEngCaption"].ToString(),
                                              LangCenter.Instance.GetSystemMessage("NotNull"));
                                Public.SystemInfo(sMsg);
                                return false;
                            }
                        }
                    }
                }
            }
            if (SqlTrans != null)
                SqlTrans.Dispose();
            SqlTrans = ConnectSetting.SysSqlConnection.BeginTransaction();
            try
            {
                result = DoBeforceSaveInTrans(SqlTrans);
            }
            catch
            {
                SqlTrans.Rollback();
                //回收Trans
                if (SqlTrans != null)
                    SqlTrans.Dispose();
                return false;
            }
            return result;
        }

        #endregion

        #region 窗体自定义设置
        /// <summary>
        /// 创建明细数据表Grid列
        /// </summary>
        /// <param name="gv">需要创建的Grid</param>
        /// <param name="tablename">明细数据表名称</param>
        public void CreateDetailGridColumn(GridView gv, string tablename)
        {
            CreateDetailGridColumn(gv, LDetailBindingSource[LDetailTableName.IndexOf(tablename)], LDynamicDetailTableData[LDetailTableName.IndexOf(tablename)], tablename);
        }

        /// <summary>
        /// 创建明细数据表Grid列
        /// </summary>
        /// <param name="gv">需要创建的Grid</param>
        /// <param name="tabledata">明细自定义数据</param>
        /// <param name="tablename">明细数据表名称</param>
        public void CreateDetailGridColumn(GridView gv,BindingSource ds,  DataTable tabledata,string tablename)
        {
            gv.Columns.Clear();
            int iIndex = 0;
            string sFilter = "bShowInGrid=1 AND sTableName='" + tablename + "'";
            DataRow[] drs = tabledata.Select(sFilter);
            foreach (DataRow dr in drs)
            {
                GridColumn cols = null;
                DataRow[] drFields = FormFieldSetting.Select("sTableName='" + tablename + "'");
                //如果没有设置过界面字段数据
                if (drFields.Length == 0)
                {
                    cols = CreateGridColumn(gv, dr, ds, tablename, iIndex, true);
                    iIndex++;
                }

                foreach (DataRow drField in drFields)
                {
                    if (dr["sFieldName"].ToString() == drField["sFieldName"].ToString())
                    {
                        if (Convert.ToBoolean(drField["bVisiable"]))
                        {
                            cols = CreateGridColumn(gv, dr, ds,tablename, iIndex, Convert.ToBoolean(drField["bEdit"]));
                            iIndex++;
                        }
                    }
                }

                if (cols != null)
                    gv.Columns.Add(cols);
            }
        }

        private GridColumn CreateGridColumn(GridView gv, DataRow dr, BindingSource ds, string tablename, int index, bool isuseredit)
        {
            //******************************特别提示*********************************************
            //Tip:如果要在Grid中取得自定义添加的控件，例如lkp,cbx,mtxt,btxt,mlkp控件
            //lkp控件：用Controls.Find()方法来查找出lkp控件
            //其他类型：用GridControl.RepositoryItems集合中查找
            //***********************************************************************************
            GridColumn cols = new GridColumn();
            string sControlType = dr["sControlType"].ToString();
            switch (sControlType)
            {
                //LookUp查询
                case "lkp":
                    {
                        if (!string.IsNullOrEmpty(dr["sLookupNo"].ToString()))
                        {
                            SunriseLookUp lkp = new SunriseLookUp();
                            lkp.Name = "collkp" + tablename + dr["sFieldName"].ToString();
                            lkp.DataBindings.Add("EditValue", ds, dr["sFieldName"].ToString());
                            this.Controls.Add(lkp);
                            Base.InitLookup(lkp, dr["sLookupNo"].ToString());
                            if (!string.IsNullOrEmpty(dr["sLookupAutoSetControl"].ToString()))
                            {
                                string[] sItem = Public.GetSplitString(dr["sLookupAutoSetControl"].ToString(), ",");
                                foreach (var s in sItem)
                                {
                                    string[] ss = Public.GetSplitString(s, "=");
                                    lkp.AutoSetValue(ss[0], ss[1]);
                                }
                            }
                            RepositoryItemButtonEdit btnRepositoryItem = new RepositoryItemButtonEdit();
                            btnRepositoryItem.ButtonClick += lkp.LookUpSelfClick;
                            btnRepositoryItem.TextEditStyle = TextEditStyles.DisableTextEditor;
                            //加这句是让了焦点更新，Grid中才会显示新的数据值，其实在后台是已经存在了的，只是在Grid中没有显示出来
                            //此处设置为查询完成后自动跳转到Grid中的下一列中
                            lkp.LookUpAfterPost += new SunriseLookUp.SunriseLookUpEvent(lkp_LookUpAfterPost);
                            cols.ColumnEdit = btnRepositoryItem;
                            gv.GridControl.RepositoryItems.Add(btnRepositoryItem);
                        }
                        break;
                    }
                //下拉框
                case "cbx":
                    {
                        if (!string.IsNullOrEmpty(dr["sLookupNo"].ToString()))
                        {
                            RepositoryItemImageComboBox cbxRepositoryItem = new RepositoryItemImageComboBox();
                            cbxRepositoryItem.Name = "colcbx" + tablename + dr["sFieldName"].ToString();
                            Base.InitRepositoryItemComboBox(cbxRepositoryItem, dr["sLookupNo"].ToString(), dr["sFieldType"].ToString());
                            cols.ColumnEdit = cbxRepositoryItem;
                            gv.GridControl.RepositoryItems.Add(cbxRepositoryItem);
                        }
                        break;
                    }
                //带按钮的文本框
                case "btxt":
                    {
                        RepositoryItemButtonEdit btxtRepositoryItem = new RepositoryItemButtonEdit();
                        btxtRepositoryItem.Name = "colbtxt" + tablename + dr["sFieldName"].ToString();
                        cols.ColumnEdit = btxtRepositoryItem;
                        gv.GridControl.RepositoryItems.Add(btxtRepositoryItem);
                        break;
                    }
                //多行文本框
                case "mtxt":
                    {
                        RepositoryItemMemoExEdit btxtRepositoryItem = new RepositoryItemMemoExEdit();
                        btxtRepositoryItem.Name = "colmtxt" + tablename + dr["sFieldName"].ToString();
                        cols.ColumnEdit = btxtRepositoryItem;
                        gv.GridControl.RepositoryItems.Add(btxtRepositoryItem);
                        break;
                    }
                //MLookUp查询
                case "mlkp":
                    {
                        if (!string.IsNullOrEmpty(dr["sLookupNo"].ToString()))
                        {
                            SunriseMLookUp mlkp = new SunriseMLookUp();
                            mlkp.Name = "colmlkp" + tablename + dr["sFieldName"].ToString();
                            mlkp.DataBindings.Add("EditValue", ds, dr["sFieldName"].ToString());
                            mlkp.IsUsedInGrid = true;
                            
                            Base.InitMLookup(mlkp, dr["sLookupNo"].ToString());
                            if (!string.IsNullOrEmpty(dr["sLookupAutoSetControl"].ToString()))
                            {
                                string[] sItem = Public.GetSplitString(dr["sLookupAutoSetControl"].ToString(), ",");
                                foreach (var s in sItem)
                                {
                                    string[] ss = Public.GetSplitString(s, "=");
                                    mlkp.AutoSetValue(ss[0], ss[1]);
                                }
                            }
                            RepositoryItemPopupContainerEdit btnRepositoryItem = new RepositoryItemPopupContainerEdit();
                            btnRepositoryItem.Name = "gridmlkp" + tablename + dr["sFieldName"].ToString();
                            //原本默认的显示Popup的按钮隐藏掉
                            btnRepositoryItem.Buttons[0].Visible = false;
                            btnRepositoryItem.Buttons.Add(new EditorButton(ButtonPredefines.Ellipsis));
                            btnRepositoryItem.ButtonClick += mlkp.LookUpSelfClick;
                            btnRepositoryItem.TextEditStyle = TextEditStyles.Standard;
                            btnRepositoryItem.Popup += mlkp.mlkpDataNo_Popup;
                            btnRepositoryItem.KeyDown += mlkp.mlkpDataNo_KeyDown;
                            btnRepositoryItem.Closed += mlkp.mlkpDataNo_Closed;
                            gv.GridControl.PreviewKeyDown += mlkp.mlkpDataNo_PreviewKeyDown;
                            
                            btnRepositoryItem.PopupControl = mlkp.mlkpPopup;
                            btnRepositoryItem.EditValueChanged += mlkp.mlkpDataNo_TextChanged;
                            
                            //加这句是让了焦点更新，Grid中才会显示新的数据值，其实在后台是已经存在了的，只是在Grid中没有显示出来
                            //此处设置为查询完成后自动跳转到Grid中的下一列中
                            mlkp.LookUpAfterPost += new SunriseLookUp.SunriseLookUpEvent(lkp_LookUpAfterPost);
                            cols.ColumnEdit = btnRepositoryItem;
                            gv.GridControl.RepositoryItems.Add(btnRepositoryItem);
                            this.Controls.Add(mlkp);
                            
                            //pnlDynamic.Controls.Add(mlkp);
                            //mlkp.Visible = false;
                        }
                        break;
                    }
            }
            cols.Caption = LangCenter.Instance.IsDefaultLanguage ? dr["sCaption"].ToString() : dr["sEngCaption"].ToString();
            cols.FieldName = dr["sFieldName"].ToString();
            //Grid 列命名为col+表名+列名
            cols.Name = "col" + tablename + dr["sFieldName"].ToString();
            cols.Width = 120;
            if (dr["sColumnType"].ToString() == "002")
            {
                //检测是否有价格权限
                bool HasPrice = SC.CheckAuth(SecurityOperation.Price, FormID);
                if (!HasPrice) return null;

                //设置价格数据显示格式
                cols.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                cols.DisplayFormat.FormatString = Base.FormatPrice;
            }
            else if (dr["sColumnType"].ToString() == "003")
            {
                //检测是否有数量权限
                bool HasNum = SC.CheckAuth(SecurityOperation.Num, FormID);
                if (!HasNum) return null;

                //设置数量数据显示格式
                cols.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                cols.DisplayFormat.FormatString = Base.FormatQuantity;
            }
            else
                cols.Visible = true;

            //不需要权限控制的价格数量显示格式化
            //无权限控制价格
            if (dr["sColumnType"].ToString() == "004")
            {
                cols.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                cols.DisplayFormat.FormatString = Base.FormatNullAuthPrice;
            }
            //无权限控制数量
            else if (dr["sColumnType"].ToString() == "005")
            {
                cols.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                cols.DisplayFormat.FormatString = Base.FormatNullAuthQuantity;
            }

            cols.VisibleIndex = index;

            //检测窗体字段设置中是否可编辑
            //这里检测的时候是先以窗体设置中的权限优先，窗体上设置不可编辑，用户字段设置可编辑，以窗体上设置为准，不可编辑
            cols.OptionsColumn.AllowEdit = Convert.ToBoolean(dr["bEdit"]);
            //先通过数量和价格权限检测后再设置其用户字段权限
            if (Convert.ToBoolean(dr["bEdit"]))
            {
                cols.OptionsColumn.AllowEdit = isuseredit;
            }

            //Grid Footer显示
            if (dr["sFooterType"].ToString() != "001")
            {
                //001	无
                //002	求和
                //003	计数
                //004	平均值
                //005	最大值
                //006	最小值                   
                cols.SummaryItem.FieldName = dr["sFieldName"].ToString();
                if (dr["sFooterType"].ToString() == "002")
                    cols.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                else if (dr["sFooterType"].ToString() == "003")
                    cols.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                else if (dr["sFooterType"].ToString() == "004")
                    cols.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Average;
                else if (dr["sFooterType"].ToString() == "005")
                    cols.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Max;
                else if (dr["sFooterType"].ToString() == "006")
                    cols.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Min;
                
                //设置GridFooter汇总格式
                //价格
                if (dr["sColumnType"].ToString() == "002")
                    cols.SummaryItem.DisplayFormat = Base.FormatPrice;
                //数量
                else if (dr["sColumnType"].ToString() == "003")
                    cols.SummaryItem.DisplayFormat = Base.FormatQuantity;
                //无权限控制价格
                else if (dr["sColumnType"].ToString() == "004")
                    cols.SummaryItem.DisplayFormat = Base.FormatNullAuthPrice;
                //无权限控制数量
                else if (dr["sColumnType"].ToString() == "005")
                    cols.SummaryItem.DisplayFormat = Base.FormatNullAuthQuantity;

                gv.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, dr["sFieldName"].ToString(), cols);
            }

            //设置非空字段颜色
            if (Convert.ToBoolean(dr["bSaveData"]) && Convert.ToBoolean(dr["bNotNull"]))
            {
                cols.AppearanceHeader.ForeColor = Color.FromName(Base.GetSystemParamter("001"));
                cols.AppearanceHeader.Options.UseForeColor = true;
            }

            return cols;
        }

        //设置为查询完成后自动跳转到Grid中的下一列中
        bool lkp_LookUpAfterPost(object sender, ButtonPressedEventArgs e)
        {
            OnKeyDown(new KeyEventArgs(Keys.Enter));
            return true;
        }
        #endregion

    }
}
