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

using DesktopContactsApp.Classes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Lógica interna para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> _contacts;

        public MainWindow()
        {
            InitializeComponent();

            _contacts = new List<Contact>();

            ReadDatabase();
        }

        /// <summary>
        /// Evento de mudança no texto da barra de pesquisa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = (TextBox)sender;

            var filteredList = _contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            // Where - LINQ
            // var filteredList = (from c in _contacts where c.Name.toLower().Contains(searchTextBox.Text.ToLower()) select c).ToList();

            contactsListView.ItemsSource = filteredList;
        }

        /// <summary>
        /// Evento de botão para adicionar novo contato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewContact_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDatabase();
        }

        /// <summary>
        /// Método para leitura dos dados na tabela de contatos (Contact)
        /// </summary>
        private void ReadDatabase()
        {
            using (SQLite.SQLiteConnection conn = new(App.DatabasePath))
            {
                conn.CreateTable<Contact>();
                _contacts = conn.Table<Contact>().ToList().OrderBy(c => c.Name).ToList();

                // OrderBy - LINQ
                //_contacts = (List<Contact>)(from c in _contacts orderby c.Name select c);
            }

            if (_contacts != null)
                contactsListView.ItemsSource = _contacts;
        }
    }
}
