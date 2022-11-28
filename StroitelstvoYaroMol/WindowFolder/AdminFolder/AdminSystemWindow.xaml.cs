using StroitelstvoYaroMol.ClassFolder;
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

namespace StroitelstvoYaroMol.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AdminSystemWindow.xaml
    /// </summary>
    public partial class AdminSystemWindow : Window
    {
        DGClass dGClass;
        public AdminSystemWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(UserDG);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            dGClass.LoadDG("SELECT * FROM dbo.UserView ");
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDG("SELECT * FROM dbo.UserView " +
              $"Where LoginUser Like '%{SearchTb.Text}%'");
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            new AdminFolder.AddAdminWindow().ShowDialog();
            dGClass.LoadDG("Select * From dbo.[UserView]");
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            new AdminFolder.EditAdminWindow().ShowDialog();
            dGClass.LoadDG("Select * From dbo.[UserView]");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (UserDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                try
                {
                    VariableClass.UserId = dGClass.SelectId();
                    new EditAdminWindow().ShowDialog();
                    dGClass.LoadDG("Select * From dbo.[UserView]");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
