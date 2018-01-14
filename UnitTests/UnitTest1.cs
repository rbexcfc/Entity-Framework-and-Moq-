using System;
using Xunit;
using ContosoUniversity.Controllers;
using ContosoUniversity.Data;
using Moq;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

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
    }
}
