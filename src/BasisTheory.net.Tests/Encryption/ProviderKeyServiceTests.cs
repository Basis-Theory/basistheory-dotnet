using System;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Encryption;
using BasisTheory.net.Encryption.Entities;
using BasisTheory.net.Tokens.Entities;
using LazyCache;
using Moq;
using Xunit;

namespace BasisTheory.net.Tests.Encryption
{
    public class ProviderKeyServiceTests
    {
        private const string Provider = "INMEMORY";
        private const string Algorithm = "RSA";

        private readonly IAppCache _cache;
        private readonly Mock<IProviderKeyFactory> _providerKeyFactory;
        private readonly IProviderKeyService _providerKeyService;

        public ProviderKeyServiceTests()
        {
            _cache = new CachingService();

            _providerKeyFactory = new Mock<IProviderKeyFactory>();
            _providerKeyFactory.Setup(x => x.Algorithm).Returns(Algorithm);
            _providerKeyFactory.Setup(x => x.Provider).Returns(Provider);

            _providerKeyService = new ProviderKeyService(_cache, new [] { _providerKeyFactory.Object });
        }

        [Fact]
        public async Task ShouldRetrieveKeyByIdIfNotCached()
        {
            var keyId = Guid.NewGuid().ToString();
            var cacheKey = $"providerkeys_{keyId}";

            var expectedProviderKey = new ProviderEncryptionKey
            {
                KeyId = keyId
            };

            _providerKeyFactory.Setup(x => x.GetKeyByKeyIdAsync(keyId, It.IsAny<CancellationToken>())).ReturnsAsync(expectedProviderKey);

            var providerKey = await _providerKeyService.GetKeyByKeyIdAsync(keyId, Provider, Algorithm);
            Assert.Equal(expectedProviderKey.KeyId, providerKey.KeyId);

            var cachedProviderKey = await _cache.GetAsync<ProviderEncryptionKey>(cacheKey);
            Assert.Equal(expectedProviderKey.KeyId, cachedProviderKey.KeyId);
        }

        [Fact]
        public async Task ShouldRetrieveKeyByIdFromCache()
        {
            var keyId = Guid.NewGuid().ToString();
            var cacheKey = $"providerkeys_{keyId}";

            var expectedProviderKey = new ProviderEncryptionKey
            {
                KeyId = keyId
            };

            _cache.Add(cacheKey, expectedProviderKey);

            var providerKey = await _providerKeyService.GetKeyByKeyIdAsync(keyId, Provider, Algorithm);
            Assert.Equal(expectedProviderKey.KeyId, providerKey.KeyId);

            var cachedProviderKey = await _cache.GetAsync<ProviderEncryptionKey>(cacheKey);
            Assert.Equal(expectedProviderKey.KeyId, cachedProviderKey.KeyId);

            _providerKeyFactory.Verify(x => x.GetKeyByKeyIdAsync(keyId, It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task ShouldRetrieveKeyByIdWithEncryptionKey()
        {
            var keyId = Guid.NewGuid().ToString();
            var cacheKey = $"providerkeys_{keyId}";

            var expectedProviderKey = new ProviderEncryptionKey
            {
                KeyId = keyId
            };

            _providerKeyFactory.Setup(x => x.GetKeyByKeyIdAsync(keyId, It.IsAny<CancellationToken>())).ReturnsAsync(expectedProviderKey);

            var providerKey = await _providerKeyService.GetKeyByKeyIdAsync(new EncryptionKey
            {
                Key = keyId,
                Provider = Provider,
                Algorithm = Algorithm
            });
            Assert.Equal(expectedProviderKey.KeyId, providerKey.KeyId);

            var cachedProviderKey = await _cache.GetAsync<ProviderEncryptionKey>(cacheKey);
            Assert.Equal(expectedProviderKey.KeyId, cachedProviderKey.KeyId);
        }

        [Fact]
        public async Task ShouldRetrieveKeyByNameFromCache()
        {
            var keyName = Guid.NewGuid().ToString();
            var cacheKey = $"providerkeys_{keyName}_{Provider}_{Algorithm}";

            var expectedProviderKey = new ProviderEncryptionKey
            {
                KeyId = Guid.NewGuid().ToString(),
                Name = keyName,
                Provider = Provider,
                Algorithm = Algorithm
            };

            _cache.Add(cacheKey, expectedProviderKey);

            var providerKey = await _providerKeyService.GetOrCreateKeyAsync(keyName, Provider, Algorithm);
            Assert.Equal(expectedProviderKey.KeyId, providerKey.KeyId);

            var cachedProviderKey = await _cache.GetAsync<ProviderEncryptionKey>(cacheKey);
            Assert.Equal(expectedProviderKey.KeyId, cachedProviderKey.KeyId);

            _providerKeyFactory.Verify(x => x.GetOrCreateKeyAsync(keyName, It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task ShouldCreateAndSaveKeyIfNotExists()
        {
            var keyName = Guid.NewGuid().ToString();
            var cacheKey = $"providerkeys_{keyName}_{Provider}_{Algorithm}";

            var expectedProviderKey = new ProviderEncryptionKey
            {
                KeyId = Guid.NewGuid().ToString(),
                Name = keyName,
                Provider = Provider,
                Algorithm = Algorithm
            };

            _providerKeyFactory.Setup(x => x.GetOrCreateKeyAsync(keyName, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProviderKey);

            var providerKey = await _providerKeyService.GetOrCreateKeyAsync(keyName, Provider, Algorithm);
            Assert.Equal(expectedProviderKey.KeyId, providerKey.KeyId);

            var cachedProviderKey = await _cache.GetAsync<ProviderEncryptionKey>(cacheKey);
            Assert.Equal(expectedProviderKey.KeyId, cachedProviderKey.KeyId);
        }
    }
}
