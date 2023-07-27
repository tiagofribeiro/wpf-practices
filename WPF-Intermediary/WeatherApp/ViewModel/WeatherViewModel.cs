using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    class WeatherViewModel : INotifyPropertyChanged
    {
        // Implementação de interfaces
        public event PropertyChangedEventHandler? PropertyChanged;

        // Propriedades privadas
        private int query;
        private CurrentConditions currentConditions;
        private City selectedcity;

        // Propriedades públicas
        public int Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged(nameof(Query));
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

        public City SelectedCity
        {
            get { return selectedcity; }
            set
            {
                selectedcity = value;
                OnPropertyChanged(nameof(SelectedCity));
            }
        }

        public WeatherViewModel()
        {
            // Cria dados "mockados" apenas no designer
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
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
