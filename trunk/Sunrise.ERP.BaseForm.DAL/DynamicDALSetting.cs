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
        private DataTable dynamicdatatable;
        public DynamicDALSetting(DataTable dynamicdata)
        {
            dynamicdatatable = dynamicdata;
        }

        #region 属性

        /// <summary>
        /// 数据表名
        /// </summary>
        private string TableName
        {
            get { return MainDynamicData[0]["sTableName"].ToString(); }
            
        }


        private string SubTableName
        {
            get { return MainDynamicData[0]["sTableName"].ToString() + MainDynamicData[0]["FormID"].ToString() + "_Z"; }
        }

        /// <summary>
        /// 数据视图名
        /// </summary>
        private string ViewName
        {
            get { return MainDynamicData[0]["sQueryViewName"].ToString(); }
        }


        /// <summary>
        /// 单据系统表结构数据
        /// </summary>
        private DataRow[] MainDynamicData
        {
            get { return dynamicdatatable.Select("bSystemColumn=1 AND bSaveData=1"); }

        }

        /// <summary>
        /// 单据扩展表结构数据
        /// </summary>
        private DataRow[] SubDynamicData
        {
            get { return dynamicdatatable.Select("bSystemColumn=0 AND bSaveData=1"); }
        }

        private string insertsql = "";
        /// <summary>
        /// Insert SQL
        /// </summary>
        public string InsertSQL
        {
            get 
            {
                if (insertsql == "")
                    insertsql = CreateSQL("Add", false);
                return insertsql; 
            }
        }

        private string updatesql = "";
        /// <summary>
        /// Update SQL
        /// </summary>
        public string UpdateSQL
        {
            get 
            {
                if (updatesql == "")
                    updatesql = CreateSQL("Update", false);
                return updatesql; 
            }
        }

        private string selectsql = "";
        /// <summary>
        /// Select SQL
        /// </summary>
        public string SelectSQL
        {
            get { return selectsql; }
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
            string strSql = CreateSQL("Add",false);
            SqlParameter[] parameters = CreateSqlParameter(dr, "Add", false);
            object obj = DbHelperSQL.GetSingle(strSql, trans, parameters);
            //添加自定义表
            dr["ID"] = obj == null ? -1 : obj;
            UpdateSubData(dr, trans);
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
            string strSql = CreateSQL("Update",false);
            SqlParameter[] parameters = CreateSqlParameter(dr, "Update",false);
            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
            UpdateSubData(dr, trans);
        }
        private void UpdateSubData(DataRow dr, SqlTransaction trans)
        {
            if (SubDynamicData.Length > 0)
            {
                string sDeleteSql = "DELETE FROM " + SubTableName + " WHERE MainTableID=" + (!string.IsNullOrEmpty(dr["ID"].ToString()) ? dr["ID"].ToString() : "-1");
                DbHelperSQL.ExecuteSql(sDeleteSql, trans);
                string sInsertSql = CreateSQL("Add", true);
                SqlParameter[] parameters = CreateSqlParameter(dr, "Add", true);
                DbHelperSQL.ExecuteSql(sInsertSql, trans, parameters);
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ma.* ");
            strSql.Append(SubDynamicData.Length > 0 ? "," + CreateFileds("Add", false, true) : "");
            strSql.Append(" FROM ");
            strSql.Append(ViewName != string.Empty ? ViewName : TableName);
            strSql.Append(" ma ");
            if (SubDynamicData.Length > 0)
            {
                strSql.Append(" LEFT JOIN ");
                strSql.Append(SubTableName + " de ON ma.ID=de.MainTableID ");
            }
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            selectsql = strSql.ToString();
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
            strSql.Append(" ma.* ");
            strSql.Append(SubDynamicData.Length > 0 ? "," + CreateFileds("Add", false, true) : "");
            strSql.Append(" FROM ");
            strSql.Append(ViewName != string.Empty ? ViewName : TableName);
            strSql.Append(" ma ");
            if (SubDynamicData.Length > 0)
            {
                strSql.Append(" LEFT JOIN ");
                strSql.Append(SubTableName + " de ON ma.ID=de.MainTableID ");
            }
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY  " + filedOrder);
            selectsql = strSql.ToString();
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion

        #region SQL语句操作

        private string CreateSQL(string type,bool issub)
        {
            StringBuilder strSql = new StringBuilder();
            if (type == "Add")
            {
                if (issub)
                {
                    strSql.Append("INSERT INTO ");
                    strSql.Append(SubTableName);
                    strSql.Append("(");
                    strSql.Append(CreateFileds("Add", false,issub));
                    strSql.Append(") VALUES (");
                    strSql.Append(CreateFileds("Add", true, issub));
                    strSql.Append(");SELECT @@IDENTITY");
                }
                else
                {
                    strSql.Append("INSERT INTO ");
                    strSql.Append(TableName);
                    strSql.Append("(");
                    strSql.Append(CreateFileds("Add", false,issub));
                    strSql.Append(") VALUES (");
                    strSql.Append(CreateFileds("Add", true, issub));
                    strSql.Append(");SELECT @@IDENTITY");
                }
            }
            else if (type == "Update")
            {
                strSql.Append("UPDATE ");
                strSql.Append(TableName);
                strSql.Append(" SET ");
                strSql.Append(CreateFileds("Update", false, issub));
            }
            return strSql.ToString();
        }

        private string CreateFileds(string type, bool isparam,bool issub)
        {
            StringBuilder strSql = new StringBuilder();
            if (type == "Add")
            {
                foreach (DataRow dr in issub ? SubDynamicData : MainDynamicData)
                {
                    if (isparam)
                    {
                        strSql.Append("@");
                    }
                    strSql.Append(dr["sFieldName"]);
                    strSql.Append(",");
                }
                //增加sUserID,iFlag
                if (!issub)
                {
                    if (MainDynamicData.Length > 0 && MainDynamicData[0]["sFormType"].ToString() == "001")
                    {
                        if (isparam)
                        {
                            strSql.Append("@");
                        }
                        strSql.Append("sUserID");
                        strSql.Append(",");
                        if (isparam)
                        {
                            strSql.Append("@");
                        }
                        strSql.Append("iFlag");
                    }
                    else if (MainDynamicData.Length > 0 && MainDynamicData[0]["sFormType"].ToString() == "002")
                    {
                        if (isparam)
                        {
                            strSql.Append("@");
                        }
                        strSql.Append("sUserID");
                    }
                    else
                    {
                        throw new Exception("自定义窗体设置中设置窗体类型错误！");
                    }
                }
                if (issub && SubDynamicData.Length > 0)
                {
                    strSql.Append(isparam ? "@MainTableID" : "MainTableID");
                }
            }
            else if (type == "Update")
            {
                foreach (DataRow dr in MainDynamicData)
                {
                    strSql.Append(dr["sFieldName"]);
                    strSql.Append("=@");
                    strSql.Append(dr["sFieldName"]);
                    strSql.Append(",");
                }
                //增加sUserID,iFlag
                if (MainDynamicData.Length > 0 && MainDynamicData[0]["sFormType"].ToString() == "001")
                {
                    strSql.Append("sUserID=@sUserID,");
                    strSql.Append("iFlag=@iFlag");
                }
                else if (MainDynamicData.Length > 0 && MainDynamicData[0]["sFormType"].ToString() == "002")
                {
                    strSql.Append("sUserID=@sUserID ");
                }
                else
                {
                    throw new Exception("自定义窗体设置中设置窗体类型错误！");
                }

                //strSql.Remove(strSql.Length - 1, 1);
                strSql.Append(" WHERE ID=@ID ");
            }
            return strSql.ToString();
        }

        private SqlParameter[] CreateSqlParameter(DataRow optiondata,string type,bool issub)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            int count = 0;
            if (type == "Update")
            {
                parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4));
                parameters[0].Value = optiondata["ID"];
                count++;
            }
            if (!issub)
            {
                if (MainDynamicData.Length > 0 && MainDynamicData[0]["sFormType"].ToString() == "001")
                {
                    parameters.Add(new SqlParameter("@sUserID", SqlDbType.VarChar, 30));
                    parameters[count].Value = optiondata["sUserID"];
                    count++;
                    parameters.Add(new SqlParameter("@iFlag", SqlDbType.Int, 4));
                    parameters[count].Value = optiondata["iFlag"];
                    count++;
                }
                else if (MainDynamicData.Length > 0 && MainDynamicData[0]["sFormType"].ToString() == "002")
                {
                    parameters.Add(new SqlParameter("@sUserID", SqlDbType.VarChar, 30));
                    parameters[count].Value = optiondata["sUserID"];
                    count++;
                }
            }
            if (issub && SubDynamicData.Length > 0)
            {
                parameters.Add(new SqlParameter("@MainTableID", SqlDbType.Int, 4));
                parameters[count].Value = optiondata["ID"];
                count++;
            }
            foreach (DataRow dr in issub ? SubDynamicData : MainDynamicData)
            {
                switch (dr["sFieldType"].ToString())
                {
                    //varchar
                    case "S":
                        {
                            //当字符超过8000则创建字符串为varchar(max)类型
                            //varchar(max)在SqlParameter中长度用-1表示
                            int iLeng = 0;
                            if (dr["iFieldLength"] != null && Convert.ToInt32(dr["iFieldLength"]) > 8000)
                                iLeng = -1;
                            else
                                iLeng=(int)dr["iFieldLength"];
                            parameters.Add(new SqlParameter("@" + dr["sFieldName"], SqlDbType.VarChar, iLeng));
                            parameters[count].Value = optiondata[dr["sFieldName"].ToString()];
                            break;
                        }
                    //datetime
                    case "D":
                        {
                            parameters.Add(new SqlParameter("@" + dr["sFieldName"], SqlDbType.DateTime));
                            parameters[count].Value = optiondata[dr["sFieldName"].ToString()];
                            break;
                        }
                    //bit
                    case "B":
                        {
                            parameters.Add(new SqlParameter("@" + dr["sFieldName"], SqlDbType.Bit, 1));
                            parameters[count].Value = optiondata[dr["sFieldName"].ToString()];
                            break;
                        }
                    //int
                    case "I":
                        {
                            parameters.Add(new SqlParameter("@" + dr["sFieldName"], SqlDbType.Int, 4));
                            parameters[count].Value = optiondata[dr["sFieldName"].ToString()];
                            break;
                        }
                    //image
                    case "M":
                        {
                            parameters.Add(new SqlParameter("@" + dr["sFieldName"], SqlDbType.Image));
                            parameters[count].Value = optiondata[dr["sFieldName"].ToString()];
                            break;
                        }
                    //float or decimal
                    case "F":
                        {
                            parameters.Add(new SqlParameter("@" + dr["sFieldName"], SqlDbType.Decimal, 9));
                            parameters[count].Value = optiondata[dr["sFieldName"].ToString()];
                            break;
                        }
                    //default 将抛出系统异常，提示某个字段字段类型设置错误
                    default:
                        {
                            throw new Exception("字段：" + dr["sFieldName"].ToString() + " 类型设置错误！请检查自定义字段设置！");
                        }

                }
                count++;
            }
            return parameters.ToArray();
        }

        #endregion
    }
}
