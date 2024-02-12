using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(StudentsDbContext context) 
        {
            context.Database.EnsureCreated();
        }
    }
}
