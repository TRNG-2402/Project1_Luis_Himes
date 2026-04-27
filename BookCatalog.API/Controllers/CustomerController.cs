using Microsoft.AspNetCore.Mvc;
using BookCatalog.DTOs;
using BookCatalog.Models;
using BookCatalog.Services;

namespace BookCatalog.Controllers;


[Route("api/[Controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]

    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
    {
        return await _customerService.GetAllCustomersAsync();
    }

    [HttpGet("{customerId}")]
    public async Task<ActionResult<Customer>> GetCustomerById(int customerId)
    {
        return await _customerService.GetCustomerByIdAsync(customerId);
    }
    [HttpPost]
    public async Task<ActionResult<Customer>> CreateCustomer(CustomerDTO newCustomer)
    {
        return await _customerService.CreateCustomerAsync(newCustomer);
    }

    [HttpDelete("{customerId}")]
    public async Task<ActionResult> DeleteCategory(int customerId)
    {
        await _customerService.DeleteCustomerAsync(customerId);
        return NoContent();
    }
    [HttpPatch("{customerId}")]
    public async Task<ActionResult> UpdateCustomer(int customerId, CustomerDTO updatedCustomer)
    {
        updatedCustomer.CustomerId = customerId;
        await _customerService.UpdateCustomerDetailsAsync(updatedCustomer);

        return NoContent();
    }

}