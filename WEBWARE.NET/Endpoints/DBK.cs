using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("DBK", 1)]
    public class DBK : EndpointHelper
    {

        public string DBKNr { get; set; }

        public DBK(WEBWAREClient w, string dbkNr) : base(w)
        {
            DBKNr = dbkNr;
        }

        public RestResponse Delete(string pk)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("PK", pk);
            return SendEndpointRequest(Method.Delete, p.GetParameters(), null, fnc: "DBK" + DBKNr + ".DELETE");
        }

        public async Task<RestResponse> DeleteAsync(string pk)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("PK", pk);
            return await SendEndpointRequestAsync(Method.Delete, p.GetParameters(), null, fnc: "DBK" + DBKNr + ".DELETE");
        }

        public RestResponse Insert(string pk = "", bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("PK", pk).AddParameter("OHNE_STAMMKALK", ohneStammkalk);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return SendEndpointRequest(Method.Post, p.GetParameters(), null, fnc: "DBK" + DBKNr + ".INSERT");
        }

        public async Task<RestResponse> InsertAsync(string pk = "", bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("PK", pk).AddParameter("OHNE_STAMMKALK", ohneStammkalk);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), null, fnc: "DBK" + DBKNr + ".INSERT");
        }

        public RestResponse Put(string pk, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("PK", pk).AddParameter("OHNE_STAMMKALK", ohneStammkalk).AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "DBK" + DBKNr + ".PUT");
        }

        public async Task<RestResponse> PutAsync(string pk, Dictionary<string, dynamic> felder, bool ohneStammkalk = false, Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("PK", pk).AddParameter("OHNE_STAMMKALK", ohneStammkalk).AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "DBK" + DBKNr + ".PUT");
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
            string pk = "",
            string vonPk = "",
            string bisPk = "")
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
                .AddParameter("PK", pk)
                .AddParameter("VON_PK", vonPk)
                .AddParameter("BIS_PK", bisPk);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "DBK" + DBKNr + ".GET");
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
            string pk = "",
            string vonPk = "",
            string bisPk = "")
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
                .AddParameter("PK", pk)
                .AddParameter("VON_PK", vonPk)
                .AddParameter("BIS_PK", bisPk);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "DBK" + DBKNr + ".GET");
        }
    }
}
