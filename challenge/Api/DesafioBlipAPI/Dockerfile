# Est�gio de constru��o
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar apenas o arquivo csproj para restaurar as depend�ncias
COPY ["DesafioBlipAPI.csproj", "./"]
RUN dotnet restore "DesafioBlipAPI.csproj"

# Copiar todo o c�digo-fonte e compilar a aplica��o
COPY . .
RUN dotnet build "DesafioBlipAPI.csproj" -c Release -o /app/build

# Est�gio de publica��o
FROM build AS publish
RUN dotnet publish "DesafioBlipAPI.csproj" -c Release -o /app/publish

# Est�gio final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copiar os arquivos publicados da etapa de publica��o
COPY --from=publish /app/publish .

# Expor a porta em que a aplica��o vai rodar (porta 80 � a padr�o para HTTP)
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet DesafioBlipAPI.dll
EXPOSE $PORT

# Comando para iniciar a aplica��o
#CMD ["dotnet", "DesafioBlipAPI.dll"]







