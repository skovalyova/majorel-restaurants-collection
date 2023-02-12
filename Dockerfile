#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/API/Majorel.RestaurantsCollection.API.csproj", "src/API/"]
COPY ["src/Application/Majorel.RestaurantsCollection.Application.csproj", "src/Application/"]
COPY ["src/Domain/Majorel.RestaurantsCollection.Domain.csproj", "src/Domain/"]
COPY ["src/Infrastructure/Majorel.RestaurantsCollection.Infrastructure.csproj", "src/Infrastructure/"]
RUN dotnet restore "src/API/Majorel.RestaurantsCollection.API.csproj"
COPY . .
WORKDIR "/src/src/API"
RUN dotnet build "Majorel.RestaurantsCollection.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Majorel.RestaurantsCollection.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Majorel.RestaurantsCollection.API.dll"]