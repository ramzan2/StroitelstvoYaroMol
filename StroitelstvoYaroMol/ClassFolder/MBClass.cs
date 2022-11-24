﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StroitelstvoYaroMol.ClassFolder
{
    class MBClass
    {
        public static void ErrorMB(Exception exception)
        {
            MessageBox.Show(exception.Message, "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        public static void ErrorMB(string text)
        {
            MessageBox.Show(text, "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        public static void InformationMB(string text)
        {
            MessageBox.Show(text, "Информация",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
        public static bool QuestionMB(string text)
        {
            return MessageBoxResult.Yes ==
                MessageBox.Show(text, "Вопрос",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
        }
        public static void ExitMB(string text)
        {
            bool result = QuestionMB("Вы действительно хотите " +
                "выйти?");
            if (result == true)
            {
                App.Current.Shutdown();
            }
        }
    }
}
