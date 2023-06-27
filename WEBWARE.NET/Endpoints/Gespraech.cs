using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("GESPRAECH", 1)]
    public class Gespraech : EndpointHelper
    {

        public Gespraech(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Delete(string pk)
        {
            return SendEndpointRequest(Method.Delete, new EndpointParameters().AddParameter("PK", pk), null);
        }

        public async Task<RestResponse> DeleteAsync(string pk)
        {
            return await SendEndpointRequestAsync(Method.Delete, new EndpointParameters().AddParameter("PK", pk), null);
        }

        public RestResponse Insert(string adrNr, DateTime datum, DateTime startzeit,
            Dictionary<string, dynamic> felder = null, DateTime? endzeit = null, string anpNr = "", string prjNr = "",
            string bedNr = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr)
                .AddParameter("DATUM", datum.ToString("dd.MM.yyyy"))
                .AddParameter("STARTZEIT", startzeit.ToString("hh:mm"))
                .AddParameter("ENDZEIT", endzeit?.ToString("hh:mm"))
                .AddParameter("ANPNR", anpNr)
                .AddParameter("PRJNR", prjNr)
                .AddParameter("BEDNR", bedNr);
            if (felder != null) p = p.AddParameterList(felder);

            return SendEndpointRequest(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public async Task<RestResponse> InsertAsync(string adrNr, DateTime datum, DateTime startzeit,
            Dictionary<string, dynamic> felder = null, DateTime? endzeit = null, string anpNr = "", string prjNr = "",
            string bedNr = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr)
                .AddParameter("DATUM", datum.ToString("dd.MM.yyyy"))
                .AddParameter("STARTZEIT", startzeit.ToString("hh:mm"))
                .AddParameter("ENDZEIT", endzeit?.ToString("hh:mm"))
                .AddParameter("ANPNR", anpNr)
                .AddParameter("PRJNR", prjNr)
                .AddParameter("BEDNR", bedNr);
            if (felder != null) p = p.AddParameterList(felder);

            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public RestResponse Put(string pk, Dictionary<string, dynamic> felder)
        {
            return SendEndpointRequest(Method.Put, new EndpointParameters().AddParameter("PK", pk).AddParameterList(felder), null);
        }

        public async Task<RestResponse> PutAsync(string pk, Dictionary<string, dynamic> felder)
        {
            return await SendEndpointRequestAsync(Method.Put, new EndpointParameters().AddParameter("PK", pk).AddParameterList(felder), null);
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
            string pk = "",
            string vonPk = "",
            string bisPk = "")
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
                .AddParameter("PK", pk)
                .AddParameter("VON_PK", vonPk)
                .AddParameter("BIS_PK", bisPk);

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
            string pk = "",
            string vonPk = "",
            string bisPk = "")
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
                .AddParameter("PK", pk)
                .AddParameter("VON_PK", vonPk)
                .AddParameter("BIS_PK", bisPk);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}