using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("WIEDERVORLAGE", 1)]
    public class Wiedervorlage : EndpointHelper
    {

        public Wiedervorlage(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Delete(string wvlId)
        {
            return SendEndpointRequest(Method.Delete, new EndpointParameters().AddParameter("WVLID", wvlId), null);
        }

        public async Task<RestResponse> DeleteAsync(string wvlId)
        {
            return await SendEndpointRequestAsync(Method.Delete, new EndpointParameters().AddParameter("WVLID", wvlId), null);
        }

        public RestResponse Insert(DateTime datum, string fuerBdNr, Dictionary<string, dynamic> felder = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("DATUM", datum.ToString("dd.MM.yyyy"))
                .AddParameter("FUER_BDNR", fuerBdNr);
            if (felder != null) p = p.AddParameterList(felder);
            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "INSERT");
        }

        public async Task<RestResponse> InsertAsync(DateTime datum, string fuerBdNr, Dictionary<string, dynamic> felder = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("DATUM", datum.ToString("dd.MM.yyyy"))
                .AddParameter("FUER_BDNR", fuerBdNr);
            if (felder != null) p = p.AddParameterList(felder);
            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "INSERT");
        }

        public RestResponse Put(string wvlId, Dictionary<string, dynamic> felder)
        {
            return SendEndpointRequest(Method.Put,
                new EndpointParameters().AddParameter("WVLID", wvlId).AddParameterList(felder), null);
        }

        public async Task<RestResponse> PutAsync(string wvlId, Dictionary<string, dynamic> felder)
        {
            return await SendEndpointRequestAsync(Method.Put,
                new EndpointParameters().AddParameter("WVLID", wvlId).AddParameterList(felder), null);
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
            string wvlId = "",
            string vonWvlId = "",
            string bisWvlId = "",
            DateTime? vonDatum = null,
            DateTime? bisDatum = null,
            string adrNr = "",
            string anpNr = "",
            string prjNr = "",
            string bedNr = "",
            string belNdx = "")
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
                .AddParameter("WVLID", wvlId)
                .AddParameter("VON_WVLID", vonWvlId)
                .AddParameter("BIS_WVLID", bisWvlId)
                .AddParameter("VON_DATUM", vonDatum?.ToString("dd.MM.yyyy"))
                .AddParameter("BIS_DATUM", bisDatum?.ToString("dd.MM.yyyy"))
                .AddParameter("ADRNR", adrNr)
                .AddParameter("ANPNR", anpNr)
                .AddParameter("PRJNR", prjNr)
                .AddParameter("BEDNR", bedNr)
                .AddParameter("BELNDX", belNdx);

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
            string wvlId = "",
            string vonWvlId = "",
            string bisWvlId = "",
            DateTime? vonDatum = null,
            DateTime? bisDatum = null,
            string adrNr = "",
            string anpNr = "",
            string prjNr = "",
            string bedNr = "",
            string belNdx = "")
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
                .AddParameter("WVLID", wvlId)
                .AddParameter("VON_WVLID", vonWvlId)
                .AddParameter("BIS_WVLID", bisWvlId)
                .AddParameter("VON_DATUM", vonDatum?.ToString("dd.MM.yyyy"))
                .AddParameter("BIS_DATUM", bisDatum?.ToString("dd.MM.yyyy"))
                .AddParameter("ADRNR", adrNr)
                .AddParameter("ANPNR", anpNr)
                .AddParameter("PRJNR", prjNr)
                .AddParameter("BEDNR", bedNr)
                .AddParameter("BELNDX", belNdx);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}