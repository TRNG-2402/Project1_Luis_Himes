

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCatalog.Models;

public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    public DateTime DateOrdered { get; set; } = DateTime.Now;

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    public Customer Customer { get; set; } = null!;

    public List<Book> Books { get; set; } = new List<Book>();


}