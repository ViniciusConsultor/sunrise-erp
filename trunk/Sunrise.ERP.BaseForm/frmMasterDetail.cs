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
using Sunrise.ERP.BaseControl;
using Sunrise.ERP.BasePublic;
namespace Sunrise.ERP.BaseForm
{
    /// <summary>
    /// �������ӱ���
    /// </summary>
    public partial class frmMasterDetail : frmSingleForm
    {
        /// <summary>
        /// ��ϸ���ݱ���
        /// </summary>
        protected List<DataSet> LDetailDataSet = new List<DataSet>();
        /// <summary>
        /// �ӱ��ֶμ���
        /// </summary>
        protected List<string> LDetailField = new List<string>();
        /// <summary>
        /// �����ֶμ���
        /// </summary>
        protected List<string> LMasterField = new List<string>();
        /// <summary>
        /// ��ϸ�����ݲ����������
        /// </summary>
        protected List<string> LDetailDALName = new List<string>();

        /// <summary>
        /// ��ϸ�������ֶμ���
        /// </summary>
        protected Hashtable DetailOrderField = new Hashtable();

        /// <summary>
        /// ���캯��
        /// </summary>
        public frmMasterDetail()
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        public frmMasterDetail(int formid, string dalpath, string dalname)
            : base(formid, dalpath,dalname)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        /// <param name="ischeckauth">�Ƿ����Ȩ�޿���</param>
        public frmMasterDetail(int formid, string dalpath, string dalname, bool ischeckauth)
            : base(formid, dalpath,dalname, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        /// <param name="pwhere">���ݹ�������,��������һ��Ҫע��SQL����ƴ��,����ǰ����Ҫ����AND�ؼ���,e.g:AND 1=1</param>
        public frmMasterDetail(int formid, string dalpath, string dalname, string pwhere)
            : base(formid, dalpath,dalname, pwhere)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        /// <param name="pwhere">���ݹ�������,��������һ��Ҫע��SQL����ƴ��,����ǰ����Ҫ����AND�ؼ���,e.g:AND 1=1</param>
        /// <param name="ischeckauth">�Ƿ����Ȩ�޿���</param>
        public frmMasterDetail(int formid, string dalpath, string dalname, string pwhere, bool ischeckauth)
            : base(formid, dalpath,dalname, pwhere, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        /// <param name="pwhere">���ݹ�������,��������һ��Ҫע��SQL����ƴ��,����ǰ����Ҫ����AND�ؼ���,e.g:AND 1=1</param>
        /// <param name="sortfield">�����ֶ�</param>
        public frmMasterDetail(int formid, string dalpath, string dalname, string pwhere, string sortfield)
            : base(formid, dalpath,dalname, pwhere, sortfield)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        /// <param name="pwhere">���ݹ�������,��������һ��Ҫע��SQL����ƴ��,����ǰ����Ҫ����AND�ؼ���,e.g:AND 1=1</param>
        /// <param name="sortfield">�����ֶ�</param>
        /// <param name="ischeckauth">�Ƿ����Ȩ�޿���</param>
        public frmMasterDetail(int formid, string dalpath, string dalname, string pwhere, string sortfield, bool ischeckauth)
            : base(formid, dalpath,dalname, pwhere, sortfield, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        /// <param name="pwhere">���ݹ�������,��������һ��Ҫע��SQL����ƴ��,����ǰ����Ҫ����AND�ؼ���,e.g:AND 1=1</param>
        /// <param name="top">ǰ��������</param>
        /// <param name="sortfield">�����ֶ�</param>
        public frmMasterDetail(int formid, string dalpath, string dalname, int top, string pwhere, string sortfield)
            : base(formid, dalpath,dalname, top, pwhere, sortfield)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="dalname">���ݲ��������</param>
        /// <param name="pwhere">���ݹ�������,��������һ��Ҫע��SQL����ƴ��,����ǰ����Ҫ����AND�ؼ���,e.g:AND 1=1</param>
        /// <param name="top">ǰ��������</param>
        /// <param name="sortfield">�����ֶ�</param>
        /// <param name="ischeckauth">�Ƿ����Ȩ�޿���</param>
        public frmMasterDetail(int formid, string dalpath, string dalname, int top, string pwhere, string sortfield, bool ischeckauth)
            : base(formid, dalpath,dalname, top, pwhere, sortfield, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// ����
        /// ����������
        /// </summary>
        /// <returns></returns>
        public override bool DoSave()
        {
            SqlTransaction trans = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection.BeginTransaction();
            try
            {
                //�ȱ�������
                RegisterMethod(MasterDALPath, MasterDALName, true);
                if (FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsInsert)
                {
                    BillID = Add(((DataRowView)dsMain.Current).Row, trans);
                    //((Sunrise.ERP.Model.Base.BaseEntity)dsMain.Current).ID = BillID;
                }
                else
                {
                    Update(((DataRowView)dsMain.Current).Row, trans);
                }
                //����ӱ�
                for (int i = 0; i < LDetailDataSet.Count; i++)
                {
                    RegisterMethod(MasterDALPath, LDetailDALName[i]);
                    foreach (DataRow dr in LDetailDataSet[i].Tables[0].Rows)
                    {
                        //����
                        if (dr.RowState == DataRowState.Added && dr["ID"].ToString()=="")
                        {
                            dr[LDetailField[i]] = GetMasterLinkValue(LMasterField[i]);
                            dr["ID"] = Add(dr, trans);
                        }
                        //����
                        else if (dr.RowState == DataRowState.Modified && dr["ID"].ToString() != "")
                        {
                            Update(dr, trans);
                        }
                        //ɾ��
                        else if (dr.RowState == DataRowState.Deleted && dr["ID", DataRowVersion.Original].ToString() != "")
                        {
                            Delete(Convert.ToInt32(dr["ID", DataRowVersion.Original]), trans);
                        }
                    }
                }
                trans.Commit();
                return true;
            }
            catch
            {
                trans.Rollback();
                return false;
            }
        }
        public override bool DoAfterSave()
        {
            RegisterMethod(MasterDALPath,MasterDALName, true);
            if (TopCount != 499 && SortField != "dInputDate DESC")
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

            Base.SetAllControlsReadOnly(this.pnlInfo, true);
            IsDataChange = false;
            initButtonsState(OperateFlag.Save);
            return base.DoAfterSave();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <returns></returns>
        public override bool DoDelete()
        {
            if (BillID > 0)
            {
                if (Public.SystemInfo("�Ƿ�ɾ�������ݣ�", 1) == DialogResult.OK)
                {
                    SqlTransaction trans = Sunrise.ERP.BaseControl.ConnectSetting.SysSqlConnection.BeginTransaction();
                    try
                    {
                        RegisterMethod(MasterDALPath,MasterDALName, true);
                        Delete(BillID, trans);
                        trans.Commit();
                        dsMain.RemoveCurrent();
                        IsDataChange = false;
                        //base.DoDelete();
                        if (dsMain.Current == null)
                        {
                            initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.None);
                        }
                        else
                        {
                            initButtonsState(Sunrise.ERP.BasePublic.OperateFlag.Delete);
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
        /// ������ϸ���ݱ�
        /// �����ֶ�һ����Ҫһһ��Ӧ������ϵͳ�޷��������ϵ
        /// </summary>
        /// <param name="dalname">���ݲ����</param>
        ///<param name="detailfield">���ӱ�����ֶ�-�ӱ��ֶ�</param>
        ///<param name="masterfield">���ӱ�����ֶ�-�����ֶ�</param>
        public void AddDetailData(string dalname, string detailfield, string masterfield)
        {
            LDetailDALName.Add(dalname);
            LDetailField.Add(detailfield);
            LMasterField.Add(masterfield);
            RegisterMethod(MasterDALPath,dalname);
            LDetailDataSet.Add(GetDataSet(detailfield + "=" + GetMasterLinkValue(masterfield)));
        }
        /// <summary>
        /// ������ϸ���ݱ�
        /// �����ֶ�һ����Ҫһһ��Ӧ������ϵͳ�޷��������ϵ
        /// </summary>
        /// <param name="dalname">���ݲ����</param>
        ///<param name="detailfield">���ӱ�����ֶ�-�ӱ��ֶ�</param>
        ///<param name="masterfield">���ӱ�����ֶ�-�����ֶ�</param>
        ///<param name="sortfield">��ϸ�������ֶΣ����Զ����e.g:ID DESC,OrderNo</param>
        public void AddDetailData(string dalname, string detailfield, string masterfield, string sortfield)
        {
            LDetailDALName.Add(dalname);
            LDetailField.Add(detailfield);
            LMasterField.Add(masterfield);
            DetailOrderField.Add(dalname, sortfield);
            RegisterMethod(MasterDALPath,dalname);
            string swhere = sortfield != "" ? detailfield + "=" + GetMasterLinkValue(masterfield) + " ORDER BY " + sortfield : detailfield + "=" + GetMasterLinkValue(masterfield);
            LDetailDataSet.Add(GetDataSet(swhere));
        }

        /// <summary>
        /// �������ݹ����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void MasterAllScroll(object sender, EventArgs e)
        {
            try
            {
                if (dsMain.Current != null)
                {
                    BillID = ((DataRowView)(dsMain.Current))["ID"].ToString() == "" ? 0 : Convert.ToInt32(((DataRowView)(dsMain.Current))["ID"]);
                    //����������ӱ�Ĺ�ϵ�ֶ�ˢ�´ӱ�����
                    if (LDetailDataSet.Count > 0)
                    {
                        for (int i = 0; i < LDetailDataSet.Count; i++)
                        {
                            string swhere = "";
                            RegisterMethod(MasterDALPath,LDetailDALName[i]);
                            swhere = LDetailField[i] + "=" + GetMasterLinkValue(LMasterField[i]);
                            if (DetailOrderField[LDetailDALName[i]] != null && DetailOrderField[LDetailDALName[i]].ToString() != "")
                            {
                                swhere += " ORDER BY " + DetailOrderField[LDetailDALName[i]].ToString();
                            }
                            LDetailDataSet[i] = GetDataSet(swhere);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    //����������Ϊ��ʱ���������ϸ����
                    for (int i = 0; i < LDetailDataSet.Count; i++)
                    {
                        LDetailDataSet[i].Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Public.SystemInfo("MasterAllScroll-" + ex.Message, true);
            }            
        }
        /// <summary>
        /// ȡ�������������������ֶ�ֵ
        /// </summary>
        /// <param name="masterfield">���������ֶ�</param>
        /// <returns></returns>
        public string GetMasterLinkValue(string masterfield)
        {
            string sResult = "";
            if (masterfield.Trim().ToUpper() == "ID")
            {
                sResult = BillID.ToString();
            }
            else
            {
                try
                {
                    RegisterMethod(MasterDALPath, MasterDALName, true);
                    sResult = GetDataSet(1, "ID=" + BillID.ToString(), "ID").Tables[0].Rows[0][masterfield].ToString();
                }
                catch (Exception)
                {
                    Public.SystemInfo("���ӱ������ֶ����ô���", true);
                }
            }
            return sResult;
        }

        private int pnlGridWidth = 200;
        private void splitterControl2_DoubleClick(object sender, EventArgs e)
        {
            if (pnlGrid.Width != 0)
            {
                pnlGridWidth = pnlGrid.Width;
                pnlGrid.Width = 0;
                toolTipController1.SetToolTip(splitterControl2, "˫��չ������");
            }
            else
            {
                pnlGrid.Width = pnlGridWidth;
                toolTipController1.SetToolTip(splitterControl2, "˫���۵�����");
            }
        }
    }
}