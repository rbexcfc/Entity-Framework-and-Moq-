using System.Threading.Tasks;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;

namespace ContosoUniversity.Data
{
    public interface ISchoolContext
    {
        DbSet<Course> Courses { get; set; }
        DbSet<Enrollment> Enrollments { get; set; }
        DbSet<Student> Students { get; set; }
        int SaveChanges();
        EntityEntry Add(object entity);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
        EntityEntry Update(object entity);
    }
}