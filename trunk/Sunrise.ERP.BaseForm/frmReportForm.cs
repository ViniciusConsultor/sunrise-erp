using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.BaseForm
{
    public partial class frmReportForm : Sunrise.ERP.BaseForm.frmForm
    {
        public frmReportForm(int formid, string formtext)
            : base(formid, formtext)
        {
            InitializeComponent();
        }
    }
}
