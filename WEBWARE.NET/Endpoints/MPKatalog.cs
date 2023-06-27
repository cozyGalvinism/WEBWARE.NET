using System.Threading.Tasks;
using RestSharp;

namespace WEBWARE.NET.Endpoints
{
    [EndpointInfo("MPKATALOG", 1)]
    public class MPKatalog : EndpointHelper
    {

        public MPKatalog(WEBWAREClient w) : base(w)
        {
            
        }

        public RestResponse Get(
            string felder = "",
            bool nurAnzahl = false,
            bool nurGroesse = false,
            string freiselekt = "",
            bool ohneLeerfelder = false,
            string katalog = "",
            string vonKatalog = "",
            string bisKatalog = "",
            bool mitKategorien = false,
            string kategorieFelder = "",
            string mitKategorienLangtext = "",
            bool mitArtikel = false,
            string artikelFelder = "",
            bool mitLagerbestand = false,
            string lager = "",
            string vonLager = "",
            string bisLager = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("FELDER", felder)
                .AddParameter("NUR_ANZAHL", nurAnzahl)
                .AddParameter("NUR_GROESSE", nurGroesse)
                .AddParameter("FREISELEKT", freiselekt)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("KATALOG", katalog)
                .AddParameter("VON_KATALOG", vonKatalog)
                .AddParameter("BIS_KATALOG", bisKatalog)
                .AddParameter("MIT_KATEGORIEN", mitKategorien)
                .AddParameter("KATEGORIE_FELDER", kategorieFelder)
                .AddParameter("MIT_KATEGORIEN_LANGTEXT", mitKategorienLangtext)
                .AddParameter("MIT_ARTIKEL", mitArtikel)
                .AddParameter("ARTIKEL_FELDER", artikelFelder)
                .AddParameter("MIT_LAGERBESTAND", mitLagerbestand)
                .AddParameter("LAGER", lager)
                .AddParameter("VON_LAGER", vonLager)
                .AddParameter("BIS_LAGER", bisLager);

            return SendEndpointRequest(Method.Put, p.GetParameters(), null);
        }

        public async Task<RestResponse> GetAsync(
            string felder = "",
            bool nurAnzahl = false,
            bool nurGroesse = false,
            string freiselekt = "",
            bool ohneLeerfelder = false,
            string katalog = "",
            string vonKatalog = "",
            string bisKatalog = "",
            bool mitKategorien = false,
            string kategorieFelder = "",
            string mitKategorienLangtext = "",
            bool mitArtikel = false,
            string artikelFelder = "",
            bool mitLagerbestand = false,
            string lager = "",
            string vonLager = "",
            string bisLager = "")
        {
            EndpointParameters p = new EndpointParameters();
            p = p.AddParameter("FELDER", felder)
                .AddParameter("NUR_ANZAHL", nurAnzahl)
                .AddParameter("NUR_GROESSE", nurGroesse)
                .AddParameter("FREISELEKT", freiselekt)
                .AddParameter("OHNE_LEERFELDER", ohneLeerfelder)
                .AddParameter("KATALOG", katalog)
                .AddParameter("VON_KATALOG", vonKatalog)
                .AddParameter("BIS_KATALOG", bisKatalog)
                .AddParameter("MIT_KATEGORIEN", mitKategorien)
                .AddParameter("KATEGORIE_FELDER", kategorieFelder)
                .AddParameter("MIT_KATEGORIEN_LANGTEXT", mitKategorienLangtext)
                .AddParameter("MIT_ARTIKEL", mitArtikel)
                .AddParameter("ARTIKEL_FELDER", artikelFelder)
                .AddParameter("MIT_LAGERBESTAND", mitLagerbestand)
                .AddParameter("LAGER", lager)
                .AddParameter("VON_LAGER", vonLager)
                .AddParameter("BIS_LAGER", bisLager);

            return await SendEndpointRequestAsync(Method.Put, p.GetParameters(), null);
        }
    }
}