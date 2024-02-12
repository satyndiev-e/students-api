using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Students.Persistence;

namespace Students.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
                
            using(var scop = host.Services.CreateScope())
            {
                var serviseProvider = scop.ServiceProvider;
                try
                {
                    var context = serviseProvider.GetRequiredService<StudentsDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception exception) 
                {
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}