using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sunrise.ERP.DataAccess;

namespace Sunrise.ERP.Module.Test2
{
    public partial class frmTest3 : Sunrise.ERP.BaseForm.frmDynamicSingleForm
    {
        public frmTest3()
        {
            InitializeComponent();
        }
        public frmTest3(int formid, string formtext)
            : base(formid, "salTest")
        {
            InitializeComponent();
            Text = formtext;

            CreateDynamicControl();
            CreateMasterGridColumn(gvMain);
        }

        public override bool DoBeforceSaveInTrans(System.Data.SqlClient.SqlTransaction trans)
        {
            string sSql = "update salTest2 set sTest='aabbcc1' where id=1";
            DbHelperSQL.ExecuteSql(sSql, trans);
            return base.DoBeforceSaveInTrans(trans);
        }

        public override bool DoAfterSaveInTrans(System.Data.SqlClient.SqlTransaction trans)
        {
            string sSql = "update salTest2 set sTest='aabbcc13' where id=13";
            //throw new Exception();
            DbHelperSQL.ExecuteSql(sSql, trans);
            return base.DoAfterSaveInTrans(trans);
        }
    }
}
