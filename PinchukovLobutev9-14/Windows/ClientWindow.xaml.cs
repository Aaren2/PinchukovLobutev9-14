using PinchukovLobutev9_14.ClassHelper;
using PinchukovLobutev9_14.Db;
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

using static PinchukovLobutev9_14.ClassHelper.EFClass;

namespace PinchukovLobutev9_14.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
            btnAddClient.Visibility = Visibility.Collapsed;
            if (AuthorizationDataClass.authorization.IdClient != 0)
            {
                if (!AuthorizationDataClass.authorization.IdEmployee.Equals(null))
                {
                    if (!context.Employee.ToList().Where(i => i.ID == AuthorizationDataClass.authorization.IdEmployee).FirstOrDefault().IdRole.Equals(1))
                    {
                       
                    }
                }
            }
            GetProduct();
        }
        private void GetProduct()
        {
            List<Client1> ClientList = new List<Client1>();

            ClientList = context.Client1.ToList();

            LVClient.ItemsSource = ClientList;
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
