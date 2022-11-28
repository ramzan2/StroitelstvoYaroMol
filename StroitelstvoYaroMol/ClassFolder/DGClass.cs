using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StroitelstvoYaroMol.ClassFolder
{
    class DGClass
    {
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=DESKTOP-C30H7UE\SQLEXPRESS;
                   Initial Catalog=user1;
                                Integrated Security=True");
        SqlDataAdapter sqlDataAdapter;
        DataGrid dataGrid;
        DataTable dataTable;

        public DGClass(DataGrid dataGrid)
        {
            this.dataGrid = dataGrid;
        }

        public void LoadDG(string sqlComand)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter =
                    new SqlDataAdapter(sqlComand, sqlConnection);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
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

        public string SelectId()
        {
            //объявляем пустой массива тип которого object 
            object[] mass = null;
            //объявляем пустую переменную типа string,
            //которую будем возвращать в методе
            string id = "";
            try
            {
                //если DataGrid не пустой
                if (dataGrid != null)
                {
                    //Объявляем переменную типа DataRowView и
                    //записываем строку из dataGrid, который входит в DataView.
                    //DataView представляет связанное представление
                    //соответствующего DataTable
                    DataRowView dataRowView = dataGrid.SelectedItem
                        as DataRowView;
                    //если dataRowView не пустой
                    if (dataRowView != null)
                    {
                        //объявляем переменную типа DataRow, который
                        //необходим для извлечения и оценки данных
                        DataRow dataRow = (DataRow)dataRowView.Row;
                        //записываем в массив полученную строку
                        mass = dataRow.ItemArray;
                    }
                }
                //получаем из массива нулевую ячейку
                id = mass[0].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            //возвращаем полученные данные при обращении к массиву
            return id;
        }
    }
}
