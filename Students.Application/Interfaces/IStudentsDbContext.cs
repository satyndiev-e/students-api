using Students.Domain;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Students.Application.Interfaces
{
    public interface IStudentsDbContext 
    {
        DbSet<Student> Students { get; set; }

        DbSet<Gender> Genders { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
