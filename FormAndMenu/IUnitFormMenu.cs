using System;

namespace FormAndMenu
{
    public interface IUnitFormMenu
    {
        IUnitFormMenu Parent { get; set; }
        string MenuName { get; set; }
        Type FormType { get; set; }
    }
}
