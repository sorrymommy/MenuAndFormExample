using MenuAndFormExample.Forms.Main.MenuView;
using MenuAndFormExample.Forms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuAndFormExample.Forms.Main.RunningFormView
{
    public class TreeViewUnitFormMenuView : IRunningUnitFormMenuView
    {
        private TreeView TreeView;
        public TreeViewUnitFormMenuView(TreeView treeView)
        {
            this.TreeView = treeView;
        }

        public void Refresh(UnitFormMenu menu)
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
