//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.DAL
//Description:      basDataDictMasterDAL
//Create by:        自动生成
//Create Date:      2010-11-14 14:57:02
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
    /// 数据访问类basDataDictMasterDAL
    /// </summary>
    public class basDataDictMasterDAL
    {
        public basDataDictMasterDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM basDataDictMaster");
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
            strSql.Append("INSERT INTO basDataDictMaster(");
            strSql.Append("sDictCategoryNo,sDictCategoryCName,sDictCategoryEName,sRemark,iFlag,sUserID)");
            strSql.Append(" VALUES (");
            strSql.Append("@sDictCategoryNo,@sDictCategoryCName,@sDictCategoryEName,@sRemark,@iFlag,@sUserID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sDictCategoryNo", SqlDbType.VarChar,30),
					new SqlParameter("@sDictCategoryCName", SqlDbType.VarChar,50),
					new SqlParameter("@sDictCategoryEName", SqlDbType.VarChar,50),
					new SqlParameter("@sRemark", SqlDbType.VarChar,200),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,20)};
            parameters[0].Value = dr["sDictCategoryNo"];
            parameters[1].Value = dr["sDictCategoryCName"];
            parameters[2].Value = dr["sDictCategoryEName"];
            parameters[3].Value = dr["sRemark"];
            parameters[4].Value = dr["iFlag"];
            parameters[5].Value = dr["sUserID"];

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
            strSql.Append("UPDATE basDataDictMaster SET ");
            strSql.Append("sDictCategoryNo=@sDictCategoryNo,");
            strSql.Append("sDictCategoryCName=@sDictCategoryCName,");
            strSql.Append("sDictCategoryEName=@sDictCategoryEName,");
            strSql.Append("sRemark=@sRemark,");
            strSql.Append("iFlag=@iFlag,");
            strSql.Append("sUserID=@sUserID");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@sDictCategoryNo", SqlDbType.VarChar,30),
					new SqlParameter("@sDictCategoryCName", SqlDbType.VarChar,50),
					new SqlParameter("@sDictCategoryEName", SqlDbType.VarChar,50),
					new SqlParameter("@sRemark", SqlDbType.VarChar,200),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,20)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["sDictCategoryNo"];
            parameters[2].Value = dr["sDictCategoryCName"];
            parameters[3].Value = dr["sDictCategoryEName"];
            parameters[4].Value = dr["sRemark"];
            parameters[5].Value = dr["iFlag"];
            parameters[6].Value = dr["sUserID"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM basDataDictMaster ");
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
            strSql.Append(" FROM basDataDictMaster ");
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
            strSql.Append(" * FROM basDataDictMaster ");
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

