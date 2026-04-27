using Microsoft.AspNetCore.Mvc;
using BookCatalog.DTOs;
using BookCatalog.Models;
using BookCatalog.Services;

namespace BookCatalog.Controllers;


[Route("api/[Controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;
    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]

    public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
    {
        return await _genreService.GetAllGenresAsync();
    }
    [HttpGet("{genreId}")]
    public async Task<ActionResult<Genre>> GetGenreById(int genreId)
    {
        return await _genreService.GetGenreByIdAsync(genreId);
    }

    [HttpPost]
    public async Task<ActionResult<Genre>> CreateGenre(NewGenreDTO newGenre)
    {
        return await _genreService.CreateGenreAsync(newGenre);
    }

    [HttpDelete("{genreId}")]

    public async Task<ActionResult> DeleteCategory(int genreId)
    {
        await _genreService.DeleteGenreAsync(genreId);

        return NoContent();
    }

    [HttpPatch("{genreId}")]
    public async Task<ActionResult> UpdateGenre(int genreId, NewGenreDTO updatedGenre)
    {
        updatedGenre.GenreId = genreId;
        await _genreService.UpdateGenreAsync(updatedGenre);

        return NoContent();
    }


}