using System.Globalization;
using HtmlAgilityPack;

namespace CoreWebApi;

public static class Scrappy
{
    public static float RealCurated()
    {
        try
        {
            var html = @"https://pt.exchange-rates.org/converter/USD/BRL/1";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            string cssClass = "single-conversions";
            var elements = htmlDoc.DocumentNode.SelectNodes($"//div[contains(@class, '{cssClass}')]//span");
            var dol2Real = elements.Count > 0 ? elements[0].InnerHtml.Split("=") : null;
            var dol2RealFormated = dol2Real[1].Split(" ")[1].Replace(",", ".");
            var dol2RealParsed = float.Parse(dol2RealFormated, CultureInfo.InvariantCulture.NumberFormat);

            return dol2RealParsed;
        }
        catch (Exception)
        {

            throw;
        }
        
    }
}
