using CoreWebApi.Models;
using HtmlAgilityPack;
using System.Globalization;

namespace CoreWebApi.Repositories;

public class Dol2RealRepository : IDol2RealRepository
{
    public Response _response;

    public Dol2RealRepository()
    {
        _response = new Response();
    }

    public async Task<Response> GetDol2Real()
    {
        try
        {
            var html = @"https://pt.exchange-rates.org/converter/USD/BRL/1";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            string cssClass = "single-conversions";
            var elements = htmlDoc.DocumentNode.SelectNodes($"//div[contains(@class, '{cssClass}')]//span");
            var dol2RealSplited = elements.Count > 0 ? elements[0].InnerHtml.Split("=") : null;
            var dol2RealFormated = dol2RealSplited[1].Split(" ")[1].Replace(",", ".");
            var dol2RealParsed = float.Parse(dol2RealFormated, CultureInfo.InvariantCulture.NumberFormat);

            Dol2Real dol2Real = new Dol2Real
            {
                    BRL = dol2RealParsed
            };

            _response.Data = dol2Real;
        }
        catch (Exception e)
        {

            _response.Message = e.Message;
            _response.IsSuccess = false;
        }

        return _response;
    }
}
