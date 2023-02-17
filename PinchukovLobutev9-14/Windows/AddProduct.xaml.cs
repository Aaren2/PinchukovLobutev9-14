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
using System.Xml.Linq;

using PinchukovLobutev9_14.ClassHelper;
using PinchukovLobutev9_14.Db;
using static PinchukovLobutev9_14.ClassHelper.EFClass;
using Microsoft.Win32;
using System.IO;


namespace PinchukovLobutev9_14.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        private string pathPhoto = null;
        public AddProduct()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbProdName.Text))
            {
                MessageBox.Show("Логин не может быть пустым" );
                return;
            }
            if (string.IsNullOrWhiteSpace(TbPrice.Text))
            {
                MessageBox.Show("Пароль не может быть пустым");
                return;
            }
            bool result = Decimal.TryParse(TbPrice.Text, out var number);
            if (result != true)
            {
                MessageBox.Show("Цена должна быть заполнена числами");
                return;
            }


            var authUser = context.Product.ToList().Where(i => i.NameOfProduct == TbProdName.Text).FirstOrDefault();
            if (authUser != null)
            {
                MessageBox.Show("Такое блюдо уже есть");
                return;
            }
            else
            {


                Db.Product product = new Db.Product();
                product.NameOfProduct= TbProdName.Text;
                product.Price = Convert.ToDecimal(TbPrice.Text);
                product.Description = TbDesc.Text;
                if (pathPhoto != null)
                {
                    product.ImageProduct = pathPhoto;
                }
                context.Product.Add(product);

                context.SaveChanges();

               
            }
        }

        private void BtnImgAdd_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var fileContent = string.Empty;
            openFileDialog.InitialDirectory = "c:\\";


            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
            {
                ImgProd.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathPhoto = openFileDialog.FileName;
            }

            MessageBox.Show(pathPhoto + "");







        }
    }
}
