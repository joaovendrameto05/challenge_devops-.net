using Microsoft.EntityFrameworkCore;
using celticsTech.Models;

namespace celticsTech.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Veterinarian> Veterinarians { get; set; }
    public DbSet<Consultation> Consultations { get; set; }
}