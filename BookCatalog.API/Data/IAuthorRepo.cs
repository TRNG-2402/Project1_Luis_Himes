
using BookCatalog.DTOs;
using BookCatalog.Models;

namespace BookCatalog.Data;

public interface IAuthorRepo
{
    Task<List<Author>> GetAllAuthorsAsync();

    Task<Author> CreateAuthorAsync(Author authorToAdd);

    Task<Author?> GetAuthorByIdAsync(int id);

    Task DeleteAuthorAsync(Author authorToDelete);
}