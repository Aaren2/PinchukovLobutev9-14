using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using PinchukovLobutev9_14.Db;

namespace PinchukovLobutev9_14.Windows
{
    /// <summary>
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();
            GetListProduct();
        }

        private void GetListProduct()
        {
            ObservableCollection<Db.Product> products = new ObservableCollection<Db.Product>(ClassHelper.Cart.Products);

            LvCartProductList.ItemsSource = products;
        }

        private void BtnRemoveToCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            var selectedProduct = button.DataContext as Db.Product;


            if (selectedProduct != null)
            {
                ClassHelper.Cart.Products.Remove(selectedProduct);
            }
            GetListProduct();


        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            Db.Sale sale = new Db.Sale();
            sale.IdEmployee = 2;
            sale.IdClient = ClassHelper.AuthorizationDataClass.authorization.IdClient;
            ClassHelper.EFClass.context.Sale.Add(sale);
            ClassHelper.EFClass.context.SaveChanges();

            Db.SaleProduct saleProduct = new Db.SaleProduct();

        }
    }
}