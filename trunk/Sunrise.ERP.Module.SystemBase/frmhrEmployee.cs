using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.Module.SystemBase
{
    public partial class frmhrEmployee : Sunrise.ERP.BaseForm.frmSingleForm
    {
        public frmhrEmployee(int formid, string formtext)
            : base(formid, "Sunrise.ERP.SystemBase.DAL", "hrEmployeeDAL")
        {
            InitializeComponent();
            if (formtext != "")
            {
                this.Text = formtext;
            }
            txtsEmpNo.DataBindings.Add("EditValue", dsMain, "sEmpNo");
            txtsEmpCName.DataBindings.Add("EditValue", dsMain, "sEmpCName");
            txtsEmpEName.DataBindings.Add("EditValue", dsMain, "sEmpEName");
            cbxsSex.DataBindings.Add("EditValue", dsMain, "sSex");
            txtsInsureID.DataBindings.Add("EditValue", dsMain, "sInsureID");
            txtsPayMentID.DataBindings.Add("EditValue", dsMain, "sPayMentID");
            txtsCallTitle.DataBindings.Add("EditValue", dsMain, "sCallTitle");
            txtsComputerTechnolic.DataBindings.Add("EditValue", dsMain, "sComputerTechnolic");
            txtsEmail.DataBindings.Add("EditValue", dsMain, "sEmail");
            txtsEmpContractID.DataBindings.Add("EditValue", dsMain, "sEmpContractID");
            txtsFamilyAddr.DataBindings.Add("EditValue", dsMain, "sFamilyAddr");
            txtsFamilyContactTel.DataBindings.Add("EditValue", dsMain, "sFamilyContactTel");
            txtsFamilyMember.DataBindings.Add("EditValue", dsMain, "sFamilyMember");
            txtsGraduateInstitute.DataBindings.Add("EditValue", dsMain, "sGraduateInstitute");
            txtsIdentityCard.DataBindings.Add("EditValue", dsMain, "sIdentityCard");
            txtsNativePlace.DataBindings.Add("EditValue", dsMain, "sNativePlace");
            txtsOtherContact.DataBindings.Add("EditValue", dsMain, "sOtherContact");
            txtsPersonContactTel.DataBindings.Add("EditValue", dsMain, "sPersonContactTel");
            txtsPosition.DataBindings.Add("EditValue", dsMain, "sPosition");
            txtsRemark.DataBindings.Add("EditValue", dsMain, "sRemark");
            txtsResidence.DataBindings.Add("EditValue", dsMain, "sResidence");
            txtsSpeciality.DataBindings.Add("EditValue", dsMain, "sSpeciality");
            txtsStature.DataBindings.Add("EditValue", dsMain, "sStature");
            txtsStudyExperienct.DataBindings.Add("EditValue", dsMain, "sStudyExperienct");
            txtsWorkExperience.DataBindings.Add("EditValue", dsMain, "sWorkExperience");
            cbxsBrood.DataBindings.Add("EditValue", dsMain, "sBrood");
            cbxsForeignLangaugeLevel.DataBindings.Add("EditValue", dsMain, "sForeignLangaugeLevel");
            cbxsIsInService.DataBindings.Add("EditValue", dsMain, "sIsInService");
            cbxsMarry.DataBindings.Add("EditValue", dsMain, "sMarry");
            cbxsNation.DataBindings.Add("EditValue", dsMain, "sNation");
            cbxsPolityStatus.DataBindings.Add("EditValue", dsMain, "sPolityStatus");
            cbxsStudyExperience.DataBindings.Add("EditValue", dsMain, "sStudyExperience");
            detdBirthday.DataBindings.Add("EditValue", dsMain, "dBirthday");
            detdCallTitleDate.DataBindings.Add("EditValue", dsMain, "dCallTitleDate");
            detdEndDate.DataBindings.Add("EditValue", dsMain, "dEndDate");
            detdFormalDate.DataBindings.Add("EditValue", dsMain, "dFormalDate");
            detdInCompanyDate.DataBindings.Add("EditValue", dsMain, "dInCompanyDate");
            detdTryoutDate.DataBindings.Add("EditValue", dsMain, "dTryoutDate");
            lkpsDeptID.DataBindings.Add("EditValue", dsMain, "iDepartmentID");
            lkpsEmpType.DataBindings.Add("EditValue", dsMain, "sEmpType");
            lkpsResidenceType.DataBindings.Add("EditValue", dsMain, "sResidenceType");
            picmPic.DataBindings.Add("EditValue", dsMain, "mPic");

            //初始化Lkp控件
            Sunrise.ERP.Common.SystemPublic.InitLkpDept(lkpsDeptID);
            Sunrise.ERP.Common.SystemPublic.InitLkpDataDict(lkpsEmpType, "1011");
            Sunrise.ERP.Common.SystemPublic.InitLkpDataDict(lkpsResidenceType, "1002");
        }
        public override void initBase()
        {
            AddNotNullFields(new string[] { "txtsEmpNo", "txtsEmpCName", "lkpsDeptID" });
            //FormID = 1001;
            base.initBase();
        }
        public override bool DoAppend()
        {
            base.DoAppend();
            Sunrise.ERP.Common.SystemPublic.GetBillNo(FormID, (DataRowView)dsMain.Current);
            dsMain.EndEdit();
            return true;
        }

        private void picmPic_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            if (picmPic.Image == null)
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore;
                ((DataRowView)dsMain.Current).Row["mPic"] = null;
            }
        }
    }
}
