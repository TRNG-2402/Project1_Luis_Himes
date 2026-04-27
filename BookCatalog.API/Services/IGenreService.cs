
using BookCatalog.DTOs;
using BookCatalog.Models;

namespace BookCatalog.Services;

public interface IGenreService
{
    Task<List<Genre>> GetAllGenresAsync();
    Task<Genre> GetGenreByIdAsync(int id);

    Task<Genre> CreateGenreAsync(NewGenreDTO newGenre);

    Task UpdateGenreAsync(NewGenreDTO updateGenre);

    Task DeleteGenreAsync(int id);
}