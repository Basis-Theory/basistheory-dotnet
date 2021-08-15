using System;
using System.Threading.Tasks;
using BasisTheory.net.Encryption;
using BasisTheory.net.Encryption.Entities;
using LazyCache;
using Moq;
using Xunit;

namespace BasisTheory.net.Tests.Encryption
{
    public class ProviderKeyServiceTests
    {
        private const string provider = "INMEMORY";
        private const string algorithm = "RSA";

        private readonly IAppCache _cache;
        private readonly Mock<IProviderKeyFactory> _providerKeyFactory;
        private readonly IProviderKeyService _providerKeyService;

        public ProviderKeyServiceTests()
        {
            _cache = new CachingService();

            _providerKeyFactory = new Mock<IProviderKeyFactory>();
            _providerKeyFactory.Setup(x => x.Algorithm).Returns(algorithm);
            _providerKeyFactory.Setup(x => x.Provider).Returns(provider);

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

            _providerKeyFactory.Setup(x => x.GetByKeyIdAsync(keyId)).ReturnsAsync(expectedProviderKey);

            var providerKey = await _providerKeyService.GetByKeyIdAsync(keyId, provider, algorithm);
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

            var providerKey = await _providerKeyService.GetByKeyIdAsync(keyId, provider, algorithm);
            Assert.Equal(expectedProviderKey.KeyId, providerKey.KeyId);

            var cachedProviderKey = await _cache.GetAsync<ProviderEncryptionKey>(cacheKey);
            Assert.Equal(expectedProviderKey.KeyId, cachedProviderKey.KeyId);

            _providerKeyFactory.Verify(x => x.GetByKeyIdAsync(keyId), Times.Never);
        }

        [Fact]
        public async Task ShouldRetrieveKeyByNameFromCache()
        {
            var keyName = Guid.NewGuid().ToString();
            var cacheKey = $"providerkeys_{keyName}_{provider}_{algorithm}";

            var expectedProviderKey = new ProviderEncryptionKey
            {
                KeyId = Guid.NewGuid().ToString(),
                Name = keyName,
                Provider = provider,
                Algorithm = algorithm
            };

            _cache.Add(cacheKey, expectedProviderKey);

            var providerKey = await _providerKeyService.GetOrCreateAsync(keyName, provider, algorithm);
            Assert.Equal(expectedProviderKey.KeyId, providerKey.KeyId);

            var cachedProviderKey = await _cache.GetAsync<ProviderEncryptionKey>(cacheKey);
            Assert.Equal(expectedProviderKey.KeyId, cachedProviderKey.KeyId);

            _providerKeyFactory.Verify(x => x.GetOrCreateAsync(keyName), Times.Never);
        }

        [Fact]
        public async Task ShouldCreateAndSaveKeyIfNotExists()
        {
            var keyName = Guid.NewGuid().ToString();
            var cacheKey = $"providerkeys_{keyName}_{provider}_{algorithm}";

            var expectedProviderKey = new ProviderEncryptionKey
            {
                KeyId = Guid.NewGuid().ToString(),
                Name = keyName,
                Provider = provider,
                Algorithm = algorithm
            };

            _providerKeyFactory.Setup(x => x.GetOrCreateAsync(keyName))
                .ReturnsAsync(expectedProviderKey);

            var providerKey = await _providerKeyService.GetOrCreateAsync(keyName, provider, algorithm);
            Assert.Equal(expectedProviderKey.KeyId, providerKey.KeyId);

            var cachedProviderKey = await _cache.GetAsync<ProviderEncryptionKey>(cacheKey);
            Assert.Equal(expectedProviderKey.KeyId, cachedProviderKey.KeyId);
        }
    }
}
