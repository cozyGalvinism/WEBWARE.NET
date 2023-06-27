using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("VERTRETER", 1)]
    public class Vertreter : EndpointHelper
    {

        public Vertreter(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Delete(string vtrNr)
        {
            return SendEndpointRequest(Method.Delete,
                new EndpointParameters().AddParameter("VTRNR", vtrNr).GetParameters(), null);
        }

        public async Task<RestResponse> DeleteAsync(string vtrNr)
        {
            return await SendEndpointRequestAsync(Method.Delete,
                new EndpointParameters().AddParameter("VTRNR", vtrNr).GetParameters(), null);
        }

        public RestResponse Insert(string vtrNr, Dictionary<string, dynamic> felder = null, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("VTRNR", vtrNr)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk);
            if (felder != null) p = p.AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);

            return SendEndpointRequest(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public async Task<RestResponse> InsertAsync(string vtrNr, Dictionary<string, dynamic> felder = null, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("VTRNR", vtrNr)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk);
            if (felder != null) p = p.AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);

            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public RestResponse Put(string vtrNr, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("VTRNR", vtrNr)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk)
                .AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> PutAsync(string vtrNr, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("VTRNR", vtrNr)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk)
                .AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);

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
            string vtrNr = "",
            string vonVtrNr = "",
            string bisVtrNr = "")
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
                .AddParameter("VTRNR", vtrNr)
                .AddParameter("VON_VTRNR", vonVtrNr)
                .AddParameter("BIS_VTRNR", bisVtrNr);

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
            string vtrNr = "",
            string vonVtrNr = "",
            string bisVtrNr = "")
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
                .AddParameter("VTRNR", vtrNr)
                .AddParameter("VON_VTRNR", vonVtrNr)
                .AddParameter("BIS_VTRNR", bisVtrNr);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}
