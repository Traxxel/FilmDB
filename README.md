# FilmDB

Eine Blazor WebAssembly Anwendung zur Verwaltung von Filmen und TV-Sendern. Die Anwendung besteht aus einer Web API (.NET 8) und einem Blazor WebAssembly Frontend.

## Funktionen

- Verwaltung von Filmen (Hinzufügen, Bearbeiten, Löschen)
- Verwaltung von TV-Sendern
- Übersichtliche Darstellung der Filmdatenbank
- Suchfunktion für Filme
- Filterung nach verschiedenen Kriterien

## Projektstruktur

```
FilmDB/
├── FilmDB.API/           # Backend Web API
├── FilmDB.Client/        # Blazor WebAssembly Frontend
├── FilmDB.Shared/        # Gemeinsam genutzte Modelle und Interfaces
└── FilmDB.Tests/         # Unit Tests
```

## Technologien

- .NET 8
- Blazor WebAssembly
- Entity Framework Core
- SQL Server
- Bootstrap 5

## Installation

1. Stelle sicher, dass .NET 8 SDK installiert ist
2. Clone das Repository:
   ```bash
   git clone https://github.com/yourusername/FilmDB.git
   ```
3. Navigiere in das Projektverzeichnis:
   ```bash
   cd FilmDB
   ```
4. Stelle die Datenbankverbindung in der `appsettings.json` ein
5. Führe die Datenbankmigrationen aus:
   ```bash
   dotnet ef database update
   ```
6. Starte die Anwendung:
   ```bash
   dotnet run --project FilmDB.API
   ```

## Entwicklung

- Backend API läuft standardmäßig auf `https://localhost:7000`
- Frontend läuft standardmäßig auf `https://localhost:7001`

## Beitragen

1. Fork das Projekt
2. Erstelle einen Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit deine Änderungen (`git commit -m 'Add some AmazingFeature'`)
4. Push in den Branch (`git push origin feature/AmazingFeature`)
5. Öffne einen Pull Request

## Lizenz

Dieses Projekt ist unter der MIT-Lizenz lizenziert - siehe die [LICENSE](LICENSE) Datei für Details. 