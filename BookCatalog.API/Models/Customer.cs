using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCatalog.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required]
    [MaxLength(100)]
    public string First_Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Last_Name { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; } = DateTime.Now;

    [MaxLength(500)]
    public string? Email { get; set; }

    [MaxLength(10)]
    public string? PhoneNumber { get; set; }

    [MaxLength(500)]
    public string? Address { get; set; }

    public List<Order> Orders { get; set; } = new List<Order>();

}