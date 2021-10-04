using Isu.Charater;
using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class IsuServiceTests
    {
        IsuService isu = new IsuService();
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Group group = isu.AddGroup(new GroupName() { X = 2, YY = 12 });
            Student student = isu.AddStudent(group, "Tran Hoang Nam");
            if (student.Group != group || !group.Students.Contains(student))
            {
                throw new IsuException("Student not in group");
            }
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Group group = isu.AddGroup(new GroupName() { X = 2, YY = 12 });
            for (int i = 0; i < 21; i++)
            {
                if (group.Students.Count > isu.MaxPeopleGroup)
                {
                    throw new IsuException("max");
                }
                isu.AddStudent(group, i.ToString());
            
            }
            


        }
        
        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            for (int i = 1; i <= 12; i++)
            {
                Group group = isu.AddGroup(new GroupName() { X = i, YY = i });
                if (group.X >= 1 && group.X <= 4 && group.YY >= 1 && group.YY <= 14)
                {
                    throw new IsuException("group doesn't exist");
                }

            }

        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Group group1 = isu.AddGroup(new GroupName() { X = 2, YY = 1 }); // creat group1
            Group group2 = isu.AddGroup(new GroupName() { X = 2, YY = 2 }); // creat group2
            Student student = isu.AddStudent(group1, "MIKITA"); // add new student
            isu.ChangeStudentGroup(student, group2); // change MIKITA to group2
            if (group1.Students.Contains(student) || !group2.Students.Contains(student))
            {
                throw new IsuException("not changed"); 
            }
        }

    }
}