using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("WARENGRUPPEN", 1)]
    public class Warengruppe : EndpointHelper
    {

        public Warengruppe(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Delete(string wgrNr)
        {
            return SendEndpointRequest(Method.Delete,
                new EndpointParameters().AddParameter("WGRNR", wgrNr).GetParameters(), null);
        }

        public async Task<RestResponse> DeleteAsync(string wgrNr)
        {
            return await SendEndpointRequestAsync(Method.Delete,
                new EndpointParameters().AddParameter("WGRNR", wgrNr).GetParameters(), null);
        }

        public RestResponse Insert(string wgrNr, Dictionary<string, dynamic> felder = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("WGRNR", wgrNr);
            if (felder != null) p = p.AddParameterList(felder);

            return SendEndpointRequest(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public async Task<RestResponse> InsertAsync(string wgrNr, Dictionary<string, dynamic> felder = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("WGRNR", wgrNr);
            if (felder != null) p = p.AddParameterList(felder);

            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public RestResponse Put(string wgrNr, Dictionary<string, dynamic> felder)
        {
            return SendEndpointRequest(Method.Put,
                new EndpointParameters().AddParameter("WGRNR", wgrNr).AddParameterList(felder), null);
        }

        public async Task<RestResponse> PutAsync(string wgrNr, Dictionary<string, dynamic> felder)
        {
            return await SendEndpointRequestAsync(Method.Put,
                new EndpointParameters().AddParameter("WGRNR", wgrNr).AddParameterList(felder), null);
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
            string mitLangtext = "",
            bool ohneLeerfelder = false,
            string wgrNr = "",
            string vonWgrNr = "",
            string bisWgrNr = "")
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
                .AddParameter("MIT_LANGTEXT", mitLangtext)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("WGRNR", wgrNr)
                .AddParameter("VON_WGRNR", vonWgrNr)
                .AddParameter("BIS_WGRNR", bisWgrNr);

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
            string mitLangtext = "",
            bool ohneLeerfelder = false,
            string wgrNr = "",
            string vonWgrNr = "",
            string bisWgrNr = "")
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
                .AddParameter("MIT_LANGTEXT", mitLangtext)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("WGRNR", wgrNr)
                .AddParameter("VON_WGRNR", vonWgrNr)
                .AddParameter("BIS_WGRNR", bisWgrNr);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}