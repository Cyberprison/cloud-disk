# Указываем базовый образ с .NET SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Копируем csproj и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем все файлы и собираем приложение
COPY . ./
RUN dotnet publish -c Release -o out

# Создаем образ для запуска приложения
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .

# Указываем команду для запуска приложения
ENTRYPOINT ["dotnet", "WebAPI.dll"]