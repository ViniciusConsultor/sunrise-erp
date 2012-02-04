using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Sunrise.ERP.Lang;
using Sunrise.ERP.BaseControl;
using Sunrise.ERP.Security;

namespace Sunrise.ERP.BaseForm
{
    /// <summary>
    /// 基础类父窗体
    /// </summary>
    public partial class frmBaseForm : frmForm
    {
        /// <summary>
        /// 不为空字段列表
        /// </summary>
        protected List<string> NotNullFields = new List<string>();

        /// <summary>
        /// 不需要复制字段列表
        /// </summary>
        protected List<string> NotCopyFields = new List<string>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmBaseForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmBaseForm(int formid, string formtext)
            : base(formid, formtext)
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmBaseForm(int formid)
            : base(formid)
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化基础
        /// </summary>
        public virtual void initBase()
        {
            //DoView();
            //initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.None);
            DoBaseView();
            //下面这句代码在发布的时候需要取消注释
            //LoadLangSetting();
        }

        #region 基本按钮状态控制

        /// <summary>
        /// 设置控制按钮初始状态
        /// </summary>
        /// <param name="Sunrise.ERP.BasePublic.OperateFlag">操作状态</param>
        public virtual void initButtonsState(ERP.BasePublic.OperateFlag operateflag)
        {
            switch (operateflag)
            {
                case Sunrise.ERP.BasePublic.OperateFlag.View:
                    {
                        btnView.Enabled = true;
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = true;
                        btnPrint.Enabled = true;
                        btnClose.Enabled = true;
                        btnCopy.Enabled = true;
                        btnSettings.Enabled = true;
                        break;
                    }
                case Sunrise.ERP.BasePublic.OperateFlag.Insert:
                    {
                        btnView.Enabled = false;
                        btnAdd.Enabled = false;
                        btnEdit.Enabled = false;
                        btnCancel.Enabled = true;
                        btnSave.Enabled = true;
                        btnDelete.Enabled = false;
                        btnPrint.Enabled = false;
                        btnClose.Enabled = true;
                        btnCopy.Enabled = false;
                        btnSettings.Enabled = false;
                        break;
                    }
                case Sunrise.ERP.BasePublic.OperateFlag.Edit:
                    {
                        btnView.Enabled = false;
                        btnAdd.Enabled = false;
                        btnEdit.Enabled = false;
                        btnCancel.Enabled = true;
                        btnSave.Enabled = true;
                        btnDelete.Enabled = false;
                        btnPrint.Enabled = false;
                        btnClose.Enabled = true;
                        btnCopy.Enabled = false;
                        btnSettings.Enabled = false;
                        break;
                    }
                case Sunrise.ERP.BasePublic.OperateFlag.Cancel:
                    {
                        btnView.Enabled = true;
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = true;
                        btnPrint.Enabled = true;
                        btnClose.Enabled = true;
                        btnCopy.Enabled = true;
                        btnSettings.Enabled = true;
                        break;
                    }
                case Sunrise.ERP.BasePublic.OperateFlag.Save:
                    {
                        btnView.Enabled = true;
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = true;
                        btnPrint.Enabled = true;
                        btnClose.Enabled = true;
                        btnCopy.Enabled = true;
                        btnSettings.Enabled = true;
                        break;
                    }
                case Sunrise.ERP.BasePublic.OperateFlag.Copy:
                    {
                        btnView.Enabled = false;
                        btnAdd.Enabled = false;
                        btnEdit.Enabled = false;
                        btnCancel.Enabled = true;
                        btnSave.Enabled = true;
                        btnDelete.Enabled = false;
                        btnPrint.Enabled = false;
                        btnClose.Enabled = true;
                        btnCopy.Enabled = false;
                        btnSettings.Enabled = false;
                        break;
                    }
                case Sunrise.ERP.BasePublic.OperateFlag.Delete:
                    {
                        btnView.Enabled = true;
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = true;
                        btnPrint.Enabled = true;
                        btnClose.Enabled = true;
                        btnCopy.Enabled = true;
                        btnSettings.Enabled = true;
                        break;
                    }
                case Sunrise.ERP.BasePublic.OperateFlag.None:
                    {
                        btnView.Enabled = true;
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = false;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        btnPrint.Enabled = false;
                        btnClose.Enabled = true;
                        btnCopy.Enabled = false;
                        btnSettings.Enabled = true;
                        break;
                    }
                default:
                    {
                        btnView.Enabled = true;
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = true;
                        btnPrint.Enabled = true;
                        btnClose.Enabled = true;
                        btnCopy.Enabled = true;
                        btnSettings.Enabled = true;
                        break;
                    }
            }
        }
        /// <summary>
        /// 新增之前执行的方法
        /// </summary>
        public virtual bool DoAppend() { return true; }

