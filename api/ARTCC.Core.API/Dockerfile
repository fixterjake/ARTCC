FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["./api/ARTCC.Core.API/ARTCC.Core.API.csproj", "ARTCC.Core.API/"]
COPY ["./api/ARTCC.Core.Shared/ARTCC.Core.Shared.csproj", "ARTCC.Core.Shared/"]
RUN dotnet restore "ARTCC.Core.API/ARTCC.Core.API.csproj"

WORKDIR "/src/ARTCC.Core.API"
COPY . .

RUN dotnet build "ARTCC.Core.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ARTCC.Core.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ARTCC.Core.API.dll"]