
using BookCatalog.DTOs;
using BookCatalog.Models;

namespace BookCatalog.Services;

public interface IAuthorService
{
    Task<List<Author>> GetAllAuthorsAsync();

    Task<Author> GetAuthorByIdAsync(int id);

    Task<Author> CreateAuthorAsync(NewAuthorDTO newAuthor);

    Task DeleteAuthorAsync(int id);
}