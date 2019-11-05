FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
EXPOSE 80 443
COPY . .
ENTRYPOINT ["dotnet", "TestServer.dll"]