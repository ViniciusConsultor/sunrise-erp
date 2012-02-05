using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Sunrise.ERP.Lang;

namespace Sunrise.ERP.Security
{
    /// <summary>
    /// 系统权限处理中心
    /// </summary>
    public class SecurityCenter
    {

        public SecurityCenter() { }

        #region 属性

        private static DataTable _dt;
        private string _strdept = "";
        private string _strunder = "";
        private string _strselfandunder = "";
        private static string _suserid = "";
        private static bool _isadmin = true;
        private static DataSet _dsMenu;

        /// <summary>
        /// 窗体权限表
        /// </summary>
        public static DataTable FormSecurityData
        {
            get
            {
                if (_dt == null && CurrentUserID != "")
                {
                    string sDataSql = "SELECT DISTINCT A.MenuID, E.iFormID, A.iView, A.iAdd, A.iEdit, A.iDelete, "
                            + "A.iPrint, A.iNum, A.iPrice "
                            + "FROM sysRolesRights A "
                            + "LEFT JOIN sysRoles B ON A.RoleID=B.ID "
                            + "LEFT JOIN sysRolesUser C ON B.ID=C.RoleID "
                            + "LEFT JOIN sysUser D ON C.UserID=D.ID "
                            + "LEFT JOIN sysMenu E ON A.MenuID=E.ID "
                            + "WHERE D.sUserID='" + SecurityCenter.CurrentUserID + "'";
                    _dt = Sunrise.ERP.DataAccess.DbHelperSQL.Query(sDataSql).Tables[0];
                    return _dt;
                }
                else
                {
                    return _dt;
                }
            }
        }

        /// <summary>
        /// 获取用户同部门所有用户字符串
        /// </summary>
        public string GetUserDeptStr
        {
            get
            {
                if (_strdept == "")
                {
                    _strdept = GetUserStr("dept");
                }
                return _strdept;
            }
        }

        /// <summary>
        /// 获取用户下属字符串
        /// </summary>
        public string GetUserUnderlingStr
        {
            get
            {
                if (_strunder == "")
                {
                    _strunder = GetUserStr("under");
                }
                return _strunder;
            }
        }

        /// <summary>
        /// 获取用户及下属字符串
        /// </summary>
        public string GetUserSelfAndUnderlingStr
        {
            get
            {
                if (_strselfandunder == "")
                {
                    _strselfandunder = GetUserStr("selfandunder");
                }
                return _strselfandunder;
            }
        }


        /// <summary>
        /// 获取当前用户ID
        /// </summary>
        public static string CurrentUserID
        {
            get
            {
                return _suserid;
            }
            set
            {
                _suserid = value;
            }
        }

        static string _suser = "";
        /// <summary>
        /// 返回当前登录用户名
        /// </summary>
        public static string CurrentUserName
        {
            get
            {
                return _suser;
            }
        }

        static string _CurrentDeptName = "";
        /// <summary>
        /// 返回当前登录用户所属部门名称
        /// </summary>
        public static string CurrentDeptName
        {
            get
            {
                return _CurrentDeptName;
            }
        }

        /// <summary>
        /// 当前用户是否为超级用户
        /// </summary>
        public static bool IsAdmin
        {
            get
            {
                if (_isadmin)
                {
                    object obj = Sunrise.ERP.DataAccess.DbHelperSQL.GetSingle("SELECT 1 FROM sysUser WHERE iUserType=1 AND sUserID='" + CurrentUserID + "'");
                    if (obj != null && obj.ToString() == "1")
                    {
                        _isadmin = true;
                    }
                    else
                    {
                        _isadmin = false;
                    }
                }
                return _isadmin;
            }
        }

        /// <summary>
        /// 系统菜单数据
        /// </summary>
        public static DataSet SysMenuDataSet
        {
            get
            {
                if (_dsMenu == null)
                {
                    _dsMenu = Sunrise.ERP.DataAccess.DbHelperSQL.Query(GetMenuAuthSQL());
                }
                return _dsMenu;
            }
        }
        #endregion


        #region 公共方法

