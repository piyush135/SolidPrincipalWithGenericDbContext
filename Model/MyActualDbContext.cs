using Microsoft.EntityFrameworkCore;

namespace SolidPrincipalWithGenericDbContext.Model
{
    public class MyActualDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MyActualDbContext(DbContextOptions<MyActualDbContext> options) : base(options)
        {
        }

        // Define your DbSets for tables
        public DbSet<MyEntity> MyEntities { get; set; }
    }
}
