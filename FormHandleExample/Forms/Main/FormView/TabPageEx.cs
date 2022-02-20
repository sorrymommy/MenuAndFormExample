using MenuAndFormExample.Forms.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuAndFormExample.Forms.Main.FormView
{
    public class TabPageEx: TabPage
    {
        public TabPageEx(UnitForm unitForm   )
        {
            this.UnitForm = unitForm;

            UnitForm.TopLevel  = false;
            UnitForm.Parent    = this;

            UnitForm.FormBorderStyle = FormBorderStyle.None;
            UnitForm.Dock            = DockStyle.Fill;

            UnitForm.Show();
        }
        public UnitForm UnitForm{ get; private set; }
    }
}
