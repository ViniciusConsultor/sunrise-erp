using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Sunrise.ERP.DataAccess;
using Sunrise.ERP.BaseForm.DAL;
using Sunrise.ERP.BaseControl;


namespace Sunrise.ERP.BaseForm.DAL
{
    /// <summary>
    /// 数据访问类sysIPLogDAL
    /// </summary>
    public class sysIPLogDAL
    {
        public sysIPLogDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM sysIPLog");
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
            strSql.Append("INSERT INTO sysIPLog(");
            strSql.Append("sUserID,sLoginIP,sLoginMachine,dLoginDate,dLogoutDate)");
            strSql.Append(" VALUES (");
            strSql.Append("@sUserID,@sLoginIP,@sLoginMachine,@dLoginDate,@dLogoutDate)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sUserID", SqlDbType.VarChar,30),
					new SqlParameter("@sLoginIP", SqlDbType.VarChar,15),
					new SqlParameter("@sLoginMachine", SqlDbType.VarChar,50),
					new SqlParameter("@dLoginDate", SqlDbType.DateTime),
					new SqlParameter("@dLogoutDate", SqlDbType.DateTime)};
            parameters[0].Value = dr["sUserID"];
            parameters[1].Value = dr["sLoginIP"];
            parameters[2].Value = dr["sLoginMachine"];
            parameters[3].Value = dr["dLoginDate"];
            parameters[4].Value = dr["dLogoutDate"];

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
            strSql.Append("UPDATE sysIPLog SET ");
            strSql.Append("sUserID=@sUserID,");
            strSql.Append("sLoginIP=@sLoginIP,");
            strSql.Append("sLoginMachine=@sLoginMachine,");
            strSql.Append("dLoginDate=@dLoginDate,");
            strSql.Append("dLogoutDate=@dLogoutDate");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30),
					new SqlParameter("@sLoginIP", SqlDbType.VarChar,15),
					new SqlParameter("@sLoginMachine", SqlDbType.VarChar,50),
					new SqlParameter("@dLoginDate", SqlDbType.DateTime),
					new SqlParameter("@dLogoutDate", SqlDbType.DateTime)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["sUserID"];
            parameters[2].Value = dr["sLoginIP"];
            parameters[3].Value = dr["sLoginMachine"];
            parameters[4].Value = dr["dLoginDate"];
            parameters[5].Value = dr["dLogoutDate"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM sysIPLog ");
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
            strSql.Append(" FROM sysIPLog ");
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
            strSql.Append(" * FROM sysIPLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY  " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public static int AddLogIP(string userid)
        {
            int result = -1;
            SqlTransaction trans = ConnectSetting.SysSqlConnection.BeginTransaction();
            try
            {
                

            }
            catch
            {
            }
            return result;
        }

        #endregion  成员方法


    }
}
