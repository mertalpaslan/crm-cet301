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
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        AppDbContext db = new AppDbContext();
        int Id;
        public EditProduct(int productId)
        {
            InitializeComponent();
            Id = productId;
        }
        private void editProductBtn_Click(object sender, RoutedEventArgs e)
        {
            {
                Product updateProduct = (from p in db.Products
                                         where p.Id == Id
                                         select p).Single();

                // updateProduct.Name = nametextbox.name

                db.SaveChanges();
                MainWindow.Products.ItemsSource = db.Products.ToList();
                this.Hide();

            }
        }
    }
}
