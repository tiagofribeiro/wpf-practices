using DesktopContactsApp.Classes;
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

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// Interação lógica para ContactControl.xam
    /// </summary>
    public partial class ContactControl : UserControl
    {


        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // DependencyProperty extende as funcionalidade de uma propriedade comum para o WPF. Isso permite: animações, estilização, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact(), SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl contactControl = (ContactControl)d;

            if(contactControl != null)
            {
                contactControl.nameTextBlock.Text = ((Contact)e.NewValue).Name;
                contactControl.emailTextBlock.Text = ((Contact)e.NewValue).Email;
                contactControl.phoneTextBlock.Text = ((Contact)e.NewValue).Phone;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
