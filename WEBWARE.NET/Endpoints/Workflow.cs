using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("WORKFLOW", 1)]
    public class Workflow : EndpointHelper
    {

        public Workflow(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Exec(string id, Dictionary<string, dynamic> felder = null, string resultVar = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ID", id)
                .AddParameter("RESULT_VAR", resultVar);
            if (felder != null) p = p.AddParameterList(felder);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }

        public async Task<RestResponse> ExecAsync(string id, Dictionary<string, dynamic> felder = null, string resultVar = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ID", id)
                .AddParameter("RESULT_VAR", resultVar);
            if (felder != null) p = p.AddParameterList(felder);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }
    }
}