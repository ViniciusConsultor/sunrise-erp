//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.DAL
//Description:      sysQueryReportMasterDAL
//Create by:        自动生成
//Create Date:      2011-2-27 22:35:10
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
    /// 数据访问类sysQueryReportMasterDAL
    /// </summary>
    public class sysQueryReportMasterDAL
    {
        public sysQueryReportMasterDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM sysQueryReportMaster");
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
            strSql.Append("INSERT INTO sysQueryReportMaster(");
            strSql.Append("sReportNo,sReportName,sReportSQL,iControlSpace,iControlColumn,bIsShowPrintBtn,bIsShowExecBtn,bIsChart,sExecBtnText,sExecSQL,sDealFields,sSortFields,iFlag,sUserID,bIsAutoRun)");
            strSql.Append(" VALUES (");
            strSql.Append("@sReportNo,@sReportName,@sReportSQL,@iControlSpace,@iControlColumn,@bIsShowPrintBtn,@bIsShowExecBtn,@bIsChart,@sExecBtnText,@sExecSQL,@sDealFields,@sSortFields,@iFlag,@sUserID,@bIsAutoRun)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sReportNo", SqlDbType.VarChar,30),
					new SqlParameter("@sReportName", SqlDbType.VarChar,30),
					new SqlParameter("@sReportSQL", SqlDbType.VarChar,5000),
					new SqlParameter("@iControlSpace", SqlDbType.Int,4),
					new SqlParameter("@iControlColumn", SqlDbType.Int,4),
					new SqlParameter("@bIsShowPrintBtn", SqlDbType.Bit,1),
					new SqlParameter("@bIsShowExecBtn", SqlDbType.Bit,1),
					new SqlParameter("@bIsChart", SqlDbType.Bit,1),
					new SqlParameter("@sExecBtnText", SqlDbType.VarChar,50),
					new SqlParameter("@sExecSQL", SqlDbType.VarChar,1000),
					new SqlParameter("@sDealFields", SqlDbType.VarChar,500),
					new SqlParameter("@sSortFields", SqlDbType.VarChar,500),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30),
					new SqlParameter("@bIsAutoRun", SqlDbType.Bit,1)};
            parameters[0].Value = dr["sReportNo"];
            parameters[1].Value = dr["sReportName"];
            parameters[2].Value = dr["sReportSQL"];
            parameters[3].Value = dr["iControlSpace"];
            parameters[4].Value = dr["iControlColumn"];
            parameters[5].Value = dr["bIsShowPrintBtn"];
            parameters[6].Value = dr["bIsShowExecBtn"];
            parameters[7].Value = dr["bIsChart"];
            parameters[8].Value = dr["sExecBtnText"];
            parameters[9].Value = dr["sExecSQL"];
            parameters[10].Value = dr["sDealFields"];
            parameters[11].Value = dr["sSortFields"];
            parameters[12].Value = dr["iFlag"];
            parameters[13].Value = dr["sUserID"];
            parameters[14].Value = dr["bIsAutoRun"];

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
            strSql.Append("UPDATE sysQueryReportMaster SET ");
            strSql.Append("sReportNo=@sReportNo,");
            strSql.Append("sReportName=@sReportName,");
            strSql.Append("sReportSQL=@sReportSQL,");
            strSql.Append("iControlSpace=@iControlSpace,");
            strSql.Append("iControlColumn=@iControlColumn,");
            strSql.Append("bIsShowPrintBtn=@bIsShowPrintBtn,");
            strSql.Append("bIsShowExecBtn=@bIsShowExecBtn,");
            strSql.Append("bIsChart=@bIsChart,");
            strSql.Append("sExecBtnText=@sExecBtnText,");
            strSql.Append("sExecSQL=@sExecSQL,");
            strSql.Append("sDealFields=@sDealFields,");
            strSql.Append("sSortFields=@sSortFields,");
            strSql.Append("iFlag=@iFlag,");
            strSql.Append("sUserID=@sUserID,");
            strSql.Append("bIsAutoRun=@bIsAutoRun");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@sReportNo", SqlDbType.VarChar,30),
					new SqlParameter("@sReportName", SqlDbType.VarChar,30),
					new SqlParameter("@sReportSQL", SqlDbType.VarChar,5000),
					new SqlParameter("@iControlSpace", SqlDbType.Int,4),
					new SqlParameter("@iControlColumn", SqlDbType.Int,4),
					new SqlParameter("@bIsShowPrintBtn", SqlDbType.Bit,1),
					new SqlParameter("@bIsShowExecBtn", SqlDbType.Bit,1),
					new SqlParameter("@bIsChart", SqlDbType.Bit,1),
					new SqlParameter("@sExecBtnText", SqlDbType.VarChar,50),
					new SqlParameter("@sExecSQL", SqlDbType.VarChar,1000),
					new SqlParameter("@sDealFields", SqlDbType.VarChar,500),
					new SqlParameter("@sSortFields", SqlDbType.VarChar,500),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30),
					new SqlParameter("@bIsAutoRun", SqlDbType.Bit,1)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["sReportNo"];
            parameters[2].Value = dr["sReportName"];
            parameters[3].Value = dr["sReportSQL"];
            parameters[4].Value = dr["iControlSpace"];
            parameters[5].Value = dr["iControlColumn"];
            parameters[6].Value = dr["bIsShowPrintBtn"];
            parameters[7].Value = dr["bIsShowExecBtn"];
            parameters[8].Value = dr["bIsChart"];
            parameters[9].Value = dr["sExecBtnText"];
            parameters[10].Value = dr["sExecSQL"];
            parameters[11].Value = dr["sDealFields"];
            parameters[12].Value = dr["sSortFields"];
            parameters[13].Value = dr["iFlag"];
            parameters[14].Value = dr["sUserID"];
            parameters[15].Value = dr["bIsAutoRun"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM sysQueryReportMaster ");
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
            strSql.Append(" FROM sysQueryReportMaster ");
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
            strSql.Append(" * FROM sysQueryReportMaster ");
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

