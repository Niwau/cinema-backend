using Microsoft.AspNetCore.Mvc;
using cinema_backend.Models;

namespace cinema_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly List<Movie> movies =
    [
        new() { Id = 1, Name = "Movie 1", Sinopsis = "Sinopsis 1", Cover = "Cover 1" },
        new() { Id = 2, Name = "Movie 2", Sinopsis = "Sinopsis 2", Cover = "Cover 2" },
        new() { Id = 3, Name = "Movie 3", Sinopsis = "Sinopsis 3", Cover = "Cover 3" },
        new() { Id = 4, Name = "Movie 4", Sinopsis = "Sinopsis 4", Cover = "Cover 4" },
        new() { Id = 5, Name = "Movie 5", Sinopsis = "Sinopsis 5", Cover = "Cover 5" }
    ];

    [HttpGet()]
    public IActionResult Get()
    {
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var movie = movies.Find(movie => movie.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Movie movie)
    {
        movies.Add(movie);
        return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Movie movie)
    {
        var index = movies.FindIndex(movie => movie.Id == id);
        
        if (index == -1) {
          return NotFound();
        }

        movies[index] = movie;
        
        return Ok(movies[index]);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var movie = movies.Find(movie => movie.Id == id);

        if (movie == null) {
          return NotFound();
        }
          
        movies.Remove(movie);
        return Ok(movie);
    }

}