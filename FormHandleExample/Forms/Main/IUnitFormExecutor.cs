using MenuAndFormExample.Forms.Base;
using MenuAndFormExample.Forms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndFormExample.Forms.Main
{
    public interface IUnitFormExecutor
    {
        void Run(UnitFormMenu unitFormMenu);
    }
}
