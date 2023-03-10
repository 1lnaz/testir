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
using testir.Components;

namespace testir.Pages.Wins
{
    /// <summary>
    /// Логика взаимодействия для LogWin.xaml
    /// </summary>
    public partial class LogWin : Window
    {
        public LogWin()
        {
            InitializeComponent();
            PasswordBox.Password = Properties.Settings.Default.Password;
            LoginBox.Text = Properties.Settings.Default.Login;
        }

        private void GoRegBTN_Click(object sender, RoutedEventArgs e)
        {
            RegWin regWin = new RegWin();
            regWin.Show();
            Close();
        }
        private void RememberMeBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {

            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
            Navigation.AuthUser = dbConnect.db.User.ToList().Find(x => x.login == login && x.password == password);
            if (Navigation.AuthUser == null)
            {
                MessageBox.Show("Такого пользователя нет", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (RememberMeBox.IsChecked == true)
                {
                    Properties.Settings.Default.Password = PasswordBox.Password;
                    Properties.Settings.Default.Login = LoginBox.Text;
                    Properties.Settings.Default.Save();

                }
                else
                {
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.Login = "";
                    Properties.Settings.Default.Save();
                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }




        }
        public LogWin (object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Login != String.Empty)
            {
                LoginBox.Text = Properties.Settings.Default.Login;
            }
        }
    }
}