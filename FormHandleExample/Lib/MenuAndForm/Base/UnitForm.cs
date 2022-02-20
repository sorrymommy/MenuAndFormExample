using FormAndMenu;
using System.Windows.Forms;

namespace MenuAndFormExample.Lib.MenuAndForm.Base
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
