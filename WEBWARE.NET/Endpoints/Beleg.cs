using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("BELEG", 1)]
    public class Beleg : EndpointHelper
    {

        public Beleg(WEBWAREClient w) : base(w)
        {

        }

        public RestResponse Delete(string belNdx, bool keineArchivierung = false)
        {
            return SendEndpointRequest(Method.Delete,
                new EndpointParameters().AddParameter("BELNDX", belNdx).AddParameter("KEINE_ARCHIVIERUNG", keineArchivierung).GetParameters(), null);
        }

        public async Task<RestResponse> DeleteAsync(string belNdx, bool keineArchivierung = false)
        {
            return await SendEndpointRequestAsync(Method.Delete,
                new EndpointParameters().AddParameter("BELNDX", belNdx).AddParameter("KEINE_ARCHIVIERUNG", keineArchivierung).GetParameters(), null);
        }

        public RestResponse Insert(string belArt, string adrNr, Dictionary<string, dynamic> felder = null, Dictionary<string, string> langtexte = null, List<Dictionary<string, dynamic>> positionsDaten = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("BEL_2_1", belArt)
                .AddParameter("BEL_11_8", adrNr);
            if (felder != null) p = p.AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);

            Dictionary<string, dynamic> body = null;
            if (positionsDaten != null)
            {
                body = new Dictionary<string, dynamic>
                {
                    ["WWSVC_FUNCTION"] = new Dictionary<string, dynamic>
                    {
                        ["POSDATEN"] = positionsDaten.Select(posFelder =>
                        {
                            int posCount = 1;
                            var retPosFeld = new Dictionary<string, dynamic>();
                            retPosFeld["PARAMETER"] = posFelder.Select(pF =>
                            {
                                var retPosF = new Dictionary<string, dynamic>();
                                retPosF["PCONTENT"] = pF.Value;
                                retPosF["POSITION"] = posCount.ToString();
                                retPosF["PNAME"] = pF.Key;
                                posCount++;
                                return retPosF;
                            }).ToList();
                            return retPosFeld;
                        }).ToList()
                    }

                };
            }

            return SendEndpointRequest(Method.Post, p.GetParameters(), body, fnc: "INSERT");
        }

        public async Task<RestResponse> InsertAsync(string belArt, string adrNr, Dictionary<string, dynamic> felder = null, Dictionary<string, string> langtexte = null, List<Dictionary<string, dynamic>> positionsDaten = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("BEL_2_1", belArt)
                .AddParameter("BEL_11_8", adrNr);
            if (felder != null) p = p.AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);

            Dictionary<string, dynamic> body = null;
            if (positionsDaten != null)
            {
                body = new Dictionary<string, dynamic>
                {
                    ["WWSVC_FUNCTION"] = new Dictionary<string, dynamic>
                    {
                        ["POSDATEN"] = positionsDaten.Select(posFelder =>
                        {
                            int posCount = 1;
                            var retPosFeld = new Dictionary<string, dynamic>();
                            retPosFeld["PARAMETER"] = posFelder.Select(pF =>
                            {
                                var retPosF = new Dictionary<string, dynamic>();
                                retPosF["PCONTENT"] = pF.Value;
                                retPosF["POSITION"] = posCount.ToString();
                                retPosF["PNAME"] = pF.Key;
                                posCount++;
                                return retPosF;
                            }).ToList();
                            return retPosFeld;
                        }).ToList()
                    }

                };
            }

            return await SendEndpointRequestAsync(Method.Post, p.GetParameters(), body, fnc: "INSERT");
        }

        public RestResponse Put(string belNdx, Dictionary<string, dynamic> felder, bool berechneSummen = false, bool keineVerbuchung = false, string kalkndx = "", Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("BELNDX", belNdx)
                .AddParameter("BERECHNE_SUMMEN", berechneSummen)
                .AddParameter("KEINE_VERBUCHUNG", keineVerbuchung)
                .AddParameter("KALKNDX", kalkndx)
                .AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> PutAsync(string belNdx, Dictionary<string, dynamic> felder, bool berechneSummen = false, bool keineVerbuchung = false, string kalkndx = "", Dictionary<string, string> langtexte = null)
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("BELNDX", belNdx)
                .AddParameter("BERECHNE_SUMMEN", berechneSummen)
                .AddParameter("KEINE_VERBUCHUNG", keineVerbuchung)
                .AddParameter("KALKNDX", kalkndx)
                .AddParameterList(felder);
            if (langtexte != null) p = p.AddParameterList(langtexte);
            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }

        public RestResponse Get(
            string felder = "",
            bool nurAnzahl = false,
            bool nurGroesse = false,
            string sucheVolltext = "",
            string freiselekt = "",
            string freiselektKey = "",
            string freiselektVonIndex = "",
            string freiselektBisIndex = "",
            string freisort = "",
            string mitLangtext = "",
            bool ohneLeerfelder = false,
            string vonAdrNr = "",
            string bisAdrNr = "",
            string belNdx = "",
            string vonBelNdx = "",
            string bisBelNdx = "",
            string jahr = "",
            string vonJahr = "",
            string bisJahr = "",
            string belArt = "",
            string belNr = "",
            string vonBelNr = "",
            string bisBelNr = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("FELDER", felder)
                .AddParameter("NUR_ANZAHL", nurAnzahl)
                .AddParameter("NUR_GROESSE", nurGroesse)
                .AddParameter("SUCHE_VOLLTEXT", sucheVolltext)
                .AddParameter("FREISELEKT", freiselekt)
                .AddParameter("FREISELEKT_KEY", freiselektKey)
                .AddParameter("FREISELEKT_VON_INDEX", freiselektVonIndex)
                .AddParameter("FREISELEKT_BIS_INDEX", freiselektBisIndex)
                .AddParameter("FREISORT", freisort)
                .AddParameter("MIT_LANGTEXT", mitLangtext)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("VON_ADRNR", vonAdrNr)
                .AddParameter("BIS_ADRNR", bisAdrNr)
                .AddParameter("BELNDX", belNdx)
                .AddParameter("VON_BELNDX", vonBelNdx)
                .AddParameter("BIS_BELNDX", bisBelNdx)
                .AddParameter("JAHR", jahr)
                .AddParameter("VON_JAHR", vonJahr)
                .AddParameter("BIS_JAHR", bisJahr)
                .AddParameter("BELART", belArt)
                .AddParameter("BELNR", belNr)
                .AddParameter("VON_BELNR", vonBelNr)
                .AddParameter("BIS_BELNR", bisBelNr);
            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> GetAsync(
            string felder = "",
            bool nurAnzahl = false,
            bool nurGroesse = false,
            string sucheVolltext = "",
            string freiselekt = "",
            string freiselektKey = "",
            string freiselektVonIndex = "",
            string freiselektBisIndex = "",
            string freisort = "",
            string mitLangtext = "",
            bool ohneLeerfelder = false,
            string vonAdrNr = "",
            string bisAdrNr = "",
            string belNdx = "",
            string vonBelNdx = "",
            string bisBelNdx = "",
            string jahr = "",
            string vonJahr = "",
            string bisJahr = "",
            string belArt = "",
            string belNr = "",
            string vonBelNr = "",
            string bisBelNr = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("FELDER", felder)
                .AddParameter("NUR_ANZAHL", nurAnzahl)
                .AddParameter("NUR_GROESSE", nurGroesse)
                .AddParameter("SUCHE_VOLLTEXT", sucheVolltext)
                .AddParameter("FREISELEKT", freiselekt)
                .AddParameter("FREISELEKT_KEY", freiselektKey)
                .AddParameter("FREISELEKT_VON_INDEX", freiselektVonIndex)
                .AddParameter("FREISELEKT_BIS_INDEX", freiselektBisIndex)
                .AddParameter("FREISORT", freisort)
                .AddParameter("MIT_LANGTEXT", mitLangtext)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("VON_ADRNR", vonAdrNr)
                .AddParameter("BIS_ADRNR", bisAdrNr)
                .AddParameter("BELNDX", belNdx)
                .AddParameter("VON_BELNDX", vonBelNdx)
                .AddParameter("BIS_BELNDX", bisBelNdx)
                .AddParameter("JAHR", jahr)
                .AddParameter("VON_JAHR", vonJahr)
                .AddParameter("BIS_JAHR", bisJahr)
                .AddParameter("BELART", belArt)
                .AddParameter("BELNR", belNr)
                .AddParameter("VON_BELNR", vonBelNr)
                .AddParameter("BIS_BELNR", bisBelNr);
            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}
