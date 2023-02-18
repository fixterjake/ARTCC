FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ARTCC.Core.API/ARTCC.Core.API.csproj", "ARTCC.Core.API/"]
COPY ["ARTCC.Core.Shared/ARTCC.Core.Shared.csproj", "ARTCC.Core.Shared/"]
RUN dotnet restore "ARTCC.Core.API/ARTCC.Core.API.csproj"

COPY . .
WORKDIR "/src/ARTCC.Core.API"

RUN dotnet build "ARTCC.Core.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ARTCC.Core.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ARTCC.Core.API.dll"]