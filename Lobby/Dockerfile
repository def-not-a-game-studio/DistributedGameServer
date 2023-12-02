FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Lobby/Lobby.csproj", "Lobby/"]
RUN dotnet restore "Lobby/Lobby.csproj"
COPY . .
WORKDIR "/src/Lobby"
RUN dotnet build "Lobby.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lobby.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lobby.dll"]
