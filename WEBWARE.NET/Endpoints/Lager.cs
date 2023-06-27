using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("LAGER", 1)]
    public class Lager : EndpointHelper
    {

        public Lager(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Delete(string lager)
        {
            return SendEndpointRequest(Method.Delete,
                new EndpointParameters().AddParameter("LAGER", lager).GetParameters(), null);
        }

        public async Task<RestResponse> DeleteAsync(string lager)
        {
            return await SendEndpointRequestAsync(Method.Delete,
                new EndpointParameters().AddParameter("LAGER", lager).GetParameters(), null);
        }

        public RestResponse Insert(string lager, Dictionary<string, dynamic> felder = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("LAGER", lager);
            if (felder != null) p = p.AddParameterList(felder);

            return SendEndpointRequest(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public async Task<RestResponse> InsertAsync(string lager, Dictionary<string, dynamic> felder = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("LAGER", lager);
            if (felder != null) p = p.AddParameterList(felder);

            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public RestResponse Put(string lager, Dictionary<string, dynamic> felder)
        {
            return SendEndpointRequest(Method.Put,
                new EndpointParameters().AddParameter("LAGER", lager).AddParameterList(felder).GetParameters(), null);
        }

        public async Task<RestResponse> PutAsync(string lager, Dictionary<string, dynamic> felder)
        {
            return await SendEndpointRequestAsync(Method.Put,
                new EndpointParameters().AddParameter("LAGER", lager).AddParameterList(felder).GetParameters(), null);
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
            string lager = "",
            string vonLager = "",
            string bisLager = "")
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
                .AddParameter("LAGER", lager)
                .AddParameter("VON_LAGER", vonLager)
                .AddParameter("BIS_LAGER", bisLager);

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
            string lager = "",
            string vonLager = "",
            string bisLager = "")
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
                .AddParameter("LAGER", lager)
                .AddParameter("VON_LAGER", vonLager)
                .AddParameter("BIS_LAGER", bisLager);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}