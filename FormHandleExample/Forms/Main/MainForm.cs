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

            treeView1.DoubleClick += Event_TreeViewDoubleClick;

        }
        private UnitForm GetUnitFormFromActiveTabPage()
        {
            if (tabControl1.SelectedTab == null)
                return null;

            if (tabControl1.SelectedTab.HasChildren)
                return tabControl1.SelectedTab.Controls[0] as UnitForm;

            return null;
        }
        private int FormCreationLimtCount {get;set;}

        private void Event_FormLoad(object sender, EventArgs e)
        {
            List<UnitFormMenu> unitFormMenus = new List<UnitFormMenu>();
            unitFormMenus.Add(new UnitFormMenu() { Parent = null, MenuName = "SubMenu01", FormType = null });
            unitFormMenus.Add(new UnitFormMenu() { Parent = unitFormMenus[unitFormMenus.Count - 1], MenuName = nameof(Child01_01), FormType = Type.GetType(typeof(Child01_01).FullName) });
            unitFormMenus.Add(new UnitFormMenu() { Parent = unitFormMenus[unitFormMenus.Count - 2], MenuName = nameof(Child01_02), FormType = Type.GetType(typeof(Child01_02).FullName) });
            unitFormMenus.Add(new UnitFormMenu() { Parent = null, MenuName = "SubMenu02", FormType = null });
            unitFormMenus.Add(new UnitFormMenu() { Parent = unitFormMenus[unitFormMenus.Count - 1], MenuName = nameof(Child02_01), FormType = Type.GetType(typeof(Child02_01).FullName) });
            unitFormMenus.Add(new UnitFormMenu() { Parent = unitFormMenus[unitFormMenus.Count - 2], MenuName = nameof(Child02_02), FormType = Type.GetType(typeof(Child02_02).FullName) });

            LoadTreeMenus(unitFormMenus);
            treeView1.ExpandAll();

            TabControlHandler tabControlHandler = new TabControlHandler(tabControl1);

            FormCreationLimtCount = 1;
            treeView1.FullRowSelect = true;
        }
        private TabPage GetTabPage(UnitFormMenu unitFormMenu)
        {
            return tabControl1.TabPages
                .Cast<TabPage>()
                .Where(tabPage => tabPage.HasChildren && (tabPage.Controls[0] as UnitForm).UnitFormMenu == unitFormMenu)
                .LastOrDefault();
        }
        private int GetCreatedCount(UnitFormMenu unitFormMenu)
        {
            return tabControl1.TabPages
                .Cast<TabPage>()
                .Where(tabPage => tabPage.HasChildren && (tabPage.Controls[0] as UnitForm).UnitFormMenu == unitFormMenu)
                .Count();
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


            TabPage tabPage = GetTabPage(menu);
            if ( (FormCreationLimtCount == 0 ) || ( GetCreatedCount(menu) < FormCreationLimtCount))
            {
                tabPage = GetTabPage(menu);
                UnitForm unitForm = Activator.CreateInstance(menu.FormType) as UnitForm;
                tabPage = new TabPage();

                tabPage.Text = menu.MenuName;
                unitForm.UnitFormMenu = menu;
                unitForm.TopLevel = false;
                unitForm.Parent = tabPage;
                unitForm.FormBorderStyle = FormBorderStyle.None;
                unitForm.Dock = DockStyle.Fill;
                unitForm.Show();

                tabControl1.TabPages.Add(tabPage);
            }

            tabControl1.SelectedTab = tabPage;

            if (tabControl1.TabPages.Count == 1)
            {
                var form = GetUnitFormFromActiveTabPage();

                if (form == null)
                    return;

                RefreshRunningMenuInfo(form.UnitFormMenu);
            }

        }

        private void LoadTreeMenus(List<UnitFormMenu> unitFormMenus)
        {
            var rootMenus = unitFormMenus.Where(x=>x.Parent == null).Select(x=>x);

            LoadUnitFormMenus(treeView1.Nodes, rootMenus);

            foreach (TreeNode node in treeView1.Nodes)
                LoadUnitFormMenus(node.Nodes, unitFormMenus.Where(x => x.Parent == (node.Tag as UnitFormMenu)).Select(x => x));
            
            void LoadUnitFormMenus(TreeNodeCollection nodes, IEnumerable<UnitFormMenu> menus)
            {
                foreach(UnitFormMenu menuItem in menus)
                {
                    TreeNode node = nodes.Add(menuItem.MenuName);
                    node.Tag = menuItem;
                }
            }
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
