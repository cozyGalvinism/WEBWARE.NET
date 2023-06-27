using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("GET_RELATION", 1)]
    public class GetRelation : EndpointHelper
    {

        public GetRelation(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Exec(string nr, Dictionary<string, dynamic> parameter = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("NR", nr);
            if (parameter != null) p = p.AddParameterList(parameter);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }

        public async Task<RestResponse> ExecAsync(string nr, Dictionary<string, dynamic> parameter = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("NR", nr);
            if (parameter != null) p = p.AddParameterList(parameter);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }
    }
}