using FormHandleExampe.Forms.Base;
using FormHandleExampe.Forms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormHandleExampe.Forms.Main
{
    public interface IUnitFormCreator
    {
        UnitForm Run(UnitFormMenu unitFormMenu);
    }
}
