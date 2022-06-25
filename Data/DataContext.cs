using Core.Models.Submarines.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

    public DbSet<Part> Parts { get; set; }
}