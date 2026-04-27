using Moq;
using BookCatalog.Data;
using BookCatalog.Models;
using BookCatalog.Services;

namespace BookCatalog.Tests.Services;

public class AuthorServiceTests
{
    private readonly Mock<IAuthorRepo> _repoMock;

    private readonly AuthorService _sut;

    public AuthorServiceTests()
    {
        _repoMock = new Mock<IAuthorRepo>();

        _sut = new AuthorService(_repoMock.Object);
    }

    [Fact]
    public async Task DeleteAuthorAsync_InvalidId_ThrowsAndNeverTouchesRepo()
    {
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
            () => _sut.DeleteAuthorAsync(0)
        );

        _repoMock.Verify(r => r.GetAuthorByIdAsync(It.IsAny<int>()), Times.Never);
        _repoMock.Verify(r => r.DeleteAuthorAsync(It.IsAny<Author>()), Times.Never);
    }
}