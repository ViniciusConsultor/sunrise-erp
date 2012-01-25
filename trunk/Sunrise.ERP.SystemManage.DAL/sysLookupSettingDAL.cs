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
    /// 数据访问类sysLookupSettingDAL
    /// </summary>
    public class sysLookupSettingDAL
    {
        public sysLookupSettingDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM sysLookupSetting");
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
            strSql.Append("INSERT INTO sysLookupSetting(");
            strSql.Append("sLookupNo,sType,sSQL,sDataField,sDisplayField,sGridDisplayField,sGridColumnText,sEnGridColumnText,sSearchFormText,sEnSearchFormText,sRemark,sUserID,iFlag)");
            strSql.Append(" VALUES (");
            strSql.Append("@sLookupNo,@sType,@sSQL,@sDataField,@sDisplayField,@sGridDisplayField,@sGridColumnText,@sEnGridColumnText,@sSearchFormText,@sEnSearchFormText,@sRemark,@sUserID,@iFlag)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sLookupNo", SqlDbType.VarChar,30),
					new SqlParameter("@sType", SqlDbType.VarChar,30),
					new SqlParameter("@sSQL", SqlDbType.VarChar,5000),
					new SqlParameter("@sDataField", SqlDbType.VarChar,50),
					new SqlParameter("@sDisplayField", SqlDbType.VarChar,50),
					new SqlParameter("@sGridDisplayField", SqlDbType.VarChar,1000),
					new SqlParameter("@sGridColumnText", SqlDbType.VarChar,1000),
					new SqlParameter("@sEnGridColumnText", SqlDbType.VarChar,1000),
					new SqlParameter("@sSearchFormText", SqlDbType.VarChar,50),
					new SqlParameter("@sEnSearchFormText", SqlDbType.VarChar,50),
					new SqlParameter("@sRemark", SqlDbType.VarChar,500),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30),
					new SqlParameter("@iFlag", SqlDbType.Int,4)};
            parameters[0].Value = dr["sLookupNo"];
            parameters[1].Value = dr["sType"];
            parameters[2].Value = dr["sSQL"];
            parameters[3].Value = dr["sDataField"];
            parameters[4].Value = dr["sDisplayField"];
            parameters[5].Value = dr["sGridDisplayField"];
            parameters[6].Value = dr["sGridColumnText"];
            parameters[7].Value = dr["sEnGridColumnText"];
            parameters[8].Value = dr["sSearchFormText"];
            parameters[9].Value = dr["sEnSearchFormText"];
            parameters[10].Value = dr["sRemark"];
            parameters[11].Value = dr["sUserID"];
            parameters[12].Value = dr["iFlag"];

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
            strSql.Append("UPDATE sysLookupSetting SET ");
            strSql.Append("sLookupNo=@sLookupNo,");
            strSql.Append("sType=@sType,");
            strSql.Append("sSQL=@sSQL,");
            strSql.Append("sDataField=@sDataField,");
            strSql.Append("sDisplayField=@sDisplayField,");
            strSql.Append("sGridDisplayField=@sGridDisplayField,");
            strSql.Append("sGridColumnText=@sGridColumnText,");
            strSql.Append("sEnGridColumnText=@sEnGridColumnText,");
            strSql.Append("sSearchFormText=@sSearchFormText,");
            strSql.Append("sEnSearchFormText=@sEnSearchFormText,");
            strSql.Append("sRemark=@sRemark,");
            strSql.Append("sUserID=@sUserID,");
            strSql.Append("iFlag=@iFlag");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@sLookupNo", SqlDbType.VarChar,30),
					new SqlParameter("@sType", SqlDbType.VarChar,30),
					new SqlParameter("@sSQL", SqlDbType.VarChar,5000),
					new SqlParameter("@sDataField", SqlDbType.VarChar,50),
					new SqlParameter("@sDisplayField", SqlDbType.VarChar,50),
					new SqlParameter("@sGridDisplayField", SqlDbType.VarChar,1000),
					new SqlParameter("@sGridColumnText", SqlDbType.VarChar,1000),
					new SqlParameter("@sEnGridColumnText", SqlDbType.VarChar,1000),
					new SqlParameter("@sSearchFormText", SqlDbType.VarChar,50),
					new SqlParameter("@sEnSearchFormText", SqlDbType.VarChar,50),
					new SqlParameter("@sRemark", SqlDbType.VarChar,500),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30),
					new SqlParameter("@iFlag", SqlDbType.Int,4)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["sLookupNo"];
            parameters[2].Value = dr["sType"];
            parameters[3].Value = dr["sSQL"];
            parameters[4].Value = dr["sDataField"];
            parameters[5].Value = dr["sDisplayField"];
            parameters[6].Value = dr["sGridDisplayField"];
            parameters[7].Value = dr["sGridColumnText"];
            parameters[8].Value = dr["sEnGridColumnText"];
            parameters[9].Value = dr["sSearchFormText"];
            parameters[10].Value = dr["sEnSearchFormText"];
            parameters[11].Value = dr["sRemark"];
            parameters[12].Value = dr["sUserID"];
            parameters[13].Value = dr["iFlag"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM sysLookupSetting ");
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
            strSql.Append(" FROM sysLookupSetting ");
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
            strSql.Append(" * FROM sysLookupSetting ");
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

