using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("MPKATEGORIE", 1)]
    public class MPKategorie : EndpointHelper
    {

        public MPKategorie(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Delete(string ktgNr)
        {
            return SendEndpointRequest(Method.Delete,
                new EndpointParameters().AddParameter("KTGNR", ktgNr).GetParameters(), null);
        }

        public async Task<RestResponse> DeleteAsync(string ktgNr)
        {
            return await SendEndpointRequestAsync(Method.Delete,
                new EndpointParameters().AddParameter("KTGNR", ktgNr).GetParameters(), null);
        }

        public RestResponse Insert(string ktgNr, Dictionary<string, dynamic> felder = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("KTGNR", ktgNr);
            if (felder != null) p = p.AddParameterList(felder);

            return SendEndpointRequest(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public async Task<RestResponse> InsertAsync(string ktgNr, Dictionary<string, dynamic> felder = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("KTGNR", ktgNr);
            if (felder != null) p = p.AddParameterList(felder);

            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public RestResponse Put(string ktgNr, Dictionary<string, dynamic> felder)
        {
            return SendEndpointRequest(Method.Put,
                new EndpointParameters().AddParameter("KTGNR", ktgNr).AddParameterList(felder).GetParameters(), null);
        }

        public async Task<RestResponse> PutAsync(string ktgNr, Dictionary<string, dynamic> felder)
        {
            return await SendEndpointRequestAsync(Method.Put,
                new EndpointParameters().AddParameter("KTGNR", ktgNr).AddParameterList(felder).GetParameters(), null);
        }

        public RestResponse Get(
            string felder = "",
            bool nurAnzahl = false,
            bool nurGroesse = false,
            string freiselekt = "",
            string freiselektKey = "",
            string freiselektVonIndex = "",
            string freiselektBisIndex = "",
            string freisort = "",
            bool ohneLeerfelder = false,
            string ktgNr = "",
            string vonKtgNr = "",
            string bisKtgNr = "",
            string mitLangtext = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("FELDER", felder)
                .AddParameter("NUR_ANZAHL", nurAnzahl)
                .AddParameter("NUR_GROESSE", nurGroesse)
                .AddParameter("FREISELEKT", freiselekt)
                .AddParameter("FREISELEKT_KEY", freiselektKey)
                .AddParameter("FREISELEKT_VON_INDEX", freiselektVonIndex)
                .AddParameter("FREISELEKT_BIS_INDEX", freiselektBisIndex)
                .AddParameter("FREISORT", freisort)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("KTGNR", ktgNr)
                .AddParameter("VON_KTGNR", vonKtgNr)
                .AddParameter("BIS_KTGNR", bisKtgNr)
                .AddParameter("MIT_LANGTEXT", mitLangtext);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> GetAsync(
            string felder = "",
            bool nurAnzahl = false,
            bool nurGroesse = false,
            string freiselekt = "",
            string freiselektKey = "",
            string freiselektVonIndex = "",
            string freiselektBisIndex = "",
            string freisort = "",
            bool ohneLeerfelder = false,
            string ktgNr = "",
            string vonKtgNr = "",
            string bisKtgNr = "",
            string mitLangtext = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("FELDER", felder)
                .AddParameter("NUR_ANZAHL", nurAnzahl)
                .AddParameter("NUR_GROESSE", nurGroesse)
                .AddParameter("FREISELEKT", freiselekt)
                .AddParameter("FREISELEKT_KEY", freiselektKey)
                .AddParameter("FREISELEKT_VON_INDEX", freiselektVonIndex)
                .AddParameter("FREISELEKT_BIS_INDEX", freiselektBisIndex)
                .AddParameter("FREISORT", freisort)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("KTGNR", ktgNr)
                .AddParameter("VON_KTGNR", vonKtgNr)
                .AddParameter("BIS_KTGNR", bisKtgNr)
                .AddParameter("MIT_LANGTEXT", mitLangtext);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}