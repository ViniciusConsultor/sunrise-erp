using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Sunrise.ERP.DataAccess;

namespace Sunrise.ERP.BaseForm.DAL
{
    public class DynamicDALSetting
    {
        public DynamicDALSetting(int formid,DataRow optiondr)
        {
            FormID = formid;
            OptionData = optiondr;
        }

        #region 属性

        private int formid;
        /// <summary>
        /// 窗体ID
        /// </summary>
        public int FormID
        {
            get { return formid; }
            set { formid = value; }
        }

        private DataRow dr;
        public DataRow OptionData
        {
            get { return dr; }
            set { dr = value; }
        }

        private string tablename;
        /// <summary>
        /// 数据表名
        /// </summary>
        public string TableName
        {
            get { return tablename; }
            set { tablename = value; }
        }

        /// <summary>
        /// 数据视图名
        /// </summary>
        public string ViewName
        {
            get
            {
                if (DynamicDataTable.Rows.Count > 0)
                {
                    return DynamicDataTable.Rows[0]["sQueryViewName"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private DataTable dynamicdatatable;

        /// <summary>
        /// 动态表结构数据
        /// </summary>
        public DataTable DynamicDataTable
        {
            get
            {
                if (dynamicdatatable == null)
                {
                    string sSql = "SELECT A.sFieldName,A.sFieldType,A.sFieldLength,B.sQueryViewName FROM sysDynamicFormDetail A LEFT JOIN "
                                + "sysDynamicFormMaster B WHERE A.MainID=B.ID AND B.FormID=" + FormID.ToString();
                    dynamicdatatable = DbHelperSQL.Query(sSql).Tables[0];
                }
                return dynamicdatatable;
            }
        }
        #endregion

        #region 公共数据库操作方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM ");
            strSql.Append(TableName);
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM ");
            strSql.Append(TableName);
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DataRow dr, SqlTransaction trans)
        {
            string strSql = CreateSQL("Add");
            SqlParameter[] parameters = CreateSqlParameter("Add");
            object obj = DbHelperSQL.GetSingle(strSql, trans, parameters);
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
            string strSql = CreateSQL("Update");
            SqlParameter[] parameters = CreateSqlParameter("Update");
            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM ");
            strSql.Append(ViewName != string.Empty ? ViewName : TableName);
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
            strSql.Append(" * FROM ");
            strSql.Append(ViewName != string.Empty ? ViewName : TableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY  " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion

        #region SQL语句操作

        private string CreateSQL(string type)
        {
            StringBuilder strSql = new StringBuilder();
            if (type == "Add")
            {
                strSql.Append("INSERT INTO ");
                strSql.Append(TableName);
                strSql.Append("(");
                strSql.Append(CreateFileds("Add", false));
                strSql.Append(") VALUES (");
                strSql.Append(CreateFileds("Add", true));
                strSql.Append(");SELECT @@IDENTITY");
            }
            else if (type == "Update")
            {
                strSql.Append("UPDATE ");
                strSql.Append(TableName);
                strSql.Append(" SET ");
                strSql.Append(CreateFileds("Update", false));
            }
            return strSql.ToString();
        }

        private string CreateFileds(string type, bool isparam)
        {
            StringBuilder strSql = new StringBuilder();
            if (type == "Add")
            {
                if (DynamicDataTable != null && DynamicDataTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in DynamicDataTable.Rows)
                    {
                        if (isparam)
                        {
                            strSql.Append("@");
                        }
                        strSql.Append(dr["sFieldName"]);
                        strSql.Append(",");
                    }
                    strSql.Remove(strSql.Length - 1, 1);
                }
            }
            else if (type == "Update")
            {
                if (DynamicDataTable != null && DynamicDataTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in DynamicDataTable.Rows)
                    {
                        strSql.Append(dr["sFieldName"]);
                        strSql.Append("=@");
                        strSql.Append(dr["sFieldName"]);
                        strSql.Append(",");
                    }
                    strSql.Remove(strSql.Length - 1, 1);
                    strSql.Append(" WHERE ID=@ID ");
                }
            }
            return strSql.ToString();
        }

        private SqlParameter[] CreateSqlParameter(string type)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            int count = 0;
            if (type == "Update")
            {
                parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4));
                parameters[0].Value = OptionData["ID"];
                count++;
            }
            foreach (DataRow dr in DynamicDataTable.Rows)
            {
                switch (dr["sFieldType"].ToString())
                {
                    //varchar
                    case "S":
                        {
                            parameters.Add(new SqlParameter("@" + dr["sFieldName"], SqlDbType.VarChar, (int)dr["sFieldLength"]));
                            parameters[count].Value = OptionData[dr["sFieldName"].ToString()];
                            break;
                        }
                    //datetime
                    case "D":
                        {
                            parameters.Add(new SqlParameter("@" + dr["sFieldName"], SqlDbType.DateTime));
                            parameters[count].Value = OptionData[dr["sFieldName"].ToString()];
                            break;
                        }
                    //bit
                    case "B":
                        {
                            parameters.Add(new SqlParameter("@" + dr["sFieldName"], SqlDbType.Bit, 1));
                            parameters[count].Value = OptionData[dr["sFieldName"].ToString()];
                            break;
                        }
                    //int
                    case "I":
                        {
                            parameters.Add(new SqlParameter("@" + dr["sFieldName"], SqlDbType.Int, 4));
                            parameters[count].Value = OptionData[dr["sFieldName"].ToString()];
                            break;
                        }
                    //image
                    case "M":
                        {
                            parameters.Add(new SqlParameter("@" + dr["sFieldName"], SqlDbType.Image));
                            parameters[count].Value = OptionData[dr["sFieldName"].ToString()];
                            break;
                        }
                }
                count++;

            }
            return parameters.ToArray();
        }

        #endregion
    }
}
