using MenuAndFormExample.Forms.Base;
using MenuAndFormExample.Forms.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuAndFormExample.Forms.Main
{
    public class TabControlHandler: IUnitFormExecutor
    {
        private TabControl TabControl;
        public TabControlHandler(TabControl tabControl)
        {
            TabControl = tabControl;

            TabControl.TabPages.Clear();

            TabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            TabControl.SizeMode = TabSizeMode.Fixed;

            TabControl.DrawItem             += Event_TabControlDrawItem;
            TabControl.MouseClick           += Event_TabControlMouseClick;
            TabControl.ControlRemoved       += Event_TabControlControlRemoved;
            TabControl.SelectedIndexChanged += Event_TabControlelectedIndexChanged;

            FormCreationLimtCount = 1;
        }
        private UnitForm GetUnitFormFromActiveTabPage()
        {
            if (TabControl.SelectedTab == null)
                return null;

            if (TabControl.SelectedTab.HasChildren)
                return TabControl.SelectedTab.Controls[0] as UnitForm;

            return null;
        }

        private void Event_TabControlelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;

            if (tabControl == null)
                return;

            UnitForm unitForm = GetUnitFormFromActiveTabPage();

            if (unitForm == null)
                return;

            //TODO : Refresh running form's information 
            //RefreshRunningMenuInfo(unitForm.UnitFormMenu);
        }

        private void Event_TabControlControlRemoved(object sender, ControlEventArgs e)
        {
            TabControl tabControl = sender as TabControl;

            if (tabControl == null)
                return;

            //TODO : Refresh running form's information 
            //ClearRunningMenuInfo();
        }
        private void Event_TabControlMouseClick(object sender, MouseEventArgs e)
        {
            TabControl tabControl = sender as TabControl;

            Point closeLoc = new Point(15, 5);

            Rectangle r = tabControl.GetTabRect(tabControl.SelectedIndex);
            Rectangle closeButtonRect = new Rectangle(r.Right - closeLoc.X, r.Top + closeLoc.Y, 10, 12);

            if (closeButtonRect.Contains(e.Location))
                tabControl.TabPages.Remove(tabControl.SelectedTab);
        }

        private void Event_TabControlDrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;

            TabPage thisTab = tabControl.TabPages[e.Index];
            string tabTitle = thisTab.Text;

            Point closeBottonPoint = new Point(15, 5);
            Rectangle closeBoxRect = new Rectangle(e.Bounds.Right - closeBottonPoint.X, e.Bounds.Top + closeBottonPoint.Y, 10, 12);
            Point closeBoxStringXPoint = new Point(e.Bounds.Right - (closeBottonPoint.X), e.Bounds.Top + closeBottonPoint.Y - 2);
            Point tabTitleStringPoint = new Point(e.Bounds.Left, e.Bounds.Top + 6);

            e.Graphics.DrawRectangle(Pens.Black, closeBoxRect);
            e.Graphics.FillRectangle(Brushes.Red, closeBoxRect);
            e.Graphics.DrawString("x", e.Font, Brushes.Black, closeBoxStringXPoint);
            e.Graphics.DrawString(tabTitle, e.Font, Brushes.Black, tabTitleStringPoint);

            e.DrawFocusRectangle();
        }

        private TabPage GetTabPage(UnitFormMenu unitFormMenu)
        {
            return TabControl.TabPages
                .Cast<TabPage>()
                .Where(tabPage => tabPage.HasChildren && (tabPage.Controls[0] as UnitForm).UnitFormMenu == unitFormMenu)
                .LastOrDefault();
        }
        private int GetCreatedCount(UnitFormMenu unitFormMenu)
        {
            return TabControl.TabPages
                .Cast<TabPage>()
                .Where(tabPage => tabPage.HasChildren && (tabPage.Controls[0] as UnitForm).UnitFormMenu == unitFormMenu)
                .Count();
        }

        private int FormCreationLimtCount { get; set; }
        public void Run(UnitFormMenu unitFormMenu)
        {
            TabPage tabPage = GetTabPage(unitFormMenu);
            UnitForm unitForm = null;
            if ((FormCreationLimtCount == 0) || (GetCreatedCount(unitFormMenu) < FormCreationLimtCount))
            {
                tabPage = GetTabPage(unitFormMenu);
                unitForm = Activator.CreateInstance(unitFormMenu.FormType) as UnitForm;
                tabPage = new TabPage();

                tabPage.Text = unitFormMenu.MenuName;
                unitForm.UnitFormMenu = unitFormMenu;
                unitForm.TopLevel = false;
                unitForm.Parent = tabPage;
                unitForm.FormBorderStyle = FormBorderStyle.None;
                unitForm.Dock = DockStyle.Fill;
                unitForm.Show();

                TabControl.TabPages.Add(tabPage);
            }

            TabControl.SelectedTab = tabPage;

            if (TabControl.TabPages.Count == 1)
            {
                var form = GetUnitFormFromActiveTabPage();

                if (form != null)
                {
                    //TODO : Refresh running form's information 
                    //RefreshRunningMenuInfo(form.UnitFormMenu);
                }
            }
        }
    }
}
