using System;
using System.Linq;
using System.Collections.Generic;
using Isu.Charater;
using System.Runtime.Serialization;

namespace Isu
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IsuService isu = new IsuService(); // creat new 

            Group group = isu.AddGroup(new groupName() { X = 2, YY = 12 }); // group add M3212
            Group group1 = isu.AddGroup(new groupName() { X = 3, YY = 11 }); // add M3311

            // studen add
            isu.AddStudent(group, "Le Ba Kien"); //0
            isu.AddStudent(group, "Nguyen Tuan Kiet"); //1
            isu.AddStudent(group, "Tran Hoang Nam"); // 2
            isu.AddStudent(group, "Phormenko"); // 3

            isu.AddStudent(group1, "Duc"); //0

            Console.WriteLine(isu.GetStudent(0).Name); // print to  check "student add" => Le Ba Kien
            Console.WriteLine();

            Console.WriteLine(isu.FindStudent("Tran Hoang Nam").Id); // print to check "find Student" => 2
            Console.WriteLine();

            //1 GroupName
            isu.PrintStudentList(isu.FindStudents(group.GroupName)); // print students in group you had added => Le Ba Kien Nguyen Tuan Kiet Tran Hoang Nam Phormenko
            Console.WriteLine();

            //2 CourseNumber
            isu.PrintStudentList(isu.FindStudents(new CourseNumber() { Number = 2 })); // => Le Ba Kien Nguyen Tuan Kiet Tran Hoang Nam Phormenko
            Console.WriteLine();

            //3 GroupList c FindGroup
            isu.PrintGroupList(isu.FindGroup(group.GroupName)); // => Le Ba Kien Nguyen Tuan Kiet Tran Hoang Nam Phormenko
            Console.WriteLine();

            //4 GroupList c CourseNumber
            isu.PrintGroupsList(isu.FindGroups(new CourseNumber() { Number = 2 })); // => M3212
            Console.WriteLine();

            // Change Group and print check
            isu.ChangeStudentGroup(isu.Students.FirstOrDefault(s => s.Name == "Duc"), group); // add student"Duc" to M3212 
            isu.PrintGroupList(group); // print "group"
            Console.WriteLine();
            isu.PrintGroupList(group1); // print "group1"
            Console.WriteLine();
            Console.ReadKey(); // keep to see screen

        }
    }

}
