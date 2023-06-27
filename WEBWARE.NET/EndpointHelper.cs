using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using WEBWARE.NET.Helper;

namespace WEBWARE.NET
{
    public abstract class EndpointHelper
    {
        protected WEBWAREClient Client { get; }

        protected EndpointHelper(WEBWAREClient client)
        {
            Client = client;
        }

        /// <summary>
        /// Sendet eine JSON-Anfrage an den angegebenen Endpunkt am WEBWARE-Server
        /// </summary>
        /// <param name="method">Die zu verwendende Methode</param>
        /// <param name="args">Die Argumente für die auszuführende Funktion oder byte[]-Daten im Falle eines Uploads</param>
        /// <param name="body">Der Funktionskörper</param>
        /// <param name="fnc">Die auszuführende Funktion</param>
        /// <param name="cursor">Cursor-Kennung (oder CREATE, wenn neuer Cursor angelegt werden soll)</param>
        /// <returns>Ein RestSharp-Antwortobjekt</returns>
        protected RestResponse SendEndpointRequest(Method method, dynamic args, Dictionary<string, dynamic> body, string fnc = "")
        {
            if (method != Method.Options && string.IsNullOrEmpty(fnc))
            {
                fnc = Endpoint + "." + Enum.GetName(typeof(Method), method);
            } else if (method != Method.Options && !string.IsNullOrEmpty(fnc))
            {
                if (!fnc.Contains("."))
                {
                    fnc = Endpoint + "." + fnc;
                }
            }
            Dictionary<string, dynamic> function;
            if (body == null)
            {
                body = new Dictionary<string, dynamic>()
                {
                    {
                        "WWSVC_FUNCTION", new Dictionary<string, dynamic>()
                        {
                            {"FUNCTIONNAME", fnc},
                            {"PARAMETER", new List<Dictionary<string, dynamic>>()}
                        }
                    }
                };
                function = body["WWSVC_FUNCTION"] as Dictionary<string, dynamic>;
            }
            else
            {
                if (!body.ContainsKey("WWSVC_FUNCTION")) body["WWSVC_FUNCTION"] = new Dictionary<string, dynamic>();
                function = body["WWSVC_FUNCTION"] as Dictionary<string, dynamic>;
                if (!function.ContainsKey("FUNCTIONNAME")) function["FUNCTIONNAME"] = fnc;
                if (!function.ContainsKey("PARAMETER")) function["PARAMETER"] = new List<Dictionary<string, dynamic>>();
            }
            if (Version >= 0) function["REVISION"] = Version;
            List<Dictionary<string, dynamic>> parameter = function["PARAMETER"] as List<Dictionary<string, dynamic>>;
            if (((args as List<dynamic>) == null || ((List<dynamic>) args).Count <= 0) &&
                ((args as Dictionary<string, dynamic>) == null || ((Dictionary<string, dynamic>) args).Count <= 0))
                return Client.SendJsonRequest(method, "EXECJSON", Client.GetHeaders(ref body), body);
            if ((args as List<dynamic>) != null)
            {
                // Add parameters by position
                List<dynamic> argList = args as List<dynamic>;
                parameter.AddRange(argList.Select(val => new Dictionary<string, dynamic>
                {
                    {"POSITION", argList.IndexOf(val) + 1},
                    {"PCONTENT", val.ToString()}
                }));
            }
            else
            {
                // Add named parameters
                Dictionary<string, dynamic> argHash = args as Dictionary<string, dynamic>;
                parameter.AddRange(argHash.Keys.Select(key => new Dictionary<string, dynamic>
                {
                    {"PNAME", key},
                    {"PCONTENT", argHash[key].ToString()}
                }));
            }

            var headers = Client.GetHeaders(ref body);
            
            return Client.SendJsonRequest(method, "EXECJSON", headers, body);
        }

