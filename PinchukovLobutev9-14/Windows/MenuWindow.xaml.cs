using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using PinchukovLobutev9_14.ClassHelper;
using PinchukovLobutev9_14.Db;
using static PinchukovLobutev9_14.ClassHelper.EFClass;

namespace PinchukovLobutev9_14.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            if (AuthorizationDataClass.authorization.IdClient != 0)
            {
                if (!AuthorizationDataClass.authorization.IdEmployee.Equals(null)) 
                {
                    if (!context.Employee.ToList().Where(i => i.ID == AuthorizationDataClass.authorization.IdEmployee).FirstOrDefault().IdRole.Equals(1))
                    {
                        btnAddProduct.Visibility = Visibility.Collapsed;
                    }
                }               
            }
            GetProduct();
        }
        private void GetProduct()
        {
            List<Product> ProdList = new List<Product>();

            ProdList = context.Product.ToList();

            LVProd.ItemsSource = ProdList;
        }
        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            var selectedProduct = button.DataContext as Db.Product;


            if (selectedProduct != null)
            {
                ClassHelper.Cart.Products.Add(selectedProduct);
            }


        }

        private void BtnGoToCart_Click(object sender, RoutedEventArgs e)
        {
            CartWindow cartWindow = new CartWindow();
            this.Hide();
            cartWindow.ShowDialog();
            this.Show();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct menuWindow = new AddProduct();
            menuWindow.Show();
            this.Close();
        }


    }
}
