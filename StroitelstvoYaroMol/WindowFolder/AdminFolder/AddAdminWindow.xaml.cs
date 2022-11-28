using StroitelstvoYaroMol.ClassFolder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace StroitelstvoYaroMol.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AddAdminWindow.xaml
    /// </summary>
    public partial class AddAdminWindow : Window
    {
        CBClass cB;
        SqlConnection sqlConnection =
          new SqlConnection(@"Data Source=DESKTOP-C30H7UE\SQLEXPRESS;
                   Initial Catalog=user1;
                                Integrated Security=True");
        SqlCommand sqlCommand;
        public AddAdminWindow()
        {
            InitializeComponent();
            cB = new CBClass();
        }


        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {


            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MBClass.ErrorMB("Не введен логин");
                LoginTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordTb.Text))
            {
                MBClass.ErrorMB("Не введен пароль");
                PasswordTb.Focus();
            }
            else if (RoleCb.SelectedIndex < 0)
            {
                MBClass.ErrorMB("Выберите роль");
                RoleCb.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert Into " +
                        "dbo.[user] (Login, Password, IdRole) " +
                        $"Values ('{LoginTb.Text}', " +
                        $"'{PasswordTb.Text}'," +
                        $"'{RoleCb.SelectedValue.ToString()}')", 
                        sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MBClass.InformationMB("Успех!");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cB.LoadCBRole(RoleCb);
        }
    }
}
