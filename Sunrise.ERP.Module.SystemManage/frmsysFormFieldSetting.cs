using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Sunrise.ERP.DataAccess;
using Sunrise.ERP.Lang;
using Sunrise.ERP.Security;
using Sunrise.ERP.SystemManage.DAL;
using Sunrise.ERP.BaseControl;

namespace Sunrise.ERP.Module.SystemManage
{
    public partial class frmsysFormFieldSetting : Sunrise.ERP.BaseForm.frmBaseForm
    {
        private DataTable dtUser;
        private DataTable dtMenu;
        private DataTable dtField;

        sysFormFieldSettingDAL objDAL = new sysFormFieldSettingDAL();

        public frmsysFormFieldSetting(int formid,string formtext)
        {
            InitializeComponent();
            Text = formtext;
        }

        private void frmsysFormFieldSetting_Load(object sender, EventArgs e)
        {
            //初始化用户列表
            initUserList();
        }

        private void initUserList()
        {
            string sSql = "SELECT sUserID,sUserCName,sUserEName FROM sysUser WHERE bIsLock=0 AND iUserType=0";
            dtUser = DbHelperSQL.Query(sSql).Tables[0];
            gcUser.DataSource = dtUser;
        }

        private void initMenuList(string suserid)
        {
            dtMenu = DbHelperSQL.Query(SecurityCenter.GetMenuAuthSQL(suserid)).Tables[0];
        }

        private void initFieldList(string suserid, int formid)
        {
            //先取得已经设置过的数据
            DataTable dtTmp = objDAL.GetList("UserID='" + suserid + "' AND FormID=" + formid.ToString()).Tables[0];

            //根据FormID取得窗体上的所有字段数据
            //取得窗体上的字段数据优先以窗体上设置的可见和可编辑权限优先，比如说窗体上设置了不可见，那么用户设置这边是看不到该字段信息的
            //如果窗体上设置不可编辑，那么用户这边设置成为可编辑，那么以窗体上设置的不可编辑为准
            string sSql = "SELECT B.FormID,B.sTableName,A.sFieldName "
                        + "FROM sysDynamicFormDetail A "
                        + "LEFT JOIN sysDynamicFormMaster B ON A.MainID=B.ID "
                        + "WHERE B.FormID=" + formid.ToString() + " AND (ISNULL(A.bShowInGrid,1)=1 OR ISNULL(A.bShowInPanel,1)=1 )"
                        + "ORDER BY B.sFormType";
            DataTable dtTmp2 = DbHelperSQL.Query(sSql).Tables[0];
            //合并设置过的数据和窗体上的字段数据
            //以查询出来的窗体上的字段数据为准
            dtField = dtTmp.Clone();
            //如果没有设置过自定义数据，则默认加载窗体界面字段上的信息，默认所有都可见和可编辑
            if (dtTmp != null && dtTmp.Rows.Count > 0)
            {
                for (int i = 0; i < dtTmp2.Rows.Count; i++)
                {
                    bool isInField = false;
                    for (int j = 0; j < dtTmp.Rows.Count; j++)
                    {
                        //同时满足字段和表名相等
                        if (dtTmp2.Rows[i]["sFieldName"].ToString().ToLower() == dtTmp.Rows[j]["sFieldName"].ToString().ToLower() &&
                            dtTmp2.Rows[i]["sTableName"].ToString().ToLower() == dtTmp.Rows[j]["sTableName"].ToString().ToLower())
                        {
                            DataRow dr = dtField.NewRow();
                            dr["UserID"] = dtTmp.Rows[j]["UserID"];
                            dr["FormID"] = dtTmp.Rows[j]["FormID"];
                            dr["sTableName"] = dtTmp.Rows[j]["sTableName"];
                            dr["sFieldName"] = dtTmp.Rows[j]["sFieldName"];
                            dr["bVisiable"] = dtTmp.Rows[j]["bVisiable"];
                            dr["bEdit"] = dtTmp.Rows[j]["bEdit"];
                            dr["sUserID"] = SecurityCenter.CurrentUserID;
                            dtField.Rows.Add(dr);
                            isInField = true;
                            break;
                        }
                    }
                    if (!isInField)
                    {
                        DataRow dr = dtField.NewRow();
                        dr["UserID"] = suserid;
                        dr["FormID"] = formid;
                        dr["sTableName"] = dtTmp2.Rows[i]["sTableName"];
                        dr["sFieldName"] = dtTmp2.Rows[i]["sFieldName"];
                        dr["bVisiable"] = 1;
                        dr["bEdit"] = 1;
                        dr["sUserID"] = SecurityCenter.CurrentUserID;
                        dtField.Rows.Add(dr);
                    }
                }
            }
            else
            {
                for (int i = 0; i < dtTmp2.Rows.Count; i++)
                {
                    DataRow dr = dtField.NewRow();
                    dr["UserID"] = suserid;
                    dr["FormID"] = formid;
                    dr["sTableName"] = dtTmp2.Rows[i]["sTableName"];
                    dr["sFieldName"] = dtTmp2.Rows[i]["sFieldName"];
                    dr["bVisiable"] = 1;
                    dr["bEdit"] = 1;
                    dr["sUserID"] = SecurityCenter.CurrentUserID;
                    dtField.Rows.Add(dr);
                }
            }

        }

        //重新BaseForm方法，初始化设置保存按钮可用
        public override void DoBaseView()
        {
            
        }

        private void gvUser_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvUser.GetFocusedDataRow() != null)
            {
                //获取用户拥有的菜单权限
                initMenuList(gvUser.GetFocusedDataRow()["sUserID"].ToString());
                tvMenu.DataSource = dtMenu;
                tvMenu.KeyFieldName = "ID";
                tvMenu.ParentFieldName = "iParentID";
                tvMenu.Columns["iFormID"].Visible = false;
                tvMenu.Columns["sModuleName"].Visible = false;
                tvMenu.Columns["sFormClassName"].Visible = false;
                tvMenu.Columns["iSort"].Visible = false;
                tvMenu.Columns["sQuickMenu"].Visible = false;
            }
        }

        private void tvMenu_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (e.Node.HasChildren)
                e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            else e.NodeImageIndex = 2;
        }

        private void tvMenu_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (tvMenu.FocusedNode != null && !tvMenu.FocusedNode.HasChildren)
            {
                initFieldList(gvUser.GetFocusedDataRow()["sUserID"].ToString(), (int)tvMenu.FocusedNode.GetValue("iFormID"));
                gcField.DataSource = dtField;
            }
            else
                gcField.DataSource = null;
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            //设置字段无数据则直接退出
            if (gvField.RowCount <= 0)
                return;
            //base.btnSave_Click(sender, e);
            //先删除原来设置的数据，重新插入新的数据
            SqlTransaction trans = ConnectSetting.SysSqlConnection.BeginTransaction();
            string sSql = "DELETE FROM sysFormFieldSetting WHERE UserID='"
                        + gvUser.GetFocusedDataRow()["sUserID"].ToString() + "' AND FormID="
                        + tvMenu.FocusedNode.GetValue("iFormID").ToString();
            try
            {
                DbHelperSQL.ExecuteSql(sSql, trans);
                foreach (DataRow dr in dtField.Rows)
                {
                    objDAL.Add(dr, trans);
                }
                trans.Commit();
                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("SaveSuccess"));

            }
            catch
            {
                trans.Rollback();
                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("SaveSuccess"));
            }
        }
    }
}
