using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.BaseForm
{
    public partial class frmSearchForm : Sunrise.ERP.BaseForm.frmForm
    {
        private List<string> LItemName = new List<string>();
        private List<string> LItemFiled = new List<string>();
        private List<Sunrise.ERP.BasePublic.FiledType> LFieldType = new List<Sunrise.ERP.BasePublic.FiledType>();
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
                    //替换查询条件
                    for (int i = 0; i < cbxSearchWhere.Properties.Items.Count; i++)
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
            if (txtSearchText.Text == "")
            {
                btnOk.Enabled = false;
            }
            for (int i = 0; i < LItemName.Count; i++)
            {
                cbxSearchItem.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(LItemName[i], LItemFiled[i]));
            }
            if (cbxSearchItem.Properties.Items.Count > 0)
            {
                cbxSearchItem.SelectedIndex = 0;
            }

        }

        private void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchText.Text != "")
            {
                btnOk.Enabled = true;
                btnOk.Focus();
            }
            else
            {
                btnOk.Enabled = false;
            }
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
            ValueControl.Visible = true;
        }
        /// <summary>
        /// 增加查询项目，-目前支持S，D，T，N，文本查询，暂不支持LookUp查询
        /// </summary>
        /// <param name="sItemName">查询项目名称</param>
        /// <param name="sItemFiled">查询项目字段</param>
        /// <param name="FiledType">查询项目类型</param>
        public void AddSearchItem(string sItemName, string sItemFiled, Sunrise.ERP.BasePublic.FiledType FiledType)
        {
            LItemName.Add(sItemName);
            LItemFiled.Add(sItemFiled);
            LFieldType.Add(FiledType);
        }

        private void cbxSearchItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxSearchWhere.SelectedIndex < 0)
                {
                    cbxSearchWhere.SelectedIndex = 0;
                }
                string sFiledType = "";
                sFiledType = LFieldType[LItemName.IndexOf(cbxSearchItem.SelectedItem.ToString())].ToString();
                switch (sFiledType)
                {
                    case "S":
                        {
                            ShowSearchValueControl(txtSearchValue);
                            SetSearchValueDefault();
                            cbxSearchWhere.SelectedIndex = 5;
                            break;
                        }
                    case "D":
                        {
                            ShowSearchValueControl(detSearchValue);
                            SetSearchValueDefault();
                            if (cbxSearchWhere.SelectedIndex == 5)
                            {
                                cbxSearchWhere.SelectedIndex = 0;
                            }
                            break;
                        }
                    case "C":
                        {
                            ShowSearchValueControl(txtBtnSearchValue);
                            SetSearchValueDefault();
                            if (cbxSearchWhere.SelectedIndex == 5)
                            {
                                cbxSearchWhere.SelectedIndex = 0;
                            }
                            break;
                        }
                    case "T":
                        {
                            ShowSearchValueControl(detSearchValue);
                            SetSearchValueDefault();
                            if (cbxSearchWhere.SelectedIndex == 5)
                            {
                                cbxSearchWhere.SelectedIndex = 0;
                            }
                            break;
                        }
                    case "N":
                        {
                            ShowSearchValueControl(txtSearchValue);
                            SetSearchValueDefault();
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
                sValue = cbxSearchValue.SelectedItem.ToString();
            }
            else if (txtBtnSearchValue.Visible)
            {
                sValue = txtBtnSearchValue.Text;
            }
            AddSearchText(cbxSearchItem.SelectedItem.ToString(), cbxSearchWhere.SelectedItem.ToString(), sValue, "AND");
        }

        private void AddSearchText(string sItemName, string sWhere, string sValue, string LinkType)
        {
            switch (LinkType)
            {
                case "AND":
                    {
                        if (sWhere != "为空" && sWhere != "不为空")
                        {
                            if (txtSearchText.Text != "")
                            {
                                txtSearchText.Text += "\r\n  并且 (" + sItemName + " " + sWhere + (sWhere == "类似于" ? " '%" : " '") + sValue + (sWhere == "类似于" ? "%' )" : "' )");
                            }
                            else
                            {
                                txtSearchText.Text += "(" + sItemName + " " + sWhere + (sWhere == "类似于" ? " '%" : " '") + sValue + (sWhere == "类似于" ? "%' )" : "' )");
                            }
                        }
                        else
                        {
                            if (txtSearchText.Text != "")
                            {
                                txtSearchText.Text += "\r\n  并且 (" + sItemName + " " + sWhere + " )";
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
                        if (sWhere != "为空" && sWhere != "不为空")
                        {
                            if (txtSearchText.Text != "")
                            {
                                txtSearchText.Text += "\r\n  或者 (" + sItemName + " " + sWhere + (sWhere == "类似于" ? " '%" : " '") + sValue + (sWhere == "类似于" ? "%' )" : "' )");
                            }
                            else
                            {
                                txtSearchText.Text += "(" + sItemName + " " + sWhere + (sWhere == "类似于" ? " '%" : " '") + sValue + (sWhere == "类似于" ? "%' )" : "' )");
                            }
                        }
                        else
                        {
                            if (txtSearchText.Text != "")
                            {
                                txtSearchText.Text += "\r\n  或者 (" + sItemName + " " + sWhere + " )";
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
                sValue = cbxSearchValue.SelectedItem.ToString();
            }
            else if (txtBtnSearchValue.Visible)
            {
                sValue = txtBtnSearchValue.Text;
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
    }
}
