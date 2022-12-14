using Microsoft.EntityFrameworkCore;
using PostgreSQLWebAPI.Models;


namespace PostgreSQLWebAPI.DataAccess
{
   
        public class PostgreSqlContext : DbContext
        {
            public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
            {
            }

            public DbSet<Student> student { get; set; }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
            }

            public override int SaveChanges()
            {
                ChangeTracker.DetectChanges();
                return base.SaveChanges();
            }
        }
    }


