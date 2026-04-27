using Moq;
using BookCatalog.Data;
using BookCatalog.Models;
using BookCatalog.Services;

namespace BookCatalog.Tests.Services;

public class GenreServiceTests
{

    private readonly Mock<IGenreRepo> _repoMock;


    private readonly GenreService _sut;


    public GenreServiceTests()
    {

        _repoMock = new Mock<IGenreRepo>();



        _sut = new GenreService(_repoMock.Object);
    }
    [Fact]
    public async Task DeleteGenreAsync_InvalidId_ThrowsAndNeverTouchesRepo()
    {
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
            () => _sut.DeleteGenreAsync(0)
        );

        _repoMock.Verify(r => r.GetGenreByIdAsync(It.IsAny<int>()), Times.Never);
        _repoMock.Verify(r => r.DeleteGenreAsync(It.IsAny<Genre>()), Times.Never);

    }


}