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

namespace StroitelstvoYaroMol.WindowFolder.StaffFolder
{
    /// <summary>
    /// Логика взаимодействия для AddStaffWindow.xaml
    /// </summary>
    public partial class AddStaffWindow : Window
    {
        CBClass cB;
        SqlConnection sqlConnection =
         new SqlConnection(@"Data Source=DESKTOP-C30H7UE\SQLEXPRESS;
                                Initial Catalog=user1;
                                Integrated Security=True");
        SqlCommand SqlCommand;
        public AddStaffWindow()
        {
            InitializeComponent();
            cB = new CBClass();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddDescriptionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(HouseNumberTb.Text))
            {
                MBClass.ErrorMB("Не введен номер дома");
                HouseNumberTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(NumberTB.Text))
            {
                MBClass.ErrorMB("Не введен тип лекарства");
                NumberTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TotalAreaTb.Text))
            {
                MBClass.ErrorMB("Не введен состав лекарства");
                TotalAreaTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(LivingAreaTb.Text))
            {
                MBClass.ErrorMB("Не введена форма выпуска лекарства");
                LivingAreaTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(NumberOfRoomsTb.Text))
            {
                MBClass.ErrorMB("Не введена упаковка лекарства");
                NumberOfRoomsTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(CostTb.Text))
            {
                MBClass.ErrorMB("Не введена характеристика лекарства");
                CostTb.Focus();
            }
            else if (JKCb.SelectedIndex < 0)
            {
                MBClass.ErrorMB("Выберите ЖК");
                JKCb.Focus();
            }
            else if (StatusCb.SelectedIndex < 0)
            {
                MBClass.ErrorMB("Выберите роль");
                StatusCb.Focus();
            }

            else
            {
                try
                {
                    
                    sqlConnection.Open();
                    SqlCommand = new SqlCommand("Insert Into" +
                      " dbo.[Flat] " +
                      "(HouseNumber,Number, " +
                      "TotalArea, LivingArea, " +
                      "NumberOfRooms, Cost," +
                      "IdStatus, IdJK) Values " +
                      $"('{HouseNumberTb.Text}', " +
                      $"'{NumberTB.Text}', " +
                      $"'{TotalAreaTb.Text}', " +
                      $"'{LivingAreaTb.Text}', " +
                      $"'{NumberOfRoomsTb.Text}', " +
                      $"'{CostTb.Text}', " +
                      $"'{JKCb.SelectedValue.ToString()}', " +
                      $"'{StatusCb.SelectedValue.ToString()}')",
                      sqlConnection);
                    SqlCommand.ExecuteNonQuery();
                    MBClass.InformationMB($"Заказ успешно добавлен");
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
            cB.LoadCBStatus(StatusCb);
            cB.LoadCBJK(JKCb);
        }
    }
}
