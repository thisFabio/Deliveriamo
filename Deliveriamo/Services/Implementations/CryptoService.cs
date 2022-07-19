using Deliveriamo.Services.Interfaces;

namespace Deliveriamo.Services.Implementations
{
    public class CryptoService : ICryptoService
    {
        public string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);

            }
        }
    }
}
