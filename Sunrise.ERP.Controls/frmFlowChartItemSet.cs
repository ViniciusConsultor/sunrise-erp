using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Sunrise.ERP.Controls
{
    public partial class frmFlowChartItemSet : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Item设置
        /// </summary>
        /// <param name="name">模块名称</param>
        /// <param name="shape">模块形状</param>
        /// <param name="formmodel">模块连接</param>
        /// <param name="forecolor">字体颜色</param>
        /// <param name="backcolor">背景颜色</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="bordercolor">边框颜色</param>
        /// <param name="font">字体</param>
        /// <param name="tooltip">提示信息</param>
        public frmFlowChartItemSet(string name, FlowChartItemStyleShape shape, string formmodel,
            Color forecolor, Color backcolor, int width, int height, Color bordercolor, Font font, string tooltip, Image backimg)
        {
            InitializeComponent();
            //移除连接线设置
            xtraTabControl1.TabPages.Remove(tp2);
            //设置窗体大小
            //xtraTabControl1.Width = 226;
            //xtraTabControl1.Height = 424;
            this.Width = 232;
            this.Height = 487;
            txtName.Text = name;
            rgpShape.SelectedIndex = (int)shape;
            txtFormID.Text = formmodel;
            txtTip.Text = tooltip;
            fntName.EditValue = font.FontFamily.Name;
            txtFontSize.Text = font.Size.ToString();
            cbxFontStyle.EditValue = font.Style.GetHashCode();
            txtWidth.Text = width.ToString();
            txtHeight.Text = height.ToString();
            colorBackColor.Color = backcolor;
            colorBorderColor.Color = bordercolor;
            colorFontColor.Color = forecolor;
            picBackImage.Image = backimg;
        }
        /// <summary>
        /// Line设置
        /// </summary>
        /// <param name="linecolor">Line颜色</param>
        /// <param name="linewidth">Line粗细</param>
        /// <param name="capwidth">箭头宽度</param>
        /// <param name="capheight">箭头高度</param>
        public frmFlowChartItemSet(Color linecolor, int linewidth, float capwidth, float capheight)
        {
            InitializeComponent();
            //移除节点设置
            xtraTabControl1.TabPages.Remove(tp1);
            //设置窗体大小
            this.Width = 232;
            this.Height = 202;
            colorLineColor.Color = linecolor;
            txtLineWidth.Text = linewidth.ToString();
            txtArrowCapWidth.Text = capwidth.ToString();
            txtArrowCapHeight.Text = capheight.ToString();
        }

        public string ItemName
        {
            get
            {
                return txtName.Text;
            }
        }
        public string ItemFormModel
        {
            get
            {
                return txtFormID.Text;
            }
        }
        public FlowChartItemStyleShape ItemShape
        {
            get
            {
                return (FlowChartItemStyleShape)rgpShape.SelectedIndex;
            }
        }


        public Color ItemForeColor
        {
            get
            {
                return colorFontColor.Color;
            }
        }


        public Color ItemBackColor
        {
            get
            {
                return colorBackColor.Color;
            }
        }


        public int ItemWidth
        {
            get
            {
                return Convert.ToInt32(txtWidth.Text);
            }
        }


        public int ItemHeight
        {
            get
            {
                return Convert.ToInt32(txtHeight.Text);
            }
        }


        public Color ItemBorderColor
        {
            get
            {
                return colorBorderColor.Color;
            }
        }


        public Font ItemFont
        {
            get
            {
                return new Font(fntName.EditValue.ToString(), float.Parse(String.IsNullOrEmpty(txtFontSize.Text) ? "9" : txtFontSize.Text), (FontStyle)cbxFontStyle.EditValue);
            }
        }
        public string ItemToolTip
        {
            get
            {
                return txtTip.Text;
            }
        }
        public Image ItemBackImage
        {
            get
            {
                return picBackImage.Image;
            }
        }


        public Color LineColor
        {
            get
            {
                return colorLineColor.Color;
            }
        }


        public int LineWidth
        {
            get
            {
                return Convert.ToInt32(txtLineWidth.Text);
            }
        }


        public float LineCapWidth
        {
            get
            {
                return float.Parse(txtArrowCapWidth.Text == "" ? "10" : txtArrowCapWidth.Text);
            }
        }


        public float LineCapHeight
        {
            get
            {
                return float.Parse(txtArrowCapHeight.Text == "" ? "10" : txtArrowCapHeight.Text);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}