        protected async Task<RestResponse> SendEndpointRequestAsync(Method method, dynamic args,
            Dictionary<string, dynamic> body, string fnc = "")
        {
            if (method != Method.Options && string.IsNullOrEmpty(fnc))
            {
                fnc = Endpoint + "." + Enum.GetName(typeof(Method), method);
            }
            else if (method != Method.Options && !string.IsNullOrEmpty(fnc))
            {
                if (!fnc.Contains("."))
                {
                    fnc = Endpoint + "." + fnc;
                }
            }
            Dictionary<string, dynamic> function;
            if (body == null)
            {
                body = new Dictionary<string, dynamic>()
                {
                    {
                        "WWSVC_FUNCTION", new Dictionary<string, dynamic>()
                        {
                            {"FUNCTIONNAME", fnc},
                            {"PARAMETER", new List<Dictionary<string, dynamic>>()}
                        }
                    }
                };
                function = body["WWSVC_FUNCTION"] as Dictionary<string, dynamic>;
            }
            else
            {
                if (!body.ContainsKey("WWSVC_FUNCTION")) body["WWSVC_FUNCTION"] = new Dictionary<string, dynamic>();
                function = body["WWSVC_FUNCTION"] as Dictionary<string, dynamic>;
                if (!function.ContainsKey("FUNCTIONNAME")) function["FUNCTIONNAME"] = fnc;
                if (!function.ContainsKey("PARAMETER")) function["PARAMETER"] = new List<Dictionary<string, dynamic>>();
            }
            if (Version >= 0) function["REVISION"] = Version;
            List<Dictionary<string, dynamic>> parameter = function["PARAMETER"] as List<Dictionary<string, dynamic>>;
            if (((args as List<dynamic>) == null || ((List<dynamic>)args).Count <= 0) &&
                ((args as Dictionary<string, dynamic>) == null || ((Dictionary<string, dynamic>)args).Count <= 0))
                return await Client.SendJsonRequestAsync(method, "EXECJSON", Client.GetHeaders(ref body), body);
            if ((args as List<dynamic>) != null)
            {
                // Add parameters by position
                List<dynamic> argList = args as List<dynamic>;
                parameter.AddRange(argList.Select(val => new Dictionary<string, dynamic>
                {
                    {"POSITION", argList.IndexOf(val) + 1},
                    {"PCONTENT", val.ToString()}
                }));
            }
            else
            {
                // Add named parameters
                Dictionary<string, dynamic> argHash = args as Dictionary<string, dynamic>;
                parameter.AddRange(argHash.Keys.Select(key => new Dictionary<string, dynamic>
                {
                    {"PNAME", key},
                    {"PCONTENT", argHash[key].ToString()}
                }));
            }

            var headers = Client.GetHeaders(ref body);

            return await Client.SendJsonRequestAsync(method, "EXECJSON", headers, body);
        }

        /// <summary>
        /// Sendet eine JSON-Anfrage an den angegebenen Endpunkt am WEBWARE-Server
        /// </summary>
        /// <param name="method">Die zu verwendende Methode</param>
        /// <param name="args">Die Argumente für die auszuführende Funktion oder byte[]-Daten im Falle eines Uploads</param>
        /// <param name="body">Der Funktionskörper</param>
        /// <param name="fnc">Die auszuführende Funktion</param>
        /// <returns>Ein byte[] mit Daten</returns>
        protected byte[] SendBinaryRequest(Method method, dynamic args, Dictionary<string, dynamic> body, string fnc = "")
        {
            if (method != Method.Options && string.IsNullOrEmpty(fnc))
            {
                fnc = Endpoint + "." + Enum.GetName(typeof(Method), method);
            } else if (method != Method.Options && !string.IsNullOrEmpty(fnc))
            {
                if (!fnc.Contains("."))
                {
                    fnc = Endpoint + "." + fnc;
                }
            }
            Dictionary<string, dynamic> function;
            if (body == null)
            {
                body = new Dictionary<string, dynamic>()
                {
                    {
                        "WWSVC_FUNCTION", new Dictionary<string, dynamic>()
                        {
                            {"FUNCTIONNAME", fnc},
                            {"PARAMETER", new List<Dictionary<string, dynamic>>()}
                        }
                    }
                };
                function = body["WWSVC_FUNCTION"] as Dictionary<string, dynamic>;
            }
            else
            {
                if (!body.ContainsKey("WWSVC_FUNCTION")) body["WWSVC_FUNCTION"] = new Dictionary<string, dynamic>();
                function = body["WWSVC_FUNCTION"] as Dictionary<string, dynamic>;
                if (!function.ContainsKey("FUNCTIONNAME")) function["FUNCTIONNAME"] = fnc;
                if (!function.ContainsKey("PARAMETER")) function["PARAMETER"] = new List<Dictionary<string, dynamic>>();
            }
            if (Version >= 0) function["REVISION"] = Version;
            List<Dictionary<string, dynamic>> parameter = function["PARAMETER"] as List<Dictionary<string, dynamic>>;
            if (((args as List<dynamic>) == null || ((List<dynamic>) args).Count <= 0) &&
                ((args as Dictionary<string, dynamic>) == null || ((Dictionary<string, dynamic>) args).Count <= 0))
                return Client.SendBinaryDownloadRequest("EXECJSON", Client.GetHeaders(ref body, true));
            if ((args as List<dynamic>) != null)
            {
                // Add parameters by position
                List<dynamic> argList = args as List<dynamic>;
                parameter.AddRange(argList.Select(val => new Dictionary<string, dynamic>
                {
                    {"POSITION", argList.IndexOf(val) + 1},
                    {"PCONTENT", val}
                }));
            }
            else
            {
                // Add named parameters
                Dictionary<string, dynamic> argHash = args as Dictionary<string, dynamic>;
                parameter.AddRange(argHash.Keys.Select(key => new Dictionary<string, dynamic>
                {
                    {"PNAME", key},
                    {"PCONTENT", argHash[key]}
                }));
            }
            
            return Client.SendBinaryDownloadRequest("EXECJSON", Client.GetHeaders(ref body, true));
        }

