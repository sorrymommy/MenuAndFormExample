namespace FormAndMenu
{
    public interface IRunningUnitFormMenuViewMonitor
    {
        void Subscribe(IRunningUnitFormMenuView unitFormMenuInfoView);
        void UnSubscribe(IRunningUnitFormMenuView unitFormMenuInfoView);
        void Notify(IUnitFormMenu menu);
        void Notify();
    }

}
