using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

using Sunrise.ERP.Lang;


namespace Sunrise.ERP.Controls
{
    public partial class SunriseGridControl : DevExpress.XtraGrid.GridControl
    {
        public SunriseGridControl()
        {
            InitializeComponent();
            this.Load += new EventHandler(BWSGridControl_Load);
        }

        void BWSGridControl_Load(object sender, EventArgs e)
        {
            ((DevExpress.XtraGrid.Views.Grid.GridView)this.MainView).ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(BWSGridControl_ShowGridMenu);
            //设置GridView分组脚注显示模式
            ((DevExpress.XtraGrid.Views.Grid.GridView)this.MainView).GroupFooterShowMode = GroupFooterShowMode.VisibleIfExpanded;
            ((DevExpress.XtraGrid.Views.Grid.GridView)this.MainView).OptionsView.ShowGroupPanel = false;
        }

        void BWSGridControl_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;
                if (menu.Column != null)
                {
                    string sMenuCaption1 = LangCenter.Instance.GetControlLangInfo("SunriseGridControl", "ShowFooter");
                    if (((GridView)this.MainView).OptionsView.ShowFooter)
                    {
                        sMenuCaption1 = LangCenter.Instance.GetControlLangInfo("SunriseGridControl", "HideFooter");
                    }
                    string sMenuCaption2 = LangCenter.Instance.GetControlLangInfo("SunriseGridControl", "ShowGroupFooter");
                    if (((GridView)this.MainView).GroupFooterShowMode == DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleIfExpanded)
                    {
                        sMenuCaption2 = LangCenter.Instance.GetControlLangInfo("SunriseGridControl", "HideGroupFooter");
                    }
                    DXMenuItem dx5 = new DXMenuItem(sMenuCaption1, ShowFooter);
                    dx5.BeginGroup = true;
                    menu.Items.Add(dx5);
                    DXMenuItem dx6 = new DXMenuItem(sMenuCaption2, ShowGroupFooter);
                    menu.Items.Add(dx6);
                    DXMenuItem dx1 = new DXMenuItem(LangCenter.Instance.GetControlLangInfo("SunriseGridControl", "SaveToExcel"), SaveAsExcel, Sunrise.ERP.Controls.Properties.Resources.excel.ToBitmap());
                    dx1.BeginGroup = true;
                    menu.Items.Add(dx1);
                    DXMenuItem dx2 = new DXMenuItem(LangCenter.Instance.GetControlLangInfo("SunriseGridControl", "SaveToWord"), SaveAsWord, Sunrise.ERP.Controls.Properties.Resources.word.ToBitmap());
                    menu.Items.Add(dx2);
                    DXMenuItem dx3 = new DXMenuItem(LangCenter.Instance.GetControlLangInfo("SunriseGridControl", "SaveToHtml"), SaveAsHtml);
                    menu.Items.Add(dx3);
                    DXMenuItem dx4 = new DXMenuItem(LangCenter.Instance.GetControlLangInfo("SunriseGridControl", "SaveToPdf"), SaveAsPdf, Sunrise.ERP.Controls.Properties.Resources.pdf.ToBitmap());
                    menu.Items.Add(dx4);
                }
            }
        }
        /// <summary>
        /// 保存为Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsExcel(object sender, EventArgs e)
        {
            if (this.MainView != null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = LangCenter.Instance.GetControlLangInfo("SunriseGridControl", "SaveToExcelFilter");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ((GridView)this.MainView).ExportToXls(dialog.FileName);
                }
            }
        }
        /// <summary>
        /// 保存为Word
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsWord(object sender, EventArgs e)
        {
            if (this.MainView != null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = LangCenter.Instance.GetControlLangInfo("SunriseGridControl", "SaveToWordFilter");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ((GridView)this.MainView).ExportToRtf(dialog.FileName);
                }
            }
        }
        /// <summary>
        /// 保存为Html
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsHtml(object sender, EventArgs e)
        {
            if (this.MainView != null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = LangCenter.Instance.GetControlLangInfo("SunriseGridControl", "SaveToHtmlFilter");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ((GridView)this.MainView).ExportToHtml(dialog.FileName);
                }
            }
        }
        /// <summary>
        /// 保存为Pdf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsPdf(object sender, EventArgs e)
        {
            if (this.MainView != null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = LangCenter.Instance.GetControlLangInfo("SunriseGridControl", "SaveToPdfFilter");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ((GridView)this.MainView).ExportToPdf(dialog.FileName);
                }
            }
        }

        /// <summary>
        /// 点击显示脚注事件
        /// </summary>
        /// <param name="serner"></param>
        /// <param name="e"></param>
        private void ShowFooter(object serner, EventArgs e)
        {
            if (((GridView)this.MainView).OptionsView.ShowFooter)
            {
                ((GridView)this.MainView).OptionsView.ShowFooter = false;
            }
            else
            {
                ((GridView)this.MainView).OptionsView.ShowFooter = true;
            }
        }
        /// <summary>
        /// 点击显示分组脚注事件
        /// </summary>
        /// <param name="serner"></param>
        /// <param name="e"></param>
        private void ShowGroupFooter(object serner, EventArgs e)
        {
            if (((GridView)this.MainView).GroupFooterShowMode == DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleIfExpanded)
            {
                ((GridView)this.MainView).GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            }
            else
            {
                ((GridView)this.MainView).GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleIfExpanded;
            }
        }


    }
}
