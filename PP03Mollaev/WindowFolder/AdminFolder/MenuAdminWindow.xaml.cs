using System;
using System.Collections.Generic;
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

namespace PP03Mollaev.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuAdminWindow.xaml
    /// </summary>
    public partial class MenuAdminWindow : Window
    {
        DGClass dGClass;
        public MenuAdminWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ListUserDG);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("Select * From dbo.[Users]");
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDG("Select * From dbo.[Users] " +
                $"Where PPUsers Like '%{SearchTb.Text}%' " +
                $"OR Login Like '%{SearchTb.Text}%'");
        }

        private void ListUserDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListUserDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                try
                {
                    VariableClass.UserId = dGClass.SelectId();
                    new EditUserWindow().ShowDialog();
                    dGClass.LoadDG("Select * From dbo.[Users]");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void AddIm_Click(object sender, RoutedEventArgs e)
        {
            new AddUserWindow().ShowDialog();
            dGClass.LoadDG("Select * From dbo.[Users]");
            Close();
        }

        private void EditIm_Click(object sender, RoutedEventArgs e)
        {
            new EditUserWindow().ShowDialog();
            dGClass.LoadDG("Select * From dbo.[Users]");
        }

        private void BackIm_Click(object sender, RoutedEventArgs e)
        {
            new MenuAdminWindow().ShowDialog();
        }

        private void ExitIm_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
