using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Lógica para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _lastNumber, _result;
        private SelectedOperator _operator;

        public MainWindow()
        {
            InitializeComponent();

            // Atribuição de evento de click manual.
            clearButton.Click += ClearButton_Click;
            negaButton.Click += NegaButton_Click;
            percentButton.Click += PercentButton_Click;
            equalButton.Click += EqualButton_Click;
        }

        /// <summary>
        /// Método - Handler para o teclado numérico da calculadora
        /// </summary>
        /// <param name="sender">Tecla</param>
        /// <param name="e">Argumentos</param>
        private void NumberHandler(object sender, RoutedEventArgs e)
        {
            int selectedNumber = int.Parse((sender as Button).Content.ToString());

            if (resultLabel.Content.ToString() == "0")
                resultLabel.Content = $"{selectedNumber}";
            else
                resultLabel.Content = $"{resultLabel.Content}{selectedNumber}";
        }

        /// <summary>
        /// Método - Handler para as operações básicas (adição, subtração, multiplicação e divisão)
        /// </summary>
        /// <param name="sender">Tecla</param>
        /// <param name="e">Argumentos</param>
        private void OperationHandler(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out _lastNumber))
                resultLabel.Content = "0";

            if (sender == plusButton)
                _operator = SelectedOperator.Addiction;
            if (sender == minusButton)
                _operator = SelectedOperator.Subtraction;
            if (sender == divButton)
                _operator = SelectedOperator.Divison;
            if (sender == multButton)
                _operator = SelectedOperator.Multiplication;
        }

        /// <summary>
        /// Função - Evento de click para o botão de igual (resultado)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (_operator)
                {
                    case SelectedOperator.Addiction:
                        _result = Operations.Add(_lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        _result = Operations.Subtract(_lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        _result = Operations.Multiply(_lastNumber, newNumber);
                        break;
                    case SelectedOperator.Divison:
                        _result = Operations.Divide(_lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = _result;
            }
        }

        /// <summary>
        /// Função - Evento de click para o botão de %
        /// <list type="bullet">
        /// <item>Em uma operação, calcula a % do primeiro valor.</item>
        /// </list>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                newNumber /= 100;
                if(_lastNumber != 0)
                    newNumber *= _lastNumber;

                resultLabel.Content = newNumber.ToString();
            }
        }

        /// <summary>
        /// Função - Evento de click para o botão de negativo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NegaButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out _lastNumber))
            {
                _lastNumber *= -1;
                resultLabel.Content = _lastNumber.ToString();
            }
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains('.'))
                resultLabel.Content = $"{resultLabel.Content}.";
        }

        /// <summary>
        /// Função - Evento de click para o botão de limpar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            _result = 0;
            _lastNumber = 0;
        }
    }

    /// <summary>
    /// Enumerador para as operações possíveis
    /// </summary>
    public enum SelectedOperator
    {
        Addiction,
        Subtraction,
        Multiplication,
        Divison
    }

    /// <summary>
    /// Classe de funções para operações matemáticas
    /// </summary>
    public class Operations
    {
        public static double Add(double n1, double n2) { return n1 + n2; }

        public static double Subtract(double n1, double n2) { return n1 - n2; }

        public static double Multiply(double n1, double n2) { return n1 * n2; }

        public static double Divide(double n1, double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show("Divisão por 0 é muito difícil!", "Tenta outro número", MessageBoxButton.OK, MessageBoxImage.Warning);
                return 0;
            }
            return (n1 / n2);
        }
    }
}
