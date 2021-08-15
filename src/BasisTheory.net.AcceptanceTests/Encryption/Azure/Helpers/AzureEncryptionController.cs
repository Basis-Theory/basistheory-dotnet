using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BasisTheory.net.Encryption;
using BasisTheory.net.Encryption.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BasisTheory.net.AcceptanceTests.Encryption.Azure.Helpers
{
    [Route("encryption/azure")]
    [ApiController]
    public class AzureEncryptionController : ControllerBase
    {
        private readonly IProviderKeyService _providerKeyService;
        private readonly IEncryptionService _encryptionService;
        private const string Provider = "AZURE";

        public AzureEncryptionController(IProviderKeyService providerKeyService, IEncryptionService encryptionService)
        {
            _providerKeyService = providerKeyService;
            _encryptionService = encryptionService;
        }

        [HttpPost("encrypt")]
        public async Task<IActionResult> Encrypt([FromBody] EncryptRequest request)
        {
            var providerEncryptionKey = await _providerKeyService.GetOrCreateKeyAsync(request.KeyName,
                Provider, request.Algorithm);

            var encryptedData = await _encryptionService.Encrypt(request.Plaintext, providerEncryptionKey);

            return Ok(encryptedData);
        }

        [HttpPost("decrypt")]
        public async Task<IActionResult> Decrypt([FromBody] EncryptedData encryptedData)
        {
            var providerKey = await _providerKeyService.GetKeyByKeyIdAsync(encryptedData.KeyEncryptionKey.Key, Provider,
                encryptedData.KeyEncryptionKey.Algorithm);
            if (providerKey == null)
                return NotFound();

            var plaintext = await _encryptionService.Decrypt(encryptedData, providerKey);

            return Ok(plaintext);
        }
    }

    public class EncryptRequest
    {
        [JsonPropertyName("key_name")]
        public string KeyName { get; set; }

        [JsonPropertyName("algorithm")]
        public string Algorithm { get; set; }

        [JsonPropertyName("plaintext")]
        public string Plaintext { get; set; }
    }
}
