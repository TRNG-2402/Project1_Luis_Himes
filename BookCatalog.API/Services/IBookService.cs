
using BookCatalog.Models;
using BookCatalog.DTOs;

namespace BookCatalog.Services;

public interface IBookService
{
    //Add my controller methods
    Task<List<Book>> GetAllBooksAsync();

    Task<Book> GetBookByIdAsync(int id);

    Task<List<Book>> GetAllBooksByGenreAsync(int genreId);

    Task<List<Book>> GetAllBooksByAuthorAsync(int authorId);

    Task<Book> CreateBookAsync(BookDTO bookToAdd);

    Task RestockBook(int bookId, int numBooks);
    Task ChangePrice(int bookId, decimal newPrice);

}