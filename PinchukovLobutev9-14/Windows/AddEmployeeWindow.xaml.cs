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
using PinchukovLobutev9_14.Db;

namespace PinchukovLobutev9_14.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        private bool addOrUpd;
        private Employee employee;
        public AddEmployeeWindow(bool addOrUpd, Employee employee)
        {
            InitializeComponent();
            this.addOrUpd = addOrUpd;
            this.employee = employee;
            CmbGender.ItemsSource = context.Gender.ToList();
            CmbGender.SelectedIndex = 0;
            CmbGender.DisplayMemberPath = "Gender1";
            if (addOrUpd) {
                TbFirstName.Text = employee.FirstName;
                TbLastName.Text = employee.LastName;
                TbMidlleName.Text = employee.MidleName;   
                TbPhone.Text = employee.Phone;
                TbEmail.Text = employee.Email;
                TbPassport.Text = employee.Passport;
                DPB.SelectedDate = employee.DateOfBirthday;
                if (employee.IdGender == 1) { CmbGender.SelectedIndex = 0; }
                else { CmbGender.SelectedIndex = 1; }


                TbLogin.Visibility = Visibility.Collapsed;               
                TbPassword1.Visibility = Visibility.Collapsed;
                TbPassword2.Visibility = Visibility.Collapsed;
                PbCode.Visibility = Visibility.Collapsed;
                TBLogin.Visibility = Visibility.Collapsed;
                TBPassword1.Visibility = Visibility.Collapsed;
                TBPassword2.Visibility = Visibility.Collapsed;
                PBCode.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbFirstName.Text))
            {
                MessageBox.Show("Имя не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(TbLastName.Text))
            {
                MessageBox.Show("Фамилия не может быть пустой");
                return;
            }

            if (string.IsNullOrWhiteSpace(TbPhone.Text))
            {
                MessageBox.Show("Телефон не может быть пустым");
                return;
            }
            bool result = Int64.TryParse(TbPhone.Text, out var number);
            if (result != true)
            {
                MessageBox.Show("Телефон должен быть заполнен числами");
                return;
            }
            if (string.IsNullOrWhiteSpace(TbEmail.Text))
            {
                MessageBox.Show("Почта не может быть пустой");
                return;
            }


            if (string.IsNullOrWhiteSpace(TbPassport.Text))
            {
                MessageBox.Show("Паспорт не может быть пустым");
                return;
            }
            bool result1 = Int64.TryParse(TbPassport.Text, out var number1);
            if (result != true)
            {
                MessageBox.Show("Паспорт должен быть заполнен числами");
                return;
            }


            

            if (!addOrUpd) {
                if (string.IsNullOrWhiteSpace(TbLogin.Text))
                {
                    MessageBox.Show("Логин не может быть пустым");
                    return;
                }
                if (string.IsNullOrWhiteSpace(TbPassword1.Password))
                {
                    MessageBox.Show("Пароль не может быть пустым");
                    return;
                }
                if (TbPassword1.Password != TbPassword2.Password)
                {
                    MessageBox.Show("Пароли должны быть одинаковыми");
                    return;
                }


                if (string.IsNullOrWhiteSpace(PbCode.Password))
                {
                    MessageBox.Show("Код сотрудника не может быть пустым");
                    return;
                }
                var authUser = context.Role.ToList().Where(i => i.PersonCode == Convert.ToInt32(PbCode.Password)).FirstOrDefault();
                if (authUser == null)
                {
                    MessageBox.Show("Неверный код сотрудника");
                    return;
                }

                var authUser1 = context.Authorization.ToList().Where(i => i.Login == TbLogin.Text).FirstOrDefault();
                if (authUser1 != null)
                {
                    MessageBox.Show("Такой логин занят");
                    return;
                }


            }
            if (string.IsNullOrWhiteSpace(DPB.Text))
            {
                MessageBox.Show("Не введена дата рождения");
                return;
            }
            else
            {
                
                if(addOrUpd){
                    Db.Employee employee = new Db.Employee();
                    employee.ID = this.employee.ID;
                    employee.FirstName = TbFirstName.Text;
                    employee.LastName = TbLastName.Text;
                    employee.MidleName = TbMidlleName.Text;
                    employee.Phone = TbPhone.Text;
                    employee.Email = TbEmail.Text;
                    employee.Passport = TbPassport.Text;
                    employee.DateOfBirthday = DPB.SelectedDate.Value;
                    employee.IdGender = (CmbGender.SelectedItem as Db.Gender).ID;
                    context.SaveChanges();
                }
                
                if (!addOrUpd)
                {
                    Db.Employee employee = new Db.Employee();
                    employee.ID = this.employee.ID;
                    employee.FirstName = TbFirstName.Text;
                    employee.LastName = TbLastName.Text;
                    employee.MidleName = TbMidlleName.Text;
                    employee.Phone = TbPhone.Text;
                    employee.Email = TbEmail.Text;
                    employee.Passport = TbPassport.Text;
                    employee.DateOfBirthday = DPB.SelectedDate.Value;
                    employee.IdGender = (CmbGender.SelectedItem as Db.Gender).ID;
                   
                    employee.IdRole = (context.Role.ToList().Where(i => i.PersonCode == Convert.ToInt32(PbCode.Password)).FirstOrDefault()).ID;
                    context.Employee.Add(employee);
                    context.SaveChanges();
                    Db.Authorization authorization = new Db.Authorization();
                    authorization.Login = TbLogin.Text;
                    authorization.Password = TbPassword1.Password;
                    authorization.IdEmployee = (context.Employee.ToList().Where(i => i.FirstName == TbFirstName.Text).Last()).ID;
                    context.Authorization.Add(authorization);

                    context.SaveChanges();
                    
                }
                
                 
                 
            }
            this.Close();
        }
    }
}
