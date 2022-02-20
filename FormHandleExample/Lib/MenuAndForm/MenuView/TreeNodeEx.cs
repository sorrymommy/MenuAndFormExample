using FormAndMenu;
using System.Windows.Forms;

namespace MenuAndFormExample.Lib.MenuAndForm.Base
{
    public class TreeNodeEx : TreeNode
    {
        public TreeNodeEx(IUnitFormMenu unitFormMenu) : base(unitFormMenu.MenuName)
        {
            this.UnitFormMenu = unitFormMenu;
        }
        public IUnitFormMenu UnitFormMenu { get; private set; }
    }
}
