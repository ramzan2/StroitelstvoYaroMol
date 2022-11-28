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

namespace StroitelstvoYaroMol.WindowFolder.StaffFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuStaffWindow.xaml
    /// </summary>
    public partial class MenuStaffWindow : Window
    {
        DGClass dGClass;
        public MenuStaffWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(StaffDG);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("Select * From dbo.[FlatView]");
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UserDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            new AddStaffWindow().ShowDialog();
            dGClass.LoadDG("Select * From dbo.[FlatView]");
            Close();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
