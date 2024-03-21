using Microsoft.EntityFrameworkCore;
using Triangle.TestBank.Data.Models;
using Triangle.TestBank.Data.Services;

namespace Triangle.TestBank.Data;

[Coalesce]
public class AppDbContext : DbContext
{
    public DbSet<Exam> Exams => Set<Exam>();

    public AppDbContext() { }

    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Remove cascading deletes.
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
