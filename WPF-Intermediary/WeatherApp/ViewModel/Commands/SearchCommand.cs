using System;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    class SearchCommand : ICommand
    {
        // Implementação de interface
        public event EventHandler? CanExecuteChanged
        {
            // Atualizar os comandos manualmente, no caso de comandos customizados
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Props
        public WeatherViewModel WeatherVM { get; set; }

        // Construtor
        public SearchCommand(WeatherViewModel weatherVM) => WeatherVM = weatherVM;

        // Métodos
        public bool CanExecute(object? parameter)
        {
            string? query = parameter as string;

            if (string.IsNullOrEmpty(query))
                return false;
            return true;
        }

        public void Execute(object? parameter)
        {
            WeatherVM.SearchCity();
        }
    }
}
