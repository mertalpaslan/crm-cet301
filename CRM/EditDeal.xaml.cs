using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
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
    /// Interaction logic for EditDeal.xaml
    /// </summary>
    public partial class EditDeal : Window
    {
        int Id;
        AppDbContext db = new AppDbContext();

        public EditDeal(int dealId)
        {
            InitializeComponent();
            Id = dealId;
            Deal updateDeal = (from d in db.Deals
                                       where d.Id == Id
                                       select d).Single();

            nameTB.Text = updateDeal.Name;
            customerTB.Text = updateDeal.CustomerId.ToString();
            productTB.Text = updateDeal.ProductId.ToString();
            amountTB.Text = updateDeal.Amount.ToString();
            IsPaid.IsChecked = updateDeal.is_paid;
        }

        private void editDealBtn_Click(object sender, RoutedEventArgs e)
        {
            bool check = IsPaid.IsChecked ?? false;
            Deal updateDeal = (from d in db.Deals
                               where d.Id == Id
                               select d).Single();

            updateDeal.Name = nameTB.Text;
            updateDeal.CustomerId = int.Parse(customerTB.Text);
            updateDeal.ProductId = int.Parse(productTB.Text);
            updateDeal.is_paid = check;
            db.SaveChanges();
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            window.Load();
            this.Hide();
        }
    }
}
