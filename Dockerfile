# ===== 1. Build stage =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем CSPROJ и восстанавливаем зависимости
COPY UserPanel/*.csproj ./
RUN dotnet restore

# Копируем весь проект и публикуем
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# ===== 2. Runtime stage =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Копируем собранное приложение из build stage
COPY --from=build /app/publish .

# Открываем порт 80
EXPOSE 80

# Запускаем приложение
ENTRYPOINT ["dotnet", "UserPanel.dll"]
