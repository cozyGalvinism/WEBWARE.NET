using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using WEBWARE.NET.Helper;

namespace WEBWARE.NET.Endpoints
{
    /// <summary>
    /// Wrapper-Klasse zum Abrufen von Artikeldaten
    /// </summary>
    [EndpointInfo("ARTIKEL", 3)]
    public class Artikel : EndpointHelper
    {
        
        public Artikel(WEBWAREClient client) : base(client)
        {
        }

        /// <summary>
        /// Löscht einen Artikeldatensatz
        /// 
        /// Es wird eine Überprüfung durchgeführt, ob der Artikel gelöscht werden kann. Artikel mit Umsatz können nicht gelöscht werden.
        /// </summary>
        /// <param name="artNr">Die Artikelnummer des zu löschenden Artikels</param>
        /// <returns>Ein Antwortpaket, ob die Anfrage erfolgreich abgeschlossen wurde</returns>
        public RestResponse Delete(string artNr)
        {
            return SendEndpointRequest(Method.Delete,
                new EndpointParameters().AddParameter("ARTNR", artNr).GetParameters(), null);
        }

        public async Task<RestResponse> DeleteAsync(string artNr)
        {
            return await SendEndpointRequestAsync(Method.Delete,
                new EndpointParameters().AddParameter("ARTNR", artNr).GetParameters(), null);
        }

