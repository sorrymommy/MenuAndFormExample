using FormHandleExampe.Forms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormHandleExampe.Forms.Main
{
    public class TreeViewMenu
    {
        private TreeView treeView;
        public TreeViewMenu(TreeView treeView)
        {
            this.treeView = treeView;

            this.treeView.DoubleClick += Event_TreeViewDoubleClick;

            this.treeView.FullRowSelect = true;
        }
        private void Event_TreeViewDoubleClick(object sender, EventArgs e)
        {
            TreeView treeView = sender as TreeView ;

            if (treeView == null)
                return;

            TreeNode node = treeView.SelectedNode;
            UnitFormMenu menu = node.Tag as UnitFormMenu;

            if (menu == null)
                return;

            if (menu.FormType == null)
                return;

            UnitFormCreator.Run(menu);
        }

        public void LoadMenu(IEnumerable<UnitFormMenu> unitFormMenus)
        {
            var rootMenus = unitFormMenus.Where(x=>x.Parent == null).Select(x=>x);

            LoadUnitFormMenus(treeView.Nodes, rootMenus);

            foreach (TreeNodeEx node in treeView.Nodes)
                LoadUnitFormMenus(node.Nodes, unitFormMenus.Where(x => x.Parent == node.Menu).Select(x => x));

            void LoadUnitFormMenus(TreeNodeCollection nodes, IEnumerable<UnitFormMenu> menus)
            {
                foreach (UnitFormMenu menuItem in menus)
                {
                    nodes.Add(new TreeNodeEx(menuItem));
                }
            }

            this.treeView.ExpandAll();

        }

        public IUnitFormCreator UnitFormCreator { get; set; }

    }
}
