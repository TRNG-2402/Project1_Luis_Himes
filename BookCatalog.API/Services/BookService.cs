using BookCatalog.Data;
using BookCatalog.DTOs;
using BookCatalog.Models;

namespace BookCatalog.Services;

public class BookService : IBookService
{

    private readonly IBookRepo _repo;

    public BookService(IBookRepo repo)
    {
        _repo = repo;
    }


    public async Task<List<Book>> GetAllBooksAsync()
    {

        List<Book> result = await _repo.GetAllBooksAsync();


        if (result is null)
            throw new NullReferenceException("Somehow... no Books?");

        return result;
    }
    public async Task<Book> GetBookByIdAsync(int id)
    {
        Book? result = await _repo.GetBookByIdAsync(id);
        if (result is null)
            throw new NullReferenceException("This book doesn't exist");
        return result;
    }

    public async Task<List<Book>> GetAllBooksByGenreAsync(int genreId)
    {
        List<Book> result = await _repo.GetAllBooksByGenreAsync(genreId);

        if (result is null)
            throw new NullReferenceException($"No books with GenreId {genreId}");

        return result;
    }

    public async Task<List<Book>> GetAllBooksByAuthorAsync(int authorId)
    {
        List<Book> result = await _repo.GetAllBooksByAuthorAsync(authorId);

        if (result is null)
            throw new NullReferenceException($"No books with AuthorId {authorId}");

        return result;
    }



    public async Task<Book> CreateBookAsync(BookDTO newBook)
    {
        Book newBk = new Book();

        newBk.Name = newBook.Name;
        newBk.Description = newBook.Description;
        newBk.Price = newBook.Price;
        newBk.Stock = newBook.Stock;
        newBk.ReleaseDate = newBook.ReleaseDate;
        newBk.GenreId = newBook.GenreId;
        newBk.AuthorId = newBook.AuthorId;

        Book createdBook = await _repo.CreateBookAsync(newBk);

        return createdBook;
    }
    public async Task RestockBook(int bookId, int numBooks)
    {
        Book? book = await _repo.GetBookByIdAsync(bookId);

        if (book is null)
            throw new KeyNotFoundException($"BookId {bookId} does not exist.");

        book.Stock = book.Stock + numBooks;

        await _repo.UpdateBookAsync(book);
    }

    public async Task ChangePrice(int bookId, decimal newPrice)
    {
        Book? book = await _repo.GetBookByIdAsync(bookId);

        if (book is null)
            throw new KeyNotFoundException($"BookId {bookId} does not exist.");

        book.Price = newPrice;

        await _repo.UpdateBookAsync(book);
    }







}