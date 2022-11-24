﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StroitelstvoYaroMol
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string ConnectionBD()
        {
            string connectionString = ConfigurationManager.
                ConnectionStrings["ConnectionDB"].ConnectionString;
            return connectionString;
        }
    }
}
