using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Students.Application.Interfaces;

namespace Students.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection 
            services, IConfiguration configuration)
        {
            var ConnectionString = configuration["DbConnection"];
            services.AddDbContext<StudentsDbContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });
            services.AddScoped<IStudentsDbContext>(provider =>
                provider.GetService<StudentsDbContext>());
            return services;
        }
    }
}
