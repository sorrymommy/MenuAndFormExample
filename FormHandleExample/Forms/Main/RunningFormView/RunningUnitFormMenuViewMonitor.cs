using MenuAndFormExample.Forms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndFormExample.Forms.Main.RunningFormView
{
    public class RunningUnitFormMenuViewMonitor:IRunningUnitFormMenuViewMonitor
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
