using System.Text;
using App.Services.impl;

namespace UnitTests.Services;

public class HashServiceTests
{
    [Fact]
    public async Task HashService_Hash_Verify_Success()
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
    public async Task HashService_Hash_Verify_Failure()
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

}