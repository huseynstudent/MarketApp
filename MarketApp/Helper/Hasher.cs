using System;
using System.Security.Cryptography;
using System.Text;

namespace ExamProject.Security;

public class Hasher
{
    public string Hash(string input)
    {
        using (SHA256 sha = SHA256.Create())
        {
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            foreach (var b in bytes)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
    }
    public bool Verify(string input, string storedHash)
    {
        string hashOfInput = Hash(input);
        return hashOfInput.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
    }
}
