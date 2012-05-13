using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

using Sunrise.ERP.BasePublic;
using Sunrise.ERP.Controls;
using Sunrise.ERP.Security;
using Sunrise.ERP.Lang;

namespace Sunrise.ERP.BaseForm
{
    public partial class frmForm : DevExpress.XtraEditors.XtraForm
    {
        public frmForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <param name="formtext">窗体名称</param>
        public frmForm(int formid, string formtext)
        {
            InitializeComponent();
            FormID = formid;
            FormText = formtext;
            if (FormText != "")
            {
                this.Text = FormText;
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">窗体ID</param>
        public frmForm(int formid)
        {
            InitializeComponent();
            FormID = formid;
            if (FormText != "")
            {
                this.Text = FormText;
            }
        }
        /// <summary>
        /// 窗体ID
        /// </summary>
        private int _FormID = 0;

        /// <summary>
        /// 窗体ID
        /// </summary>
        protected int FormID
        {
            get
            {
                return _FormID;
            }
            set
            {
                _FormID = value;
            }
        }
        /// <summary>
        /// 窗体是否是第一次加载
        /// </summary>
        private bool _IsFirtLoad = false;
        /// <summary>
        /// 窗体是否是第一次加载
        /// </summary>
        protected bool IsFirstLoad
        {
            get
            {
                return _IsFirtLoad;
            }
            set
            {
                _IsFirtLoad = value;
            }
        }
        /// <summary>
        /// 数据操作状态
        /// </summary>
        private DataFlag _DataFlag = 0;
        /// <summary>
        /// 数据操作状态
        /// </summary>
        public DataFlag FormDataFlag
        {
            get
            {
                return _DataFlag;
            }
            set
            {
                _DataFlag = value;
            }
        }
        private string _formtext = "";
        /// <summary>
        /// 窗体Text
        /// </summary>
        protected string FormText
        {
            get
            {
                return _formtext;
            }
            set
            {
                _formtext = value;
            }
        }

        private void frmForm_Load(object sender, EventArgs e)
        {
            try
            {
                //添加系统日志
                if (FormID != 0)
                    SysPublic.AddIPLog(FormID, SecurityCenter.CurrentUserID, LangCenter.Instance.GetSystemMessage("LoginModule"));
            }
            catch { }
        }

        private void frmForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //添加系统日志
                if (FormID != 0)
                    SysPublic.AddIPLog(FormID, SecurityCenter.CurrentUserID, LangCenter.Instance.GetSystemMessage("LogoutModule"));
            }
            catch { }
        }

        public void GridCreateColumns(BTOperator bto, GridView gv)
        {
            SunriseLookUp.SunriseLookUpEvent slookHandler = new SunriseLookUp.SunriseLookUpEvent(lkp_LookUpAfterPostx);
            UIService.GridCreateColumns(this, gv, this.FormID, bto.TableName, bto.BindingSource, slookHandler);
            gv.GridControl.DataSource = bto.BindingSource;
        }

        public void GridCreateColumns(GridView gv, int formID, string tableName, object lpkBindSource)
        {
            SunriseLookUp.SunriseLookUpEvent slookHandler = new SunriseLookUp.SunriseLookUpEvent(lkp_LookUpAfterPostx);
            UIService.GridCreateColumns(this, gv, 511510, "sysAuditJob", lpkBindSource, slookHandler);
        }

        private bool lkp_LookUpAfterPostx(object sender, ButtonPressedEventArgs e)
        {
            OnKeyDown(new KeyEventArgs(Keys.Enter));
            return true;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if ((((DevExpress.XtraEditors.TextBoxMaskBox)(Sunrise.ERP.BasePublic.Base.GetFocusedControl()))).OwnerEdit.Tag == null || (((DevExpress.XtraEditors.TextBoxMaskBox)(Sunrise.ERP.BasePublic.Base.GetFocusedControl()))).OwnerEdit.Tag.ToString().ToLower() != "notab")
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
                base.OnKeyDown(e);
            }
            catch (Exception)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
                base.OnKeyDown(e);
            }
        }
    }
}