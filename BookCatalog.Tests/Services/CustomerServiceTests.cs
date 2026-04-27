using Moq;
using BookCatalog.Data;
using BookCatalog.Models;
using BookCatalog.Services;
using BookCatalog.DTOs;

namespace BookCatalog.Tests.Services;

public class CustomerServiceTests
{
    private readonly Mock<ICustomerRepo> _repoMock;

    private readonly CustomerService _sut;

    public CustomerServiceTests()
    {
        _repoMock = new Mock<ICustomerRepo>();
        _sut = new CustomerService(_repoMock.Object);
    }
    [Fact]
    public async Task UpdateCustomerDetailsAsync_InvalidId_ThrowsAndNeverTouchesRepo()
    {
        CustomerDTO testDTO = new CustomerDTO();
        testDTO.CustomerId = 0;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
            () => _sut.UpdateCustomerDetailsAsync(testDTO)
        );

        _repoMock.Verify(r => r.GetCustomerByIdAsync(It.IsAny<int>()), Times.Never);
        _repoMock.Verify(r => r.UpdateCustomerDetailsAsync(It.IsAny<Customer>()), Times.Never);
    }
    [Fact]
    public async Task DeleteCustomerAsync_InvalidId_ThrowsAndNeverTouchesRepo()
    {
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
            () => _sut.DeleteCustomerAsync(0)
        );
        _repoMock.Verify(r => r.GetCustomerByIdAsync(It.IsAny<int>()), Times.Never);
        _repoMock.Verify(r => r.DeleteCustomerAsync(It.IsAny<Customer>()), Times.Never);
    }
}