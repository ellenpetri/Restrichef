using System.Security.Cryptography;

namespace Restrichef.Api.Application.Security;

public static class PasswordHasher
{
    private const int SaltSize = 16;
    private const int KeySize = 32;
    private const int Iterations = 100_000;

    public static string Hash(string senha)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

        byte[] key = Rfc2898DeriveBytes.Pbkdf2(
            senha,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            KeySize
        );

        byte[] result = new byte[SaltSize + KeySize];
        Buffer.BlockCopy(salt, 0, result, 0, SaltSize);
        Buffer.BlockCopy(key, 0, result, SaltSize, KeySize);

        return Convert.ToBase64String(result);
    }

    public static bool Verify(string senha, string hash)
    {
        byte[] decoded = Convert.FromBase64String(hash);

        byte[] salt = new byte[SaltSize];
        Buffer.BlockCopy(decoded, 0, salt, 0, SaltSize);

        byte[] storedKey = new byte[KeySize];
        Buffer.BlockCopy(decoded, SaltSize, storedKey, 0, KeySize);

        byte[] generatedKey = Rfc2898DeriveBytes.Pbkdf2(
            senha,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            KeySize
        );

        return CryptographicOperations.FixedTimeEquals(storedKey, generatedKey);
    }
}