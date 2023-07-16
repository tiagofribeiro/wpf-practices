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
    /// Lógica interna para DetailedContactWindow.xaml
    /// </summary>
    public partial class DetailedContactWindow : Window
    {
        private Contact _contact;

        public DetailedContactWindow(Contact contact)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            _contact = contact;

            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneTextBox.Text = contact.Phone;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            _contact.Name = nameTextBox.Text;
            _contact.Email = emailTextBox.Text;
            _contact.Phone = phoneTextBox.Text;

            using (SQLiteConnection conn = new(App.DatabasePath))
            {
                _ = conn.Update(_contact);
            }

            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new(App.DatabasePath))
            {
                _ = conn.Delete(_contact);
            }

            Close();
        }
    }
}
