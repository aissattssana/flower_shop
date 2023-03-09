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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
		FlowerShopdbContext db = new FlowerShopdbContext();
		private void entr_Click(object sender, RoutedEventArgs e)
		{
            if (login.Text == " " || password.Password == " ")
            {
                MessageBox.Show("Введите все данные!!");
                return;
            }

            foreach (User user in db.Users)
            {
                if (user.Login == login.Text && user.Password == password.Password)
                {
                    if (user.Role == "admin")
                    {
                        var window = new AdminWindow();
                        window.Show();
                        this.Close();
                        MessageBox.Show("Успешная авторизация");
                    }
                    if (user.Role == "client")
                    {
                        var window = new CatalogWindow();
                        window.Show();
                        this.Close();
                        MessageBox.Show("Успешная авторизация");
                    }
                }
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {

        }
        private void pass_Click(object sender, RoutedEventArgs e)
        {
            var pas = new PasswordRestorationWindow();
            pas.Show();
            this.Close();
        }
    }
}
