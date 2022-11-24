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
        SqlConnection sqlConnection =
          new SqlConnection(@"Data Source=DESKTOP-C30H7UE\SQLEXPRESS;
                   Initial Catalog=user1;
                                Integrated Security=True");
        SqlCommand sqlCommand;
        CBClass cBClass;
        public AddAdminWindow()
        {
            InitializeComponent();
            cBClass = new CBClass();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cBClass.LoadCBRole(RoleCb);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RoleCb.SelectedIndex < 0)
            {
                MBClass.ErrorMB("Выберите роль");

            }
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert Into " +
                    "ddbo.[user] (Login, Password, IdRole) " +
                    $"Values ({LoginTb.Text},{PasswordTb.Text}, " +
                    $"{RoleCb.SelectedValue.ToString()})", sqlConnection);
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
}
