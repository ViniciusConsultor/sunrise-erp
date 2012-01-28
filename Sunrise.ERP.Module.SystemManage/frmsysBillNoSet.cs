using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.Module.SystemManage
{
    public partial class frmsysBillNoSet : Sunrise.ERP.BaseForm.frmSingleForm
    {
        public frmsysBillNoSet(int formid, string formtext)
            : base(formid, "Sunrise.ERP.SystemManage.DAL", "sysBillNoSetDAL")
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(formtext))
                Text = formtext;
            lkpDateFormatStr.DataBindings.Add("EditValue", dsMain, "sDateType");
            txtsFieldName.DataBindings.Add("EditValue", dsMain, "sFieldName");
            lkpFormID.DataBindings.Add("EditValue", dsMain, "iFormID");
            lkpTableName.DataBindings.Add("EditValue", dsMain, "sTableName");
            txtFormID.DataBindings.Add("EditValue", dsMain, "iFormID");
            txtNoFormatStr.DataBindings.Add("EditValue", dsMain, "sSerialType");
            txtPreFormatStr.DataBindings.Add("EditValue", dsMain, "sPrefix");

            Sunrise.ERP.Common.SystemPublic.InitLkpDataDict(lkpDateFormatStr, "1012");
            Sunrise.ERP.Common.SystemPublic.InitLkpFormID(lkpFormID);
            Sunrise.ERP.Common.SystemPublic.InitLookUpBase(lkpTableName, "SELECT TOP 100 PERCENT name,id FROM sysobjects WHERE xtype = 'U' ORDER BY name", "name", "name", "name", "数据表名", "数据表");
            //Sunrise.ERP.Common.SystemPublic.InitLookUpBase(txtsFieldName, "SELECT name, length FROM syscolumns Order BY colid", "name", "name", "name", "字段名称", "字段名称");
        }

        public override void initBase()
        {
            AddNotNullFields(new string[] { "lkpFormID", "lkpTableName", "txtsFieldName", "txtNoFormatStr" });
            base.initBase();
        }

        private void frmsysBillNoSet_Load(object sender, EventArgs e)
        {
        }
    }
}
