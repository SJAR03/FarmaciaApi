# Usa la imagen base de .NET SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia el archivo csproj y restaura las dependencias
COPY ./FarmaciaApi/FarmaciaApi.csproj ./FarmaciaApi/
WORKDIR /src/FarmaciaApi
RUN dotnet restore

# Copia el resto del código fuente y construye la aplicación
COPY . .
RUN dotnet build -c Release -o /app/build

# Usa una imagen base de .NET Runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "FarmaciaApi.dll"]
