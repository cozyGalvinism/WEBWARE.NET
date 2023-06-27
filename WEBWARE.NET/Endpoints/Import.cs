using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("IMPORT", 1)]
    public class Import : EndpointHelper
    {
        public Import(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Exec(string fileName)
        {
            byte[] file = System.IO.File.ReadAllBytes(fileName);
            return Exec(file, fileName);
        }

        public async Task<RestResponse> ExecAsync(string fileName)
        {
            byte[] file = System.IO.File.ReadAllBytes(fileName);
            return await ExecAsync(file, fileName);
        }

        public RestResponse Exec(byte[] data, string fileName = "import.dta", string importModellNr = "")
        {
            string path = "EXECURL/" + Client.ServicePass + "/IMPORT.EXEC/IMPORTFILE=" + Path.GetFileName(fileName);
            if (importModellNr != "")
            {
                path += "/IMPORTMODELLNR=" + importModellNr;
            }
            
            return Client.SendJsonRequest(Method.Put, path,
                Client.GetHeaders(), data);
        }

        public async Task<RestResponse> ExecAsync(byte[] data, string fileName = "import.dta", string importModellNr = "")
        {
            string path = "EXECURL/" + Client.ServicePass + "/IMPORT.EXEC/IMPORTFILE=" + Path.GetFileName(fileName);
            if (importModellNr != "")
            {
                path += "/IMPORTMODELLNR=" + importModellNr;
            }

            return await Client.SendJsonRequestAsync(Method.Put, path,
                Client.GetHeaders(), data);
        }
    }
}
