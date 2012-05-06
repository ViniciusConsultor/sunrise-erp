using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SqlClient;
using System.Linq;

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
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace Sunrise.ERP.BaseForm
{
    public partial class frmDynamicSingleForm : frmBaseForm
    {
        #region 定义
        /// <summary>
        /// 主表数据
        /// </summary>
        protected DataTable dtMain;

        /// <summary>
        /// 权限处理定义
        /// </summary>
        protected SecurityCenter _sc;

        protected SqlTransaction SqlTrans;

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmDynamicSingleForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="top">前多少行数据</param>
        /// <param name="sortfield">排序字段</param>
        public frmDynamicSingleForm(int formid, string tablename, int top, string pwhere, string sortfield)
            : base(formid)
        {
            InitializeComponent();
            pWhere = pwhere;
            TopCount = top;
            SortField = sortfield;
            MasterTableName = tablename;
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(MasterDynamicDAL, top, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, sortfield).Tables[0];
            }
            else
            {
                dtMain = GetDataSet(MasterDynamicDAL, top, "1=1 " + pWhere, sortfield).Tables[0];
            }
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="top">前多少行数据</param>
        /// <param name="sortfield">排序字段</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmDynamicSingleForm(int formid, string tablename, int top, string pwhere, string sortfield, bool ischeckauth)
            : base(formid)
        {
            InitializeComponent();
            pWhere = pwhere;
            TopCount = top;
            SortField = sortfield;
            IsCheckAuth = ischeckauth;
            MasterTableName = tablename;
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(MasterDynamicDAL, top, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, sortfield).Tables[0];
            }
            else
            {
                dtMain = GetDataSet(MasterDynamicDAL, top, "1=1 " + pWhere, sortfield).Tables[0];
            }
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="sortfield">排序字段</param>
        public frmDynamicSingleForm(int formid, string tablename, string pwhere, string sortfield)
            : base(formid)
        {
            InitializeComponent();
            SortField = sortfield;
            pWhere = pwhere;
            SortField = sortfield;
            MasterTableName = tablename;
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(MasterDynamicDAL, 100000, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, SortField).Tables[0];
            }
            else
            {
                dtMain = GetDataSet(MasterDynamicDAL, "1=1 " + pWhere).Tables[0];
            }
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="sortfield">排序字段</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmDynamicSingleForm(int formid, string tablename, string pwhere, string sortfield, bool ischeckauth)
            : base(formid)
        {
            InitializeComponent();
            SortField = sortfield;
            pWhere = pwhere;
            SortField = sortfield;
            IsCheckAuth = ischeckauth;
            MasterTableName = tablename;
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(MasterDynamicDAL, 100000, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, SortField).Tables[0];
            }
            else
            {
                dtMain = GetDataSet(MasterDynamicDAL, "1=1 " + pWhere).Tables[0];
            }
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="dalname">数据表名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        public frmDynamicSingleForm(int formid, string tablename, string pwhere)
            : base(formid)
        {
            InitializeComponent();
            pWhere = pwhere;
            MasterTableName = tablename;
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(MasterDynamicDAL, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
            }
            else
            {
                dtMain = GetDataSet(MasterDynamicDAL, "1=1 " + pWhere).Tables[0];
            }
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="dalname">数据表名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmDynamicSingleForm(int formid, string tablename, string pwhere, bool ischeckauth)
            : base(formid)
        {
            InitializeComponent();
            pWhere = pwhere;
            IsCheckAuth = ischeckauth;
            MasterTableName = tablename;
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(MasterDynamicDAL, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
            }
            else
            {
                dtMain = GetDataSet(MasterDynamicDAL, "1=1 " + pWhere).Tables[0];
            }
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="dalname">数据表名称</param>
        public frmDynamicSingleForm(int formid, string tablename)
            : base(formid)
        {
            InitializeComponent();
            MasterTableName = tablename;
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(MasterDynamicDAL, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
            }
            else
            {
                dtMain = GetDataSet(MasterDynamicDAL, "1=1 " + pWhere).Tables[0];
            }
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="dalname">数据表名称</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmDynamicSingleForm(int formid, string tablename, bool ischeckauth)
            : base(formid)
        {
            InitializeComponent();
            IsCheckAuth = ischeckauth;
            MasterTableName = tablename;
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(MasterDynamicDAL, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
            }
            else
            {
                dtMain = GetDataSet(MasterDynamicDAL, "1=1 " + pWhere).Tables[0];
            }
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
        }

        /// <summary>
        /// 列改变-用于同步绑定数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dtMain_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            //e.Row.EndEdit();
        }
        #endregion

        #region 重写基本按钮状态控制
        /// <summary>
        /// 查询
        /// </summary>
        public override void DoView()
        {
            if (MasterFilterSQL != "")
            {
                if (TopCount != 499 && SortField != "dInputDate DESC")
                {
                    if (IsCheckAuth)
                    {
                        dtMain = GetDataSet(MasterDynamicDAL, TopCount, SC.GetAuthSQL(ShowType.FormQuery, FormID) + pWhere + MasterFilterSQL, SortField).Tables[0];
                    }
                    else
                    {
                        dtMain = GetDataSet(MasterDynamicDAL, TopCount, "1=1 " + pWhere + MasterFilterSQL, SortField).Tables[0];
                    }
                    dsMain.DataSource = dtMain;
                    dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                }
                else
                {
                    if (IsCheckAuth)
                    {
                        dtMain = GetDataSet(MasterDynamicDAL, SC.GetAuthSQL(ShowType.FormQuery, FormID) + pWhere + MasterFilterSQL).Tables[0];
                    }
                    else
                    {
                        dtMain = GetDataSet(MasterDynamicDAL, "1=1 " + pWhere + MasterFilterSQL).Tables[0];
                    }
                    dsMain.DataSource = dtMain;
                    dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                }
            }
            if (dsMain.Current != null)
            {
                base.DoView();
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlMain, true);
                IsDataChange = false;
            }
            else
            {
                initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.None);
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlMain, true);
                IsDataChange = false;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        public override void DoBaseView()
        {
            if (dsMain.Current != null)
            {
                base.DoBaseView();
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlMain, true);
                IsDataChange = false;
            }
            else
            {
                initButtonsState(OperateFlag.None);
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlMain, true);
                IsDataChange = false;
            }
        }

        /// <summary>
        /// 新增之前执行的方法
        /// </summary>
        public override bool DoAppend()
        {
            Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlMain, false);
            dsMain.AddNew();
            dsMain.EndEdit();
            ((DataRowView)dsMain.Current).Row["iFlag"] = 0;
            ((DataRowView)dsMain.Current).Row["sUserID"] = Sunrise.ERP.Security.SecurityCenter.CurrentUserID;
            IsDataChange = false;
            return base.DoAppend();

        }
        /// <summary>
        /// 取消之前执行的方法
        /// </summary>
        /// <returns></returns>
        public override bool DoBeforeCancel()
        {
            if (dsMain.Current != null)
            {
                if (IsDataChange)
                {
                    if (Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "DataNotSavedForCancel"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (TopCount != 499 & SortField != "dInputDate DESC")
                        {
                            if (IsCheckAuth)
                            {
                                dtMain = GetDataSet(MasterDynamicDAL, TopCount, SC.GetAuthSQL(MasterFilterSQL == "" ? ShowType.FormShow : ShowType.FormQuery, FormID) + pWhere + MasterFilterSQL, SortField).Tables[0];
                            }
                            else
                            {
                                dtMain = GetDataSet(MasterDynamicDAL, TopCount, "1=1 " + pWhere + MasterFilterSQL, SortField).Tables[0];
                            }
                            dsMain.DataSource = dtMain;
                            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);

                        }
                        else
                        {
                            if (IsCheckAuth)
                            {
                                dtMain = GetDataSet(MasterDynamicDAL, SC.GetAuthSQL(MasterFilterSQL == "" ? ShowType.FormShow : ShowType.FormQuery, FormID) + pWhere + MasterFilterSQL).Tables[0];
                            }
                            else
                            {
                                dtMain = GetDataSet(MasterDynamicDAL, "1=1 " + pWhere + MasterFilterSQL).Tables[0];
                            }
                            dsMain.DataSource = dtMain;
                            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                        }
                        dsMain.CancelEdit();
                        Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlMain, true);
                        IsDataChange = false;
                        return base.DoBeforeCancel();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (TopCount != 499 & SortField != "dInputDate DESC")
                    {
                        if (IsCheckAuth)
                        {
                            dtMain = GetDataSet(MasterDynamicDAL, TopCount, SC.GetAuthSQL(MasterFilterSQL == "" ? ShowType.FormShow : ShowType.FormQuery, FormID) + pWhere + MasterFilterSQL, SortField).Tables[0];
                        }
                        else
                        {
                            dtMain = GetDataSet(MasterDynamicDAL, TopCount, "1=1 " + pWhere + MasterFilterSQL, SortField).Tables[0];
                        }
                        dsMain.DataSource = dtMain;
                        dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                    }
                    else
                    {
                        if (IsCheckAuth)
                        {
                            dtMain = GetDataSet(MasterDynamicDAL, SC.GetAuthSQL(MasterFilterSQL == "" ? ShowType.FormShow : ShowType.FormQuery, FormID) + pWhere + MasterFilterSQL).Tables[0];
                        }
                        else
                        {
                            dtMain = GetDataSet(MasterDynamicDAL, "1=1 " + pWhere + MasterFilterSQL).Tables[0];
                        }
                        dsMain.DataSource = dtMain;
                        dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                    }
                    dsMain.CancelEdit();
                    Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlMain, true);
                    IsDataChange = false;
                    return base.DoBeforeCancel();
                }
            }
            else
            {
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlMain, true);
                IsDataChange = false;
                return base.DoBeforeCancel();
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        public override void DoCancel()
        {
            if (dsMain.Current != null)
            {
                base.DoCancel();
            }
            else
            {
                initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.None);
            }
        }
        /// <summary>
        /// 编辑
        /// </summary>
        public override void DoEdit()
        {
            base.DoEdit();
            Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlMain, false);
            IsDataChange = false;
        }
        /// <summary>
        /// 复制
        /// </summary>
        public override void DoCopy()
        {
            base.DoCopy();
            DataRow drTemp = ((DataRowView)dsMain.Current).Row;
            DoAppend();
            //控制不需要复制的字段
            for (int i = 0; i < drTemp.ItemArray.Length; i++)
            {
                //默认的ID,sUserID,iFlag,dInputDate字段不复制
                if (!NotCopyFields.Contains(drTemp.Table.Columns[i].ColumnName) &&
                    drTemp.Table.Columns[i].ColumnName != "ID" &&
                    drTemp.Table.Columns[i].ColumnName != "sUserID" &&
                    drTemp.Table.Columns[i].ColumnName != "iFlag" &&
                    drTemp.Table.Columns[i].ColumnName != "dInputDate")
                {
                    ((DataRowView)dsMain.Current).Row[i] = drTemp[i];
                }
            }
            //((DataRowView)dsMain.Current).Row["iFlag"] = 0;
            //((DataRowView)dsMain.Current).Row["sUserID"] = Sunrise.ERP.Security.SecurityCenter.CurrentUserID;
            dsMain.EndEdit();
            //Sunrise.ERP.BasePublic.BasePublic.SetAllControlsReadOnly(this.pnlInfo, false);
            //IsDataChange = false;

        }

        /// <summary>
        /// 保存前执行的方法
        /// </summary>
        /// <returns></returns>
        public override bool DoBeforeSave()
        {
            bool result = false;
            //非空验证
            if (dsMain.Current != null)
            {
                foreach (DataRow dr in DynamicMasterTableData.Select("bNotNull=1"))
                {
                    if (((DataRowView)dsMain.Current).Row[dr["sFieldName"].ToString()].ToString() == "")
                    {
                        string sMsg = string.Format("{0} {1}", LangCenter.Instance.IsDefaultLanguage ? dr["sCaption"].ToString() : dr["sEngCaption"].ToString(),
                                      LangCenter.Instance.GetSystemMessage("NotNull"));
                        Public.SystemInfo(sMsg);
                        return false;
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

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public override bool DoSave()
        {
            if (FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsInsert)
            {
                try
                {
                    Add(MasterDynamicDAL, ((DataRowView)dsMain.Current).Row, SqlTrans);
                    return base.DoSave();
                }
                catch(Exception ex)
                {
                    Public.SystemInfo(ex.Message, true);
                    //回收Trans
                    if (SqlTrans != null)
                        SqlTrans.Dispose();
                    return false;
                }
            }
            else
            {
                try
                {
                    Update(MasterDynamicDAL, ((DataRowView)dsMain.Current).Row, SqlTrans);
                    return base.DoSave();
                }
                catch (Exception ex)
                {
                    Public.SystemInfo(ex.Message, true);
                    //回收Trans
                    if (SqlTrans != null)
                        SqlTrans.Dispose();
                    return false;
                }
            }
        }

        public override bool DoAfterSave()
        {
            //先处理保存后的SQL事务
            try
            {
                if (DoAfterSaveInTrans(SqlTrans))
                    SqlTrans.Commit();
            }
            catch
            {
                SqlTrans.Rollback();
                //回收Trans
                if (SqlTrans != null)
                    SqlTrans.Dispose();
                return false;
            }
            if (TopCount != 499 & SortField != "dInputDate DESC")
            {
                if (IsCheckAuth)
                    dtMain = GetDataSet(MasterDynamicDAL, TopCount, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, SortField).Tables[0];
                else
                    dtMain = GetDataSet(MasterDynamicDAL, TopCount, "1=1 " + pWhere, SortField).Tables[0];
                dsMain.DataSource = dtMain;
                dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
            }
            else
            {
                if (IsCheckAuth)
                    dtMain = GetDataSet(MasterDynamicDAL, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
                else
                    dtMain = GetDataSet(MasterDynamicDAL, "1=1 " + pWhere).Tables[0];
                dsMain.DataSource = dtMain;
                dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
            }
            Base.SetAllControlsReadOnly(this.pnlMain, true);
            IsDataChange = false;
            return base.DoAfterSave();
        }
        /// <summary>
        /// 保存之前执行的方法，加入事务处理
        /// </summary>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual bool DoBeforceSaveInTrans(SqlTransaction trans)
        {
            return true;
        }

        /// <summary>
        /// 保存之后执行的方法，加入事务处理
        /// </summary>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual bool DoAfterSaveInTrans(SqlTransaction trans)
        {
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public override bool DoDelete()
        {
            if (BillID > 0)
            {
                if (Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "DeleteData"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlTransaction trans = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection.BeginTransaction();
                    try
                    {
                        Delete(MasterDynamicDAL, BillID, trans);
                        trans.Commit();
                        dsMain.RemoveCurrent();
                        IsDataChange = false;
                        base.DoDelete();
                        if (dsMain.Current == null)
                        {
                            initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.None);
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 关闭之前执行的方法
        /// </summary>
        /// <returns></returns>
        public override bool DoBeforeClose()
        {
            return base.DoBeforeCancel();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (IsDataChange)
            {
                if (Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "DataNotSavedForClose"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlMain, true);
                    IsDataChange = false;
                    base.OnFormClosing(e);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlMain, true);
                IsDataChange = false;
                base.OnFormClosing(e);
            }

        }


        #endregion

        #region 窗体设置
        /// <summary>
        /// 窗体初始化
        /// </summary>
        public override void initBase()
        {
            base.initBase();
            //设置非空字段颜色
            Sunrise.ERP.BasePublic.Base.SetNotNullFiledsColor(this.pnlMain, NotNullFields);
            IsDataChange = false;
            try
            {
                toolTipController1.SetToolTip(sptUpDown, LangCenter.Instance.GetFormLangInfo("BaseForm", "DbClickToClose"));
            }
            catch { }

        }

        private int pnlMainHeight = 300;
        private void sptUpDown_DoubleClick(object sender, EventArgs e)
        {
            if (pnlMain.Height != 0)
            {
                pnlMainHeight = pnlMain.Height;
                pnlMain.Height = 0;
                toolTipController1.SetToolTip(sptUpDown, LangCenter.Instance.GetFormLangInfo("BaseForm", "DbClickToExpand"));
            }
            else
            {
                pnlMain.Height = pnlMainHeight;
                toolTipController1.SetToolTip(sptUpDown, LangCenter.Instance.GetFormLangInfo("BaseForm", "DbClickToClose"));
            }
        }

         /// <summary>
        /// 初始化数据绑定
        /// </summary>
        public void InitDataBindings()
        {
            this.InitDataBindings(DynamicMasterTableData, pnlMain,dsMain);
        }
        public void InitDataBindings(DataTable dtcolumninfo, Control parentControl,BindingSource bsData)
        {
            Control[] ctls;
            foreach (DataRow dr in dtcolumninfo.Select("sControlType<>'lbl'"))
            {
                //添加不可复制的字段
                if (!Convert.ToBoolean(dr["bCopy"]))
                    AddNotCopyFields(dr["sFieldName"].ToString());

                string ControlKey = "lbl" + dr["sFieldName"].ToString();
                ctls = parentControl.Controls.Find(ControlKey, true);
                //设置字段Label显示
                if (ctls != null && ctls.Length == 1)
                {
                    ctls[0].Text = LangCenter.Instance.IsDefaultLanguage ? dr["sCaption"].ToString() : dr["sEngCaption"].ToString();
                    //设置非空字段颜色
                    if (bool.Parse(dr["bNotNull"].ToString().ToLower()))
                        ctls[0].ForeColor = Color.FromName(Base.GetSystemParamter("001"));
                }

                ControlKey = dr["sControlType"].ToString() + dr["sFieldName"].ToString();
                ctls = parentControl.Controls.Find(ControlKey, true);
                //DataBinding
                if (ctls != null && ctls.Length == 1)
                {
                    //如果界面布局用Layout，设置Layout标签及非空字段颜色
                    if (ctls[0].Parent is LayoutControl)
                    {
                        ((LayoutControl)ctls[0].Parent).GetItemByControl(ctls[0]).Text = LangCenter.Instance.IsDefaultLanguage ? dr["sCaption"].ToString() : dr["sEngCaption"].ToString();
                        //设置非空字段颜色
                        if (bool.Parse(dr["bNotNull"].ToString().ToLower()))
                            ((LayoutControl)ctls[0].Parent).GetItemByControl(ctls[0]).AppearanceItemCaption.ForeColor = Color.FromName(Base.GetSystemParamter("001"));

                        //如果设置不显示在Panel中则该字段不显示
                        if (!bool.Parse(dr["bShowInPanel"].ToString().ToLower()))
                            ((LayoutControl)ctls[0].Parent).GetItemByControl(ctls[0]).Visibility = LayoutVisibility.Never;
                    }

                    ctls[0].DataBindings.Add("EditValue", bsData, dr["sFieldName"].ToString());

                    //数量或者价格权限检测
                    if (dr["sColumnType"].ToString() == "002")
                    {
                        //检测是否有价格权限
                        bool HasPrice = SC.CheckAuth(SecurityOperation.Price, FormID);
                        //设置该字段控件及其对应Label标签也不显示
                        Control[] lblctls = parentControl.Controls.Find("lbl" + dr["sFieldName"].ToString(), true);
                        if (lblctls != null && lblctls.Length == 1)
                            lblctls[0].Visible = HasPrice;
                        ctls[0].Visible = HasPrice;

                        //如果界面布局用Layout，控制其显示与否
                        if (ctls[0].Parent is LayoutControl && !HasPrice)
                            ((LayoutControl)ctls[0].Parent).GetItemByControl(ctls[0]).Visibility = LayoutVisibility.Never;
                        else
                        {
                            if (ctls[0] is TextEdit || ctls[0] is MemoEdit)
                            {
                                ((TextEdit)ctls[0]).Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                                ((TextEdit)ctls[0]).Properties.DisplayFormat.FormatString = Base.FormatPrice;
                            }
                        }

                    }
                    else if (dr["sColumnType"].ToString() == "003")
                    {
                        //检测是否有数量权限
                        bool HasNum = SC.CheckAuth(SecurityOperation.Num, FormID);
                        //设置该字段控件及其对应Label标签也不显示
                        Control[] lblctls = parentControl.Controls.Find("lbl" + dr["sFieldName"].ToString(), true);
                        if (lblctls != null && lblctls.Length == 1)
                            lblctls[0].Visible = HasNum;
                        ctls[0].Visible = HasNum;

                        //如果界面布局用Layout，控制其显示与否
                        if (ctls[0].Parent is LayoutControl && !HasNum)
                            ((LayoutControl)ctls[0].Parent).GetItemByControl(ctls[0]).Visibility = LayoutVisibility.Never;
                        else
                        {
                            if (ctls[0] is TextEdit || ctls[0] is MemoEdit)
                            {
                                ((TextEdit)ctls[0]).Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                                ((TextEdit)ctls[0]).Properties.DisplayFormat.FormatString = Base.FormatQuantity;
                            }
                        }
                    }

                    //不需要权限控制的价格数量显示格式化
                    //无权限控制价格
                    if (dr["sColumnType"].ToString() == "004")
                    {
                        if (ctls[0] is TextEdit || ctls[0] is MemoEdit)
                        {
                            ((TextEdit)ctls[0]).Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            ((TextEdit)ctls[0]).Properties.DisplayFormat.FormatString = Base.FormatNullAuthPrice;
                        }
                    }
                    //无权限控制数量
                    else if (dr["sColumnType"].ToString() == "005")
                    {
                        if (ctls[0] is TextEdit || ctls[0] is MemoEdit)
                        {
                            ((TextEdit)ctls[0]).Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            ((TextEdit)ctls[0]).Properties.DisplayFormat.FormatString = Base.FormatNullAuthQuantity;
                        }
                    }

                    //控制界面上显示字段是否显示和可编辑
                    //超级用户或者在窗体字段设置没有进行过设置则显示全部
                    if (!SecurityCenter.IsAdmin && FormFieldSetting.Rows.Count > 0)
                    {
                        //取只有是主表/单表的数据
                        foreach (DataRow drField in FormFieldSetting.Select("sTableName='" + MasterTableName + "'"))
                        {
                            if (dr["sFieldName"].ToString() == drField["sFieldName"].ToString())
                            {
                                //先判断是否可见
                                if (Convert.ToBoolean(drField["bVisiable"]))
                                {
                                    if (!Convert.ToBoolean(drField["bEdit"]))
                                    {
                                        ctls[0].Tag = "99";
                                        Base.SetControlsReadOnly(ctls[0], true);
                                    }
                                }
                                else
                                {
                                    //设置该字段控件及其对应Label标签也不显示
                                    Control[] lblctls = parentControl.Controls.Find("lbl" + dr["sFieldName"].ToString(), true);
                                    if (lblctls != null && lblctls.Length == 1)
                                        lblctls[0].Visible = false;
                                    ctls[0].Visible = false;

                                    //如果界面布局用Layout，控制其显示与否
                                    if (ctls[0].Parent is LayoutControl)
                                        ((LayoutControl)ctls[0].Parent).GetItemByControl(ctls[0]).Visibility = LayoutVisibility.Never;
                                }
                            }
                        }
                    }


                    //初始化Lookup
                    if (ctls[0] is SunriseLookUp)
                    {
                        if (!string.IsNullOrEmpty(dr["sLookupNo"].ToString()))
                        {
                            Base.InitLookup((SunriseLookUp)ctls[0], dr["sLookupNo"].ToString());
                            if (!string.IsNullOrEmpty(dr["sLookupAutoSetControl"].ToString()))
                            {
                                string[] sItem = Public.GetSplitString(dr["sLookupAutoSetControl"].ToString(), ",");
                                foreach (var s in sItem)
                                {
                                    string[] ss = Public.GetSplitString(s, "=");
                                    ((SunriseLookUp)ctls[0]).AutoSetValue(ss[0], ss[1]);
                                }
                            }
                        }
                    }
                    //初始化ComboBox
                    if (ctls[0] is ImageComboBoxEdit)
                    {
                        if (!string.IsNullOrEmpty(dr["sLookupNo"].ToString()))
                            Base.InitComboBox((ImageComboBoxEdit)ctls[0], dr["sLookupNo"].ToString(), dr["sFieldType"].ToString());
                    }

                    //初始化MLookup
                    if (ctls[0] is SunriseMLookUp)
                    {
                        if (!string.IsNullOrEmpty(dr["sLookupNo"].ToString()))
                        {
                            Base.InitMLookup((SunriseMLookUp)ctls[0], dr["sLookupNo"].ToString());
                            if (!string.IsNullOrEmpty(dr["sLookupAutoSetControl"].ToString()))
                            {
                                string[] sItem = Public.GetSplitString(dr["sLookupAutoSetControl"].ToString(), ",");
                                foreach (var s in sItem)
                                {
                                    string[] ss = Public.GetSplitString(s, "=");
                                    ((SunriseMLookUp)ctls[0]).AutoSetValue(ss[0], ss[1]);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 设置在按下回车键后控件焦点自动下移
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if ((((DevExpress.XtraEditors.TextBoxMaskBox)(Sunrise.ERP.BasePublic.Base.GetFocusedControl()))).OwnerEdit.Tag == null || (((DevExpress.XtraEditors.TextBoxMaskBox)(Sunrise.ERP.BasePublic.Base.GetFocusedControl()))).OwnerEdit.Tag.ToString().ToLower() != "notab")
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
                base.OnKeyDown(e);
            }
            catch (Exception)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
                base.OnKeyDown(e);
            }

        }

        #endregion

        #region 数据操作
        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="dr">数据行对象</param>
        /// <param name="trans">SQL事务</param>
        /// <returns></returns>
        public int Add(DynamicDALSetting DALobj, DataRow dr, SqlTransaction trans)
        {
            try
            {
                return DALobj.Add(dr, trans);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="dr">数据行对象</param>
        /// <param name="trans">SQL事务</param>
        /// <returns></returns>
        public void Update(DynamicDALSetting DALobj, DataRow dr, SqlTransaction trans)
        {
            try
            {
                DALobj.Update(dr, trans);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">单据ID</param>
        /// <param name="trans">SQL事务</param>
        /// <returns></returns>
        public void Delete(DynamicDALSetting DALobj, int id, SqlTransaction trans)
        {
            try
            {
                DALobj.Delete(id, trans);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="pwhere">条件</param>
        /// <returns></returns>
        public DataSet GetDataSet(DynamicDALSetting DALobj, string pwhere)
        {
            try
            {
                return DALobj.GetList(pwhere); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="top">前数据行</param>
        /// <param name="pwhere">条件</param>
        /// <param name="order">排序字段</param>
        /// <returns></returns>
        public DataSet GetDataSet(DynamicDALSetting DALobj, int top, string pwhere, string order)
        {
            try
            {
                return DALobj.GetList(top, pwhere, order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 数据状态控制
        /// <summary>
        /// 数据状态控制
        /// 在主从表窗体中一定要重写此方法来控制明细Grid及按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void DataStateChange(object sender, EventArgs e)
        {
            Base.SetControlsGridEnable(this.pnlGrid, FormDataFlag == DataFlag.dsBrowse);
        }
        private void dsMain_CurrentItemChanged(object sender, EventArgs e)
        {
            if (dsMain.Current != null)
            {
                BillID = ((DataRowView)(dsMain.Current))["ID"].ToString() == "" ? 0 : Convert.ToInt32(((DataRowView)(dsMain.Current))["ID"]);
                if (IsFirstLoad)
                {
                    if (FormDataFlag != DataFlag.dsBrowse)
                    {
                        IsDataChange = true;
                    }
                }
            }
        }

        private void dsMain_CurrentChanged(object sender, EventArgs e)
        {
            if (dsMain.Current == null)
            {
                initButtonsState(OperateFlag.None);
            }
        }

        /// <summary>
        /// 加载窗体数据
        /// </summary>
        /// <param name="filters">过滤条件注意SQL拼接，e.g: "AND 1=1"</param>
        public void LoadFormData(string filters)
        {
            //添加空格用于SQL拼接
            MasterFilterSQL = filters;
            if (MasterFilterSQL != "")
            {
                if (TopCount != 499 && SortField != "dInputDate DESC")
                {
                    if (IsCheckAuth)
                    {
                        dtMain = GetDataSet(MasterDynamicDAL, TopCount, SC.GetAuthSQL(ShowType.FormQuery, FormID) + pWhere + " " + MasterFilterSQL, SortField).Tables[0];
                    }
                    else
                    {
                        dtMain = GetDataSet(MasterDynamicDAL, TopCount, "1=1 " + pWhere + " " + MasterFilterSQL, SortField).Tables[0];
                    }
                    dsMain.DataSource = dtMain;
                    dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                }
                else
                {
                    if (IsCheckAuth)
                    {
                        dtMain = GetDataSet(MasterDynamicDAL, SC.GetAuthSQL(ShowType.FormQuery, FormID) + pWhere + " " + MasterFilterSQL).Tables[0];
                    }
                    else
                    {
                        dtMain = GetDataSet(MasterDynamicDAL, "1=1 " + pWhere + " " + MasterFilterSQL).Tables[0];
                    }
                    dsMain.DataSource = dtMain;
                    dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                }
            }
            if (dsMain.Current != null)
            {
                base.DoView();
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlMain, true);
                IsDataChange = false;
            }
            else
            {
                initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.None);
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlMain, true);
                IsDataChange = false;
            }
        }

        /// <summary>
        /// 根据单据ID加载窗体数据
        /// </summary>
        /// <param name="id">单据ID</param>
        public void LoadFormData(int id)
        {
            LoadFormData(" AND ma.ID=" + id.ToString() + " ");
        }

        /// <summary>
        /// 根据单据编号加载窗体数据
        /// </summary>
        /// <param name="billnofield">单据编号字段</param>
        /// <param name="billno">单据编号</param>
        public void LoadFormData(string billnofield, string billno)
        {
            LoadFormData(" AND ma." + billnofield + "='" + billno + "' ");
        }

        #endregion

        #region 属性设置

        /// <summary>
        /// 窗体数据ID(单据ID)
        /// </summary>
        private int _BillID = 0;

        /// <summary>
        /// 窗体数据ID(单据ID)
        /// </summary>
        protected int BillID
        {
            get
            {
                return _BillID;
            }
            set
            {
                _BillID = value;
            }
        }

        private bool _datachange = false;

        /// <summary>
        /// 数据是否变更
        /// </summary>
        protected bool IsDataChange
        {
            get
            {
                return _datachange;
            }
            set
            {
                _datachange = value;
            }
        }

        private string _pwhere = " AND 1=1";

        /// <summary>
        /// 设置数据条件
        /// </summary>
        protected string pWhere
        {
            get
            {
                return _pwhere;
            }
            set
            {
                _pwhere = value;
            }
        }

        private int _top = 499;

        /// <summary>
        /// 设置数据默认显示条数
        /// </summary>
        protected int TopCount
        {
            get
            {
                return _top;
            }
            set
            {
                _top = value;
            }
        }

        private string _sortfield = "dInputDate DESC";

        /// <summary>
        /// 排序字段
        /// </summary>
        protected string SortField
        {
            get
            {
                return _sortfield;
            }
            set
            {
                _sortfield = value;
            }
        }

        private string _tablename;
        /// <summary>
        /// 单据主表或者单表名称
        /// </summary>
        protected string MasterTableName
        {
            get
            {
                return _tablename;
            }
            set
            {
                _tablename = value;
            }
        }

        private bool _ischeckauth = true;

        /// <summary>
        /// 设置窗体是否需要进行权限验证
        /// </summary>
        protected bool IsCheckAuth
        {
            get
            {
                return _ischeckauth;
            }
            set
            {
                _ischeckauth = value;
            }
        }

        private string _MasterSql = "";
        /// <summary>
        /// 窗体主表数据SQL
        /// </summary>
        protected string MasterSQL
        {
            get
            {
                return _MasterSql;
            }
            set
            {
                _MasterSql = value;
            }
        }

        private string _MasterFilterSql = "";
        /// <summary>
        /// 窗体主表数据查询过滤SQL
        /// </summary>
        protected string MasterFilterSQL
        {
            get
            {
                return _MasterFilterSql;
            }
            set
            {
                _MasterFilterSql = value;
            }
        }

        private DataTable _dtFormFieldSeting;

        /// <summary>
        /// 获取当前用户窗体字段权限数据
        /// </summary>
        public DataTable FormFieldSetting
        {
            get
            {
                if (_dtFormFieldSeting == null)
                {
                    _dtFormFieldSeting = Base.GetFormFieldSetting(SecurityCenter.CurrentUserID, FormID);
                }
                return _dtFormFieldSeting;
            }
        }

        /// <summary>
        /// 系统权限处理类
        /// </summary>
        protected SecurityCenter SC
        {
            get
            {
                if (_sc == null)
                    _sc = new SecurityCenter();
                return _sc;
            }
        }

        private DynamicDALSetting _MasterDynamicDAL;
        /// <summary>
        /// 主表或单表数据操作层
        /// </summary>
        protected DynamicDALSetting MasterDynamicDAL
        {
            get
            {
                if (_MasterDynamicDAL == null)
                {
                    _MasterDynamicDAL = new DynamicDALSetting(DynamicMasterTableData);
                }
                return _MasterDynamicDAL;
            }
        }

        private DataTable _dynamicmatsertabledata;
        /// <summary>
        /// 动态单表/主表结构数据
        /// </summary>
        protected DataTable DynamicMasterTableData
        {
            get
            {
                if (_dynamicmatsertabledata == null)
                    _dynamicmatsertabledata = Base.GetDynamicTableData(FormID, MasterTableName);
                return _dynamicmatsertabledata;
            }
        }

        private int _ControlX = 10;
        /// <summary>
        /// 第一个自定义控件的Location X
        /// </summary>
        public int ControlX
        {
            get { return _ControlX; }
            set { _ControlX = value; }
        }

        private int _ControlY = 4;
        /// <summary>
        /// 第一个自定义控件的Location Y
        /// </summary>
        public int ControlY
        {
            get { return _ControlY; }
            set { _ControlY = value; }
        }

        #endregion

        #region 按钮操作权限检测

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsCheckAuth && !SC.CheckAuth(SecurityOperation.Add, FormID))
            {
                Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "NoAddAuth"));
                return;
            }
            base.btnAdd_Click(sender, e);
        }

        public override void btnView_Click(object sender, EventArgs e)
        {
            string sUserID = dsMain.Current == null ? "" : ((DataRowView)dsMain.Current)["sUserID"].ToString();
            if (IsCheckAuth && !SC.CheckAuth(SecurityOperation.View, FormID, sUserID))
            {
                Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "NoQueryAuth"));
                return;
            }
            //创建查询窗口
            CreateSearchFilter();

            base.btnView_Click(sender, e);
        }

        public override void btnEdit_Click(object sender, EventArgs e)
        {
            if (IsCheckAuth && !SC.CheckAuth(SecurityOperation.Edit, FormID, ((DataRowView)dsMain.Current)["sUserID"].ToString()))
            {
                Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "NoEditAuth"));
                return;
            }
            if (((DataRowView)dsMain.Current)["iFlag"].ToString() == "4")
            {
                Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "AuthedCannotEdit"));
                return;
            }
            base.btnEdit_Click(sender, e);
        }

        public override void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsCheckAuth && !SC.CheckAuth(SecurityOperation.Delete, FormID, ((DataRowView)dsMain.Current)["sUserID"].ToString()))
            {
                Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "NoDeleteAuth"));
                return;
            }
            if (((DataRowView)dsMain.Current)["iFlag"].ToString() == "4")
            {
                Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "AuthedCannotDelete"));
                return;
            }
            base.btnDelete_Click(sender, e);
        }

        public override void btnPrint_Click(object sender, EventArgs e)
        {
            if (IsCheckAuth && !SC.CheckAuth(SecurityOperation.Print, FormID, ((DataRowView)dsMain.Current)["sUserID"].ToString()))
            {
                Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "NoPrintAuth"));
                return;
            }
            base.btnPrint_Click(sender, e);
        }

        public override void btnProperty_Click(object sender, EventArgs e)
        {
            if (IsCheckAuth && !SC.CheckAuth(SecurityOperation.Property, FormID))
            {
                Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "NoPropertyAuth"));
                return;
            }
            base.btnProperty_Click(sender, e);
        }

        #endregion

        #region 窗体自定义设置

        private void btnSettings_Click(object sender, EventArgs e)
        {
            //frmDynamicFormSetting frm = new frmDynamicFormSetting(FormID);
            //frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.ShowDialog();
        }

        /// <summary>
        /// 重新设置控件位置
        /// </summary>
        public void ResetControlLocation()
        {

        }

        /// <summary>
        /// 创建自定义控件
        /// </summary>
        public void CreateDynamicControl()
        {
            if (DynamicMasterTableData.Select("bSystemColumn=0").Length > 0)
            {
                pnlDynamic.Visible = true;

                //每行控件数
                int iControlColumn = Convert.ToInt32(DynamicMasterTableData.Rows[0]["iControlColumn"]);
                //控件间距
                int iControlSpace = Convert.ToInt32(DynamicMasterTableData.Rows[0]["iControlSpace"]);
                //先计算需要生成控件的数据，去除如果在自定义字段权限设置中设置为不可见的数据
                List<DataRow> drs = DynamicMasterTableData.Select("bSystemColumn=0 AND bShowInPanel=1").ToList();

                if (!SecurityCenter.IsAdmin && FormFieldSetting.Rows.Count > 0)
                {
                    for (int i = 0; i < drs.Count; i++)
                    {
                        //取只有是主表/单表的数据
                        foreach (DataRow drField in FormFieldSetting.Select("sTableName='" + MasterTableName + "'"))
                        {
                            if (drs[i]["sFieldName"].ToString() == drField["sFieldName"].ToString() &&
                                !Convert.ToBoolean(drField["bVisiable"]))
                            {
                                drs.Remove(drs[i]);
                            }
                        }
                    }
                }

                //计算控件总共行数
                int iRows = 0;
                if (drs.Count > 0)
                {
                    if (drs.Count % iControlColumn != 0)
                    {
                        iRows = (int)Math.Floor(Convert.ToDecimal(drs.Count / iControlColumn)) + 1;
                    }
                    else
                    {
                        iRows = Convert.ToInt32(drs.Count / iControlColumn);
                    }
                    //设置控件数计数
                    int iControl = 0;
                    for (int j = 0; j < iRows; j++)
                    {
                        for (int i = 0; i < iControlColumn; i++)
                        {
                            //控件类型
                            string sControlType = drs[iControl]["sControlType"].ToString();
                            //创建控件
                            //Lable大小控制为80X21，其他输入控件大小为120X21
                            Label lblControl = new Label();
                            lblControl.AutoSize = false;
                            lblControl.Size = new Size(80, 21);
                            lblControl.Location = new Point(ControlX + (80 + 120 + iControlSpace) * i, ControlY + (21 + 10) * j);
                            //控件命名规则：lbl+字段名
                            lblControl.Name = "lbl" + drs[iControl]["sFieldName"].ToString();
                            lblControl.TextAlign = ContentAlignment.BottomLeft;
                            //当控件类型为复选框\单选\Label标签时不创建Lable控件
                            if (sControlType != "chk" && sControlType != "rad" && sControlType != "lbl")
                            {
                                lblControl.Text = LangCenter.Instance.IsDefaultLanguage ? drs[iControl]["sCaption"].ToString() : drs[iControl]["sCaption"].ToString();
                            }
                            else
                                lblControl.Visible = false;
                            pnlDynamic.Controls.Add(lblControl);
                            switch (sControlType)
                            {
                                case "txt":
                                    {
                                        TextEdit txt = new TextEdit();
                                        txt.Size = new Size(120, 21);
                                        txt.Name = "txt" + drs[iControl]["sFieldName"].ToString();
                                        txt.Location = new Point(ControlX + (80 + 120 + iControlSpace) * i + 80, ControlY + 4 + (21 + 10) * j);
                                        pnlDynamic.Controls.Add(txt);
                                        break;
                                    }
                                case "mtxt":
                                    {
                                        MemoEdit mtxt = new MemoEdit();
                                        mtxt.Size = new Size(120, 21);
                                        mtxt.Name = "mtxt" + drs[iControl]["sFieldName"].ToString();
                                        mtxt.Location = new Point(ControlX + (80 + 120 + iControlSpace) * i + 80, ControlY + 4 + (21 + 10) * j);
                                        pnlDynamic.Controls.Add(mtxt);
                                        break;
                                    }
                                case "btxt":
                                    {
                                        MemoExEdit btxt = new MemoExEdit();
                                        btxt.Size = new Size(120, 21);
                                        btxt.Name = "btxt" + drs[iControl]["sFieldName"].ToString();
                                        btxt.Location = new Point(ControlX + (80 + 120 + iControlSpace) * i + 80, ControlY + 4 + (21 + 10) * j);
                                        pnlDynamic.Controls.Add(btxt);
                                        break;
                                    }
                                case "cbx":
                                    {
                                        ImageComboBoxEdit cbx = new ImageComboBoxEdit();
                                        cbx.Size = new Size(120, 21);
                                        cbx.Name = "cbx" + drs[iControl]["sFieldName"].ToString();
                                        cbx.Location = new Point(ControlX + (80 + 120 + iControlSpace) * i + 80, ControlY + 4 + (21 + 10) * j);
                                        pnlDynamic.Controls.Add(cbx);
                                        break;
                                    }
                                case "chk":
                                    {
                                        CheckEdit chk = new CheckEdit();
                                        chk.Size = new Size(120, 21);
                                        chk.Name = "chk" + drs[iControl]["sFieldName"].ToString();
                                        chk.Location = new Point(ControlX + (80 + 120 + iControlSpace) * i + 80, ControlY + 4 + (21 + 10) * j);
                                        chk.CheckState = CheckState.Unchecked;
                                        chk.Text = LangCenter.Instance.IsDefaultLanguage ? drs[iControl]["sCaption"].ToString() : drs[iControl]["sEngCaption"].ToString();
                                        pnlDynamic.Controls.Add(chk);
                                        break;
                                    }
                                case "det":
                                    {
                                        DateEdit det = new DateEdit();
                                        det.Size = new Size(120, 21);
                                        det.Name = "det" + drs[iControl]["sFieldName"].ToString();
                                        det.Location = new Point(ControlX + (80 + 120 + iControlSpace) * i + 80, ControlY + 4 + (21 + 10) * j);
                                        det.EditValue = null;
                                        pnlDynamic.Controls.Add(det);
                                        break;
                                    }
                                case "img":
                                    {
                                        ImageEdit img = new ImageEdit();
                                        img.Size = new Size(120, 21);
                                        img.Name = "img" + drs[iControl]["sFieldName"].ToString();
                                        img.Location = new Point(ControlX + (80 + 120 + iControlSpace) * i + 80, ControlY + 4 + (21 + 10) * j);
                                        pnlDynamic.Controls.Add(img);
                                        break;
                                    }
                                case "lbl":
                                    {
                                        LabelControl lbl = new LabelControl();
                                        lbl.Size = new Size(120, 21);
                                        lbl.Name = "lbl" + drs[iControl]["sFieldName"].ToString() + iControl.ToString();
                                        lbl.Location = new Point(ControlX + (80 + 120 + iControlSpace) * i + 80, ControlY + 4 + (21 + 10) * j);
                                        lbl.Text = LangCenter.Instance.IsDefaultLanguage ? drs[iControl]["sCaption"].ToString() : drs[iControl]["sEngCaption"].ToString();
                                        pnlDynamic.Controls.Add(lbl);
                                        break;
                                    }
                                case "lkp":
                                    {
                                        SunriseLookUp lkp = new SunriseLookUp();
                                        lkp.Size = new Size(120, 21);
                                        lkp.Name = "lkp" + drs[iControl]["sFieldName"].ToString();
                                        lkp.Location = new Point(ControlX + (80 + 120 + iControlSpace) * i + 80, ControlY + 4 + (21 + 10) * j);
                                        pnlDynamic.Controls.Add(lkp);
                                        break;
                                    }
                                case "mlkp":
                                    {
                                        SunriseMLookUp mlkp = new SunriseMLookUp();
                                        mlkp.Size = new Size(120, 21);
                                        mlkp.Name = "mlkp" + drs[iControl]["sFieldName"].ToString();
                                        mlkp.Location = new Point(ControlX + (80 + 120 + iControlSpace) * i + 80, ControlY + 4 + (21 + 10) * j);
                                        pnlDynamic.Controls.Add(mlkp);
                                        break;
                                    }
                                case "rad":
                                    {
                                        RadioGroup rad = new RadioGroup();
                                        rad.Size = new Size(120, 21);
                                        rad.Name = "rad" + drs[iControl]["sFieldName"].ToString();
                                        rad.Location = new Point(ControlX + (80 + 120 + iControlSpace) * i + 80, ControlY + 4 + (21 + 10) * j);
                                        pnlDynamic.Controls.Add(rad);
                                        break;
                                    }
                            }
                            iControl++;
                            //当计数大于等于要创建的控件数量时则退出循环
                            if (iControl >= drs.Count)
                                break;
                        }
                    }
                }
                pnlDynamic.Height = ControlY + iRows * 31;
            }
            //初始化数据绑定
            InitDataBindings();
        }

        /// <summary>
        /// 创建单表或者主表Grid列
        /// </summary>
        /// <param name="gv"></param>
        public void CreateMasterGridColumn(GridView gv)
        {
            int iIndex = 0;
            string sFilter = "bShowInGrid=1 AND sTableName='" + MasterTableName + "'";
            foreach (DataRow dr in DynamicMasterTableData.Select(sFilter))
            {
                GridColumn cols = null;
                DataRow[] drFields = FormFieldSetting.Select("sTableName='" + MasterTableName + "'");
                if (drFields.Length == 0)
                {
                    cols = CreateGridColumn(gv, dr, iIndex);
                    iIndex++;
                }

                //加载窗体字段设置，主表或者单表Grid列都不能够编辑，只有显示或者不显示
                foreach (DataRow drField in drFields)
                {
                    if (dr["sFieldName"].ToString() == drField["sFieldName"].ToString())
                    {
                        if (Convert.ToBoolean(drField["bVisiable"]))
                        {
                            cols = CreateGridColumn(gv, dr, iIndex);
                            iIndex++;
                        }
                    }
                }
                if (cols != null)
                    gv.Columns.Add(cols);
            }
        }

        private GridColumn CreateGridColumn(GridView gv, DataRow dr, int index)
        {
            GridColumn col = new GridColumn();
            string sControlType = dr["sControlType"].ToString();
            switch (sControlType)
            {
                //下拉框
                case "cbx":
                    {
                        if (!string.IsNullOrEmpty(dr["sLookupNo"].ToString()))
                        {
                            RepositoryItemImageComboBox cbxRepositoryItem = new RepositoryItemImageComboBox();
                            Base.InitRepositoryItemComboBox(cbxRepositoryItem, dr["sLookupNo"].ToString(), dr["sFieldType"].ToString());                            
                            col.ColumnEdit = cbxRepositoryItem;
                            gv.GridControl.RepositoryItems.Add(cbxRepositoryItem);
                        }
                        break;
                    }
            }
            col.Caption = LangCenter.Instance.IsDefaultLanguage ? dr["sCaption"].ToString() : dr["sEngCaption"].ToString();
            col.FieldName = dr["sFieldName"].ToString();
            //Grid 列命名为col+表名+字段名
            col.Name = "col" + MasterTableName + dr["sFieldName"].ToString();
            col.Width = 120;
            if (dr["sColumnType"].ToString() == "002")
            {
                //检测是否有价格权限
                bool HasPrice = SC.CheckAuth(SecurityOperation.Price, FormID);
                if (!HasPrice) return null;

                //设置价格数据显示格式
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                col.DisplayFormat.FormatString = Base.FormatPrice;
            }
            else if (dr["sColumnType"].ToString() == "003")
            {
                //检测是否有数量权限
                bool HasNum = SC.CheckAuth(SecurityOperation.Num, FormID);
                if (!HasNum) return null;

                //设置数量数据显示格式
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                col.DisplayFormat.FormatString = Base.FormatQuantity;
            }
            else
                col.Visible = true;

            //不需要权限控制的价格数量显示格式化
            //无权限控制价格
            if (dr["sColumnType"].ToString() == "004")
            {
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                col.DisplayFormat.FormatString = Base.FormatNullAuthPrice;
            }
            //无权限控制数量
            else if (dr["sColumnType"].ToString() == "005")
            {
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                col.DisplayFormat.FormatString = Base.FormatNullAuthQuantity;
            }

            col.VisibleIndex = index;
            col.OptionsColumn.AllowEdit = Convert.ToBoolean(dr["bEdit"] == null ? 1 : dr["bEdit"]);
            //Grid Footer显示
            if (dr["sFooterType"].ToString() != "001")
            {
                //001	无
                //002	求和
                //003	计数
                //004	平均值
                //005	最大值
                //006	最小值                   
                col.SummaryItem.FieldName = dr["sFieldName"].ToString();
                if (dr["sFooterType"].ToString() == "002")
                    col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                else if (dr["sFooterType"].ToString() == "003")
                    col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                else if (dr["sFooterType"].ToString() == "004")
                    col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Average;
                else if (dr["sFooterType"].ToString() == "005")
                    col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Max;
                else if (dr["sFooterType"].ToString() == "006")
                    col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Min;

                gv.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, dr["sFieldName"].ToString(), col);
            }
            return col;
        }

        public virtual void CreateSearchFilter()
        {
            DataRow[] drs = DynamicMasterTableData.Select("bQuery=1");
            if (drs.Length > 0)
            {
                frmSearchForm frmSearch = new frmSearchForm();
                foreach (DataRow dr in drs)
                {
                    string sControlType = dr["sControlType"].ToString();
                    switch (sControlType)
                    {
                        case "txt":
                        case "mtxt":
                            {
                                frmSearch.AddSearchItem(LangCenter.Instance.IsDefaultLanguage ? dr["sCaption"].ToString() : dr["sEngCaption"].ToString(),
                                                        dr["sFieldName"].ToString(), FiledType.S);
                                break;
                            }
                        case "cbx":
                            {
                                frmSearch.AddSearchItem(LangCenter.Instance.IsDefaultLanguage ? dr["sCaption"].ToString() : dr["sEngCaption"].ToString(),
                                                        dr["sFieldName"].ToString(), FiledType.C, dr["sLookupNo"].ToString());
                                break;
                            }
                        case "lkp":
                            {
                                frmSearch.AddSearchItem(LangCenter.Instance.IsDefaultLanguage ? dr["sCaption"].ToString() : dr["sEngCaption"].ToString(),
                                                        dr["sFieldName"].ToString(), FiledType.L, dr["sLookupNo"].ToString());
                                break;
                            }
                        case "det":
                            {
                                frmSearch.AddSearchItem(LangCenter.Instance.IsDefaultLanguage ? dr["sCaption"].ToString() : dr["sEngCaption"].ToString(),
                                                        dr["sFieldName"].ToString(), FiledType.D);
                                break;
                            }
                    }
                }
                if (frmSearch.ShowDialog() == DialogResult.OK)
                {
                    MasterFilterSQL = " AND " + frmSearch.SearchSQL;
                }
            }
        }

        #endregion
    }
}
