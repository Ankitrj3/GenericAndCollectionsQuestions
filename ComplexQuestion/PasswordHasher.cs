// Secure Password Storage Utility (Hashing + Salt)
// string HashPassword(string password) 
// bool VerifyPassword(string password, string storedHash) 
// Must use salt, strong hashing, no plain text

using System.Security.Cryptography;
using System.Text;

public class PasswordHasher
{
    public string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, 10000, HashAlgorithmName.SHA256, 20);
        
        byte[] combined = new byte[36];
        Buffer.BlockCopy(salt, 0, combined, 0, 16);
        Buffer.BlockCopy(hash, 0, combined, 16, 20);
        
        return Convert.ToBase64String(combined);
    }

    public bool VerifyPassword(string password, string storedHash)
    {
        byte[] combined = Convert.FromBase64String(storedHash);
        
        byte[] salt = new byte[16];
        Buffer.BlockCopy(combined, 0, salt, 0, 16);
        
        byte[] storedHashBytes = new byte[20];
        Buffer.BlockCopy(combined, 16, storedHashBytes, 0, 20);
        
        byte[] testHash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, 10000, HashAlgorithmName.SHA256, 20);
        
        for(int i = 0; i < 20; i++)
        {
            if(storedHashBytes[i] != testHash[i])
                return false;
        }
        return true;
    }
}
