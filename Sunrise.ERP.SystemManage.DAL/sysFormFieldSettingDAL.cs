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
    /// 数据访问类sysFormFieldSettingDAL
    /// </summary>
    public class sysFormFieldSettingDAL
    {
        public sysFormFieldSettingDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM sysFormFieldSetting");
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
            strSql.Append("INSERT INTO sysFormFieldSetting(");
            strSql.Append("UserID,FormID,sTableName,sFieldName,bVisiable,bEdit,sUserID)");
            strSql.Append(" VALUES (");
            strSql.Append("@UserID,@FormID,@sTableName,@sFieldName,@bVisiable,@bEdit,@sUserID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,30),
					new SqlParameter("@FormID", SqlDbType.Int,4),
					new SqlParameter("@sTableName", SqlDbType.VarChar,100),
					new SqlParameter("@sFieldName", SqlDbType.VarChar,50),
					new SqlParameter("@bVisiable", SqlDbType.Bit,1),
					new SqlParameter("@bEdit", SqlDbType.Bit,1),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["UserID"];
            parameters[1].Value = dr["FormID"];
            parameters[2].Value = dr["sTableName"];
            parameters[3].Value = dr["sFieldName"];
            parameters[4].Value = dr["bVisiable"];
            parameters[5].Value = dr["bEdit"];
            parameters[6].Value = dr["sUserID"];

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
            strSql.Append("UPDATE sysFormFieldSetting SET ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("FormID=@FormID,");
            strSql.Append("sTableName=@sTableName,");
            strSql.Append("sFieldName=@sFieldName,");
            strSql.Append("bVisiable=@bVisiable,");
            strSql.Append("bEdit=@bEdit,");
            strSql.Append("sUserID=@sUserID");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.VarChar,30),
					new SqlParameter("@FormID", SqlDbType.Int,4),
					new SqlParameter("@sTableName", SqlDbType.VarChar,100),
					new SqlParameter("@sFieldName", SqlDbType.VarChar,50),
					new SqlParameter("@bVisiable", SqlDbType.Bit,1),
					new SqlParameter("@bEdit", SqlDbType.Bit,1),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["UserID"];
            parameters[2].Value = dr["FormID"];
            parameters[3].Value = dr["sTableName"];
            parameters[4].Value = dr["sFieldName"];
            parameters[5].Value = dr["bVisiable"];
            parameters[6].Value = dr["bEdit"];
            parameters[7].Value = dr["sUserID"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM sysFormFieldSetting ");
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
            strSql.Append(" FROM sysFormFieldSetting ");
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
            strSql.Append(" * FROM sysFormFieldSetting ");
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
