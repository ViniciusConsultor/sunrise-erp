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

namespace Sunrise.ERP.BasePublic
{
    /// <summary>
    /// 系统BaseForm基础控制类
    /// </summary>
    public class BasePublic
    {
        public BasePublic()
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
                if (ctl.Tag == null || ctl.Tag.ToString() != "99")
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
                    //SpinEdit
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
                    else if (ctl is Sunrise.ERP.Controls.SunriseLookUp)
                    {
                        ((Sunrise.ERP.Controls.SunriseLookUp)ctl).IsReadOnly = !isreadonly;
                    }
                    //TextEdit
                    else if (ctl is DevExpress.XtraEditors.TextEdit)
                    {
                        ((DevExpress.XtraEditors.TextEdit)ctl).Properties.ReadOnly = isreadonly;
                    }

                    if (ctl.HasChildren)
                    {
                        SetAllControlsReadOnly(ctl, isreadonly);
                    }
                }
            }
        }

        /// <summary>
        /// 设置容器内Grid控件的状态
        /// </summary>
        /// <param name="ctr">容器控件</param>
        /// <param name="isreadonly">是否可用</param>
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
                        //((DevExpress.XtraTreeList.TreeList)ctl).OptionsBehavior.Editable = isenable;
                        ((DevExpress.XtraTreeList.TreeList)ctl).OptionsBehavior.DragNodes = isenable;
                        //((DevExpress.XtraGrid.GridControl)ctl).En
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
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.TextEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.DateEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.ComboBoxEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.CheckEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                //((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                                ctl.ForeColor = System.Drawing.Color.Blue;
                                //这个很奇怪，如果不加这句颜色必须要当鼠标经过控件后颜色才会有
                                ctl.Text = ctl.Text;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.ButtonEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.CheckedComboBoxEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.MemoEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.MemoExEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.LookUpEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.SpinEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.TimeEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.RadioGroup && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.ImageEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        else if (ctl is DevExpress.XtraEditors.PictureEdit && ctl.Parent is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (s == ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).Control.Name)
                            {
                                ((DevExpress.XtraLayout.LayoutControl)ctl.Parent).GetItemByControl(ctl).AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
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
        public static Hashtable FormParaList(int formid)
        {
            Hashtable formParaList = new Hashtable();
            string sSql = "SELECT A.sParamName,A.sParamValue FROM sysMenuParam A "
                        + "LEFT JOIN sysMenu B ON A.MenuID=B.ID "
                        + "WHERE B.iFormID=" + formid.ToString();
            DataTable dtTemp = Sunrise.ERP.DataAccess.DbHelperSQL.Query(sSql).Tables[0];
            foreach (DataRow dr in dtTemp.Rows)
            {
                formParaList.Add(dr["sParamName"], dr["sParamValue"]);
            }
            return formParaList;
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

        #endregion
    }
}
