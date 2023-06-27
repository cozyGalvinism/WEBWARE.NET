using System.Threading.Tasks;
using RestSharp;
using WEBWARE.NET.Enums;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("STATLGDAT", 1)]
    public class StatLgDat : EndpointHelper
    {

        public StatLgDat(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Exec(string artNr, STATLGDATArt art, string vonLager, string bisLager = "", bool mitMaterialUmlauf = false, bool alternativeLagereinheit = false, bool mitLagergesamt = false)
        {
            int iArt = (int) art;
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ARTNR", artNr)
                .AddParameter("ART", iArt)
                .AddParameter("VON_LAGER", vonLager)
                .AddParameter("BIS_LAGER", bisLager)
                .AddParameter("MIT_MATERIALUMLAUF", mitMaterialUmlauf)
                .AddParameter("ALTERNATIVE_LAGEREINHEIT", alternativeLagereinheit)
                .AddParameter("MIT_LAGERGESAMT", mitLagergesamt);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }

        public async Task<RestResponse> ExecAsync(string artNr, STATLGDATArt art, string vonLager, string bisLager = "", bool mitMaterialUmlauf = false, bool alternativeLagereinheit = false, bool mitLagergesamt = false)
        {
            int iArt = (int)art;
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ARTNR", artNr)
                .AddParameter("ART", iArt)
                .AddParameter("VON_LAGER", vonLager)
                .AddParameter("BIS_LAGER", bisLager)
                .AddParameter("MIT_MATERIALUMLAUF", mitMaterialUmlauf)
                .AddParameter("ALTERNATIVE_LAGEREINHEIT", alternativeLagereinheit)
                .AddParameter("MIT_LAGERGESAMT", mitLagergesamt);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }
    }
}