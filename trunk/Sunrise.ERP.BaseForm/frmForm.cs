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
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="formtext">��������</param>
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
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
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
        /// ����ID
        /// </summary>
        private int _FormID = 0;

        /// <summary>
        /// ����ID
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
        /// �����Ƿ��ǵ�һ�μ���
        /// </summary>
        private bool _IsFirtLoad = false;
        /// <summary>
        /// �����Ƿ��ǵ�һ�μ���
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
        /// ���ݲ���״̬
        /// </summary>
        private DataFlag _DataFlag = 0;
        /// <summary>
        /// ���ݲ���״̬
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
        /// ����Text
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
                //���ϵͳ��־
                if (FormID != 0)
                    SysPublic.AddIPLog(FormID, SecurityCenter.CurrentUserID, LangCenter.Instance.GetSystemMessage("LoginModule"));
            }
            catch { }
        }

        private void frmForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //���ϵͳ��־
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