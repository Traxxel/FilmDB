# FilmDB

Eine Blazor WebAssembly Anwendung zur Verwaltung von Filmen und TV-Sendern. Die Anwendung besteht aus einer Web API (.NET 8) und einem Blazor WebAssembly Frontend.

## Funktionen

- Verwaltung von Filmen (Hinzufügen, Bearbeiten, Löschen)
- Verwaltung von TV-Sendern
- Übersichtliche Darstellung der Filmdatenbank mit DevExpress Grid
- Suchfunktion und Filterung für Filme
- Bewertungssystem mit Sternen (1-5)
- Azure AD Authentifizierung
  - Öffentliche Ansicht der Filmliste für alle Besucher
  - Verwaltungsfunktionen nur für authentifizierte Benutzer

## Projektstruktur

```
FilmDB/
├── FilmDB.API/           # Backend Web API mit Azure AD Auth
├── FilmDB.BLAZOR/        # Blazor WebAssembly Frontend
├── FilmDB.DAL/           # Data Access Layer mit Entity Framework
└── FilmDB.Tests/         # Unit Tests
```

## Technologien

- .NET 8
- Blazor WebAssembly
- Entity Framework Core
- PostgreSQL
- Azure AD B2C
- DevExpress Blazor Components
- Bootstrap 5
- Bootstrap Icons

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
4. Konfiguriere die Anwendung:
   - Erstelle `appsettings.Development.json` in FilmDB.API/ und FilmDB.BLAZOR/
   - Füge die Azure AD Konfiguration hinzu
   - Stelle die Datenbankverbindung ein
5. Führe die Datenbankmigrationen aus:
   ```bash
   dotnet ef database update
   ```
6. Starte die Anwendung:
   ```bash
   # API starten
   cd FilmDB.API
   dotnet run

   # In einem neuen Terminal: Frontend starten
   cd FilmDB.BLAZOR
   dotnet run
   ```

## Entwicklung

- Backend API läuft standardmäßig auf `http://localhost:5000`
- Frontend läuft standardmäßig auf `http://localhost:5002`

### Konfiguration

Die Anwendung benötigt folgende Konfigurationen:

#### API (appsettings.Development.json):
```json
{
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "Domain": "ihre-domain.onmicrosoft.com",
    "TenantId": "ihr-tenant-id",
    "ClientId": "ihre-client-id",
    "Audience": "api://ihre-client-id"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=FilmDB;Username=postgres;Password=ihr-passwort"
  }
}
```

#### Frontend (appsettings.Development.json):
```json
{
  "AzureAd": {
    "Authority": "https://login.microsoftonline.com/ihr-tenant-id",
    "ClientId": "ihre-client-id",
    "ValidateAuthority": true,
    "DefaultScopes": [
      "openid",
      "profile",
      "offline_access",
      "api://ihre-client-id/API.Access"
    ]
  },
  "DevExpress": {
    "LicenseKey": "ihre-devexpress-lizenz"
  }
}
```

## Beitragen

1. Fork das Projekt
2. Erstelle einen Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit deine Änderungen (`git commit -m 'Add some AmazingFeature'`)
4. Push in den Branch (`git push origin feature/AmazingFeature`)
5. Öffne einen Pull Request

## Lizenz

Dieses Projekt ist unter der MIT-Lizenz lizenziert - siehe die [LICENSE](LICENSE) Datei für Details. 