        /// <summary>
        /// 获取窗体操作权限(包括具体的权限值)
        /// </summary>
        /// <param name="formid">窗体ID</param>
        /// <returns></returns>
        public List<Hashtable> GetFormSecurity(int formid)
        {
            List<Hashtable> Result = new List<Hashtable>();
            DataRow[] drDate = FormSecurityData.Select("iFormID=" + formid.ToString());
            foreach(DataRow dr in drDate)
            {
                Hashtable htTemp = new Hashtable();
                htTemp.Add(SecurityOperation.View, GetOperationValue(dr["iView"]));
                htTemp.Add(SecurityOperation.Add, GetOperationValue(dr["iAdd"]));
                htTemp.Add(SecurityOperation.Edit, GetOperationValue(dr["iEdit"]));
                htTemp.Add(SecurityOperation.Delete, GetOperationValue(dr["iDelete"]));
                htTemp.Add(SecurityOperation.Print, GetOperationValue(dr["iPrint"]));
                htTemp.Add(SecurityOperation.Num, GetOperationValue(dr["iNum"]));
                htTemp.Add(SecurityOperation.Price, GetOperationValue(dr["iPrice"]));
                Result.Add(htTemp);
            }
            return Result;
        }

        /// <summary>
        /// 根据用户获取相应的字符串（部门，下属，个人及下属）
        /// </summary>
        /// <param name="type">部门-dept,下属-under,个人及下属-selfandunder</param>
        /// <returns></returns>
        private string GetUserStr(string type)
        {
            string str = "";
            string sSql = "";
            //部门
            if (type == "dept")
            {
                sSql = "SELECT A.sUserID FROM sysUser A "
                     + "WHERE A.DeptID IN "
                     + "(SELECT AA.DeptID FROM sysUser AA WHERE AA.sUserID='" + CurrentUserID + "')";
            }
            //下属
            else if (type == "under")
            {
                sSql = "SELECT A.sUserID "
                     + "FROM sysUser A "
                     + "LEFT JOIN sysUser B ON A.ParentID=B.ID "
                     + "WHERE B.sUserID='" + CurrentUserID + "' AND A.ID<>B.ParentID ";
            }
            //个人及下属
            else if (type == "selfandunder")
            {
                sSql = "SELECT A.sUserID "
                    + "FROM sysUser A "
                    + "LEFT JOIN sysUser B ON A.ParentID=B.ID "
                    + "WHERE B.sUserID='" + CurrentUserID + "' AND A.ID<>B.ParentID "
                    + "UNION ALL "
                    + "SELECT C.sUserID FROM sysUser C WHERE C.sUserID='" + CurrentUserID + "'";
            }
            if (sSql != "")
            {
                DataTable dt = Sunrise.ERP.DataAccess.DbHelperSQL.Query(sSql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (str == "")
                        {
                            str += dr["sUserID"];
                        }
                        else
                        {
                            str += "," + dr["sUserID"];
                        }
                    }
                }
            }
            return str;
        }

        /// <summary>
        /// 获取权限值类型
        /// </summary>
        /// <param name="operation">权限操作值</param>
        /// <returns></returns>
        public SecurityOperationValue GetOperationValue(object operation)
        {
            int iOperation = Convert.ToInt32(operation);
            switch (iOperation)
            {
                //无权限 
                case 0:
                    {
                        return SecurityOperationValue.None;
                    }
                //个人
                case 1:
                    {
                        return SecurityOperationValue.Self;
                    }
                //下属
                case 2:
                    {
                        return SecurityOperationValue.Underling;
                    }
                //个人及下属
                case 3:
                    {
                        return SecurityOperationValue.SelfAndUnderling;
                    }
                //部门
                case 4:
                    {
                        return SecurityOperationValue.Department;
                    }
                //所有
                case 5:
                    {
                        return SecurityOperationValue.All;
                    }

                default:
                    {
                        return SecurityOperationValue.None;
                    }
            }
        }

