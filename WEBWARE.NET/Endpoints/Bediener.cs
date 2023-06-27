using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("BEDIENER", 1)]
    public class Bediener : EndpointHelper
    {

        public Bediener(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Get(bool nurAnzahl = false, bool nurGroesse = false, bool ohneLeerfelder = false, string bdNr = "", string vonBdNr = "", string bisBdNr = "", bool mitModulberechtigungen = false)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("NUR_ANZAHL", nurAnzahl)
                .AddParameter("NUR_GROESSE", nurGroesse)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("BDNR", bdNr)
                .AddParameter("VON_BDNR", vonBdNr)
                .AddParameter("BIS_BDNR", bisBdNr)
                .AddParameter("MIT_MODULBERECHTIGUNGEN", mitModulberechtigungen);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> GetAsync(bool nurAnzahl = false, bool nurGroesse = false, bool ohneLeerfelder = false, string bdNr = "", string vonBdNr = "", string bisBdNr = "", bool mitModulberechtigungen = false)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("NUR_ANZAHL", nurAnzahl)
                .AddParameter("NUR_GROESSE", nurGroesse)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("BDNR", bdNr)
                .AddParameter("VON_BDNR", vonBdNr)
                .AddParameter("BIS_BDNR", bisBdNr)
                .AddParameter("MIT_MODULBERECHTIGUNGEN", mitModulberechtigungen);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}