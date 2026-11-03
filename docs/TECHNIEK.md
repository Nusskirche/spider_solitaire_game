# Technische toelichting

## Architectuur
- Eén lokaal HTML-bestand met eigen CSS en JavaScript.
- Geen externe bibliotheken, CDN, externe geluiden of internetverzoeken.
- Spelmotor: 104 kaarten, tableau van 10 kolommen, 50 voorraadkaarten, 8 te verzamelen reeksen.
- Lokale opslag via `localStorage`.
- Audio-effecten via Web Audio API; animaties via CSS en Web Animations API.

## Regels
- Kaarten mogen op een kaart van één rang hoger worden gelegd.
- Een meervoudige reeks kan alleen samen worden verplaatst als rang en kaartsoort doorlopend kloppen.
- Een complete aflopende K–A-reeks van dezelfde soort wordt verzameld.
- Nieuwe kaarten mogen pas worden gedeeld als alle tien kolommen een kaart bevatten.
- Ongedaan maken herstelt de spelstatus uit een geschiedenis.

## Bewaren en upgraden
- De browser bepaalt de opslaglocatie van `localStorage`, ook bij lokale `file://`-bestanden.
- Houd dezelfde browser en bestandslocatie aan wanneer bestaande voortgang belangrijk is.
- Verwijder niet zonder meer opgeslagen browsergegevens.

## Veiligheid en distributie
- De HTML-versie heeft geen installatie nodig.
- De afzonderlijke Windows-EXE was een launcher; reproduceerbare launcherbroncode staat nog niet in deze repository.
- Een digitale codehandtekening is niet aanwezig. SmartScreen en antivirus horen ingeschakeld te blijven.

## Verdere ontwikkeling
Een mogelijke vervolgstap is het scheiden van spelmotor, weergave en tests, met een reproduceerbare Windows-build en een teststraat.
