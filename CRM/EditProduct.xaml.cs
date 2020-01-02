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
            Product updateProduct = (from p in db.Products
                                     where p.Id == Id
                                     select p).Single();
            nameTB.Text = updateProduct.Name;
            descriptionTB.Text = updateProduct.Description;
            priceTB.Text = updateProduct.Price.ToString();



        }
  
        private void editProductBtn_Click(object sender, RoutedEventArgs e)
        {
            {
                Product updateProduct = (from p in db.Products
                                         where p.Id == Id
                                         select p).Single();

                // updateProduct.Name = nametextbox.name
                updateProduct.Name = nameTB.Text;
                updateProduct.Description = descriptionTB.Text;
                updateProduct.Price = int.Parse(priceTB.Text);
                db.SaveChanges();
                MainWindow.Products.ItemsSource = db.Products.ToList();
                this.Hide();

            }
        }
    }
}
