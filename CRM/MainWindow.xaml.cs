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

namespace CRM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView Products;
        public static ListView Customers;

        AppDbContext db = new AppDbContext();
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            CList.ItemsSource = db.Customers.ToList();
            Customers = CList;
            PList.ItemsSource = db.Products.ToList();
            Products = PList;
        }


        // Product
        private void addProductPageBtn(object sender, RoutedEventArgs e)
        {
            AddProduct APW = new AddProduct();
            APW.ShowDialog();
        }

        private void pEditBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (PList.SelectedItem as Product).Id;
            EditProduct EPW = new EditProduct(Id);
            EPW.ShowDialog();
        }



        private void pDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (PList.SelectedItem as Product).Id;
            var selectedProduct = db.Products.Where(p => p.Id == id).Single();
            db.Products.Remove(selectedProduct);
            db.SaveChanges();
            PList.ItemsSource = db.Products.ToList();

        }


        // Customer

        private void addCustomerPageBtn(object sender, RoutedEventArgs e)
        {
            AddCustomer ACW = new AddCustomer();
            ACW.ShowDialog();
        }

        private void cEditBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (CList.SelectedItem as Customer).Id;
            EditCustomer ECW = new EditCustomer(Id);
            ECW.ShowDialog();
        }


        private void cDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (CList.SelectedItem as Customer).Id;
            var selectedCustomer = db.Customers.Where(c => c.Id == id).Single();
            db.Customers.Remove(selectedCustomer);
            db.SaveChanges();
            CList.ItemsSource = db.Customers.ToList();

        }
    }
}
