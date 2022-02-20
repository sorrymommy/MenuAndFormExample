using FormAndMenu;
using System;

namespace MenuAndFormExample.Lib.MenuAndForm.Base
{
    public class UnitFormMenu : IUnitFormMenu
    {
        public IUnitFormMenu Parent { get; set; }
        public string MenuName { get; set; }
        public Type FormType { get; set; }
    }
}
