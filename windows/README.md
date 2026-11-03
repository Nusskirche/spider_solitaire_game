# Windows-app (WebView2)

Dit project verpakt `SpiderSolitaire.html` als een offline Windows Forms-app met WebView2.

## Vereisten

- Windows 10/11 x64
- Microsoft Edge **WebView2 Runtime** (standaard beschikbaar op de meeste Windows 11-installaties)
- Alleen **voor het bouwen**: .NET 10 SDK en internettoegang voor de eerste NuGet-restore

## Lokaal bouwen (Windows)

```powershell
dotnet restore windows/OmasSpiderSolitaire.csproj
dotnet publish windows/OmasSpiderSolitaire.csproj --no-restore -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -o publish
```

Pak voor distributie **alle inhoud** van `publish/` samen. Afhankelijk van de WebView2 SDK kunnen ook native hulpbestanden aanwezig zijn; ga niet ervan uit dat alleen de EXE voldoende is.

## Offline en gegevens bewaren

- De HTML-code is een ingebedde resource, niet opgehaald via internet.
- Bij de start wordt de meegeleverde HTML opgeslagen in `%LOCALAPPDATA%\OmasSpiderSolitaire\Game`.
- WebView2 bewaart het browserprofiel en de lokale spelgegevens onder `%LOCALAPPDATA%\OmasSpiderSolitaire\WebView2Profile`.
- De virtuele oorsprong `https://spider-solitaire.example/` blijft gelijk voor updates, zodat spelstand, opties en statistieken kunnen worden behouden.
- **Let op:** de oude HTML-versie in Edge of de oudere EXE heeft mogelijk een ander opslagprofiel. Die spelstand wordt **niet automatisch gemigreerd** naar deze nieuwe app.

## GitHub Actions

Bij iedere push naar `main` wordt een Windows-build gemaakt. Het ZIP-bestand staat bij de workflow onder **Artifacts**.

Bij het aanmaken van een tag zoals `v3.2.0` wordt daarnaast geprobeerd het ZIP-bestand te publiceren als GitHub Release.

## Veiligheid

De EXE is niet digitaal ondertekend. Microsoft SmartScreen kan daardoor blijven waarschuwen. Schakel Defender of SmartScreen niet uit. Het bouwproces gebruikt geen zelfgeschreven uitvoerbare downloaders en haalt bij het spelen geen gamecode van internet.
