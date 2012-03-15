using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using Sunrise.ERP.Lang;
using Sunrise.ERP.BaseControl;

namespace Sunrise.ERP.Controls
{
    public partial class SunriseLookUp : DevExpress.XtraEditors.XtraUserControl
    {
        private string _searchsql;
        private string _griddisplayname;
        private string _griddisplayfield;
        private string _displayfield;
        private string _valuefield;
        private string _searchformtext;
        private bool _ismulti=false;
        private DataTable _dt;
        private bool _isedit = false;
        private string _editformname;
        private string _editformfilter;
        private int _editformid = 0;
        private string _searchformfilter = "";


        private List<Control> LAutoSetControl = new List<Control>();
        private List<string> LAutoSetFields = new List<string>();
        private List<string> LAutoSetValueFields = new List<string>();

        private DevExpress.XtraGrid.Views.Grid.GridView gvTemp;

        public SunriseLookUp()
        {
            InitializeComponent();
            
        }

        #region 属性

        [Category("LookUp设置"), Description("是否多选"), DefaultValue(false)]
        public bool IsMultiSelect
        {
            get
            {
                return _ismulti;
            }
            set
            {
                _ismulti = value;
            }
        }
        [Category("LookUp设置"), Description("设置绑定字段"), Bindable(true)]
        public string EditValue
        {
            get
            {
                return txtValueText.Text;
            }
            set
            {
                txtValueText.Text = value;
            }
        }

        [Category("LookUp设置"), Description("设置返回字段")]
        public string DataField
        {
            get
            {
                return _valuefield;
            }
            set
            {
                _valuefield = value;
            }
        }

        [Category("LookUp设置"), Description("设置LookUp显示字段")]
        public string DisplayField
        {
            get
            {
                return _displayfield;
            }
            set
            {
                _displayfield = value;
            }
        }

        [Category("LookUp设置"), Description("设置Grid显示字段,用\",\"间隔")]
        public string GridDisplayField
        {
            get
            {
                return _griddisplayfield;
            }
            set
            {
                _griddisplayfield = value;
            }
        }

        [Category("LookUp设置"), Description("设置查询SQL")]
        public string SQL
        {
            get
            {
                return _searchsql;
            }
            set
            {
                _searchsql = value;
            }
        }

        [Category("LookUp设置"), Description("设置GRID列显示名称,用\",\"间隔")]
        public string GridColumnText
        {
            get
            {
                return _griddisplayname;
            }
            set
            {
                _griddisplayname = value;
            }
        }
        [Category("LookUp设置"), Description("设置控件是否只读(可用)"),DefaultValue(true)]
        public bool IsReadOnly
        {
            get
            {
                return txtDisplayText.Properties.Buttons[0].Enabled;
            }
            set
            {
                txtDisplayText.Properties.Buttons[0].Enabled = value;
                if (value)
                {
                    txtDisplayText.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                }
                else
                {
                    txtDisplayText.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                }
                txtDisplayText.Properties.ReadOnly = !value;
            }
        }

        [Category("LookUp设置"), Description("设置选择窗体Text")]
        public string SearchFormText
        {
            get
            {
                if (_searchformtext == null)
                {
                    _searchformtext = "";
                }
                return _searchformtext;
            }
            set
            {
                _searchformtext= value;
            }
        }
        /// <summary>
        /// 返回的查询数据结果
        /// </summary>
        [Category("LookUp设置"), Description("返回查询的结果")]
        public DataTable ReturnData
        {
            get
            {
                if (_dt != null && _dt.Rows.Count > 0)
                {
                    return _dt;
                }
                else
                {
                    return new DataTable();
                }
            }
        }
        /// <summary>
        /// 是否允许编辑查询结果
        /// </summary>
        [Category("LookUp设置"), Description("设置是否允许编辑查询结果"), DefaultValue(false)]
        public bool IsSearchFormEdit
        {
            get
            {
                return _isedit;
            }
            set
            {
                _isedit = value;
            }
        }

        /// <summary>
        /// 编辑弹出窗体名称
        /// </summary>
        [Category("LookUp设置"), Description("设置编辑弹出窗体名称(包括完整的命名空间)，例如：Sunrise.ERP.Module.SystemBase.frmbasDataDict")]
        public string EditFormName
        {
            get
            {
                return _editformname;
            }
            set
            {
                _editformname = value;
            }
        }
        /// <summary>
        /// 编辑弹出窗体数据条件
        /// </summary>
        [Category("LookUp设置"), Description("设置编辑弹出窗体数据条件，例如数据字典：sDictCategoryNo=1001")]
        public string EditFormFilter
        {
            get
            {
                return _editformfilter;
            }
            set
            {
                _editformfilter = value;
            }
        }

