using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;

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
        }

        // Métodos
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CreateQuery()
        {
            var cities = AccuWeatherHelper.GetCitiesAsync(Query);
        }
    }
}
