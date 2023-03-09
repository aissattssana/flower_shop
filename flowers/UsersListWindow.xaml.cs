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
    /// Логика взаимодействия для UsersListWindow.xaml
    /// </summary>
    public partial class UsersListWindow : Window
    {
        private Client currentClient = new Client();
        private User currentUser = new User();
        FlowerShopdbContext db = new FlowerShopdbContext();
        public UsersListWindow()
        {
            InitializeComponent();
            InitDataGrid();
        }
        private void create_Click(object sender, RoutedEventArgs e)
        {
            var window = new CreateUserWindow("user");
            window.Show();
            this.Close();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            db.Clients.Remove(currentClient);
            db.Users.Remove(currentUser);
            db.SaveChanges();
            MessageBox.Show("Клиент удален");
            InitDataGrid();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            var window = new AdminWindow();
            window.Show();
            this.Close();
        }
        private void DataGridManagers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                currentUser = DataGridManagers.SelectedItem as User;
                currentClient = db.Clients.Where(x => x.UserId == currentUser.IdUser).First();
            }
            catch
            {
                return;
            }
        }

        private void InitDataGrid()
        {
            DataGridManagers.ItemsSource = db.Users.Where(x => x.Role == "client").ToList();
        }
    }
}
