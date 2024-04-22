# Estágio de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar apenas o arquivo csproj para restaurar as dependências
COPY ["DesafioBlipAPI.csproj", "./"]
RUN dotnet restore "DesafioBlipAPI.csproj"

# Copiar todo o código-fonte e compilar a aplicação
COPY . .
RUN dotnet build "DesafioBlipAPI.csproj" -c Release -o /app/build

# Estágio de publicação
FROM build AS publish
RUN dotnet publish "DesafioBlipAPI.csproj" -c Release -o /app/publish

# Estágio final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copiar os arquivos publicados da etapa de publicação
COPY --from=publish /app/publish .

# Expor a porta em que a aplicação vai rodar (porta 80 é a padrão para HTTP)
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet DesafioBlipAPI.dll
EXPOSE $PORT

# Comando para iniciar a aplicação
#CMD ["dotnet", "DesafioBlipAPI.dll"]







