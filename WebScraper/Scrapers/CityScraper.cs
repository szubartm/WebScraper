﻿using HtmlAgilityPack.CssSelectors.NetCore;
using WebScraper.Models;


namespace WebScraper.Scrapers
{
    public class CityScraper
    {
        public IEnumerable<CityModel> GetCities(CountryModel country)
        {
            var web = new HtmlAgilityPack.HtmlWeb();


            var document = web.Load(country.Href);

            var tableRows = document.QuerySelectorAll("body > table:nth-child(3) tr").Skip(1);

            foreach (var tableRow in tableRows)
            {
                var tds = tableRow.QuerySelectorAll("td");
                var code = tds[1].InnerText;
                var name = tds[2].InnerText;

                yield return new CityModel(code, name);
            }
        }
    }
}
