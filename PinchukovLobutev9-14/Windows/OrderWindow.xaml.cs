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
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();
            CBOrderBy.SelectedIndex = 0;
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
            List<OrderStatic> OrderStatic = new List<OrderStatic>();

            OrderStatic = context.OrderStatic.ToList();

            LVOrder.ItemsSource = OrderStatic;
        }


        private void BTNSerch_Click(object sender, RoutedEventArgs e)
        {
            LVOrder.ItemsSource = context.OrderStatic.ToList().Where(i => i.Date >= TBDateStar.SelectedDate && i.Date <= TBDateEnd.SelectedDate);
        }

        private void IdOrder_Selected(object sender, RoutedEventArgs e)
        {

            ComboBoxItem item = sender as ComboBoxItem;
            if (CBOrderBy.SelectedIndex == 0) {                
                switch(item.Name) {
                    case "IdOrder":
                        LVOrder.ItemsSource = context.OrderStatic.ToList().OrderBy(i => i.ID);
                        break;
                    case "FullPrice":
                        LVOrder.ItemsSource = context.OrderStatic.ToList().OrderBy(i => i.FullPrice);
                        break;
                    case "Quantity":
                        LVOrder.ItemsSource = context.OrderStatic.ToList().OrderBy(i => i.Quantity);
                        break;
                    case "Date":
                        LVOrder.ItemsSource = context.OrderStatic.ToList().OrderBy(i => i.Date);
                        break;
                    case "IdEmployee":
                        LVOrder.ItemsSource = context.OrderStatic.ToList().OrderBy(i => i.IdEmployee);
                        break;
                    case "IdClient":
                        LVOrder.ItemsSource = context.OrderStatic.ToList().OrderBy(i => i.IdClient);
                        break;

                    default: 
                        break;
                }
            }
            if (CBOrderBy.SelectedIndex == 1)
            {
                switch (item.Name)
                {
                    case "IdOrder":
                        LVOrder.ItemsSource = context.OrderStatic.ToList().OrderByDescending(i => i.ID);
                        break;
                    case "FullPrice":
                        LVOrder.ItemsSource = context.OrderStatic.ToList().OrderByDescending(i => i.FullPrice);
                        break;
                    case "Quantity":
                        LVOrder.ItemsSource = context.OrderStatic.ToList().OrderByDescending(i => i.Quantity);
                        break;
                    case "Date":
                        LVOrder.ItemsSource = context.OrderStatic.ToList().OrderByDescending(i => i.Date);
                        break;
                    case "IdEmployee":
                        LVOrder.ItemsSource = context.OrderStatic.ToList().OrderByDescending(i => i.IdEmployee);
                        break;
                    case "IdClient":
                        LVOrder.ItemsSource = context.OrderStatic.ToList().OrderByDescending(i => i.IdClient);
                        break;

                    default:
                        break;
                }
            }
        }

        private void OrderBy_Selected(object sender, RoutedEventArgs e)
        {
            CBSerch.SelectedIndex = 0;
        }
    }
}
