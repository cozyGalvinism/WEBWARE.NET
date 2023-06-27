using System.Threading.Tasks;
using RestSharp;
using WEBWARE.NET.Enums;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("STATVTWGR", 1)]
    public class StatVtWgr : EndpointHelper
    {

        public StatVtWgr(WEBWAREClient w) : base(w)
        {
            
        }
        
        public RestResponse Exec(string wgrNr, STATVTWGRArt art, string vtrNr = "", string jahr = "", string vonPeriode = "", string bisPeriode = "")
        {
            int iArt = (int) art;
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("WGRNR", wgrNr)
                .AddParameter("ART", iArt)
                .AddParameter("VTRNR", vtrNr)
                .AddParameter("JAHR", jahr)
                .AddParameter("VON_PERIODE", vonPeriode)
                .AddParameter("BIS_PERIODE", bisPeriode);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }

        public async Task<RestResponse> ExecAsync(string wgrNr, STATVTWGRArt art, string vtrNr = "", string jahr = "", string vonPeriode = "", string bisPeriode = "")
        {
            int iArt = (int)art;
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("WGRNR", wgrNr)
                .AddParameter("ART", iArt)
                .AddParameter("VTRNR", vtrNr)
                .AddParameter("JAHR", jahr)
                .AddParameter("VON_PERIODE", vonPeriode)
                .AddParameter("BIS_PERIODE", bisPeriode);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }
    }
}