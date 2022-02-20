using FormAndMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndFormExample.Forms.Model
{
    public class UnitFormMenu : IUnitFormMenu
    {
        public IUnitFormMenu Parent { get; set; }
        public string MenuName { get; set; }
        public Type FormType { get; set; }
    }
}
