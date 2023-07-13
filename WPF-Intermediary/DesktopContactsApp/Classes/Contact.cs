using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactsApp.Classes
{
    internal class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        /// <summary>
        /// Sobrescrita do método ToString para realizar formatação prévia
        /// </summary>
        /// <returns>Todos os dados de forma legível</returns>
        public override string ToString()
        {
            return $"{Name} - {Email} - {Phone}";
        }
    }
}
