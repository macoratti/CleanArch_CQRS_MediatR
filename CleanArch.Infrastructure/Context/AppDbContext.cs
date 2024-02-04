using CleanArch.Domain.Entities;
using CleanArch.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Member> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new MemberConfiguration());
    }
}
