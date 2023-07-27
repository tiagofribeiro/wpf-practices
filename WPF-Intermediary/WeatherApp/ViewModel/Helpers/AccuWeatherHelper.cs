﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    internal class AccuWeatherHelper
    {
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "/locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENTCONDITION_ENDPOINT = "/currentconditions/v1/{0}?apikey={1}";
        public const string API_KEY = "uvkLz0LpYl2roY6rGGfGGtalTzSAAJ3G";

        public static async Task<List<City>> GetCitiesAsync(string query)
        {
            List<City>? cityList = new();

            string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);

            using (HttpClient client = new()) 
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                // 
                cityList = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cityList;
        }

        public static async Task<CurrentConditions> GetCurrentConditionsAsync(string cityKey)
        {
            CurrentConditions? currentConditions = new();

            string url = BASE_URL + string.Format(CURRENTCONDITION_ENDPOINT, cityKey, API_KEY);

            using (HttpClient client = new())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                currentConditions = JsonConvert.DeserializeObject<CurrentConditions>(json);
            }

            return currentConditions;
        }
    }
}