        /// <summary>
        /// Legt einen neuen Artikel an
        /// 
        /// Falls <paramref name="artNr"/> nicht angegeben wird, wird die Artikelnummer automatisch vergeben
        /// </summary>
        /// <param name="felder">Zu setzende Felder</param>
        /// <param name="artNr">Vorgabe für die Artikelnummer</param>
        /// <param name="erfassungsgruppe">Zu verwendende Artikelerfassungsgruppe</param>
        /// <param name="nurTesten">Vorgang nur testen, es wird kein Satz angelegt</param>
        /// <param name="langtexte">Übergibt Langtext-Parameter. Dies ist ein Dictionary, dessen Keys folgende Werte annehmen können: NOTIZTEXT, LANGTEXT, WARNTEXT, KURZTEXT, LT01, LT02, LT03, LT04, LT05 und dessen Werte den zu setzenden Text für diesen Langtext darstellt</param>
        /// <returns>Ein Antwortpaket, mit der neu angelegten Artikelnummer</returns>
        public RestResponse Insert(Dictionary<string, dynamic> felder = null, string artNr = "", string erfassungsgruppe = "",
            bool nurTesten = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ARTNR", artNr).AddParameter("ERFASSUNGSGRUPPE", erfassungsgruppe)
                .AddParameter("NUR_TESTEN", nurTesten);
            if (felder != null) p = p.AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return SendEndpointRequest(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public async Task<RestResponse> InsertAsync(Dictionary<string, dynamic> felder = null, string artNr = "", string erfassungsgruppe = "",
            bool nurTesten = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ARTNR", artNr).AddParameter("ERFASSUNGSGRUPPE", erfassungsgruppe)
                .AddParameter("NUR_TESTEN", nurTesten);
            if (felder != null) p = p.AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        /// <summary>
        /// Aktualisiert einen vorhandenen Artikel
        /// </summary>
        /// <param name="artNr">Artikelnummer</param>
        /// <param name="felder">Zu setzende Felder</param>
        /// <param name="ohneStammkalk">Keine Stammdatenkalkulation durchführen</param>
        /// <param name="langtexte">Übergibt Langtext-Parameter. Dies ist ein Dictionary, dessen Keys folgende Werte annehmen können: NOTIZTEXT, LANGTEXT, WARNTEXT, KURZTEXT, LT01, LT02, LT03, LT04, LT05 und dessen Werte den zu setzenden Text für diesen Langtext darstellt</param>
        /// <returns>Ein Antwortpaket, ob die Anfrage erfolgreich abgeschlossen wurde</returns>
        public RestResponse Put(string artNr, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ARTNR", artNr).AddParameter("OHNE_STAMMKALK", ohneStammkalk).AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> PutAsync(string artNr, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ARTNR", artNr).AddParameter("OHNE_STAMMKALK", ohneStammkalk).AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }

        /// <summary>
        /// Holt eine Liste von Artikeldatensätzen
        /// </summary>
        /// <param name="felder">Übergibt eine Komma-getrennte Liste der gewünschten Datenfelder (z.B. FELDER=ART_1_25,ART_51_60)</param>
        /// <param name="nurAnzahl">Liefert als Antwortpaket nur die Anzahl der gefundenen Datensätze</param>
        /// <param name="nurGroesse">Liefert als Antwortpaket nur die Größe des Antwortpakets in Byte</param>
        /// <param name="sucheVolltext">Übergibt einen Volltext-Suchbegriff. Die Volltextsuche wird als erster Schritt durchgeführt, danach werden weitere Selektionsparameter angewandt</param>
        /// <param name="freiselekt">Übergibt einen freien Selektionsausdruck Bsp.: (ART_36_5='WGR01' # ART_36_5='WGR56')</param>
        /// <param name="freiselektKey">Nummer des gewünschten Schlüssels (0...n) oder 'AUTO' für die automatische Ermittlung aus dem Selektionsausdruck (experimentell)</param>
        /// <param name="freiselektVonIndex">Startwert für Index</param>
        /// <param name="freiselektBisIndex">Endwert für Index</param>
        /// <param name="freisort">Übergibt eine Komma-getrennte Liste der gewünschten Sortierfelder FREISORT = &lt;Feldname&gt;[ ASC|DESC][,…] (z.B. FREISORT=ART_178_9 DESC,ART_1_25 ASC) Es können derzeit maximal fünf Felder angegeben werden</param>
        /// <param name="mitLangtext">Übergibt Langtext-Parameter. Dies ist eine Komma-getrennte Liste folgender möglicher Werte: NOTIZTEXT, LANGTEXT, WARNTEXT, KURZTEXT, LT01, LT02, LT03, LT04, LT05</param>
        /// <param name="ohneLeerfelder">Datenfelder ohne Inhalt werden im Ergebnissatz komplett ausgelassen</param>
        /// <param name="artNr">Artikelnummer</param>
        /// <param name="vonArtNr"></param>
        /// <param name="bisArtNr">Schränkt die Liste auf den angegebenen Artikelnummernbereich ein</param>
        /// <param name="wgr">Warengruppe</param>
        /// <param name="vonWgr"></param>
        /// <param name="bisWgr">Schränkt die Liste auf den angegebenen Warengruppenbereich ein</param>
        /// <param name="katalog">Katalog</param>
        /// <param name="vonKatalog"></param>
        /// <param name="bisKatalog">Schränkt die Liste auf den angegebenen Katalognummernbereich ein</param>
        /// <param name="mitKategorien">Liefert innerhalb des Artikelobjekts eine Liste der den Artikel enthaltenden Marketplace-Kategorien als Unterobjekt</param>
        /// <param name="kategorieFelder">Übergibt eine Komma-getrennte Liste der gewünschten Datenfelder der Kategorientabelle (KAT_0_10, etc.)</param>
        /// <param name="mitLagerbestand">Ruft Lagerbestände in die Fehler ART_759_10 und ART_769_10 ab</param>
        /// <param name="lager">Lager</param>
        /// <param name="vonLager"></param>
        /// <param name="bisLager">Schränkt Lager für Lagerbestandsermittlung auf den angegebenen Bereich ein</param>
        /// <param name="mitAttributen">Ruft alle zum Artikel hinterlegten Attribute ab</param>
        /// <param name="attributFelder">Übergibt Komma-getrennte Liste der gewünschten Felder der Attributtabelle (ATR_61_10, ATR_88_256,...)</param>
        /// <param name="mitAttributLangtext">Übergibt Parameter für Langtext-Attribute. Dies ist eine Komma-getrennte Liste folgender möglicher Werte: LT00, LT01, LT02, LT03, LT04</param>
        /// <param name="mitAttributDefinition">Ruft zu jedem Attribut auch dessen Attributdefinition ab</param>
        /// <param name="attributDefinitionFelder">Übergibt Komma-getrennte Liste der gewünschten Felder Attributdefinitionstabelle (ATD_10_60,...)</param>
        /// <param name="mitVarianten">Ist ein Artikel ein Variantenhauptartikel, werden die Artikelnummern seiner Varianten als Liste mit ausgegeben (siehe Beispiel)</param>
        /// <param name="mitVariantenWerte">Für alle Variantenartikel werden die Ausprägungen mit ausgegeben (siehe Beispiel)</param>
        /// <returns>Die Antwort des WEBWARE-Servers</returns>
        public RestResponse Get(
            string felder = "",
            bool nurAnzahl = false,
            bool nurGroesse = false,
            string sucheVolltext = "",
            string freiselekt = "",
            string freiselektKey = "",
            string freiselektVonIndex = "",
            string freiselektBisIndex = "",
            string freisort = "",
            string mitLangtext = "",
            bool ohneLeerfelder = false,
            string artNr = "",
            string vonArtNr = "",
            string bisArtNr = "",
            string wgr = "",
            string vonWgr = "",
            string bisWgr = "",
            string katalog = "",
            string vonKatalog = "",
            string bisKatalog = "",
            bool mitKategorien = false,
            string kategorieFelder = "",
            bool mitLagerbestand = false,
            string lager = "",
            string vonLager = "",
            string bisLager = "",
            bool mitAttributen = false,
            string attributFelder = "",
            string mitAttributLangtext = "",
            bool mitAttributDefinition = false,
            string attributDefinitionFelder = "",
            bool mitVarianten = false,
            bool mitVariantenWerte = false,
            string langtextFormat = "")
        {
            Dictionary<string, dynamic> parameter = new Dictionary<string, dynamic>()
            {
                ["FELDER"] = felder,
                ["NUR_ANZAHL"] = nurAnzahl ? 1 : 0,
                ["NUR_GROESSE"] = nurGroesse ? 1 : 0,
                ["SUCHE_VOLLTEXT"] = sucheVolltext,
                ["FREISELEKT"] = freiselekt,
                ["FREISELEKT_KEY"] = freiselektKey,
                ["FREISELEKT_VON_INDEX"] = freiselektVonIndex,
                ["FREISELEKT_BIS_INDEX"] = freiselektBisIndex,
                ["FREISORT"] = freisort,
                ["MIT_LANGTEXT"] = mitLangtext,
                ["OHNE_LEERFELDER"] = ohneLeerfelder ? 1 : 0,
                ["ARTNR"] = artNr,
                ["VON_ARTNR"] = vonArtNr,
                ["BIS_ARTNR"] = bisArtNr,
                ["WGR"] = wgr,
                ["VON_WGR"] = vonWgr,
                ["BIS_WGR"] = bisWgr,
                ["KATALOG"] = katalog,
                ["VON_KATALOG"] = vonKatalog,
                ["BIS_KATALOG"] = bisKatalog,
                ["MIT_KATEGORIEN"] = mitKategorien ? 1 : 0,
                ["KATEGORIE_FELDER"] = kategorieFelder,
                ["MIT_LAGERBESTAND"] = mitLagerbestand ? 1 : 0,
                ["LAGER"] = lager,
                ["VON_LAGER"] = vonLager,
                ["BIS_LAGER"] = bisLager,
                ["MIT_ATTRIBUTEN"] = mitAttributen ? 1 : 0,
                ["ATTRIBUT_FELDER"] = attributFelder,
                ["MIT_ATTRIBUT_LANGTEXT"] = mitAttributLangtext,
                ["MIT_ATTRIBUTDEFINITION"] = mitAttributDefinition ? 1 : 0,
                ["ATTRIBUTDEFINITION_FELDER"] = attributDefinitionFelder,
                ["MIT_VARIANTEN"] = mitVarianten ? 1 : 0,
                ["MIT_VARIANTEN_WERTE"] = mitVariantenWerte ? 1 : 0,
                ["LANGTEXT_FORMAT"] = langtextFormat
            };
            EndpointParameters p = new EndpointParameters();
            parameter.Each(action =>
            {
                p = p.AddParameter(action.Key, action.Value);
            });
            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> GetAsync(
            string felder = "",
            bool nurAnzahl = false,
            bool nurGroesse = false,
            string sucheVolltext = "",
            string freiselekt = "",
            string freiselektKey = "",
            string freiselektVonIndex = "",
            string freiselektBisIndex = "",
            string freisort = "",
            string mitLangtext = "",
            bool ohneLeerfelder = false,
            string artNr = "",
            string vonArtNr = "",
            string bisArtNr = "",
            string wgr = "",
            string vonWgr = "",
            string bisWgr = "",
            string katalog = "",
            string vonKatalog = "",
            string bisKatalog = "",
            bool mitKategorien = false,
            string kategorieFelder = "",
            bool mitLagerbestand = false,
            string lager = "",
            string vonLager = "",
            string bisLager = "",
            bool mitAttributen = false,
            string attributFelder = "",
            string mitAttributLangtext = "",
            bool mitAttributDefinition = false,
            string attributDefinitionFelder = "",
            bool mitVarianten = false,
            bool mitVariantenWerte = false,
            string langtextFormat = "")
        {
            Dictionary<string, dynamic> parameter = new Dictionary<string, dynamic>()
            {
                ["FELDER"] = felder,
                ["NUR_ANZAHL"] = nurAnzahl ? 1 : 0,
                ["NUR_GROESSE"] = nurGroesse ? 1 : 0,
                ["SUCHE_VOLLTEXT"] = sucheVolltext,
                ["FREISELEKT"] = freiselekt,
                ["FREISELEKT_KEY"] = freiselektKey,
                ["FREISELEKT_VON_INDEX"] = freiselektVonIndex,
                ["FREISELEKT_BIS_INDEX"] = freiselektBisIndex,
                ["FREISORT"] = freisort,
                ["MIT_LANGTEXT"] = mitLangtext,
                ["OHNE_LEERFELDER"] = ohneLeerfelder ? 1 : 0,
                ["ARTNR"] = artNr,
                ["VON_ARTNR"] = vonArtNr,
                ["BIS_ARTNR"] = bisArtNr,
                ["WGR"] = wgr,
                ["VON_WGR"] = vonWgr,
                ["BIS_WGR"] = bisWgr,
                ["KATALOG"] = katalog,
                ["VON_KATALOG"] = vonKatalog,
                ["BIS_KATALOG"] = bisKatalog,
                ["MIT_KATEGORIEN"] = mitKategorien ? 1 : 0,
                ["KATEGORIE_FELDER"] = kategorieFelder,
                ["MIT_LAGERBESTAND"] = mitLagerbestand ? 1 : 0,
                ["LAGER"] = lager,
                ["VON_LAGER"] = vonLager,
                ["BIS_LAGER"] = bisLager,
                ["MIT_ATTRIBUTEN"] = mitAttributen ? 1 : 0,
                ["ATTRIBUT_FELDER"] = attributFelder,
                ["MIT_ATTRIBUT_LANGTEXT"] = mitAttributLangtext,
                ["MIT_ATTRIBUTDEFINITION"] = mitAttributDefinition ? 1 : 0,
                ["ATTRIBUTDEFINITION_FELDER"] = attributDefinitionFelder,
                ["MIT_VARIANTEN"] = mitVarianten ? 1 : 0,
                ["MIT_VARIANTEN_WERTE"] = mitVariantenWerte ? 1 : 0,
                ["LANGTEXT_FORMAT"] = langtextFormat
            };
            EndpointParameters p = new EndpointParameters();
            parameter.Each(action =>
            {
                p = p.AddParameter(action.Key, action.Value);
            });
            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}
