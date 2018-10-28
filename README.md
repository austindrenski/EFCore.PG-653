## Windows (x64)

```bash
dotnet publish -c Release -f netcoreapp2.1 -r win-x64
./bin/Release/netcoreapp2.1/win-x64/publish/EFCore.PG-653.exe
```

## Linux (x64)

```bash
# See: https://github.com/dotnet/corert/issues/5654
export CppCompilerAndLinker=clang
dotnet publish -c Release -f netcoreapp2.1 -r linux-x64
./bin/Release/netcoreapp2.1/win-x64/publish/EFCore.PG-653.exe
```

