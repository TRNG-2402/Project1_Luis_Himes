
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.DTOs;

public class CustomerDTO
{

    public int CustomerId { get; set; }
    [Required]
    public string First_Name { get; set; } = string.Empty;

    [Required]
    public string Last_Name { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; } = DateTime.Now;

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

}