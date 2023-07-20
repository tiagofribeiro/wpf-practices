using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    internal class AccuWeatherHelper
    {
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "/locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENTCONDITION_ENDPOINT = "/currentconditions/v1/{0}?apikey={1}";
        public const string API_KEY = "uvkLz0LpYl2roY6rGGfGGtalTzSAAJ3G";

        public static List<City> GetCities(string query)
        {
            List<City> cityList = new();

            string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);

            using (HttpClient client = new()) 
            {
                //Fazer request
            }

            return cityList;
        }
    }
}
