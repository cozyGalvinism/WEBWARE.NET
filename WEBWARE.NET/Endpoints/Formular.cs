using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using WEBWARE.NET.Enums;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("FORMULAR", 1)]
    public class Formular : EndpointHelper
    {
        public Formular(WEBWAREClient client) : base(client)
        {
        }

        public RestResponse Get(Formularbereich bereich = Formularbereich.Kein, string vonFmtNr = "",
            string bisFmtNr = "9999", string name = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("VON_FMTNR", vonFmtNr)
                .AddParameter("BIS_FMTNR", bisFmtNr)
                .AddParameter("NAME", name);
            if (bereich != Formularbereich.Kein) p = p.AddParameter("BEREICH", bereich.ToString());

            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> GetAsync(Formularbereich bereich = Formularbereich.Kein, string vonFmtNr = "",
            string bisFmtNr = "9999", string name = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("VON_FMTNR", vonFmtNr)
                .AddParameter("BIS_FMTNR", bisFmtNr)
                .AddParameter("NAME", name);
            if (bereich != Formularbereich.Kein) p = p.AddParameter("BEREICH", bereich.ToString());

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }

        public RestResponse Exec(string name, string drucker, Dictionary<string, dynamic> eingabevariablen = null,
            Dictionary<string, dynamic> selektionsvariablen = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("NAME", name)
                .AddParameter("DRUCKER", drucker);
            if (eingabevariablen != null)
            {
                p = p.AddParameterList(eingabevariablen);
            }

            if (selektionsvariablen != null)
            {
                p = p.AddParameterList(selektionsvariablen);
            }

            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }

        public async Task<RestResponse> ExecAsync(string name, string drucker, Dictionary<string, dynamic> eingabevariablen = null,
            Dictionary<string, dynamic> selektionsvariablen = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("NAME", name)
                .AddParameter("DRUCKER", drucker);
            if (eingabevariablen != null)
            {
                p = p.AddParameterList(eingabevariablen);
            }

            if (selektionsvariablen != null)
            {
                p = p.AddParameterList(selektionsvariablen);
            }

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }
    }
}
