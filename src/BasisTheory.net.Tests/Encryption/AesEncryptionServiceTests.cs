using System.Security.Cryptography;
using System.Threading.Tasks;
using BasisTheory.net.Encryption;
using Bogus;
using Xunit;

namespace BasisTheory.net.Tests.Encryption
{
    public class AesEncryptionServiceTests
    {
        [Fact]
        public async Task ShouldEncryptAndDecryptWithAESKey()
        {
            var faker = new Faker();

            var expectedPlaintext = faker.Lorem.Paragraph();

            using var aesKey = Aes.Create();

            var ciphertext = await AesEncryptionService.EncryptAsync(aesKey, expectedPlaintext);
            var plaintext = await AesEncryptionService.DecryptAsync(aesKey, ciphertext);

            Assert.Equal(expectedPlaintext, plaintext);
        }
    }
}
