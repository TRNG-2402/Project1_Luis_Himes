using Microsoft.AspNetCore.Mvc;
using BookCatalog.DTOs;
using BookCatalog.Models;
using BookCatalog.Services;

namespace BookCatalog.Controllers;


[Route("api/[Controller]")]
[ApiController]
public class BookController : ControllerBase
{

    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {

        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        return await _bookService.GetAllBooksAsync();
    }
    [HttpGet("{bookId}")]
    public async Task<ActionResult<Book>> GetBookById(int bookId)
    {
        return await _bookService.GetBookByIdAsync(bookId);
    }
    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook(BookDTO newBook)
    {
        return await _bookService.CreateBookAsync(newBook);
    }
    [HttpPatch("{bookId}/restock")]
    public async Task<ActionResult> RestockBook(int bookId, int numBooks)
    {
        await _bookService.RestockBook(bookId, numBooks);

        return NoContent();
    }
    [HttpPatch("{bookId}/changePrice")]
    public async Task<ActionResult> ChangeBookPrice(int bookId, decimal price)
    {
        await _bookService.ChangePrice(bookId, price);

        return NoContent();
    }






}