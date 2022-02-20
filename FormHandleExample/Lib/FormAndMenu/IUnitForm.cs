using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuAndFormExample.Lib.FormAndMenu
{
    public interface IUnitForm
    {
        Form Form { get; }
        UnitFormMenu UnitFormMenu { get; set; }
    }
}
