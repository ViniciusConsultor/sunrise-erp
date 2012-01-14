//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.DAL
//Description:      salGoodInfoMasterDAL
//Create by:        自动生成
//Create Date:      2010-12-13 23:02:46
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
    /// 数据访问类salGoodInfoMasterDAL
    /// </summary>
    public class salGoodInfoMasterDAL
    {
        public salGoodInfoMasterDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM salGoodInfoMaster");
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
            strSql.Append("INSERT INTO salGoodInfoMaster(");
            strSql.Append("sGoodID,sGoodCName,sGoodEName,sGoodTypeID,sUnitID,sShopID,sRemark,bIsStop,iFlag,sUserID)");
            strSql.Append(" VALUES (");
            strSql.Append("@sGoodID,@sGoodCName,@sGoodEName,@sGoodTypeID,@sUnitID,@sShopID,@sRemark,@bIsStop,@iFlag,@sUserID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sGoodID", SqlDbType.VarChar,50),
					new SqlParameter("@sGoodCName", SqlDbType.VarChar,50),
					new SqlParameter("@sGoodEName", SqlDbType.VarChar,50),
					new SqlParameter("@sGoodTypeID", SqlDbType.VarChar,30),
					new SqlParameter("@sUnitID", SqlDbType.VarChar,30),
					new SqlParameter("@sShopID", SqlDbType.VarChar,30),
					new SqlParameter("@sRemark", SqlDbType.VarChar,200),
					new SqlParameter("@bIsStop", SqlDbType.Bit,1),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["sGoodID"];
            parameters[1].Value = dr["sGoodCName"];
            parameters[2].Value = dr["sGoodEName"];
            parameters[3].Value = dr["sGoodTypeID"];
            parameters[4].Value = dr["sUnitID"];
            parameters[5].Value = dr["sShopID"];
            parameters[6].Value = dr["sRemark"];
            parameters[7].Value = dr["bIsStop"];
            parameters[8].Value = dr["iFlag"];
            parameters[9].Value = dr["sUserID"];

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
            strSql.Append("UPDATE salGoodInfoMaster SET ");
            strSql.Append("sGoodID=@sGoodID,");
            strSql.Append("sGoodCName=@sGoodCName,");
            strSql.Append("sGoodEName=@sGoodEName,");
            strSql.Append("sGoodTypeID=@sGoodTypeID,");
            strSql.Append("sUnitID=@sUnitID,");
            strSql.Append("sShopID=@sShopID,");
            strSql.Append("sRemark=@sRemark,");
            strSql.Append("bIsStop=@bIsStop,");
            strSql.Append("iFlag=@iFlag,");
            strSql.Append("sUserID=@sUserID");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@sGoodID", SqlDbType.VarChar,50),
					new SqlParameter("@sGoodCName", SqlDbType.VarChar,50),
					new SqlParameter("@sGoodEName", SqlDbType.VarChar,50),
					new SqlParameter("@sGoodTypeID", SqlDbType.VarChar,30),
					new SqlParameter("@sUnitID", SqlDbType.VarChar,30),
					new SqlParameter("@sShopID", SqlDbType.VarChar,30),
					new SqlParameter("@sRemark", SqlDbType.VarChar,200),
					new SqlParameter("@bIsStop", SqlDbType.Bit,1),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["sGoodID"];
            parameters[2].Value = dr["sGoodCName"];
            parameters[3].Value = dr["sGoodEName"];
            parameters[4].Value = dr["sGoodTypeID"];
            parameters[5].Value = dr["sUnitID"];
            parameters[6].Value = dr["sShopID"];
            parameters[7].Value = dr["sRemark"];
            parameters[8].Value = dr["bIsStop"];
            parameters[9].Value = dr["iFlag"];
            parameters[10].Value = dr["sUserID"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM salGoodInfoMaster ");
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
            strSql.Append(" FROM vwsalGoodInfoMaster ");
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
            strSql.Append(" * FROM vwsalGoodInfoMaster ");
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

