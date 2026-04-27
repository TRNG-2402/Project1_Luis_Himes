
using BookCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Data;

public class CustomerRepo : ICustomerRepo
{
    private readonly AppDbContext _context;

    public CustomerRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        List<Customer> result = await _context.Customers.ToListAsync();
        return result;
    }

    public async Task<Customer> CreateCustomerAsync(Customer customerToAdd)
    {
        _context.Customers.Add(customerToAdd);
        await _context.SaveChangesAsync();
        return customerToAdd;
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task DeleteCustomerAsync(Customer customerToDelete)
    {
        _context.Customers.Remove(customerToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCustomerDetailsAsync(Customer updatedCustomer)
    {
        Customer? customer = await _context.Customers
            .FirstOrDefaultAsync(p => p.CustomerId == updatedCustomer.CustomerId);

        if (customer is null)
            throw new KeyNotFoundException($"Customer {updatedCustomer.First_Name} {updatedCustomer.Last_Name} not found");
        customer.First_Name = updatedCustomer.First_Name;
        customer.Last_Name = updatedCustomer.Last_Name;
        customer.DateOfBirth = updatedCustomer.DateOfBirth;
        customer.Email = updatedCustomer.Email;
        customer.PhoneNumber = updatedCustomer.PhoneNumber;
        customer.Address = updatedCustomer.Address;
        await _context.SaveChangesAsync();
    }
}