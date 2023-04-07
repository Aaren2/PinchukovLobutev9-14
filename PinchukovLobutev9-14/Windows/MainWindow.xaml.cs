using PinchukovLobutev9_14.Windows;
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
using PinchukovLobutev9_14.ClassHelper;

namespace PinchukovLobutev9_14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (AuthorizationDataClass.authorization.IdClient != 0)
            {
                BtnAuthorization.Visibility = Visibility.Collapsed;
                BtnEmployee.Visibility = Visibility.Collapsed;
                BtnClient.Visibility = Visibility.Collapsed;
                BtnOrder.Visibility = Visibility.Collapsed;
            }


        }

        private void BtnEmplyee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAuthorization_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            this.Hide();
            menuWindow.ShowDialog();
            this.Show();
        }
    }
}