        /// <summary>
        /// 新增
        /// </summary>
        public virtual void DoAdd()
        {
            initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.Insert);
        }

        /// <summary>
        /// 查询
        /// </summary>
        public virtual void DoView()
        {
            initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.View);
        }

        /// <summary>
        /// 查询
        /// </summary>
        public virtual void DoBaseView()
        {
            initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.View);
        }

        /// <summary>
        /// 编辑之前执行的方法
        /// </summary>
        /// <returns></returns>
        public virtual bool DoBeforeEdit() { return true; }
        /// <summary>
        /// 编辑
        /// </summary>
        public virtual void DoEdit()
        {
            initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.Edit);
        }

        /// <summary>
        /// 删除之前执行的方法
        /// </summary>
        public virtual bool DoBeforeDelete() { return true; }

        /// <summary>
        /// 删除
        /// </summary>
        public virtual bool DoDelete()
        {
            initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.Delete);
            return true;
        }

        /// <summary>
        /// 删除之后执行的方法
        /// </summary>
        public virtual void DoAfterDelete() { }

        /// <summary>
        /// 复制
        /// </summary>
        public virtual void DoCopy()
        {
            initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.Copy);
        }

        /// <summary>
        /// 取消之前执行的方法
        /// </summary>
        /// <returns></returns>
        public virtual bool DoBeforeCancel() { return true; }

        /// <summary>
        /// 取消
        /// </summary>
        public virtual void DoCancel()
        {
            initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.Cancel);
        }

        /// <summary>
        /// 保存之前执行的方法
        /// </summary>
        public virtual bool DoBeforeSave() { return true; }

        /// <summary>
        /// 保存
        /// </summary>
        public virtual bool DoSave()
        {
            return true;
        }

        /// <summary>
        /// 打印
        /// </summary>
        public virtual void DoPrint() { }
        /// <summary>
        /// 保存之后执行的方法
        /// </summary>
        public virtual bool DoAfterSave()
        {
            initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.Save);
            return true;
        }

        /// <summary>
        /// 窗体关闭之前执行的方法
        /// </summary>
        public virtual bool DoBeforeClose() { return true; }

        /// <summary>
        /// 窗体关闭
        /// </summary>
        public virtual void DoClose()
        {
            this.Close();
        }

        #endregion

        public virtual void frmBaseForm_Load(object sender, EventArgs e)
        {
            initBase();
            IsFirstLoad = true;
            this.txtDataFlag.TextChanged += new EventHandler(DataStateChange);
        }

        /// <summary>
        /// 数据状态改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void DataStateChange(object sender, EventArgs e) { }

        /// <summary>
        /// 设置界面上不为空的字段列表
        /// </summary>
        /// <param name="notNullFields">不为空的字符串数组(控件名称)</param>
        protected void AddNotNullFields(string[] notNullFields)
        {
            foreach (string s in notNullFields)
            {
                if (s.Length > 0)
                {
                    NotNullFields.Add(s);
                }
            }
        }
        /// <summary>
        /// 设置界面上不为空的字段列表
        /// </summary>
        /// <param name="notNullField">不为空的字符串(控件名称)</param>
        protected void AddNotNullFields(string notNullField)
        {
            NotNullFields.Add(notNullField);
        }

        /// <summary>
        /// 设置界面上不需要复制字段列表
        /// </summary>
        /// <param name="notCopyFields">不需要复制的字符串数组</param>
        protected void AddNotCopyFields(string[] notCopyFields)
        {
            foreach (string s in notCopyFields)
            {
                if (s.Length > 0)
                {
                    NotCopyFields.Add(s);
                }
            }
        }

        /// <summary>
        /// 设置界面上不需要复制字段列表
        /// </summary>
        /// <param name="notCopyField">不需要复制的字符串</param>
        protected void AddNotCopyFields(string notCopyField)
        {
            NotCopyFields.Add(notCopyField);
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            FormDataFlag = Sunrise.ERP.BasePublic.DataFlag.dsBrowse;
            base.OnFormClosing(e);
        }

        public virtual void btnView_Click(object sender, EventArgs e)
        {
            DoView();
            FormDataFlag = Sunrise.ERP.BasePublic.DataFlag.dsBrowse;
        }

        public virtual void btnAdd_Click(object sender, EventArgs e)
        {
            if (DoAppend())
            {
                DoAdd();
                FormDataFlag = Sunrise.ERP.BasePublic.DataFlag.dsInsert;
                txtDataFlag.Text = FormDataFlag.ToString();
            }
        }

        public virtual void btnEdit_Click(object sender, EventArgs e)
        {
            if (DoBeforeEdit())
            {
                DoEdit();
                FormDataFlag = Sunrise.ERP.BasePublic.DataFlag.dsEdit;
                txtDataFlag.Text = FormDataFlag.ToString();
            }
        }

        public virtual void btnDelete_Click(object sender, EventArgs e)
        {
            if (DoBeforeDelete())
            {
                if (DoDelete())
                {
                    DoAfterDelete();
                    FormDataFlag = Sunrise.ERP.BasePublic.DataFlag.dsBrowse;
                }
            }
        }

        public virtual void btnCopy_Click(object sender, EventArgs e)
        {
            DoCopy();
            FormDataFlag = Sunrise.ERP.BasePublic.DataFlag.dsInsert;
            txtDataFlag.Text = FormDataFlag.ToString();
        }

        public virtual void btnCancel_Click(object sender, EventArgs e)
        {
            if (DoBeforeCancel())
            {
                DoCancel();
                FormDataFlag = Sunrise.ERP.BasePublic.DataFlag.dsBrowse;
                txtDataFlag.Text = FormDataFlag.ToString();
            }
        }

        public virtual void btnSave_Click(object sender, EventArgs e)
        {

            if (DoBeforeSave())
            {
                if (DoSave())
                {
                    if (DoAfterSave())
                    {
                        FormDataFlag = Sunrise.ERP.BasePublic.DataFlag.dsBrowse;
                        txtDataFlag.Text = FormDataFlag.ToString();
                        if (ShowSaveInfo)
                            Public.SystemInfo(LangCenter.Instance.GetSystemMessage("SaveSuccess"));
                    }
                    else
                    {
                        if (ShowSaveInfo)
                            Public.SystemInfo(LangCenter.Instance.GetSystemMessage("SaveFailed"));
                        return;
                    }
                }
                else
                {
                    if (ShowSaveInfo)
                        Public.SystemInfo(LangCenter.Instance.GetSystemMessage("SaveFailed"));
                    return;
                }
            }
        }

        public virtual void btnPrint_Click(object sender, EventArgs e)
        {
            DoPrint();
            FormDataFlag = Sunrise.ERP.BasePublic.DataFlag.dsBrowse;
        }

        public virtual void btnClose_Click(object sender, EventArgs e)
        {
            if (DoBeforeClose())
            {
                FormDataFlag = Sunrise.ERP.BasePublic.DataFlag.dsBrowse;
                DoClose();
            }
        }

        public virtual void btnRefesh_Click(object sender, EventArgs e)
        {
            FormDataFlag = Sunrise.ERP.BasePublic.DataFlag.dsBrowse;
        }

        private bool _ShowSaveInfo = true;
        /// <summary>
        /// 是否显示保存提示信息
        /// </summary>
        public bool ShowSaveInfo
        {
            get
            {
                return _ShowSaveInfo;
            }
            set
            {
                _ShowSaveInfo = value;
            }
        }

        private void LoadLangSetting()
        {
            btnView.Text = LangCenter.Instance.GetFormLangInfo("BaseForm", btnView.Name);
            btnAdd.Text = LangCenter.Instance.GetFormLangInfo("BaseForm", btnAdd.Name);
            btnEdit.Text = LangCenter.Instance.GetFormLangInfo("BaseForm", btnEdit.Name);
            btnCancel.Text = LangCenter.Instance.GetFormLangInfo("BaseForm", btnCancel.Name);
            btnDelete.Text = LangCenter.Instance.GetFormLangInfo("BaseForm", btnDelete.Name);
            btnSave.Text = LangCenter.Instance.GetFormLangInfo("BaseForm", btnSave.Name);
            btnPrint.Text = LangCenter.Instance.GetFormLangInfo("BaseForm", btnPrint.Name);
            btnCopy.Text = LangCenter.Instance.GetFormLangInfo("BaseForm", btnCopy.Name);
            btnClose.Text = LangCenter.Instance.GetFormLangInfo("BaseForm", btnClose.Name);
            btnInsert.Text = LangCenter.Instance.GetFormLangInfo("BaseForm", btnInsert.Name);
            btnRefresh.Text = LangCenter.Instance.GetFormLangInfo("BaseForm", btnRefresh.Name);
            btnSettings.Text = LangCenter.Instance.GetFormLangInfo("BaseForm", btnSettings.Name);
        }
    }
}
