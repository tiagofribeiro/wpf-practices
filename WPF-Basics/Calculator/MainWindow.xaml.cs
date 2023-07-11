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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _lastNumber, _result;

        public MainWindow()
        {
            InitializeComponent();

            clearButton.Click += ClearButton_Click;
            negaButton.Click += NegaButton_Click;
            percentButton.Click += PercentButton_Click;
            equalButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OperationHandler(object sender, RoutedEventArgs e)
        {

        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out _lastNumber))
            {
                _lastNumber /= 100;
                resultLabel.Content = _lastNumber.ToString();
            }
        }

        private void NegaButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out _lastNumber))
            {
                _lastNumber *= -1;
                resultLabel.Content = _lastNumber.ToString();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void NumberHandler(object sender, RoutedEventArgs e)
        {
            int selectedNumber = 0;

            if (sender == zeroButton)
                selectedNumber = 0;
            if (sender == oneButton)
                selectedNumber = 1;
            if (sender == twoButton)
                selectedNumber = 2;
            if (sender == threeButton)
                selectedNumber = 3;
            if (sender == fourButton)
                selectedNumber = 4;
            if (sender == fiveButton)
                selectedNumber = 5;
            if (sender == sixButton)
                selectedNumber = 6;
            if (sender == sevenButton)
                selectedNumber = 7;
            if (sender == eightButton)
                selectedNumber = 8;
            if (sender == nineButton)
                selectedNumber = 9;

            if (resultLabel.Content.ToString() == "0")
                resultLabel.Content = $"{selectedNumber}";
            else 
                resultLabel.Content = $"{resultLabel.Content}{selectedNumber}";
        }
    }
}
