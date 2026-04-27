

using BookCatalog.Data;
using BookCatalog.DTOs;
using BookCatalog.Models;

namespace BookCatalog.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepo _repo;

    public AuthorService(IAuthorRepo repo)
    {
        _repo = repo;
    }

    public async Task<List<Author>> GetAllAuthorsAsync()
    {
        List<Author> result = await _repo.GetAllAuthorsAsync();

        if (result is null)
            throw new NullReferenceException("Somehow . . . no authors?");


        return result;
    }

    public async Task<Author> GetAuthorByIdAsync(int id)
    {
        Author? result = await _repo.GetAuthorByIdAsync(id);
        if (result is null)
            throw new NullReferenceException("This author doesn't exist.");

        return result;

    }

    public async Task<Author> CreateAuthorAsync(NewAuthorDTO newAuthor)
    {
        Author newAut = new Author();

        newAut.Name = newAuthor.Name;

        Author createdAuthor = await _repo.CreateAuthorAsync(newAut);

        return createdAuthor;
    }

    public async Task DeleteAuthorAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException("ID must be greater than 0!");

        Author? author = await _repo.GetAuthorByIdAsync(id);

        if (author is null)
            throw new KeyNotFoundException("This author doesn't exist.");

        await _repo.DeleteAuthorAsync(author);
    }
}