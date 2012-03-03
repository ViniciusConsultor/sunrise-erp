using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using Sunrise.ERP.BaseControl;
using Sunrise.ERP.Lang;
using Sunrise.ERP.DataAccess;
using Sunrise.ERP.Controls;
using Sunrise.ERP.Common;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace Sunrise.ERP.BasePublic
{
    /// <summary>
    /// 系统BaseForm基础控制类
    /// </summary>
    public class Base
    {
        public Base()
        {
        }

        #region 窗体操作
        /// <summary>
        /// 设置容器内控件的状态
        /// </summary>
        /// <param name="ctr">容器控件</param>
        /// <param name="isreadonly">是否只读</param>
        public static void SetAllControlsReadOnly(Control ctr, bool isreadonly)
        {
            //用递归来遍历所有控件
            foreach (Control ctl in ctr.Controls)
            {
                //当控件Tag设置为99时不受系统框架限制
                if (ctl.Tag == null || ctl.Tag.ToString() != "99")
                {
                    SetControlsReadOnly(ctl, isreadonly);
                    if (ctl.HasChildren)
                        SetAllControlsReadOnly(ctl, isreadonly);
                }
            }
        }

        /// <summary>
        /// 设置控件的状态
        /// </summary>
        /// <param name="ctl">控件名称</param>
        /// <param name="isreadonly">是否只读</param>
        public static void SetControlsReadOnly(Control ctl, bool isreadonly)
        {
            //DateEdit
            if (ctl is DevExpress.XtraEditors.DateEdit)
            {
                ((DevExpress.XtraEditors.DateEdit)ctl).Properties.ReadOnly = isreadonly;
            }
            //CheckEdit
            else if (ctl is DevExpress.XtraEditors.CheckEdit)
            {
                ((DevExpress.XtraEditors.CheckEdit)ctl).Properties.ReadOnly = isreadonly;
            }
            //ComboBoxEdit
            else if (ctl is DevExpress.XtraEditors.ComboBoxEdit)
            {
                ((DevExpress.XtraEditors.ComboBoxEdit)ctl).Properties.ReadOnly = isreadonly;
            }
            //ButtonEdit
            else if (ctl is DevExpress.XtraEditors.ButtonEdit)
            {
                ((DevExpress.XtraEditors.ButtonEdit)ctl).Properties.ReadOnly = isreadonly;
                foreach (EditorButton btn in ((DevExpress.XtraEditors.ButtonEdit)ctl).Properties.Buttons)
                {
                    btn.Enabled = !isreadonly;
                }
            }
            //RadioGroup
            else if (ctl is DevExpress.XtraEditors.RadioGroup)
            {
                ((DevExpress.XtraEditors.RadioGroup)ctl).Properties.ReadOnly = isreadonly;
            }
            //MemoEdit
            else if (ctl is DevExpress.XtraEditors.MemoEdit)
            {
                ((DevExpress.XtraEditors.MemoEdit)ctl).Properties.ReadOnly = isreadonly;
            }
            //MemoExEdit
            else if (ctl is DevExpress.XtraEditors.MemoExEdit)
            {
                ((DevExpress.XtraEditors.MemoExEdit)ctl).Properties.ReadOnly = isreadonly;
            }
            //LookUpEdit
            else if (ctl is DevExpress.XtraEditors.LookUpEdit)
            {
                ((DevExpress.XtraEditors.LookUpEdit)ctl).Properties.ReadOnly = isreadonly;
            }
            //SpinEdit
            else if (ctl is DevExpress.XtraEditors.SpinEdit)
            {
                ((DevExpress.XtraEditors.SpinEdit)ctl).Properties.ReadOnly = isreadonly;
            }
            //TimeEdit
            else if (ctl is DevExpress.XtraEditors.TimeEdit)
            {
                ((DevExpress.XtraEditors.TimeEdit)ctl).Properties.ReadOnly = isreadonly;
            }
            //CheckedComboBoxEdit
            else if (ctl is DevExpress.XtraEditors.CheckedComboBoxEdit)
            {
                ((DevExpress.XtraEditors.CheckedComboBoxEdit)ctl).Properties.ReadOnly = isreadonly;
            }
            //PictureEdit
            else if (ctl is DevExpress.XtraEditors.PictureEdit)
            {
                ((DevExpress.XtraEditors.PictureEdit)ctl).Properties.ReadOnly = isreadonly;
            }
            //ImageEdit
            else if (ctl is DevExpress.XtraEditors.ImageEdit)
            {
                ((DevExpress.XtraEditors.ImageEdit)ctl).Properties.ReadOnly = isreadonly;
            }
            //DropDownButton
            else if (ctl is DevExpress.XtraEditors.DropDownButton)
            {
                ((DevExpress.XtraEditors.DropDownButton)ctl).Enabled = isreadonly;
            }
            //ImageListBoxControl
            else if (ctl is DevExpress.XtraEditors.ImageListBoxControl)
            {
                ((DevExpress.XtraEditors.ImageListBoxControl)ctl).Enabled = isreadonly;
            }
            //SunriseLookUp
            else if (ctl is Sunrise.ERP.Controls.SunriseLookUp)
            {
                ((Sunrise.ERP.Controls.SunriseLookUp)ctl).IsReadOnly = !isreadonly;
            }
            //TextEdit
            else if (ctl is DevExpress.XtraEditors.TextEdit)
            {
                ((DevExpress.XtraEditors.TextEdit)ctl).Properties.ReadOnly = isreadonly;
            }
        }


        /// <summary>
        /// 设置容器内Grid,TreeList控件的状态
        /// </summary>
        /// <param name="ctr">容器控件</param>
        /// <param name="isenable">是否可用</param>
        public static void SetControlsGridEnable(Control ctr, bool isenable)
        {
            //用递归来遍历所有控件
            foreach (Control ctl in ctr.Controls)
            {
                if (ctl.Tag == null || ctl.Tag.ToString() != "99")
                {
                    if (ctl is DevExpress.XtraGrid.GridControl)
                    {
                        ((DevExpress.XtraGrid.GridControl)ctl).UseDisabledStatePainter = false;
                        ((DevExpress.XtraGrid.GridControl)ctl).Enabled = isenable;
                    }
                    else if (ctl is DevExpress.XtraTreeList.TreeList)
                    {
                        ((DevExpress.XtraTreeList.TreeList)ctl).UseDisabledStatePainter = false;
                        //((DevExpress.XtraTreeList.TreeList)ctl).OptionsBehavior.DragNodes = isenable;
                        ((DevExpress.XtraTreeList.TreeList)ctl).Enabled = isenable;
                    }
                    if (ctl.HasChildren)
                    {
                        SetControlsGridEnable(ctl, isenable);
                    }
                }
            }
        }
        #endregion

        #region 系统窗体控件提示操作

        /// <summary>
        /// 设置不为空字段颜色
        /// 说明：这个设置颜色只能够设置控件的父容器为LayoutControl的颜色
        /// 如果拖放了其他容器控件需要手动设置
        /// </summary>
        /// <param name="ctr">pnl控件,此控件为放置LayoutControl的pnl</param>
        /// <param name="fields">不为空字段List</param>
        public static void SetNotNullFiledsColor(Control ctr, List<string> fields)
        {
            foreach (string s in fields.ToArray())
            {
                foreach (Control ctl in ctr.Controls)
                {
                    if (ctl.Tag == null || ctl.Tag.ToString() != "99")
                    {
                        if (ctl is Sunrise.ERP.Controls.SunriseLookUp && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.TextEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.DateEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.ComboBoxEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.CheckEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                //((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                                ctl.ForeColor = System.Drawing.Color.Red;
                                //这个很奇怪，如果不加这句颜色必须要当鼠标经过控件后颜色才会有
                                ctl.Text = ctl.Text;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.ButtonEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.CheckedComboBoxEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.MemoEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.MemoExEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.LookUpEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.SpinEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.TimeEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.RadioGroup && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.ImageEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.PictureEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        if (ctl.HasChildren)
                        {
                            SetNotNullFiledsColor(ctl, fields);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 非空验证
        /// 在调用后返回后请一定要设置非空验证属性Public.IsNull=true
        /// </summary>
        /// <param name="ctr">pnl控件,此控件为放置LayoutControl的pnl</param>
        /// <param name="fields">不为空字段List</param>
        /// <returns></returns>
        public static bool CheckNotNullFields(Control ctr, List<string> fields)
        {
            return CheckNotNullFields(ctr, fields, 0);
        }
        /// <summary>
        /// 非空验证
        /// 在调用后返回后请一定要设置非空验证属性Public.IsNull=true
        /// </summary>
        /// <param name="ctr">pnl控件,此控件为放置LayoutControl的pnl</param>
        /// <param name="fields">不为空字段List</param>
        /// <param name="count">调用时默认请输入0</param>
        /// <returns></returns>
        public static bool CheckNotNullFields(Control ctr, List<string> fields, int count)
        {
            if (IsNull)
            {
                if (count == 0)
                {
                    for (int i = 0; i < fields.Count; i++)
                    {
                        foreach (Control ctl in ctr.Controls)
                        {
                            if (ctl is DevExpress.XtraEditors.TextEdit)
                            {
                                if (fields[i] == ctl.Name && ctl.Text == "")
                                {
                                    Public.SystemInfo(((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Text + LangCenter.Instance.GetSystemMessage("NotNull"));
                                    i = fields.Count;
                                    ctl.Focus();
                                    IsNull = false;
                                    return false;
                                }
                            }

                            else if (ctl is DevExpress.XtraEditors.DateEdit)
                            {
                                if (fields[i] == ctl.Name && ctl.Text == "")
                                {
                                    Public.SystemInfo(((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Text + LangCenter.Instance.GetSystemMessage("NotNull"));
                                    i = fields.Count;
                                    ctl.Focus();
                                    IsNull = false;
                                    return false;
                                }
                            }
                            else if (ctl is DevExpress.XtraEditors.ComboBoxEdit)
                            {
                                if (fields[i] == ctl.Name && ctl.Text == "")
                                {
                                    Public.SystemInfo(((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Text + LangCenter.Instance.GetSystemMessage("NotNull"));
                                    i = fields.Count;
                                    ctl.Focus();
                                    IsNull = false;
                                    return false;
                                }
                            }
                            else if (ctl is DevExpress.XtraEditors.ButtonEdit)
                            {
                                if (fields[i] == ctl.Name && ctl.Text == "")
                                {
                                    Public.SystemInfo(((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Text + LangCenter.Instance.GetSystemMessage("NotNull"));
                                    i = fields.Count;
                                    ctl.Focus();
                                    IsNull = false;
                                    return false;
                                }
                            }
                            else if (ctl is DevExpress.XtraEditors.CheckedComboBoxEdit)
                            {
                                if (fields[i] == ctl.Name && ctl.Text == "")
                                {
                                    Public.SystemInfo(((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Text + LangCenter.Instance.GetSystemMessage("NotNull"));
                                    i = fields.Count;
                                    ctl.Focus();
                                    IsNull = false;
                                    return false;
                                }
                            }
                            else if (ctl is DevExpress.XtraEditors.MemoEdit)
                            {
                                if (fields[i] == ctl.Name && ctl.Text == "")
                                {
                                    Public.SystemInfo(((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Text + LangCenter.Instance.GetSystemMessage("NotNull"));
                                    i = fields.Count;
                                    ctl.Focus();
                                    IsNull = false;
                                    return false;
                                }
                            }
                            else if (ctl is DevExpress.XtraEditors.MemoExEdit)
                            {
                                if (fields[i] == ctl.Name && ctl.Text == "")
                                {
                                    Public.SystemInfo(((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Text + LangCenter.Instance.GetSystemMessage("NotNull"));
                                    i = fields.Count;
                                    ctl.Focus();
                                    IsNull = false;
                                    return false;
                                }
                            }
                            else if (ctl is DevExpress.XtraEditors.LookUpEdit)
                            {
                                if (fields[i] == ctl.Name && ctl.Text == "")
                                {
                                    Public.SystemInfo(((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Text + LangCenter.Instance.GetSystemMessage("NotNull"));
                                    i = fields.Count;
                                    ctl.Focus();
                                    IsNull = false;
                                    return false;
                                }
                            }
                            else if (ctl is DevExpress.XtraEditors.SpinEdit)
                            {
                                if (fields[i] == ctl.Name && ctl.Text == "")
                                {
                                    Public.SystemInfo(((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Text + LangCenter.Instance.GetSystemMessage("NotNull"));
                                    i = fields.Count;
                                    ctl.Focus();
                                    IsNull = false;
                                    return false;
                                }
                            }
                            else if (ctl is DevExpress.XtraEditors.TimeEdit)
                            {
                                if (fields[i] == ctl.Name && ctl.Text == "")
                                {
                                    Public.SystemInfo(((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Text + LangCenter.Instance.GetSystemMessage("NotNull"));
                                    i = fields.Count;
                                    ctl.Focus();
                                    IsNull = false;
                                    return false;
                                }
                            }
                            else if (ctl is DevExpress.XtraEditors.RadioGroup)
                            {
                                if (fields[i] == ctl.Name && ctl.Text == "")
                                {
                                    Public.SystemInfo(((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Text + LangCenter.Instance.GetSystemMessage("NotNull"));
                                    i = fields.Count;
                                    ctl.Focus();
                                    IsNull = false;
                                    return false;
                                }
                            }
                            else
                            {
                                if (ctl.HasChildren && i < fields.Count)
                                {
                                    CheckNotNullFields(ctl, fields, i);
                                }
                            }
                        }
                        if (i == fields.Count)
                        {
                            break;
                        }
                    }
                }
                return IsNull;
            }
            else
            {
                return IsNull;
            }
        }
        #endregion

        #region 属性设置
        private static bool isnull = true;
        /// <summary>
        /// 设置非空验证属性
        /// </summary>
        public static bool IsNull
        {
            get
            {
                return isnull;
            }
            set
            {
                isnull = value;
            }
        }

        #endregion

        #region 系统基础操作方法
        /// <summary>
        /// 获取菜单参数列表
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <returns></returns>
        public static Hashtable GetFormParaList(int formid)
        {
            Hashtable formParaList = new Hashtable();
            string sSql = "SELECT A.sParamName,A.sParamValue FROM sysMenuParam A "
                        + "LEFT JOIN sysMenu B ON A.MenuID=B.ID "
                        + "WHERE B.iFormID=" + formid.ToString();
            DataTable dtTemp = DbHelperSQL.Query(sSql).Tables[0];
            foreach (DataRow dr in dtTemp.Rows)
            {
                formParaList.Add(dr["sParamName"], dr["sParamValue"]);
            }
            return formParaList;
        }

        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="paramno">系统参数编号</param>
        /// <returns></returns>
        public static string GetSystemParamter(string paramno)
        {
            string result;
            string sSql = "SELECT sSysParamValue FROM sysParamter WHERE sSysParamNo='" + paramno + "' AND bActive=1";
            DataTable dtTemp = DbHelperSQL.Query(sSql).Tables[0];
            if (dtTemp != null && dtTemp.Rows.Count == 1)
                result = dtTemp.Rows[0]["sSysParamValue"].ToString();
            else
                result = string.Empty;
            return result;
        }

        /// <summary>
        /// 检查一个表是否有自定义字段
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="formid">FormID</param>
        /// <returns>存在返回True,不存在返回False</returns>
        public static bool IsHasSubTable(string tablename,int formid)
        {
            string sSql = "SELECT COUNT(1) FROM sysobjects WHERE xtype='U' AND name='" + tablename + formid.ToString() + "_Z" + "'";
            return DbHelperSQL.Exists(sSql);
        }

        /// <summary>
        /// 检查一个表是否存在某一列
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="columnname">列名</param>
        /// <returns>存在返回True,不存在返回False</returns>
        public static bool IsColumnExist(string tablename, string columnname)
        {
            string sSql = "SELECT COUNT(1) FROM syscolumns WHERE id=OBJECT_ID('" + tablename + "') AND name='" + columnname + "'";
            return DbHelperSQL.Exists(sSql);
        }

        /// <summary>
        /// 获取表中所有的列信息
        /// </summary>
        /// <param name="tablename">表名称</param>
        /// <param name="iscontaindefault">是否包含默认列信息</param>
        /// <returns></returns>
        public static List<string> GetTableColumns(string tablename, bool iscontaindefault)
        {
            List<string> result = new List<string>();
            string sSql = "SELECT [NAME] AS ColumnName FROM syscolumns WHERE id=OBJECT_ID('" + tablename + "')";
            DataTable dtTmp = DbHelperSQL.Query(sSql).Tables[0];
            if (dtTmp != null && dtTmp.Rows.Count > 0)
            {
                foreach (DataRow dr in dtTmp.Rows)
                {
                    if (iscontaindefault)
                        result.Add(dr["ColumnName"].ToString()); 
                    else
                    {
                        if (dr["ColumnName"].ToString() != "ID" &&
                            dr["ColumnName"].ToString() != "MainTableID")
                            result.Add(dr["ColumnName"].ToString());
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取表的外键字段名称
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static string GetTableFKFieldName(string tablename)
        {
            string result = string.Empty;
            string sSql = "SELECT OBJECT_NAME(F.FKEYID) AS FTABLENAME, COL.NAME, F.CONSTID AS TEMP "
                        + "FROM SYSCOLUMNS COL,SYSFOREIGNKEYS F "
                        + "WHERE F.FKEYID=COL.ID AND F.FKEY=COL.COLID AND F.CONSTID IN "
                        + "( SELECT DISTINCT(ID)  "
                        + "FROM SYSOBJECTS "
                        + "WHERE OBJECT_NAME(PARENT_OBJ)='" + tablename + "' AND XTYPE='F')";
            DataTable dtTmp = DbHelperSQL.Query(sSql).Tables[0];
            if (dtTmp != null && dtTmp.Rows.Count > 0)
                result = dtTmp.Rows[0]["NAME"].ToString();
            return result;
        }

        /// <summary>
        /// 获取自定义表数据
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名</param>
        /// <returns></returns>
        public static DataTable GetDynamicTableData(int formid, string tablename)
        {
            string sSql = "SELECT A.*,B.sFormType, B.iDefaultQueryCount, B.iControlSpace, B.iControlColumn,B.FormID, "
                                + "B.bCreateLookUp, B.bSyncLookUp, B.sTableName, B.sQueryViewName "
                                + "FROM sysDynamicFormDetail A LEFT JOIN "
                                + "sysDynamicFormMaster B ON A.MainID=B.ID WHERE B.FormID=" + formid.ToString() + " AND B.sTableName='" + tablename + "'";
            return DbHelperSQL.Query(sSql).Tables[0];
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        internal static extern IntPtr GetFocus();
        /// <summary>
        /// 获取当前拥有焦点的控件
        /// </summary>
        /// <returns></returns>
        public static Control GetFocusedControl()
        {
            Control focusedControl = null;
            // To get hold of the focused control:
            IntPtr focusedHandle = GetFocus();
            if (focusedHandle != IntPtr.Zero)
                //focusedControl = Control.FromHandle(focusedHandle);
                focusedControl = Control.FromChildHandle(focusedHandle);
            return focusedControl;
        }

        /// <summary>
        /// 创建自定义表
        /// </summary>
        /// <param name="drs">需要创建的数据列</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="formid">FormID</param>
        public static void CreateSubTable(DataRow[] drs, string tablename,int formid)
        {
            if (drs != null && drs.Length > 0)
            {
                //不存在自定义表则直接创建自定义表
                string subtablename = tablename + formid.ToString() + "_Z";
                StringBuilder sCreateSQL = new StringBuilder();
                sCreateSQL.Append("CREATE TABLE [dbo].[" + subtablename + "] (");
                sCreateSQL.AppendLine();
                sCreateSQL.Append("[ID] [int]  IDENTITY (1, 1)  NOT NULL, ");
                sCreateSQL.AppendLine();
                sCreateSQL.Append("[MainTableID] [int] NOT NULL,");
                sCreateSQL.AppendLine();
                foreach (DataRow dr in drs)
                {
                    sCreateSQL.Append("[" + dr["sFieldName"].ToString() + "] ");
                    switch (dr["sFieldType"].ToString())
                    {
                        case "S":
                            {
                                //当字符超过8000则创建字符串为varchar(max)类型
                                string sLeng = string.Empty;
                                if (dr["iFieldLength"] != null && Convert.ToInt32(dr["iFieldLength"]) > 8000)
                                    sLeng = "max";
                                else
                                    sLeng = dr["iFieldLength"].ToString();
                                sCreateSQL.Append("[varchar] (" + sLeng + ")");
                                break;
                            }
                        case "B":
                            {
                                sCreateSQL.Append("[bit]");
                                break;
                            }
                        case "F":
                            {
                                sCreateSQL.Append("[decimal] (18," + dr["iFieldLength"].ToString() + ")");
                                break;
                            }
                        case "I":
                            {
                                sCreateSQL.Append("[int]");
                                break;
                            }
                        case "D":
                            {
                                sCreateSQL.Append("[datetime]");
                                break;
                            }
                        case "M":
                            {
                                sCreateSQL.Append("[image]");
                                break;
                            }

                    }
                    sCreateSQL.Append(" NULL, ");
                    sCreateSQL.AppendLine();
                }
                sCreateSQL.Append("CONSTRAINT [PK_" + subtablename + "] PRIMARY KEY CLUSTERED ([ID] ASC)");
                sCreateSQL.AppendLine();
                sCreateSQL.Append("WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]");
                DbHelperSQL.ExecuteSql(sCreateSQL.ToString());
                sCreateSQL.Remove(0, sCreateSQL.Length);
                sCreateSQL.Append("SET ANSI_PADDING OFF");
                DbHelperSQL.ExecuteSql(sCreateSQL.ToString());
                sCreateSQL.Remove(0, sCreateSQL.Length);
                sCreateSQL.Append("ALTER TABLE [dbo].[" + subtablename + "] " + "WITH CHECK ADD  CONSTRAINT [FK_" + subtablename + "_" + tablename + "] FOREIGN KEY([MainTableID])");
                sCreateSQL.AppendLine();
                sCreateSQL.Append("REFERENCES [dbo].[" + tablename + "] ([ID])");
                sCreateSQL.AppendLine();
                sCreateSQL.Append("ON UPDATE CASCADE ON DELETE CASCADE");
                DbHelperSQL.ExecuteSql(sCreateSQL.ToString());
                sCreateSQL.Remove(0, sCreateSQL.Length);
                sCreateSQL.Append("ALTER TABLE [dbo].[" + subtablename + "] CHECK CONSTRAINT [FK_" + subtablename + "_" + tablename + "]"); ;
                DbHelperSQL.ExecuteSql(sCreateSQL.ToString());
            }
        }

        /// <summary>
        /// 创建自定义表的列信息
        /// </summary>
        /// <param name="drs">需要创建的数据列</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="formid">FormID</param>
        public static void CreateSubTableColumns(DataRow[] drs, string tablename,int formid)
        {
            if (drs != null && drs.Length > 0)
            {
                string sTableName = tablename + formid.ToString() + "_Z";
                StringBuilder sCreateSQL = new StringBuilder();
                List<string> listColumns = new List<string>();
                List<string> tableColumns = GetTableColumns(sTableName, false);
                foreach (DataRow dr in drs)
                {
                    listColumns.Add(dr["sFieldName"].ToString());
                    if (IsColumnExist(sTableName, dr["sFieldName"].ToString()))
                    {
                        //修改表结构的话只允许修改其类型长度，字符型和浮点型
                        if (dr["sFieldType"].ToString() == "S" || dr["sFieldType"].ToString() == "F")
                        {
                            sCreateSQL.Append("ALTER TABLE " + sTableName);
                            sCreateSQL.AppendLine();
                            sCreateSQL.Append("ALTER COLUMN ");
                            sCreateSQL.Append(dr["sFieldName"].ToString());
                            switch (dr["sFieldType"].ToString())
                            {
                                case "S":
                                    {
                                        //当字符超过8000则创建字符串为varchar(max)类型
                                        string sLeng = string.Empty;
                                        if (dr["iFieldLength"] != null && Convert.ToInt32(dr["iFieldLength"]) > 8000)
                                            sLeng = "max";
                                        else
                                            sLeng = dr["iFieldLength"].ToString();
                                        sCreateSQL.Append(" [varchar] (" + sLeng + ")");
                                        break;
                                    }
                                case "F":
                                    {
                                        sCreateSQL.Append(" [decimal] (18," + dr["iFieldLength"].ToString() + ")");
                                        break;
                                    }
                            }
                            DbHelperSQL.ExecuteSql(sCreateSQL.ToString());
                            sCreateSQL.Remove(0, sCreateSQL.Length);
                        }
                    }
                    else
                    {
                        sCreateSQL.Append("ALTER TABLE " + sTableName);
                        sCreateSQL.AppendLine();
                        sCreateSQL.Append("ADD ");
                        sCreateSQL.Append(dr["sFieldName"].ToString());
                        switch (dr["sFieldType"].ToString())
                        {
                            case "S":
                                {
                                    sCreateSQL.Append(" [varchar] (" + dr["iFieldLength"].ToString() + ")");
                                    break;
                                }
                            case "B":
                                {
                                    sCreateSQL.Append(" [bit]");
                                    break;
                                }
                            case "F":
                                {
                                    sCreateSQL.Append(" [decimal] (18," + dr["iFieldLength"].ToString() + ")");
                                    break;
                                }
                            case "I":
                                {
                                    sCreateSQL.Append(" [int]");
                                    break;
                                }
                            case "D":
                                {
                                    sCreateSQL.Append(" [datetime]");
                                    break;
                                }
                            case "M":
                                {
                                    sCreateSQL.Append(" [image]");
                                    break;
                                }

                        }
                        sCreateSQL.Append(" NULL");
                        DbHelperSQL.ExecuteSql(sCreateSQL.ToString());
                        sCreateSQL.Remove(0, sCreateSQL.Length);
                    }
                }
                //删除不在listColumns中的列
                foreach (var s in tableColumns)
                {
                    bool exist = true;
                    foreach (var ss in listColumns)
                    {
                        if (string.Equals(s, ss))
                            exist = false;
                    }
                    if (exist)
                    {
                        sCreateSQL.Append("ALTER TABLE " + sTableName);
                        sCreateSQL.AppendLine();
                        sCreateSQL.Append("DROP COLUMN " + s);
                        DbHelperSQL.ExecuteSql(sCreateSQL.ToString());
                        sCreateSQL.Remove(0, sCreateSQL.Length);
                    }
                }
            }
        }

        /// <summary>
        /// 删除自定义表
        /// </summary>
        /// <param name="tablename">数据表名称</param>
        /// <param name="formid">FormID</param>
        public static void DeleteSubTable(string tablename,int formid)
        {
            if (IsHasSubTable(tablename, formid))
            {
                string sSql = "DROP TABLE [dbo].[" + tablename + formid.ToString() + "_Z]";
                DbHelperSQL.ExecuteSql(sSql);
            }
        }

        /// <summary>
        /// 初始化Lookup控件
        /// </summary>
        /// <param name="lkp">LookUp控件</param>
        /// <param name="lookupno">Lookup配置编号</param>
        public static void InitLookup(SunriseLookUp lkp, string lookupno)
        {
            string sSql = "SELECT sLookupNo, sSQL, sDataField, sDisplayField, sGridDisplayField, "
                        + "sGridColumnText, sEnGridColumnText, sSearchFormText, sEnSearchFormText "
                        + "FROM sysLookupSetting " 
                        + "WHERE sType='LookUp' AND sLookupNo='" + lookupno + "'";
            DataTable dtTmp = DbHelperSQL.Query(sSql).Tables[0];
            if (dtTmp != null && dtTmp.Rows.Count > 0)
            {
                string SearchFormText = LangCenter.Instance.IsDefaultLanguage ?
                    dtTmp.Rows[0]["sSearchFormText"].ToString() : dtTmp.Rows[0]["sEnSearchFormText"].ToString();
                string SQL = dtTmp.Rows[0]["sSQL"].ToString();
                string DataField = dtTmp.Rows[0]["sDataField"].ToString();
                string DisplayField = dtTmp.Rows[0]["sDisplayField"].ToString();
                string GridDisplayField = dtTmp.Rows[0]["sGridDisplayField"].ToString();
                string GridColumnText = LangCenter.Instance.IsDefaultLanguage ?
                    dtTmp.Rows[0]["sGridColumnText"].ToString() : dtTmp.Rows[0]["sEnGridColumnText"].ToString();
                SystemPublic.InitLookUpBase(lkp, SQL, DataField, DisplayField, GridDisplayField, GridColumnText, SearchFormText);
            }
        }

        /// <summary>
        /// 初始化ComboBox
        /// </summary>
        /// <param name="cbx">ComboBox控件</param>
        /// <param name="comboboxno">ComboBox配置编号</param>
        public static void InitComboBox(ImageComboBoxEdit cbx, string comboboxno)
        {
            string sSql = "SELECT sGridDisplayField,sGridColumnText, sEnGridColumnText "
                        + "FROM sysLookupSetting "
                        + "WHERE sType='ComboBox' AND sLookupNo='" + comboboxno + "'";
            DataTable dtTmp = DbHelperSQL.Query(sSql).Tables[0];
            if (dtTmp != null && dtTmp.Rows.Count > 0)
            {
                string[] ValueFields = Public.GetSplitString(dtTmp.Rows[0]["sGridDisplayField"].ToString(), ",");
                string[] DisplayText = Public.GetSplitString(LangCenter.Instance.IsDefaultLanguage ?
                    dtTmp.Rows[0]["sGridColumnText"].ToString() : dtTmp.Rows[0]["sEnGridColumnText"].ToString(), ",");
                if (ValueFields.Length == DisplayText.Length)
                {
                    cbx.Properties.Items.Clear();
                    for (int i = 0; i < ValueFields.Length; i++)
                    {
                        cbx.Properties.Items.Add(new ImageComboBoxItem(DisplayText[i], ValueFields[i]));
                    }
                }
                else
                    Public.SystemInfo(LangCenter.Instance.GetSystemMessage("InitComboBoxFailed"), true);                
            }
        }

        /// <summary>
        /// 初始化RepositoryItemImageComboBox
        /// </summary>
        /// <param name="cbx">RepositoryItemImageComboBox控件</param>
        /// <param name="comboboxno">ComboBox配置编号</param>
        public static void InitRepositoryItemComboBox(RepositoryItemImageComboBox cbx, string comboboxno)
        {
            string sSql = "SELECT sGridDisplayField,sGridColumnText, sEnGridColumnText "
                        + "FROM sysLookupSetting "
                        + "WHERE sType='ComboBox' AND sLookupNo='" + comboboxno + "'";
            DataTable dtTmp = DbHelperSQL.Query(sSql).Tables[0];
            if (dtTmp != null && dtTmp.Rows.Count > 0)
            {
                string[] ValueFields = Public.GetSplitString(dtTmp.Rows[0]["sGridDisplayField"].ToString(), ",");
                string[] DisplayText = Public.GetSplitString(LangCenter.Instance.IsDefaultLanguage ?
                    dtTmp.Rows[0]["sGridColumnText"].ToString() : dtTmp.Rows[0]["sEnGridColumnText"].ToString(), ",");
                if (ValueFields.Length == DisplayText.Length)
                {
                    cbx.Items.Clear();
                    for (int i = 0; i < ValueFields.Length; i++)
                    {
                        cbx.Items.Add(new ImageComboBoxItem(DisplayText[i], ValueFields[i]));
                    }
                }
                else
                    Public.SystemInfo(LangCenter.Instance.GetSystemMessage("InitComboBoxFailed"), true);
            }
        }

        /// <summary>
        /// 获取用户窗体字段权限数据
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="formid">FormID</param>
        /// <returns></returns>
        public static DataTable GetFormFieldSetting(string userid, int formid)
        {
            string sSql = "SELECT UserID, FormID, sTableName, sFieldName, bVisiable, bEdit FROM sysFormFieldSetting WHERE UserID='"
                                + userid + "' AND FormID=" + formid.ToString();
            return DbHelperSQL.Query(sSql).Tables[0];
        }

        #endregion
    }
}
