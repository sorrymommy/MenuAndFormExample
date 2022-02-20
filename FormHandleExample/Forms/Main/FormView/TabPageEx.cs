using FormAndMenu;
using System.Windows.Forms;

namespace MenuAndFormExample.Forms.Main.FormView
{
    public class TabPageEx : TabPage
    {
        public TabPageEx(IUnitForm unitForm)
        {
            this.UnitForm = unitForm;

            Form form = unitForm.Form;
            form.TopLevel = false;
            form.Parent = this;

            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            form.Show();
        }
        public IUnitForm UnitForm { get; private set; }
    }
}
