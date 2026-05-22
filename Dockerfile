FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
USER app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# === ALTERE AQUI O NOME DO SEU ARQUIVO .CSPROJ ===
COPY ["CELTICS_NET.csproj", "."]        # ← Mude para o nome correto
RUN dotnet restore "CELTICS_NET.csproj"
COPY . .
RUN dotnet build "CELTICS_NET.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "CELTICS_NET.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CELTICS_NET.dll"]   # ← Mude também se necessário