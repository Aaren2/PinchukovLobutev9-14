using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

            Price(products);
        }

        private void Price(ObservableCollection<Product> products) {
            decimal price = 0;
            foreach (var item in products)
            {
                price += item.Price * item.Quantity;

            }
            //DateTime dateTime = new DateTime(2023,5,25); //Проверка работоспособности 
            DateTime dateTime = DateTime.Now;
            if (dateTime.DayOfWeek+"" == "Thursday") {
                
                for (int i = 22; i < 28; i++) {
                    if (i == dateTime.Day) {
                        price = price - (price * (decimal)0.04);
                    }
                }                
            }
            price = Math.Round(price, 2);
            TBPrice.Text = price.ToString();           
            
        }

        private void BtnRemoveToCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }
            Db.Product selectedProduct = button.DataContext as Db.Product;

            if (selectedProduct != null)
            {
                if (selectedProduct.Quantity == 1 || selectedProduct.Quantity == 0)
                {
                    ClassHelper.Cart.Products.Remove(selectedProduct);
                }
                else
                {
                    selectedProduct.Quantity--;
                    int o = ClassHelper.Cart.Products.IndexOf(selectedProduct);
                    ClassHelper.Cart.Products.Remove(selectedProduct);
                    ClassHelper.Cart.Products.Insert(o, selectedProduct);
                }

            }
            GetListProduct();
        }

        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            Db.Product selectedProduct = button.DataContext as Db.Product;
            if (selectedProduct != null)
            {
                selectedProduct.Quantity++;
                int o = ClassHelper.Cart.Products.IndexOf(selectedProduct);
                ClassHelper.Cart.Products.Remove(selectedProduct);
                ClassHelper.Cart.Products.Insert(o, selectedProduct);
            }
            GetListProduct();
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Db.Product> products = new ObservableCollection<Db.Product>(ClassHelper.Cart.Products);
            if (products.Count() == 0)
            {
                MessageBox.Show("Корзина пуста");
            }
            else {    
                Db.Sale sale = new Db.Sale();
                sale.IdEmployee = (int)ClassHelper.AuthorizationDataClass.authorization.IdEmployee;
                sale.IdClient = 1;
                sale.Date = DateTime.Now;
                if (sale != null)
                {
                    ClassHelper.EFClass.context.Sale.Add(sale);
                    ClassHelper.EFClass.context.SaveChanges();
                }
    
    
                foreach (var item in ClassHelper.Cart.Products)
                {
                    Db.SaleProduct saleProduct = new Db.SaleProduct();
                    saleProduct.IdProduct = item.ID;
                    saleProduct.Quantity = item.Quantity;
                    saleProduct.IdSale = ClassHelper.EFClass.context.Sale.ToList().LastOrDefault().ID;
                    ClassHelper.EFClass.context.SaleProduct.Add(saleProduct);
                    ClassHelper.EFClass.context.SaveChanges();
                }
                ClassHelper.Cart.Products = new ObservableCollection<Db.Product>();
                MessageBox.Show("Продукты успешно добавлены");
            }
            Close();
        }
    }
    
}