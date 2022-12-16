using Newtonsoft.Json;
using WebScraper.Models;
using WebScraper.Scrapers;


var countryScraper = new CountryScraper();
var cityScraper = new CityScraper();
var result = new List<CountryDetails>();

var countries = countryScraper.GetCountries();

foreach (var country in countries)
{
    Console.WriteLine($"Getting cities for {country.Name}");
    var cities = cityScraper.GetCities(country).ToList();

    result.Add(new CountryDetails()
    {
        Code = country.Code,
        Name = country.Name,
        Cities = cities,
    });
}

var json = JsonConvert.SerializeObject(result).Replace("&nbsp;", " ");
var path = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\net6.0", "");
File.WriteAllText($@"{path}\result.json", json);
Console.WriteLine($@"Saving file to {path}\result.json ");