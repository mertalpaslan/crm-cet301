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
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        AppDbContext db = new AppDbContext();
        int Id;
        public EditCustomer(int customerId)
        {
            InitializeComponent();
            Id = customerId;
            Customer updateCustomer = (from c in db.Customers
                                     where c.Id == Id
                                     select c).Single();
            nameTB.Text = updateCustomer.Name;
            addressTB.Text = updateCustomer.Address;
            cnumberTB.Text = updateCustomer.ContactNumber;
        }

        private void editCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            {
                Customer updateCustomer = (from c in db.Customers
                                         where c.Id == Id
                                         select c).Single();

                updateCustomer.Name = nameTB.Text;
                updateCustomer.Address = addressTB.Text;
                updateCustomer.ContactNumber = cnumberTB.Text;

                db.SaveChanges();
                MainWindow.Customers.ItemsSource = db.Customers.ToList();
                this.Hide();

            }
        }


    }
}
