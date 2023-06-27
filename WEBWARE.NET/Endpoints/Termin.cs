using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("TERMIN", 1)]
    public class Termin : EndpointHelper
    {

        public Termin(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Delete(string pk, bool ganztag)
        {
            return SendEndpointRequest(Method.Delete, new EndpointParameters().AddParameter("PK", pk).AddParameter("GANZTAG", ganztag), null);
        }

        public RestResponse Insert(string persNr, DateTime vonDatum, string titel,
            Dictionary<string, dynamic> felder = null, DateTime? bisDatum = null, DateTime? vonZeit = null, DateTime? bisZeit = null, string text = "", bool ohneStammkalk = false)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("PERSNR", persNr)
                .AddParameter("VON_DATUM", vonDatum.ToString("dd.MM.yyyy"))
                .AddParameter("TITEL", titel)
                .AddParameter("BIS_DATUM", bisDatum?.ToString("dd.MM.yyyy"))
                .AddParameter("VON_ZEIT", vonZeit?.ToString("hh:mm"))
                .AddParameter("BIS_ZEIT", bisZeit?.ToString("hh:mm"))
                .AddParameter("TEXT", text)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk);
            if (felder != null) p = p.AddParameterList(felder);

            return SendEndpointRequest(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public async Task<RestResponse> InsertAsync(string persNr, DateTime vonDatum, string titel,
            Dictionary<string, dynamic> felder = null, DateTime? bisDatum = null, DateTime? vonZeit = null, DateTime? bisZeit = null, string text = "", bool ohneStammkalk = false)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("PERSNR", persNr)
                .AddParameter("VON_DATUM", vonDatum.ToString("dd.MM.yyyy"))
                .AddParameter("TITEL", titel)
                .AddParameter("BIS_DATUM", bisDatum?.ToString("dd.MM.yyyy"))
                .AddParameter("VON_ZEIT", vonZeit?.ToString("hh:mm"))
                .AddParameter("BIS_ZEIT", bisZeit?.ToString("hh:mm"))
                .AddParameter("TEXT", text)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk);
            if (felder != null) p = p.AddParameterList(felder);

            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public RestResponse Put(string pk, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, bool ganztag = false)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("PK", pk)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk)
                .AddParameter("GANZTAG", ganztag)
                .AddParameterList(felder);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> PutAsync(string pk, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, bool ganztag = false)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("PK", pk)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk)
                .AddParameter("GANZTAG", ganztag)
                .AddParameterList(felder);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }

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
            bool ganztag = false,
            string pk = "",
            string persNr = "",
            string vonPersNr = "",
            string bisPersNr = "",
            DateTime? datum = null,
            DateTime? vonDatum = null,
            DateTime? bisDatum = null)
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
                .AddParameter("GANZTAG", ganztag)
                .AddParameter("PK", pk)
                .AddParameter("PERSNR", persNr)
                .AddParameter("VON_PERSNR", vonPersNr)
                .AddParameter("BIS_PERSNR", bisPersNr)
                .AddParameter("DATUM", datum?.ToString("dd.MM.yyyy"))
                .AddParameter("VON_DATUM", vonDatum?.ToString("dd.MM.yyyy"))
                .AddParameter("BIS_DATUM", bisDatum?.ToString("dd.MM.yyyy"));

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
            bool ganztag = false,
            string pk = "",
            string persNr = "",
            string vonPersNr = "",
            string bisPersNr = "",
            DateTime? datum = null,
            DateTime? vonDatum = null,
            DateTime? bisDatum = null)
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
                .AddParameter("GANZTAG", ganztag)
                .AddParameter("PK", pk)
                .AddParameter("PERSNR", persNr)
                .AddParameter("VON_PERSNR", vonPersNr)
                .AddParameter("BIS_PERSNR", bisPersNr)
                .AddParameter("DATUM", datum?.ToString("dd.MM.yyyy"))
                .AddParameter("VON_DATUM", vonDatum?.ToString("dd.MM.yyyy"))
                .AddParameter("BIS_DATUM", bisDatum?.ToString("dd.MM.yyyy"));

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}