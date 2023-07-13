using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly string _dbName = "Contacts.db";
        private static readonly string _folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static string DatabasePath { get; } = System.IO.Path.Combine(_folderPath, _dbName);
    }
}
