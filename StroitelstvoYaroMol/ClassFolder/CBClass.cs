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
    class CBClass
    {
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=DESKTOP-C30H7UE\SQLEXPRESS;
                   Initial Catalog=user1;
                                Integrated Security=True");
        SqlDataAdapter sqlDataAdapter;
        DataSet dataSet;

        public void LoadCBRole(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter("Select IdRole, RoleName " +
                    "From dbo.[Role] Order by IdRole ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "[Role]");
                comboBox.ItemsSource = dataSet
                    .Tables["[Role]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet
                    .Tables["[Role]"].Columns["RoleName"].ToString();
                comboBox.SelectedValuePath = dataSet
                    .Tables["[Role]"].Columns["IdRole"].ToString();
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
        public void LoadCBStatus(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter("Select IdStatus, StatusName " +
                    "From dbo.[Status] Order by Id ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "[Status]");
                comboBox.ItemsSource = dataSet
                    .Tables["[Status]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet
                    .Tables["[Status]"].Columns["StatusName"].ToString();
                comboBox.SelectedValuePath = dataSet
                    .Tables["[Status]"].Columns["IdStatus"].ToString();
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
