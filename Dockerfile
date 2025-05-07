FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /source

# Copiar y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto del codigo fuente
COPY . ./
RUN dotnet publish -c Release -o /app

# Construir la imagen final
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS final
WORKDIR /app
COPY --from=build /app ./

ENV ASPNETCORE_URLS=http://+:5076
EXPOSE 5076
ENTRYPOINT ["dotnet", "aztro_cchardos_back_group2.dll"]