FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
# Copia tudo para o container para evitar erros de nomes específicos
COPY . .
# Restaura e constrói tudo o que estiver na pasta
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/publish .
# O comando abaixo assume que seu executável se chama celticsTech.dll
ENTRYPOINT ["dotnet", "celticsTech.dll"]