using FormAndMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuAndFormExample.Forms.Base
{
    public partial class UnitForm : Form, IUnitForm
    {
        public UnitForm()
        {
            InitializeComponent();
        }
        public IUnitFormMenu UnitFormMenu { get; set; }
        public Form Form
        {
            get
            {
                return this;
            }
        }
    }
}
