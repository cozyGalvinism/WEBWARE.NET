# WEBWARE.NET

Ein einfacher Wrapper für die WEBSERVICES der WEBWARE

## Benutzung

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
