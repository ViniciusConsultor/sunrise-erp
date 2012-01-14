﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SqlClient;

using Sunrise.ERP.Security;
using Sunrise.ERP.BasePublic;
using Sunrise.ERP.Lang;
using Sunrise.ERP.BaseControl;
using Sunrise.ERP.BaseForm.DAL;
using Sunrise.ERP.DataAccess;

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
        protected SecurityCenter SC = new SecurityCenter();

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
                dtMain = GetDataSet(top, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, sortfield).Tables[0];
            }
            else
            {
                dtMain = GetDataSet(top, "1=1 " + pWhere, sortfield).Tables[0];
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
                dtMain = GetDataSet(top, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, sortfield).Tables[0];
            }
            else
            {
                dtMain = GetDataSet(top, "1=1 " + pWhere, sortfield).Tables[0];
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
                dtMain = GetDataSet(100000, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, SortField).Tables[0];
            }
            else
            {
                dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
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
                dtMain = GetDataSet(100000, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, SortField).Tables[0];
            }
            else
            {
                dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
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
                dtMain = GetDataSet(SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
            }
            else
            {
                dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
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
                dtMain = GetDataSet(SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
            }
            else
            {
                dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
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
                dtMain = GetDataSet(SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
            }
            else
            {
                dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
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
                dtMain = GetDataSet(SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
            }
            else
            {
                dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
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
            e.Row.EndEdit();
        }
        #endregion

        #region 重写基本按钮状态控制
        /// <summary>
        /// 查询
        /// </summary>
        public override void DoView()
        {
            if (MasterFilerSQL != "")
            {
                if (TopCount != 499 && SortField != "dInputDate DESC")
                {
                    if (IsCheckAuth)
                    {
                        dtMain = GetDataSet(TopCount, SC.GetAuthSQL(ShowType.FormQuery, FormID) + pWhere + MasterFilerSQL, SortField).Tables[0];
                    }
                    else
                    {
                        dtMain = GetDataSet(TopCount, "1=1 " + pWhere + MasterFilerSQL, SortField).Tables[0];
                    }
                    dsMain.DataSource = dtMain;
                    dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                }
                else
                {
                    if (IsCheckAuth)
                    {
                        dtMain = GetDataSet(SC.GetAuthSQL(ShowType.FormQuery, FormID) + pWhere + MasterFilerSQL).Tables[0];
                    }
                    else
                    {
                        dtMain = GetDataSet("1=1 " + pWhere + MasterFilerSQL).Tables[0];
                    }
                    dsMain.DataSource = dtMain;
                    dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                }
            }
            if (dsMain.Current != null)
            {
                base.DoView();
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                IsDataChange = false;
            }
            else
            {
                initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.None);
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
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
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                IsDataChange = false;
            }
            else
            {
                initButtonsState(OperateFlag.None);
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                IsDataChange = false;
            }
        }

        /// <summary>
        /// 新增之前执行的方法
        /// </summary>
        public override bool DoAppend()
        {
            Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, false);
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
                    if (Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "DataNotSavedForCancel"), 4) == DialogResult.Yes)
                    {
                        if (TopCount != 499 & SortField != "dInputDate DESC")
                        {
                            if (IsCheckAuth)
                            {
                                dtMain = GetDataSet(TopCount, SC.GetAuthSQL(MasterFilerSQL == "" ? ShowType.FormShow : ShowType.FormQuery, FormID) + pWhere, SortField).Tables[0];
                            }
                            else
                            {
                                dtMain = GetDataSet(TopCount, "1=1 " + pWhere, SortField).Tables[0];
                            }
                            dsMain.DataSource = dtMain;
                            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);

                        }
                        else
                        {
                            if (IsCheckAuth)
                            {
                                dtMain = GetDataSet(SC.GetAuthSQL(MasterFilerSQL == "" ? ShowType.FormShow : ShowType.FormQuery, FormID) + pWhere).Tables[0];
                            }
                            else
                            {
                                dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
                            }
                            dsMain.DataSource = dtMain;
                            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                        }
                        dsMain.CancelEdit();
                        Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
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
                            dtMain = GetDataSet(TopCount, SC.GetAuthSQL(MasterFilerSQL == "" ? ShowType.FormShow : ShowType.FormQuery, FormID) + pWhere, SortField).Tables[0];
                        }
                        else
                        {
                            dtMain = GetDataSet(TopCount, "1=1 " + pWhere, SortField).Tables[0];
                        }
                        dsMain.DataSource = dtMain;
                        dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                    }
                    else
                    {
                        if (IsCheckAuth)
                        {
                            dtMain = GetDataSet(SC.GetAuthSQL(MasterFilerSQL == "" ? ShowType.FormShow : ShowType.FormQuery, FormID) + pWhere).Tables[0];
                        }
                        else
                        {
                            dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
                        }
                        dsMain.DataSource = dtMain;
                        dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                    }
                    dsMain.CancelEdit();
                    Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                    IsDataChange = false;
                    return base.DoBeforeCancel();
                }
            }
            else
            {
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
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
            Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, false);
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
                if (!NotCopyFields.Contains(drTemp.Table.Columns[i].ColumnName))
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
        /// 保存
        /// </summary>
        /// <returns></returns>
        public override bool DoSave()
        {
            SqlTransaction trans = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection.BeginTransaction();
            if (FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsInsert)
            {
                try
                {
                    Add(((DataRowView)dsMain.Current).Row, trans);
                    trans.Commit();
                    if (TopCount != 499 & SortField != "dInputDate DESC")
                    {
                        if (IsCheckAuth)
                        {
                            dtMain = GetDataSet(TopCount, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, SortField).Tables[0];
                        }
                        else
                        {
                            dtMain = GetDataSet(TopCount, "1=1 " + pWhere, SortField).Tables[0];
                        }
                        dsMain.DataSource = dtMain;
                        dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                    }
                    else
                    {
                        if (IsCheckAuth)
                        {
                            dtMain = GetDataSet(SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
                        }
                        else
                        {
                            dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
                        }
                        dsMain.DataSource = dtMain;
                        dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                    }
                    Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                    IsDataChange = false;
                    return base.DoSave();

                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
            else
            {
                try
                {
                    Update(((DataRowView)dsMain.Current).Row, trans);
                    trans.Commit();
                    if (TopCount != 499 & SortField != "dInputDate DESC")
                    {
                        if (IsCheckAuth)
                        {
                            dtMain = GetDataSet(TopCount, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, SortField).Tables[0];
                        }
                        else
                        {
                            dtMain = GetDataSet(TopCount, "1=1 " + pWhere, SortField).Tables[0];
                        }
                        dsMain.DataSource = dtMain;
                        dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                    }
                    else
                    {
                        if (IsCheckAuth)
                        {
                            dtMain = GetDataSet(SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
                        }
                        else
                        {
                            dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
                        }
                        dsMain.DataSource = dtMain;
                        dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                    }
                    Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                    IsDataChange = false;
                    return base.DoSave();
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
        /// <summary>
        /// 保存前执行的方法
        /// </summary>
        /// <returns></returns>
        public override bool DoBeforeSave()
        {
            //非空验证
            if (NotNullFields.Count > 0)
            {
                if (Sunrise.ERP.BasePublic.Base.CheckNotNullFields(this.pnlInfo, NotNullFields))
                {
                    Sunrise.ERP.BasePublic.Base.IsNull = true;
                    return true;
                }
                else
                {
                    Sunrise.ERP.BasePublic.Base.IsNull = true;
                    return false;
                }
            }
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
                if (Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "DeleteData"), 1) == DialogResult.OK)
                {
                    SqlTransaction trans = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection.BeginTransaction();
                    try
                    {
                        Delete(BillID, trans);
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
                if (Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "DataNotSavedForClose"), 4) == DialogResult.Yes)
                {
                    Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
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
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
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
            Sunrise.ERP.BasePublic.Base.SetNotNullFiledsColor(this.pnlInfo, NotNullFields);
            IsDataChange = false;

        }

        private int pnlInfoHeight = 300;
        private void splitterControl1_DoubleClick(object sender, EventArgs e)
        {
            if (pnlInfo.Height != 0)
            {
                pnlInfoHeight = pnlInfo.Height;
                pnlInfo.Height = 0;
                toolTipController1.SetToolTip(splitterControl1, LangCenter.Instance.GetFormLangInfo("BaseForm", "DbClickToExpand"));
            }
            else
            {
                pnlInfo.Height = pnlInfoHeight;
                toolTipController1.SetToolTip(splitterControl1, LangCenter.Instance.GetFormLangInfo("BaseForm", "DbClickToClose"));
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
        public int Add(DataRow dr, SqlTransaction trans)
        {
            try
            {
                return MasterDynamicDAL.Add(dr, trans);
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
        public void Update(DataRow dr, SqlTransaction trans)
        {
            try
            {
                MasterDynamicDAL.Update(dr, trans);
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
        public void Delete(int id, SqlTransaction trans)
        {
            try
            {
                MasterDynamicDAL.Delete(id, trans);
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
        public DataSet GetDataSet(string pwhere)
        {
            try
            {
                return MasterDynamicDAL.GetList(pwhere); ;
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
        public DataSet GetDataSet(int top, string pwhere, string order)
        {
            try
            {
                return MasterDynamicDAL.GetList(top, pwhere, order);
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
            Sunrise.ERP.BasePublic.Base.SetControlsGridEnable(this.pnlGrid, FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsBrowse);
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
        protected string MasterFilerSQL
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

        private DynamicDALSetting _MasterDynamicDAL;
        /// <summary>
        /// 主表或单表数据操作层
        /// </summary>
        protected DynamicDALSetting MasterDynamicDAL
        {
            get
            {
                if (_MasterDynamicDAL != null)
                {
                    _MasterDynamicDAL = new DynamicDALSetting(DynamicTableData);
                }
                return _MasterDynamicDAL;
            }
        }

        private DataTable _dynamicdatatable;
        /// <summary>
        /// 动态表结构数据
        /// </summary>
        protected DataTable DynamicTableData
        {
            get
            {
                if (_dynamicdatatable == null)
                {
                    _dynamicdatatable = Base.GetDynamicTableData(FormID, MasterTableName);
                }
                return _dynamicdatatable;
            }
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
        #endregion

        #region 窗体自定义设置

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }

        #endregion


    }
}
