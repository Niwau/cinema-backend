using Microsoft.AspNetCore.Mvc;
using cinema_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController(AppDbContext db) : ControllerBase
{

    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        try {
            List<Movie> movies = await db.Movies.ToListAsync();

            if (movies.Count == 0) {
                return Ok(new List<Movie>());
            }

            return Ok(db.Movies.ToList());
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
    }

    // TODO: SOMENTE OS ADMINS PODEM CRIAR FILMES
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Movie movie)
    {
        try
        {
            await db.Movies.AddAsync(movie);
            await db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try {
            Movie movie = await db.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
    }

    // TODO: SOMENTE OS ADMINS PODEM ALTERAR FILMES
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Movie movie)
    {    
       try {
            var movieToUpdate = await db.Movies.FindAsync(id);

            if (movieToUpdate == null) {
                return NotFound();
            }

            movieToUpdate.Name = movie.Name;
            movieToUpdate.Sinopsis = movie.Sinopsis;
            movieToUpdate.Cover = movie.Cover;

            db.Movies.Update(movieToUpdate);
            await db.SaveChangesAsync();
            return Ok(movie);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // TODO: SOMENTE OS ADMINS PODEM DELETAR FILMES
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try {
            var movie = await db.Movies.FindAsync(id);

            if (movie == null) {
                return NotFound();
            }
            
            db.Movies.Remove(movie);
            await db.SaveChangesAsync();

            return Ok(movie);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    } 
}