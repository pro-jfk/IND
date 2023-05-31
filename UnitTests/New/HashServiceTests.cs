using System.Text;
using App.Services.impl;

namespace UnitTests.New;

public class HashServiceTests
{
    [Fact]
    public void Hash_ThrowsException_FingerprintIsNull()
    {
        // Arrange
        var hashService = new HashService();
        var salt = hashService.CreateSalt();

        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => hashService.Hash(null, salt));
    }

    [Fact]
    public async Task Verify_Success()
    {
        // Arrange
        var hashService = new HashService();
        var fingerprint = "fingerprint";
        var salt = hashService.CreateSalt();
        var hash = await hashService.Hash(fingerprint, salt);

        // Act
        var result = await hashService.Verify(fingerprint, salt, hash);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Verify_Failure()
    {
        // Arrange
        var hashService = new HashService();
        var fingerprint = "fingerprint";
        var salt = hashService.CreateSalt();
        var hash = await hashService.Hash(fingerprint, salt);

        // Act
        var result = await hashService.Verify(fingerprint, salt, Encoding.UTF8.GetBytes("wrongHash"));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CreateSalt_ReturnsByteArray()
    {
        var hashService = new HashService();
        var result = hashService.CreateSalt();

        Assert.Equal(16, result.Length);
    }
}