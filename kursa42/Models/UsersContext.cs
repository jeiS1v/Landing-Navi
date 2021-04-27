using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursa42.Models
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Soobshenie> Messeng { get; set; }
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
