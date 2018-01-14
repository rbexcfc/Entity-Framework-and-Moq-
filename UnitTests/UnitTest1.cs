using System;
using Xunit;
using ContosoUniversity.Controllers;
using ContosoUniversity.Data;
using Moq;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;
using FluentAssertions;
using System.Linq;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Non query test")]
        public void TestNonQueryMethod()
        {
            var mockSet = new Mock<DbSet<Student>>();

            var mockContext = new Mock<ISchoolContext>();
            mockContext.Setup(c => c.Students).Returns(mockSet.Object);

            var controller = new StudentsController(mockContext.Object);
            controller.MethodToTest(999, "Rich", "Bexhell", DateTime.Now);

            mockSet.Verify(c => c.Add(It.IsAny<Student>()), Times.Once);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }
        [Fact(DisplayName = "Student count")]
        public void StudentCountTest()
        {
            var students = new Student[]
            {
              new Student{ID = 1,FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
              new Student{ID = 2, FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")}
            }.AsQueryable();


            var mockSet = new Mock<DbSet<Student>>();
            mockSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(students.Provider);
            mockSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(students.Expression);
            mockSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(students.ElementType);
            mockSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(students.GetEnumerator());

            var mockContext = new Mock<ISchoolContext>();
            mockContext.Setup(c => c.Students).Returns(mockSet.Object);

            var controller = new StudentsController(mockContext.Object);
            var result = controller.GetAllStudentsTest();

            result.Count.ShouldBeEquivalentTo(2);

        }
    }
}