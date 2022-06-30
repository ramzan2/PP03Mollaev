using PP03Mollaev.ClassFolder;
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

namespace PP03Mollaev.WindowFolder.EmployeeFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuEmployeeWindow.xaml
    /// </summary>
    public partial class MenuEmployeeWindow : Window
    {
        DGClass dGClass;
        public MenuEmployeeWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ListUserDG);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("Select * From dbo.[Stock]");
        }

        private void AddIm_Click(object sender, RoutedEventArgs e)
        {
            new AddMedicationsWindow().ShowDialog();
            dGClass.LoadDG("Select * From dbo.[Stock]");
            Close();
        }

        private void EditIm_Click(object sender, RoutedEventArgs e)
        {
            new EditMedicationsWindow().ShowDialog();
            dGClass.LoadDG("Select * From dbo.[Stock]");
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDG("Select * From dbo.[Stock] " +
              $"Where PP Like '%{SearchTb.Text}%' " +
              $"OR Name Like '%{SearchTb.Text}%'");
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
                    new EditMedicationsWindow().ShowDialog();
                    dGClass.LoadDG("Select * From dbo.[Stock]");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void ExitIm_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
