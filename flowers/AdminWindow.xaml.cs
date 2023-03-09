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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }
        private void managers_Click(object sender, RoutedEventArgs e)
        {
            var window = new ManagersListWindow();
            window.Show();
            this.Close();
        }

        private void clients_Click(object sender, RoutedEventArgs e)
        {
            var window = new UsersListWindow();
            window.Show();
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            var window = new LoginWindow();
            window.Show();
            this.Close();
        }
    }
}
