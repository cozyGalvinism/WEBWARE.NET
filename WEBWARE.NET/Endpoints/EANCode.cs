using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("EANCODE", 1)]
    public class EANCode : EndpointHelper
    {

        public EANCode(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Delete(string ean)
        {
            return SendEndpointRequest(Method.Delete, new EndpointParameters().AddParameter("EAN", ean).GetParameters(),
                null);
        }

        public async Task<RestResponse> DeleteAsync(string ean)
        {
            return await SendEndpointRequestAsync(Method.Delete, new EndpointParameters().AddParameter("EAN", ean).GetParameters(),
                null);
        }

        public RestResponse Insert(string ean, Dictionary<string, dynamic> felder = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("EAN", ean);
            if (felder != null) p = p.AddParameterList(felder);

            return SendEndpointRequest(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public async Task<RestResponse> InsertAsync(string ean, Dictionary<string, dynamic> felder = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("EAN", ean);
            if (felder != null) p = p.AddParameterList(felder);

            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public RestResponse Put(string ean, Dictionary<string, dynamic> felder)
        {
            return SendEndpointRequest(Method.Put,
                new EndpointParameters().AddParameter("EAN", ean).AddParameterList(felder).GetParameters(), null);
        }

        public async Task<RestResponse> PutAsync(string ean, Dictionary<string, dynamic> felder)
        {
            return await SendEndpointRequestAsync(Method.Put,
                new EndpointParameters().AddParameter("EAN", ean).AddParameterList(felder).GetParameters(), null);
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
            string ean = "",
            string vonEan = "",
            string bisEan = "",
            string vonArtNr = "",
            string bisArtNr = "")
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
                .AddParameter("EAN", ean)
                .AddParameter("VON_EAN", vonEan)
                .AddParameter("BIS_EAN", bisEan)
                .AddParameter("VON_ARTNR", vonArtNr)
                .AddParameter("BIS_ARTNR", bisArtNr);

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
            string ean = "",
            string vonEan = "",
            string bisEan = "",
            string vonArtNr = "",
            string bisArtNr = "")
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
                .AddParameter("EAN", ean)
                .AddParameter("VON_EAN", vonEan)
                .AddParameter("BIS_EAN", bisEan)
                .AddParameter("VON_ARTNR", vonArtNr)
                .AddParameter("BIS_ARTNR", bisArtNr);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}