using System;
using System.Collections.Generic;
using System.Data;
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
        public static ListView Deals;
        public static ListView Manipulated;
        

        AppDbContext db = new AppDbContext();


        public MainWindow()
        {
            InitializeComponent();
            Load();

        }
        public void Load()
        {
        var JoinedDeals = (from d in db.Deals
                        join p in db.Products
                        on d.ProductId equals p.Id
                        join c in db.Customers
                         on d.CustomerId equals c.Id
                        select new DealProfile { CustomerName = c.Name, CustomerId = c.Id, ProductName = p.Name, ProductId = p.Id, DealId = d.Id,
                            Amount = d.Amount, TotalPrice = p.Price * d.Amount, UnitPrice = p.Price, IsPaid = d.is_paid, DealName = d.Name}).ToList<DealProfile>();

            

            CList.ItemsSource = db.Customers.ToList();
            Customers = CList;
            PList.ItemsSource = db.Products.ToList();
            Products = PList;
            DList.ItemsSource = JoinedDeals;
            Deals = DList;
            DList.Items.Refresh();
            DList.ItemsSource = null;
            DList.Items.Refresh();
            DList.ItemsSource = JoinedDeals;
            DList.Items.Refresh();

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



        // Deal


        public class DealProfile
        {
            public string DealName { get; set; }

            public string CustomerName { get; set; }
            
            public int CustomerId { get; set; }

            public string ProductName { get; set; }

            public int ProductId { get; set; }

            public int DealId { get; set; }

            public int UnitPrice { get; set; }

            public int Amount { get; set; }

            public int TotalPrice { get; set; }

            public bool IsPaid { get; set; }

        }

        private void dDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (DList.SelectedItem as DealProfile).DealId;
            var selectedDeal = db.Deals.Where(d => d.Id == id).Single();
            db.Deals.Remove(selectedDeal);
            db.SaveChanges();
            this.Load();


            db.SaveChanges();
         //   DList.ItemsSource = JoinedDeals.ToList();
        }

        private void dEditBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (DList.SelectedItem as DealProfile).DealId;
            EditDeal EDW = new EditDeal(Id);
            EDW.ShowDialog();
        }

        private void addDealPageBtn(object sender, RoutedEventArgs e)
        {
            AddDeal ADW = new AddDeal();
            ADW.ShowDialog();
        }


        // Dashboard

    }
}
