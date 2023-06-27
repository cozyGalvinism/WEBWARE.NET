using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("PROJEKT", 1)]
    public class Projekt : EndpointHelper
    {

        public Projekt(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Delete(string prjNr)
        {
            return SendEndpointRequest(Method.Delete, new EndpointParameters().AddParameter("PRJNR", prjNr).GetParameters(), null);
        }

        public async Task<RestResponse> DeleteAsync(string prjNr)
        {
            return await SendEndpointRequestAsync(Method.Delete, new EndpointParameters().AddParameter("PRJNR", prjNr).GetParameters(), null);
        }

        public RestResponse Insert(string prjNr = "", bool ohneStammkalk = false, bool nurTesten = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("PRJNR", prjNr)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk)
                .AddParameter("NUR_TESTEN", nurTesten);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return SendEndpointRequest(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public async Task<RestResponse> InsertAsync(string prjNr = "", bool ohneStammkalk = false, bool nurTesten = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("PRJNR", prjNr)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk)
                .AddParameter("NUR_TESTEN", nurTesten);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public RestResponse Put(string prjNr, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("PRJNR", prjNr)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk)
                .AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> PutAsync(string prjNr, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("PRJNR", prjNr)
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
            string prjNr = "",
            string vonPrjNr = "",
            string bisPrjNr = "",
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
                .AddParameter("PRJNR", prjNr)
                .AddParameter("VON_PRJNR", vonPrjNr)
                .AddParameter("BIS_PRJNR", bisPrjNr)
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
            string prjNr = "",
            string vonPrjNr = "",
            string bisPrjNr = "",
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
                .AddParameter("PRJNR", prjNr)
                .AddParameter("VON_PRJNR", vonPrjNr)
                .AddParameter("BIS_PRJNR", bisPrjNr)
                .AddParameter("ADRNR", adrNr)
                .AddParameter("VON_ADRNR", vonAdrNr)
                .AddParameter("BIS_ADRNR", bisAdrNr);
            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}
