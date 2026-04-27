using System.ComponentModel.DataAnnotations;

namespace BookCatalog.DTOs;

public class NewGenreDTO
{

    public int GenreId { get; set; }
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }
}