        /// <summary>
        /// 获取窗体查询权限SQL
        /// </summary>
        /// <param name="st">数据显示类型</param>
        /// <param name="formid"></param>
        /// <returns></returns>
        public string GetAuthSQL(ShowType st, int formid)
        {
            string sResult = "(";
            //管理员(超级用户)则查看全部数据
            if (IsAdmin)
            {
                if (st == ShowType.FormShow)
                {
                    sResult += " iFlag IN (0,1,2,3)) ";
                }
                else
                {
                    sResult += " 1=1) ";
                }
            }
            else
            {
                foreach (Hashtable ht in GetFormSecurity(formid))
                {
                    string sLastAuthSQL = "";
                    switch ((SecurityOperationValue)ht[SecurityOperation.View])
                    {
                        case SecurityOperationValue.None:
                            {
                                if (sLastAuthSQL != " (1=2) OR")
                                {
                                    sResult += " (1=2) OR";
                                    sLastAuthSQL = " (1=2) OR";
                                }
                                break;
                            }
                        case SecurityOperationValue.Self:
                            {
                                if (st == ShowType.FormShow)
                                {
                                    if (sLastAuthSQL != " (iFlag IN (0,1,2,3) AND sUserID='" + CurrentUserID + "') OR")
                                    {
                                        sResult += " (iFlag IN (0,1,2,3) AND sUserID='" + CurrentUserID + "') OR";
                                        sLastAuthSQL = " (iFlag IN (0,1,2,3) AND sUserID='" + CurrentUserID + "') OR";
                                    }
                                    break;
                                }
                                else
                                {
                                    if (sLastAuthSQL != " (sUserID='" + CurrentUserID + "') OR")
                                    {
                                        sResult += " (sUserID='" + CurrentUserID + "') OR";
                                        sLastAuthSQL = " (sUserID='" + CurrentUserID + "') OR";
                                    }
                                    break;
                                }
                            }
                        case SecurityOperationValue.Underling:
                            {
                                if (st == ShowType.FormShow)
                                {
                                    if (sLastAuthSQL != " (iFlag IN (0,1,2,3) AND sUserID IN('" + GetUserUnderlingStr.Replace(",", "','") + "')) OR")
                                    {
                                        sResult += " (iFlag IN (0,1,2,3) AND sUserID IN('" + GetUserUnderlingStr.Replace(",", "','") + "')) OR";
                                        sLastAuthSQL = " (iFlag IN (0,1,2,3) AND sUserID IN('" + GetUserUnderlingStr.Replace(",", "','") + "')) OR";
                                    }
                                    break;
                                }
                                else
                                {
                                    if (sLastAuthSQL != " (sUserID IN('" + GetUserUnderlingStr.Replace(",", "','") + "')) OR")
                                    {
                                        sResult += " (sUserID IN('" + GetUserUnderlingStr.Replace(",", "','") + "')) OR";
                                        sLastAuthSQL = " (sUserID IN('" + GetUserUnderlingStr.Replace(",", "','") + "')) OR";
                                    }
                                    break;
                                }
                            }
                        case SecurityOperationValue.SelfAndUnderling:
                            {
                                if (st == ShowType.FormShow)
                                {
                                    if (sLastAuthSQL != " (iFlag IN (0,1,2,3) AND sUserID IN('" + GetUserSelfAndUnderlingStr.Replace(",", "','") + "')) OR")
                                    {
                                        sResult += " (iFlag IN (0,1,2,3) AND sUserID IN('" + GetUserSelfAndUnderlingStr.Replace(",", "','") + "')) OR";
                                        sLastAuthSQL = " (iFlag IN (0,1,2,3) AND sUserID IN('" + GetUserSelfAndUnderlingStr.Replace(",", "','") + "')) OR";
                                    }
                                    break;
                                }
                                else
                                {
                                    if (sLastAuthSQL != " (sUserID IN('" + GetUserSelfAndUnderlingStr.Replace(",", "','") + "')) OR")
                                    {
                                        sResult += " (sUserID IN('" + GetUserSelfAndUnderlingStr.Replace(",", "','") + "')) OR";
                                        sLastAuthSQL = " (sUserID IN('" + GetUserSelfAndUnderlingStr.Replace(",", "','") + "')) OR";
                                    }
                                    break;
                                }
                            }
                        case SecurityOperationValue.Department:
                            {
                                if (st == ShowType.FormShow)
                                {
                                    if (sLastAuthSQL != " (iFlag IN (0,1,2,3) AND sUserID IN('" + GetUserDeptStr.Replace(",", "','") + "')) OR")
                                    {
                                        sResult += " (iFlag IN (0,1,2,3) AND sUserID IN('" + GetUserDeptStr.Replace(",", "','") + "')) OR";
                                        sLastAuthSQL = " (iFlag IN (0,1,2,3) AND sUserID IN('" + GetUserDeptStr.Replace(",", "','") + "')) OR";
                                    }
                                    break;
                                }
                                else
                                {
                                    if (sLastAuthSQL != " (sUserID IN('" + GetUserDeptStr.Replace(",", "','") + "')) OR")
                                    {
                                        sResult += " (sUserID IN('" + GetUserDeptStr.Replace(",", "','") + "')) OR";
                                        sLastAuthSQL = " (sUserID IN('" + GetUserDeptStr.Replace(",", "','") + "')) OR";
                                    }
                                    break;
                                }
                            }
                        case SecurityOperationValue.All:
                            {
                                if (st == ShowType.FormShow)
                                {
                                    if (sLastAuthSQL != " (iFlag IN (0,1,2,3)) OR")
                                    {
                                        sResult += " (iFlag IN (0,1,2,3)) OR";
                                        sLastAuthSQL = " (iFlag IN (0,1,2,3)) OR";
                                    }
                                    break;
                                }
                                else
                                {
                                    if (sLastAuthSQL != " (1=1) OR")
                                    {
                                        sResult += " (1=1) OR";
                                        sLastAuthSQL = " (1=1) OR";
                                    }
                                    break;
                                }
                            }
                        default:
                            {
                                if (sLastAuthSQL != " (1=2) OR")
                                {
                                    sResult += " (1=2) OR";
                                    sLastAuthSQL = " (1=2) OR";
                                }
                                break;
                            }
                    }
                }
                if (sResult.EndsWith("OR"))
                {
                    sResult = sResult.Substring(0, sResult.Length - 3) + ")";
                }

            }
            return sResult;
        }

