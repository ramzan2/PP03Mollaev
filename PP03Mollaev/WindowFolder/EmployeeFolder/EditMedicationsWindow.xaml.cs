using PP03Mollaev.ClassFolder;
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

namespace PP03Mollaev.WindowFolder.EmployeeFolder
{
    /// <summary>
    /// Логика взаимодействия для EditMedicationsWindow.xaml
    /// </summary>
    public partial class EditMedicationsWindow : Window
    {
        SqlConnection sqlConnection =
          new SqlConnection(@"Data Source=DESKTOP-C30H7UE\SQLEXPRESS;
                                Initial Catalog=PP03Mollaev;
                                Integrated Security=True");
        SqlCommand SqlCommand;
        SqlDataReader dataReader;
        public EditMedicationsWindow()
        {
            InitializeComponent();
        }

   

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Select * from dbo.[Stock] " +
                $"Where PP='{VariableClass.UserId}'",
                sqlConnection);
                dataReader = SqlCommand.ExecuteReader();
                dataReader.Read();
                Name.Text = dataReader[1].ToString();
                Type.Text = dataReader[2].ToString();
                Composition.Text = dataReader[3].ToString();
                Formofrelease.Text = dataReader[4].ToString();
                Packaging.Text = dataReader[5].ToString();
                characteristic.Text = dataReader[6].ToString();
                Indicationsforuse.Text = dataReader[7].ToString();
                ContraindicationsToUse.Text = dataReader[8].ToString();
                HowToUse.Text = dataReader[9].ToString();
                Dosage.Text = dataReader[10].ToString();
                TermsOfDispensing.Text = dataReader[11].ToString();
                manufacturer.Text = dataReader[12].ToString();
                ManufacturersAddress.Text = dataReader[13].ToString();
                TrademarkCertificate.Text = dataReader[14].ToString();
                Series.Text = dataReader[16].ToString();
                ShelfLife.Text = dataReader[16].ToString();
                DateOfProduction.Text = dataReader[17].ToString();
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

        private void AddDescriptionBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Update " +
                    " dbo.[Stock] " +
                    $"Set Name ='{Name.Text}', " +
                    $"Type ='{Type.Text}', " +
                    $"Composition ='{Composition.Text}', " +
                    $"Formofrelease ='{Formofrelease.Text}', " +
                    $"Packaging ='{Packaging.Text}', " +
                    $"characteristic ='{characteristic.Text}', " +
                    $"Indicationsforuse ='{Indicationsforuse.Text}', " +
                    $"ContraindicationsToUse ='{ContraindicationsToUse.Text}', " +
                    $"HowToUse ='{HowToUse.Text}', " +
                    $"Dosage ='{Dosage.Text}', " +
                    $"TermsOfDispensing ='{TermsOfDispensing.Text}', " +
                    $"manufacturer ='{manufacturer.Text}', " +
                    $"ManufacturersAddress ='{ManufacturersAddress.Text}', " +
                    $"TrademarkCertificate ='{TrademarkCertificate.Text}', " +
                    $"Series ='{Series.Text}', " +
                    $"ShelfLife ='{ShelfLife.Text}', " +
                    $"DateOfProduction ='{DateOfProduction.Text}' " +
                    $"Where PP='{VariableClass.UserId}'",
                    sqlConnection);
                SqlCommand.ExecuteNonQuery();
                MBClass.InfoMB($"Данные лекарства успешно отредактированы");
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

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new MenuEmployeeWindow().ShowDialog();
        }
    }
}
