using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.Module.SystemManage
{
    public partial class frmsysEditUser : Sunrise.ERP.BaseForm.frmSingleForm
    {
        public frmsysEditUser()
            : base(0, "Sunrise.ERP.SystemManage.DAL", "sysUserDAL", false)
        {
            InitializeComponent();
            txtsPassword.DataBindings.Add("EditValue", dsMain, "sPassword");
            txtsRemark.DataBindings.Add("EditValue", dsMain, "sRemark");
            txtsUserCName.DataBindings.Add("EditValue", dsMain, "sUserCName");
            txtsUserEName.DataBindings.Add("EditValue", dsMain, "sUserEName");
            lkpParantID.DataBindings.Add("EditValue", dsMain, "ParentID");
            lkpsUserID.DataBindings.Add("EditValue", dsMain, "sUserID");
            cbxUserType.DataBindings.Add("EditValue", dsMain, "iUserType");
            chkbIsLock.DataBindings.Add("EditValue", dsMain, "bIsLock");
            Sunrise.ERP.Common.SystemPublic.InitLookUpBase(lkpsUserID, "SELECT ID,sEmpNo,sEmpCName,sEmpEName,sDeptNo,sDeptName,sDeptEName FROM vwhrEmployee", "sEmpNo",
                                                       "sEmpNo", "sEmpNo,sEmpCName,sEmpEName,sDeptNo,sDeptName", "员工编号,员工名称,员工英文名,部门编号,部门名称", "员工信息");
            Sunrise.ERP.Common.SystemPublic.InitLkpSystemUser(lkpParantID);
        }
        public override bool DoAppend()
        {
            Sunrise.ERP.BasePublic.Base.SetAllControlsReadOnly(this.pnlInfo, false);
            dsMain.AddNew();
            ((DataRowView)dsMain.Current).Row["iFlag"] = 0;
            ((DataRowView)dsMain.Current).Row["bIsLock"] = 0;
            ((DataRowView)dsMain.Current).Row["iUserType"] = 0;
            dsMain.EndEdit();
            IsDataChange = false;
            return true;
        }
        public override void initBase()
        {
            AddNotNullFields(new string[] { "lkpsUserID", "txtsUserCName", "txtsPassword" });
            base.initBase();
        }

        private void frmsysEditUser_Load(object sender, EventArgs e)
        {
            lkpsUserID.LookUpAfterPost += new Sunrise.ERP.Controls.SunriseLookUp.SunriseLookUpEvent(lkpsUserID_LookUpAfterPost);
        }

        bool lkpsUserID_LookUpAfterPost(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            dsMain.EndEdit();
            ((DataRowView)dsMain.Current).Row["EmpID"] = lkpsUserID.ReturnData.Rows[0]["ID"];
            ((DataRowView)dsMain.Current).Row["sUserCName"]=lkpsUserID.ReturnData.Rows[0]["sEmpCName"].ToString();
            ((DataRowView)dsMain.Current).Row["sUserEName"] = lkpsUserID.ReturnData.Rows[0]["sEmpEName"].ToString();            
            return txtsUserEName.Focus();
        }

        private void gvMain_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.Column.FieldName == "bIsLock")
            //{
            //    if (e.CellValue != null && (bool)e.CellValue)
            //    {
            //        e.Appearance.BackColor = System.Drawing.Color.Gray;
            //        //gvMain.Appearance.Row.BackColor = System.Drawing.Color.Gray;

            //    }
            //}
        }
        public override bool DoBeforeSave()
        {
            ((DataRowView)dsMain.Current).Row["sPassword"] = Sunrise.ERP.BaseControl.SysEncrypt.EncryptStr(((DataRowView)dsMain.Current).Row["sPassword"].ToString());
            dsMain.EndEdit();
            return base.DoBeforeSave();
        }
    }
}
