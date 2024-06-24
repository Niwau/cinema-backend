using Microsoft.EntityFrameworkCore;

namespace cinema_backend.Models;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Movie>? Movies { get; set; }
    public DbSet<Session>? Sessions { get; set; }
    public DbSet<Chair>? Chairs { get; set; }
    public DbSet<Admin>? Admins { get; set; }
    public DbSet<Room>? Rooms { get; set; }
}