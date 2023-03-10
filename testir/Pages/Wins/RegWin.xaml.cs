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
    /// Логика взаимодействия для RegWin.xaml
    /// </summary>
    public partial class RegWin : Window
    {
        public RegWin()
        {
            InitializeComponent();
        }
        private void RegBTN_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
                if (login.Length > 0)
                {
                    try
                    {
                        User user = new User()
                        {
                            login = login,
                            password = password,
                        };
                        dbConnect.db.User.Add(user);
                        dbConnect.db.SaveChanges();
                        MessageBox.Show("Регистрация прошла успешно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                LogWin authWin = new LogWin();
                authWin.Show();
                Close();
        }
        private void GoAuthBTN_Click(object sender, RoutedEventArgs e)
        {
            LogWin authWin = new LogWin();
            authWin.Show();
            Close();
        }
    }
}
