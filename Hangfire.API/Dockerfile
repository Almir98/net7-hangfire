#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Hangfire.API/Hangfire.API.csproj", "Hangfire.API/"]
COPY ["Hangfire.Contracts/Hangfire.Contracts.csproj", "Hangfire.Contracts/"]
COPY ["Hangfire.Implementation/Hangfire.Implementation.csproj", "Hangfire.Implementation/"]
RUN dotnet restore "Hangfire.API/Hangfire.API.csproj"
COPY . .
WORKDIR "/src/Hangfire.API"
RUN dotnet build "Hangfire.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hangfire.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hangfire.API.dll"]