using MenuAndFormExample.Forms.Base;
using MenuAndFormExample.Forms.Menu_01;
using MenuAndFormExample.Forms.Menu_02;
using MenuAndFormExample.Forms.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuAndFormExample.Forms.Main
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.Load += Event_FormLoad;

        }
        private void Event_FormLoad(object sender, EventArgs e)
        {
            List<UnitFormMenu> unitFormMenus = new List<UnitFormMenu>();
            unitFormMenus.Add(new UnitFormMenu() { Parent = null, MenuName = "SubMenu01", FormType = null });
            unitFormMenus.Add(new UnitFormMenu() { Parent = unitFormMenus[unitFormMenus.Count - 1], MenuName = nameof(Child01_01), FormType = Type.GetType(typeof(Child01_01).FullName) });
            unitFormMenus.Add(new UnitFormMenu() { Parent = unitFormMenus[unitFormMenus.Count - 2], MenuName = nameof(Child01_02), FormType = Type.GetType(typeof(Child01_02).FullName) });
            unitFormMenus.Add(new UnitFormMenu() { Parent = null, MenuName = "SubMenu02", FormType = null });
            unitFormMenus.Add(new UnitFormMenu() { Parent = unitFormMenus[unitFormMenus.Count - 1], MenuName = nameof(Child02_01), FormType = Type.GetType(typeof(Child02_01).FullName) });
            unitFormMenus.Add(new UnitFormMenu() { Parent = unitFormMenus[unitFormMenus.Count - 2], MenuName = nameof(Child02_02), FormType = Type.GetType(typeof(Child02_02).FullName) });

            TabControlHandler tabControlHandler = new TabControlHandler(tabControl1);
            TreeViewMenu treeViewMenu = new TreeViewMenu(treeView1);
            treeViewMenu.LoadTreeMenus(unitFormMenus);
            treeViewMenu.UnitFormExecutor = tabControlHandler;

        }
        private void SelectMenu(UnitFormMenu unitFormMenu)
        {
            TreeNode node = GetNode(treeView1.Nodes);

            treeView1.SelectedNode = node;
            treeView1.Focus();
            TreeNode GetNode(TreeNodeCollection nodes)
            {
                foreach(TreeNode tn in nodes)
                {
                    if (tn.Nodes.Count > 0)
                    {
                        TreeNode tempNode = GetNode(tn.Nodes);
                        if (tempNode != null)
                            return tempNode;
                    }

                    if (unitFormMenu == (tn.Tag as UnitFormMenu))
                        return tn;
                }
                return null;
            }
        }
        private void RefreshRunningMenuInfo(UnitFormMenu unitFormMenu)
        {
            toolStripStatusLabel1.Text = $"RunningMenu : {unitFormMenu.MenuName}[{unitFormMenu.FormType.Name}]";
            SelectMenu(unitFormMenu);
        }
        private void ClearRunningMenuInfo()
        {
            toolStripStatusLabel1.Text = string.Empty;
        }
    }
}
