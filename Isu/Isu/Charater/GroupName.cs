using System;
using System.Collections.Generic;
using System.Text;

namespace Isu.Charater
{
    public class GroupName
    {
        public int X { get; set; } // курсс
        public int YY { get; set; } // Группа
        public override string ToString()
        {
            return "M3" + X.ToString() + YY.ToString(); // M3+X+YY
        }
    }
}
