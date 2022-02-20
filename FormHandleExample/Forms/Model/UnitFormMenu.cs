using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndFormExample.Forms.Model
{

    public class UnitFormMenu
    {
        /// <summary>
        /// 메뉴를 생성하고 실행하는 기준이 되는 데이터클래스
        /// Data class for loding menus , run menus and etc
        /// </summary>
        public UnitFormMenu Parent { get; set; }
        public string MenuName { get; set; }
        public Type FormType { get; set; }
        public override string ToString()
        {
            return MenuName;
        }
    }
}
