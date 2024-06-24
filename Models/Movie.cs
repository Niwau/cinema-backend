using Microsoft.EntityFrameworkCore;
namespace cinema_backend.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Sinopsis { get; set; }
    public string? Cover { get; set; }
}

public class MovieDB(DbContextOptions options) : DbContext(options)
{
    public DbSet<Movie>? Movies { get; set; }
}