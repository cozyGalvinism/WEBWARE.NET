using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("BELPOS", 1)]
    public class Belpos : EndpointHelper
    {

        public Belpos(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Insert(string belNdx, string artNr, string menge, bool langtextAufloesen = false,
            string einfuegeSnr = "", Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("BELNDX", belNdx)
                .AddParameter("POS_18_25", artNr)
                .AddParameter("POS_164_8", menge)
                .AddParameter("LANGTEXT_AUFLOESEN", langtextAufloesen)
                .AddParameter("EINFUEGE_SNR", einfuegeSnr);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return SendEndpointRequest(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public async Task<RestResponse> InsertAsync(string belNdx, string artNr, string menge, bool langtextAufloesen = false,
            string einfuegeSnr = "", Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("BELNDX", belNdx)
                .AddParameter("POS_18_25", artNr)
                .AddParameter("POS_164_8", menge)
                .AddParameter("LANGTEXT_AUFLOESEN", langtextAufloesen)
                .AddParameter("EINFUEGE_SNR", einfuegeSnr);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), null, fnc: "INSERT");
        }

        public RestResponse Put(string snr, bool mitVerbuchung = false, bool mitBerechnung = false,
            Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("SNR", snr)
                .AddParameter("MIT_VERBUCHUNG", mitVerbuchung)
                .AddParameter("MIT_BERECHNUNG", mitBerechnung);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> PutAsync(string snr, bool mitVerbuchung = false, bool mitBerechnung = false,
            Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("SNR", snr)
                .AddParameter("MIT_VERBUCHUNG", mitVerbuchung)
                .AddParameter("MIT_BERECHNUNG", mitBerechnung);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }

        public RestResponse Get(string belNdx, string felder = "", bool nurAnzahl = false, bool nurGroesse = false, string mitLangtext = "", bool ohneLeerfelder = false, string freisort = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("BELNDX", belNdx)
                .AddParameter("FELDER", felder)
                .AddParameter("NUR_ANZAHL", nurAnzahl)
                .AddParameter("NUR_GROESSE", nurGroesse)
                .AddParameter("MIT_LANGTEXT", mitLangtext)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("FREISORT", freisort);
            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> GetAsync(string belNdx, string felder = "", bool nurAnzahl = false, bool nurGroesse = false, string mitLangtext = "", bool ohneLeerfelder = false, string freisort = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("BELNDX", belNdx)
                .AddParameter("FELDER", felder)
                .AddParameter("NUR_ANZAHL", nurAnzahl)
                .AddParameter("NUR_GROESSE", nurGroesse)
                .AddParameter("MIT_LANGTEXT", mitLangtext)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("FREISORT", freisort);
            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}
