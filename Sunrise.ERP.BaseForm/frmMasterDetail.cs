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
using Sunrise.ERP.Security;
using Sunrise.ERP.BaseControl;
using Sunrise.ERP.BasePublic;
namespace Sunrise.ERP.BaseForm
{
    /// <summary>
    /// 基础主从表窗体
    /// </summary>
    public partial class frmMasterDetail : frmSingleForm
    {
        /// <summary>
        /// 明细数据表集合
        /// </summary>
        protected List<DataSet> LDetailDataSet = new List<DataSet>();
        /// <summary>
        /// 从表字段集合
        /// </summary>
        protected List<string> LDetailField = new List<string>();
        /// <summary>
        /// 主表字段集合
        /// </summary>
        protected List<string> LMasterField = new List<string>();
        /// <summary>
        /// 明细表数据层对象名集合
        /// </summary>
        protected List<string> LDetailDALName = new List<string>();

        /// <summary>
        /// 明细表排序字段集合
        /// </summary>
        protected Hashtable DetailOrderField = new Hashtable();

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmMasterDetail()
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="dalname">数据层对象名称</param>
        public frmMasterDetail(int formid, string dalpath, string dalname)
            : base(formid, dalpath,dalname)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="dalname">数据层对象名称</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmMasterDetail(int formid, string dalpath, string dalname, bool ischeckauth)
            : base(formid, dalpath,dalname, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="dalname">数据层对象名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        public frmMasterDetail(int formid, string dalpath, string dalname, string pwhere)
            : base(formid, dalpath,dalname, pwhere)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="dalname">数据层对象名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmMasterDetail(int formid, string dalpath, string dalname, string pwhere, bool ischeckauth)
            : base(formid, dalpath,dalname, pwhere, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="dalname">数据层对象名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="sortfield">排序字段</param>
        public frmMasterDetail(int formid, string dalpath, string dalname, string pwhere, string sortfield)
            : base(formid, dalpath,dalname, pwhere, sortfield)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="dalname">数据层对象名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="sortfield">排序字段</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmMasterDetail(int formid, string dalpath, string dalname, string pwhere, string sortfield, bool ischeckauth)
            : base(formid, dalpath,dalname, pwhere, sortfield, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="dalname">数据层对象名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="top">前多少数据</param>
        /// <param name="sortfield">排序字段</param>
        public frmMasterDetail(int formid, string dalpath, string dalname, int top, string pwhere, string sortfield)
            : base(formid, dalpath,dalname, top, pwhere, sortfield)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="dalname">数据层对象名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="top">前多少数据</param>
        /// <param name="sortfield">排序字段</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmMasterDetail(int formid, string dalpath, string dalname, int top, string pwhere, string sortfield, bool ischeckauth)
            : base(formid, dalpath,dalname, top, pwhere, sortfield, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// 保存
        /// 加入事务处理
        /// </summary>
        /// <returns></returns>
        public override bool DoSave()
        {
            SqlTransaction trans = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection.BeginTransaction();
            try
            {
                //先保存主表
                RegisterMethod(MasterDALPath, MasterDALName, true);
                if (FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsInsert)
                {
                    BillID = Add(((DataRowView)dsMain.Current).Row, trans);
                    //((Sunrise.ERP.Model.Base.BaseEntity)dsMain.Current).ID = BillID;
                }
                else
                {
                    Update(((DataRowView)dsMain.Current).Row, trans);
                }
                //保存从表
                for (int i = 0; i < LDetailDataSet.Count; i++)
                {
                    RegisterMethod(MasterDALPath, LDetailDALName[i]);
                    foreach (DataRow dr in LDetailDataSet[i].Tables[0].Rows)
                    {
                        //增加
                        if (dr.RowState == DataRowState.Added && dr["ID"].ToString()=="")
                        {
                            dr[LDetailField[i]] = GetMasterLinkValue(LMasterField[i]);
                            dr["ID"] = Add(dr, trans);
                        }
                        //更新
                        else if (dr.RowState == DataRowState.Modified && dr["ID"].ToString() != "")
                        {
                            Update(dr, trans);
                        }
                        //删除
                        else if (dr.RowState == DataRowState.Deleted && dr["ID", DataRowVersion.Original].ToString() != "")
                        {
                            Delete(Convert.ToInt32(dr["ID", DataRowVersion.Original]), trans);
                        }
                    }
                }
                trans.Commit();
                return true;
            }
            catch
            {
                trans.Rollback();
                return false;
            }
        }
        public override bool DoAfterSave()
        {
            RegisterMethod(MasterDALPath,MasterDALName, true);
            if (TopCount != 499 && SortField != "dInputDate DESC")
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

            Base.SetAllControlsReadOnly(this.pnlInfo, true);
            IsDataChange = false;
            initButtonsState(OperateFlag.Save);
            return base.DoAfterSave();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public override bool DoDelete()
        {
            if (BillID > 0)
            {
                if (Public.SystemInfo("是否删除该数据？", 1) == DialogResult.OK)
                {
                    SqlTransaction trans = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection.BeginTransaction();
                    try
                    {
                        RegisterMethod(MasterDALPath,MasterDALName, true);
                        Delete(BillID, trans);
                        trans.Commit();
                        dsMain.RemoveCurrent();
                        IsDataChange = false;
                        //base.DoDelete();
                        if (dsMain.Current == null)
                        {
                            initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.None);
                        }
                        else
                        {
                            initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.Delete);
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
        /// 增加明细数据表
        /// 关联字段一定是要一一对应，否则系统无法建立其关系
        /// </summary>
        /// <param name="dalname">数据层对象</param>
        ///<param name="detailfield">主从表关联字段-从表字段</param>
        ///<param name="masterfield">主从表关联字段-主表字段</param>
        public void AddDetailData(string dalname, string detailfield, string masterfield)
        {
            LDetailDALName.Add(dalname);
            LDetailField.Add(detailfield);
            LMasterField.Add(masterfield);
            RegisterMethod(MasterDALPath,dalname);
            LDetailDataSet.Add(GetDataSet(detailfield + "=" + GetMasterLinkValue(masterfield)));
        }
        /// <summary>
        /// 增加明细数据表
        /// 关联字段一定是要一一对应，否则系统无法建立其关系
        /// </summary>
        /// <param name="dalname">数据层对象</param>
        ///<param name="detailfield">主从表关联字段-从表字段</param>
        ///<param name="masterfield">主从表关联字段-主表字段</param>
        ///<param name="sortfield">明细表排序字段，可以多个，e.g:ID DESC,OrderNo</param>
        public void AddDetailData(string dalname, string detailfield, string masterfield, string sortfield)
        {
            LDetailDALName.Add(dalname);
            LDetailField.Add(detailfield);
            LMasterField.Add(masterfield);
            DetailOrderField.Add(dalname, sortfield);
            RegisterMethod(MasterDALPath,dalname);
            string swhere = sortfield != "" ? detailfield + "=" + GetMasterLinkValue(masterfield) + " ORDER BY " + sortfield : detailfield + "=" + GetMasterLinkValue(masterfield);
            LDetailDataSet.Add(GetDataSet(swhere));
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
                    if (LDetailDataSet.Count > 0)
                    {
                        for (int i = 0; i < LDetailDataSet.Count; i++)
                        {
                            string swhere = "";
                            RegisterMethod(MasterDALPath,LDetailDALName[i]);
                            swhere = LDetailField[i] + "=" + GetMasterLinkValue(LMasterField[i]);
                            if (DetailOrderField[LDetailDALName[i]] != null && DetailOrderField[LDetailDALName[i]].ToString() != "")
                            {
                                swhere += " ORDER BY " + DetailOrderField[LDetailDALName[i]].ToString();
                            }
                            LDetailDataSet[i] = GetDataSet(swhere);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    //当主表数据为空时清空所有明细数据
                    for (int i = 0; i < LDetailDataSet.Count; i++)
                    {
                        LDetailDataSet[i].Clear();
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
            {
                sResult = BillID.ToString();
            }
            else
            {
                try
                {
                    RegisterMethod(MasterDALPath, MasterDALName, true);
                    sResult = GetDataSet(1, "ID=" + BillID.ToString(), "ID").Tables[0].Rows[0][masterfield].ToString();
                }
                catch (Exception)
                {
                    Public.SystemInfo("主从表连接字段设置错误！", true);
                }
            }
            return sResult;
        }

        private int pnlGridWidth = 200;
        private void splitterControl2_DoubleClick(object sender, EventArgs e)
        {
            if (pnlGrid.Width != 0)
            {
                pnlGridWidth = pnlGrid.Width;
                pnlGrid.Width = 0;
                toolTipController1.SetToolTip(splitterControl2, "双击展开窗口");
            }
            else
            {
                pnlGrid.Width = pnlGridWidth;
                toolTipController1.SetToolTip(splitterControl2, "双击折叠窗口");
            }
        }
    }
}