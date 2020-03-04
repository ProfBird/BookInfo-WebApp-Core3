# download the ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
# download the .NET Core runtime
FROM mcr.microsoft.com/dotnet/core/runtime:3.1
COPY GoodBookNook/bin/Release/netcoreapp3.1/publish/ app/
ENTRYPOINT ["dotnet", "app/GoodBookNook.dll"]