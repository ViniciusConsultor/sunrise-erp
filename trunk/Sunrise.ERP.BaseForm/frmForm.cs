using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sunrise.ERP.BasePublic;

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
        public frmForm(int formid,string formtext)
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
        protected DataFlag FormDataFlag
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

    }
}