        protected async Task<byte[]> SendBinaryRequestAsync(Method method, dynamic args, Dictionary<string, dynamic> body, string fnc = "")
        {
            if (method != Method.Options && string.IsNullOrEmpty(fnc))
            {
                fnc = Endpoint + "." + Enum.GetName(typeof(Method), method);
            }
            else if (method != Method.Options && !string.IsNullOrEmpty(fnc))
            {
                if (!fnc.Contains("."))
                {
                    fnc = Endpoint + "." + fnc;
                }
            }
            Dictionary<string, dynamic> function;
            if (body == null)
            {
                body = new Dictionary<string, dynamic>()
                {
                    {
                        "WWSVC_FUNCTION", new Dictionary<string, dynamic>()
                        {
                            {"FUNCTIONNAME", fnc},
                            {"PARAMETER", new List<Dictionary<string, dynamic>>()}
                        }
                    }
                };
                function = body["WWSVC_FUNCTION"] as Dictionary<string, dynamic>;
            }
            else
            {
                if (!body.ContainsKey("WWSVC_FUNCTION")) body["WWSVC_FUNCTION"] = new Dictionary<string, dynamic>();
                function = body["WWSVC_FUNCTION"] as Dictionary<string, dynamic>;
                if (!function.ContainsKey("FUNCTIONNAME")) function["FUNCTIONNAME"] = fnc;
                if (!function.ContainsKey("PARAMETER")) function["PARAMETER"] = new List<Dictionary<string, dynamic>>();
            }
            if (Version >= 0) function["REVISION"] = Version;
            List<Dictionary<string, dynamic>> parameter = function["PARAMETER"] as List<Dictionary<string, dynamic>>;
            if (((args as List<dynamic>) == null || ((List<dynamic>)args).Count <= 0) &&
                ((args as Dictionary<string, dynamic>) == null || ((Dictionary<string, dynamic>)args).Count <= 0))
                return await Client.SendBinaryDownloadRequestAsync("EXECJSON", Client.GetHeaders(ref body, true));
            if ((args as List<dynamic>) != null)
            {
                // Add parameters by position
                List<dynamic> argList = args as List<dynamic>;
                parameter.AddRange(argList.Select(val => new Dictionary<string, dynamic>
                {
                    {"POSITION", argList.IndexOf(val) + 1},
                    {"PCONTENT", val}
                }));
            }
            else
            {
                // Add named parameters
                Dictionary<string, dynamic> argHash = args as Dictionary<string, dynamic>;
                parameter.AddRange(argHash.Keys.Select(key => new Dictionary<string, dynamic>
                {
                    {"PNAME", key},
                    {"PCONTENT", argHash[key]}
                }));
            }

            return await Client.SendBinaryDownloadRequestAsync("EXECJSON", Client.GetHeaders(ref body, true));
        }

        private string Endpoint => GetEndpoint();
        private int Version => GetVersion();

        private string GetEndpoint()
        {
            return ((EndpointInfo)Attribute.GetCustomAttribute(GetType(), typeof(EndpointInfo))).Funktionsname;
        }

        private int GetVersion()
        {
            return ((EndpointInfo) Attribute.GetCustomAttribute(GetType(), typeof(EndpointInfo))).Version;
        }
    }
}
