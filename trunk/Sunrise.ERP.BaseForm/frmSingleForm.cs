using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SqlClient;

using Sunrise.ERP.Security;
using Sunrise.ERP.BasePublic;
using Sunrise.ERP.Lang;
using Sunrise.ERP.BaseControl;

namespace Sunrise.ERP.BaseForm
{
    /// <summary>
    /// ����������
    /// </summary>
    public partial class frmSingleForm : frmBaseForm
    {
        #region ����
        /// <summary>
        /// ���ݲ��������
        /// </summary>
        private object objDAL;
        private MethodInfo mGetDataSet;
        private MethodInfo mGetTopDataSet;
        private MethodInfo mAddInTrans;
        private MethodInfo mUpdateInTrans;
        private MethodInfo mDeleteInTrans;

        /// <summary>
        /// ��������
        /// </summary>
        protected DataTable dtMain;


        /// <summary>
        /// ��������б�
        /// </summary>
        protected Hashtable FormParaList = new Hashtable();

        /// <summary>
        /// Ȩ�޴�����
        /// </summary>
        protected SecurityCenter SC = new SecurityCenter();

        #endregion

        #region ���캯��
        /// <summary>
        /// ���캯��
        /// </summary>
        public frmSingleForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        /// <param name="pwhere">���ݹ�������,��������һ��Ҫע��SQL����ƴ��,����ǰ����Ҫ����AND�ؼ���,e.g:AND 1=1</param>
        /// <param name="top">ǰ����������</param>
        /// <param name="sortfield">�����ֶ�</param>
        public frmSingleForm(int formid, string dalpath,string dalname, int top, string pwhere, string sortfield)
            : base(formid)
        {
            InitializeComponent();
            pWhere = pwhere;
            TopCount = top;
            SortField = sortfield;
            MasterDALName = dalname;
            RegisterMethod(dalpath,dalname, true);
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(top, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, sortfield).Tables[0];
                //MasterSQL = SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere;
            }
            else
            {
                dtMain = GetDataSet(top, "1=1 " + pWhere, sortfield).Tables[0];
                //MasterSQL = "1=1 " + pWhere;
            }
            //dtMain = GetDataSet(TopCount, MasterSQL, SortField).Tables[0];
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        /// <param name="pwhere">���ݹ�������,��������һ��Ҫע��SQL����ƴ��,����ǰ����Ҫ����AND�ؼ���,e.g:AND 1=1</param>
        /// <param name="top">ǰ����������</param>
        /// <param name="sortfield">�����ֶ�</param>
        /// <param name="ischeckauth">�Ƿ����Ȩ�޿���</param>
        public frmSingleForm(int formid, string dalpath, string dalname, int top, string pwhere, string sortfield, bool ischeckauth)
            : base(formid)
        {
            InitializeComponent();
            pWhere = pwhere;
            TopCount = top;
            SortField = sortfield;
            IsCheckAuth = ischeckauth;
            MasterDALName = dalname;
            RegisterMethod(dalpath,dalname, true);
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(top, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, sortfield).Tables[0];
                //MasterSQL = SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere;
            }
            else
            {
                dtMain = GetDataSet(top, "1=1 " + pWhere, sortfield).Tables[0];
                //MasterSQL = "1=1 " + pWhere;
            }
            //dtMain = GetDataSet(TopCount, MasterSQL, SortField).Tables[0];
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        /// <param name="pwhere">���ݹ�������,��������һ��Ҫע��SQL����ƴ��,����ǰ����Ҫ����AND�ؼ���,e.g:AND 1=1</param>
        /// <param name="sortfield">�����ֶ�</param>
        public frmSingleForm(int formid, string dalpath, string dalname, string pwhere, string sortfield)
            : base(formid)
        {
            InitializeComponent();
            SortField = sortfield;
            //pWhere = sortfield != "" ? pwhere + " ORDER BY " + sortfield : pwhere;
            pWhere = pwhere;
            SortField = sortfield;
            TopCount = 10000000;
            MasterDALName = dalname;
            RegisterMethod(dalpath,dalname, true);
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(TopCount, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, SortField).Tables[0];
                //MasterSQL = SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere;
            }
            else
            {
                dtMain = GetDataSet(TopCount, "1=1 " + pWhere, SortField).Tables[0];
                //MasterSQL = "1=1 " + pWhere;
            }
            //dtMain = GetDataSet(100000, MasterSQL, SortField).Tables[0];
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);

        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        /// <param name="pwhere">���ݹ�������,��������һ��Ҫע��SQL����ƴ��,����ǰ����Ҫ����AND�ؼ���,e.g:AND 1=1</param>
        /// <param name="sortfield">�����ֶ�</param>
        /// <param name="ischeckauth">�Ƿ����Ȩ�޿���</param>
        public frmSingleForm(int formid, string dalpath, string dalname, string pwhere, string sortfield, bool ischeckauth)
            : base(formid)
        {
            InitializeComponent();
            SortField = sortfield;
            //pWhere = sortfield != "" ? pwhere + " ORDER BY " + sortfield : pwhere;
            pWhere = pwhere;
            SortField = sortfield;
            TopCount = 1000000;
            IsCheckAuth = ischeckauth;
            MasterDALName = dalname;
            RegisterMethod(dalpath,dalname, true);
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(TopCount, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, SortField).Tables[0];
                //MasterSQL = SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere;
            }
            else
            {
                dtMain = GetDataSet(TopCount, "1=1 " + pWhere, SortField).Tables[0];
                //MasterSQL = "1=1 " + pWhere;
            }
            //dtMain = GetDataSet(10000, MasterSQL, SortField).Tables[0];
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);

        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        /// <param name="pwhere">���ݹ�������,��������һ��Ҫע��SQL����ƴ��,����ǰ����Ҫ����AND�ؼ���,e.g:AND 1=1</param>
        public frmSingleForm(int formid, string dalpath, string dalname, string pwhere)
            : base(formid)
        {
            InitializeComponent();
            pWhere = pwhere;
            MasterDALName = dalname;
            RegisterMethod(dalpath,dalname, true);
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
                //MasterSQL = SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere;
            }
            else
            {
                dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
                //MasterSQL = "1=1 " + pWhere;
            }
            //dtMain = GetDataSet(MasterSQL).Tables[0];
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);

        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        /// <param name="pwhere">���ݹ�������,��������һ��Ҫע��SQL����ƴ��,����ǰ����Ҫ����AND�ؼ���,e.g:AND 1=1</param>
        /// <param name="ischeckauth">�Ƿ����Ȩ�޿���</param>
        public frmSingleForm(int formid, string dalpath, string dalname, string pwhere, bool ischeckauth)
            : base(formid)
        {
            InitializeComponent();
            pWhere = pwhere;
            IsCheckAuth = ischeckauth;
            MasterDALName = dalname;
            RegisterMethod(dalpath,dalname, true);
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
                //MasterSQL = SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere;
            }
            else
            {
                dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
                //MasterSQL = "1=1 " + pWhere;
            }
            //dtMain = GetDataSet(MasterSQL).Tables[0];
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);

        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        public frmSingleForm(int formid, string dalpath, string dalname)
            : base(formid)
        {
            InitializeComponent();
            MasterDALName = dalname;
            RegisterMethod(dalpath,dalname, true);
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
                //MasterSQL = SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere;
            }
            else
            {
                dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
                //MasterSQL = "1=1 " + pWhere;
            }
            //dtMain = GetDataSet(MasterSQL).Tables[0];
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        /// <param name="ischeckauth">�Ƿ����Ȩ�޿���</param>
        public frmSingleForm(int formid, string dalpath, string dalname, bool ischeckauth)
            : base(formid)
        {
            InitializeComponent();
            IsCheckAuth = ischeckauth;
            MasterDALName = dalname;
            RegisterMethod(dalpath,dalname, true);
            if (IsCheckAuth)
            {
                dtMain = GetDataSet(SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
                //MasterSQL = SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere;
            }
            else
            {
                dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
                //MasterSQL = "1=1 " + pWhere;
            }
            //dtMain = GetDataSet(MasterSQL).Tables[0];
            dsMain.DataSource = dtMain;
            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
        }

        /// <summary>
        /// �иı�-����ͬ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dtMain_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            e.Row.EndEdit();
        }
        #endregion

        #region ��д������ť״̬����
        /// <summary>
        /// ��ѯ
        /// </summary>
        public override void DoView()
        {
            if (MasterFilerSQL != "")
            {
                RegisterMethod(MasterDALPath, MasterDALName, true);
                if (TopCount != 499 && SortField != "dInputDate DESC")
                {
                    if (IsCheckAuth)
                    {
                        dtMain = GetDataSet(TopCount, SC.GetAuthSQL(ShowType.FormQuery, FormID) + pWhere + MasterFilerSQL, SortField).Tables[0];
                    }
                    else
                    {
                        dtMain = GetDataSet(TopCount, "1=1 " + pWhere + MasterFilerSQL, SortField).Tables[0];
                    }
                    dsMain.DataSource = dtMain;
                    dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                }
                else
                {
                    if (IsCheckAuth)
                    {
                        dtMain = GetDataSet(SC.GetAuthSQL(ShowType.FormQuery, FormID) + pWhere + MasterFilerSQL).Tables[0];
                    }
                    else
                    {
                        dtMain = GetDataSet("1=1 " + pWhere + MasterFilerSQL).Tables[0];
                    }
                    dsMain.DataSource = dtMain;
                    dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                }
            }
            if (dsMain.Current != null)
            {
                base.DoView();
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                IsDataChange = false;
            }
            else
            {
                initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.None);
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                IsDataChange = false;
            }
        }

        /// <summary>
        /// ��ѯ
        /// </summary>
        public override void DoBaseView()
        {
            if (dsMain.Current != null)
            {
                base.DoBaseView();
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                IsDataChange = false;
            }
            else
            {
                initButtonsState(OperateFlag.None);
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                IsDataChange = false;
            }
        }

        /// <summary>
        /// ����֮ǰִ�еķ���
        /// </summary>
        public override bool DoAppend()
        {
            Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, false);
            dsMain.AddNew();
            dsMain.EndEdit();
            ((DataRowView)dsMain.Current).Row["iFlag"] = 0;
            ((DataRowView)dsMain.Current).Row["sUserID"] = Sunrise.ERP.Security.SecurityCenter.CurrentUserID;
            IsDataChange = false;
            return base.DoAppend();

        }
        /// <summary>
        /// ȡ��֮ǰִ�еķ���
        /// </summary>
        /// <returns></returns>
        public override bool DoBeforeCancel()
        {
            if (dsMain.Current != null)
            {
                RegisterMethod(MasterDALPath, MasterDALName, true);
                if (IsDataChange)
                {
                    if (Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm","DataNotSavedForCancel"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (TopCount != 499 & SortField != "dInputDate DESC")
                        {
                            if (IsCheckAuth)
                            {
                                dtMain = GetDataSet(TopCount, SC.GetAuthSQL(MasterFilerSQL == "" ? ShowType.FormShow : ShowType.FormQuery, FormID) + pWhere, SortField).Tables[0];
                            }
                            else
                            {
                                dtMain = GetDataSet(TopCount, "1=1 " + pWhere, SortField).Tables[0];
                            }
                            dsMain.DataSource = dtMain;
                            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);

                        }
                        else
                        {
                            if (IsCheckAuth)
                            {
                                dtMain = GetDataSet(SC.GetAuthSQL(MasterFilerSQL == "" ? ShowType.FormShow : ShowType.FormQuery, FormID) + pWhere).Tables[0];
                            }
                            else
                            {
                                dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
                            }
                            dsMain.DataSource = dtMain;
                            dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                        }
                        dsMain.CancelEdit();
                        Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                        IsDataChange = false;
                        return base.DoBeforeCancel();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (TopCount != 499 & SortField != "dInputDate DESC")
                    {
                        if (IsCheckAuth)
                        {
                            dtMain = GetDataSet(TopCount, SC.GetAuthSQL(MasterFilerSQL == "" ? ShowType.FormShow : ShowType.FormQuery, FormID) + pWhere, SortField).Tables[0];
                        }
                        else
                        {
                            dtMain = GetDataSet(TopCount, "1=1 " + pWhere, SortField).Tables[0];
                        }
                        dsMain.DataSource = dtMain;
                        dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                    }
                    else
                    {
                        if (IsCheckAuth)
                        {
                            dtMain = GetDataSet(SC.GetAuthSQL(MasterFilerSQL == "" ? ShowType.FormShow : ShowType.FormQuery, FormID) + pWhere).Tables[0];
                        }
                        else
                        {
                            dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
                        }
                        dsMain.DataSource = dtMain;
                        dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                    }
                    dsMain.CancelEdit();
                    Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                    IsDataChange = false;
                    return base.DoBeforeCancel();
                }
            }
            else
            {
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                IsDataChange = false;
                return base.DoBeforeCancel();
            }
        }
        /// <summary>
        /// ȡ��
        /// </summary>
        public override void DoCancel()
        {
            if (dsMain.Current != null)
            {
                base.DoCancel();
            }
            else
            {
                initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.None);
            }
        }
        /// <summary>
        /// �༭
        /// </summary>
        public override void DoEdit()
        {
            base.DoEdit();
            Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, false);
            IsDataChange = false;
        }
        /// <summary>
        /// ����
        /// </summary>
        public override void DoCopy()
        {
            base.DoCopy();
            DataRow drTemp = ((DataRowView)dsMain.Current).Row;
            DoAppend();
            //���Ʋ���Ҫ���Ƶ��ֶ�
            for (int i = 0; i < drTemp.ItemArray.Length; i++)
            {
                if (!NotCopyFields.Contains(drTemp.Table.Columns[i].ColumnName))
                {
                    ((DataRowView)dsMain.Current).Row[i] = drTemp[i];
                }
            }
            //((DataRowView)dsMain.Current).Row["iFlag"] = 0;
            //((DataRowView)dsMain.Current).Row["sUserID"] = Sunrise.ERP.Security.SecurityCenter.CurrentUserID;
            dsMain.EndEdit();
            //Sunrise.ERP.BasePublic.BasePublic.SetAllControlsReadOnly(this.pnlInfo, false);
            //IsDataChange = false;

        }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public override bool DoSave()
        {
            SqlTransaction trans = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection.BeginTransaction();
            RegisterMethod(MasterDALPath, MasterDALName, true);
            if (FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsInsert)
            {
                try
                {
                    Add(((DataRowView)dsMain.Current).Row, trans);
                    trans.Commit();
                    if (TopCount != 499 & SortField != "dInputDate DESC")
                    {
                        if (IsCheckAuth)
                        {
                            dtMain = GetDataSet(TopCount, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, SortField).Tables[0];
                        }
                        else
                        {
                            dtMain = GetDataSet(TopCount, "1=1 " + pWhere, SortField).Tables[0];
                        }
                        dsMain.DataSource = dtMain;
                        dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                    }
                    else
                    {
                        if (IsCheckAuth)
                        {
                            dtMain = GetDataSet(SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
                        }
                        else
                        {
                            dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
                        }
                        dsMain.DataSource = dtMain;
                        dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                    }
                    Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                    IsDataChange = false;
                    return base.DoSave();

                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
            else
            {
                try
                {
                    Update(((DataRowView)dsMain.Current).Row, trans);
                    trans.Commit();
                    if (TopCount != 499 & SortField != "dInputDate DESC")
                    {
                        if (IsCheckAuth)
                        {
                            dtMain = GetDataSet(TopCount, SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere, SortField).Tables[0];
                        }
                        else
                        {
                            dtMain = GetDataSet(TopCount, "1=1 " + pWhere, SortField).Tables[0];
                        }
                        dsMain.DataSource = dtMain;
                        dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                    }
                    else
                    {
                        if (IsCheckAuth)
                        {
                            dtMain = GetDataSet(SC.GetAuthSQL(ShowType.FormShow, FormID) + pWhere).Tables[0];
                        }
                        else
                        {
                            dtMain = GetDataSet("1=1 " + pWhere).Tables[0];
                        }
                        dsMain.DataSource = dtMain;
                        dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
                    }
                    Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                    IsDataChange = false;
                    return base.DoSave();
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
        /// <summary>
        /// ����ǰִ�еķ���
        /// </summary>
        /// <returns></returns>
        public override bool DoBeforeSave()
        {
            //�ǿ���֤
            if (NotNullFields.Count > 0)
            {
                if (Sunrise.ERP.BasePublic.Base.CheckNotNullFields(this.pnlInfo, NotNullFields))
                {
                    Sunrise.ERP.BasePublic.Base.IsNull = true;
                    return true;
                }
                else
                {
                    Sunrise.ERP.BasePublic.Base.IsNull = true;
                    return false;
                }
            }
            return true;

        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <returns></returns>
        public override bool DoDelete()
        {
            if (BillID > 0)
            {
                if (Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm","DeleteData"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlTransaction trans = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection.BeginTransaction();
                    try
                    {
                        RegisterMethod(MasterDALPath, MasterDALName, true);
                        Delete(BillID, trans);
                        trans.Commit();
                        dsMain.RemoveCurrent();
                        IsDataChange = false;
                        base.DoDelete();
                        if (dsMain.Current == null)
                        {
                            initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.None);
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// �ر�֮ǰִ�еķ���
        /// </summary>
        /// <returns></returns>
        public override bool DoBeforeClose()
        {
            return base.DoBeforeCancel();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (IsDataChange)
            {
                if (Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "DataNotSavedForClose"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                    IsDataChange = false;
                    base.OnFormClosing(e);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, true);
                IsDataChange = false;
                base.OnFormClosing(e);
            }

        }


        #endregion

        #region ��������
        /// <summary>
        /// �����ʼ��
        /// </summary>
        public override void initBase()
        {
            base.initBase();
            //���÷ǿ��ֶ���ɫ
            Sunrise.ERP.BasePublic.Base.SetNotNullFiledsColor(this.pnlInfo, NotNullFields);
            IsDataChange = false;

        }

        private int pnlInfoHeight = 300;
        private void splitterControl1_DoubleClick(object sender, EventArgs e)
        {
            if (pnlInfo.Height != 0)
            {
                pnlInfoHeight = pnlInfo.Height;
                pnlInfo.Height = 0;
                toolTipController1.SetToolTip(splitterControl1, LangCenter.Instance.GetFormLangInfo("BaseForm", "DbClickToExpand"));
            }
            else
            {
                pnlInfo.Height = pnlInfoHeight;
                toolTipController1.SetToolTip(splitterControl1, LangCenter.Instance.GetFormLangInfo("BaseForm", "DbClickToClose"));
            }
        }

        /// <summary>
        /// �����ڰ��»س�����ؼ������Զ�����
        /// </summary>
        /// <param name="e"></param>
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

        #endregion

        #region ע��ҵ���߼������ݲ�������
        /// <summary>
        /// ע�����ݲ����ݲ�������
        /// ��ismaster������ʾע��ӱ�
        /// </summary>
        /// <param name="dalname">���ݲ������</param>
        /// <param name="pwhere">����</param>
        /// <param name="ismaster">�Ƿ�Ϊ����򵥱�</param>
        public void RegisterMethod(string dalpath, string dalname, string pwhere, bool ismaster)
        {
            pWhere = pwhere;
            if (ismaster)
            {
                MasterDALName = dalname;
            }
            MasterDALPath = dalpath;
            Type tDAL = Assembly.Load(dalpath).GetType(dalpath + "." + dalname);
            objDAL = Assembly.Load(dalpath).CreateInstance(dalpath + "." + dalname);
            mGetDataSet = tDAL.GetMethod("GetList", new Type[] { typeof(string) });
            mGetTopDataSet = tDAL.GetMethod("GetList", new Type[] { typeof(int), typeof(string), typeof(string) });
            mAddInTrans = tDAL.GetMethod("Add", new Type[] { typeof(DataRow), typeof(SqlTransaction) });
            mUpdateInTrans = tDAL.GetMethod("Update", new Type[] { typeof(DataRow), typeof(SqlTransaction) });
            mDeleteInTrans = tDAL.GetMethod("Delete", new Type[] { typeof(int), typeof(SqlTransaction) });
        }

        /// <summary>
        /// ע�����ݲ����ݲ�������
        /// ��ismaster������ʾע��ӱ�
        /// </summary>
        /// <param name="dalname">���ݲ������</param>
        /// <param name="ismaster">�Ƿ�Ϊ����򵥱�</param>
        public void RegisterMethod(string dalpath, string dalname, bool ismaster)
        {
            if (ismaster)
            {
                MasterDALName = dalname;
            }
            MasterDALPath = dalpath;
            Type tDAL = Assembly.Load(dalpath).GetType(dalpath + "." + dalname);
            objDAL = Assembly.Load(dalpath).CreateInstance(dalpath + "." + dalname);
            mGetDataSet = tDAL.GetMethod("GetList", new Type[] { typeof(string) });
            mGetTopDataSet = tDAL.GetMethod("GetList", new Type[] { typeof(int), typeof(string), typeof(string) });
            mAddInTrans = tDAL.GetMethod("Add", new Type[] { typeof(DataRow), typeof(SqlTransaction) });
            mUpdateInTrans = tDAL.GetMethod("Update", new Type[] { typeof(DataRow), typeof(SqlTransaction) });
            mDeleteInTrans = tDAL.GetMethod("Delete", new Type[] { typeof(int), typeof(SqlTransaction) });
        }

        /// <summary>
        /// ע�����ݲ����ݲ�������
        /// ��ismaster������ʾע��ӱ�
        /// </summary>
        /// <param name="dalname">���ݲ������</param>
        public void RegisterMethod(string dalpath, string dalname)
        {
            Type tDAL = Assembly.Load(dalpath).GetType(dalpath + "." + dalname);
            objDAL = Assembly.Load(dalpath).CreateInstance(dalpath + "." + dalname);
            mGetDataSet = tDAL.GetMethod("GetList", new Type[] { typeof(string) });
            mGetTopDataSet = tDAL.GetMethod("GetList", new Type[] { typeof(int), typeof(string), typeof(string) });
            mAddInTrans = tDAL.GetMethod("Add", new Type[] { typeof(DataRow), typeof(SqlTransaction) });
            mUpdateInTrans = tDAL.GetMethod("Update", new Type[] { typeof(DataRow), typeof(SqlTransaction) });
            mDeleteInTrans = tDAL.GetMethod("Delete", new Type[] { typeof(int), typeof(SqlTransaction) });
        }

        /// <summary>
        /// ע�����ݲ����ݲ�������
        /// ��ismaster������ʾע��ӱ�
        /// </summary>
        /// <param name="dalname">���ݲ������</param>
        /// <param name="pwhere">����</param>
        public void RegisterMethod(string dalpath, string dalname, string pwhere)
        {
            pWhere = pwhere;
            Type tDAL = Assembly.Load(dalpath).GetType(dalpath + "." + dalname);
            objDAL = Assembly.Load(dalpath).CreateInstance(dalpath + "." + dalname);
            mGetDataSet = tDAL.GetMethod("GetList", new Type[] { typeof(string) });
            mGetTopDataSet = tDAL.GetMethod("GetList", new Type[] { typeof(int), typeof(string), typeof(string) });
            mAddInTrans = tDAL.GetMethod("Add", new Type[] { typeof(DataRow), typeof(SqlTransaction) });
            mUpdateInTrans = tDAL.GetMethod("Update", new Type[] { typeof(DataRow), typeof(SqlTransaction) });
            mDeleteInTrans = tDAL.GetMethod("Delete", new Type[] { typeof(int), typeof(SqlTransaction) });
        }
        #endregion

        #region ���ݲ���
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="dr">�����ж���</param>
        /// <param name="trans">SQL����</param>
        /// <returns></returns>
        public int Add(DataRow dr, SqlTransaction trans)
        {
            try
            {
                object[] obj = { dr, trans };
                return (int)mAddInTrans.Invoke(objDAL, obj);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="dr">�����ж���</param>
        /// <param name="trans">SQL����</param>
        /// <returns></returns>
        public int Update(DataRow dr, SqlTransaction trans)
        {
            try
            {
                object[] obj = { dr, trans };
                return Convert.ToInt32(mUpdateInTrans.Invoke(objDAL, obj));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="id">����ID</param>
        /// <param name="trans">SQL����</param>
        /// <returns></returns>
        public void Delete(int id, SqlTransaction trans)
        {
            try
            {
                object[] obj = { id, trans };
                mDeleteInTrans.Invoke(objDAL, obj);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// ��ȡ���ݼ�
        /// </summary>
        /// <param name="pwhere">����</param>
        /// <returns></returns>
        public DataSet GetDataSet(string pwhere)
        {
            try
            {
                object[] obj = { pwhere };
                return (DataSet)mGetDataSet.Invoke(objDAL, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ��ȡ���ݼ�
        /// </summary>
        /// <param name="top">ǰ������</param>
        /// <param name="pwhere">����</param>
        /// <param name="order">�����ֶ�</param>
        /// <returns></returns>
        public DataSet GetDataSet(int top, string pwhere, string order)
        {
            try
            {
                object[] obj = { top, pwhere, order };
                return (DataSet)mGetTopDataSet.Invoke(objDAL, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ����״̬����
        /// <summary>
        /// ����״̬����
        /// �����ӱ�����һ��Ҫ��д�˷�����������ϸGrid����ť״̬
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void DataStateChange(object sender, EventArgs e)
        {
            Base.SetControlsGridEnable(this.pnlGrid, FormDataFlag == DataFlag.dsBrowse);
        }
        private void dsMain_CurrentItemChanged(object sender, EventArgs e)
        {
            if (dsMain.Current != null)
            {
                BillID = ((DataRowView)(dsMain.Current))["ID"].ToString() == "" ? 0 : Convert.ToInt32(((DataRowView)(dsMain.Current))["ID"]);
                if (IsFirstLoad)
                {
                    if (FormDataFlag != DataFlag.dsBrowse)
                    {
                        IsDataChange = true;
                    }
                }
            }
        }

        private void dsMain_CurrentChanged(object sender, EventArgs e)
        {
            if (dsMain.Current == null)
            {
                initButtonsState(OperateFlag.None);
            }
        }

        #endregion

        #region ��������

        /// <summary>
        /// ��������ID(����ID)
        /// </summary>
        private int _BillID = 0;

        /// <summary>
        /// ��������ID(����ID)
        /// </summary>
        protected int BillID
        {
            get
            {
                return _BillID;
            }
            set
            {
                _BillID = value;
            }
        }

        private bool _datachange = false;

        /// <summary>
        /// �����Ƿ���
        /// </summary>
        protected bool IsDataChange
        {
            get
            {
                return _datachange;
            }
            set
            {
                _datachange = value;
            }
        }

        private string _pwhere = " AND 1=1";

        /// <summary>
        /// ������������
        /// </summary>
        protected string pWhere
        {
            get
            {
                return _pwhere;
            }
            set
            {
                _pwhere = value;
            }
        }

        private int _top = 499;

        /// <summary>
        /// ��������Ĭ����ʾ����
        /// </summary>
        protected int TopCount
        {
            get
            {
                return _top;
            }
            set
            {
                _top = value;
            }
        }

        private string _sortfield = "dInputDate DESC";

        /// <summary>
        /// �����ֶ�
        /// </summary>
        protected string SortField
        {
            get
            {
                return _sortfield;
            }
            set
            {
                _sortfield = value;
            }
        }

        private string _dalname;
        /// <summary>
        /// �������ݲ��������
        /// </summary>
        protected string MasterDALName
        {
            get
            {
                return _dalname;
            }
            set
            {
                _dalname = value;
            }
        }
        private string _dalpath;
        /// <summary>
        /// �������ݲ��������
        /// </summary>
        protected string MasterDALPath
        {
            get
            {
                return _dalpath;
            }
            set
            {
                _dalpath = value;
            }
        }

        private bool _ischeckauth = true;

        /// <summary>
        /// ���ô����Ƿ���Ҫ����Ȩ����֤
        /// </summary>
        protected bool IsCheckAuth
        {
            get
            {
                return _ischeckauth;
            }
            set
            {
                _ischeckauth = value;
            }
        }

        private string _MasterSql = "";
        /// <summary>
        /// ������������SQL
        /// </summary>
        protected string MasterSQL
        {
            get
            {
                return _MasterSql;
            }
            set
            {
                _MasterSql = value;
            }
        }

        private string _MasterFilterSql = "";
        /// <summary>
        /// �����������ݲ�ѯ����SQL
        /// </summary>
        protected string MasterFilerSQL
        {
            get
            {
                return _MasterFilterSql;
            }
            set
            {
                _MasterFilterSql = value;
            }
        }
        #endregion             

        #region ��ť����Ȩ�޼��

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsCheckAuth && !SC.CheckAuth(SecurityOperation.Add, FormID))
            {
                Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "NoAddAuth"));
                return;
            }
            base.btnAdd_Click(sender, e);
        }

        public override void btnView_Click(object sender, EventArgs e)
        {
            string sUserID = dsMain.Current == null ? "" : ((DataRowView)dsMain.Current)["sUserID"].ToString();
            if (IsCheckAuth && !SC.CheckAuth(SecurityOperation.View, FormID, sUserID))
            {
                Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "NoQueryAuth"));
                return;
            }
            base.btnView_Click(sender, e);
        }

        public override void btnEdit_Click(object sender, EventArgs e)
        {
            if (IsCheckAuth && !SC.CheckAuth(SecurityOperation.Edit, FormID, ((DataRowView)dsMain.Current)["sUserID"].ToString()))
            {
                Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "NoEditAuth"));
                return;
            }
            if (((DataRowView)dsMain.Current)["iFlag"].ToString()=="4")
            {
                Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "AuthedCannotEdit"));
                return;
            }
            base.btnEdit_Click(sender, e);
        }

        public override void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsCheckAuth && !SC.CheckAuth(SecurityOperation.Delete, FormID, ((DataRowView)dsMain.Current)["sUserID"].ToString()))
            {
                Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "NoDeleteAuth"));
                return;
            }
            if (((DataRowView)dsMain.Current)["iFlag"].ToString() == "4")
            {
                Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "AuthedCannotDelete"));
                return;
            }
            base.btnDelete_Click(sender, e);
        }

        public override void btnPrint_Click(object sender, EventArgs e)
        {
            if (IsCheckAuth && !SC.CheckAuth(SecurityOperation.Print, FormID, ((DataRowView)dsMain.Current)["sUserID"].ToString()))
            {
                Public.SystemInfo(LangCenter.Instance.GetFormLangInfo("BaseForm", "NoPrintAuth"));
                return;
            }
            base.btnPrint_Click(sender, e);
        }
        #endregion

    }
}
