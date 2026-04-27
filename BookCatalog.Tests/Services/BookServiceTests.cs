using BookCatalog.Models;
using BookCatalog.Services;
using BookCatalog.Data;
using Moq;

namespace BookCatalog.Tests.Services;

public class BookServiceTests
{
    private readonly Mock<IBookRepo> _repoMock;

    private readonly BookService _sut;

    public BookServiceTests()
    {
        _repoMock = new Mock<IBookRepo>();

        _sut = new BookService(_repoMock.Object);
    }
    [Fact]
    public async Task GetBookByIdAsync_InvalidId_ThrowsNullReferenceException()
    {
        await Assert.ThrowsAsync<NullReferenceException>(
            () => _sut.GetBookByIdAsync(20000)
        );

        _repoMock.Verify(r => r.GetBookByIdAsync(It.IsAny<int>()), Times.Once);
    }

}