        /// <summary>
        /// 获取菜单权限SQL
        /// </summary>
        /// <returns></returns>
        public static string GetMenuAuthSQL()
        {
            string sResult = "";
            //用户是admin或者是超级用户的时候显示所有菜单
            if (CurrentUserID == "admin" || IsAdmin)
            {
                sResult = "SELECT A.ID,A.iFormID,"
                        + (LangCenter.Instance.IsDefaultLanguage ? "A.sMenuName" : "A.sMenuEngName AS sMenuName")
                        + ",A.iParentID,A.sModuleName,A.sFormClassName,A.iSort,A.sQuickMenu FROM sysMenu A ORDER BY A.iSort";

            }
            else
            {
                sResult = "SELECT DISTINCT E.ID,E.iFormID,"
                        + (LangCenter.Instance.IsDefaultLanguage ? "E.sMenuName" : "E.sMenuEngName AS sMenuName")
                        + ",E.iParentID,E.sModuleName,E.sFormClassName,E.iSort,E.sQuickMenu "
                        + "FROM sysRolesRights A "
                        + "LEFT JOIN sysRoles B ON A.RoleID=B.ID "
                        + "LEFT JOIN sysRolesUser C ON B.ID=C.RoleID "
                        + "LEFT JOIN sysUser D ON C.UserID=D.ID "
                        + "LEFT JOIN sysMenu E ON A.MenuID=E.ID "
                        + "WHERE D.sUserID='" + CurrentUserID + "' "
                        + "ORDER BY E.iSort";

            }
            return sResult;
        }

        /// <summary>
        /// 获取所有菜单SQL
        /// </summary>
        /// <returns></returns>
        public static string GetAllMenuSQL()
        {
            return "SELECT A.ID,A.iFormID,A.sMenuName,A.sMenuEngName,A.iParentID,A.sModuleName,"
                   + "A.sFormClassName,A.iSort,A.sQuickMenu FROM sysMenu A ORDER BY A.iSort";
        }

