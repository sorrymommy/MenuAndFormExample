using System.Windows.Forms;

namespace FormAndMenu
{
    public interface IUnitForm
    {
        Form Form { get; }
        IUnitFormMenu UnitFormMenu { get; set; }
    }
}
