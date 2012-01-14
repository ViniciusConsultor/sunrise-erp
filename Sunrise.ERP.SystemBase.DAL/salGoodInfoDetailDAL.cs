//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.DAL
//Description:      salGoodInfoDetailDAL
//Create by:        自动生成
//Create Date:      2010-12-14 23:32:37
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
    /// 数据访问类salGoodInfoDetailDAL
    /// </summary>
    public class salGoodInfoDetailDAL
    {
        public salGoodInfoDetailDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM salGoodInfoDetail");
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
            strSql.Append("INSERT INTO salGoodInfoDetail(");
            strSql.Append("MainID,iSort,fBasePrice,fSupplierSalePrice,fDiscount,fSalePrice,bIsStop,dPriceDate,sRemark,sUserID)");
            strSql.Append(" VALUES (");
            strSql.Append("@MainID,@iSort,@fBasePrice,@fSupplierSalePrice,@fDiscount,@fSalePrice,@bIsStop,@dPriceDate,@sRemark,@sUserID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MainID", SqlDbType.Int,4),
					new SqlParameter("@iSort", SqlDbType.Int,4),
					new SqlParameter("@fBasePrice", SqlDbType.Decimal,9),
					new SqlParameter("@fSupplierSalePrice", SqlDbType.Decimal,9),
					new SqlParameter("@fDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@fSalePrice", SqlDbType.Decimal,9),
					new SqlParameter("@bIsStop", SqlDbType.Bit,1),
					new SqlParameter("@dPriceDate", SqlDbType.DateTime),
					new SqlParameter("@sRemark", SqlDbType.VarChar,200),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["MainID"];
            parameters[1].Value = dr["iSort"];
            parameters[2].Value = dr["fBasePrice"];
            parameters[3].Value = dr["fSupplierSalePrice"];
            parameters[4].Value = dr["fDiscount"];
            parameters[5].Value = dr["fSalePrice"];
            parameters[6].Value = dr["bIsStop"];
            parameters[7].Value = dr["dPriceDate"];
            parameters[8].Value = dr["sRemark"];
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
            strSql.Append("UPDATE salGoodInfoDetail SET ");
            strSql.Append("MainID=@MainID,");
            strSql.Append("iSort=@iSort,");
            strSql.Append("fBasePrice=@fBasePrice,");
            strSql.Append("fSupplierSalePrice=@fSupplierSalePrice,");
            strSql.Append("fDiscount=@fDiscount,");
            strSql.Append("fSalePrice=@fSalePrice,");
            strSql.Append("bIsStop=@bIsStop,");
            strSql.Append("dPriceDate=@dPriceDate,");
            strSql.Append("sRemark=@sRemark,");
            strSql.Append("sUserID=@sUserID");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@MainID", SqlDbType.Int,4),
					new SqlParameter("@iSort", SqlDbType.Int,4),
					new SqlParameter("@fBasePrice", SqlDbType.Decimal,9),
					new SqlParameter("@fSupplierSalePrice", SqlDbType.Decimal,9),
					new SqlParameter("@fDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@fSalePrice", SqlDbType.Decimal,9),
					new SqlParameter("@bIsStop", SqlDbType.Bit,1),
					new SqlParameter("@dPriceDate", SqlDbType.DateTime),
					new SqlParameter("@sRemark", SqlDbType.VarChar,200),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["MainID"];
            parameters[2].Value = dr["iSort"];
            parameters[3].Value = dr["fBasePrice"];
            parameters[4].Value = dr["fSupplierSalePrice"];
            parameters[5].Value = dr["fDiscount"];
            parameters[6].Value = dr["fSalePrice"];
            parameters[7].Value = dr["bIsStop"];
            parameters[8].Value = dr["dPriceDate"];
            parameters[9].Value = dr["sRemark"];
            parameters[10].Value = dr["sUserID"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM salGoodInfoDetail ");
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
            strSql.Append(" FROM salGoodInfoDetail ");
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
            strSql.Append(" * FROM salGoodInfoDetail ");
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

