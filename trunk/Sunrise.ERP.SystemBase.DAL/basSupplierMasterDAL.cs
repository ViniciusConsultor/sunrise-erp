//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.DAL
//Description:      basSupplierMasterDAL
//Create by:        自动生成
//Create Date:      2010-12-12 23:40:56
//Modify by：              Modify Date：               Description：
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sunrise.ERP.DataAccess;
namespace Sunrise.ERP.SystemBase.DAL
{
    /// <summary>
    /// 数据访问类basSupplierMasterDAL
    /// </summary>
    public class basSupplierMasterDAL
    {
        public basSupplierMasterDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM basSupplierMaster");
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
            strSql.Append("INSERT INTO basSupplierMaster(");
            strSql.Append("sSupplierID,sSupplierSName,sSupplierCName,sSupplierEName,sSupplierTypeID,sTel,sFax,sSupplierCEOName,sSupplierCEOMobile,sContactMan,sContactMobile,sEmail,sHomePage,sChnAddr,sEngAddr,sPostCode,sTax,sBankName,sBankAdrr,sBankAccount,sBusinessMan,sRemark,iFlag,sUserID)");
            strSql.Append(" VALUES (");
            strSql.Append("@sSupplierID,@sSupplierSName,@sSupplierCName,@sSupplierEName,@sSupplierTypeID,@sTel,@sFax,@sSupplierCEOName,@sSupplierCEOMobile,@sContactMan,@sContactMobile,@sEmail,@sHomePage,@sChnAddr,@sEngAddr,@sPostCode,@sTax,@sBankName,@sBankAdrr,@sBankAccount,@sBusinessMan,@sRemark,@iFlag,@sUserID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sSupplierID", SqlDbType.VarChar,20),
					new SqlParameter("@sSupplierSName", SqlDbType.VarChar,200),
					new SqlParameter("@sSupplierCName", SqlDbType.VarChar,200),
					new SqlParameter("@sSupplierEName", SqlDbType.VarChar,200),
					new SqlParameter("@sSupplierTypeID", SqlDbType.VarChar,20),
					new SqlParameter("@sTel", SqlDbType.VarChar,30),
					new SqlParameter("@sFax", SqlDbType.VarChar,30),
					new SqlParameter("@sSupplierCEOName", SqlDbType.VarChar,20),
					new SqlParameter("@sSupplierCEOMobile", SqlDbType.VarChar,20),
					new SqlParameter("@sContactMan", SqlDbType.VarChar,20),
					new SqlParameter("@sContactMobile", SqlDbType.VarChar,20),
					new SqlParameter("@sEmail", SqlDbType.VarChar,50),
					new SqlParameter("@sHomePage", SqlDbType.VarChar,50),
					new SqlParameter("@sChnAddr", SqlDbType.VarChar,200),
					new SqlParameter("@sEngAddr", SqlDbType.VarChar,200),
					new SqlParameter("@sPostCode", SqlDbType.VarChar,10),
					new SqlParameter("@sTax", SqlDbType.VarChar,200),
					new SqlParameter("@sBankName", SqlDbType.VarChar,200),
					new SqlParameter("@sBankAdrr", SqlDbType.VarChar,200),
					new SqlParameter("@sBankAccount", SqlDbType.VarChar,200),
					new SqlParameter("@sBusinessMan", SqlDbType.VarChar,20),
					new SqlParameter("@sRemark", SqlDbType.VarChar,500),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,20)};
            parameters[0].Value = dr["sSupplierID"];
            parameters[1].Value = dr["sSupplierSName"];
            parameters[2].Value = dr["sSupplierCName"];
            parameters[3].Value = dr["sSupplierEName"];
            parameters[4].Value = dr["sSupplierTypeID"];
            parameters[5].Value = dr["sTel"];
            parameters[6].Value = dr["sFax"];
            parameters[7].Value = dr["sSupplierCEOName"];
            parameters[8].Value = dr["sSupplierCEOMobile"];
            parameters[9].Value = dr["sContactMan"];
            parameters[10].Value = dr["sContactMobile"];
            parameters[11].Value = dr["sEmail"];
            parameters[12].Value = dr["sHomePage"];
            parameters[13].Value = dr["sChnAddr"];
            parameters[14].Value = dr["sEngAddr"];
            parameters[15].Value = dr["sPostCode"];
            parameters[16].Value = dr["sTax"];
            parameters[17].Value = dr["sBankName"];
            parameters[18].Value = dr["sBankAdrr"];
            parameters[19].Value = dr["sBankAccount"];
            parameters[20].Value = dr["sBusinessMan"];
            parameters[21].Value = dr["sRemark"];
            parameters[22].Value = dr["iFlag"];
            parameters[23].Value = dr["sUserID"];

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
            strSql.Append("UPDATE basSupplierMaster SET ");
            strSql.Append("sSupplierID=@sSupplierID,");
            strSql.Append("sSupplierSName=@sSupplierSName,");
            strSql.Append("sSupplierCName=@sSupplierCName,");
            strSql.Append("sSupplierEName=@sSupplierEName,");
            strSql.Append("sSupplierTypeID=@sSupplierTypeID,");
            strSql.Append("sTel=@sTel,");
            strSql.Append("sFax=@sFax,");
            strSql.Append("sSupplierCEOName=@sSupplierCEOName,");
            strSql.Append("sSupplierCEOMobile=@sSupplierCEOMobile,");
            strSql.Append("sContactMan=@sContactMan,");
            strSql.Append("sContactMobile=@sContactMobile,");
            strSql.Append("sEmail=@sEmail,");
            strSql.Append("sHomePage=@sHomePage,");
            strSql.Append("sChnAddr=@sChnAddr,");
            strSql.Append("sEngAddr=@sEngAddr,");
            strSql.Append("sPostCode=@sPostCode,");
            strSql.Append("sTax=@sTax,");
            strSql.Append("sBankName=@sBankName,");
            strSql.Append("sBankAdrr=@sBankAdrr,");
            strSql.Append("sBankAccount=@sBankAccount,");
            strSql.Append("sBusinessMan=@sBusinessMan,");
            strSql.Append("sRemark=@sRemark,");
            strSql.Append("iFlag=@iFlag,");
            strSql.Append("sUserID=@sUserID");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@sSupplierID", SqlDbType.VarChar,20),
					new SqlParameter("@sSupplierSName", SqlDbType.VarChar,200),
					new SqlParameter("@sSupplierCName", SqlDbType.VarChar,200),
					new SqlParameter("@sSupplierEName", SqlDbType.VarChar,200),
					new SqlParameter("@sSupplierTypeID", SqlDbType.VarChar,20),
					new SqlParameter("@sTel", SqlDbType.VarChar,30),
					new SqlParameter("@sFax", SqlDbType.VarChar,30),
					new SqlParameter("@sSupplierCEOName", SqlDbType.VarChar,20),
					new SqlParameter("@sSupplierCEOMobile", SqlDbType.VarChar,20),
					new SqlParameter("@sContactMan", SqlDbType.VarChar,20),
					new SqlParameter("@sContactMobile", SqlDbType.VarChar,20),
					new SqlParameter("@sEmail", SqlDbType.VarChar,50),
					new SqlParameter("@sHomePage", SqlDbType.VarChar,50),
					new SqlParameter("@sChnAddr", SqlDbType.VarChar,200),
					new SqlParameter("@sEngAddr", SqlDbType.VarChar,200),
					new SqlParameter("@sPostCode", SqlDbType.VarChar,10),
					new SqlParameter("@sTax", SqlDbType.VarChar,200),
					new SqlParameter("@sBankName", SqlDbType.VarChar,200),
					new SqlParameter("@sBankAdrr", SqlDbType.VarChar,200),
					new SqlParameter("@sBankAccount", SqlDbType.VarChar,200),
					new SqlParameter("@sBusinessMan", SqlDbType.VarChar,20),
					new SqlParameter("@sRemark", SqlDbType.VarChar,500),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,20)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["sSupplierID"];
            parameters[2].Value = dr["sSupplierSName"];
            parameters[3].Value = dr["sSupplierCName"];
            parameters[4].Value = dr["sSupplierEName"];
            parameters[5].Value = dr["sSupplierTypeID"];
            parameters[6].Value = dr["sTel"];
            parameters[7].Value = dr["sFax"];
            parameters[8].Value = dr["sSupplierCEOName"];
            parameters[9].Value = dr["sSupplierCEOMobile"];
            parameters[10].Value = dr["sContactMan"];
            parameters[11].Value = dr["sContactMobile"];
            parameters[12].Value = dr["sEmail"];
            parameters[13].Value = dr["sHomePage"];
            parameters[14].Value = dr["sChnAddr"];
            parameters[15].Value = dr["sEngAddr"];
            parameters[16].Value = dr["sPostCode"];
            parameters[17].Value = dr["sTax"];
            parameters[18].Value = dr["sBankName"];
            parameters[19].Value = dr["sBankAdrr"];
            parameters[20].Value = dr["sBankAccount"];
            parameters[21].Value = dr["sBusinessMan"];
            parameters[22].Value = dr["sRemark"];
            parameters[23].Value = dr["iFlag"];
            parameters[24].Value = dr["sUserID"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM basSupplierMaster ");
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
            strSql.Append(" FROM vwbasSupplierMaster ");
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
            strSql.Append(" * FROM vwbasSupplierMaster ");
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

