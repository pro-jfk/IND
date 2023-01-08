namespace App.Services;

public interface IHashService
{
    Task<string> Hash(string fingerprint, byte [] salt);

    Task<bool> Verify(string fingerprint, byte [] salt, string hash);
    byte[] CreateSalt();
}