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
            GetProduct();
        }
        private void GetProduct()
        {
            List<Product> ProdList = new List<Product>();

            ProdList = context.Product.ToList();

            LVProd.ItemsSource = ProdList;
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct menuWindow = new AddProduct();
            menuWindow.Show();
            this.Close();
        }


    }
}
