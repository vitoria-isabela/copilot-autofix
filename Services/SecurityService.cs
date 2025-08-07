using System.Security.Cryptography;
using System.Text;

public class SecurityService
{
    public string HashPassword(string password)
    {
        /// <summary>
        /// VULNERABILITY: Use of a Broken or Risky Cryptographic Algorithm.
        /// MD5 is considered insecure for password hashing.
        /// </summary>
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }
    }

    public int GenerateInsecureToken()
    {
        /// <summary>
        /// VULNERABILITY: Use of Insecure Random Number Generator.
        /// System.Random is not cryptographically secure for generating tokens or secrets.
        /// </summary>
        Random rand = new Random();
        return rand.Next(1000, 9999);
    }
}