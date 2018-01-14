using System.Threading.Tasks;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public interface ISchoolContext
    {
        DbSet<Course> Courses { get; set; }
        DbSet<Enrollment> Enrollments { get; set; }
        DbSet<Student> Students { get; set; }
        int SaveChanges();
        void Add(Student student);
        Task SaveChangesAsync();
        void Update(Student student);
    }
}