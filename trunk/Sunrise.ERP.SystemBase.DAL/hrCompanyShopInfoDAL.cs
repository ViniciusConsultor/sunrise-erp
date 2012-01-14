//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.DAL
//Description:      hrCompanyShopInfoDAL
//Create by:        自动生成
//Create Date:      2010-12-13 22:23:36
//Modify by：              Modify Date：               Description：
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sunrise.ERP.DataAccess;
namespace Sunrise.ERP.SystemBase.DAL
{
    /// <summary>
    /// 数据访问类hrCompanyShopInfoDAL
    /// </summary>
    public class hrCompanyShopInfoDAL
    {
        public hrCompanyShopInfoDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM hrCompanyShopInfo");
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
            strSql.Append("INSERT INTO hrCompanyShopInfo(");
            strSql.Append("MainID,sShopID,sShopCName,sShopEName,sRemark,sUserID)");
            strSql.Append(" VALUES (");
            strSql.Append("@MainID,@sShopID,@sShopCName,@sShopEName,@sRemark,@sUserID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MainID", SqlDbType.Int,4),
					new SqlParameter("@sShopID", SqlDbType.VarChar,30),
					new SqlParameter("@sShopCName", SqlDbType.VarChar,50),
					new SqlParameter("@sShopEName", SqlDbType.VarChar,50),
					new SqlParameter("@sRemark", SqlDbType.VarChar,200),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["MainID"];
            parameters[1].Value = dr["sShopID"];
            parameters[2].Value = dr["sShopCName"];
            parameters[3].Value = dr["sShopEName"];
            parameters[4].Value = dr["sRemark"];
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
            strSql.Append("UPDATE hrCompanyShopInfo SET ");
            strSql.Append("MainID=@MainID,");
            strSql.Append("sShopID=@sShopID,");
            strSql.Append("sShopCName=@sShopCName,");
            strSql.Append("sShopEName=@sShopEName,");
            strSql.Append("sRemark=@sRemark,");
            strSql.Append("sUserID=@sUserID");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@MainID", SqlDbType.Int,4),
					new SqlParameter("@sShopID", SqlDbType.VarChar,30),
					new SqlParameter("@sShopCName", SqlDbType.VarChar,50),
					new SqlParameter("@sShopEName", SqlDbType.VarChar,50),
					new SqlParameter("@sRemark", SqlDbType.VarChar,200),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["MainID"];
            parameters[2].Value = dr["sShopID"];
            parameters[3].Value = dr["sShopCName"];
            parameters[4].Value = dr["sShopEName"];
            parameters[5].Value = dr["sRemark"];
            parameters[6].Value = dr["sUserID"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM hrCompanyShopInfo ");
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
            strSql.Append(" FROM hrCompanyShopInfo ");
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
            strSql.Append(" * FROM hrCompanyShopInfo ");
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

