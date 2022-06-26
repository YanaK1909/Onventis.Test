#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Onventist.Test.Webhook.Compose/Onventist.Test.Webhook.Compose.csproj", "Onventist.Test.Webhook.Compose/"]
RUN dotnet restore "Onventist.Test.Webhook.Compose/Onventist.Test.Webhook.Compose.csproj"
COPY . .
WORKDIR "/src/Onventist.Test.Webhook.Compose"
RUN dotnet build "Onventist.Test.Webhook.Compose.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onventist.Test.Webhook.Compose.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onventist.Test.Webhook.Compose.dll"]