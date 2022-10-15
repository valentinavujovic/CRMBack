using System.Security.Cryptography;
using System.Text;

namespace CRMSYSTEMBACK.Helpers;
  
    public class Encription
    {
     
        public String HashString(string password)
        {
            StringBuilder sb = new StringBuilder();
            foreach(byte b in GetHash(password))
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
        public static byte[] GetHash(string password)
        {
            using(HashAlgorithm algorithm = SHA256.Create())
            {
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(password)); 
            }
        }
    }

