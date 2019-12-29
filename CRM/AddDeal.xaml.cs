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
    /// Interaction logic for AddDeal.xaml
    /// </summary>
    public partial class AddDeal : Window
    {
        AppDbContext db = new AppDbContext();
        public AddDeal()
        {
            InitializeComponent();
        }

        private void addDealBtn_Click(object sender, RoutedEventArgs e)
        {
            Deal newDeal = new Deal()
            {
                Name = nameTB.Text,
                ProductId = int.Parse(productTB.Text),
                CustomerId = int.Parse(customerTB.Text),
                Amount = int.Parse(amountTB.Text)
            };
            db.Deals.Add(newDeal);
            db.SaveChanges();

            this.Hide();

        }
    }
}
