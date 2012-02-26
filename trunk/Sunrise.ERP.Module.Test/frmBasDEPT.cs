using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.Module.Test
{
    public partial class frmBasDEPT : Sunrise.ERP.BaseForm.frmDynamicSingleForm
    {
        public frmBasDEPT(int formid, string formText) :
            base(formid, "DEPT")
        {
            InitializeComponent();
            this.Text = formText;
            CreateDynamicControl();
        }

        public override void initBase()
        {
            AddNotCopyFields(new string[] { "DEP", "NAME" });
            base.initBase();
        }
    }
}
