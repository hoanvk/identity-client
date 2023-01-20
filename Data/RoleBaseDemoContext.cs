using Microsoft.EntityFrameworkCore;
using RoleBaseDemo.Models;

namespace RoleBaseDemo.Data;
public class RoleBaseDemoContext : DbContext
{
    public RoleBaseDemoContext() : base()
    {

    }

    public RoleBaseDemoContext(DbContextOptions<RoleBaseDemoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Student>(entity =>
        {
            entity.ToTable(name: "students");
        });
    }
    //entities
    public DbSet<Student> Students { get; set; }
}