        /// <summary>
        /// 查询窗体数据条件
        /// </summary>
        [Category("LookUp设置"), Description("设置查询窗体数据条件，例如数据字典：sDictCategoryNo=1001")]
        public string SearchFormFilter
        {
            get
            {
                return _searchformfilter;
            }
            set
            {
                _searchformfilter = value;
            }
        }

        /// <summary>
        /// 编辑弹出窗体ID
        /// </summary>
        [Category("LookUp设置"), Description("设置编辑弹出窗体ID，确保正确")]
        public int EditFormID
        {
            get
            {
                return _editformid;
            }
            set
            {
                _editformid = value;
            }
        }

        public Font TextFont
        {
            get
            {
                return txtDisplayText.Font;
            }
            set
            {
                txtDisplayText.Font = value;
            }
        }

        private int _formid;
        /// <summary>
        /// 获取或设置控件所属FormID
        /// </summary>
        public int FormID
        {
            get { return _formid; }
            set { _formid = value; }
        }
        #endregion

        /// <summary>
        /// LookUp查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LookUpSelfClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string sql = "";
                //检测SQL设置
                if (SQL == null || SQL == "")
                {
                    Public.SystemInfo(LangCenter.Instance.GetControlLangInfo("SunriseLookUp", "NoSQL"), true);
                    return;
                }
                if (IsSearchFormEdit)
                {
                    if (EditFormName == null || EditFormName == "")
                    {
                        Public.SystemInfo(LangCenter.Instance.GetControlLangInfo("SunriseLookUp", "NoEditFormName"), true);
                        return;
                    }
                    if (EditFormID == 0)
                    {
                        Public.SystemInfo(LangCenter.Instance.GetControlLangInfo("SunriseLookUp", "NoEditFormID"), true);
                        return;
                    }

                }
                if (LookUpBeforePost != null)
                {
                    if (!LookUpBeforePost(sender, e))
                    {
                        return;
                    }
                }
                if (SearchFormFilter != "" && SearchFormFilter != null)
                {
                    sql = "SELECT A.* FROM (" + SQL + ") A WHERE " + SearchFormFilter;
                }
                else
                {
                    sql = SQL;
                }
                frmLookUpSearch frm = new frmLookUpSearch(sql, GridColumnText, GridDisplayField, SearchFormText, IsMultiSelect, IsSearchFormEdit, EditFormName, EditFormFilter, EditFormID);
                DialogResult result;
                if (IsMultiSelect)
                {
                    result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        if (frm.ReturnData != null)
                        {
                            if (frm.ReturnData.Rows.Count > 0)
                            {
                                //选择的结果
                                _dt = frm.ReturnData;
                                if (LookUpAfterPost != null)
                                {
                                    if (!LookUpAfterPost(sender, e))
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        if (frm.ReturnData != null)
                        {
                            if (frm.ReturnData.Rows.Count == 1)
                            {
                                //选择的结果
                                _dt = frm.ReturnData;
                                txtDisplayText.Focus();
                                txtValueText.Text = _dt.Rows[0][DataField].ToString();
                                if (this.DataBindings.Count>0 && this.DataBindings[0].DataSource is System.Windows.Forms.BindingSource)
                                {
                                    ((DataRowView)((System.Windows.Forms.BindingSource)(this.DataBindings[0].DataSource)).Current).Row[this.DataBindings[0].BindingMemberInfo.BindingField] = EditValue;
                                    ((System.Windows.Forms.BindingSource)(this.DataBindings[0].DataSource)).EndEdit();
                                }
                                if (LookUpAfterPost != null)
                                {
                                    if (!LookUpAfterPost(sender, e))
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        txtDisplayText.Focus();
                        EditValue = string.Empty;
                        if (this.DataBindings.Count > 0 && this.DataBindings[0].DataSource is System.Windows.Forms.BindingSource)
                        {
                            //清空数据
                            ((DataRowView)((System.Windows.Forms.BindingSource)(this.DataBindings[0].DataSource)).Current).Row[this.DataBindings[0].BindingMemberInfo.BindingField] = DBNull.Value;
                            ((System.Windows.Forms.BindingSource)(this.DataBindings[0].DataSource)).EndEdit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Public.SystemInfo("LookUp Error：" + ex.Message,true);
            }
        }

        private void txtValueText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtDisplayText.Text = "";
                string sSql = "";
                //if (EditValue != "" && EditValue!="0")
                if (EditValue != "")
                {
                    //sSql = "SELECT A." + DisplayField + " FROM (" + SQL + ") A WHERE " + DataField + "='" + EditValue + "'";
                    //sSql = "SELECT A.*" + " FROM (" + SQL + ") A WHERE " + DataField + "='" + EditValue + "'";
                    if (SearchFormFilter != "" && SearchFormFilter != null)
                    {
                        sSql = "SELECT A.* FROM (" + SQL + ") A WHERE " + SearchFormFilter;
                    }
                    else
                    {
                        sSql = SQL;
                    }
                    //DataTable dt = Sunrise.ERP.DataAccess.DbHelperSQL.Query(sSql).Tables[0];
                    DataRow[] dr = Sunrise.ERP.DataAccess.DbHelperSQL.Query(sSql).Tables[0].Select(DataField + "='" + EditValue + "'");
                    //if (dt.Rows.Count > 0)
                    if (dr.Length > 0)
                    {
                        //txtDisplayText.Text = dt.Rows[0][DisplayField].ToString();
                        txtDisplayText.Text = dr[0][DisplayField].ToString();
                        //txtDisplayText.Focus();
                        for (int i = 0; i < LAutoSetControl.ToArray().Length; i++)
                        {
                            LAutoSetControl[i].Focus();
                            if (LAutoSetControl[i] is TextBox || LAutoSetControl[i] is TextEdit ||
                                LAutoSetControl[i] is MemoEdit || LAutoSetControl[i] is MemoExEdit)
                                LAutoSetControl[i].Text = _dt.Rows[0][LAutoSetValueFields[i]].ToString();
                            if (LAutoSetControl[i] is SunriseLookUp)
                                ((SunriseLookUp)LAutoSetControl[i]).EditValue = _dt.Rows[0][LAutoSetValueFields[i]].ToString();
                            if (LAutoSetControl[i] is ImageComboBoxEdit)
                                ((ImageComboBoxEdit)LAutoSetControl[i]).EditValue = _dt.Rows[0][LAutoSetValueFields[i]].ToString();
                            if (LAutoSetControl[i] is ComboBoxEdit)
                                ((ComboBoxEdit)LAutoSetControl[i]).EditValue = _dt.Rows[0][LAutoSetValueFields[i]].ToString();

                        }
                        if (gvTemp != null)
                            for (int i = 0; i < LAutoSetFields.ToArray().Length; i++)
                            {
                                gvTemp.Focus();
                                if (this.DataBindings.Count > 0 && this.DataBindings[0].DataSource is System.Windows.Forms.BindingSource)
                                {
                                    //先要设置控件绑定的值,在设置自动赋值的字段
                                    ((DataTable)(((System.Windows.Forms.BindingSource)(this.DataBindings[0].DataSource)).DataSource)).Rows[gvTemp.GetFocusedDataSourceRowIndex()][this.DataBindings[0].BindingMemberInfo.BindingField] = EditValue;
                                    ((DataTable)(((System.Windows.Forms.BindingSource)(this.DataBindings[0].DataSource)).DataSource)).Rows[gvTemp.GetFocusedDataSourceRowIndex()][LAutoSetFields[i]] = dr[0][LAutoSetValueFields[i]];
                                    //((System.Windows.Forms.BindingSource)(this.DataBindings[0].DataSource)).EndEdit();
                                }
                                else
                                {
                                    ((DataSet)(this.DataBindings[0].DataSource)).Tables[0].Rows[gvTemp.GetFocusedDataSourceRowIndex()][this.DataBindings[0].BindingMemberInfo.BindingField] = EditValue;
                                    ((DataSet)(this.DataBindings[0].DataSource)).Tables[0].Rows[gvTemp.GetFocusedDataSourceRowIndex()][LAutoSetFields[i]] = dr[0][LAutoSetValueFields[i]];
                                    ((DataSet)(this.DataBindings[0].DataSource)).Tables[0].AcceptChanges();
                                }
                            }
                        else
                            for (int i = 0; i < LAutoSetFields.ToArray().Length; i++)
                            {
                                if (this.DataBindings.Count > 0 && this.DataBindings[0].DataSource is System.Windows.Forms.BindingSource)
                                {
                                    //先要设置控件绑定的值,在设置自动赋值的字段
                                    //((DataTable)(((System.Windows.Forms.BindingSource)(this.DataBindings[0].DataSource)).DataSource)).Rows[gvTemp.GetFocusedDataSourceRowIndex()][this.DataBindings[0].BindingMemberInfo.BindingField] = EditValue;
                                    //((DataTable)(((System.Windows.Forms.BindingSource)(this.DataBindings[0].DataSource)).DataSource)).Rows[gvTemp.GetFocusedDataSourceRowIndex()][LAutoSetFields[i]] = dr[0][LAutoSetValueFields[i]];
                                    ((DataRowView)((System.Windows.Forms.BindingSource)(this.DataBindings[0].DataSource)).Current).Row[this.DataBindings[0].BindingMemberInfo.BindingField] = EditValue;
                                    ((DataRowView)((System.Windows.Forms.BindingSource)(this.DataBindings[0].DataSource)).Current).Row[LAutoSetFields[i]] = dr[0][LAutoSetValueFields[i]];
                                    ((System.Windows.Forms.BindingSource)(this.DataBindings[0].DataSource)).EndEdit();
                                }
                                //else
                                //{
                                //    ((DataSet)(this.DataBindings[0].DataSource)).Tables[0].Rows[gvTemp.GetFocusedDataSourceRowIndex()][this.DataBindings[0].BindingMemberInfo.BindingField] = EditValue;
                                //    ((DataSet)(this.DataBindings[0].DataSource)).Tables[0].Rows[gvTemp.GetFocusedDataSourceRowIndex()][LAutoSetFields[i]] = dr[0][LAutoSetValueFields[i]];
                                //    ((DataSet)(this.DataBindings[0].DataSource)).Tables[0].AcceptChanges();
                                //}
                            }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 查询后自动设置相应数据值-用于主表自动赋值
        /// </summary>
        /// <param name="ctl">控件名</param>
        /// <param name="valuefield">返回结果中的字段名</param>
        public void AutoSetValue(Control ctl, string valuefield)
        {
            LAutoSetControl.Add(ctl);
            LAutoSetValueFields.Add(valuefield);
        }

        /// <summary>
        /// 查询后自动设置相应数据值-用于Grid中自动赋值
        /// </summary>
        /// <param name="gv">GridView控件</param>
        /// <param name="field">GridView中要赋值的字段</param>
        /// <param name="valuefield">返回结果中的字段名</param>
        public void AutoSetValue(ref DevExpress.XtraGrid.Views.Grid.GridView gv, string field, string valuefield)
        {
            gvTemp = gv;
            LAutoSetFields.Add(field);
            LAutoSetValueFields.Add(valuefield);
        }
        /// <summary>
        /// 查询后自动设置相应数据值-用于绑定的数据源是BindingSource
        /// </summary>
        /// <param name="field">需要设置的字段</param>
        /// <param name="valuefield">查询出来的数据源字段</param>
        public void AutoSetValue(string field, string valuefield)
        {
            LAutoSetFields.Add(field);
            LAutoSetValueFields.Add(valuefield);
        }

        private void SunriseLookUp_Load(object sender, EventArgs e)
        {
            txtValueText.Text = EditValue;
        }

        private void SunriseLookUp_SizeChanged(object sender, EventArgs e)
        {
            this.Height = txtDisplayText.Height;
        }

        public delegate bool SunriseLookUpEvent(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e);

        /// <summary>
        /// 单击LookUp查询前执行事件
        /// </summary>
        [Category("事件"), Description("单击LookUp查询前执行事件")]
        public event SunriseLookUpEvent LookUpBeforePost;

        /// <summary>
        /// 单击LookUp查询后执行事件
        /// </summary>
        [Category("事件"), Description("单击LookUp查询后执行事件")]
        public event SunriseLookUpEvent LookUpAfterPost;

        private void txtDisplayText_Click(object sender, EventArgs e)
        {
            if (txtDisplayText.Properties.Buttons[0].Enabled)
            {
                LookUpSelfClick(sender, null);
            }
        }
    }
}
