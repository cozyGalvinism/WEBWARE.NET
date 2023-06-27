using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("LIEFERADRESSE", 1)]
    public class Lieferadresse : EndpointHelper
    {

        public Lieferadresse(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Delete(string lfaNr)
        {
            return SendEndpointRequest(Method.Delete, new EndpointParameters().AddParameter("LFANR", lfaNr), null);
        }

        public async Task<RestResponse> DeleteAsync(string lfaNr)
        {
            return await SendEndpointRequestAsync(Method.Delete, new EndpointParameters().AddParameter("LFANR", lfaNr), null);
        }

        public RestResponse Insert(Dictionary<string, dynamic> felder = null, string lfaNr = "",
            bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("LFANR", lfaNr)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk);
            if (felder != null) p = p.AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "INSERT");
        }

        public async Task<RestResponse> InsertAsync(Dictionary<string, dynamic> felder = null, string lfaNr = "",
            bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("LFANR", lfaNr)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk);
            if (felder != null) p = p.AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "INSERT");
        }

        public RestResponse Put(string lfaNr, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("LFANR", lfaNr)
                .AddParameterList(felder)
                .AddParameter("OHNE_STAMMKALK", ohneStammkalk);
            if (langtexte != null) p = p.AddParameterList(langtexte);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> PutAsync(string lfaNr, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("LFANR", lfaNr)
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
            string adrNr = "",
            string vonAdrNr = "",
            string bisAdrNr = "",
            string lfaNr = "",
            string vonLfaNr = "",
            string bisLfaNr = "")
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
                .AddParameter("ADRNR", adrNr)
                .AddParameter("VON_ADRNR", vonAdrNr)
                .AddParameter("BIS_ADRNR", bisAdrNr)
                .AddParameter("LFANR", lfaNr)
                .AddParameter("VON_LFANR", vonLfaNr)
                .AddParameter("BIS_LFANR", bisLfaNr);

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
            string adrNr = "",
            string vonAdrNr = "",
            string bisAdrNr = "",
            string lfaNr = "",
            string vonLfaNr = "",
            string bisLfaNr = "")
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
                .AddParameter("ADRNR", adrNr)
                .AddParameter("VON_ADRNR", vonAdrNr)
                .AddParameter("BIS_ADRNR", bisAdrNr)
                .AddParameter("LFANR", lfaNr)
                .AddParameter("VON_LFANR", vonLfaNr)
                .AddParameter("BIS_LFANR", bisLfaNr);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}
