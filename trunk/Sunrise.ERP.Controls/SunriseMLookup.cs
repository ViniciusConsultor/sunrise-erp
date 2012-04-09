using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;

using Sunrise.ERP.BaseControl;
using Sunrise.ERP.DataAccess;

namespace Sunrise.ERP.Controls
{
    /// <summary>
    /// 可输入LookUp
    /// </summary>
    public partial class SunriseMLookup : SunriseLookUp
    {
        /// <summary>
        /// 可输入LookUp
        /// </summary>
        public SunriseMLookup()
        {
            InitializeComponent();
        }
        #region 公共属性
        string _datanofield;
        /// <summary>
        /// MLoopUp编号显示字段
        /// </summary>
        public string DataNoField
        {
            get { return _datanofield; }
            set { _datanofield = value; }
        }

        string _popupdisplayfields;
        /// <summary>
        /// Popup显示名称
        /// </summary>
        public string PopupDisplayFields
        {
            get { return _popupdisplayfields; }
            set { _popupdisplayfields = value; }
        }

        string _popupdatafields;
        /// <summary>
        /// Popup显示字段
        /// </summary>
        public string PopupDataFields
        {
            get { return _popupdatafields; }
            set { _popupdatafields = value; }
        }

        #endregion

        #region 私有属性
        List<string> _popupfields = new List<string>();
        /// <summary>
        /// Popup显示字段集合
        /// </summary>
        private List<string> PopupFields
        {
            get
            {
                if (_popupfields.Count > 0 && !string.IsNullOrEmpty(PopupDataFields))
                {
                    string[] ss = Public.GetSplitString(PopupDataFields, ",");
                    foreach (string s in ss)
                    {
                        _popupfields.Add(s);
                    }
                }
                return _popupfields;
            }
        }
        DataTable _dtPopupData;
        /// <summary>
        /// Popup显示数据表
        /// </summary>
        private DataTable PopupData
        {
            get
            {
                if (_dtPopupData == null)
                {
                    _dtPopupData = DbHelperSQL.QueryTable(SQL);
                }
                return _dtPopupData;
            }
        }
        
        #endregion


        #region 私有方法

        private string GetDataFilterString(string inputstring)
        {
            string result = string.Empty;
            for (int i=0;i<PopupFields.Count;i++)
            {
                if (i == 0)
                    result = PopupFields[i];
                else
                    result = string.Concat(result, " OR ", PopupFields[i], " LIKE '%{0}%'");
            }
            if (!string.IsNullOrEmpty(result))
                result = string.Format(result, inputstring);
            return result;
        }

        #endregion

        #region 公共方法
        #endregion


        #region 私有事件
        private void mlkpDataNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
                LookUpSelfClick(sender, e);
        }
        

        private void mlkpDataNo_Popup(object sender, EventArgs e)
        {

        }

        private void mlkpDataNo_TextChanged(object sender, EventArgs e)
        {
            mlkpPopupGird.DataSource = PopupData;
            PopupData.DefaultView.RowFilter = GetDataFilterString(mlkpDataNo.Text);
            mlkpDataNo.ShowPopup();
        }

        private void mlkpDataNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                mlkpPopuoGirdView.FocusedRowHandle += 1;
            }
            else if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                mlkpPopuoGirdView.FocusedRowHandle -= 1;
            }
            else if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                DataRow dr = mlkpPopuoGirdView.GetDataRow(mlkpPopuoGirdView.FocusedRowHandle);
                if (dr == null) return;
                EditValue = dr[DataField].ToString();
                mlkpDataNo.EditValue = dr[DataNoField];
                mlkpDataName.EditValue = dr[PopupDisplayFields];
                mlkpDataNo.ClosePopup();
            }
        }

        #endregion
        
    }
}
