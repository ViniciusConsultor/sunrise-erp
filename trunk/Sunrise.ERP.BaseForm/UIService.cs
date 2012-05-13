using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

using Sunrise.ERP.DataAccess;
using Sunrise.ERP.Controls;
using Sunrise.ERP.BasePublic;
using Sunrise.ERP.BaseControl;
using Sunrise.ERP.Security;
using Sunrise.ERP.Lang;

namespace Sunrise.ERP.BaseForm
{
    public class UIService
    {
        #region GridControl
        #region CreateGridColumns
        /// <summary>
        /// 创建明细数据表Grid列
        /// </summary>
        /// <param name="gv">需要创建的Grid</param>
        /// <param name="formID"></param>
        /// <param name="tablename">明细数据表名称</param>
        /// <param name="lpkBindSource"></param>
        public static void GridCreateColumns(Form frm, GridView gv, int formID, string tableName, object lpkBindSource, SunriseLookUp.SunriseLookUpEvent slookHandler)
        {
            if (gv == null) return;
            DataTable dtColumnsConfig = Base.GetDynamicTableData(formID, tableName); //列配置数据
            gv.BeginUpdate();
            gv.Columns.Clear();
            int iIndex = 0;
            string sFilter = string.Format("bShowInGrid=1 AND sTableName='{0}'", tableName);
            DataRow[] drs = dtColumnsConfig.Select(sFilter);
            foreach (DataRow dr in drs)
            {
                string sFieldName = dr["sFieldName"].ToString();
                GridColumn gc = null;
                DataRow[] drFields = GetFormFieldSetting(formID).Select(string.Format("sTableName='{0}' and sFieldName='{1}'", tableName, sFieldName));
                bool allowEdit = true;
                //如果已经设置过界面字段数据
                if (drFields.Length > 0)
                {
                    DataRow drField = drFields[0];
                    if ((bool)drField["bVisiable"] == false) continue;
                    allowEdit = (bool)drField["bEdit"];
                }
                gc = GridCreateColumn(frm, gv, dr, tableName, iIndex, allowEdit, formID, lpkBindSource, slookHandler);
                iIndex++;
                if (gc != null) gv.Columns.Add(gc);
            }
            gv.EndUpdate();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="dr"></param>
        /// <param name="tableName"></param>
        /// <param name="index"></param>
        /// <param name="isuseredit"></param>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static GridColumn GridCreateColumn(Form frm, GridView gv, DataRow drConfig, string tableName, int index, bool allowEdit, int formID, object lpkBindSource, SunriseLookUp.SunriseLookUpEvent slookHandler)
        {
            GridColumn gc = new GridColumn();
            string sControlType = drConfig["sControlType"].ToString();
            string sFieldName = drConfig["sFieldName"].ToString();
            string sLookupNo = drConfig["sLookupNo"].ToString();
            string sColumnType = drConfig["sColumnType"].ToString();
            #region 设置ColumnEdit
            switch (sControlType)
            {
                case "lkp":
                    #region LookUp查询
                    if (!string.IsNullOrEmpty(sLookupNo) && lpkBindSource != null)
                    {
                        SunriseLookUp lkp = new SunriseLookUp();
                        lkp.Name = string.Format("collkp{0}{1}", tableName, sFieldName);
                        lkp.DataBindings.Add("EditValue", lpkBindSource, sFieldName);
                        Base.InitLookup(lkp, sLookupNo);
                        string sLookupAutoSetControl = drConfig["sLookupAutoSetControl"].ToString();
                        if (!string.IsNullOrEmpty(sLookupAutoSetControl))
                        {
                            string[] sItem = Public.GetSplitString(sLookupAutoSetControl, ",");
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
                        if (slookHandler != null) lkp.LookUpAfterPost += slookHandler;
                        //if (slookHandler != null) lkp.LookUpAfterPost += new SunriseLookUp.SunriseLookUpEvent(lkp_LookUpAfterPost);
                        gc.ColumnEdit = btnRepositoryItem;
                        gv.GridControl.RepositoryItems.Add(btnRepositoryItem);
                    }
                    break;
                    #endregion
                case "cbx":
                    #region 下拉框
                    if (!string.IsNullOrEmpty(sLookupNo))
                    {
                        RepositoryItemImageComboBox cbxRepositoryItem = new RepositoryItemImageComboBox();
                        Base.InitRepositoryItemComboBox(cbxRepositoryItem, sLookupNo, (string)drConfig["sFieldType"]);
                        gc.ColumnEdit = cbxRepositoryItem;
                        gv.GridControl.RepositoryItems.Add(cbxRepositoryItem);
                    }
                    break;
                    #endregion
                case "btxt":
                    #region 带按钮的文本框
                    RepositoryItemMemoExEdit btxtRepositoryItem = new RepositoryItemMemoExEdit();
                    gc.ColumnEdit = btxtRepositoryItem;
                    gv.GridControl.RepositoryItems.Add(btxtRepositoryItem);
                    break;
                    #endregion
                //modify by han
                #region
                //多行文本框
                case "mtxt":

                    RepositoryItemMemoExEdit mtxtRepositoryItem = new RepositoryItemMemoExEdit();
                    mtxtRepositoryItem.Name = "colmtxt" + tableName + drConfig["sFieldName"].ToString();
                    gc.ColumnEdit = mtxtRepositoryItem;
                    gv.GridControl.RepositoryItems.Add(mtxtRepositoryItem);
                    break;

                //MLookUp查询
                case "mlkp":
                    {
                        if (!string.IsNullOrEmpty(drConfig["sLookupNo"].ToString()))
                        {
                            SunriseMLookUp mlkp = new SunriseMLookUp();
                            mlkp.Name = "colmlkp" + tableName + drConfig["sFieldName"].ToString();
                            mlkp.DataBindings.Add("EditValue", lpkBindSource, drConfig["sFieldName"].ToString());
                            mlkp.IsUsedInGrid = true;

                            Base.InitMLookup(mlkp, drConfig["sLookupNo"].ToString());
                            if (!string.IsNullOrEmpty(drConfig["sLookupAutoSetControl"].ToString()))
                            {
                                string[] sItem = Public.GetSplitString(drConfig["sLookupAutoSetControl"].ToString(), ",");
                                foreach (var s in sItem)
                                {
                                    string[] ss = Public.GetSplitString(s, "=");
                                    mlkp.AutoSetValue(ss[0], ss[1]);
                                }
                            }
                            RepositoryItemPopupContainerEdit btnRepositoryItem = new RepositoryItemPopupContainerEdit();
                            btnRepositoryItem.Name = "gridmlkp" + tableName + drConfig["sFieldName"].ToString();
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
                            // mlkp.LookUpAfterPost += new SunriseLookUp.SunriseLookUpEvent(lkp_LookUpAfterPost);
                            mlkp.LookUpAfterPost += slookHandler;

                            gc.ColumnEdit = btnRepositoryItem;
                            gv.GridControl.RepositoryItems.Add(btnRepositoryItem);
                            frm.Controls.Add(mlkp);
                            mlkp.Location = new Point(frm.Size.Height / 2, frm.Size.Width / 2);
                            mlkp.SendToBack();
                        }
                        break;
                    }
                #endregion
            }
            #endregion
            gc.Caption = LangCenter.Instance.IsDefaultLanguage ? drConfig["sCaption"].ToString() : drConfig["sEngCaption"].ToString();
            gc.FieldName = sFieldName;
            gc.Name = string.Format("col{0}{1}", tableName, sFieldName);//Grid 列命名为col+表名+列名
            gc.Width = 120;
            if (sColumnType == "002" && !SC.CheckAuth(SecurityOperation.Price, formID)) return null;//检测是否有价格权限
            if (sColumnType == "003" && !SC.CheckAuth(SecurityOperation.Num, formID)) return null;//检测是否有数量权限
            gc.Visible = true;
            gc.VisibleIndex = index;
            #region 检测窗体字段设置中是否可编辑
            //这里检测的时候是先以窗体设置中的权限优先，窗体上设置不可编辑，用户字段设置可编辑，以窗体上设置为准，不可编辑
            bool bEdit = Convert.ToBoolean(drConfig["bEdit"]);
            //先通过数量和价格权限检测后再设置其用户字段权限
            if (bEdit) bEdit = allowEdit;
            gc.OptionsColumn.AllowEdit = bEdit;
            #endregion
            #region Grid Footer显示
            string sFooterType = (string)drConfig["sFooterType"];
            gc.SummaryItem.FieldName = sFieldName;
            DevExpress.Data.SummaryItemType sitype = DevExpress.Data.SummaryItemType.None;
            if (sFooterType == "001") sitype = DevExpress.Data.SummaryItemType.None;  //001	无
            if (sFooterType == "002") sitype = DevExpress.Data.SummaryItemType.Sum;//002	求和
            if (sFooterType == "003") sitype = DevExpress.Data.SummaryItemType.Count;//003	计数
            if (sFooterType == "004") sitype = DevExpress.Data.SummaryItemType.Average;//004	平均值
            if (sFooterType == "005") sitype = DevExpress.Data.SummaryItemType.Max;//005	最大值
            if (sFooterType == "006") sitype = DevExpress.Data.SummaryItemType.Min;//006	最小值
            gc.SummaryItem.SummaryType = sitype;
            if (sitype != DevExpress.Data.SummaryItemType.None) gv.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, sFieldName, gc);
            #endregion

            //modify by han
            //设置非空字段颜色
            if (Convert.ToBoolean(drConfig["bSaveData"]) && Convert.ToBoolean(drConfig["bNotNull"]))
            {
                gc.AppearanceHeader.ForeColor = Color.FromName(Base.GetSystemParamter("001"));
                gc.AppearanceHeader.Options.UseForeColor = true;
            }

            return gc;
        }
        //设置为查询完成后自动跳转到Grid中的下一列中
        private static bool lkp_LookUpAfterPost(object sender, ButtonPressedEventArgs e)
        {
            Control lkp = (Control)sender;
            if (lkp.DataBindings.Count == 0) return false;
            BindingSource bs = (BindingSource)lkp.DataBindings[0].DataSource;
            bs.EndEdit();
            return true;
        }

        #endregion
        /// <summary>
        /// 获取鼠标是否在数据区域(包含数据行和空白区域)
        /// </summary>
        public static bool GridMouseInDataArea(GridView gv)
        {
            if (gv == null) return false;
            DevExpress.XtraGrid.GridControl gc = gv.GridControl;
            if (gc == null) return false;
            System.Drawing.Point pt = gc.PointToClient(Control.MousePosition);
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo ghi = gv.CalcHitInfo(pt);
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest ght = ghi.HitTest;
            if (ght == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.Row) return true;
            if (ght == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell) return true;
            if (ght == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.EmptyRow) return true;
            return false;
        }
        #endregion
        #region LayoutControl

        public static void LayoutDataBindings(int formID, string tableName, Control parentControl, BindingSource bsData, List<string> unCopyFields)
        {
            Control[] ctls;
            DataTable dtColumnsConfig = Base.GetDynamicTableData(formID, tableName); //列配置数据
            DataTable dtFormFieldSetting = GetFormFieldSetting(formID);
            foreach (DataRow dr in dtColumnsConfig.Select("sControlType<>'lbl'"))
            {
                string sFieldName = dr["sFieldName"].ToString();
                string sColumnType = dr["sColumnType"].ToString();
                //添加不可复制的字段
                if (!Convert.ToBoolean(dr["bCopy"])) unCopyFields.Add(sFieldName);

                string ControlKey = "lbl" + sFieldName;
                ctls = parentControl.Controls.Find(ControlKey, true);
                //设置字段Label显示
                if (ctls != null && ctls.Length == 1)
                {
                    ctls[0].Text = LangCenter.Instance.IsDefaultLanguage ? dr["sCaption"].ToString() : dr["sEngCaption"].ToString();
                    //设置非空字段颜色
                    if (bool.Parse(dr["bNotNull"].ToString().ToLower()))
                        ctls[0].ForeColor = Color.FromName(Base.GetSystemParamter("001"));
                }

                ControlKey = dr["sControlType"].ToString() + sFieldName;
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

                    ctls[0].DataBindings.Add("EditValue", bsData, sFieldName);

                    //数量或者价格权限检测
                    if (sColumnType == "002")
                    {
                        //检测是否有价格权限
                        bool HasPrice = SC.CheckAuth(SecurityOperation.Price, formID);
                        //设置该字段控件及其对应Label标签也不显示
                        Control[] lblctls = parentControl.Controls.Find("lbl" + sFieldName, true);
                        if (lblctls != null && lblctls.Length == 1) lblctls[0].Visible = HasPrice;
                        ctls[0].Visible = HasPrice;

                        //如果界面布局用Layout，控制其显示与否
                        if (ctls[0].Parent is LayoutControl && !HasPrice)
                            ((LayoutControl)ctls[0].Parent).GetItemByControl(ctls[0]).Visibility = LayoutVisibility.Never;

                    }
                    else if (sColumnType == "003")
                    {
                        //检测是否有数量权限
                        bool HasNum = SC.CheckAuth(SecurityOperation.Num, formID);
                        //设置该字段控件及其对应Label标签也不显示
                        Control[] lblctls = parentControl.Controls.Find("lbl" + sFieldName, true);
                        if (lblctls != null && lblctls.Length == 1) lblctls[0].Visible = HasNum;
                        ctls[0].Visible = HasNum;

                        //如果界面布局用Layout，控制其显示与否
                        if (ctls[0].Parent is LayoutControl && !HasNum)
                            ((LayoutControl)ctls[0].Parent).GetItemByControl(ctls[0]).Visibility = LayoutVisibility.Never;
                    }

                    //控制界面上显示字段是否显示和可编辑
                    //超级用户或者在窗体字段设置没有进行过设置则显示全部
                    if (!SecurityCenter.IsAdmin && dtFormFieldSetting.Rows.Count > 0)
                    {
                        //取只有是主表/单表的数据
                        foreach (DataRow drField in dtFormFieldSetting.Select(string.Format("sTableName='{0}'", tableName)))
                        {
                            if (sFieldName == drField["sFieldName"].ToString())
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
                                    Control[] lblctls = parentControl.Controls.Find("lbl" + sFieldName, true);
                                    if (lblctls != null && lblctls.Length == 1) lblctls[0].Visible = false;
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
                        if (!string.IsNullOrEmpty(dr["sLookupNo"].ToString())) Base.InitComboBox((ImageComboBoxEdit)ctls[0], dr["sLookupNo"].ToString());
                    }
                }
            }
        }
        #endregion
        #region DataBase
        public static DataTable DBgetDataTable(string sql)
        {
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables.Count == 0) return null;
            return ds.Tables[0];
        }
        public static DataTable DBGroupDataTable(DataTable dt, string groupColumns, List<SumColumn> sumColumns)
        {
            if (dt == null) return null;
            if (sumColumns == null) sumColumns = new List<SumColumn>();

            DataTable result = new DataTable();
            string[] colsGroup = groupColumns.Split(',');
            foreach (string col in colsGroup)
            {
                if (col.Trim() == "") continue;
                result.Columns.Add(col.Trim(), dt.Columns[col.Trim()].DataType);
            }
            DataRow drprev = null;
            DataRow[] drs = dt.Select(null, groupColumns);
            foreach (DataRow dr in drs)
            {
                if (DBGroupEqualsColumn(drprev, dr)) continue;
                drprev = result.NewRow();
                foreach (DataColumn dc in result.Columns)
                {
                    drprev[dc] = dr[dc.ColumnName];
                }
                result.Rows.Add(drprev);
            }
            foreach (SumColumn sc in sumColumns)
            {
                if (sc.AliasName == "") continue;
                result.Columns.Add(sc.AliasName, sc.DataType);
            }
            foreach (DataRow dr in result.Rows)
            {
                string filter = "";
                foreach (string col in colsGroup)
                {
                    filter += string.Format("and {0}='{1}' ", col.Trim(), dr[col.Trim()]);
                }
                filter = filter.Substring(4);
                foreach (SumColumn sc in sumColumns)
                {
                    string expression = string.Format("{0}({1})", sc.Expression, sc.ColumnName);
                    object value = dt.Compute(expression, filter);
                    dr[sc.AliasName] = value;
                }
            }
            return result;
        }
        private static bool DBGroupEqualsColumn(DataRow dr1, DataRow dr2)
        {
            if (dr1 == null) return false;
            foreach (DataColumn dc in dr1.Table.Columns)
            {
                if (dr1[dc].Equals(dr2[dc.ColumnName])) continue;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 设置数据表的某列为自动递增列
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="columnName">自动递增列名称</param>
        public static void DBAutoAutoIncrement(DataTable dt, string columnName)
        {
            if (dt == null) return;
            if (columnName == null) return;
            if (columnName.Trim() == "") return;
            if (dt.Columns.Contains(columnName) == false) return;
            if (dt.Columns[columnName].AutoIncrement) return;
            dt.Columns[columnName].AutoIncrement = true;
            object value = dt.Compute(string.Format("max({0})", columnName), null);
            int maxid = 0;
            if (value != DBNull.Value) maxid = (int)value;
            dt.Columns[columnName].AutoIncrementSeed = maxid + 1;
        }
        /// <summary>
        /// 将数据表的自动递增列的新增行数值取反
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="columnName"></param>
        public static void DBReverseAutoID(DataTable dt, string columnName)
        {
            if (dt == null) return;
            if (columnName == null) return;
            if (columnName.Trim() == "") return;
            if (dt.Columns.Contains(columnName) == false) return;
            if (dt.Columns[columnName].AutoIncrement == false) return;
            foreach (DataRow dr in dt.Rows)
            {
                DBReverseAutoID(dr, columnName);
            }
        }
        public static void DBReverseAutoID(DataRow dr, string columnName)
        {
            if (dr.RowState != DataRowState.Added) return;
            object value = null;
            Type dataType = dr.Table.Columns[columnName].DataType;
            if (dataType == typeof(int))
            {
                value = -(int)dr[columnName];
            }
            else if (dataType == typeof(long))
            {
                value = -(long)dr[columnName];
            }
            dr[columnName] = value;
        }
        public static int DBExecuteSql(string sql)
        {
            return DBExecuteSql(sql, null, null);
        }
        public static int DBExecuteSql(string sql, SqlTransaction tran, params SqlParameter[] sps)
        {
            if (tran == null && sps == null) return Sunrise.ERP.DataAccess.DbHelperSQL.ExecuteSql(sql);
            if (tran == null && sps != null) return Sunrise.ERP.DataAccess.DbHelperSQL.ExecuteSql(sql, sps);
            if (tran != null && sps == null) return Sunrise.ERP.DataAccess.DbHelperSQL.ExecuteSql(sql, tran);
            return Sunrise.ERP.DataAccess.DbHelperSQL.ExecuteSql(sql, tran, sps);
        }
        public static object DBGetSingle(string sql, SqlTransaction tran)
        {
            if (tran == null) return Sunrise.ERP.DataAccess.DbHelperSQL.GetSingle(sql);
            return Sunrise.ERP.DataAccess.DbHelperSQL.GetSingle(sql, tran);
        }
        public static DataTable DBQueryTable(string sql)
        {
            return DBQueryTable(sql, null);
        }
        public static DataTable DBQueryTable(string sql, SqlTransaction tran)
        {
            if (tran == null) return Sunrise.ERP.DataAccess.DbHelperSQL.QueryTable(sql);
            return Sunrise.ERP.DataAccess.DbHelperSQL.QueryTable(sql, tran);
        }
        #endregion
        #region Language
        public static DialogResult ShowMessage(string key, params object[] datas)
        {
            string value = LangCenter.Instance.GetSystemMessage(key);
            string sMsg = string.Format(value, datas);
            return Public.SystemInfo(sMsg);
        }
        public static DialogResult ShowMessage(string key, string dataValue)
        {
            string value = LangCenter.Instance.GetSystemMessage(key);
            return Public.SystemInfo(value + "\r\n" + dataValue);
        }
        #endregion
        #region 系统配置
        private static SecurityCenter m_SC = null;
        /// <summary>
        /// 系统权限处理对象
        /// </summary>
        public static SecurityCenter SC
        {
            get
            {
                if (m_SC == null) m_SC = new SecurityCenter();
                return m_SC;
            }
        }
        /// <summary>
        /// 获取当前用户窗体字段权限数据
        /// </summary>
        public static DataTable GetFormFieldSetting(int formID)
        {
            DataTable result = Base.GetFormFieldSetting(SecurityCenter.CurrentUserID, formID);
            return result;
        }
        #endregion
    }
    public class SumColumn
    {
        public SumColumn(string columnName, string expression, string aliasName, Type dataType)
        {
            this.ColumnName = columnName;
            this.Expression = expression;
            this.AliasName = aliasName;
            this.DataType = dataType;
        }
        public string ColumnName = "";
        public string Expression = "";
        public Type DataType;
        public string AliasName = "";
    }
}