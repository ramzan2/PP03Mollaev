using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PP03Mollaev.ClassFolder
{
    class CBClass
    {
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=DESKTOP-C30H7UE\SQLEXPRESS;
                                Initial Catalog=PP03Mollaev;
                                Integrated Security=True");
        SqlDataAdapter sqlData;
        DataSet dataSet;

        public void RoleCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlData = new SqlDataAdapter("Select PPRole, RoleTitle " +
                    "From dbo.[Roles] Order by PPRole ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[Roles]");
                comboBox.ItemsSource = dataSet.Tables["[Roles]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Roles]"].Columns["RoleTitle"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[Roles]"].Columns["PPRole"].ToString();
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
