using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("MEDIEN", 1)]
    public class Medien : EndpointHelper
    {

        public Medien(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Get(string id)
        {
            return SendEndpointRequest(Method.Put, new EndpointParameters().AddParameter("ID", id).GetParameters(),
                null);
        }

        public async Task<RestResponse> GetAsync(string id)
        {
            return await SendEndpointRequestAsync(Method.Put, new EndpointParameters().AddParameter("ID", id).GetParameters(),
                null);
        }

        public byte[] GetBinary(string id)
        {
            return SendBinaryRequest(Method.Put, new EndpointParameters().AddParameter("ID", id).GetParameters(), null);
        }

        public async Task<byte[]> GetBinaryAsync(string id)
        {
            return await SendBinaryRequestAsync(Method.Put, new EndpointParameters().AddParameter("ID", id).GetParameters(), null);
        }
    }
}