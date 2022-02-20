using MenuAndFormExample.Forms.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MenuAndFormExample.Forms.Menu_02
{
    public partial class Child02_02 : MenuAndFormExample.Forms.Base.UnitForm
    {
        public Child02_02()
        {
            InitializeComponent();
        }
        private void LoadMenu()
        {
            List<UnitFormMenu> unitFormMenus = new List<UnitFormMenu>();
            unitFormMenus.Add(new UnitFormMenu());
        }
    }
}
