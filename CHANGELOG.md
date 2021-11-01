# [1.12.0](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.11.0...v1.12.0) (2021-11-01)


### Features

* add monthly_active_tokens to TenantUsageReport ([#78](https://github.com/Basis-Theory/basistheory-dotnet/issues/78)) ([46b6b70](https://github.com/Basis-Theory/basistheory-dotnet/commit/46b6b709942de8cb8ce8f7c1ed3fc405c8b3e8ae))

# [1.11.0](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.10.0...v1.11.0) (2021-10-29)


### Features

* Standardizing audit fields across entities ([#77](https://github.com/Basis-Theory/basistheory-dotnet/issues/77)) ([a8634d3](https://github.com/Basis-Theory/basistheory-dotnet/commit/a8634d309049be767286d3e53d685b80b560daa5))

# [1.10.0](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.9.0...v1.10.0) (2021-10-28)


### Features

* add AtomicCard and AtomicBank Update methods ([#73](https://github.com/Basis-Theory/basistheory-dotnet/issues/73)) ([4c00b3d](https://github.com/Basis-Theory/basistheory-dotnet/commit/4c00b3d89f2041d0c45cf17f38997e7877c35d22))

# [1.9.0](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.8.0...v1.9.0) (2021-10-27)


### Features

* Add modified_by and modified_at to base TokenResponse model ([#76](https://github.com/Basis-Theory/basistheory-dotnet/issues/76)) ([a5a5f2f](https://github.com/Basis-Theory/basistheory-dotnet/commit/a5a5f2f4d4d0442057fe0576b766fad1ddc2ae68))

# [1.8.0](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.7.0...v1.8.0) (2021-10-26)


### Features

* add GetTenantUsageReport methods to TenantClient ([#75](https://github.com/Basis-Theory/basistheory-dotnet/issues/75)) ([c5f1d41](https://github.com/Basis-Theory/basistheory-dotnet/commit/c5f1d41130234941129941f36265953324d959a2))

# [1.7.0](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.6.0...v1.7.0) (2021-10-20)


### Features

* makes card expiration date fields optional ([#72](https://github.com/Basis-Theory/basistheory-dotnet/issues/72)) ([8fbda69](https://github.com/Basis-Theory/basistheory-dotnet/commit/8fbda6928f89768d91afc60f26477df74f14b735))

# [1.6.0](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.5.0...v1.6.0) (2021-10-14)


### Features

* adds fingerprint prop to token, cards, and bank response ([#69](https://github.com/Basis-Theory/basistheory-dotnet/issues/69)) ([92c0298](https://github.com/Basis-Theory/basistheory-dotnet/commit/92c0298a69f891912e9fad7ced877e79c3ed68fe))

# [1.5.0](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.4.0...v1.5.0) (2021-10-14)


### Features

* Remove unsupported mask and billing_details Token Types ([#68](https://github.com/Basis-Theory/basistheory-dotnet/issues/68)) ([414af10](https://github.com/Basis-Theory/basistheory-dotnet/commit/414af1076333071eeaa48d8087509fbacf4627b7))

# [1.4.0](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.3.0...v1.4.0) (2021-08-22)


### Features

* Add provider to encryption key and handle it in the encryption service ([#58](https://github.com/Basis-Theory/basistheory-dotnet/issues/58)) ([5b4809e](https://github.com/Basis-Theory/basistheory-dotnet/commit/5b4809e189b587af793cad4d1d88e8e0dd595056))

# [1.3.0](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.2.3...v1.3.0) (2021-08-22)


### Features

* pass cancellationtoken to all encryption methods ([688c3ea](https://github.com/Basis-Theory/basistheory-dotnet/commit/688c3ea93668b5169322901be20fd48c41d6850c))

## [1.2.3](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.2.2...v1.2.3) (2021-08-22)


### Bug Fixes

* ignore default values when serializing ([c745e76](https://github.com/Basis-Theory/basistheory-dotnet/commit/c745e76c60282e09a2bd1a73d6f06d5b988dd1af))
* set serialization order ([33e2d3b](https://github.com/Basis-Theory/basistheory-dotnet/commit/33e2d3ba159e146c909244715a78b97f95c0f379))

## [1.2.2](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.2.1...v1.2.2) (2021-08-15)


### Bug Fixes

* Remove duplicate extension method ([bd0866d](https://github.com/Basis-Theory/basistheory-dotnet/commit/bd0866d71b907859f63e9015bf93cb06f5293ff7))

## [1.2.1](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.2.0...v1.2.1) (2021-08-15)


### Bug Fixes

* make token id not nullable ([0c78ec7](https://github.com/Basis-Theory/basistheory-dotnet/commit/0c78ec7126da4ba974aa0edc20e3b462e6c3d00c))

# [1.2.0](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.1.0...v1.2.0) (2021-08-15)


### Features

* Rework encryption to remove dependency on a repo and allow hooks to be passed in ([#55](https://github.com/Basis-Theory/basistheory-dotnet/issues/55)) ([ad2cfcf](https://github.com/Basis-Theory/basistheory-dotnet/commit/ad2cfcfe9209dff16e0ea1933b7690f4a5019add))

# [1.1.0](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.0.1...v1.1.0) (2021-08-14)


### Features

* Rename encryption data ([e41db0f](https://github.com/Basis-Theory/basistheory-dotnet/commit/e41db0fa9a91f42c9d447613fc849016be73ea48))

## [1.0.1](https://github.com/Basis-Theory/basistheory-dotnet/compare/v1.0.0...v1.0.1) (2021-08-14)

# 1.0.0 (2021-08-08)


### Features

* initial release ([0b77b97](https://github.com/Basis-Theory/basistheory-dotnet/commit/0b77b970ef30b02946ac3f53cfd0692fbdbd1fa1))
