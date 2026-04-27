using Microsoft.AspNetCore.Mvc;
using BookCatalog.DTOs;
using BookCatalog.Models;
using BookCatalog.Services;

namespace BookCatalog.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
    {
        return await _authorService.GetAllAuthorsAsync();
    }

    [HttpGet("{authorId}")]
    public async Task<ActionResult<Author>> GetAuthorById(int authorId)
    {
        return await _authorService.GetAuthorByIdAsync(authorId);
    }

    [HttpPost]
    public async Task<ActionResult<Author>> CreateAuthor(NewAuthorDTO newAuthor)
    {
        return await _authorService.CreateAuthorAsync(newAuthor);
    }



}