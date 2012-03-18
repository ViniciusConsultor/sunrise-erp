//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.DAL
//Description:      sysMenuDAL
//Create by:        自动生成
//Create Date:      2010-11-14 14:44:17
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
    /// 数据访问类sysMenuDAL
    /// </summary>
    public class sysMenuDAL
    {
        public sysMenuDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM sysMenu");
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
            strSql.Append("INSERT INTO sysMenu(");
            strSql.Append("iFormID,sMenuName,sMenuEngName,iParentID,sModuleName,sFormClassName,iSort,dDLLGetTime,dDLLLastTime,sUserID,sQuickMenu,iFlag,bIsBill)");
            strSql.Append(" VALUES (");
            strSql.Append("@iFormID,@sMenuName,@sMenuEngName,@iParentID,@sModuleName,@sFormClassName,@iSort,@dDLLGetTime,@dDLLLastTime,@sUserID,@sQuickMenu,@iFlag,@bIsBill)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@iFormID", SqlDbType.Int,4),
					new SqlParameter("@sMenuName", SqlDbType.VarChar,50),
					new SqlParameter("@sMenuEngName", SqlDbType.VarChar,50),
					new SqlParameter("@iParentID", SqlDbType.Int,4),
					new SqlParameter("@sModuleName", SqlDbType.VarChar,100),
					new SqlParameter("@sFormClassName", SqlDbType.VarChar,50),
					new SqlParameter("@iSort", SqlDbType.Int,4),
					new SqlParameter("@dDLLGetTime", SqlDbType.DateTime),
					new SqlParameter("@dDLLLastTime", SqlDbType.DateTime),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30),
					new SqlParameter("@sQuickMenu", SqlDbType.VarChar,50),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@bIsBill", SqlDbType.Bit,1)};
            parameters[0].Value = dr["iFormID"];
            parameters[1].Value = dr["sMenuName"];
            parameters[2].Value = dr["sMenuEngName"];
            parameters[3].Value = dr["iParentID"];
            parameters[4].Value = dr["sModuleName"];
            parameters[5].Value = dr["sFormClassName"];
            parameters[6].Value = dr["iSort"];
            parameters[7].Value = dr["dDLLGetTime"];
            parameters[8].Value = dr["dDLLLastTime"];
            parameters[9].Value = dr["sUserID"];
            parameters[10].Value = dr["sQuickMenu"];
            parameters[11].Value = dr["iFlag"];
            parameters[12].Value = dr["bIsBill"];

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
            strSql.Append("UPDATE sysMenu SET ");
            strSql.Append("iFormID=@iFormID,");
            strSql.Append("sMenuName=@sMenuName,");
            strSql.Append("sMenuEngName=@sMenuEngName,");
            strSql.Append("iParentID=@iParentID,");
            strSql.Append("sModuleName=@sModuleName,");
            strSql.Append("sFormClassName=@sFormClassName,");
            strSql.Append("iSort=@iSort,");
            strSql.Append("dDLLGetTime=@dDLLGetTime,");
            strSql.Append("dDLLLastTime=@dDLLLastTime,");
            strSql.Append("sUserID=@sUserID,");
            strSql.Append("sQuickMenu=@sQuickMenu,");
            strSql.Append("iFlag=@iFlag,");
            strSql.Append("bIsBill=@bIsBill");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@iFormID", SqlDbType.Int,4),
					new SqlParameter("@sMenuName", SqlDbType.VarChar,50),
					new SqlParameter("@sMenuEngName", SqlDbType.VarChar,50),
					new SqlParameter("@iParentID", SqlDbType.Int,4),
					new SqlParameter("@sModuleName", SqlDbType.VarChar,100),
					new SqlParameter("@sFormClassName", SqlDbType.VarChar,50),
					new SqlParameter("@iSort", SqlDbType.Int,4),
					new SqlParameter("@dDLLGetTime", SqlDbType.DateTime),
					new SqlParameter("@dDLLLastTime", SqlDbType.DateTime),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30),
					new SqlParameter("@sQuickMenu", SqlDbType.VarChar,50),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@bIsBill", SqlDbType.Bit,1)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["iFormID"];
            parameters[2].Value = dr["sMenuName"];
            parameters[3].Value = dr["sMenuEngName"];
            parameters[4].Value = dr["iParentID"];
            parameters[5].Value = dr["sModuleName"];
            parameters[6].Value = dr["sFormClassName"];
            parameters[7].Value = dr["iSort"];
            parameters[8].Value = dr["dDLLGetTime"];
            parameters[9].Value = dr["dDLLLastTime"];
            parameters[10].Value = dr["sUserID"];
            parameters[11].Value = dr["sQuickMenu"];
            parameters[12].Value = dr["iFlag"];
            parameters[13].Value = dr["bIsBill"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM sysMenu ");
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
            strSql.Append(" FROM sysMenu ");
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
            strSql.Append(" * FROM sysMenu ");
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

