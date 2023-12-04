using System.Security.Cryptography;
using System.Text;
using TrackMoney.Data.Repos.Repos.Cryptology;

namespace TrackMoney.Services.Cryptology
{
    public class CryptologyService : ICryptologyService
    {
        public async Task<string> EncryptPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(64);
            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password),
                salt,
                350000,
                HashAlgorithmName.SHA512,
                64);
            return Convert.ToHexString(hash);
        }

    }
}
