﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    class WeatherViewModel : INotifyPropertyChanged
    {
        // Implementação de interface
        public event PropertyChangedEventHandler? PropertyChanged;

        // Props
        private string query;
        private City selectedcity;
        private CurrentConditions currentConditions;

        public ObservableCollection<City> Cities { get; set; }

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged(nameof(Query));
            }
        }

        public City SelectedCity
        {
            get { return selectedcity; }
            set
            {
                selectedcity = value;
                OnPropertyChanged(nameof(SelectedCity));
            }
        }

        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set
            {
                currentConditions = value;
                OnPropertyChanged(nameof(CurrentConditions));
            }
        }

        // Commands
        public SearchCommand SearchCommand { get; set; }

        // Construtor
        public WeatherViewModel()
        {
            // Dados mocados visíveis apenas no designer
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                SelectedCity = new City
                {
                    LocalizedName = "Belo Horizonte"
                };
                CurrentConditions = new CurrentConditions
                {
                    WeatherText = "Nublado",
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = 30,
                        }
                    }
                };
            }

            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();
        }

        // Métodos
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            Console.WriteLine(propertyName);
        }

        public async void SearchCity()
        {
            Cities.Clear();

            List<City> response = await AccuWeatherHelper.GetCitiesAsync(Query);

            foreach (City city in response)
            {
                Cities.Add(city);
            }
        }

        private async void GetCurrentConditions()
        {
            Cities.Clear();
            CurrentConditions = new();
            Query = string.Empty;


            CurrentConditions = await AccuWeatherHelper.GetCurrentConditionsAsync(SelectedCity.Key);

        }
    }
}
