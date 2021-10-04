using System;
using System.Collections.Generic;
using System.Text;

namespace Isu.Charater
{
    public class CourseNumber
    {
        private int num;
        public int Number
        {
            get
            {
                return num;
            }

            set
            {
                if (value >= 1 && value <= 4) // курс 1-4
                    num = value;
            }
        }
    }
}
