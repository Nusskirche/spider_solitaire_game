# Oma's Spider Solitaire

Een klassiek Spider Solitaire-kaartspel, gemaakt voor oma. **Versie 3.2** — volledig offline, zonder reclame, account of netwerkverbinding.

## Spelen op Windows

1. Download de repository via **Code → Download ZIP** en pak het bestand uit.
2. Dubbelklik op `SpiderSolitaire.html`, of op `START_SPEL.bat`.
3. Kies een moeilijkheidsgraad en speel met of zonder tijdslimiet.

Er is geen installatie of webserver nodig. Het spel draait in een moderne lokale browser.

## Speelfuncties

- 104 kaarten, tien kolommen, vijf rondes nieuwe kaarten.
- Eén, twee of vier kaartsoorten.
- Een tijdslimiet van 10/12/15 minuten of onbeperkt spelen.
- Kaarten verslepen of aanklikken om te verplaatsen.
- Hints **alleen na klikken op Hint**, met zichtbaar vertrekpunt, pijl en bestemming.
- Ongedaan maken, pauzeren, volledig scherm en spelregels.
- Kaartgeluiden en -animaties, waaronder het langzaam wegvliegen van complete reeksen.
- Start- en eindscherm, persoonlijke statistieken, automatisch opslaan.
- Geluiden en beweging afzonderlijk uitschakelbaar.

## Voortgang

Voortgang, instellingen en statistieken worden lokaal opgeslagen met browser-`localStorage`. Er wordt geen informatie verzonden. Browsergegevens wissen of het bestand op een andere locatie openen kan invloed hebben op opgeslagen partijen.

## Projectbestanden

- `SpiderSolitaire.html` — het volledige spel (HTML/CSS/JavaScript).
- `START_SPEL.bat` — startbestand voor Windows.
- `docs/CHANGELOG.md` — versieoverzicht.
- `docs/TECHNIEK.md` — technische toelichting.
- `.gitignore` — sluit lokale buildbestanden uit.

## Windows EXE

Er bestaat ook een aparte Windows-EXE voor versie 3.2, maar de **broncode van de EXE-launcher en een reproduceerbare Windows-build** zitten nog niet in deze repository. De HTML-versie is volledig lokaal speelbaar. Een nieuw, niet-ondertekend EXE-bestand kan door Microsoft SmartScreen als onbekend worden gemarkeerd.

## Licentie

Familieproject. Er is momenteel geen opensourcelicentie toegevoegd.
