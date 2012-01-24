using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sunrise.ERP.DataAccess;
namespace Sunrise.ERP.BaseForm.DAL
{
    /// <summary>
    /// 数据访问类sysDynamicFormMasterDAL
    /// </summary>
    public class sysDynamicFormMasterDAL
    {
        public sysDynamicFormMasterDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM sysDynamicFormMaster");
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
            strSql.Append("INSERT INTO sysDynamicFormMaster(");
            strSql.Append("FormID,sFormType,iDefaultQueryCount,iControlSpace,iControlColumn,bCreateLookUp,bSyncLookUp,sTableName,sQueryViewName,iFlag,sUserID)");
            strSql.Append(" VALUES (");
            strSql.Append("@FormID,@sFormType,@iDefaultQueryCount,@iControlSpace,@iControlColumn,@bCreateLookUp,@bSyncLookUp,@sTableName,@sQueryViewName,@iFlag,@sUserID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FormID", SqlDbType.Int,4),
					new SqlParameter("@sFormType", SqlDbType.VarChar,30),
					new SqlParameter("@iDefaultQueryCount", SqlDbType.Int,4),
					new SqlParameter("@iControlSpace", SqlDbType.Int,4),
					new SqlParameter("@iControlColumn", SqlDbType.Int,4),
					new SqlParameter("@bCreateLookUp", SqlDbType.Bit,1),
					new SqlParameter("@bSyncLookUp", SqlDbType.Bit,1),
					new SqlParameter("@sTableName", SqlDbType.VarChar,50),
					new SqlParameter("@sQueryViewName", SqlDbType.VarChar,50),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["FormID"];
            parameters[1].Value = dr["sFormType"];
            parameters[2].Value = dr["iDefaultQueryCount"];
            parameters[3].Value = dr["iControlSpace"];
            parameters[4].Value = dr["iControlColumn"];
            parameters[5].Value = dr["bCreateLookUp"];
            parameters[6].Value = dr["bSyncLookUp"];
            parameters[7].Value = dr["sTableName"];
            parameters[8].Value = dr["sQueryViewName"];
            parameters[9].Value = dr["iFlag"];
            parameters[10].Value = dr["sUserID"];

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
            strSql.Append("UPDATE sysDynamicFormMaster SET ");
            strSql.Append("FormID=@FormID,");
            strSql.Append("sFormType=@sFormType,");
            strSql.Append("iDefaultQueryCount=@iDefaultQueryCount,");
            strSql.Append("iControlSpace=@iControlSpace,");
            strSql.Append("iControlColumn=@iControlColumn,");
            strSql.Append("bCreateLookUp=@bCreateLookUp,");
            strSql.Append("bSyncLookUp=@bSyncLookUp,");
            strSql.Append("sTableName=@sTableName,");
            strSql.Append("sQueryViewName=@sQueryViewName,");
            strSql.Append("iFlag=@iFlag,");
            strSql.Append("sUserID=@sUserID");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@FormID", SqlDbType.Int,4),
					new SqlParameter("@sFormType", SqlDbType.VarChar,30),
					new SqlParameter("@iDefaultQueryCount", SqlDbType.Int,4),
					new SqlParameter("@iControlSpace", SqlDbType.Int,4),
					new SqlParameter("@iControlColumn", SqlDbType.Int,4),
					new SqlParameter("@bCreateLookUp", SqlDbType.Bit,1),
					new SqlParameter("@bSyncLookUp", SqlDbType.Bit,1),
					new SqlParameter("@sTableName", SqlDbType.VarChar,50),
					new SqlParameter("@sQueryViewName", SqlDbType.VarChar,50),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["FormID"];
            parameters[2].Value = dr["sFormType"];
            parameters[3].Value = dr["iDefaultQueryCount"];
            parameters[4].Value = dr["iControlSpace"];
            parameters[5].Value = dr["iControlColumn"];
            parameters[6].Value = dr["bCreateLookUp"];
            parameters[7].Value = dr["bSyncLookUp"];
            parameters[8].Value = dr["sTableName"];
            parameters[9].Value = dr["sQueryViewName"];
            parameters[10].Value = dr["iFlag"];
            parameters[11].Value = dr["sUserID"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM sysDynamicFormMaster ");
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
            strSql.Append(" FROM vwsysDynamicFormMaster ");
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
            strSql.Append(" * FROM vwsysDynamicFormMaster ");
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

