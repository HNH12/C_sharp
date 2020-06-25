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

        public CreateWorker()
        {
            InitializeComponent();

            DataBaseClass.DataBase dataBase = new DataBaseClass.DataBase(DataBaseOption.dataBaseOption);
            dataBase.staffDataBase.OutputTableStaff(staffTableDataGrid);

            string[] staff = {"Продавец-консультант", "Менеджер", "Кассир" };

            staffComboBox.ItemsSource = staff;
        }

        private bool CheckFullInfo()
        {
            bool check = true;

            if (firstNameTextBox.Text == "")
            {
                firstNameToolTip.Visibility = Visibility.Visible;
                firstNameTextBox.BorderBrush = Brushes.Red;

                check = false;
            }

            if (secondNameTextBox.Text == "")
            {
                secondNameToolTip.Visibility = Visibility.Visible;
                secondNameTextBox.BorderBrush = Brushes.Red;

                check = false;
            }

            if (middleNameTextBox.Text == "")
            {
                middleNameToolTip.Visibility = Visibility.Visible;
                middleNameTextBox.BorderBrush = Brushes.Red;

                check = false;
            }

            if (staffComboBox.SelectedIndex == -1)
            {
                firstObjectLabel.Visibility = Visibility.Visible;
                staffToolTip.Visibility = Visibility.Visible;

                check = false;
            }

            return check;
        }

        private void OnlyLetter(object sender)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                (
                textBox.Text.Where
                (ch =>
                (ch >= 'а' && ch <= 'я')
                || (ch >= 'А' && ch <= 'Я')
                || ch == 'ё' || ch == 'Ё' || ch == ' ' || ch == '-')
                .ToArray()
                );
            }
        }

        private void AddWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseClass.DataBase dataBase = new DataBaseClass.DataBase(DataBaseOption.dataBaseOption);

            if (CheckFullInfo())
            {
                bool isExistWorker = dataBase.staffDataBase.CheckFullStaff(secondNameTextBox.Text, firstNameTextBox.Text, middleNameTextBox.Text,
                    staffComboBox.SelectedItem.ToString());

                if (isExistWorker)
                    MessageBox.Show("Такой работник уже записан");
                
                else
                {
                    dataBase.staffDataBase.CreateNewWorker(secondNameTextBox.Text, firstNameTextBox.Text, middleNameTextBox.Text, 
                        staffComboBox.SelectedItem.ToString());

                    MessageBox.Show("Уcпешно создан");

                    dataBase.staffDataBase.OutputTableStaff(staffTableDataGrid);
                }

                firstNameTextBox.Clear();
                secondNameTextBox.Clear();
                middleNameTextBox.Clear();

                staffComboBox.SelectedIndex = -1;
            }
        }

        private void staffComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            firstObjectLabel.Visibility = Visibility.Hidden;
            staffToolTip.Visibility = Visibility.Hidden;
        }

        private void middleNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            middleNameTextBox.BorderBrush = brush;

            middleNameToolTip.Visibility = Visibility.Hidden;

            OnlyLetter(sender);
        }

        private void firstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            firstNameTextBox.BorderBrush = brush;

            firstNameToolTip.Visibility = Visibility.Hidden;

            OnlyLetter(sender);
        }

        private void secondNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            secondNameTextBox.BorderBrush = brush;

            secondNameToolTip.Visibility = Visibility.Hidden;

            OnlyLetter(sender);
        }
    }
}
