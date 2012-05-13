using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

using Sunrise.ERP.BasePublic;
using Sunrise.ERP.Security;
using Sunrise.ERP.BaseForm;
using Sunrise.ERP.BaseForm.DAL;

namespace Sunrise.ERP.BaseForm
{
    public class BTOperators : List<BTOperator>
    {
        #region 初始化
        public BTOperators(int formID, string mastertableName, string filter, string sortfields, int topRowCount, bool isCheckAuth)
        {
            this.m_FormID = formID;
            BTOperator bto = new BTOperator(this.FormID, mastertableName, filter, sortfields, topRowCount, isCheckAuth);
            base.Add(bto);
            this.m_DataSet = new DataSet();
            this.m_DataSet.Tables.Add(bto.DataTable);
            this.m_MasterBTOperator = bto;
            this.m_MasterTable = bto.DataTable;
            this.m_MasterBindingSource = bto.BindingSource;
        }
        #endregion
        #region 属性
        private int m_FormID = 0;
        public int FormID { get { return this.m_FormID; } }
        private DataSet m_DataSet = null;
        public DataSet DataSet { get { return this.m_DataSet; } }
        private DataTable m_MasterTable = null;
        public DataTable MasterTable { get { return this.m_MasterTable; } }
        private BindingSource m_MasterBindingSource = null;
        public BindingSource MasterBindingSource { get { return this.m_MasterBindingSource; } }
        private BTOperator m_MasterBTOperator = null;
        public BTOperator MasterBTOperator { get { return this.m_MasterBTOperator; } }

        private DataTable m_FormFieldSetting = null;
        /// <summary>
        /// 获取当前用户窗体字段权限数据
        /// </summary>
        public DataTable FormFieldSetting
        {
            get
            {
                if (this.m_FormFieldSetting == null)
                {
                    this.m_FormFieldSetting = Base.GetFormFieldSetting(SecurityCenter.CurrentUserID, FormID);
                }
                return this.m_FormFieldSetting;
            }
        }
        #endregion
        #region 函数
        public override string ToString()
        {
            return this.m_FormID.ToString();
        }
        public BTOperator Add(string detailtableName, string filter, string sortfields, BTOperator btoParent, string detailField, string relationName)
        {
            BTOperator result = new BTOperator(this.FormID, detailtableName, filter, sortfields, this, btoParent, detailField, relationName);
            base.Add(result);
            return result;
        }

        public void FillDetailDatas()
        {
            DataRow drMaster = ((DataRowView)this.MasterBindingSource.Current).Row;
            if (drMaster.RowState == DataRowState.Added) return;
            foreach (BTOperator bto in this)
            {
                if (bto == this.MasterBTOperator) continue;
                bto.GetDetailDatas();
            }
        }

        /// <summary>
        /// 根据数据表序号获数据
        /// </summary>
        /// <param name="tableIndex"></param>
        /// <returns></returns>
        public BTOperator FindBTOperator(string tableName)
        {
            foreach (BTOperator bto in this)
            {
                if (bto.TableName == tableName) return bto;
            }
            return null;
        }
        /// <summary>
        /// 根据数据表序号获数据
        /// </summary>
        /// <param name="tableIndex"></param>
        /// <returns></returns>
        public DataTable FindDataTable(int tableIndex)
        {
            if (tableIndex < 0) return null;
            if (tableIndex > this.DataSet.Tables.Count - 1) return null;
            DataTable dt = this.DataSet.Tables[tableIndex];
            return dt;
        }
        /// <summary>
        /// 根据数据表名称获数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable FindDataTable(string tableName)
        {
            if (this.DataSet.Tables.Contains(tableName) == false) return null;
            return this.DataSet.Tables[tableName];
        }
        /// <summary>
        /// 获取数据源的绑定的数据表
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public DataTable FindDataTable(BindingSource bs)
        {
            if (bs == null) return null;
            if (bs.DataSource == null) return null;
            if ((bs.DataSource is DataTable) == false) return null;
            return (DataTable)(bs.DataSource);
        }
        /// <summary>
        /// 根据数据表名称获数据源
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public BindingSource FindBindingSource(string tableName)
        {
            foreach (BTOperator bto in this)
            {
                DataTable dt = bto.DataTable;
                if (dt == null) continue;
                if (dt.TableName == tableName) return bto.BindingSource;
            }
            return null;
        }

