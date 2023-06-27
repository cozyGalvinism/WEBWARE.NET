using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("ANSPRECHPARTNER", 1)]
    public class Ansprechpartner : EndpointHelper
    {

        public Ansprechpartner(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Delete(string adrNr, string anpNr)
        {
            return SendEndpointRequest(Method.Delete, new EndpointParameters().AddParameter("ADRNR", adrNr).AddParameter("ANPNR", anpNr), null);
        }

        public async Task<RestResponse> DeleteAsync(string adrNr, string anpNr)
        {
            return await SendEndpointRequestAsync(Method.Delete, new EndpointParameters().AddParameter("ADRNR", adrNr).AddParameter("ANPNR", anpNr), null);
        }

        public RestResponse Insert(string adrNr, Dictionary<string, dynamic> felder = null, string anpNr = "", bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr)
                .AddParameter("ANPNR", anpNr)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk);
            if (felder != null) p = p.AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);

            return SendEndpointRequest(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public async Task<RestResponse> InsertAsync(string adrNr, Dictionary<string, dynamic> felder = null, string anpNr = "", bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr)
                .AddParameter("ANPNR", anpNr)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk);
            if (felder != null) p = p.AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);

            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public RestResponse Put(string adrNr, string anpNr, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr)
                .AddParameter("ANPNR", anpNr)
                .AddParameterList(felder)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk);
            if (langtexte != null) p = p.AddParameterList(langtexte);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> PutAsync(string adrNr, string anpNr, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr)
                .AddParameter("ANPNR", anpNr)
                .AddParameterList(felder)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk);
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
            string adrNr = "",
            string vonAdrNr = "",
            string bisAdrNr = "",
            string anpNr = "",
            string vonAnpNr = "",
            string bisAnpNr = "")
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
                .AddParameter("ADRNR", adrNr)
                .AddParameter("VON_ADRNR", vonAdrNr)
                .AddParameter("BIS_ADRNR", bisAdrNr)
                .AddParameter("ANPNR", anpNr)
                .AddParameter("VON_ANPNR", vonAnpNr)
                .AddParameter("BIS_ANPNR", bisAnpNr);

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
            string adrNr = "",
            string vonAdrNr = "",
            string bisAdrNr = "",
            string anpNr = "",
            string vonAnpNr = "",
            string bisAnpNr = "")
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
                .AddParameter("ADRNR", adrNr)
                .AddParameter("VON_ADRNR", vonAdrNr)
                .AddParameter("BIS_ADRNR", bisAdrNr)
                .AddParameter("ANPNR", anpNr)
                .AddParameter("VON_ANPNR", vonAnpNr)
                .AddParameter("BIS_ANPNR", bisAnpNr);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}
