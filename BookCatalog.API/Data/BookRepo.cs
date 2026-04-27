using Microsoft.EntityFrameworkCore;
using BookCatalog.DTOs;
using BookCatalog.Models;

namespace BookCatalog.Data;

public class BookRepo : IBookRepo
{

    private readonly AppDbContext _context;

    public BookRepo(AppDbContext context)
    {
        _context = context;
    }



    public async Task<List<Book>> GetAllBooksAsync()
    {

        List<Book> result = await _context.Books.ToListAsync();

        return result;
    }

    public async Task<List<Book>> GetAllBooksByGenreAsync(int genreId)
    {

        List<Book> result = await _context.Books.Where(p => p.GenreId == genreId).ToListAsync();

        return result;
    }

    public async Task<List<Book>> GetAllBooksByAuthorAsync(int authorId)
    {
        List<Book> result = await _context.Books.Where(p => p.AuthorId == authorId).ToListAsync();

        return result;
    }
    public async Task<Book> CreateBookAsync(Book bookToAdd)
    {
        _context.Books.Add(bookToAdd);

        await _context.SaveChangesAsync();

        return bookToAdd;
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }



    public async Task UpdateBookAsync(Book updatedBook)
    {
        Book? book = await _context.Books
            .FirstOrDefaultAsync(p => p.BookId == updatedBook.BookId);

        if (book is null)
            throw new KeyNotFoundException($"Book {updatedBook.Name} not found.");

        book.Name = updatedBook.Name;
        book.Description = updatedBook.Description;
        book.Price = updatedBook.Price;
        book.Stock = updatedBook.Stock;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(Book bookToDelete)
    {
        _context.Books.Remove(bookToDelete);

        await _context.SaveChangesAsync();
    }


}