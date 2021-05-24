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

namespace Cinema_Ticket
{
    class Avtoris
    {
        static CinEntities1 db = new CinEntities1();
            static public void Autorisation(TextBox tbLog, PasswordBox pbPass, Window MainWindow)
        {
            if (String.IsNullOrEmpty(tbLog.Text) || String.IsNullOrEmpty(pbPass.Password))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {


                authorisation usr = db.authorisation.SingleOrDefault(c => c.Login == tbLog.Text);
                if (usr == null)
                {
                    MessageBox.Show("Такого пользователя не существует");
                    return;
                }
                Func f = new Func();
                if (f.CheckPassword(usr.Pass, f.GetHashPassword(pbPass.Password)))
                {
                    MessageBox.Show($"Здравствуйте, {usr.FirstName}");
                    PlaybillWindow PlaybillWindow = new PlaybillWindow();
                    PlaybillWindow.Show();
                    MainWindow.Hide();
                }
                else
                {
                    MessageBox.Show("Пароль неверный!");
                }

            }
        }

    }
}
