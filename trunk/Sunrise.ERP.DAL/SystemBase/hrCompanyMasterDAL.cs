//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.DAL
//Description:      hrCompanyMasterDAL
//Create by:        自动生成
//Create Date:      2010-11-14 15:02:14
//Modify by：              Modify Date：               Description：
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sunrise.ERP.DataAccess;
namespace Sunrise.ERP.SystemModule.DAL
{
    /// <summary>
    /// 数据访问类hrCompanyMasterDAL
    /// </summary>
    public class hrCompanyMasterDAL
    {
        public hrCompanyMasterDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM hrCompanyMaster");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DataRow dr, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO hrCompanyMaster(");
            strSql.Append("sCompanyID,sCompanySName,sCompanyCName,sCompanyEName,sCorporation,sTel,sFax,sEmail,sHomepage,sChnAddr,sEngAddr,sPostCode,sTax,sChnTitle,sEngTitle,sChnTitle2,sEngTitle2,mlogo,sRemark,dBillDate,iFlag,sUserID)");
            strSql.Append(" VALUES (");
            strSql.Append("@sCompanyID,@sCompanySName,@sCompanyCName,@sCompanyEName,@sCorporation,@sTel,@sFax,@sEmail,@sHomepage,@sChnAddr,@sEngAddr,@sPostCode,@sTax,@sChnTitle,@sEngTitle,@sChnTitle2,@sEngTitle2,@mlogo,@sRemark,@dBillDate,@iFlag,@sUserID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sCompanyID", SqlDbType.VarChar,20),
					new SqlParameter("@sCompanySName", SqlDbType.VarChar,50),
					new SqlParameter("@sCompanyCName", SqlDbType.VarChar,100),
					new SqlParameter("@sCompanyEName", SqlDbType.VarChar,100),
					new SqlParameter("@sCorporation", SqlDbType.VarChar,20),
					new SqlParameter("@sTel", SqlDbType.VarChar,50),
					new SqlParameter("@sFax", SqlDbType.VarChar,20),
					new SqlParameter("@sEmail", SqlDbType.VarChar,50),
					new SqlParameter("@sHomepage", SqlDbType.VarChar,50),
					new SqlParameter("@sChnAddr", SqlDbType.VarChar,100),
					new SqlParameter("@sEngAddr", SqlDbType.VarChar,150),
					new SqlParameter("@sPostCode", SqlDbType.VarChar,50),
					new SqlParameter("@sTax", SqlDbType.VarChar,50),
					new SqlParameter("@sChnTitle", SqlDbType.VarChar,100),
					new SqlParameter("@sEngTitle", SqlDbType.VarChar,150),
					new SqlParameter("@sChnTitle2", SqlDbType.VarChar,100),
					new SqlParameter("@sEngTitle2", SqlDbType.VarChar,150),
					new SqlParameter("@mlogo", SqlDbType.Image),
					new SqlParameter("@sRemark", SqlDbType.VarChar,100),
					new SqlParameter("@dBillDate", SqlDbType.DateTime),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,20)};
            parameters[0].Value = dr["sCompanyID"];
            parameters[1].Value = dr["sCompanySName"];
            parameters[2].Value = dr["sCompanyCName"];
            parameters[3].Value = dr["sCompanyEName"];
            parameters[4].Value = dr["sCorporation"];
            parameters[5].Value = dr["sTel"];
            parameters[6].Value = dr["sFax"];
            parameters[7].Value = dr["sEmail"];
            parameters[8].Value = dr["sHomepage"];
            parameters[9].Value = dr["sChnAddr"];
            parameters[10].Value = dr["sEngAddr"];
            parameters[11].Value = dr["sPostCode"];
            parameters[12].Value = dr["sTax"];
            parameters[13].Value = dr["sChnTitle"];
            parameters[14].Value = dr["sEngTitle"];
            parameters[15].Value = dr["sChnTitle2"];
            parameters[16].Value = dr["sEngTitle2"];
            parameters[17].Value = dr["mlogo"];
            parameters[18].Value = dr["sRemark"];
            parameters[19].Value = dr["dBillDate"];
            parameters[20].Value = dr["iFlag"];
            parameters[21].Value = dr["sUserID"];

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), trans, parameters);
            if (obj == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DataRow dr, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE hrCompanyMaster SET ");
            strSql.Append("sCompanyID=@sCompanyID,");
            strSql.Append("sCompanySName=@sCompanySName,");
            strSql.Append("sCompanyCName=@sCompanyCName,");
            strSql.Append("sCompanyEName=@sCompanyEName,");
            strSql.Append("sCorporation=@sCorporation,");
            strSql.Append("sTel=@sTel,");
            strSql.Append("sFax=@sFax,");
            strSql.Append("sEmail=@sEmail,");
            strSql.Append("sHomepage=@sHomepage,");
            strSql.Append("sChnAddr=@sChnAddr,");
            strSql.Append("sEngAddr=@sEngAddr,");
            strSql.Append("sPostCode=@sPostCode,");
            strSql.Append("sTax=@sTax,");
            strSql.Append("sChnTitle=@sChnTitle,");
            strSql.Append("sEngTitle=@sEngTitle,");
            strSql.Append("sChnTitle2=@sChnTitle2,");
            strSql.Append("sEngTitle2=@sEngTitle2,");
            strSql.Append("mlogo=@mlogo,");
            strSql.Append("sRemark=@sRemark,");
            strSql.Append("dBillDate=@dBillDate,");
            strSql.Append("iFlag=@iFlag,");
            strSql.Append("sUserID=@sUserID");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@sCompanyID", SqlDbType.VarChar,20),
					new SqlParameter("@sCompanySName", SqlDbType.VarChar,50),
					new SqlParameter("@sCompanyCName", SqlDbType.VarChar,100),
					new SqlParameter("@sCompanyEName", SqlDbType.VarChar,100),
					new SqlParameter("@sCorporation", SqlDbType.VarChar,20),
					new SqlParameter("@sTel", SqlDbType.VarChar,50),
					new SqlParameter("@sFax", SqlDbType.VarChar,20),
					new SqlParameter("@sEmail", SqlDbType.VarChar,50),
					new SqlParameter("@sHomepage", SqlDbType.VarChar,50),
					new SqlParameter("@sChnAddr", SqlDbType.VarChar,100),
					new SqlParameter("@sEngAddr", SqlDbType.VarChar,150),
					new SqlParameter("@sPostCode", SqlDbType.VarChar,50),
					new SqlParameter("@sTax", SqlDbType.VarChar,50),
					new SqlParameter("@sChnTitle", SqlDbType.VarChar,100),
					new SqlParameter("@sEngTitle", SqlDbType.VarChar,150),
					new SqlParameter("@sChnTitle2", SqlDbType.VarChar,100),
					new SqlParameter("@sEngTitle2", SqlDbType.VarChar,150),
					new SqlParameter("@mlogo", SqlDbType.Image),
					new SqlParameter("@sRemark", SqlDbType.VarChar,100),
					new SqlParameter("@dBillDate", SqlDbType.DateTime),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,20)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["sCompanyID"];
            parameters[2].Value = dr["sCompanySName"];
            parameters[3].Value = dr["sCompanyCName"];
            parameters[4].Value = dr["sCompanyEName"];
            parameters[5].Value = dr["sCorporation"];
            parameters[6].Value = dr["sTel"];
            parameters[7].Value = dr["sFax"];
            parameters[8].Value = dr["sEmail"];
            parameters[9].Value = dr["sHomepage"];
            parameters[10].Value = dr["sChnAddr"];
            parameters[11].Value = dr["sEngAddr"];
            parameters[12].Value = dr["sPostCode"];
            parameters[13].Value = dr["sTax"];
            parameters[14].Value = dr["sChnTitle"];
            parameters[15].Value = dr["sEngTitle"];
            parameters[16].Value = dr["sChnTitle2"];
            parameters[17].Value = dr["sEngTitle2"];
            parameters[18].Value = dr["mlogo"];
            parameters[19].Value = dr["sRemark"];
            parameters[20].Value = dr["dBillDate"];
            parameters[21].Value = dr["iFlag"];
            parameters[22].Value = dr["sUserID"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM hrCompanyMaster ");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM hrCompanyMaster ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (Top > 0)
            {
                strSql.Append(" TOP " + Top.ToString());
            }
            strSql.Append(" * FROM hrCompanyMaster ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY  " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  成员方法
    }
}

