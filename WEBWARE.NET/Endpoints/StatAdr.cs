using System.Threading.Tasks;
using RestSharp;
using WEBWARE.NET.Enums;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("STATADR", 1)]
    public class StatAdr : EndpointHelper
    {

        public StatAdr(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Exec(string adrNr, STATADRArt art, int belegArt, string jahr = "", string vonPeriode = "", string bisPeriode = "")
        {
            int iArt = (int) art;
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr)
                .AddParameter("ART", iArt)
                .AddParameter("BELEGART", belegArt)
                .AddParameter("JAHR", jahr)
                .AddParameter("VON_PERIODE", vonPeriode)
                .AddParameter("BIS_PERIODE", bisPeriode);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }

        public async Task<RestResponse> ExecAsync(string adrNr, STATADRArt art, int belegArt, string jahr = "", string vonPeriode = "", string bisPeriode = "")
        {
            int iArt = (int)art;
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr)
                .AddParameter("ART", iArt)
                .AddParameter("BELEGART", belegArt)
                .AddParameter("JAHR", jahr)
                .AddParameter("VON_PERIODE", vonPeriode)
                .AddParameter("BIS_PERIODE", bisPeriode);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }
    }
}