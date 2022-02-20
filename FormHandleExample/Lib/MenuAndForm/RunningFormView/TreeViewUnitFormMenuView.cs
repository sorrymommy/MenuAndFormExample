using FormAndMenu;
using System.Windows.Forms;

namespace MenuAndFormExample.Lib.MenuAndForm.Base
{
    public class TreeViewUnitFormMenuView : IRunningUnitFormMenuView
    {
        private TreeView TreeView;
        public TreeViewUnitFormMenuView(TreeView treeView)
        {
            this.TreeView = treeView;
        }

        public void Refresh(IUnitFormMenu menu)
        {
            TreeNode node = GetNode(TreeView.Nodes);

            TreeView.SelectedNode = node;
            TreeView.Focus();

            TreeNodeEx GetNode(TreeNodeCollection nodes)
            {
                foreach (TreeNodeEx tn in nodes)
                {
                    if (tn.Nodes.Count > 0)
                    {
                        TreeNodeEx tempNode = GetNode(tn.Nodes);
                        if (tempNode != null)
                            return tempNode;
                    }

                    if (menu == tn.UnitFormMenu)
                        return tn;
                }
                return null;
            }
        }
    }
}
