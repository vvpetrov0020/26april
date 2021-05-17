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

namespace ISP11_17_Galimova_Petrov_26_april
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        



        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var user = Classes.ClassEntities.context.Person.ToList().Where(i => i.Login == txtLogin.Text && i.Password == txtPassword.Password).FirstOrDefault();
            if (user != null)
            {
                switch (user.IdRole)
                {
                    case 1:
                        this.Hide();
                        Windows.AdminWindow adminWindow = new Windows.AdminWindow();
                        adminWindow.ShowDialog();
                        this.Show();
                        break;

                    case 2:
                        this.Hide();
                        Windows.UserWindow userWindow = new Windows.UserWindow();
                        userWindow.ShowDialog();
                        this.Show();
                        break;

                    case 3:
                        this.Hide();
                        Windows.ManagerWindow managerWindow = new Windows.ManagerWindow();
                        managerWindow.ShowDialog();
                        this.Show();
                        break;

                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }
    }
}
