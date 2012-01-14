//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.DAL
//Description:      sysUserDAL
//Create by:        自动生成
//Create Date:      2010-11-14 14:54:09
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
    /// 数据访问类sysUserDAL
    /// </summary>
    public class sysUserDAL
    {
        public sysUserDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM sysUser");
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
            strSql.Append("INSERT INTO sysUser(");
            strSql.Append("sUserID,sUserCName,sUserEName,sPassword,ParentID,EmpID,iUserType,bIsLock,sRemark,iFlag)");
            strSql.Append(" VALUES (");
            strSql.Append("@sUserID,@sUserCName,@sUserEName,@sPassword,@ParentID,@EmpID,@iUserType,@bIsLock,@sRemark,@iFlag)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sUserID", SqlDbType.VarChar,30),
					new SqlParameter("@sUserCName", SqlDbType.VarChar,50),
					new SqlParameter("@sUserEName", SqlDbType.VarChar,50),
					new SqlParameter("@sPassword", SqlDbType.VarChar,100),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@EmpID", SqlDbType.Int,4),
					new SqlParameter("@iUserType", SqlDbType.Int,4),
					new SqlParameter("@bIsLock", SqlDbType.Bit,1),
					new SqlParameter("@sRemark", SqlDbType.VarChar,200),
					new SqlParameter("@iFlag", SqlDbType.Int,4)};
            parameters[0].Value = dr["sUserID"];
            parameters[1].Value = dr["sUserCName"];
            parameters[2].Value = dr["sUserEName"];
            parameters[3].Value = dr["sPassword"];
            parameters[4].Value = dr["ParentID"];
            parameters[5].Value = dr["EmpID"];
            parameters[6].Value = dr["iUserType"];
            parameters[7].Value = dr["bIsLock"];
            parameters[8].Value = dr["sRemark"];
            parameters[9].Value = dr["iFlag"];

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
            strSql.Append("UPDATE sysUser SET ");
            strSql.Append("sUserID=@sUserID,");
            strSql.Append("sUserCName=@sUserCName,");
            strSql.Append("sUserEName=@sUserEName,");
            strSql.Append("sPassword=@sPassword,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("EmpID=@EmpID,");
            strSql.Append("iUserType=@iUserType,");
            strSql.Append("bIsLock=@bIsLock,");
            strSql.Append("sRemark=@sRemark,");
            strSql.Append("iFlag=@iFlag");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30),
					new SqlParameter("@sUserCName", SqlDbType.VarChar,50),
					new SqlParameter("@sUserEName", SqlDbType.VarChar,50),
					new SqlParameter("@sPassword", SqlDbType.VarChar,100),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@EmpID", SqlDbType.Int,4),
					new SqlParameter("@iUserType", SqlDbType.Int,4),
					new SqlParameter("@bIsLock", SqlDbType.Bit,1),
					new SqlParameter("@sRemark", SqlDbType.VarChar,200),
					new SqlParameter("@iFlag", SqlDbType.Int,4)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["sUserID"];
            parameters[2].Value = dr["sUserCName"];
            parameters[3].Value = dr["sUserEName"];
            parameters[4].Value = dr["sPassword"];
            parameters[5].Value = dr["ParentID"];
            parameters[6].Value = dr["EmpID"];
            parameters[7].Value = dr["iUserType"];
            parameters[8].Value = dr["bIsLock"];
            parameters[9].Value = dr["sRemark"];
            parameters[10].Value = dr["iFlag"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM sysUser ");
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
            strSql.Append(" FROM vwsysUser ");
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
            strSql.Append(" * FROM vwsysUser ");
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

