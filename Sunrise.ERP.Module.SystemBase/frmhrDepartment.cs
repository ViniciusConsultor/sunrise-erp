using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sunrise.ERP.Common;

namespace Sunrise.ERP.Module.SystemBase
{
    public partial class frmhrDepartment : Sunrise.ERP.BaseForm.frmSingleForm
    {
        public frmhrDepartment(int formid, string formtext)
            : base(formid, "Sunrise.ERP.SystemBase.DAL", "hrDepartmentDAL", false)
        {
            InitializeComponent();
            Text = formtext;

            txtsDeptNo.DataBindings.Add("EditValue", dsMain, "sDeptNo");
            txtsRemark.DataBindings.Add("EditValue", dsMain, "sRemark");
            txtsDeptName.DataBindings.Add("EditValue", dsMain, "sDeptName");
            txtsDeptEName.DataBindings.Add("EditValue", dsMain, "sDeptEName");
            lkpiCompanyID.DataBindings.Add("EditValue", dsMain, "iCompanyID");
            lkpParentID.DataBindings.Add("EditValue", dsMain, "ParentID");
            chkbIsLock.DataBindings.Add("EditValue", dsMain, "bIsLock");

            SystemPublic.InitLkpDept(lkpParentID);
            SystemPublic.InitLkpCompany(lkpiCompanyID);
            
        }

        public override bool DoAppend()
        {
            base.DoAppend();
            //新增默认值
            //自动生成部门编号
            SystemPublic.GetBillNo(FormID, (DataRowView)dsMain.Current);
            ((DataRowView)dsMain.Current).Row["bIsLock"] = 0;
            dsMain.EndEdit();
            return true;
        }

        public override void initBase()
        {
            AddNotNullFields(new string[] { "txtsDeptName", "txtsDeptEName", "lkpiCompanyID", "txtsDeptNo" });
            AddNotCopyFields(new string[] { "sUserID", "iFlag" });
            base.initBase();
        }
    }
}
