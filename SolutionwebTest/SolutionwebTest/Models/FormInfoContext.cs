using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionwebTest.Models
{
    public class FormInfoContext : DbContext
    {
        public FormInfoContext(DbContextOptions<FormInfoContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<FormInfo> formInfos { get; set; }
    }
}
