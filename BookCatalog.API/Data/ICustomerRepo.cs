
using BookCatalog.Models;

namespace BookCatalog.Data;

public interface ICustomerRepo
{

    Task<List<Customer>> GetAllCustomersAsync();

    Task<Customer> CreateCustomerAsync(Customer customerToAdd);

    Task<Customer?> GetCustomerByIdAsync(int id);

    Task DeleteCustomerAsync(Customer customerToDelete);

    Task UpdateCustomerDetailsAsync(Customer updatedCustomer);
}