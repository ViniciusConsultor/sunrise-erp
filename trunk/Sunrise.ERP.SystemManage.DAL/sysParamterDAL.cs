using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sunrise.ERP.DataAccess;
namespace Sunrise.ERP.SystemManage.DAL
{
    /// <summary>
    /// 数据访问类sysParamterDAL
    /// </summary>
    public class sysParamterDAL
    {
        public sysParamterDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM sysParamter");
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
            strSql.Append("INSERT INTO sysParamter(");
            strSql.Append("sSysParamNo,sSysParamValue,sRemark,sUserID,bActive,iFlag)");
            strSql.Append(" VALUES (");
            strSql.Append("@sSysParamNo,@sSysParamValue,@sRemark,@sUserID,@bActive,@iFlag)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sSysParamNo", SqlDbType.VarChar,30),
					new SqlParameter("@sSysParamValue", SqlDbType.VarChar,500),
					new SqlParameter("@sRemark", SqlDbType.VarChar,1000),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30),
					new SqlParameter("@bActive", SqlDbType.Bit,1),
					new SqlParameter("@iFlag", SqlDbType.Int,4)};
            parameters[0].Value = dr["sSysParamNo"];
            parameters[1].Value = dr["sSysParamValue"];
            parameters[2].Value = dr["sRemark"];
            parameters[3].Value = dr["sUserID"];
            parameters[4].Value = dr["bActive"];
            parameters[5].Value = dr["iFlag"];

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
            strSql.Append("UPDATE sysParamter SET ");
            strSql.Append("sSysParamNo=@sSysParamNo,");
            strSql.Append("sSysParamValue=@sSysParamValue,");
            strSql.Append("sRemark=@sRemark,");
            strSql.Append("sUserID=@sUserID,");
            strSql.Append("bActive=@bActive,");
            strSql.Append("iFlag=@iFlag");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@sSysParamNo", SqlDbType.VarChar,30),
					new SqlParameter("@sSysParamValue", SqlDbType.VarChar,500),
					new SqlParameter("@sRemark", SqlDbType.VarChar,1000),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30),
					new SqlParameter("@bActive", SqlDbType.Bit,1),
					new SqlParameter("@iFlag", SqlDbType.Int,4)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["sSysParamNo"];
            parameters[2].Value = dr["sSysParamValue"];
            parameters[3].Value = dr["sRemark"];
            parameters[4].Value = dr["sUserID"];
            parameters[5].Value = dr["bActive"];
            parameters[6].Value = dr["iFlag"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM sysParamter ");
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
            strSql.Append(" FROM sysParamter ");
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
            strSql.Append(" * FROM sysParamter ");
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

