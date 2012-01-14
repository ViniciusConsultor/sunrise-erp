//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.DAL
//Description:      sysBillNoSetDAL
//Create by:        自动生成
//Create Date:      2010-11-21 17:42:41
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
    /// 数据访问类sysBillNoSetDAL
    /// </summary>
    public class sysBillNoSetDAL
    {
        public sysBillNoSetDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM sysBillNoSet");
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
            strSql.Append("INSERT INTO sysBillNoSet(");
            strSql.Append("iFormID,sTableName,sFieldName,sDateType,sPrefix,sSerialType,iFlag,sUserID)");
            strSql.Append(" VALUES (");
            strSql.Append("@iFormID,@sTableName,@sFieldName,@sDateType,@sPrefix,@sSerialType,@iFlag,@sUserID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@iFormID", SqlDbType.Int,4),
					new SqlParameter("@sTableName", SqlDbType.VarChar,100),
					new SqlParameter("@sFieldName", SqlDbType.VarChar,100),
					new SqlParameter("@sDateType", SqlDbType.VarChar,50),
					new SqlParameter("@sPrefix", SqlDbType.VarChar,50),
					new SqlParameter("@sSerialType", SqlDbType.VarChar,50),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["iFormID"];
            parameters[1].Value = dr["sTableName"];
            parameters[2].Value = dr["sFieldName"];
            parameters[3].Value = dr["sDateType"];
            parameters[4].Value = dr["sPrefix"];
            parameters[5].Value = dr["sSerialType"];
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
            strSql.Append("UPDATE sysBillNoSet SET ");
            strSql.Append("iFormID=@iFormID,");
            strSql.Append("sTableName=@sTableName,");
            strSql.Append("sFieldName=@sFieldName,");
            strSql.Append("sDateType=@sDateType,");
            strSql.Append("sPrefix=@sPrefix,");
            strSql.Append("sSerialType=@sSerialType,");
            strSql.Append("iFlag=@iFlag,");
            strSql.Append("sUserID=@sUserID");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@iFormID", SqlDbType.Int,4),
					new SqlParameter("@sTableName", SqlDbType.VarChar,100),
					new SqlParameter("@sFieldName", SqlDbType.VarChar,100),
					new SqlParameter("@sDateType", SqlDbType.VarChar,50),
					new SqlParameter("@sPrefix", SqlDbType.VarChar,50),
					new SqlParameter("@sSerialType", SqlDbType.VarChar,50),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["iFormID"];
            parameters[2].Value = dr["sTableName"];
            parameters[3].Value = dr["sFieldName"];
            parameters[4].Value = dr["sDateType"];
            parameters[5].Value = dr["sPrefix"];
            parameters[6].Value = dr["sSerialType"];
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
            strSql.Append("DELETE FROM sysBillNoSet ");
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
            strSql.Append(" FROM vwsysBillNoSet ");
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
            strSql.Append(" * FROM vwsysBillNoSet ");
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

