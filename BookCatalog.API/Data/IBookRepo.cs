using BookCatalog.Models;
using BookCatalog.DTOs;

namespace BookCatalog.Data;

public interface IBookRepo
{
    Task<List<Book>> GetAllBooksAsync();

    Task<List<Book>> GetAllBooksByGenreAsync(int genreId);

    Task<List<Book>> GetAllBooksByAuthorAsync(int authorId);

    Task<Book> CreateBookAsync(Book bookToAdd);

    Task<Book?> GetBookByIdAsync(int id);

    Task DeleteBookAsync(Book bookToDelete);

    Task UpdateBookAsync(Book updatedBook);

}