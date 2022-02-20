using FormAndMenu;
using System.Windows.Forms;

namespace MenuAndFormExample.Forms.Main.RunningFormView
{
    public class ToolStripStatusLabelRunningUnitFormMenuView : IRunningUnitFormMenuView
    {
        private ToolStripStatusLabel ToolStripStatusLabel;
        public ToolStripStatusLabelRunningUnitFormMenuView(ToolStripStatusLabel toolStripStatusLabel)
        {
            this.ToolStripStatusLabel = toolStripStatusLabel;
        }
        public void Refresh(IUnitFormMenu menu)
        {
            if (menu == null)
                ToolStripStatusLabel.Text = string.Empty;
            else
                ToolStripStatusLabel.Text = $"RunningMenu : {menu.MenuName}[{menu.FormType.Name}]";
        }
    }
}
