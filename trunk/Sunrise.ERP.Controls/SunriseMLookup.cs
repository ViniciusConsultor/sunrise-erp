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
using Sunrise.ERP.Lang;

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

        private bool _ispopupshow = false;
        public bool IsPopuoShow
        {
            get { return _ispopupshow; }
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
                if (_popupfields.Count == 0 && !string.IsNullOrEmpty(PopupDataFields))
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
                if (_dtPopupData == null && !string.IsNullOrEmpty(SQL))
                {
                    try
                    {
                        _dtPopupData = DbHelperSQL.QueryTable(SQL);
                    }
                    catch { return null; }
                }
                return _dtPopupData;
            }
        }

        private bool _isfromlkpclick = false;
        private bool IsFromLkpClick
        {
            get { return _isfromlkpclick; }
            
        }

        #endregion


        #region 私有方法

        private string GetDataFilterString(string inputstring)
        {
            string result = string.Empty;
            for (int i=0;i<PopupFields.Count;i++)
            {
                if (i == 0)
                    result = string.Concat(PopupFields[i], " LIKE '%{0}%'");
                else
                    result = string.Concat(result, " OR ", PopupFields[i], " LIKE '%{0}%'");
            }
            if (!string.IsNullOrEmpty(result))
                result = string.Format(result, inputstring);
            return result;
        }

        #endregion

        #region 公共方法

        public override void LookUpSelfClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            base.LookUpSelfClick(sender, e);
            if(ReturnData.Rows.Count>0)
            {
                _isfromlkpclick = true;
                mlkpDataNo.EditValue = ReturnData.Rows[0][DataNoField];
                mlkpDataName.EditValue = ReturnData.Rows[0][DisplayField];
                EditValue = ReturnData.Rows[0][DataField].ToString();
            }
            if (string.IsNullOrEmpty(EditValue))
            {
                mlkpDataNo.EditValue = string.Empty;
                mlkpDataName.Text = string.Empty;
            }
        }

        #endregion


        #region 私有事件
        private void mlkpDataNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                _isfromlkpclick = true;
                LookUpSelfClick(sender, e);
            }
        }
        

        private void mlkpDataNo_Popup(object sender, EventArgs e)
        {
            mlkpDataNo.Focus();
            _ispopupshow = true;
        }

        private void mlkpDataNo_TextChanged(object sender, EventArgs e)
        {
            if (PopupData == null)
            {
                mlkpDataNo.EditValue = null;
                return;
            }
            EditValue = string.Empty;
            mlkpDataName.Text = string.Empty;
            PopupData.DefaultView.RowFilter = string.Empty;
            if (!IsFromLkpClick)
            {
                PopupData.DefaultView.RowFilter = GetDataFilterString(mlkpDataNo.Text);
                mlkpDataNo.ShowPopup();
            }
            else
                _isfromlkpclick = false;
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
                if (IsPopuoShow)
                {
                    e.Handled = true;
                    GetData();               
                }
            }
        }

        private void SunriseMLookup_Load(object sender, EventArgs e)
        {
            CreateGridColumns();
        }

        private void GetData()
        {
            DataRow dr = mlkpPopuoGirdView.GetDataRow(mlkpPopuoGirdView.FocusedRowHandle);
            if (dr != null)
            {
                mlkpDataNo.ClosePopup();
                //特殊设置，在选择完成后，不再对数据进行过滤
                _isfromlkpclick = true;
                mlkpDataNo.EditValue = dr[DataNoField];
                EditValue = dr[DataField].ToString();
                mlkpDataName.EditValue = dr[DisplayField];
            }
            else
            {
                mlkpDataNo.EditValue = string.Empty;
                PopupData.DefaultView.RowFilter = "1=2";
            }
        }

        private void CreateGridColumns()
        {
            if (PopupData == null)
            {
                mlkpDataNo.EditValue = null;
                return;
            }
            if (!string.IsNullOrEmpty(SQL) && !string.IsNullOrEmpty(PopupDataFields) && !string.IsNullOrEmpty(PopupDisplayFields))
            {
                
                List<string> DisplayFields = new List<string>();
                List<string> DataFields = new List<string>();
                foreach (string s in Public.GetSplitString(PopupDisplayFields, ","))
                {
                    DisplayFields.Add(s);
                }
                foreach (string s in Public.GetSplitString(PopupDataFields, ","))
                {
                    DataFields.Add(s);
                }
                //设置GRID列显示
                int iCount;
                if (DisplayFields.Count > DataFields.Count)
                {
                    iCount = DataFields.Count;
                }
                else
                {
                    iCount = DisplayFields.Count;
                }
                for (int i = 0; i < iCount; i++)
                {
                    DevExpress.XtraGrid.Columns.GridColumn clm = new DevExpress.XtraGrid.Columns.GridColumn();
                    clm.Name = "clm" + DataFields[i];
                    clm.Caption = DisplayFields[i];
                    clm.FieldName = DataFields[i];
                    clm.Width = 100;
                    clm.Visible = true;
                    clm.VisibleIndex = i;
                    mlkpPopuoGirdView.Columns.Add(clm);
                }
                
                mlkpPopupGird.DataSource = PopupData;
            }
        }

        private void mlkpPopuoGirdView_DoubleClick(object sender, EventArgs e)
        {
            GetData();
        }

        private void mlkpDataNo_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            _ispopupshow = false;
        }

        private void mlkpPopuoGirdView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                GetData();
            }
        }

        private void mlkpDataNo_Properties_Leave(object sender, EventArgs e)
        {
            GetData();
        }
        #endregion       

       

        
        
    }
}
