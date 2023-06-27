using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using WEBWARE.NET.Helper;
using WEBWARE.NET.Shared;

namespace WEBWARE.NET
{
    public class WEBWAREClient
    {
        public string HerstellerHash { get; set; }
        public string AnwendungsHash { get; set; }
        public string Secret { get; set; }
        public int Revision { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string WWSVCPfad { get; set; }
        public int CurrentRequestId { get; set; }
        public string? ServicePass { get; set; }
        public string? AppId { get; set; }
        public int ResultMaxLines { get; set; }
        public Cursor? Cursor { get; set; }

        public int Timeout { get; set; } = 10000;

        public RestClient RawClient => _rc;

        private RestClient _rc;
        public RestResponse? LastResponse { get; set; }

        public WEBWAREClient(string herstellerHash, string anwendungsHash, string secret, int revision, string host,
            int port, string wwsvcPfad)
        {
            HerstellerHash = herstellerHash;
            AnwendungsHash = anwendungsHash;
            Secret = secret;
            Revision = revision;
            Host = host;
            Port = port;
            WWSVCPfad = wwsvcPfad;
            ResultMaxLines = 100000;

            UriBuilder builder = new UriBuilder();

            builder.Scheme = "https";
            builder.Host = Host;
            builder.Port = Port;
            builder.Path = WWSVCPfad;

            _rc = new RestClient(builder.Uri, configureRestClient: client => {
                client.UserAgent = "WEBWARE.NET Client v1.0";
            }, configureSerialization: serializer => serializer.UseNewtonsoftJson());
        }

        /// <summary>
        /// Registriert den Client an der WEBWARE
        /// </summary>
        /// <returns>true, falls die Registrierung erfolgreich verlief</returns>
        public bool Register()
        {
            var res = SendJsonRequest(Method.Get, string.Join("/", new string[]
            {
                "WWSERVICE",
                "REGISTER",
                HerstellerHash,
                AnwendungsHash,
                Secret,
                Revision.ToString()
            }), GetHeaders()!, null);
            LastResponse = res;
            if (res.StatusCode != HttpStatusCode.Accepted && res.StatusCode != HttpStatusCode.OK) return false;
            if (res.StatusCode == HttpStatusCode.Accepted) return true;
            if (res.Content == null) return false;
            JObject? result = JObject.Parse(res.Content)["SERVICEPASS"] as JObject;
            if (result == null) return false;
            if (result["PASSID"] == null || result["APPID"] == null) return false;
            ServicePass = result["PASSID"]?.ToString();
            AppId = result["APPID"]?.ToString();
            return true;
        }

        public async Task<bool> RegisterAsync()
        {
            var res = await SendJsonRequestAsync(Method.Get, string.Join("/", new string[]
            {
                "WWSERVICE",
                "REGISTER",
                HerstellerHash,
                AnwendungsHash,
                Secret,
                Revision.ToString()
            }), GetHeaders(), null);
            LastResponse = res;
            if (res.StatusCode != HttpStatusCode.Accepted && res.StatusCode != HttpStatusCode.OK) return false;
            if (res.StatusCode == HttpStatusCode.Accepted) return true;
            if (res.Content == null) return false;
            JObject? result = JObject.Parse(res.Content)["SERVICEPASS"] as JObject;
            if (result == null) return false;
            if (result["PASSID"] == null || result["APPID"] == null) return false;
            ServicePass = result["PASSID"]?.ToString();
            AppId = result["APPID"]?.ToString();
            return true;
        }

        /// <summary>
        /// Validiert den ServicePass, welcher momentan in Benutzung ist
        /// </summary>
        /// <returns>true, wenn der ServicePass valide ist</returns>
        public bool Validate()
        {
            if (ServicePass == null) return false;
            var res = SendJsonRequest(Method.Get, string.Join("/", new string[]
            {
                "WWSERVICE",
                "VALIDATE",
                ServicePass
            }), GetHeaders(), null);
            LastResponse = res;
            return (ServicePass != null) &&
                   res.StatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> ValidateAsync()
        {
            if (ServicePass == null) return false;
            var res = await SendJsonRequestAsync(Method.Get, string.Join("/", new string[]
                {
                    "WWSERVICE",
                    "VALIDATE",
                    ServicePass
                }), GetHeaders(), null);
            LastResponse = res;
            return (ServicePass != null) &&
                   res.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Sendet eine JSON-Anfrage zum WEBWARE-Server
        /// </summary>
        /// <param name="method">Welche Methode soll verwendet werden (WEBWARE-GET-Funktionen müssen als Method.Put gesender werden!)</param>
        /// <param name="path">Pfad der Anfrage</param>
        /// <param name="headers">Header der Anfrage</param>
        /// <param name="body">Body als byte[] oder Dictionary&lt;string, dynamic&gt;</param>
        /// <param name="filename"></param>
        /// <param name="mime">Der MIME-Typ, falls eine Datei übergeben wird</param>
        /// <returns>Ein RestSharp-Antwotobjekt</returns>
        public RestResponse? SendJsonRequest(Method method, string path, Dictionary<string, string> headers,
            dynamic? body, string filename = "import.dta", string mime = "application/dta")
        {
            if (body != null && (body as byte[]) == null && (body as Dictionary<string, dynamic>) == null)
                throw new Exception("Body must be of type byte[] or Dictionary<string, dynamic>!");
            if (body != null && method == Method.Get) method = Method.Put;
            var request = new RestRequest(path, method);
            headers.Each(h => request.AddHeader(h.Key, h.Value));
            if (body != null)
            {
                if (body is byte[] bytes)
                {
                    request.AddParameter(filename, bytes, ParameterType.RequestBody);
                }
                else if (body is Dictionary<string, dynamic>)
                {
                    string? json = JsonConvert.SerializeObject(body);
                    request.AddJsonBody(json);
                }
            }
            
            var res = _rc.Execute(request);
            if (res == null) throw new Exception("No response received!");
            LastResponse = res;

            if(Cursor != null && !Cursor.Closed)
            {
                var cookie = res.Cookies?.FirstOrDefault(c => c.Name == "WWSVC-CURSOR");
                if(cookie != null)
                {
                    Cursor.Cursorkennung = cookie.Value;
                } else
                {
                    // Im Header schauen
                    var header = res.Headers?.FirstOrDefault(h => h.Name == "WWSVC-CURSOR");
                    if(header != null && header.Value != null)
                    {
                        Cursor.Cursorkennung = header.Value.ToString()!;
                    }else
                    {
                        throw new Exception("Keine Cursor-Kennung erhalten!");
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Sendet eine asynchrone JSON-Anfrage zum WEBWARE-Server (verwendet nicht serverseitige Async-Features!)
        /// </summary>
        /// <param name="method"></param>
        /// <param name="path"></param>
        /// <param name="headers"></param>
        /// <param name="body"></param>
        /// <param name="filename"></param>
        /// <param name="mime"></param>
        /// <returns></returns>
        public async Task<RestResponse?> SendJsonRequestAsync(Method method, string path, Dictionary<string, string> headers,
            dynamic? body, string filename = "import.dta", string mime = "application/dta")
        {
            if (body != null && (body as byte[]) == null && (body as Dictionary<string, dynamic>) == null)
                throw new Exception("Body must be of type byte[] or Dictionary<string, dynamic>!");
            if (body != null && method == Method.Get) method = Method.Put;
            var request = new RestRequest(path, method);
            headers.Each(h => request.AddHeader(h.Key, h.Value));
            if (body != null)
            {
                if (body is byte[] bytes)
                {
                    request.AddParameter(filename, bytes, ParameterType.RequestBody);
                }
                else if (body is Dictionary<string, dynamic>)
                {
                    string? json = JsonConvert.SerializeObject(body);
                    request.AddJsonBody(json);
                }
            }

            var res = await _rc.ExecuteAsync(request).ConfigureAwait(false);
            if (res == null) throw new Exception("No response received!");
            LastResponse = res;

            if (Cursor != null && !Cursor.Closed)
            {
                var cookie = res.Cookies?.FirstOrDefault(c => c.Name == "WWSVC-CURSOR");
                if (cookie != null)
                {
                    Cursor.Cursorkennung = cookie.Value;
                }
                else
                {
                    // Im Header schauen
                    var header = res.Headers?.FirstOrDefault(h => h.Name == "WWSVC-CURSOR");
                    if (header != null && header.Value != null)
                    {
                        Cursor.Cursorkennung = header.Value.ToString()!;
                    }
                    else
                    {
                        throw new Exception("Keine Cursor-Kennung erhalten!");
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Sendet eine Anfrage zum Download von einer Datei
        ///
        /// Warnung: Die Datei wird im RAM abgelegt!
        /// </summary>
        /// <param name="path">WWSVC-Funktions-Pfad</param>
        /// <param name="headers">Header als Dictionary</param>
        /// <returns>Ein byte[] mit den heruntergeladenen Daten</returns>
        public byte[]? SendBinaryDownloadRequest(string path, Dictionary<string, string> headers)
        {
            var request = new RestRequest(path, Method.Get);
            headers.Each(h => request.AddHeader(h.Key, h.Value));
            byte[]? res = _rc.DownloadData(request);
            return res;
        }

        public async Task<byte[]?> SendBinaryDownloadRequestAsync(string path, Dictionary<string, string> headers)
        {
            var request = new RestRequest(path, Method.Get);
            headers.Each(h => request.AddHeader(h.Key, h.Value));
            var res = await _rc.ExecuteAsync(request).ConfigureAwait(false);
            return res.RawBytes;
        }

        /// <summary>
        /// Sendet eine Anfrage zum Download einer Datei direkt auf die Festplatte
        /// </summary>
        /// <param name="path">WWSVC-Funktions-Pfad</param>
        /// <param name="fsPath">Pfad auf dem Dateisystem</param>
        /// <param name="headers">Header als Dictionary</param>
        public RestResponse? SendDownloadRequest(string path, string fsPath, Dictionary<string, string> headers)
        {
            var request = new RestRequest(path, Method.Get);
            headers.Each(h => request.AddHeader(h.Key, h.Value));
            RestResponse res;
            using (var writer = File.Create(fsPath))
            {
                request.ResponseWriter = (responseStream) => {
                    responseStream.CopyTo(writer);
                    return writer;
                };
                res = _rc.Execute(request);
            }
            return res;
        }

        public async Task<RestResponse?> SendDownloadRequestAsync(string path, string fsPath, Dictionary<string, string> headers)
        {
            var request = new RestRequest(path, Method.Get);
            headers.Each(h => request.AddHeader(h.Key, h.Value));
            RestResponse res;
            using (var writer = File.Create(fsPath))
            {
                request.ResponseWriter = (responseStream) => {
                    responseStream.CopyTo(writer);
                    return writer;
                };
                res = await _rc.ExecuteAsync(request).ConfigureAwait(false);
            }
            return res;
        }

        /// <summary>
        /// Deregistriert den ServicePass von der WEBWARE
        /// </summary>
        /// <returns>true, wenn der ServicePass erfolgreich deregistriert wurde</returns>
        public bool Deregister()
        {
            if (ServicePass == null) return true;
            RestResponse? deregisterResponse = SendJsonRequest(Method.Get, string.Join("/", new string[]
                {
                    "WWSERVICE",
                    "DEREGISTER",
                    ServicePass
                }), GetHeaders(), null);
            if (deregisterResponse != null && deregisterResponse.StatusCode !=
                HttpStatusCode.OK) return false;
            ServicePass = null;
            AppId = null;
            return true;
        }

        public async Task<bool> DeregisterAsync()
        {
            if (ServicePass == null) return true;


            var res = await SendJsonRequestAsync(Method.Get, string.Join("/", new string[]
                {
                    "WWSERVICE",
                    "DEREGISTER",
                    ServicePass
                }), GetHeaders(), null);
            if (res != null && res.StatusCode != HttpStatusCode.OK) return false;
            ServicePass = null;
            AppId = null;
            return true;
        }

        /// <summary>
        /// Generiert die benötigten Headers für eine Abfrage des WEBWARE-Servers
        ///
        /// Zählt die RequestID hoch!
        /// </summary>
        /// <param name="bin">true, falls die Serverantwort als Binärdaten geladen werden sollen</param>
        /// <returns>Ein Dictionary&lt;string, string&gt; mit den generierten Headern</returns>
        public Dictionary<string, string>? GetHeaders(bool bin = false)
        {
            if (AppId == null) return null;

            AppHash h = AppHash.GenerateAppHash(CurrentRequestId, AppId);
            CurrentRequestId = h.NewRequestId;
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                ["WWSVC-REQID"] = CurrentRequestId.ToString(),
                ["WWSVC-TS"] = h.DateFormatted,
                ["WWSVC-HASH"] = h.Hash,
                ["WWSVC-EXECUTE-MODE"] = "SYNCHRON",
                ["WWSVC-ACCEPT-RESULT-MAX-LINES"] = ResultMaxLines.ToString()
            };
            if (bin)
            {
                headers["WWSVC-ACCEPT-RESULT-TYPE"] = "BIN";
            }
            else
            {
                headers["WWSVC-ACCEPT-RESULT-TYPE"] = "JSON";
            }
            if (Cursor != null && !Cursor.Closed)
            {
                // Cursor-Header setzen
                headers["WWSVC-ACCEPT-RESULT-MAX-LINES"] = Cursor.ResultMaxLines;
                headers["WWSVC-CURSOR"] = Cursor.Cursorkennung;
            }
            return headers;
        }

        /// <summary>
        /// Generiert die benötigten Headers für eine Abfrage des WEBWARE-Servers mit einem vordefinierten Body
        ///
        /// Zählt die RequestID hoch!
        /// </summary>
        /// <param name="body">Der vordefinierte Body</param>
        /// <param name="bin">true, falls die Serverantwort als Binärdaten geladen werden sollen</param>
        /// <returns>Ein Dictionary&lt;string, string&gt; mit den generierten Headern</returns>
        public Dictionary<string, string>? GetHeaders(ref Dictionary<string, dynamic> body, bool bin = false)
        {
            if (ServicePass == null) return null;

            var headers = GetHeaders(bin);
            if (headers == null) return null;
            if (!body.ContainsKey("WWSVC_PASSINFO")) body["WWSVC_PASSINFO"] = new Dictionary<string, dynamic>();
            Dictionary<string, dynamic> passInfo = (body["WWSVC_PASSINFO"] as Dictionary<string, dynamic>)!;
            passInfo["SERVICEPASS"] = ServicePass;
            passInfo["APPHASH"] = headers["WWSVC-HASH"];
            passInfo["TIMESTAMP"] = headers["WWSVC-TS"];
            passInfo["REQUESTID"] = CurrentRequestId;
            passInfo["EXECUTE_MODE"] = "SYNCHRON";
            return headers;
        }
    }
}