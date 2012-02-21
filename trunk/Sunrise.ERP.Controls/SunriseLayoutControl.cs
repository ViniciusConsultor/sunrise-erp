using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

using Sunrise.ERP.Security;

namespace Sunrise.ERP.Controls
{
    public partial class SunriseLayoutControl : LayoutControl
    {
        /// <summary>
        /// Sunrise LayoutControl
        /// </summary>
        public SunriseLayoutControl()
        {
            InitializeComponent();
            this.AllowCustomizationMenu = SecurityCenter.IsAdmin;
            //设置Skin为Blue
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
        }
    }
}
