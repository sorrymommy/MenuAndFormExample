using MenuAndFormExample.Forms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndFormExample.Forms.Main
{
    public interface IRunningUnitFormMenuViewMonitor
    {
        void Subscribe(IRunningUnitFormMenuView unitFormMenuInfoView);
        void UnSubscribe(IRunningUnitFormMenuView unitFormMenuInfoView);
        void Notify(UnitFormMenu menu);
        void Notify();
    }

}
