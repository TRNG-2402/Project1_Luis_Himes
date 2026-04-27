using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCatalog.Models;

public class Author
{
    [Key]
    public int AuthorId { get; set; }

    [Required]

    public string Name { get; set; } = string.Empty;

    public List<Book> Books { get; set; } = new List<Book>();
}