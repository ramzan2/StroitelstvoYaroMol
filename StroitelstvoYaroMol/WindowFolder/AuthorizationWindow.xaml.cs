﻿using StroitelstvoYaroMol.ClassFolder;
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

namespace StroitelstvoYaroMol.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=DESKTOP-C30H7UE\SQLEXPRESS;
                   Initial Catalog=user1;
                                Integrated Security=True");
        SqlDataReader dataReader;
        SqlCommand sqlCommand;
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordTb.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordTb.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("SELECT Password, IdRole " +
                        "From dbo.[user] " +
                        $"Where Login='{LoginTb.Text}'", sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();

                    if (dataReader[0].ToString() != PasswordTb.Password)
                    {
                        MBClass.ErrorMB("Вы ввели не правильный пароль");
                        PasswordTb.Focus();
                    }
                    else
                    {
                        switch (dataReader[1].ToString())
                        {
                            case "1":
                                new AdminFolder.AdminSystemWindow().ShowDialog();
                                break;
                            case "2":
                                MBClass.InformationMB("Менеджер");
                                break;
                            case "3":
                                new StaffFolder.MenuStaffWindow().ShowDialog();
                                break;
                        }
                    }
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

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().ShowDialog();
        }
    }
}
