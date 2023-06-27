using System.Threading.Tasks;
using RestSharp;
using WEBWARE.NET.Enums;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("STATLFA", 1)]
    public class StatLfa : EndpointHelper
    {

        public StatLfa(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Exec(string lfaNr, STATLFAArt art, string jahr = "", string vonPeriode = "", string bisPeriode = "")
        {
            int iArt = (int) art;
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("LFANR", lfaNr)
                .AddParameter("ART", iArt)
                .AddParameter("JAHR", jahr)
                .AddParameter("VON_PERIODE", vonPeriode)
                .AddParameter("BIS_PERIODE", bisPeriode);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }

        public async Task<RestResponse> ExecAsync(string lfaNr, STATLFAArt art, string jahr = "", string vonPeriode = "", string bisPeriode = "")
        {
            int iArt = (int)art;
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("LFANR", lfaNr)
                .AddParameter("ART", iArt)
                .AddParameter("JAHR", jahr)
                .AddParameter("VON_PERIODE", vonPeriode)
                .AddParameter("BIS_PERIODE", bisPeriode);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }
    }
}