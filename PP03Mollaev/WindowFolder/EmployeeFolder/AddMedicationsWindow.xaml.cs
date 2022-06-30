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
    /// Логика взаимодействия для AddMedicationsWindow.xaml
    /// </summary>
    public partial class AddMedicationsWindow : Window
    {
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=DESKTOP-C30H7UE\SQLEXPRESS;
                                Initial Catalog=PP03Mollaev;
                                Integrated Security=True");
        SqlCommand SqlCommand;
        public AddMedicationsWindow()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new MenuEmployeeWindow().ShowDialog();
        }

        private void AddDescriptionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name.Text))
            {
                MBClass.ErrorMB("Не введено название лекарства");
                Name.Focus();
            }
            else if (string.IsNullOrWhiteSpace(Type.Text))
            {
                MBClass.ErrorMB("Не введен тип лекарства");
                Type.Focus();
            }
            else if (string.IsNullOrWhiteSpace(Composition.Text))
            {
                MBClass.ErrorMB("Не введен состав лекарства");
                Composition.Focus();
            }
            else if (string.IsNullOrWhiteSpace(Formofrelease.Text))
            {
                MBClass.ErrorMB("Не введена форма выпуска лекарства");
                Formofrelease.Focus();
            }
            else if (string.IsNullOrWhiteSpace(Packaging.Text))
            {
                MBClass.ErrorMB("Не введена упаковка лекарства");
                Packaging.Focus();
            }
            else if (string.IsNullOrWhiteSpace(characteristic.Text))
            {
                MBClass.ErrorMB("Не введена характеристика лекарства");
                characteristic.Focus();
            }
            else if (string.IsNullOrWhiteSpace(Indicationsforuse.Text))
            {
                MBClass.ErrorMB("Не введено показание к применению лекасртва");
                Indicationsforuse.Focus();
            }
            else if (string.IsNullOrWhiteSpace(ContraindicationsToUse.Text))
            {
                MBClass.ErrorMB("Не введёно противопоказания к применению лекарства");
                ContraindicationsToUse.Focus();
            }
            else if (string.IsNullOrWhiteSpace(HowToUse.Text))
            {
                MBClass.ErrorMB("Не введён способ применения лекарства");
                HowToUse.Focus();
            }
            else if (string.IsNullOrWhiteSpace(Dosage.Text))
            {
                MBClass.ErrorMB("Не введена дозировка лекарства");
                Dosage.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TermsOfDispensing.Text))
            {
                MBClass.ErrorMB("Не введены условия отпуска лекарства");
                TermsOfDispensing.Focus();
            }
            else if (string.IsNullOrWhiteSpace(manufacturer.Text))
            {
                MBClass.ErrorMB("Не введен производитель лекарства");
                manufacturer.Focus();
            }
            else if (string.IsNullOrWhiteSpace(ManufacturersAddress.Text))
            {
                MBClass.ErrorMB("Не введён адрес производителя лекарства");
                ManufacturersAddress.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TrademarkCertificate.Text))
            {
                MBClass.ErrorMB("Не введёно свидетельство на товарный знак лекарства");
                TrademarkCertificate.Focus();
            }
            else if (string.IsNullOrWhiteSpace(Series.Text))
            {
                MBClass.ErrorMB("Не введёна серия лекарства ");
                Series.Focus();
            }
            else if (string.IsNullOrWhiteSpace(ShelfLife.Text))
            {
                MBClass.ErrorMB("Не введён срок годности лекарства");
                ShelfLife.Focus();
            }
            else if (string.IsNullOrWhiteSpace(DateOfProduction.Text))
            {
                MBClass.ErrorMB("Не введёна дата производства лекарства ");
                DateOfProduction.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand = new SqlCommand("Insert Into" +
                        " dbo.[Stock] " +
                        "(Name,Type, " +
                        "Composition, Formofrelease, " +
                        "Packaging, characteristic," +
                        "Indicationsforuse, ContraindicationsToUse, " +
                        "HowToUse, Dosage,  " +
                        "TermsOfDispensing, manufacturer, " +
                        "ManufacturersAddress, TrademarkCertificate, " +
                        "Series, ShelfLife, " +
                        "DateOfProduction) Values " +
                        $"('{Name.Text}', " +
                        $"'{Type.Text}', " +
                        $"'{Composition.Text}', " +
                        $"'{Formofrelease.Text}', " +
                        $"'{Packaging.Text}', " +
                        $"'{characteristic.Text}', " +
                        $"'{Indicationsforuse.Text}', " +
                        $"'{ContraindicationsToUse.Text}', " +
                        $"'{HowToUse.Text}', " +
                        $"'{Dosage.Text}', " +
                        $"'{TermsOfDispensing.Text}', " +
                        $"'{manufacturer.Text}', " +
                        $"'{ManufacturersAddress.Text}', " +
                        $"'{TrademarkCertificate.Text}', " +
                        $"'{Series.Text}', " +
                        $"'{ShelfLife.Text}', " +
                        $"'{DateOfProduction.Text}')",
                        sqlConnection);
                    SqlCommand.ExecuteNonQuery();
                    MBClass.InfoMB($"Лекарство успешно добавлено");
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

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
