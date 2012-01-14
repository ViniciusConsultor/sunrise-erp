//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.DAL
//Description:      hrEmployeeDAL
//Create by:        自动生成
//Create Date:      2010-11-14 15:01:04
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
    /// 数据访问类hrEmployeeDAL
    /// </summary>
    public class hrEmployeeDAL
    {
        public hrEmployeeDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM hrEmployee");
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
            strSql.Append("INSERT INTO hrEmployee(");
            strSql.Append("sEmpNo,sEmpCName,sEmpEName,sIsInService,sEmpContractID,sResidenceType,sInsureID,sPayMentID,sSex,dBirthday,dBabyBirthday,sIdentityCard,sNation,sMarry,sStature,sPolityStatus,sNativePlace,sBrood,sStudyExperience,sGraduateInstitute,sSpeciality,dInCompanyDate,iDepartmentID,sEmpType,sCallTitle,dCallTitleDate,sPosition,sForeignLangaugeLevel,sComputerTechnolic,sEmail,sPersonContactTel,sFamilyContactTel,sOtherContact,sResidence,sFamilyAddr,sFamilyMember,sStudyExperienct,sWorkExperience,dTryoutDate,dFormalDate,mPic,dEndDate,sRemark,iFlag,sUserID)");
            strSql.Append(" VALUES (");
            strSql.Append("@sEmpNo,@sEmpCName,@sEmpEName,@sIsInService,@sEmpContractID,@sResidenceType,@sInsureID,@sPayMentID,@sSex,@dBirthday,@dBabyBirthday,@sIdentityCard,@sNation,@sMarry,@sStature,@sPolityStatus,@sNativePlace,@sBrood,@sStudyExperience,@sGraduateInstitute,@sSpeciality,@dInCompanyDate,@iDepartmentID,@sEmpType,@sCallTitle,@dCallTitleDate,@sPosition,@sForeignLangaugeLevel,@sComputerTechnolic,@sEmail,@sPersonContactTel,@sFamilyContactTel,@sOtherContact,@sResidence,@sFamilyAddr,@sFamilyMember,@sStudyExperienct,@sWorkExperience,@dTryoutDate,@dFormalDate,@mPic,@dEndDate,@sRemark,@iFlag,@sUserID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sEmpNo", SqlDbType.VarChar,20),
					new SqlParameter("@sEmpCName", SqlDbType.VarChar,20),
					new SqlParameter("@sEmpEName", SqlDbType.VarChar,20),
					new SqlParameter("@sIsInService", SqlDbType.VarChar,10),
					new SqlParameter("@sEmpContractID", SqlDbType.VarChar,20),
					new SqlParameter("@sResidenceType", SqlDbType.VarChar,20),
					new SqlParameter("@sInsureID", SqlDbType.VarChar,50),
					new SqlParameter("@sPayMentID", SqlDbType.VarChar,50),
					new SqlParameter("@sSex", SqlDbType.VarChar,10),
					new SqlParameter("@dBirthday", SqlDbType.DateTime),
					new SqlParameter("@dBabyBirthday", SqlDbType.DateTime),
					new SqlParameter("@sIdentityCard", SqlDbType.VarChar,18),
					new SqlParameter("@sNation", SqlDbType.VarChar,30),
					new SqlParameter("@sMarry", SqlDbType.VarChar,10),
					new SqlParameter("@sStature", SqlDbType.Int,4),
					new SqlParameter("@sPolityStatus", SqlDbType.VarChar,20),
					new SqlParameter("@sNativePlace", SqlDbType.VarChar,30),
					new SqlParameter("@sBrood", SqlDbType.VarChar,8),
					new SqlParameter("@sStudyExperience", SqlDbType.VarChar,10),
					new SqlParameter("@sGraduateInstitute", SqlDbType.VarChar,40),
					new SqlParameter("@sSpeciality", SqlDbType.VarChar,50),
					new SqlParameter("@dInCompanyDate", SqlDbType.DateTime),
					new SqlParameter("@iDepartmentID", SqlDbType.Int,4),
					new SqlParameter("@sEmpType", SqlDbType.VarChar,20),
					new SqlParameter("@sCallTitle", SqlDbType.VarChar,20),
					new SqlParameter("@dCallTitleDate", SqlDbType.DateTime),
					new SqlParameter("@sPosition", SqlDbType.VarChar,20),
					new SqlParameter("@sForeignLangaugeLevel", SqlDbType.VarChar,100),
					new SqlParameter("@sComputerTechnolic", SqlDbType.VarChar,100),
					new SqlParameter("@sEmail", SqlDbType.VarChar,50),
					new SqlParameter("@sPersonContactTel", SqlDbType.VarChar,20),
					new SqlParameter("@sFamilyContactTel", SqlDbType.VarChar,20),
					new SqlParameter("@sOtherContact", SqlDbType.VarChar,20),
					new SqlParameter("@sResidence", SqlDbType.VarChar,100),
					new SqlParameter("@sFamilyAddr", SqlDbType.VarChar,100),
					new SqlParameter("@sFamilyMember", SqlDbType.VarChar,300),
					new SqlParameter("@sStudyExperienct", SqlDbType.VarChar,400),
					new SqlParameter("@sWorkExperience", SqlDbType.VarChar,400),
					new SqlParameter("@dTryoutDate", SqlDbType.DateTime),
					new SqlParameter("@dFormalDate", SqlDbType.DateTime),
					new SqlParameter("@mPic", SqlDbType.Image),
					new SqlParameter("@dEndDate", SqlDbType.DateTime),
					new SqlParameter("@sRemark", SqlDbType.VarChar,100),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,20)};
            parameters[0].Value = dr["sEmpNo"];
            parameters[1].Value = dr["sEmpCName"];
            parameters[2].Value = dr["sEmpEName"];
            parameters[3].Value = dr["sIsInService"];
            parameters[4].Value = dr["sEmpContractID"];
            parameters[5].Value = dr["sResidenceType"];
            parameters[6].Value = dr["sInsureID"];
            parameters[7].Value = dr["sPayMentID"];
            parameters[8].Value = dr["sSex"];
            parameters[9].Value = dr["dBirthday"];
            parameters[10].Value = dr["dBabyBirthday"];
            parameters[11].Value = dr["sIdentityCard"];
            parameters[12].Value = dr["sNation"];
            parameters[13].Value = dr["sMarry"];
            parameters[14].Value = dr["sStature"];
            parameters[15].Value = dr["sPolityStatus"];
            parameters[16].Value = dr["sNativePlace"];
            parameters[17].Value = dr["sBrood"];
            parameters[18].Value = dr["sStudyExperience"];
            parameters[19].Value = dr["sGraduateInstitute"];
            parameters[20].Value = dr["sSpeciality"];
            parameters[21].Value = dr["dInCompanyDate"];
            parameters[22].Value = dr["iDepartmentID"];
            parameters[23].Value = dr["sEmpType"];
            parameters[24].Value = dr["sCallTitle"];
            parameters[25].Value = dr["dCallTitleDate"];
            parameters[26].Value = dr["sPosition"];
            parameters[27].Value = dr["sForeignLangaugeLevel"];
            parameters[28].Value = dr["sComputerTechnolic"];
            parameters[29].Value = dr["sEmail"];
            parameters[30].Value = dr["sPersonContactTel"];
            parameters[31].Value = dr["sFamilyContactTel"];
            parameters[32].Value = dr["sOtherContact"];
            parameters[33].Value = dr["sResidence"];
            parameters[34].Value = dr["sFamilyAddr"];
            parameters[35].Value = dr["sFamilyMember"];
            parameters[36].Value = dr["sStudyExperienct"];
            parameters[37].Value = dr["sWorkExperience"];
            parameters[38].Value = dr["dTryoutDate"];
            parameters[39].Value = dr["dFormalDate"];
            parameters[40].Value = dr["mPic"];
            parameters[41].Value = dr["dEndDate"];
            parameters[42].Value = dr["sRemark"];
            parameters[43].Value = dr["iFlag"];
            parameters[44].Value = dr["sUserID"];

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
            strSql.Append("UPDATE hrEmployee SET ");
            strSql.Append("sEmpNo=@sEmpNo,");
            strSql.Append("sEmpCName=@sEmpCName,");
            strSql.Append("sEmpEName=@sEmpEName,");
            strSql.Append("sIsInService=@sIsInService,");
            strSql.Append("sEmpContractID=@sEmpContractID,");
            strSql.Append("sResidenceType=@sResidenceType,");
            strSql.Append("sInsureID=@sInsureID,");
            strSql.Append("sPayMentID=@sPayMentID,");
            strSql.Append("sSex=@sSex,");
            strSql.Append("dBirthday=@dBirthday,");
            strSql.Append("dBabyBirthday=@dBabyBirthday,");
            strSql.Append("sIdentityCard=@sIdentityCard,");
            strSql.Append("sNation=@sNation,");
            strSql.Append("sMarry=@sMarry,");
            strSql.Append("sStature=@sStature,");
            strSql.Append("sPolityStatus=@sPolityStatus,");
            strSql.Append("sNativePlace=@sNativePlace,");
            strSql.Append("sBrood=@sBrood,");
            strSql.Append("sStudyExperience=@sStudyExperience,");
            strSql.Append("sGraduateInstitute=@sGraduateInstitute,");
            strSql.Append("sSpeciality=@sSpeciality,");
            strSql.Append("dInCompanyDate=@dInCompanyDate,");
            strSql.Append("iDepartmentID=@iDepartmentID,");
            strSql.Append("sEmpType=@sEmpType,");
            strSql.Append("sCallTitle=@sCallTitle,");
            strSql.Append("dCallTitleDate=@dCallTitleDate,");
            strSql.Append("sPosition=@sPosition,");
            strSql.Append("sForeignLangaugeLevel=@sForeignLangaugeLevel,");
            strSql.Append("sComputerTechnolic=@sComputerTechnolic,");
            strSql.Append("sEmail=@sEmail,");
            strSql.Append("sPersonContactTel=@sPersonContactTel,");
            strSql.Append("sFamilyContactTel=@sFamilyContactTel,");
            strSql.Append("sOtherContact=@sOtherContact,");
            strSql.Append("sResidence=@sResidence,");
            strSql.Append("sFamilyAddr=@sFamilyAddr,");
            strSql.Append("sFamilyMember=@sFamilyMember,");
            strSql.Append("sStudyExperienct=@sStudyExperienct,");
            strSql.Append("sWorkExperience=@sWorkExperience,");
            strSql.Append("dTryoutDate=@dTryoutDate,");
            strSql.Append("dFormalDate=@dFormalDate,");
            strSql.Append("mPic=@mPic,");
            strSql.Append("dEndDate=@dEndDate,");
            strSql.Append("sRemark=@sRemark,");
            strSql.Append("iFlag=@iFlag,");
            strSql.Append("sUserID=@sUserID");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@sEmpNo", SqlDbType.VarChar,20),
					new SqlParameter("@sEmpCName", SqlDbType.VarChar,20),
					new SqlParameter("@sEmpEName", SqlDbType.VarChar,20),
					new SqlParameter("@sIsInService", SqlDbType.VarChar,10),
					new SqlParameter("@sEmpContractID", SqlDbType.VarChar,20),
					new SqlParameter("@sResidenceType", SqlDbType.VarChar,20),
					new SqlParameter("@sInsureID", SqlDbType.VarChar,50),
					new SqlParameter("@sPayMentID", SqlDbType.VarChar,50),
					new SqlParameter("@sSex", SqlDbType.VarChar,10),
					new SqlParameter("@dBirthday", SqlDbType.DateTime),
					new SqlParameter("@dBabyBirthday", SqlDbType.DateTime),
					new SqlParameter("@sIdentityCard", SqlDbType.VarChar,18),
					new SqlParameter("@sNation", SqlDbType.VarChar,30),
					new SqlParameter("@sMarry", SqlDbType.VarChar,10),
					new SqlParameter("@sStature", SqlDbType.Int,4),
					new SqlParameter("@sPolityStatus", SqlDbType.VarChar,20),
					new SqlParameter("@sNativePlace", SqlDbType.VarChar,30),
					new SqlParameter("@sBrood", SqlDbType.VarChar,8),
					new SqlParameter("@sStudyExperience", SqlDbType.VarChar,10),
					new SqlParameter("@sGraduateInstitute", SqlDbType.VarChar,40),
					new SqlParameter("@sSpeciality", SqlDbType.VarChar,50),
					new SqlParameter("@dInCompanyDate", SqlDbType.DateTime),
					new SqlParameter("@iDepartmentID", SqlDbType.Int,4),
					new SqlParameter("@sEmpType", SqlDbType.VarChar,20),
					new SqlParameter("@sCallTitle", SqlDbType.VarChar,20),
					new SqlParameter("@dCallTitleDate", SqlDbType.DateTime),
					new SqlParameter("@sPosition", SqlDbType.VarChar,20),
					new SqlParameter("@sForeignLangaugeLevel", SqlDbType.VarChar,100),
					new SqlParameter("@sComputerTechnolic", SqlDbType.VarChar,100),
					new SqlParameter("@sEmail", SqlDbType.VarChar,50),
					new SqlParameter("@sPersonContactTel", SqlDbType.VarChar,20),
					new SqlParameter("@sFamilyContactTel", SqlDbType.VarChar,20),
					new SqlParameter("@sOtherContact", SqlDbType.VarChar,20),
					new SqlParameter("@sResidence", SqlDbType.VarChar,100),
					new SqlParameter("@sFamilyAddr", SqlDbType.VarChar,100),
					new SqlParameter("@sFamilyMember", SqlDbType.VarChar,300),
					new SqlParameter("@sStudyExperienct", SqlDbType.VarChar,400),
					new SqlParameter("@sWorkExperience", SqlDbType.VarChar,400),
					new SqlParameter("@dTryoutDate", SqlDbType.DateTime),
					new SqlParameter("@dFormalDate", SqlDbType.DateTime),
					new SqlParameter("@mPic", SqlDbType.Image),
					new SqlParameter("@dEndDate", SqlDbType.DateTime),
					new SqlParameter("@sRemark", SqlDbType.VarChar,100),
					new SqlParameter("@iFlag", SqlDbType.Int,4),
					new SqlParameter("@sUserID", SqlDbType.VarChar,20)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["sEmpNo"];
            parameters[2].Value = dr["sEmpCName"];
            parameters[3].Value = dr["sEmpEName"];
            parameters[4].Value = dr["sIsInService"];
            parameters[5].Value = dr["sEmpContractID"];
            parameters[6].Value = dr["sResidenceType"];
            parameters[7].Value = dr["sInsureID"];
            parameters[8].Value = dr["sPayMentID"];
            parameters[9].Value = dr["sSex"];
            parameters[10].Value = dr["dBirthday"];
            parameters[11].Value = dr["dBabyBirthday"];
            parameters[12].Value = dr["sIdentityCard"];
            parameters[13].Value = dr["sNation"];
            parameters[14].Value = dr["sMarry"];
            parameters[15].Value = dr["sStature"];
            parameters[16].Value = dr["sPolityStatus"];
            parameters[17].Value = dr["sNativePlace"];
            parameters[18].Value = dr["sBrood"];
            parameters[19].Value = dr["sStudyExperience"];
            parameters[20].Value = dr["sGraduateInstitute"];
            parameters[21].Value = dr["sSpeciality"];
            parameters[22].Value = dr["dInCompanyDate"];
            parameters[23].Value = dr["iDepartmentID"];
            parameters[24].Value = dr["sEmpType"];
            parameters[25].Value = dr["sCallTitle"];
            parameters[26].Value = dr["dCallTitleDate"];
            parameters[27].Value = dr["sPosition"];
            parameters[28].Value = dr["sForeignLangaugeLevel"];
            parameters[29].Value = dr["sComputerTechnolic"];
            parameters[30].Value = dr["sEmail"];
            parameters[31].Value = dr["sPersonContactTel"];
            parameters[32].Value = dr["sFamilyContactTel"];
            parameters[33].Value = dr["sOtherContact"];
            parameters[34].Value = dr["sResidence"];
            parameters[35].Value = dr["sFamilyAddr"];
            parameters[36].Value = dr["sFamilyMember"];
            parameters[37].Value = dr["sStudyExperienct"];
            parameters[38].Value = dr["sWorkExperience"];
            parameters[39].Value = dr["dTryoutDate"];
            parameters[40].Value = dr["dFormalDate"];
            parameters[41].Value = dr["mPic"];
            parameters[42].Value = dr["dEndDate"];
            parameters[43].Value = dr["sRemark"];
            parameters[44].Value = dr["iFlag"];
            parameters[45].Value = dr["sUserID"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM hrEmployee ");
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
            strSql.Append(" FROM vwhrEmployee ");
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
            strSql.Append(" * FROM vwhrEmployee ");
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

