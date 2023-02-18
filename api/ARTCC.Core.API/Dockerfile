FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet restore "api/ARTCC.Core.API/ARTCC.Core.API.csproj"
RUN dotnet build "api/ARTCC.Core.API/ARTCC.Core.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api/ARTCC.Core.Shared/ARTCC.Core.Shared.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ARTCC.Core.API.dll"]