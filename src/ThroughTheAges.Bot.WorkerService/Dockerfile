#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ThroughTheAges.Bot.WorkerService/ThroughTheAges.Bot.WorkerService.csproj", "ThroughTheAges.Bot.WorkerService/"]
RUN dotnet restore "ThroughTheAges.Bot.WorkerService/ThroughTheAges.Bot.WorkerService.csproj"
COPY . .
WORKDIR "/src/ThroughTheAges.Bot.WorkerService"
RUN dotnet build "ThroughTheAges.Bot.WorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ThroughTheAges.Bot.WorkerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ThroughTheAges.Bot.WorkerService.dll"]