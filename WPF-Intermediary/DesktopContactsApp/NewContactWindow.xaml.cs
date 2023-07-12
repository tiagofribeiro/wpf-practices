using SQLite;
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
using System.Windows.Shapes;

using DesktopContactsApp.Classes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Lógica interna para NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text,
            };

            // A palavra chave using utiliza a interface disposable para simplificar a 'eliminação' do obj
            using (SQLiteConnection _conn = new SQLiteConnection(App.DatabasePath))
            {
                _conn.CreateTable<Contact>();
                _conn.Insert(contact);
            } ;

            Close();
        }
    }
}
