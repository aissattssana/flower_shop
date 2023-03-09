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
using System.Windows.Shapes;

namespace flowers
{
    /// <summary>
    /// Логика взаимодействия для CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        private string _callerWindow;
        FlowerShopdbContext db = new FlowerShopdbContext();
        public CreateUserWindow(string callerWindow)
        {
            InitializeComponent();
            _callerWindow = callerWindow;
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] textBoxes = { login_u, second_name_u, name_u, password_u, mail_u, address, money_u };
            foreach (var textBox in textBoxes)
            {
                if (String.IsNullOrEmpty(textBox.Text))
                {
                    MessageBox.Show("Введите текст");
                    return;
                }
            }

            if (client.IsChecked == false && manager.IsChecked == false)
            {
                MessageBox.Show("Выберите тип пользователя");
                return;
            }

            var newUser = new User()
            {
                Login = login_u.Text,
                SecondName = second_name_u.Text,
                Name = name_u.Text,
                Password = password_u.Text,
                Mail = mail_u.Text,
                Address = address.Text,
                Phone = phone_u.Text
            };
            if (client.IsChecked == true)
            {
                newUser.Role = "client";
                dol.IsEnabled = false;
                possition_u.IsEnabled = false;
                var newClient = new Client()
                {
                    UserId = newUser.IdUser,
                    Money = Convert.ToDouble(money_u.Text)
                };
            }
            else if (manager.IsChecked == true)
            {
                newUser.Role = "manager";
                kosh.IsEnabled = false;
                money_u.IsEnabled = false;
                var newManager = new Manager()
                {
                    UserId = newUser.IdUser,
                    Position = possition_u.Text
                };
            }

            db.Users.Add(newUser);
            db.SaveChanges();

            if (newUser.Role == "client")
            {
                var newClient = new Client()
                {
                    UserId = newUser.IdUser,
                    Money = int.Parse(money_u.Text)
                };
                db.Clients.Add(newClient);
                db.SaveChanges();
                MessageBox.Show("Client is successfully added!");
                return;
            }
            else if (newUser.Role == "manager")
            {
                if (String.IsNullOrEmpty(possition_u.Text))
                {
                    MessageBox.Show("Введите должность");
                    return;
                }
                textBoxes.Append(possition_u);
                var newManager = new Manager()
                {
                    UserId = newUser.IdUser,
                    Position = possition_u.Text,
                    Salary = int.Parse(money_u.Text)
                };
                db.Managers.Add(newManager);
                db.SaveChanges();
                MessageBox.Show("Manager is successfully added!");
                return;
            }
            ClearTextBoxes(textBoxes);
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window() ;
            if (_callerWindow == "user")
            {
                window = new UsersListWindow();
            }
            else if (_callerWindow == "manager")
            {
                window = new ManagersListWindow();
            }
            window.Show();
            this.Close();
        }
        private void ClearTextBoxes(TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
        }
    }
}
