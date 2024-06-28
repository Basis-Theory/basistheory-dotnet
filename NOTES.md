# Code Generation Notes

## Generator

The `csharp-netcore` generator is NOT currently documented on the OpenAPI [Generator site](https://openapi-generator.tech/docs/generators).

### List all available generators

```shell
docker run --rm -v ${PWD}:/local openapitools/openapi-generator-cli:v6.2.1 list
```
### View available configuration options for a given generator

```shell
docker run --rm -v ${PWD}:/local openapitools/openapi-generator-cli:v6.2.1 config-help -g csharp-netcore
```

## Template Changes

The `.openapi-generator/templates/netcore_project.mustache` template file was modified to include the following project attributes.

```xml
<NuspecProperties>version=$(Version)</NuspecProperties>  
<PackageReadmeFile>README.md</PackageReadmeFile>  
<AssemblyVersion>1.0.0</AssemblyVersion>  
<LangVersion>11.0</LangVersion>
```