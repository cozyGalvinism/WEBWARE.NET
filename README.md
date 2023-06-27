# WEBWARE.NET

Ein einfacher Wrapper für die WEBSERVICES der WEBWARE

## Benutzung

Hinzufügen zum Projekt:

**Windows:**

```cmd
dotnet nuget add source --name "cozyGalvinism" "https://nuget.pkg.github.com/cozyGalvinism/index.json" --username "[YOUR GITHUB USERNAME]" --password "[YOUR GITHUB PASSWORD OR ACCESS TOKEN]"
dotnet add package WEBWARE.NET
```

**Linux:**

```cmd
dotnet nuget add source --name "cozyGalvinism" "https://nuget.pkg.github.com/cozyGalvinism/index.json" --username "[YOUR GITHUB USERNAME]" --password "[YOUR GITHUB PASSWORD OR ACCESS TOKEN]" --store-password-in-clear-text
dotnet add package WEBWARE.NET
```

Einen Client erstellen und registrieren:

```cs
WEBWAREClient wc = new WEBWAREClient("Hersteller-Hash", "Anwendungs-Hash", "Secret", 1, "Host", 443, "/WWSVC/");
if(!wc.Register()) {
    // Beende Programm, zeige Fehlermeldung, etc.
}
```

Artikel abrufen:

```cs
Artikel art = new Artikel(wc);
IRestResponse response = art.Get();
JArray artikel = JObject.Parse(response.Content)["ARTIKELLISTE"]["ARTIKEL"] as JArray;

foreach(JObject artikelJson in artikel) {
    // Aktion mit Artikeln ausführen
}
```

Registrierung aufheben:

```cs
wc.Deregister();
```
