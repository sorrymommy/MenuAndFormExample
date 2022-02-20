using FormAndMenu;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MenuAndFormExample.Lib.MenuAndForm.Base
{
    public class TabControlUnitFormExecutor : IUnitFormExecutor
    {
        private TabControl TabControl;
        public TabControlUnitFormExecutor(TabControl tabControl)
        {
            TabControl = tabControl;

            FormCreationLimtCount = 1;
        }
        public void Run(IUnitFormMenu unitFormMenu)
        {
            TabPageEx tabPageEx = GetTabPage(unitFormMenu);
            if ((FormCreationLimtCount == 0) || (GetCreatedCount(unitFormMenu) < FormCreationLimtCount))
            {
                tabPageEx = GetTabPage(unitFormMenu);
                IUnitForm unitForm = Activator.CreateInstance(unitFormMenu.FormType) as IUnitForm;
                unitForm.UnitFormMenu = unitFormMenu;

                tabPageEx = new TabPageEx(unitForm);
                tabPageEx.Text = unitFormMenu.MenuName;

                TabControl.TabPages.Add(tabPageEx);
            }

            TabControl.SelectedTab = tabPageEx;

            RunningUnitFormMenuViewMonitor.Notify(tabPageEx.UnitForm.UnitFormMenu);
        }
        public int FormCreationLimtCount { get; set; }
        private TabPageEx GetTabPage(IUnitFormMenu unitFormMenu)
        {
            return TabControl.TabPages
                .Cast<TabPageEx>()
                .Where(tabPage => tabPage.UnitForm.UnitFormMenu == unitFormMenu)
                .LastOrDefault();
        }
        private int GetCreatedCount(IUnitFormMenu unitFormMenu)
        {
            return TabControl.TabPages
                .Cast<TabPageEx>()
                .Where(tabPage => tabPage.UnitForm.UnitFormMenu == unitFormMenu)
                .Count();
        }

        public IRunningUnitFormMenuViewMonitor RunningUnitFormMenuViewMonitor { get; set; }
    }
}
