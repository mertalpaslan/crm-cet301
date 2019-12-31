using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRM
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        AppDbContext db = new AppDbContext();
        public AddCustomer()
        {
            InitializeComponent();
        }
        private void addCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            Customer newCustomer = new Customer()
            {
                Name = nameTB.Text,
                Address = adressTB.Text,
                ContactNumber = cnumberTB.Text
            };
            db.Customers.Add(newCustomer);
            db.SaveChanges();
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.Load();
            this.Hide();

        }
    }
}
