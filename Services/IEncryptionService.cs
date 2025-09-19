namespace caso2net.Services;

public interface IEncryptionService
{
    string EncryptString(string plainText);
    string DecryptString(string cipherText);
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
    string GenerateSecureToken();
}