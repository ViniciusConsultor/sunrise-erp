//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.DAL
//Description:      basDataDictDetailDAL
//Create by:        自动生成
//Create Date:      2010-11-14 14:59:29
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
    /// 数据访问类basDataDictDetailDAL
    /// </summary>
    public class basDataDictDetailDAL
    {
        public basDataDictDetailDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM basDataDictDetail");
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
            strSql.Append("INSERT INTO basDataDictDetail(");
            strSql.Append("MainID,sDictDataNo,sDictDataCName,sDictDataEName,bIsStop,sRemark,sUserID)");
            strSql.Append(" VALUES (");
            strSql.Append("@MainID,@sDictDataNo,@sDictDataCName,@sDictDataEName,@bIsStop,@sRemark,@sUserID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MainID", SqlDbType.Int,4),
					new SqlParameter("@sDictDataNo", SqlDbType.VarChar,30),
					new SqlParameter("@sDictDataCName", SqlDbType.VarChar,50),
					new SqlParameter("@sDictDataEName", SqlDbType.VarChar,50),
					new SqlParameter("@bIsStop", SqlDbType.Bit,1),
					new SqlParameter("@sRemark", SqlDbType.Text),
					new SqlParameter("@sUserID", SqlDbType.VarChar,20)};
            parameters[0].Value = dr["MainID"];
            parameters[1].Value = dr["sDictDataNo"];
            parameters[2].Value = dr["sDictDataCName"];
            parameters[3].Value = dr["sDictDataEName"];
            parameters[4].Value = dr["bIsStop"];
            parameters[5].Value = dr["sRemark"];
            parameters[6].Value = dr["sUserID"];

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
            strSql.Append("UPDATE basDataDictDetail SET ");
            strSql.Append("MainID=@MainID,");
            strSql.Append("sDictDataNo=@sDictDataNo,");
            strSql.Append("sDictDataCName=@sDictDataCName,");
            strSql.Append("sDictDataEName=@sDictDataEName,");
            strSql.Append("bIsStop=@bIsStop,");
            strSql.Append("sRemark=@sRemark,");
            strSql.Append("sUserID=@sUserID");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@MainID", SqlDbType.Int,4),
					new SqlParameter("@sDictDataNo", SqlDbType.VarChar,30),
					new SqlParameter("@sDictDataCName", SqlDbType.VarChar,50),
					new SqlParameter("@sDictDataEName", SqlDbType.VarChar,50),
					new SqlParameter("@bIsStop", SqlDbType.Bit,1),
					new SqlParameter("@sRemark", SqlDbType.Text),
					new SqlParameter("@sUserID", SqlDbType.VarChar,20)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["MainID"];
            parameters[2].Value = dr["sDictDataNo"];
            parameters[3].Value = dr["sDictDataCName"];
            parameters[4].Value = dr["sDictDataEName"];
            parameters[5].Value = dr["bIsStop"];
            parameters[6].Value = dr["sRemark"];
            parameters[7].Value = dr["sUserID"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM basDataDictDetail ");
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
            strSql.Append(" FROM basDataDictDetail ");
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
            strSql.Append(" * FROM basDataDictDetail ");
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

