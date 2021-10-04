using System;
using System.Collections.Generic;
using System.Text;

namespace Isu.Charater
{
    public class Student
    {
        public int Id { get; set; } // прямой запрос через Id //динамически создать свойство для управления "int"
        public string Name { get; set; } // прямой запрос через Name
        public Group Group { get; set; } // прямой запрос через Group
    }
}
