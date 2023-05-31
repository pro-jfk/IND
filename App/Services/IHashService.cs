namespace App.Services;

public interface IHashService
{
    Task<byte[]> Hash(string fingerprint, byte[] salt);

    Task<bool> Verify(string fingerprint, byte[] salt, byte[] hash);
    byte[] CreateSalt();
}