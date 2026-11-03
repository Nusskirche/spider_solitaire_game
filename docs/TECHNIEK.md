# Technische toelichting

## Spelmotor en interface

- Een lokaal HTML-bestand met eigen CSS en JavaScript.
- Geen externe JavaScript-bibliotheken, CDN, geluidbestanden of netwerkverzoeken.
- 104 kaarten, tien kolommen, 50 voorraadkaarten, acht te verzamelen K–A-reeksen.
- Browser-`localStorage` bewaart spelstand, instellingen en statistieken.
- Web Audio API en Web Animations API zorgen voor geluid en animaties.

## Windows-app

- Broncode in [`windows/`](../windows/).
- Windows Forms op .NET 10 met Microsoft WebView2, self-contained `win-x64`.
- `SpiderSolitaire.html` is ingebed in het programma en wordt lokaal uitgepakt onder `%LOCALAPPDATA%\OmasSpiderSolitaire\Game`.
- WebView2 bewaart zijn profiel onder `%LOCALAPPDATA%\OmasSpiderSolitaire\WebView2Profile`.
- Het spel wordt geladen met een stabiele virtuele host (`https://spider-solitaire.example/`) die uitsluitend naar de lokale Game-map verwijst.
- Externe navigatie en nieuwe vensters worden geblokkeerd.
- WebView2 Runtime moet op de Windows-computer aanwezig zijn.

## Automatisch bouwen

- GitHub Actions: [`.github/workflows/build-windows.yml`](../.github/workflows/build-windows.yml).
- Bij wijzigingen op `main` en bij handmatig starten wordt een Windows-app gebouwd; de ZIP is als workflow-artifact beschikbaar.
- Een Git-tag die begint met `v` probeert daarnaast een GitHub Release te publiceren.
- Een GitHub Actions-build betekent **niet** dat de EXE digitaal is ondertekend.

## Voortgang

De bestaande HTML-versie en oudere Edge-launcher kunnen andere opslagprofielen gebruiken; die data wordt niet automatisch meegenomen. Nieuwe builds van deze WebView2-app gebruiken dezelfde virtuele oorsprong en profielmap, zolang die locaties niet worden gewijzigd.

## Verder ontwikkelen

- Oplossing testen op een echte Windows-machine.
- Indien gewenst een icoon en installer toevoegen.
- Later digitale codeondertekening onderzoeken, alleen als distributie buiten de familie relevant wordt.
