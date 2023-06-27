using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("DBP", 1)]
    public class DBP : EndpointHelper
    {

        public string DBPNr { get; set; }

        public DBP(WEBWAREClient w, string dbpNr) : base(w)
        {
            DBPNr = dbpNr;
        }

        public RestResponse Insert(string dbkNdx, bool mitVerbuchung = false, bool mitBerechnung = false, string einfuegeSnr = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("DBKNDX", dbkNdx)
                .AddParameter("MIT_VERBUCHUNG", mitVerbuchung)
                .AddParameter("MIT_BERECHNUNG", mitBerechnung)
                .AddParameter("EINFUEGE_SNR", einfuegeSnr);
            return SendEndpointRequest(Method.Post, p.GetParameters(), null, fnc: "DBP" + DBPNr + ".INSERT");
        }

        public async Task<RestResponse> InsertAsync(string dbkNdx, bool mitVerbuchung = false, bool mitBerechnung = false, string einfuegeSnr = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("DBKNDX", dbkNdx)
                .AddParameter("MIT_VERBUCHUNG", mitVerbuchung)
                .AddParameter("MIT_BERECHNUNG", mitBerechnung)
                .AddParameter("EINFUEGE_SNR", einfuegeSnr);
            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), null, fnc: "DBP" + DBPNr + ".INSERT");
        }

        public RestResponse Put(string snr, bool mitVerbuchung = false, bool mitBerechnung = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("SNR", snr)
                .AddParameter("MIT_VERBUCHUNG", mitVerbuchung)
                .AddParameter("MIT_BERECHNUNG", mitBerechnung);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "DBP" + DBPNr + ".PUT");
        }

        public async Task<RestResponse> PutAsync(string snr, bool mitVerbuchung = false, bool mitBerechnung = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("SNR", snr)
                .AddParameter("MIT_VERBUCHUNG", mitVerbuchung)
                .AddParameter("MIT_BERECHNUNG", mitBerechnung);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "DBP" + DBPNr + ".PUT");
        }

        public RestResponse Get(string dbkNdx, string felder = "", bool ohneLeerfelder = false, string freisort = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("DBKNDX", dbkNdx)
                .AddParameter("FELDER", felder)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("FREISORT", freisort);
            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "DBP" + DBPNr + ".GET");
        }

        public async Task<RestResponse> GetAsync(string dbkNdx, string felder = "", bool ohneLeerfelder = false, string freisort = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("DBKNDX", dbkNdx)
                .AddParameter("FELDER", felder)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("FREISORT", freisort);
            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "DBP" + DBPNr + ".GET");
        }
    }
}
