using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sunrise.ERP.Common;

namespace Sunrise.ERP.Module.SystemManage
{
    public partial class frmsysEditUser : Sunrise.ERP.BaseForm.frmSingleForm
    {
        private bool isPasswordChanged = false;
        public frmsysEditUser(int formid, string formtext)
            : base(formid, "Sunrise.ERP.SystemManage.DAL", "sysUserDAL", false)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(formtext))
                Text = formtext;
            txtsUserID.DataBindings.Add("EditValue", dsMain, "sUserID");
            txtsPassword.DataBindings.Add("EditValue", dsMain, "sPassword");
            txtsRemark.DataBindings.Add("EditValue", dsMain, "sRemark");
            txtsUserCName.DataBindings.Add("EditValue", dsMain, "sUserCName");
            txtsUserEName.DataBindings.Add("EditValue", dsMain, "sUserEName");
            lkpParentID.DataBindings.Add("EditValue", dsMain, "ParentID");
            lkpDeptID.DataBindings.Add("EditValue", dsMain, "DeptID");
            cbxUserType.DataBindings.Add("EditValue", dsMain, "iUserType");
            chkbIsLock.DataBindings.Add("EditValue", dsMain, "bIsLock");

            SystemPublic.InitLkpSystemUser(lkpParentID);
            SystemPublic.InitLkpDept(lkpDeptID);
            lkpDeptID.AutoSetValue("sDeptName", "sDeptName");
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
            AddNotNullFields(new string[] { "txtsUserID", "txtsUserCName", "txtsPassword", "lkpDeptID" });
            AddNotCopyFields(new string[] { "sUserID", "sUserCName", "sUserEName", "sPassword" });
            base.initBase();
        }

        public override bool DoBeforeSave()
        {
            if (isPasswordChanged)
            {
                ((DataRowView)dsMain.Current).Row["sPassword"] = Sunrise.ERP.BaseControl.SysEncrypt.EncryptStr(((DataRowView)dsMain.Current).Row["sPassword"].ToString());
                dsMain.EndEdit();
                isPasswordChanged = false;
            }
            return base.DoBeforeSave();
        }

        private void txtsPassword_TextChanged(object sender, EventArgs e)
        {
            if (FormDataFlag != Sunrise.ERP.BasePublic.DataFlag.dsBrowse)
                isPasswordChanged = true;
        }
    }
}
