using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

using Sunrise.ERP.Lang;
using Sunrise.ERP.BaseControl;
using Sunrise.ERP.SysBase;
using Sunrise.ERP.DataAccess;
using System.IO;

namespace Sunrise.ERP.BasePublic
{
    /// <summary>
    /// ϵͳ����������
    /// </summary>
    public class SysPublic
    {
        /// <summary>
        /// ���ؼ�Textֵ�Ƿ�Ϊ��
        /// </summary>
        /// <param name="ctl">��Ҫ��֤�Ŀؼ�</param>
        /// <param name="title">��ʾ����</param>
        /// <returns>True-Ϊ�գ�False-��Ϊ��</returns>
        public static bool CheckNotNull(Control ctl,string title)
        {
            if (ctl.Text == "")
            {
                Sunrise.ERP.BaseControl.Public.SystemInfo(title + LangCenter.Instance.GetSystemMessage("NotNull"));
                return true;
            }
            else
            {
                return false;
            }

        }        

        /// <summary>
        /// ȡ�õ�ǰ���������ڼ�
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ChsWeek(DateTime date)
        {
            string week = date.DayOfWeek.ToString();
            switch (week)
            {
                case "Monday": return "����һ";
                case "Tuesday": return "���ڶ�";
                case "Wednesday": return "������";
                case "Thursday": return "������";
                case "Friday": return "������";
                case "Saturday": return "������";
                default: return "������";
            }
        }

        /// <summary>
        /// ȡ�õ�ǰʱ���ũ������
        /// </summary>
        /// <returns></returns>
        public static string CNDate()
        {
            System.Globalization.ChineseLunisolarCalendar l = new System.Globalization.ChineseLunisolarCalendar();
            DateTime dt = DateTime.Today; //ת�����յ�����
            string[] aMonth = { "", "����", "����", "����", "����", "����", "����", "����", "����", "����", "ʮ��", "ʮһ��", "����", "����" };

            string[] a10 = { "��", "ʮ", "��ʮ", "��ʮ" };
            string[] aDigi = { "��", "һ", "��", "��", "��", "��", "��", "��", "��", "��" };
            string sYear = "", sYearArab = "", sMonth = "", sDay = "", sDay10 = "", sDay1 = "", sLuniSolarDate = "";
            int iYear, iMonth, iDay;
            iYear = l.GetYear(dt);
            iMonth = l.GetMonth(dt);
            iDay = l.GetDayOfMonth(dt);

            //Format Year
            sYearArab = iYear.ToString();
            for (int i = 0; i < sYearArab.Length; i++)
            {
                sYear += aDigi[Convert.ToInt16(sYearArab.Substring(i, 1))];
            }

            //Format Month
            int iLeapMonth = l.GetLeapMonth(iYear); //��ȡ����

            if (iLeapMonth > 0 && iMonth <= iLeapMonth)
            {
                aMonth[iLeapMonth] = "��" + aMonth[iLeapMonth - 1];
                sMonth = aMonth[l.GetMonth(dt)];
            }
            else if (iLeapMonth > 0 && iMonth > iLeapMonth)
            {
                sMonth = aMonth[l.GetMonth(dt) - 1];
            }
            else
            {
                sMonth = aMonth[l.GetMonth(dt)];
            }


            //Format Day
            sDay10 = a10[iDay / 10];
            sDay1 = aDigi[(iDay % 10)];
            sDay = sDay10 + sDay1;

            if (iDay == 10) sDay = "��ʮ";
            if (iDay == 20) sDay = "��ʮ";
            if (iDay == 30) sDay = "��ʮ";

            //Format Lunar Date
            sLuniSolarDate = sMonth + sDay;
            return sLuniSolarDate;
        }

