using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sunrise.ERP.BasePublic;
using Sunrise.ERP.BaseControl;
using Sunrise.ERP.Common;

using DevExpress.XtraEditors.Controls;
using Sunrise.ERP.Lang;

namespace Sunrise.ERP.BaseForm
{
    public partial class frmSearchForm : Sunrise.ERP.BaseForm.frmForm
    {
        private List<string> LItemName = new List<string>();
        private List<string> LItemFiled = new List<string>();
        private List<FiledType> LFieldType = new List<FiledType>();
        private List<string> LLookUpOrComboBoxSetting = new List<string>();
        /// <summary>
        /// 通用查询设置窗体
        /// </summary>
        public frmSearchForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchText.Text != "")
                {
                    sSearchSql = txtSearchText.Text;
                    //替换查询项目
                    for (int i = 0; i < LItemFiled.Count; i++)
                    {
                        sSearchSql = sSearchSql.Replace(LItemName[i], LItemFiled[i]);
                    }
                    //替换查询条件,倒序进行替换
                    for (int i = cbxSearchWhere.Properties.Items.Count - 1; i >= 0; i--)
                    {
                        sSearchSql = sSearchSql.Replace(cbxSearchWhere.Properties.Items[i].Description, cbxSearchWhere.Properties.Items[i].Value.ToString());
                    }
                    //替换关键字
                    sSearchSql = sSearchSql.Replace("并且", "AND");
                    sSearchSql = sSearchSql.Replace("或者", "OR");
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
            }
        }

        private void frmSearchForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchText.Text))
                btnOk.Enabled = false;
            for (int i = 0; i < LItemName.Count; i++)
            {
                cbxSearchItem.Properties.Items.Add(new ImageComboBoxItem(LItemName[i], LItemFiled[i]));
            }
            if (cbxSearchItem.Properties.Items.Count > 0)
                cbxSearchItem.SelectedIndex = 0;
            LoadLangSetting();
        }

        private void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchText.Text != "")
            {
                btnOk.Enabled = true;
                btnOk.Focus();
            }
            else
                btnOk.Enabled = false;
        }
        /// <summary>
        /// 创建查询值控件
        /// </summary>
        private void ShowSearchValueControl(Control ValueControl)
        {
            cbxSearchValue.Visible = false;
            txtSearchValue.Visible = false;
            detSearchValue.Visible = false;
            txtBtnSearchValue.Visible = false;
            lkpSearchValue.Visible = false;
            ValueControl.Visible = true;
        }
        /// <summary>
        /// 增加查询项目
        /// </summary>
        /// <param name="sItemName">查询项目名称</param>
        /// <param name="sItemFiled">查询项目字段</param>
        /// <param name="FiledType">查询项目类型</param>
        public void AddSearchItem(string sItemName, string sItemFiled, FiledType FiledType)
        {
            LItemName.Add(sItemName);
            LItemFiled.Add(sItemFiled);
            LFieldType.Add(FiledType);
            LLookUpOrComboBoxSetting.Add("NULL");
        }
        public void AddSearchItem(string sItemName, string sItemFiled, FiledType FiledType,string LookUpOrComboBoxSetting)
        {
            LItemName.Add(sItemName);
            LItemFiled.Add(sItemFiled);
            LFieldType.Add(FiledType);
            LLookUpOrComboBoxSetting.Add(LookUpOrComboBoxSetting);
        }
        public void AddSearchItem(string sItemName, string sItemFiled, FiledType FiledType, string sql, 
            string returnfield, string displayfield, string columnfield, string columntetx, string text)
        {
            LItemName.Add(sItemName);
            LItemFiled.Add(sItemFiled);
            LFieldType.Add(FiledType);
            string LookUpOrComboBoxSetting = sql + "|" + returnfield + "|" + displayfield + "|" + "|" + columnfield + "|" + columntetx + "|" + text;
            LLookUpOrComboBoxSetting.Add(LookUpOrComboBoxSetting);
        }
        public void AddSearchItem(string sItemName, string sItemFiled, FiledType FiledType, string ComboBoxValues,string ComboBoxTexts)
        {
            LItemName.Add(sItemName);
            LItemFiled.Add(sItemFiled);
            LFieldType.Add(FiledType);
            string LookUpOrComboBoxSetting = ComboBoxValues + "|" + ComboBoxTexts;
            LLookUpOrComboBoxSetting.Add(LookUpOrComboBoxSetting);
        }


        private void cbxSearchItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxSearchWhere.SelectedIndex < 0)
                {
                    cbxSearchWhere.SelectedIndex = 0;
                }
                FiledType filedType = LFieldType[LItemName.IndexOf(cbxSearchItem.SelectedItem.ToString())];
                switch (filedType)
                {
                    case FiledType.S:
                        {
                            ShowSearchValueControl(txtSearchValue);
                            SetSearchValueDefault();
                            break;
                        }
                    case FiledType.D:
                        {
                            ShowSearchValueControl(detSearchValue);
                            SetSearchValueDefault();
                            break;
                        }
                    case FiledType.C:
                        {
                            ShowSearchValueControl(cbxSearchValue);
                            SetSearchValueDefault();
                            InitComboBox(LItemName.IndexOf(cbxSearchItem.SelectedItem.ToString()));
                            break;
                        }
                    case FiledType.T:
                        {
                            ShowSearchValueControl(detSearchValue);
                            SetSearchValueDefault();
                            break;
                        }
                    case FiledType.N:
                        {
                            ShowSearchValueControl(txtSearchValue);
                            SetSearchValueDefault();
                            break;
                        }
                    case FiledType.L:
                        {
                            ShowSearchValueControl(lkpSearchValue);
                            SetSearchValueDefault();
                            InitLookUp(LItemName.IndexOf(cbxSearchItem.SelectedItem.ToString()));
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 清除查询值
        /// </summary>
        private void SetSearchValueDefault()
        {
            txtSearchValue.Text = "";
            cbxSearchValue.SelectedIndex = -1;
            detSearchValue.DateTime = DateTime.Now;
            lkpSearchValue.EditValue = string.Empty;
            txtBtnSearchValue.Text = "";

        }
        private void btnAnd_Click(object sender, EventArgs e)
        {
            string sValue = "";
            if (txtSearchValue.Visible)
            {
                sValue = txtSearchValue.Text;
            }
            else if (detSearchValue.Visible)
            {
                sValue = detSearchValue.DateTime.ToShortDateString();
            }
            else if (cbxSearchValue.Visible)
            {
                sValue = cbxSearchValue.EditValue.ToString();
            }
            else if (txtBtnSearchValue.Visible)
            {
                sValue = txtBtnSearchValue.Text;
            }
            else if (lkpSearchValue.Visible)
            {
                sValue = lkpSearchValue.EditValue;
            }
            AddSearchText(cbxSearchItem.SelectedItem.ToString(), cbxSearchWhere.SelectedItem.ToString(), sValue, "AND");
        }

        private void AddSearchText(string sItemName, string sWhere, string sValue, string LinkType)
        {
            switch (LinkType)
            {
                case "AND":
                    {
                        if (sWhere != LangCenter.Instance.GetFormLangInfo("frmSearchForm", "cbxSearchWhereText7") &&
                            sWhere != LangCenter.Instance.GetFormLangInfo("frmSearchForm", "cbxSearchWhereText8"))
                        {
                            if (txtSearchText.Text != "")
                            {
                                txtSearchText.Text += "\r\n  " + LangCenter.Instance.GetFormLangInfo("frmSearchForm", "WhereAnd")
                                                    + " (" + sItemName + " " + sWhere + (sWhere == LangCenter.Instance.GetFormLangInfo("frmSearchForm", "cbxSearchWhereText6") ? " '%" : " '")
                                                    + sValue + (sWhere == LangCenter.Instance.GetFormLangInfo("frmSearchForm", "cbxSearchWhereText6") ? "%' )" : "' )");
                            }
                            else
                            {
                                txtSearchText.Text += "(" + sItemName + " " + sWhere 
                                                    + (sWhere == LangCenter.Instance.GetFormLangInfo("frmSearchForm", "cbxSearchWhereText6") ? " '%" : " '")
                                                    + sValue + (sWhere == LangCenter.Instance.GetFormLangInfo("frmSearchForm", "cbxSearchWhereText6") ? "%' )" : "' )");
                            }
                        }
                        else
                        {
                            if (txtSearchText.Text != "")
                            {
                                txtSearchText.Text += "\r\n  " + LangCenter.Instance.GetFormLangInfo("frmSearchForm", "WhereAnd") 
                                                    + " (" + sItemName + " " + sWhere + " )";
                            }
                            else
                            {
                                txtSearchText.Text += "(" + sItemName + " " + sWhere + " )";
                            }
                            
                        }
                        break;
                    }
                case "OR":
                    {
                        if (sWhere != LangCenter.Instance.GetFormLangInfo("frmSearchForm", "cbxSearchWhereText7") &&
                            sWhere != LangCenter.Instance.GetFormLangInfo("frmSearchForm", "cbxSearchWhereText8"))
                        {
                            if (txtSearchText.Text != "")
                            {
                                txtSearchText.Text += "\r\n  "+ LangCenter.Instance.GetFormLangInfo("frmSearchForm", "WhereOr")
                                                    + " (" + sItemName + " " + sWhere + (sWhere == LangCenter.Instance.GetFormLangInfo("frmSearchForm", "cbxSearchWhereText6") ? " '%" : " '")
                                                    + sValue + (sWhere == LangCenter.Instance.GetFormLangInfo("frmSearchForm", "cbxSearchWhereText6") ? "%' )" : "' )");
                            }
                            else
                            {
                                txtSearchText.Text += "(" + sItemName + " " + sWhere
                                                    + (sWhere == LangCenter.Instance.GetFormLangInfo("frmSearchForm", "cbxSearchWhereText6") ? " '%" : " '")
                                                    + sValue + (sWhere == LangCenter.Instance.GetFormLangInfo("frmSearchForm", "cbxSearchWhereText6") ? "%' )" : "' )");
                            }
                        }
                        else
                        {
                            if (txtSearchText.Text != "")
                            {
                                txtSearchText.Text += "\r\n  " + LangCenter.Instance.GetFormLangInfo("frmSearchForm", "WhereOr") 
                                                    + " (" + sItemName + " " + sWhere + " )";
                            }
                            else
                            {
                                txtSearchText.Text += "(" + sItemName + " " + sWhere + " )";
                            }
                        }
                        break;
                    }
            }
        }

        private void btnOr_Click(object sender, EventArgs e)
        {
            string sValue = "";
            if (txtSearchValue.Visible)
            {
                sValue = txtSearchValue.Text;
            }
            else if (detSearchValue.Visible)
            {
                sValue = detSearchValue.DateTime.ToShortDateString();
            }
            else if (cbxSearchValue.Visible)
            {
                sValue = cbxSearchValue.EditValue.ToString();
            }
            else if (txtBtnSearchValue.Visible)
            {
                sValue = txtBtnSearchValue.Text;
            }
            else if (lkpSearchValue.Visible)
            {
                sValue = lkpSearchValue.EditValue;
            }
            AddSearchText(cbxSearchItem.SelectedItem.ToString(), cbxSearchWhere.SelectedItem.ToString(), sValue, "OR");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchText.Text = "";
        }

        private string sSearchSql = "";
        /// <summary>
        /// 查询条件SQL
        /// </summary>
        public string SearchSQL
        {
            get
            {
                return sSearchSql;
            }
        }

        private void InitLookUp(int index)
        {
            string LookupSetting = LLookUpOrComboBoxSetting[index];
            if (LookupSetting.Contains("|"))
            {
                string[] s = Public.GetSplitString(LookupSetting, "|");
                SystemPublic.InitLookUpBase(lkpSearchValue, s[0], s[1], s[2], s[3], s[4], s[5]);
            }
            else if (!string.IsNullOrEmpty(LookupSetting) && LookupSetting != "NULL")
                Base.InitLookup(lkpSearchValue, LookupSetting);
        }

        private void InitComboBox(int index)
        {
            string ComboBoxSetting = LLookUpOrComboBoxSetting[index];
            if (ComboBoxSetting.Contains("|"))
            {
                string[] s = Public.GetSplitString(ComboBoxSetting, "|");
                string[] value = Public.GetSplitString(s[0], ",");
                string[] text = Public.GetSplitString(s[1], ",");
                if (value.Length == text.Length)
                {
                    cbxSearchValue.Properties.Items.Clear();
                    for (int i = 0; i < value.Length; i++)
                    {
                        cbxSearchValue.Properties.Items.Add(new ImageComboBoxItem(text[i], value[i]));
                    }
                }
            }
            else if (!string.IsNullOrEmpty(ComboBoxSetting) && ComboBoxSetting != "NULL")
                Base.InitComboBox(cbxSearchValue, ComboBoxSetting);
        }

        /// <summary>
        /// 加载语言数据
        /// </summary>
        private void LoadLangSetting()
        {
            this.Text = LangCenter.Instance.GetFormLangInfo("frmSearchForm", this.Name);
            lblSearchItem.Text = LangCenter.Instance.GetFormLangInfo("frmSearchForm", lblSearchItem.Name);
            lblSearchText.Text = LangCenter.Instance.GetFormLangInfo("frmSearchForm", lblSearchText.Name);
            lblSearchWhere.Text = LangCenter.Instance.GetFormLangInfo("frmSearchForm", lblSearchWhere.Name);
            lblSearchValue.Text = LangCenter.Instance.GetFormLangInfo("frmSearchForm", lblSearchValue.Name);
            btnAnd.Text = LangCenter.Instance.GetFormLangInfo("frmSearchForm", btnAnd.Name);
            btnCancel.Text = LangCenter.Instance.GetFormLangInfo("frmSearchForm", btnCancel.Name);
            btnClear.Text = LangCenter.Instance.GetFormLangInfo("frmSearchForm", btnClear.Name);
            btnOk.Text = LangCenter.Instance.GetFormLangInfo("frmSearchForm", btnOk.Name);
            btnOr.Text = LangCenter.Instance.GetFormLangInfo("frmSearchForm", btnOr.Name);
            for (int i = 0; i < cbxSearchWhere.Properties.Items.Count; i++)
            {
                cbxSearchWhere.Properties.Items[i].Description = LangCenter.Instance.GetFormLangInfo("frmSearchForm", "cbxSearchWhereText" + i.ToString());
            }
        }
    }
}
