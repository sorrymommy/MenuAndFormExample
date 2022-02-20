using FormAndMenu;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MenuAndFormExample.Lib.MenuAndForm.Base
{
    public class TabControlUIHandler
    {
        private TabControl TabControl;
        public TabControlUIHandler(TabControl tabControl)
        {
            TabControl = tabControl;

            TabControl.TabPages.Clear();

            TabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            TabControl.SizeMode = TabSizeMode.Fixed;

            TabControl.DrawItem += Event_TabControlDrawItem;
            TabControl.MouseClick += Event_TabControlMouseClick;
            TabControl.ControlRemoved += Event_TabControlControlRemoved;
            TabControl.SelectedIndexChanged += Event_TabControlelectedIndexChanged;

        }
        private void Event_TabControlelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;

            if (tabControl == null)
                return;

            TabPageEx tabPageEx = tabControl.SelectedTab as TabPageEx;

            if (tabPageEx == null)
                return;

            RunningUnitFormMenuViewMonitor.Notify(tabPageEx.UnitForm.UnitFormMenu);
        }

        private void Event_TabControlControlRemoved(object sender, ControlEventArgs e)
        {
            TabControl tabControl = sender as TabControl;

            if (tabControl == null)
                return;

            RunningUnitFormMenuViewMonitor.Notify(null);
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
        public IRunningUnitFormMenuViewMonitor RunningUnitFormMenuViewMonitor { get; set; }
    }
}
