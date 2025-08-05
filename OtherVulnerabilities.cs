using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace OtherVulnerabilities
{
    class Program
    {
        // Example 1: Hardcoded cryptographic key
        static void HardcodedKeyExample()
        {
            // Vulnerable: hardcoded encryption key
            string key = "mysecretkey12345";
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key.PadRight(32));
                aesAlg.IV = new byte[16];
                byte[] encrypted = aesAlg.CreateEncryptor().TransformFinalBlock(
                    Encoding.UTF8.GetBytes("Sensitive Data"), 0, "Sensitive Data".Length);
                Console.WriteLine("Encrypted data: " + Convert.ToBase64String(encrypted));
            }
        }

        // Example 2: Insecure random number generation
        static void InsecureRandomExample()
        {
            // Vulnerable: using System.Random for security-sensitive values
            Random random = new Random();
            int insecureToken = random.Next();
            Console.WriteLine("Insecure token: " + insecureToken);
        }

        // Example 3: Open redirect vulnerability
        static void OpenRedirectExample(string url)
        {
            // Vulnerable: direct use of user input in redirect
            Console.WriteLine("Redirecting to: " + url);
            // In a real web app, this would be something like:
            // Response.Redirect(url);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Other examples of vulnerabilities in C#");
            HardcodedKeyExample();
            InsecureRandomExample();
            OpenRedirectExample("http://malicious-site.com");
        }
    }
}
