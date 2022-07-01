using Core.Models.Submarines.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

    public DbSet<Part> Parts { get; set; }
    public DbSet<SubmarinePart> SubmarineParts { get; set; }
    public DbSet<Submarine> Submarines { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Part>()
            .HasMany(p => p.SubmarineParts)
            .WithOne(sp => sp.Part)
            .HasForeignKey(sp => sp.PartId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Submarine>()
            .HasMany(s => s.Parts)
            .WithOne(sp => sp.Submarine)
            .HasForeignKey(sp => sp.SubmarineId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SubmarinePart>()
            .HasKey(sp => new { sp.SubmarineId, sp.PartId });
        
        modelBuilder.Seed();
    }
}