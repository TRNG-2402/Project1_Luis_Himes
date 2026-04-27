
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Caching.Memory;
using BookCatalog.Data;
using BookCatalog.DTOs;
using BookCatalog.Models;

namespace BookCatalog.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepo _repo;
    public GenreService(IGenreRepo repo)
    {
        _repo = repo;
    }


    public async Task<List<Genre>> GetAllGenresAsync()
    {
        List<Genre> result = await _repo.GetAllGenresAsync();

        if (result is null)
            throw new NullReferenceException("Somehow . . . no genres?");


        return result;
    }
    public async Task<Genre> GetGenreByIdAsync(int id)
    {
        Genre? result = await _repo.GetGenreByIdAsync(id);

        if (result is null)
            throw new NullReferenceException("This genre doesn't exist.");

        return result;
    }

    public async Task<Genre> CreateGenreAsync(NewGenreDTO newGenre)
    {

        Genre newGen = new Genre();

        newGen.Name = newGenre.Name;
        newGen.Description = newGenre.Description;

        Genre createdGenre = await _repo.CreateGenreAsync(newGen);


        return createdGenre;

    }

    public async Task DeleteGenreAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException("ID must be greater than 0!");

        Genre? genre = await _repo.GetGenreByIdAsync(id);

        if (genre is null)
            throw new KeyNotFoundException("This genre doesn't exist.");

        await _repo.DeleteGenreAsync(genre);

    }
    public async Task UpdateGenreAsync(NewGenreDTO updateGenre)
    {
        Genre? genre = await _repo.GetGenreByIdAsync(updateGenre.GenreId);

        if (genre is null)
            throw new KeyNotFoundException($"Genre {updateGenre.Name} doesn't exist.");

        genre.Description = updateGenre.Description;

        await _repo.UpdateGenreDescription(genre);

    }



}