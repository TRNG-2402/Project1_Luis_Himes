
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.DTOs;

public class NewAuthorDTO
{
    [Required]
    public string? Name { get; set; }
}