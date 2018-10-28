using Microsoft.EntityFrameworkCore;

// ReSharper disable UnusedMember.Global
namespace EFCore_PG_653
{
    public class SomeDbContext : DbContext
    {
        public DbSet<SomeClass> SomeClass { get; set; }

        public SomeDbContext(DbContextOptions<SomeDbContext> options) : base(options) {}
    }
}