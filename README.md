# Oma's Spider Solitaire

Een klassiek Spider Solitaire-kaartspel voor oma. **Versie 3.2** — volledig offline, zonder reclame of account.

## Direct spelen in je browser

1. Download de bestanden via **Code → Download ZIP** en pak ze uit.
2. Dubbelklik op `SpiderSolitaire.html` of `START_SPEL.bat` (Windows).
3. Kies 1, 2 of 4 kaartsoorten en spelen met of zonder klok.

## Windows-app (.exe)

De map [`windows/`](windows/) bevat de broncode van een zelfstandige Windows Forms-app op basis van Microsoft WebView2. De broncode van het spel wordt **ongewijzigd** als resource opgenomen in de Windows-build. De app gebruikt uitsluitend lokale spelbestanden.

**Downloaden uit GitHub Actions:** open [Actions → Windows EXE](../../actions/workflows/build-windows.yml), open een geslaagde run en download **Omas-Spider-Solitaire-Windows-x64** onder *Artifacts*. Pak de ZIP uit en start `OmasSpiderSolitaire.exe`. De app vereist Windows 10/11 x64 en de Microsoft Edge WebView2 Runtime. Er is geen .NET-installatie nodig bij oma dankzij de self-contained build.

**Nieuwe release:** een Git-tag met `v` voorop (zoals `v3.2.0`) start automatisch een build en maakt na een geslaagde build een item onder [Releases](../../releases). Zonder tag staat de build alleen onder de workflow-artifacts.

De Windows-build is **niet digitaal ondertekend**. SmartScreen kan daarom een waarschuwing geven. Zet Windows Defender of SmartScreen niet uit.

## Functies

- 104 speelkaarten, tien kolommen, vijf uitdeelrondes.
- Makkelijk (1 kaartsoort), gemiddeld (2) of moeilijk (4).
- Met klok (10, 12 of 15 minuten) of zonder tijdslimiet.
- Kaarten slepen of aanklikken om te verplaatsen.
- Duidelijke aanwijzingen **alleen bij het drukken op Hint**; normaal spelen verklapt geen zetten.
- Ongedaan maken, pauzeren, spelregels, volledig scherm.
- Geluiden, subtiele animaties, langzame wegleganimatie voor complete reeksen.
- Statistieken, eigen records, start- en eindschermen en automatisch opslaan.
- Animaties en geluid afzonderlijk uitschakelen.

## Voortgang en privacy

Alle gegevens blijven lokaal. De HTML-versie slaat ze op in de gebruikte browser. De Windows-app gebruikt een vast WebView2-profiel onder `%LOCALAPPDATA%\\OmasSpiderSolitaire\\WebView2Profile`. Nieuwe Windows-appversies kunnen die gegevens blijven gebruiken.

**Let op:** de oude losse EXE en de HTML-versie kunnen een andere opslaglocatie hebben. De bestaande spelstand verhuist niet automatisch naar de nieuwe WebView2-app.

## Repository

- `SpiderSolitaire.html` — volledig spel inclusief opmaak, regels, animaties en audio.
- `START_SPEL.bat` — snelstart via de browser.
- `windows/` — Windows-appbroncode, instellingen en bouwinstructies.
- `.github/workflows/build-windows.yml` — automatische Windows-build.
- `docs/CHANGELOG.md` — versiegeschiedenis.
- `docs/TECHNIEK.md` — technische toelichting.

## Licentie

Persoonlijk familieproject; nog geen opensourcelicentie toegevoegd.
