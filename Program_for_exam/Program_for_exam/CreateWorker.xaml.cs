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

namespace Program_for_exam
{
    /// <summary>
    /// Логика взаимодействия для CreateWorker.xaml
    /// </summary>
    public partial class CreateWorker : Window
    {
        private string _dataBaseOption = "server = 127.0.0.1; user = root; database = market";

        public CreateWorker()
        {
            InitializeComponent();

            DataBase dataBase = new DataBase(_dataBaseOption);
            dataBase.OutputTableStaff(staffTable);

            string[] staff = {"Продавец-консультант", "Менеджер", "Кассир" };

            staffComboBox.ItemsSource = staff;
        }

        private bool CheckFullInfo()
        {
            bool check = true;

            if (firstName.Text == "")
            {
                firstNameToolTip.Visibility = Visibility.Visible;
                firstName.BorderBrush = Brushes.Red;
                check = false;
            }

            if (secondName.Text == "")
            {
                secondNameToolTip.Visibility = Visibility.Visible;
                secondName.BorderBrush = Brushes.Red;
                check = false;
            }

            if (middleName.Text == "")
            {
                middleNameToolTip.Visibility = Visibility.Visible;
                middleName.BorderBrush = Brushes.Red;
                check = false;
            }

            if (staffComboBox.SelectedIndex == -1)
            {
                firstObject.Visibility = Visibility.Visible;
                staffToolTip.Visibility = Visibility.Visible;
                check = false;
            }

            return check;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBase dataBase = new DataBase(_dataBaseOption);

            if (CheckFullInfo())
            {
                if (dataBase.CheckFullStaff(secondName, firstName, middleName, staffComboBox.SelectedItem.ToString()))
                {
                    MessageBox.Show("Такой работник уже записан");
                }
                else
                {
                    dataBase.CreateNewWorker(secondName,firstName, middleName, staffComboBox.SelectedItem.ToString());
                    MessageBox.Show("Уcпешно создан");
                    dataBase.OutputTableStaff(staffTable);
                }

                firstName.Clear();
                secondName.Clear();
                middleName.Clear();
                staffComboBox.SelectedIndex = -1;
            }
        }

        private void staffComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            firstObject.Visibility = Visibility.Hidden;
            staffToolTip.Visibility = Visibility.Hidden;
        }

        private void middleName_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            middleName.BorderBrush = brush;

            middleNameToolTip.Visibility = Visibility.Hidden;
        }

        private void firstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            firstName.BorderBrush = brush;

            firstNameToolTip.Visibility = Visibility.Hidden;
        }

        private void secondName_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            secondName.BorderBrush = brush;

            secondNameToolTip.Visibility = Visibility.Hidden;
        }
    }
}
