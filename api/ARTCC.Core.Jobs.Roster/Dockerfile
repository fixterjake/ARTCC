#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["api/ARTCC.Core.Jobs.Roster/ARTCC.Core.Jobs.Roster.csproj", "ARTCC.Core.Jobs.Roster/"]
RUN dotnet restore "ARTCC.Core.Jobs.Roster/ARTCC.Core.Jobs.Roster.csproj"
COPY . .
WORKDIR "/src/src/ARTCC.Core.Jobs.Roster"
RUN dotnet build "ARTCC.Core.Jobs.Roster.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ARTCC.Core.Jobs.Roster.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ARTCC.Core.Jobs.Roster.dll"]