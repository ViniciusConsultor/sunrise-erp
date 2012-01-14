//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.DAL
//Description:      hrCompanyDetailDAL
//Create by:        自动生成
//Create Date:      2010-11-14 15:01:54
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
    /// 数据访问类hrCompanyDetailDAL
    /// </summary>
    public class hrCompanyDetailDAL
    {
        public hrCompanyDetailDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM hrCompanyDetail");
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
            strSql.Append("INSERT INTO hrCompanyDetail(");
            strSql.Append("MainID,sCurrency,sBankName,sBankAccount,sBankAddr,sRemark,iFlag,sUserID)");
            strSql.Append(" VALUES (");
            strSql.Append("@MainID,@sCurrency,@sBankName,@sBankAccount,@sBankAddr,@sRemark,@iFlag,@sUserID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MainID", SqlDbType.Int,4),
					new SqlParameter("@sCurrency", SqlDbType.VarChar,20),
					new SqlParameter("@sBankName", SqlDbType.VarChar,100),
					new SqlParameter("@sBankAccount", SqlDbType.VarChar,40),
					new SqlParameter("@sBankAddr", SqlDbType.VarChar,100),
					new SqlParameter("@sRemark", SqlDbType.VarChar,100),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,20)};
            parameters[0].Value = dr["MainID"];
            parameters[1].Value = dr["sCurrency"];
            parameters[2].Value = dr["sBankName"];
            parameters[3].Value = dr["sBankAccount"];
            parameters[4].Value = dr["sBankAddr"];
            parameters[5].Value = dr["sRemark"];
            parameters[6].Value = dr["iFlag"];
            parameters[7].Value = dr["sUserID"];

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
            strSql.Append("UPDATE hrCompanyDetail SET ");
            strSql.Append("MainID=@MainID,");
            strSql.Append("sCurrency=@sCurrency,");
            strSql.Append("sBankName=@sBankName,");
            strSql.Append("sBankAccount=@sBankAccount,");
            strSql.Append("sBankAddr=@sBankAddr,");
            strSql.Append("sRemark=@sRemark,");
            strSql.Append("iFlag=@iFlag,");
            strSql.Append("sUserID=@sUserID");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@MainID", SqlDbType.Int,4),
					new SqlParameter("@sCurrency", SqlDbType.VarChar,20),
					new SqlParameter("@sBankName", SqlDbType.VarChar,100),
					new SqlParameter("@sBankAccount", SqlDbType.VarChar,40),
					new SqlParameter("@sBankAddr", SqlDbType.VarChar,100),
					new SqlParameter("@sRemark", SqlDbType.VarChar,100),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,20)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["MainID"];
            parameters[2].Value = dr["sCurrency"];
            parameters[3].Value = dr["sBankName"];
            parameters[4].Value = dr["sBankAccount"];
            parameters[5].Value = dr["sBankAddr"];
            parameters[6].Value = dr["sRemark"];
            parameters[7].Value = dr["iFlag"];
            parameters[8].Value = dr["sUserID"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM hrCompanyDetail ");
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
            strSql.Append(" FROM vwhrCompanyDetail ");
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
            strSql.Append(" * FROM vwhrCompanyDetail ");
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

