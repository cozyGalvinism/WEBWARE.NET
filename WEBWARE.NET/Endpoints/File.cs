using System.IO;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("FILE", 1)]
    public class File : EndpointHelper
    {
        public File(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Put(string fsPfad, string pfad = "", bool ueberschreiben = false)
        {
            byte[] data = System.IO.File.ReadAllBytes(fsPfad);
            return Put(data, pfad, ueberschreiben);
        }

        public async Task<RestResponse> PutAsync(string fsPfad, string pfad = "", bool ueberschreiben = false)
        {
            byte[] data = System.IO.File.ReadAllBytes(fsPfad);
            return await PutAsync(data, pfad, ueberschreiben);
        }

        public RestResponse Put(byte[] data, string pfad = "", bool ueberschreiben = false)
        {
            string path = "EXECURL/" + Client.ServicePass + "/FILE.PUT/PFAD=" + pfad + $"/UEBERSCHREIBEN={(ueberschreiben ? 1 : 0)}";

            return Client.SendJsonRequest(Method.Put, path,
                Client.GetHeaders(), data);
        }

        public async Task<RestResponse> PutAsync(byte[] data, string pfad = "", bool ueberschreiben = false)
        {
            string path = "EXECURL/" + Client.ServicePass + "/FILE.PUT/PFAD=" + pfad + $"/UEBERSCHREIBEN={(ueberschreiben ? 1 : 0)}";

            return await Client.SendJsonRequestAsync(Method.Put, path,
                Client.GetHeaders(), data);
        }

        public RestResponse Get(string pfad)
        {
            return SendEndpointRequest(Method.Put, new EndpointParameters().AddParameter("PFAD", pfad).GetParameters(),
                null);
        }

        public async Task<RestResponse> GetAsync(string pfad)
        {
            return await SendEndpointRequestAsync(Method.Put, new EndpointParameters().AddParameter("PFAD", pfad).GetParameters(),
                null);
        }

        public byte[] GetBinary(string pfad)
        {
            return SendBinaryRequest(Method.Put, new EndpointParameters().AddParameter("PFAD", pfad).GetParameters(), null);
        }

        public async Task<byte[]> GetBinaryAsync(string pfad)
        {
            return await SendBinaryRequestAsync(Method.Put, new EndpointParameters().AddParameter("PFAD", pfad).GetParameters(), null);
        }
    }
}