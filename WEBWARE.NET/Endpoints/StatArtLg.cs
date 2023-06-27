using System.Threading.Tasks;
using RestSharp;
using WEBWARE.NET.Enums;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("STATARTLG", 1)]
    public class StatArtLg : EndpointHelper
    {

        public StatArtLg(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Exec(string artNr, STATARTLGArt art, string vonLager = "", string bisLager = "", bool alternativeLagereinheit = false, bool wildcard = false, bool lagergesamtIgnorieren = false)
        {
            int iArt = (int) art;
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ARTNR", artNr)
                .AddParameter("ART", iArt)
                .AddParameter("VON_LAGER", vonLager)
                .AddParameter("BIS_LAGER", bisLager)
                .AddParameter("ALTERNATIVE_LAGEREINHEIT", alternativeLagereinheit)
                .AddParameter("WILDCARD", wildcard)
                .AddParameter("LAGERGESAMT_IGNORIEREN", lagergesamtIgnorieren);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }

        public async Task<RestResponse> ExecAsync(string artNr, STATARTLGArt art, string vonLager = "", string bisLager = "", bool alternativeLagereinheit = false, bool wildcard = false, bool lagergesamtIgnorieren = false)
        {
            int iArt = (int)art;
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ARTNR", artNr)
                .AddParameter("ART", iArt)
                .AddParameter("VON_LAGER", vonLager)
                .AddParameter("BIS_LAGER", bisLager)
                .AddParameter("ALTERNATIVE_LAGEREINHEIT", alternativeLagereinheit)
                .AddParameter("WILDCARD", wildcard)
                .AddParameter("LAGERGESAMT_IGNORIEREN", lagergesamtIgnorieren);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }
    }
}