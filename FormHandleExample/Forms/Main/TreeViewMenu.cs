using MenuAndFormExample.Forms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuAndFormExample.Forms.Main
{
    public class TreeViewMenu
    {
        private TreeView TreeView;
        public TreeViewMenu(TreeView treeView)
        {
            TreeView = treeView;

            TreeView.FullRowSelect = true;

            TreeView.DoubleClick += Event_TreeViewDoubleClick;
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

            if (UnitFormExecutor != null)
                UnitFormExecutor.Run(menu);
        }
        public void LoadTreeMenus(List<UnitFormMenu> unitFormMenus)
        {
            var rootMenus = unitFormMenus.Where(x=>x.Parent == null).Select(x=>x);

            LoadUnitFormMenus(TreeView.Nodes, rootMenus);

            foreach (TreeNode node in TreeView.Nodes)
                LoadUnitFormMenus(node.Nodes, unitFormMenus.Where(x => x.Parent == (node.Tag as UnitFormMenu)).Select(x => x));

            TreeView.ExpandAll();

            void LoadUnitFormMenus(TreeNodeCollection nodes, IEnumerable<UnitFormMenu> menus)
            {
                foreach (UnitFormMenu menuItem in menus)
                {
                    TreeNode node = nodes.Add(menuItem.MenuName);
                    node.Tag = menuItem;
                }
            }
        }
        public IUnitFormExecutor UnitFormExecutor { get; set; }
    }
}
