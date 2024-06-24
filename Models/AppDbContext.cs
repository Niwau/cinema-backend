using Microsoft.EntityFrameworkCore;

namespace cinema_backend.Models;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Movie>? Movies { get; set; }
}