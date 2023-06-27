using System;
using System.Threading.Tasks;
using RestSharp;
using WEBWARE.NET.Enums;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("DUBLETTENPRUEFUNG", 1)]
    public class Dublettenpruefung : EndpointHelper
    {

        public Dublettenpruefung(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Exec(string adrNr, string schwellwert = "", string maxDubletten = "", Prüfbereich pruefbereich = Prüfbereich.KOMPLETT)
        {
            string bereich = Enum.GetName(typeof(Prüfbereich), pruefbereich);
            
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr)
                .AddParameter("SCHWELLWERT", schwellwert)
                .AddParameter("MAX_DUBLETTEN", maxDubletten)
                .AddParameter("PRUEFBEREICH", bereich);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }

        public async Task<RestResponse> ExecAsync(string adrNr, string schwellwert = "", string maxDubletten = "", Prüfbereich pruefbereich = Prüfbereich.KOMPLETT)
        {
            string bereich = Enum.GetName(typeof(Prüfbereich), pruefbereich);

            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("ADRNR", adrNr)
                .AddParameter("SCHWELLWERT", schwellwert)
                .AddParameter("MAX_DUBLETTEN", maxDubletten)
                .AddParameter("PRUEFBEREICH", bereich);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }

        public RestResponse Exec(string vorname = "", string nachname = "", string namezusatz = "", string strasse = "", string plz = "", string ort = "", string telefonnummer = "", string mobilnummer = "", string emailadresse = "", string schwellwert = "", string maxDubletten = "", Prüfbereich pruefbereich = Prüfbereich.KOMPLETT)
        {
            string bereich = Enum.GetName(typeof(Prüfbereich), pruefbereich);
            
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("VORNAME", vorname)
                .AddParameter("NACHNAME", nachname)
                .AddParameter("NAMEZUSATZ", namezusatz)
                .AddParameter("STRASSE", strasse)
                .AddParameter("PLZ", plz)
                .AddParameter("ORT", ort)
                .AddParameter("TELEFONNUMMER", telefonnummer)
                .AddParameter("MOBILNUMMER", mobilnummer)
                .AddParameter("EMAILADRESSE", emailadresse)
                .AddParameter("SCHWELLWERT", schwellwert)
                .AddParameter("MAX_DUBLETTEN", maxDubletten)
                .AddParameter("PRUEFBEREICH", bereich);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }

        public async Task<RestResponse> ExecAsync(string vorname = "", string nachname = "", string namezusatz = "", string strasse = "", string plz = "", string ort = "", string telefonnummer = "", string mobilnummer = "", string emailadresse = "", string schwellwert = "", string maxDubletten = "", Prüfbereich pruefbereich = Prüfbereich.KOMPLETT)
        {
            string bereich = Enum.GetName(typeof(Prüfbereich), pruefbereich);

            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("VORNAME", vorname)
                .AddParameter("NACHNAME", nachname)
                .AddParameter("NAMEZUSATZ", namezusatz)
                .AddParameter("STRASSE", strasse)
                .AddParameter("PLZ", plz)
                .AddParameter("ORT", ort)
                .AddParameter("TELEFONNUMMER", telefonnummer)
                .AddParameter("MOBILNUMMER", mobilnummer)
                .AddParameter("EMAILADRESSE", emailadresse)
                .AddParameter("SCHWELLWERT", schwellwert)
                .AddParameter("MAX_DUBLETTEN", maxDubletten)
                .AddParameter("PRUEFBEREICH", bereich);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null, fnc: "EXEC");
        }
    }
}