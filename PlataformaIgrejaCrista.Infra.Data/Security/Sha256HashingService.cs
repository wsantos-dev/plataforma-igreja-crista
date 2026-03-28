using PlataformaIgrejaCrista.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PlataformaIgrejaCrista.Infra.Data.Security
{
    /// <summary>
    /// SHA-256 hashing implementation.
    /// </summary>
    public sealed class Sha256HashingService : IHashingService
    {
        public string ComputeSha256(string input)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(bytes);
        }
    }
}
