using Microsoft.EntityFrameworkCore;
using UniversumCRUD.Models.Domain;

namespace UniversumCRUD.Data
{
    public class MVCUniversumDbContext : DbContext
    {
        public MVCUniversumDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}