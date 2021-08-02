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
        private readonly Mock<IProviderKeyRespository> _providerKeyRespository;
        private readonly IProviderKeyService _providerKeyService;

        public ProviderKeyServiceTests()
        {
            _cache = new CachingService();
            _providerKeyRespository = new Mock<IProviderKeyRespository>();
            _providerKeyService = new ProviderKeyService(_cache, _providerKeyRespository.Object,
                new [] { new StubProviderKeyFactory() });
        }

        [Fact]
        public async Task ShouldRetrieveKeyByIdFromRepositoryIfNotCached()
        {
            var keyId = Guid.NewGuid().ToString();
            var cacheKey = $"providerkeys_{keyId}";

            var expectedProviderKey = new ProviderEncryptionKey
            {
                KeyId = keyId
            };

            _providerKeyRespository.Setup(x => x.GetKeyByKeyIdAsync(keyId)).ReturnsAsync(expectedProviderKey);

            var providerKey = await _providerKeyService.GetKeyByKeyIdAsync(keyId);
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

            var providerKey = await _providerKeyService.GetKeyByKeyIdAsync(keyId);
            Assert.Equal(expectedProviderKey.KeyId, providerKey.KeyId);

            var cachedProviderKey = await _cache.GetAsync<ProviderEncryptionKey>(cacheKey);
            Assert.Equal(expectedProviderKey.KeyId, cachedProviderKey.KeyId);

            _providerKeyRespository.Verify(x => x.GetKeyByKeyIdAsync(keyId), Times.Never);
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

            _providerKeyRespository.Verify(x => x.GetKeyByNameAsync(keyName, provider, algorithm), Times.Never);
        }

        [Fact]
        public async Task ShouldRetrieveKeyByNameFromRepositoryIfNotInCache()
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

            _providerKeyRespository.Setup(x => x.GetKeyByNameAsync(keyName, provider, algorithm))
                .ReturnsAsync(expectedProviderKey);

            var providerKey = await _providerKeyService.GetOrCreateAsync(keyName, provider, algorithm);
            Assert.Equal(expectedProviderKey.KeyId, providerKey.KeyId);

            var cachedProviderKey = await _cache.GetAsync<ProviderEncryptionKey>(cacheKey);
            Assert.Equal(expectedProviderKey.KeyId, cachedProviderKey.KeyId);

            _providerKeyRespository.Verify(x => x.SaveAsync(It.IsAny<ProviderEncryptionKey>()), Times.Never);
        }

        [Fact]
        public async Task ShouldCreateAndSaveKeyIfNotExists()
        {
            var keyId = Guid.NewGuid().ToString();
            var keyName = Guid.NewGuid().ToString();
            var cacheKey = $"providerkeys_{keyName}_{provider}_{algorithm}";

            ProviderEncryptionKey savedProviderKey = null;

            _providerKeyRespository.Setup(x => x.SaveAsync(It.IsAny<ProviderEncryptionKey>()))
                .Returns<ProviderEncryptionKey>(Task.FromResult)
                .Callback<ProviderEncryptionKey>(key =>
                {
                    key.KeyId = keyId;
                    savedProviderKey = key;
                });

            var providerKey = await _providerKeyService.GetOrCreateAsync(keyName, provider, algorithm);
            Assert.NotNull(savedProviderKey);
            Assert.Equal(keyId, providerKey.KeyId);
            Assert.Equal(provider, providerKey.Provider);
            Assert.Equal(algorithm, providerKey.Algorithm);
            Assert.Equal(keyName, providerKey.Name);
            Assert.Equal(savedProviderKey.ProviderKeyId, providerKey.ProviderKeyId);
            Assert.Equal(savedProviderKey.ExpirationDate, providerKey.ExpirationDate);

            var cachedProviderKey = await _cache.GetAsync<ProviderEncryptionKey>(cacheKey);
            Assert.Equal(keyId, cachedProviderKey.KeyId);
        }

        private class StubProviderKeyFactory : IProviderKeyFactory
        {
            public string Provider => "INMEMORY";
            public string Algorithm => "RSA";

            public Task<ProviderEncryptionKey> Create(string name)
            {
                return Task.FromResult(new ProviderEncryptionKey
                {
                    Name = name,
                    Algorithm = Algorithm,
                    Provider = Provider,
                    ProviderKeyId = Guid.NewGuid().ToString(),
                    ExpirationDate = DateTimeOffset.UtcNow.AddDays(30)
                });
            }
        }
    }
}
