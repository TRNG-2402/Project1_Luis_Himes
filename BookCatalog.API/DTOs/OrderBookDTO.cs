
namespace BookCatalog.DTOs;

public class OrderBookDTO
{
    public int BookId { get; set; }
    public int OrderId { get; set; }

    public DateTime DateOrdered { get; set; }

    public int CustomerId { get; set; }
}