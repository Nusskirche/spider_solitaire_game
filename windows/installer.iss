; Inno Setup installer voor Oma's Spider Solitaire
; Bouwt op de gepubliceerde .NET/WebView2 bestanden in ../publish.
#define GameName "Oma's Spider Solitaire"
#define GameVersion "3.2.0"
#define GameExe "OmasSpiderSolitaire.exe"

[Setup]
AppId={{8DA1D7D1-E398-4127-823D-A74A75E6034C}
AppName={#GameName}
AppVersion={#GameVersion}
AppVerName={#GameName} {#GameVersion}
AppPublisher=Oma's Spider Solitaire
DefaultDirName={localappdata}\Programs\Omas Spider Solitaire
DefaultGroupName={#GameName}
DisableProgramGroupPage=yes
DisableDirPage=no
DisableWelcomePage=no
PrivilegesRequired=lowest
WizardStyle=modern
MinVersion=10.0
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
Compression=lzma2
SolidCompression=yes
UninstallDisplayName={#GameName}
OutputDir=..\release
OutputBaseFilename=Omas-Spider-Solitaire-Setup-v{#GameVersion}

[Languages]
Name: "dutch"; MessagesFile: "compiler:Languages\Dutch.isl"

[Tasks]
Name: "desktopicon"; Description: "Maak een snelkoppeling op het bureaublad"; GroupDescription: "Snelkoppelingen:"

[Files]
Source: "..\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#GameName}"; Filename: "{app}\{#GameExe}"
Name: "{autodesktop}\{#GameName}"; Filename: "{app}\{#GameExe}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#GameExe}"; Description: "Start {#GameName}"; Flags: nowait postinstall skipifsilent
