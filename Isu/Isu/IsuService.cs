using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Charater;
using Isu.Services;

namespace Isu
{
    public class IsuService : IIsuService
    {
        private int _studentId;

        public IsuService()
        {
            _studentId = 0;
            MaxPeopleGroup = 20;
            Groups = new List<Group>();
            Students = new List<Student>();
        }

        public int MaxPeopleGroup { get; set; }
        public List<Group> Groups { get; set; }
        public List<Student> Students { get; set; }

        // add new group
        public Group AddGroup(GroupName name)
        {
            Groups.Add(new Group() { GroupName = name, Students = new List<Student>() });
            return Groups.LastOrDefault();
        }

        // add new student
        public Student AddStudent(Group group, string name)
        {
            Student newStudent = new Student() { Id = _studentId++, Name = name, Group = group };
            Students.Add(newStudent);
            group.Students.Add(newStudent);
            return newStudent;
        }

        // Get student
        public Student GetStudent(int id)
        {
            return Students.FirstOrDefault(s => s.Id == id);
        }

        // FindStudent
        public Student FindStudent(string name)
        {
            return Students.FirstOrDefault(s => s.Name == name);
        }

        // find group
        public Group FindGroup(GroupName groupName)
        {
            return Groups.FirstOrDefault(g => g.GroupName.ToString() == groupName.ToString());
        }

        // find group c CourseNumber
        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            return Groups.Where(g => g.GroupName.X == courseNumber.Number).ToList();
        }

        public List<Student> FindStudents(GroupName groupName)
        {
            return FindGroup(groupName)?.Students;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            return Students.Where(g => g.Group.GroupName.X == courseNumber.Number).ToList();
        }

        public List<Group> FindGroup(CourseNumber courseNumber)
        {
            return Groups.Where(g => g.GroupName.X == courseNumber.Number).ToList();
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            student.Group.Students.Remove(student);
            newGroup.Students.Add(student);
        }

        public void PrintGroupList(Group group)
        {
            Console.WriteLine("Students in group " + group.GroupName.ToString() + " have :");
            foreach (Student student in group.Students)
            {
                Console.WriteLine(student.Name);
            }

            Console.WriteLine();
        }

        public void PrintStudentList(List<Student> student1)
        {
            Console.WriteLine("List Students: ");
            foreach (var student in student1)
            {
                Console.WriteLine(student.Name);
            }

            Console.WriteLine();
        }

        public void PrintGroupsList(List<Group> group1)
        {
            Console.WriteLine("Group you need find: ");
            foreach (var group in group1)
            {
                Console.WriteLine(group.GroupName.ToString());
            }

            Console.WriteLine();
        }
    }
}