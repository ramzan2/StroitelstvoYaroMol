using StroitelstvoYaroMol.ClassFolder;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для EditAdminWindow.xaml
    /// </summary>
    public partial class EditAdminWindow : Window
    {
        CBClass cBClass;
        SqlConnection sqlConnection =
          new SqlConnection(@"Data Source=DESKTOP-C30H7UE\SQLEXPRESS;
                   Initial Catalog=user1;
                                Integrated Security=True");
        SqlCommand SqlCommand;
        SqlDataReader dataReader;
        public EditAdminWindow()
        {
            InitializeComponent();
            cBClass =  new CBClass();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cBClass.LoadCBRole(RoleCb);
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Select * from dbo.[user] " +
                $"Where UserId='{VariableClass.UserId}'",
                sqlConnection);
                dataReader = SqlCommand.ExecuteReader();
                dataReader.Read();
                LoginTb.Text = dataReader[1].ToString();
                PasswordTb.Text = dataReader[2].ToString();
                RoleCb.SelectedValue = dataReader[3].ToString();
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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Update " +
                    " dbo.[user] " +
                    $"Set [Login]  ='{LoginTb.Text}', " +
                    $"[Password] ='{PasswordTb.Text}', " +
                    $"IdRole = '{RoleCb.SelectedValue.ToString()}' " +
                    $"Where UserId='{VariableClass.UserId}'",
                    sqlConnection);
                SqlCommand.ExecuteNonQuery();
                MBClass.InformationMB($"Данные пользователя успешно отредактированы");
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

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
