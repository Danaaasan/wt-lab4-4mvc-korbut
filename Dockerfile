# Этап сборки: используем SDK .NET 8
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем csproj и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем всё остальное и публикуем
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Этап запуска: используем runtime ASP.NET Core 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Render передаёт порт через переменную PORT
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT:-10000}
EXPOSE 10000

ENTRYPOINT ["dotnet", "wt-lab4-4mvc-korbut.dll"]