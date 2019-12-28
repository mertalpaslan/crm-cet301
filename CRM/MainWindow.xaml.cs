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

        AppDbContext db = new AppDbContext();
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            PList.ItemsSource = db.Products.ToList();
            Products = PList;
        }

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

    }
}
