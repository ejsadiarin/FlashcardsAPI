FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FlashcardsAPI.EF.MSSQL/FlashcardsAPI.EF.MSSQL.csproj", "FlashcardsAPI.EF.MSSQL/"]
RUN dotnet restore "FlashcardsAPI.EF.MSSQL/FlashcardsAPI.EF.MSSQL.csproj"
COPY . .
WORKDIR "/src/FlashcardsAPI.EF.MSSQL"
RUN dotnet build "FlashcardsAPI.EF.MSSQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FlashcardsAPI.EF.MSSQL.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlashcardsAPI.EF.MSSQL.dll"]
