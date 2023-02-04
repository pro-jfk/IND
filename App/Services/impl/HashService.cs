using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace App.Services.impl;

public class HashService : IHashService
{
    public async Task<byte[]> Hash(string fingerprint, byte[] salt)
    {
        byte[] bytesFingerprint = Encoding.UTF8.GetBytes(fingerprint);
        Argon2id argon2Id = new Argon2id(bytesFingerprint)
        {
            Salt = salt,
            Iterations = 2,
            MemorySize = 4096,
            DegreeOfParallelism = 3
        };
        var result = await argon2Id.GetBytesAsync(128);
        return result;
    }

    public async Task<bool> Verify(string fingerprint, byte[] salt, byte[] hash)
    {
        var newHash = await Hash(fingerprint, salt);
        // byte[] newHashBytes = Encoding.UTF8.GetBytes(newHash);
        return hash.SequenceEqual(newHash);
    }

    public byte[] CreateSalt()
    {
        var buffer = new byte[16];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(buffer);
        return buffer;
    }
}