        public bool CheckAuth(SecurityOperation so, string dataUserID)
        {
            BTOperator btoMaster = this.MasterBTOperator;
            if (btoMaster.IsCheckAuth == false) return true;
            if (dataUserID == null) SC.CheckAuth(so, btoMaster.FormID);
            return SC.CheckAuth(so, btoMaster.FormID, dataUserID);
        }
        /// <summary>
        /// 提交主数据以及明细数据的修改
        /// </summary>
        public void AcceptChanges()
        {
            BTOperator btoMaster = this.MasterBTOperator;
            BindingSource bsmaster = btoMaster.BindingSource;
            DataRow drMaster = ((DataRowView)bsmaster.Current).Row;
            drMaster.AcceptChanges();
            foreach (BTOperator bto in this)
            {
                if (bto.DataTable == this.MasterTable) continue;
                DataTable dtDetail = bto.DataTable;
                dtDetail.AcceptChanges();
            }
        }
        #endregion
        #region 静态属性和函数
        public static readonly SecurityCenter SC = new SecurityCenter();
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="pwhere">条件</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string tableName, DynamicDALSetting DALobj, string pwhere)
        {
            return GetDataTable(tableName, DALobj, int.MaxValue, pwhere, "dInputDate");
        }
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="top">前数据行</param>
        /// <param name="pwhere">条件</param>
        /// <param name="order">排序字段</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string tableName, DynamicDALSetting DALobj, int top, string pwhere, string order)
        {
            DataSet ds = DALobj.GetList(top, pwhere, order);
            DataTable dt = ds.Tables[0].Copy();
            ds.Tables[0].Rows.Clear();
            ds.Tables.Clear();
            ds.Dispose();
            dt.TableName = tableName;
            dt.AcceptChanges();
            return dt;
        }
        #endregion
    }
    public class BTOperator
    {
        #region 初始化
        public BTOperator(int formID, string tableName, string filter, string sortFields, int topRowCount, bool isCheckAuth)
        {
            this.Init(formID, tableName, filter, sortFields, topRowCount, isCheckAuth);
            string formauth = "1=1 ";
            if (this.IsCheckAuth) formauth = BTOperators.SC.GetAuthSQL(ShowType.FormShow, this.FormID);
            this.GetTableData(formauth);
            this.m_DataTable.TableName = tableName;
            UIService.DBAutoAutoIncrement(this.DataTable, "ID");
            this.m_DataTable.ColumnChanged += new DataColumnChangeEventHandler(Table_ColumnChanged);
            this.m_BindingSource = new BindingSource(this.m_DataTable, "");
        }
        public BTOperator(int formID, string detailtablename, string filter, string sortFields, BTOperators owner, BTOperator btoParent, string detailField, string relationName)
        {
            this.Init(formID, detailtablename, filter, sortFields, int.MaxValue, false);
            this.m_MIDName = detailField;
            this.m_Owner = owner;
            this.m_ParentBTOperator = btoParent;
            this.m_IsCheckAuth = false;
            string swhere = filter;
            this.GetTableData("1=2");
            this.m_DataTable.TableName = detailtablename;
            owner.DataSet.Tables.Add(this.m_DataTable);
            UIService.DBAutoAutoIncrement(this.m_DataTable, "ID");
            this.m_DataTable.ColumnChanged += new DataColumnChangeEventHandler(Table_ColumnChanged);
            this.m_DataTable.TableNewRow += new DataTableNewRowEventHandler(Table_NewRow);
            this.m_BindingSource = new BindingSource(this.m_DataTable, "");
            this.m_BindingSource.CurrentChanged += new EventHandler(CurrentRow_Changed);

            if (relationName == null) relationName = "";
            if (relationName != "")
            {
                DataRelation dre = new DataRelation(relationName, btoParent.DataTable.Columns["ID"], this.DataTable.Columns[detailField], true);
                owner.DataSet.Relations.Add(dre);
                btoParent.ChildBTOperators.Add(this);
            }
        }
        private void Init(int formID, string tableName, string filter, string sortFields, int topRowCount, bool isCheckAuth)
        {
            this.m_FormID = formID;
            this.m_TableName = tableName;
            this.m_Filter = filter;
            if (sortFields == null) sortFields = "";
            if (sortFields == "") sortFields = "dInputDate DESC";
            this.m_SortFields = sortFields;
            if (topRowCount > -1) this.m_TopRowCount = topRowCount;
            this.m_IsCheckAuth = isCheckAuth;

            this.m_dtFieldsData = Base.GetDynamicTableData(this.FormID, tableName);
            this.m_DynamicDALSetting = new DynamicDALSetting(this.m_dtFieldsData);
        }
        #endregion
        #region 属性
        private DataTable m_dtFieldsData = null;
        /// <summary>
        /// 表字段设置信息
        /// </summary>
        public DataTable dtFieldsData { get { return this.m_dtFieldsData; } }
        private int m_FormID = 0;
        public int FormID { get { return this.m_FormID; } }
        private string m_TableName = "";
        public string TableName { get { return this.m_TableName; } }
        private int m_TopRowCount = 499;
        public int TopRowCount { get { return this.m_TopRowCount; } }
        private string m_Filter = "";
        public string Filter { get { return this.m_Filter; } set { this.m_Filter = value; } }
        private string m_MasterFilter = "";
        public string MasterFilter { get { return this.m_MasterFilter; } set { this.m_MasterFilter = value; } }
        private string m_SortFields = "";
        public string SortFields { get { return this.m_SortFields; } }
        private bool m_IsCheckAuth = true;
        /// <summary>
        /// 设置窗体是否需要进行权限验证
        /// </summary>
        public bool IsCheckAuth { get { return this.m_IsCheckAuth; } }
        private string m_MIDName = "";
        public string MIDName { get { return this.m_MIDName; } }

        private DynamicDALSetting m_DynamicDALSetting = null;
        public DynamicDALSetting DynamicDALSetting { get { return this.m_DynamicDALSetting; } }
        private DataTable m_DataTable = null;
        public DataTable DataTable { get { return this.m_DataTable; } }
        private BTOperators m_Owner = null;
        public BTOperators Owner { get { return this.m_Owner; } }
        private BTOperator m_ParentBTOperator = null;
        public BTOperator ParentBTOperator { get { return this.m_ParentBTOperator; } }
        private DataTable m_ParentTable = null;
        public DataTable ParentTable { get { return this.m_ParentTable; } }
        private List<BTOperator> m_ChildBTOperators = null;
        public List<BTOperator> ChildBTOperators
        {
            get
            {
                if (this.m_ChildBTOperators != null) return this.m_ChildBTOperators;
                this.m_ChildBTOperators = new List<BTOperator>();
                return this.m_ChildBTOperators;
            }
        }
        private BindingSource m_BindingSource = null;
        public BindingSource BindingSource { get { return this.m_BindingSource; } }
        #endregion
        #region 函数
        public override string ToString()
        {
            return this.TableName;
        }
        #region 数据库操作
        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="dr">数据行对象</param>
        /// <param name="trans">SQL事务</param>
        /// <returns></returns>
        public int DBAdd(DataRow dr, SqlTransaction trans)
        {
            return this.DynamicDALSetting.Add(dr, trans);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="dr">数据行对象</param>
        /// <param name="trans">SQL事务</param>
        /// <returns></returns>
        public void DBUpdate(DataRow dr, SqlTransaction trans)
        {
            this.DynamicDALSetting.Update(dr, trans);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">单据ID</param>
        /// <param name="trans">SQL事务</param>
        /// <returns></returns>
        public void DBDelete(DataRow dr, SqlTransaction trans)
        {
            int id = (int)(dr["ID", DataRowVersion.Original]);
            this.DynamicDALSetting.Delete(id, trans);
        }

        #endregion
        public int GetCurrentID()
        {
            DataRowView drv = (DataRowView)this.BindingSource.Current;
            if (drv == null) return 0;
            return (int)drv.Row["ID"];
        }
        public List<int> GetIDS()
        {
            List<int> ids = new List<int>();
            foreach (DataRow dr in this.DataTable.Rows)
            {
                if (dr.RowState == DataRowState.Detached) continue;
                ids.Add((int)dr["ID"]);
            }
            return ids;
        }
        public string GetIDString()
        {
            string result = "";
            List<int> ids = this.GetIDS();
            if (ids.Count == 0) { return string.Format("-1", this.MIDName); }
            foreach (int id in ids)
            {
                result += string.Format("{0},", id);
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }
        public void GetDetailDatas()
        {
            string swhere = "";
            if (this.ParentBTOperator == Owner.MasterBTOperator)
            {
                swhere += string.Format("{0}={1}", this.MIDName, this.ParentBTOperator.GetCurrentID());
            }
            else
            {
                swhere += string.Format("{0} in({1})", this.MIDName, this.ParentBTOperator.GetIDString());
            }
            this.GetTableData(swhere);
        }
        private void CopyDatas(DataTable dttemp)
        {
            try
            {
                // this.DataTable.BeginLoadData();
                this.DataTable.Rows.Clear();
                foreach (DataRow drtemp in dttemp.Rows)
                {
                    DataRow dr = this.DataTable.NewRow();
                    this.FillDataRow(dr, drtemp);
                    this.DataTable.Rows.Add(dr);
                }
                // this.DataTable.EndLoadData();
                this.DataTable.AcceptChanges();
            }
            catch { }
        }

        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="top">前数据行</param>
        /// <param name="pwhere">条件</param>
        /// <param name="order">排序字段</param>
        /// <returns></returns>
        public void GetTableData(string filter)
        {
            string where = "";
            if (this.Filter != "") where += string.Format("and {0} ", this.Filter);
            if (filter != "") where += string.Format("and {0} ", filter);
            if (this.MasterFilter != "") where += string.Format("and {0} ", this.MasterFilter);
            if (where != null) where = where.Substring(4);
            DataSet ds = this.m_DynamicDALSetting.GetList(this.TopRowCount, where, this.SortFields);
            DataTable dttemp = ds.Tables[0];
            if (this.m_DataTable == null)
            {
                this.m_DataTable = dttemp.Copy();
                this.m_DataTable.AcceptChanges();
                return;
            }
            this.CopyDatas(dttemp);
            ds.Tables[0].Rows.Clear();
            ds.Tables.Clear();
            ds.Dispose();
        }
        public void FillDataRow(DataRow drDes, DataRow drSrc)
        {
            DataTable dtDes = drDes.Table;
            DataTable dtSrc = drSrc.Table;
            foreach (DataColumn dc in dtDes.Columns)
            {
                if (dtSrc.Columns.Contains(dc.ColumnName) == false) continue;
                drDes[dc] = drSrc[dc.ColumnName];
            }
        }
        #endregion
        #region 事件函数
        protected void Table_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            //e.Row.EndEdit();
        }
        void Table_NewRow(object sender, DataTableNewRowEventArgs e)
        {
            DataTable dt = (DataTable)sender;
            if (dt.ParentRelations.Count == 0) return;
            DataRelation dre = dt.ParentRelations[0];
            DataTable dtparent = dre.ParentTable;
            DataColumn dcParent = dre.ParentColumns[0];
            DataColumn dcChild = dre.ChildColumns[0];
            BindingSource bs = this.ParentBTOperator.BindingSource;
            if (bs == null) return;
            if (bs.Current == null) return;
            e.Row[dcChild] = ((DataRowView)bs.Current).Row[dcParent];
            if (this.TableNewRow == null) return;
            this.TableNewRow(sender, e);
        }
        private void CurrentRow_Changed(object sender, EventArgs e)
        {
            BindingSource bs = (BindingSource)sender;
            DataTable dt = (DataTable)bs.DataSource;
            if (dt.ChildRelations.Count == 0) return;
            foreach (DataRelation dre in dt.ChildRelations)
            {
                DataTable dtchild = dre.ChildTable;
                DataColumn dcParent = dre.ParentColumns[0];
                DataColumn dcChild = dre.ChildColumns[0];
                BindingSource bsChild = this.Owner.FindBindingSource(dtchild.TableName);
                bsChild.AllowNew = (bs.Current != null);
                if (bs.Current == null) continue;
                dtchild.Columns[dcChild.ColumnName].DefaultValue = ((DataRowView)bs.Current).Row[dcParent];
            }
        }
        #endregion
        #region 自定义事件
        public event DataTableNewRowEventHandler TableNewRow = null;
        #endregion
    }
}