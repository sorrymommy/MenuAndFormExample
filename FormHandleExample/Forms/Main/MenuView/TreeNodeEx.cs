using MenuAndFormExample.Lib.FormAndMenu;
using System.Windows.Forms;

namespace MenuAndFormExample.Forms.Main.MenuView
{
    public class TreeNodeEx : TreeNode
    {
        public TreeNodeEx(UnitFormMenu unitFormMenu) : base(unitFormMenu.MenuName)
        {
            this.UnitFormMenu = unitFormMenu;
        }
        public UnitFormMenu UnitFormMenu { get; private set; }
    }
}
