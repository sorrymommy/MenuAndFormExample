using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormAndMenu
{
    public interface IUnitForm
    {
        Form Form { get; }
        IUnitFormMenu UnitFormMenu { get; set; }
    }
}
