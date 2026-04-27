
using BookCatalog.DTOs;
using BookCatalog.Models;

namespace BookCatalog.Services;

public interface ICustomerService
{
    Task<List<Customer>> GetAllCustomersAsync();

    Task<Customer> CreateCustomerAsync(CustomerDTO customerToAdd);

    Task<Customer> GetCustomerByIdAsync(int id);

    Task DeleteCustomerAsync(int id);

    Task UpdateCustomerDetailsAsync(CustomerDTO updatedCustomer);


}