        /// <summary>
        /// DataRowViewת��ΪDataTable
        /// </summary>
        /// <param name="drv">DataRowView</param>
        /// <returns>DataTable</returns>
        public static DataTable ConvertDataRowViewToTable(DataRowView drv)
        {
            DataTable dt = drv.DataView.Table.Clone();
            DataRow dr = dt.NewRow();
            for (int i = 0; i < drv.DataView.Table.Columns.Count; i++)
            {
                dr[i] = drv.Row[i];
            }
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// ���ϵͳ��־��¼
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="userid">�û�ID</param>
        /// <param name="action">����</param>
        /// <returns></returns>
        public static void AddIPLog(int formid, string userid, string action)
        {
            SqlTransaction trans = ConnectSetting.SysSqlConnection.BeginTransaction();
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("INSERT INTO sysIPLog(");
                strSql.Append("sUserID,sLoginIP,sLoginMachine,dActionDate,sAction,iFormID)");
                strSql.Append(" VALUES (");
                strSql.Append("@sUserID,@sLoginIP,@sLoginMachine,@dActionDate,@sAction,@iFormID)");
                SqlParameter[] parameters = {
					new SqlParameter("@sUserID", SqlDbType.VarChar,30),
					new SqlParameter("@sLoginIP", SqlDbType.VarChar,15),
					new SqlParameter("@sLoginMachine", SqlDbType.VarChar,50),
					new SqlParameter("@dActionDate", SqlDbType.DateTime),
					new SqlParameter("@sAction", SqlDbType.VarChar,100),
                    new SqlParameter("@iFormID", SqlDbType.Int)};
                parameters[0].Value = userid;
                parameters[1].Value = HardwareInfo.GetIPAddress();
                parameters[2].Value = "(" + Environment.UserName + ")" + Environment.UserDomainName;
                parameters[3].Value = DateTime.Now;
                parameters[4].Value = action;
                parameters[5].Value = formid;

                DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
            }
        }

        /// <summary>
        /// ��ӵ�������Log
        /// </summary>
        /// <param name="formid">����ID</param>
        /// <param name="userid">�û�ID</param>
        /// <param name="billno">���ݺ�</param>
        public static void AddBillLog(int formid, string userid, string billno)
        {
            AddIPLog(formid, userid, string.Format(LangCenter.Instance.GetSystemMessage("AddNewBill"), billno));
        }

        /// <summary>
        /// ���ش���Gird��ʽ
        /// </summary>
        /// <param name="suserid">�û�ID</param>
        /// <param name="formid">FormID</param>
        /// <param name="ctls">��Ҫ������ʽ��Grid List</param>
        public static void LoadFormStyle(string suserid, int formid, List<Control> ctls)
        {
            try
            {
                string sSql = "SELECT sUserID, FormID, ControlName, StyleFile  FROM sysFormStyleSetting WHERE sUserID='" + suserid + "' AND FormID=" + formid.ToString();
                DataTable dtTmp = DbHelperSQL.QueryTable(sSql);
                foreach (var c in ctls)
                {
                    if (c is DevExpress.XtraGrid.GridControl)
                    {
                        DataRow[] drs = dtTmp.Select("ControlName='" + c.Name + "'");
                        if (drs != null && drs.Length == 1)
                        {
                            byte[] bt = (byte[])drs[0]["StyleFile"];
                           ((DevExpress.XtraGrid.GridControl)c).Views[0].RestoreLayoutFromStream(new MemoryStream(bt));
                        }
                    }
                }

            }

            catch
            { }
                
        }

        /// <summary>
        /// ���洰��Gird��ʽ
        /// </summary>
        /// <param name="suserid">�û�ID</param>
        /// <param name="formid">FormID</param>
        /// <param name="ctls">��Ҫ������ʽ��Grid List</param>
        public static void SaveFormStyle(string suserid, int formid, List<Control> ctls)
        {
            SqlTransaction trans = ConnectSetting.SysSqlConnection.BeginTransaction();
            try
            {
                foreach (var c in ctls)
                {
                    MemoryStream ms = new MemoryStream();
                    ((DevExpress.XtraGrid.GridControl)c).Views[0].SaveLayoutToStream(ms);
                    byte[] file = ms.ToArray();
                    string sDel = "DELETE FROM sysFormStyleSetting WHERE FormID=" + formid.ToString() + " AND ControlName='" + c.Name + "'";
                    string sSql = "INSERT INTO sysFormStyleSetting(sUserID,FormID,ControlName,StyleFile) VALUES(@sUserID,@FormID,@ControlName,@StyleFile)";
                    SqlParameter[] para ={
                                new SqlParameter("@sUserID",SqlDbType.VarChar,50),
                                new SqlParameter("@FormID",SqlDbType.Int,4),
                                new SqlParameter("@ControlName",SqlDbType.VarChar,50),
                                new SqlParameter("@StyleFile",SqlDbType.Image)};
                    para[0].Value = suserid;
                    para[1].Value = formid;
                    para[2].Value = c.Name;
                    para[3].Value = file;
                    //��ɾ��ԭ�����ٱ���
                    DbHelperSQL.ExecuteSql(sDel,trans);
                    DbHelperSQL.ExecuteSql(sSql, trans, para);
                    
                }
                trans.Commit();
            }
            catch 
            {
                trans.Rollback();
            }
        }
    }
}
