using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace App.Services.impl;

public class HashService : IHashService
{
    public async Task<string> Hash(string fingerprint, byte [] salt)
    {
        var argon2 = new Argon2i(Encoding.UTF8.GetBytes(fingerprint));
        argon2.Salt = salt;
        argon2.Iterations = 2;
        argon2.MemorySize = 65586;
        argon2.Iterations = 4;
        argon2.DegreeOfParallelism = 2;
        var result = await argon2.GetBytesAsync(128);
        return result.ToString();
    }

    public async Task<bool> Verify(string fingerprint, byte [] salt, string hash)
    {
        var newHash = await Hash(fingerprint, salt);
        // byte[] newHashBytes = Encoding.UTF8.GetBytes(newHash);
        return hash.Equals(newHash);
    }

    public byte[] CreateSalt()
    {
        var buffer = new byte[16];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(buffer);
        return buffer;
    }
}

