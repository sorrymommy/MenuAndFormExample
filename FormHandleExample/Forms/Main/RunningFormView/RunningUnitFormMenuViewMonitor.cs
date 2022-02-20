using MenuAndFormExample.Lib.FormAndMenu;
using System.Collections.Generic;

namespace MenuAndFormExample.Forms.Main.RunningFormView
{
    public class RunningUnitFormMenuViewMonitor : IRunningUnitFormMenuViewMonitor
    {
        private List<IRunningUnitFormMenuView> views;
        public RunningUnitFormMenuViewMonitor()
        {
            views = new List<IRunningUnitFormMenuView>();
        }
        public void Notify(UnitFormMenu menu)
        {
            views.ForEach(view =>
            {
                view.Refresh(menu);
            });
        }
        public void Notify()
        {
            this.Notify(null);
        }
        public void Subscribe(IRunningUnitFormMenuView unitFormMenuInfoView)
        {
            views.Add(unitFormMenuInfoView);
        }

        public void UnSubscribe(IRunningUnitFormMenuView unitFormMenuInfoView)
        {
            views.Remove(unitFormMenuInfoView);
        }
    }
}
