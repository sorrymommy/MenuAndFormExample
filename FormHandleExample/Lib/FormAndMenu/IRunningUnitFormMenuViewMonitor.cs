namespace MenuAndFormExample.Lib.FormAndMenu
{
    public interface IRunningUnitFormMenuViewMonitor
    {
        void Subscribe(IRunningUnitFormMenuView unitFormMenuInfoView);
        void UnSubscribe(IRunningUnitFormMenuView unitFormMenuInfoView);
        void Notify(UnitFormMenu menu);
        void Notify();
    }

}
