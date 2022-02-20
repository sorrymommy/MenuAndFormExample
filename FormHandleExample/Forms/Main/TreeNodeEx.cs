using FormHandleExampe.Forms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormHandleExampe.Forms.Main
{
    public class TreeNodeEx : TreeNode
    {
        public TreeNodeEx(UnitFormMenu menu) : base(menu.MenuName)
        {
            this.Menu = menu;
        }
        public UnitFormMenu Menu { get; private set; }
    }
}
