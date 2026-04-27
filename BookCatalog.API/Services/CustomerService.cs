

using BookCatalog.Data;
using BookCatalog.DTOs;
using BookCatalog.Models;

namespace BookCatalog.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepo _repo;

    public CustomerService(ICustomerRepo repo)
    {
        _repo = repo;
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        List<Customer> result = await _repo.GetAllCustomersAsync();

        if (result is null)
            throw new NullReferenceException("Somehow . . . no customers?");

        return result;
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        Customer? result = await _repo.GetCustomerByIdAsync(id);

        if (result is null)
            throw new NullReferenceException("This customer doesn't exist.");

        return result;
    }

    public async Task<Customer> CreateCustomerAsync(CustomerDTO customerToAdd)
    {
        Customer newCust = new Customer();

        newCust.First_Name = customerToAdd.First_Name;
        newCust.Last_Name = customerToAdd.Last_Name;
        newCust.DateOfBirth = customerToAdd.DateOfBirth;
        newCust.Email = customerToAdd.Email;
        newCust.PhoneNumber = customerToAdd.PhoneNumber;
        newCust.Address = customerToAdd.Address;

        Customer createdCustomer = await _repo.CreateCustomerAsync(newCust);
        return createdCustomer;
    }

    public async Task UpdateCustomerDetailsAsync(CustomerDTO updatedCustomer)
    {
        if (updatedCustomer.CustomerId <= 0)
            throw new ArgumentOutOfRangeException("ID must be greater than 0!");
        Customer? customer = await _repo.GetCustomerByIdAsync(updatedCustomer.CustomerId);

        if (customer is null)
            throw new KeyNotFoundException($"Customer {updatedCustomer.First_Name} {updatedCustomer.Last_Name} doesn't exist.");

        customer.First_Name = updatedCustomer.First_Name;
        customer.Last_Name = updatedCustomer.Last_Name;
        customer.DateOfBirth = updatedCustomer.DateOfBirth;
        customer.Email = updatedCustomer.Email;
        customer.PhoneNumber = updatedCustomer.PhoneNumber;
        customer.Address = updatedCustomer.Address;

        await _repo.UpdateCustomerDetailsAsync(customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException("ID must be greater than 0!");

        Customer? genre = await _repo.GetCustomerByIdAsync(id);

        if (genre is null)
            throw new KeyNotFoundException("This customer doesn't exist.");

        await _repo.DeleteCustomerAsync(genre);
    }


}