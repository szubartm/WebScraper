﻿namespace WebScraper.Models
{
    public class CountryDetails
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<CityModel> Cities { get; set; }
    }
}
