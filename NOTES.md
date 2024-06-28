# Code Generation Notes

## Template Changes

The `.openapi-generator/templates/netcore_project.mustache` template file was modified to include the following project attributes.

```xml
<NuspecProperties>version=$(Version)</NuspecProperties>  
<PackageReadmeFile>README.md</PackageReadmeFile>  
<AssemblyVersion>1.0.0</AssemblyVersion>  
<LangVersion>11.0</LangVersion>
```