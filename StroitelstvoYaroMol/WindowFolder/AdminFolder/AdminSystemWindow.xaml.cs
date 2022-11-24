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

        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            new AdminFolder.EditAdminWindow().ShowDialog();
        }
    }
}
