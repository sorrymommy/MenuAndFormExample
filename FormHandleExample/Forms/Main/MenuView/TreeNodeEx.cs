using MenuAndFormExample.Forms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
