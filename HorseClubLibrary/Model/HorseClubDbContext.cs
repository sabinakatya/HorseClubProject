using HorseClubLibrary.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace HorseClubLibrary.Model;

public class HorseClubDbContext : DbContext
{
    public HorseClubDbContext(DbContextOptions<HorseClubDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();

        modelBuilder.Entity<DurationTours>().Property(m => m.Id).UseIdentityColumn();
        modelBuilder.Entity<Orders>().Property(m => m.Id).UseIdentityColumn();
        modelBuilder.Entity<Statuses>().Property(s => s.Id).UseIdentityColumn();
        modelBuilder.Entity<Tours>().Property(p => p.Id).UseIdentityColumn();
        modelBuilder.Entity<Users>().Property(p => p.Id).UseIdentityColumn();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    public DbSet<DurationTours> DurationTours { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<Statuses> Statuses { get; set; }
    public DbSet<Tours> Tours { get; set; }
    public DbSet<Users> Users { get; set; }
}