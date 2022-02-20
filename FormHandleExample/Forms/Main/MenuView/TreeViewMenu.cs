using MenuAndFormExample.Forms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuAndFormExample.Forms.Main.MenuView
{
    public class TreeViewMenu : IUnitFormMenuLoader
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

            TreeNodeEx node = treeView.SelectedNode as TreeNodeEx;

            if (node.UnitFormMenu.FormType != null)
            {
                if (UnitFormExecutor != null)
                    UnitFormExecutor.Run(node.UnitFormMenu);
            }

        }
        public void Load(List<UnitFormMenu> unitFormMenus)
        {
            TreeView.Nodes.Clear();

            var rootMenus = unitFormMenus.Where(x=>x.Parent == null).Select(x=>x);

            LoadUnitFormMenus(TreeView.Nodes, rootMenus);

            foreach (TreeNodeEx node in TreeView.Nodes)
                LoadUnitFormMenus(node.Nodes, unitFormMenus.Where(x => x.Parent == node.UnitFormMenu).Select(x => x));

            TreeView.ExpandAll();

            void LoadUnitFormMenus(TreeNodeCollection nodes, IEnumerable<UnitFormMenu> menus)
            {
                foreach (UnitFormMenu menuItem in menus)
                {
                    nodes.Add(new TreeNodeEx(menuItem));
                }
            }
        }
        public IUnitFormExecutor UnitFormExecutor { get; set; }
    }
}
