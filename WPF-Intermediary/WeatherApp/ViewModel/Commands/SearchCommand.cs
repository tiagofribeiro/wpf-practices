using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    class SearchCommand : ICommand
    {
        // Props
        public WeatherViewModel WeatherVM { get; set; }

        // Implementação de interface
        public event EventHandler? CanExecuteChanged
        {
            // Atualizar os comandos, no caso de comandos customizados
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Construtor
        public SearchCommand(WeatherViewModel weatherVM) => WeatherVM = weatherVM;

        // Métodos
        public bool CanExecute(object? parameter)
        {
            string query = parameter as string;

            if (string.IsNullOrEmpty(query))
                return false;
            return true;
        }

        public void Execute(object? parameter)
        {
            WeatherVM.CreateQuery();
        }
    }
}
