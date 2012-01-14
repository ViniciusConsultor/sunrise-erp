using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.Module.SystemManage
{
    public partial class frmsysMenuPara : Sunrise.ERP.BaseForm.frmForm
    {
        public frmsysMenuPara()
        {
            InitializeComponent();
        }

        private Hashtable _ht=new Hashtable();
        /// <summary>
        /// 菜单参数列表
        /// </summary>
        public Hashtable MenuPara
        {
            get
            {
                return _ht;
            }
            set
            {
                _ht = value;
            }
        }

        private bool _flag;
        /// <summary>
        /// 窗体标示，Ture-添加参数，False-修改参数
        /// </summary>
        public bool Flag
        {
            get
            {
                return _flag;
            }
            set
            {
                _flag = value;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtParaName.Text == "")
            {
                Sunrise.ERP.BaseControl.Public.SystemInfo("参数名不能够为空！");
                return;
            }
            else if (txtParaValue.Text == "")
            {
                Sunrise.ERP.BaseControl.Public.SystemInfo("参数值不能够为空！");
                return;
            }
            MenuPara.Clear();
            MenuPara.Add("ParamName", txtParaName.Text);
            MenuPara.Add("ParamValue", txtParaValue.Text);
            DialogResult = DialogResult.OK;
        }

        private void frmsysMenuPara_Load(object sender, EventArgs e)
        {
            if (Flag)
            {
                Text = "添加菜单参数";
            }
            else
            {
                Text = "修改菜单参数";
                if (MenuPara.Count == 2)
                {
                    txtParaName.Text = MenuPara["ParamName"].ToString();
                    txtParaValue.Text = MenuPara["ParamValue"].ToString();
                }
                else
                {
                    Sunrise.ERP.BaseControl.Public.SystemInfo("获取参数失败！", true);
                }
            }
        }
    }
}
