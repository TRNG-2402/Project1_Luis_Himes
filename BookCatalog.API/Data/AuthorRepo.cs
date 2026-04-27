

using BookCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Data;

public class AuthorRepo : IAuthorRepo
{

    private readonly AppDbContext _context;

    public AuthorRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Author>> GetAllAuthorsAsync()
    {
        List<Author> result = await _context.Authors.ToListAsync();
        return result;
    }

    public async Task<Author> CreateAuthorAsync(Author authorToAdd)
    {
        _context.Authors.Add(authorToAdd);

        await _context.SaveChangesAsync();

        return authorToAdd;
    }

    public async Task<Author?> GetAuthorByIdAsync(int id)
    {
        return await _context.Authors.FindAsync(id);
    }

    public async Task DeleteAuthorAsync(Author authorToDelete)
    {
        _context.Authors.Remove(authorToDelete);
        await _context.SaveChangesAsync();
    }


}