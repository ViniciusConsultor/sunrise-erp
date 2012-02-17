//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.DAL
//Description:      sysQueryReportDetailDAL
//Create by:        自动生成
//Create Date:      2011-2-27 16:29:18
//Modify by：              Modify Date：               Description：
//-------------------------------------------------------------------------------------------
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
    /// 数据访问类sysQueryReportDetailDAL
    /// </summary>
    public class sysQueryReportDetailDAL
    {
        public sysQueryReportDetailDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM sysQueryReportDetail");
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
            strSql.Append("INSERT INTO sysQueryReportDetail(");
            strSql.Append("MainID,iSort,sColumnFieldName,sColumnCaption,sColumnType,bIsQuery,bIsShow,bChartField,bChartValue,sSearchType,sDefaultValue,sReturnValue,bIsGroup,sFooterType,bIsStat,iFormID,sUserID)");
            strSql.Append(" VALUES (");
            strSql.Append("@MainID,@iSort,@sColumnFieldName,@sColumnCaption,@sColumnType,@bIsQuery,@bIsShow,@bChartField,@bChartValue,@sSearchType,@sDefaultValue,@sReturnValue,@bIsGroup,@sFooterType,@bIsStat,@iFormID,@sUserID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MainID", SqlDbType.Int,4),
					new SqlParameter("@iSort", SqlDbType.Int,4),
					new SqlParameter("@sColumnFieldName", SqlDbType.VarChar,30),
					new SqlParameter("@sColumnCaption", SqlDbType.VarChar,30),
					new SqlParameter("@sColumnType", SqlDbType.VarChar,5),
					new SqlParameter("@bIsQuery", SqlDbType.Bit,1),
					new SqlParameter("@bIsShow", SqlDbType.Bit,1),
					new SqlParameter("@bChartField", SqlDbType.Bit,1),
					new SqlParameter("@bChartValue", SqlDbType.Bit,1),
					new SqlParameter("@sSearchType", SqlDbType.VarChar,30),
					new SqlParameter("@sDefaultValue", SqlDbType.VarChar,1000),
					new SqlParameter("@sReturnValue", SqlDbType.VarChar,1000),
					new SqlParameter("@bIsGroup", SqlDbType.Bit,1),
					new SqlParameter("@sFooterType", SqlDbType.VarChar,30),
					new SqlParameter("@bIsStat", SqlDbType.Bit,1),
					new SqlParameter("@iFormID", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["MainID"];
            parameters[1].Value = dr["iSort"];
            parameters[2].Value = dr["sColumnFieldName"];
            parameters[3].Value = dr["sColumnCaption"];
            parameters[4].Value = dr["sColumnType"];
            parameters[5].Value = dr["bIsQuery"];
            parameters[6].Value = dr["bIsShow"];
            parameters[7].Value = dr["bChartField"];
            parameters[8].Value = dr["bChartValue"];
            parameters[9].Value = dr["sSearchType"];
            parameters[10].Value = dr["sDefaultValue"];
            parameters[11].Value = dr["sReturnValue"];
            parameters[12].Value = dr["bIsGroup"];
            parameters[13].Value = dr["sFooterType"];
            parameters[14].Value = dr["bIsStat"];
            parameters[15].Value = dr["iFormID"];
            parameters[16].Value = dr["sUserID"];

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
            strSql.Append("UPDATE sysQueryReportDetail SET ");
            strSql.Append("MainID=@MainID,");
            strSql.Append("iSort=@iSort,");
            strSql.Append("sColumnFieldName=@sColumnFieldName,");
            strSql.Append("sColumnCaption=@sColumnCaption,");
            strSql.Append("sColumnType=@sColumnType,");
            strSql.Append("bIsQuery=@bIsQuery,");
            strSql.Append("bIsShow=@bIsShow,");
            strSql.Append("bChartField=@bChartField,");
            strSql.Append("bChartValue=@bChartValue,");
            strSql.Append("sSearchType=@sSearchType,");
            strSql.Append("sDefaultValue=@sDefaultValue,");
            strSql.Append("sReturnValue=@sReturnValue,");
            strSql.Append("bIsGroup=@bIsGroup,");
            strSql.Append("sFooterType=@sFooterType,");
            strSql.Append("bIsStat=@bIsStat,");
            strSql.Append("iFormID=@iFormID,");
            strSql.Append("sUserID=@sUserID");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@MainID", SqlDbType.Int,4),
					new SqlParameter("@iSort", SqlDbType.Int,4),
					new SqlParameter("@sColumnFieldName", SqlDbType.VarChar,30),
					new SqlParameter("@sColumnCaption", SqlDbType.VarChar,30),
					new SqlParameter("@sColumnType", SqlDbType.VarChar,5),
					new SqlParameter("@bIsQuery", SqlDbType.Bit,1),
					new SqlParameter("@bIsShow", SqlDbType.Bit,1),
					new SqlParameter("@bChartField", SqlDbType.Bit,1),
					new SqlParameter("@bChartValue", SqlDbType.Bit,1),
					new SqlParameter("@sSearchType", SqlDbType.VarChar,30),
					new SqlParameter("@sDefaultValue", SqlDbType.VarChar,1000),
					new SqlParameter("@sReturnValue", SqlDbType.VarChar,1000),
					new SqlParameter("@bIsGroup", SqlDbType.Bit,1),
					new SqlParameter("@sFooterType", SqlDbType.VarChar,30),
					new SqlParameter("@bIsStat", SqlDbType.Bit,1),
					new SqlParameter("@iFormID", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["MainID"];
            parameters[2].Value = dr["iSort"];
            parameters[3].Value = dr["sColumnFieldName"];
            parameters[4].Value = dr["sColumnCaption"];
            parameters[5].Value = dr["sColumnType"];
            parameters[6].Value = dr["bIsQuery"];
            parameters[7].Value = dr["bIsShow"];
            parameters[8].Value = dr["bChartField"];
            parameters[9].Value = dr["bChartValue"];
            parameters[10].Value = dr["sSearchType"];
            parameters[11].Value = dr["sDefaultValue"];
            parameters[12].Value = dr["sReturnValue"];
            parameters[13].Value = dr["bIsGroup"];
            parameters[14].Value = dr["sFooterType"];
            parameters[15].Value = dr["bIsStat"];
            parameters[16].Value = dr["iFormID"];
            parameters[17].Value = dr["sUserID"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM sysQueryReportDetail ");
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
            strSql.Append(" FROM vwsysQueryReportDetail ");
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
            strSql.Append(" * FROM vwsysQueryReportDetail ");
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