        /// <summary>
        /// 判断权限
        /// 用于判断查询,修改,删除,打印权限
        /// </summary>
        /// <param name="so">权限操作类型</param>
        /// <param name="formid">窗体ID</param>
        /// <param name="lano">制单人</param>
        /// <returns></returns>
        public bool CheckAuth(SecurityOperation so, int formid, string suserid)
        {
            bool bResult = false;
            //如果是超级用户则直接返回True
            if (IsAdmin)
            {
                bResult = true;
            }
            else if (suserid == "")
            {
                bResult = true;
            }
            else
            {
                foreach (Hashtable ht in GetFormSecurity(formid))
                {
                    ////增加权限，只要设置的不为None，其他的都具有
                    //if (so == SecurityOperation.Add)
                    //{
                    //    if ((SecurityOperationValue)GetFormSecurity(formid)[so] != SecurityOperationValue.None)
                    //    {
                    //        bResult = true;
                    //    }
                    //}
                    //else
                    //{
                    switch ((SecurityOperationValue)ht[so])
                    {
                        case SecurityOperationValue.None:
                            {
                                bResult = false;
                                break;
                            }
                        case SecurityOperationValue.Self:
                            {
                                bResult = CurrentUserID.ToLower() == suserid.ToLower();
                                if (bResult)
                                {
                                    return bResult;
                                }
                                break;
                            }
                        case SecurityOperationValue.Underling:
                            {
                                bResult = GetUserUnderlingStr.ToLower().Contains(suserid.ToLower());
                                if (bResult)
                                {
                                    return bResult;
                                }
                                break;
                            }
                        case SecurityOperationValue.SelfAndUnderling:
                            {
                                bResult = GetUserSelfAndUnderlingStr.ToLower().Contains(suserid.ToLower());
                                if (bResult)
                                {
                                    return bResult;
                                }
                                break;
                            }
                        case SecurityOperationValue.Department:
                            {
                                bResult = GetUserDeptStr.ToLower().Contains(suserid.ToLower());
                                if (bResult)
                                {
                                    return bResult;
                                }
                                break;
                            }
                        case SecurityOperationValue.All:
                            {
                                bResult = true;
                                if (bResult)
                                {
                                    return bResult;
                                }
                                break;
                            }
                        default:
                            {
                                bResult = false;
                                break;
                            }
                    }
                }
            }
            return bResult;
        }

        /// <summary>
        /// 判断权限
        /// 用于判断增加,单价,数量权限
        /// </summary>
        /// <param name="so">权限操作类型</param>
        /// <param name="formid">窗体ID</param>
        /// <returns></returns>
        public bool CheckAuth(SecurityOperation so, int formid)
        {
            bool bResult = false;
            //如果是超级用户则直接返回True
            if (IsAdmin)
            {
                bResult = true;
            }
            else
            {
                foreach (Hashtable ht in GetFormSecurity(formid))
                {
                    //增加,单价,数量权限，只要设置的不为None，其他的都具有
                    if (so == SecurityOperation.Add || so == SecurityOperation.Num || so == SecurityOperation.Price)
                    {
                        if ((SecurityOperationValue)ht[so] != SecurityOperationValue.None)
                        {
                            bResult = true;
                            if (bResult)
                            {
                                return bResult;
                            }
                        }
                    }
                }
            }
            return bResult;
        }

        /// <summary>
        /// 检测用户登录情况,0-用户不存在或者登录异常，1-登录成功，2-密码错误
        /// </summary>
        /// <param name="suser">登录用户名</param>
        /// <param name="spassword">登录密码</param>
        /// <returns>返回结果，0-用户不存在或者登录异常，1-登录成功，2-密码错误</returns>
        public static int CheckSystemLogin(string suser,string spassword)
        {
            int iResult = 0;
            try
            {
                string sSql = "SELECT sUserCName,sPassword,sDeptName FROM vwsysUser WHERE sUserID='" + suser + "'";
                string spwd = "";
                DataTable dtTemp = Sunrise.ERP.DataAccess.DbHelperSQL.Query(sSql).Tables[0];
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    spwd = dtTemp.Rows[0]["sPassword"].ToString();
                }
                else
                {
                    return 0;
                }
                if (spassword == Sunrise.ERP.BaseControl.SysEncrypt.DecryptStr(spwd))
                {
                    iResult = 1;
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        //设置当前登录用户
                        _suserid = suser;
                        _suser = dtTemp.Rows[0]["sUserCName"].ToString();
                        _CurrentDeptName = dtTemp.Rows[0]["sDeptName"].ToString();
                    }
                }
                else
                {
                    iResult = 2;
                }
                return iResult;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion
    }
}
