using DataMatrix.Models;
using Microsoft.EntityFrameworkCore;

namespace DataMatrix.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Contact> Contacts { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


    }
}
