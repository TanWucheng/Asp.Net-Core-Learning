# dotnet CLI 命令基本使用

## 新建解决方案和项目

```bash
> dotnet new sln -o CoreConsoleApp
> dotnet new console -n CoreConsoleApp
> dotnet new classlib -n CoreConsoleLib
> dotnet sln add CoreConsoleApp && dotnet sln add CoreConsoleLib
```

## 编译打包类库

```bash
> cd CoreConsoleApp
> dotnet build && dotnet pack
```

## 类库代码变更之后打包也升级 Nuget 版本号

```bash
> dotnet pack -p:PackageVersion=1.0.2
```

## 编辑 CoreConsoleApp.csproj 添加类库引用

```xml
<ItemGroup>
    <PackageReference Include="CoreConsoleLib" Version="1.0.0" />
</ItemGroup>
```

## 使用类库包源恢复项目 CoreConsoleApp

```bash
> cd ../CoreConsoleApp/
> dotnet restore -s ../CoreConsoleLib/bin/Debug
```

## 编译运行项目 CoreConsoleApp

```bash
> dotnet build && dotnet run
```
