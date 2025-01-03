FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MyGame.csproj", "."]
RUN dotnet restore "./MyGame.csproj"
COPY . .
RUN dotnet build "./MyGame.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "./MyGame.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyGame.dll"]
