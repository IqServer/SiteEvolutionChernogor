FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EvoWeb/EvoWeb.csproj", "EvoWeb/"]
RUN dotnet restore "EvoWeb/EvoWeb.csproj"
COPY . .
WORKDIR "/src/EvoWeb"
RUN dotnet build "EvoWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EvoWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EvoWeb.dll"]
