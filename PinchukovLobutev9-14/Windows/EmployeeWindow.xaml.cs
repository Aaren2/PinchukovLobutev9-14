using PinchukovLobutev9_14.ClassHelper;
using PinchukovLobutev9_14.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();


            if (AuthorizationDataClass.authorization.IdClient != 0)
            {
                if (!AuthorizationDataClass.authorization.IdEmployee.Equals(null))
                {
                    if (!context.Employee.ToList().Where(i => i.ID == AuthorizationDataClass.authorization.IdEmployee).FirstOrDefault().IdRole.Equals(1))
                    {
                        WP.Visibility = Visibility.Collapsed;
                    }
                }
            }
            else 
            {
                btnAddEmployee.Visibility = Visibility.Collapsed;
            }
            GetProduct();
        }
        private void GetProduct()
        {
            List<Employee> EmploList = new List<Employee>();

            EmploList = context.Employee.ToList();

            LVEmplo.ItemsSource = EmploList;
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow(false,null);
            this.Hide();
            addEmployeeWindow.ShowDialog();
            GetProduct();
            this.ShowDialog();
        }

        private void btnUpdEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = LVEmplo.SelectedValue as Employee;
            if(employee!=null){
                AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow(true,employee);
                this.Hide();
                addEmployeeWindow.ShowDialog();
                GetProduct();
            }
        }
    }
}
