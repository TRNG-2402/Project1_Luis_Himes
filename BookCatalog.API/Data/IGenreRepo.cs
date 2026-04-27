
using BookCatalog.DTOs;
using BookCatalog.Models;

namespace BookCatalog.Data;

public interface IGenreRepo
{
    Task<List<Genre>> GetAllGenresAsync();

    Task<Genre> CreateGenreAsync(Genre genreToAdd);
    Task<Genre?> GetGenreByIdAsync(int id);
    Task DeleteGenreAsync(Genre genreToDelete);

    Task UpdateGenreDescription(Genre updateGenreDescription);

    Task<Genre?> GetGenreByNameAsync(string name);

}