using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("CHARGE", 1)]
    public class Charge : EndpointHelper
    {

        public Charge(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Delete(string chaNr)
        {
            return SendEndpointRequest(Method.Delete,
                new EndpointParameters().AddParameter("CHANR", chaNr).GetParameters(), null);
        }

        public async Task<RestResponse> DeleteAsync(string chaNr)
        {
            return await SendEndpointRequestAsync(Method.Delete,
                new EndpointParameters().AddParameter("CHANR", chaNr).GetParameters(), null);
        }

        public RestResponse Insert(string chaNr, Dictionary<string, dynamic> felder = null, bool ohneStammkalk = false,
            bool nurTesten = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("CHANR", chaNr)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk)
                .AddParameter("NUR_TESTEN", nurTesten);
            if (felder != null) p = p.AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return SendEndpointRequest(Method.Post, p.GetParameters(), null, "INSERT");
        }

        public async Task<RestResponse> InsertAsync(string chaNr, Dictionary<string, dynamic> felder = null, bool ohneStammkalk = false,
            bool nurTesten = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("CHANR", chaNr)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk)
                .AddParameter("NUR_TESTEN", nurTesten);
            if (felder != null) p = p.AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), null, "INSERT");
        }

        public RestResponse Put(string chaNr, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("CHANR", chaNr)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk)
                .AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> PutAsync(string chaNr, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("CHANR", chaNr)
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
            string chaNr = "",
            string vonChaNr = "",
            string bisChaNr = "",
            string artNr = "",
            string vonArtNr = "",
            string bisArtNr = "")
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
                .AddParameter("CHANR", chaNr)
                .AddParameter("VON_CHANR", vonChaNr)
                .AddParameter("BIS_CHANR", bisChaNr)
                .AddParameter("ARTNR", artNr)
                .AddParameter("VON_ARTNR", vonArtNr)
                .AddParameter("BIS_ARTNR", bisArtNr);
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
            string chaNr = "",
            string vonChaNr = "",
            string bisChaNr = "",
            string artNr = "",
            string vonArtNr = "",
            string bisArtNr = "")
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
                .AddParameter("CHANR", chaNr)
                .AddParameter("VON_CHANR", vonChaNr)
                .AddParameter("BIS_CHANR", bisChaNr)
                .AddParameter("ARTNR", artNr)
                .AddParameter("VON_ARTNR", vonArtNr)
                .AddParameter("BIS_ARTNR", bisArtNr);
            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}
