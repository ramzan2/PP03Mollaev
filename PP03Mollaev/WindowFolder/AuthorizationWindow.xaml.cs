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
using PP03Mollaev.ClassFolder;

namespace PP03Mollaev.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(@"Data Source=DESKTOP-C30H7UE\SQLEXPRESS;
                                Initial Catalog=PP03Mollaev;
                                Integrated Security=True");
        SqlCommand SqlCommand;
        SqlDataReader dataReader;

        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LogInBth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MBClass.ErrorMB("Некоректный логин");
                LoginTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordPsb.Password))
            {
                MBClass.ErrorMB("Некоректный пароль");
                PasswordPsb.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand = new SqlCommand("Select Login, Password, IDRoles " +
                        "From dbo.[Users] " +
                        $"Where Login='{LoginTb.Text}'",
                        sqlConnection);
                    dataReader = SqlCommand.ExecuteReader();
                    dataReader.Read();

                    if (dataReader[1].ToString() != PasswordPsb.Password)
                    {
                        MBClass.ErrorMB("Введеный пароль не коректен");
                        PasswordPsb.Focus();
                    }
                    else
                    {
                        switch (dataReader[2].ToString())
                        {
                            case "1":
                                new AdminFolder.
                                    MenuAdminWindow().ShowDialog();
                                this.Close();
                                break;

                            case "2":
                                new EmployeeFolder.
                                    MenuEmployeeWindow().ShowDialog();
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

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().Show();
            Close();
        }

        private void LogOutBth_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}

