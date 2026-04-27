
using Microsoft.EntityFrameworkCore;
using BookCatalog.Models;
using BookCatalog.DTOs;

namespace BookCatalog.Data;

public class GenreRepo : IGenreRepo
{

    private readonly AppDbContext _context;

    public GenreRepo(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<Genre>> GetAllGenresAsync()
    {
        List<Genre> result = await _context.Genres.ToListAsync();
        return result;
    }

    public async Task<Genre> CreateGenreAsync(Genre genreToAdd)
    {
        _context.Genres.Add(genreToAdd);

        await _context.SaveChangesAsync();

        return genreToAdd;
    }

    public async Task<Genre?> GetGenreByIdAsync(int id)
    {
        return await _context.Genres.FindAsync(id);
    }

    public async Task DeleteGenreAsync(Genre genreToDelete)
    {
        _context.Genres.Remove(genreToDelete);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateGenreDescription(Genre updateGenreDescription)
    {
        Genre? genre = await _context.Genres
            .FirstOrDefaultAsync(p => p.Name == updateGenreDescription.Name);

        if (genre is null)
            throw new KeyNotFoundException($"Genre {updateGenreDescription.Name} not found.");

        genre.Description = updateGenreDescription.Description;

        await _context.SaveChangesAsync();
    }

    public async Task<Genre?> GetGenreByNameAsync(string name)
    {
        return await _context.Genres.FirstOrDefaultAsync(p => p.Name == name);
    }


}