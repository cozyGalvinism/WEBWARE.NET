using System;
using System.Threading.Tasks;
using RestSharp;
using WEBWARE.NET.Enums;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("STATARTUM", 1)]
    public class StatArtUm : EndpointHelper
    {

        public StatArtUm(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Exec(string artNr, STATARTUMArt art, string vonJahr = "", string bisJahr = "", string vonPeriode = "", string bisPeriode = "", DateTime? datum = null, bool alternativeLagereinheit = false, bool wildcard = false)
        {
            int iArt = (int) art;
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ARTNR", artNr)
                .AddParameter("ART", iArt)
                .AddParameter("VON_JAHR", vonJahr)
                .AddParameter("BIS_JAHR", bisJahr)
                .AddParameter("VON_PERIODE", vonPeriode)
                .AddParameter("BIS_PERIODE", bisPeriode)
                .AddParameter("DATUM", datum?.ToString("dd.MM.yyyy"))
                .AddParameter("ALTERNATIVE_LAGEREINHEIT", alternativeLagereinheit)
                .AddParameter("WILDCARD", wildcard);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }

        public async Task<RestResponse> ExecAsync(string artNr, STATARTUMArt art, string vonJahr = "", string bisJahr = "", string vonPeriode = "", string bisPeriode = "", DateTime? datum = null, bool alternativeLagereinheit = false, bool wildcard = false)
        {
            int iArt = (int)art;
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ARTNR", artNr)
                .AddParameter("ART", iArt)
                .AddParameter("VON_JAHR", vonJahr)
                .AddParameter("BIS_JAHR", bisJahr)
                .AddParameter("VON_PERIODE", vonPeriode)
                .AddParameter("BIS_PERIODE", bisPeriode)
                .AddParameter("DATUM", datum?.ToString("dd.MM.yyyy"))
                .AddParameter("ALTERNATIVE_LAGEREINHEIT", alternativeLagereinheit)
                .AddParameter("WILDCARD", wildcard);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }
    }
}