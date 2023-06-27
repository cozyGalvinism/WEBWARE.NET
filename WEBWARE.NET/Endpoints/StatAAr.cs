using System.Threading.Tasks;
using RestSharp;
using WEBWARE.NET.Enums;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("STATAAR", 1)]
    public class StatAAr : EndpointHelper
    {

        public StatAAr(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Exec(string adrNr, string artNr, STATADRArt art, string jahr = "", string vonPeriode = "", string bisPeriode = "")
        {
            int iArt = (int) art;
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr)
                .AddParameter("ARTNR", artNr)
                .AddParameter("ART", iArt)
                .AddParameter("JAHR", jahr)
                .AddParameter("VON_PERIODE", vonPeriode)
                .AddParameter("BIS_PERIODE", bisPeriode);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }

        public async Task<RestResponse> ExecAsync(string adrNr, string artNr, STATADRArt art, string jahr = "", string vonPeriode = "", string bisPeriode = "")
        {
            int iArt = (int)art;
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr)
                .AddParameter("ARTNR", artNr)
                .AddParameter("ART", iArt)
                .AddParameter("JAHR", jahr)
                .AddParameter("VON_PERIODE", vonPeriode)
                .AddParameter("BIS_PERIODE", bisPeriode);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }
    }
}