using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        AppDbContext db = new AppDbContext();
        public AddProduct()
        {
            InitializeComponent();
        }

        private void addProductBtn_Click(object sender, RoutedEventArgs e)
        {
            Product newProduct = new Product()
            {
                Name = nameTB.Text,
                Description = descriptionTB.Text,
                Price = int.Parse(priceTB.Text)
            };
            db.Products.Add(newProduct);
            db.SaveChanges();
            this.Hide();

        }
    }
}
