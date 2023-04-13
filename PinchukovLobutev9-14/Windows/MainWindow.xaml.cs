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
using System.Runtime.Remoting.Contexts;


using PinchukovLobutev9_14.Db;
using static PinchukovLobutev9_14.ClassHelper.EFClass;


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
            
            if (AuthorizationDataClass.authorization.IdClient != null)
            {
                TbUser.Text = "Клиент";
                BtnEmployee.Visibility = Visibility.Collapsed;
                BtnClient.Visibility = Visibility.Collapsed;
                BtnOrder.Visibility = Visibility.Collapsed;
            }
            else
            {
                TbUser.Text = context.Role.ToList().Where(i => i.ID == context.Employee.ToList().Where(j => j.ID == AuthorizationDataClass.authorization.IdEmployee).FirstOrDefault().IdRole).FirstOrDefault().NameOfRole;
            }



        }

        private void BtnEmplyee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            this.Hide();
            employeeWindow.ShowDialog();
            this.Show();
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow clientWindow = new ClientWindow();
            this.Hide();
            clientWindow.ShowDialog();
            this.Show();
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            this.Hide();
            orderWindow.ShowDialog();
            this.Show();
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
