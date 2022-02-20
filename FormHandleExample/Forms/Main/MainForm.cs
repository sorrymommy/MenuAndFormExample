using MenuAndFormExample.Forms.Main.FormView;
using MenuAndFormExample.Forms.Main.MenuView;
using MenuAndFormExample.Forms.Main.RunningFormView;
using MenuAndFormExample.Forms.Menu_01;
using MenuAndFormExample.Forms.Menu_02;
using MenuAndFormExample.Lib.FormAndMenu;
using System;
using System.Collections.Generic;
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

        private List<UnitFormMenu> GetUnitFormMenus()
        {
            List<UnitFormMenu> unitFormMenus = new List<UnitFormMenu>();
            unitFormMenus.Add(new UnitFormMenu() { Parent = null, MenuName = "SubMenu01", FormType = null });
            unitFormMenus.Add(new UnitFormMenu() { Parent = unitFormMenus[unitFormMenus.Count - 1], MenuName = nameof(Child01_01), FormType = Type.GetType(typeof(Child01_01).FullName) });
            unitFormMenus.Add(new UnitFormMenu() { Parent = unitFormMenus[unitFormMenus.Count - 2], MenuName = nameof(Child01_02), FormType = Type.GetType(typeof(Child01_02).FullName) });
            unitFormMenus.Add(new UnitFormMenu() { Parent = null, MenuName = "SubMenu02", FormType = null });
            unitFormMenus.Add(new UnitFormMenu() { Parent = unitFormMenus[unitFormMenus.Count - 1], MenuName = nameof(Child02_01), FormType = Type.GetType(typeof(Child02_01).FullName) });
            unitFormMenus.Add(new UnitFormMenu() { Parent = unitFormMenus[unitFormMenus.Count - 2], MenuName = nameof(Child02_02), FormType = Type.GetType(typeof(Child02_02).FullName) });

            return unitFormMenus;
        }
        private void Event_FormLoad(object sender, EventArgs e)
        {

            IRunningUnitFormMenuViewMonitor runningUnitFormMenuViewMonitor = new RunningUnitFormMenuViewMonitor();
            runningUnitFormMenuViewMonitor.Subscribe(new ToolStripStatusLabelRunningUnitFormMenuView(toolStripStatusLabel1));
            runningUnitFormMenuViewMonitor.Subscribe(new TreeViewUnitFormMenuView(treeView1));

            IUnitFormExecutor unitFormExecutor = new TabControlUnitFormExecutor(tabControl1)
            {
                RunningUnitFormMenuViewMonitor = runningUnitFormMenuViewMonitor
            };

            new TabControlUIHandler(tabControl1)
            {
                RunningUnitFormMenuViewMonitor = runningUnitFormMenuViewMonitor
            };

            IUnitFormMenuLoader unitFormMenuLoader = new TreeViewMenu(treeView1)
            {
                UnitFormExecutor = unitFormExecutor
            };

            unitFormMenuLoader.Load(GetUnitFormMenus());
        }
    }
}
