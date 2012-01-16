using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.Module.Test
{
    public partial class frmTest : Sunrise.ERP.BaseForm.frmDynamicSingleForm
    {
        public frmTest(int formid, string formtext)
            : base(formid, "salTest")
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(formtext))
                Text = formtext;
            CreateDynamicControl();
            InitDataBindings();
        }

        private void mtxtsRemark_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
