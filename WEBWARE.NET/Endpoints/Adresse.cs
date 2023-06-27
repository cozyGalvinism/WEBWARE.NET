using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using WEBWARE.NET.Enums;

namespace WEBWARE.NET.Endpoints
{
    /// <summary>
    /// Wrapper-Klasse zum Abrufen von Adressdaten
    /// </summary>
    [EndpointInfo("ADRESSE", 1)]
    public class Adresse : EndpointHelper
    {
        public Adresse(WEBWAREClient w) : base(w)
        {
            
        }

        /// <summary>
        /// Löscht einen Adressdatensatz
        /// </summary>
        /// <param name="adrNr">Adressnummer</param>
        /// <returns></returns>
        public RestResponse Delete(string adrNr)
        {
            return SendEndpointRequest(Method.Delete,
                new EndpointParameters().AddParameter("ADRNR", adrNr).GetParameters(), null);
        }

        public async Task<RestResponse> DeleteAsync(string adrNr)
        {
            return await SendEndpointRequestAsync(Method.Delete,
                new EndpointParameters().AddParameter("ADRNR", adrNr).GetParameters(), null);
        }

        /// <summary>
        /// Erstellt einen neuen Adressdatensatz
        /// </summary>
        /// <param name="typ">Typ der Adresse (KUNDE, LIEFERANT, ERSTKONTAKT)</param>
        /// <param name="felder">Zu setzende Felder</param>
        /// <param name="adrNr">Vorgabe für Adressnummer</param>
        /// <param name="adrArt">Vorgabe Adressart</param>
        /// <param name="adrKreis">Vorgabe Adresskreis</param>
        /// <param name="land">Vorgabe Ländereinstellungen</param>
        /// <param name="ohneStammkalk">Keine Stammdatenkalkulation durchführen</param>
        /// <param name="langtexte">Übergibt Langtext-Parameter. Dies ist ein Dictionary, dessen Keys folgende Werte annehmen können: NOTIZTEXT, WARNTEXT, NT72, NT73, NT74, NT75, NT76 und dessen Werte den zu setzenden Text für diesen Langtext darstellt</param>
        /// <returns></returns>
        public RestResponse Insert(ADRTyp typ, Dictionary<string, dynamic> felder = null, string adrNr = "",
            string adrArt = "", string adrKreis = "", string land = "", bool ohneStammkalk = false,
            Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr)
                .AddParameter("TYP", typ.ToString())
                .AddParameter("ADRART", adrArt)
                .AddParameter("ADRKREIS", adrKreis)
                .AddParameter("LAND", land)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk);
            if (felder != null) p = p.AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return SendEndpointRequest(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public async Task<RestResponse> InsertAsync(ADRTyp typ, Dictionary<string, dynamic> felder = null, string adrNr = "",
            string adrArt = "", string adrKreis = "", string land = "", bool ohneStammkalk = false,
            Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr)
                .AddParameter("TYP", typ.ToString())
                .AddParameter("ADRART", adrArt)
                .AddParameter("ADRKREIS", adrKreis)
                .AddParameter("LAND", land)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk);
            if (felder != null) p = p.AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        /// <summary>
        /// Aktualisiert einen bestehenden Adressdatensatz
        /// </summary>
        /// <param name="adrNr">Adressnummer</param>
        /// <param name="felder">Zu setzende Felder</param>
        /// <param name="ohneStammkalk">Keine Stammdatenkalkulation durchführen</param>
        /// <param name="langtexte">Übergibt Langtext-Parameter. Dies ist ein Dictionary, dessen Keys folgende Werte annehmen können: NOTIZTEXT, WARNTEXT, NT72, NT73, NT74, NT75, NT76 und dessen Werte den zu setzenden Text für diesen Langtext darstellt</param>
        /// <returns></returns>
        public RestResponse Put(string adrNr, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr).AddParameter("OHNE_STAMMKALK", ohneStammkalk).AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> PutAsync(string adrNr, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr).AddParameter("OHNE_STAMMKALK", ohneStammkalk).AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }

        /// <summary>
        /// Holt eine Liste von Adressdatensätzen
        /// </summary>
        /// <param name="felder">Übergibt eine Komma-getrennte Liste der gewünschten Datenfelder (z.B. FELDER=ADR_2_8,ADR_10_10)</param>
        /// <param name="nurAnzahl">Liefert als Antwortpaket nur die Anzahl der gefundenen Datensätze</param>
        /// <param name="nurGroesse">Liefert als Antwortpaket nur die Größe des in Bytes des tatsächlichen Antwortpakets</param>
        /// <param name="sucheVolltext">Übergibt einen Volltext-Suchbegriff. Die Volltextsuche wird als erster Schritt durchgeführt, danach werden weitere Selektionsparameter angewandt</param>
        /// <param name="freiselekt">übergibt einen freien Selektionsausdruck. Bsp.: (ADR_2_8 &lt; 70000 # ADR_10_10 = 'abcdef')</param>
        /// <param name="freiselektKey">Nummer des gewünschten Schlüssels (0...n) oder "AUTO" für automatische Ermittlung aus dem Selektionsausdruck (experimentell!)</param>
        /// <param name="freiselektVonIndex">Startwert für Index</param>
        /// <param name="freiselektBisIndex">Endwert für Index</param>
        /// <param name="freisort">Übergibt eine Komma-getrennte Liste der gewünschten Sortierfelder FREISORT = &lt;Feldname&gt;[ ASC|DESC][,…] (z.B. FREISORT=ART_178_9 DESC,ART_1_25 ASC) Es können derzeit maximal fünf Felder angegeben werden</param>
        /// <param name="mitLangtext">Übergibt Langtext-Parameter. Dies ist eine Komma-getrennte Liste folgender möglicher Werte: NOTIZTEXT, WARNTEXT, NT72, NT73, NT74, NT75, NT76</param>
        /// <param name="ohneLeerfelder">Datenfelder ohne Inhalt werden im Ergebnissatz komplett ausgelassen</param>
        /// <param name="adrNr">Adressnummer</param>
        /// <param name="vonAdrNr"></param>
        /// <param name="bisAdrNr">Schränkt die Liste auf den angegebenen Adressnummernbereich ein</param>
        /// <returns></returns>
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
            string adrNr = "",
            string vonAdrNr = "",
            string bisAdrNr = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("FELDER", felder)
                .AddParameter("NUR_ANZAHL", nurAnzahl)
                .AddParameter("NUR_GROESSE", nurGroesse)
                .AddParameter("SUCHE_VOLLTEXT", sucheVolltext)
                .AddParameter("FREISELEKT", freiselekt)
                .AddParameter("FREISELEKT_KEY", freiselektKey)
                .AddParameter("FREISELEKT_VON_INDEX", freiselektVonIndex)
                .AddParameter("FREISELEKT_BIS_INDEX", freiselektBisIndex)
                .AddParameter("FREISORT", freisort)
                .AddParameter("MIT_LANGTEXT", mitLangtext)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("ADRNR", adrNr)
                .AddParameter("VON_ADRNR", vonAdrNr)
                .AddParameter("BIS_ADRNR", bisAdrNr);
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
            string adrNr = "",
            string vonAdrNr = "",
            string bisAdrNr = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("FELDER", felder)
                .AddParameter("NUR_ANZAHL", nurAnzahl)
                .AddParameter("NUR_GROESSE", nurGroesse)
                .AddParameter("SUCHE_VOLLTEXT", sucheVolltext)
                .AddParameter("FREISELEKT", freiselekt)
                .AddParameter("FREISELEKT_KEY", freiselektKey)
                .AddParameter("FREISELEKT_VON_INDEX", freiselektVonIndex)
                .AddParameter("FREISELEKT_BIS_INDEX", freiselektBisIndex)
                .AddParameter("FREISORT", freisort)
                .AddParameter("MIT_LANGTEXT", mitLangtext)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("ADRNR", adrNr)
                .AddParameter("VON_ADRNR", vonAdrNr)
                .AddParameter("BIS_ADRNR", bisAdrNr);
            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}
