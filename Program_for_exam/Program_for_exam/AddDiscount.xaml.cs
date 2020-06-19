using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
    /// Логика взаимодействия для AddDiscount.xaml
    /// </summary>
    public partial class AddDiscount : Window
    {
        private string _dataBaseOption = "server = 127.0.0.1; user = root; database = market";

        public AddDiscount()
        {
            InitializeComponent();

            DataBase dataBase = new DataBase(_dataBaseOption);
            dataBase.OutputAllTechnic(technicComboBox);
            dataBase.OutputTableDiscount(discountDataGrid);
            dataBase.OutputAllDiscount(currentDiscount);
        }

        private bool CheckRightDiscount()
        {
            bool check = true;

            int result;
            bool isInt = Int32.TryParse(discountTextBox.Text, out result);

            bool rightDiscount = (result > 0 && result < 100) && 
                (discountTextBox.Text[0] != '-' && discountTextBox.Text[0] != '0');

            if (!isInt || !rightDiscount)
                check = false;

            return check;
        }

        private bool CheckFullDiscount()
        {
            bool check = true;

            if(technicComboBox.SelectedIndex == -1)
            {
                check = false;

                firstObejct.Visibility = Visibility.Visible;
                productToolTip.Visibility = Visibility.Visible;
            }

            if(discountTextBox.Text=="" || !CheckRightDiscount())
            {
                check = false;

                discountTextBox.BorderBrush = Brushes.Red;
                discountToolTip.Visibility = Visibility.Visible;
            }

            return check;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFullDiscount())
            {
                DataBase dataBase = new DataBase(_dataBaseOption);

                if (dataBase.AddDiscount(technicComboBox.SelectedItem.ToString(), discountTextBox.Text))
                {
                    Tuple<string, int> tuple = new Tuple<string, int>
                        (technicComboBox.SelectedItem.ToString(), Convert.ToInt32(discountTextBox.Text));
             
                    discountDataGrid.Items.Clear();
                    currentDiscount.Items.Clear();
                    dataBase.OutputTableDiscount(discountDataGrid);
                    dataBase.OutputAllDiscount(currentDiscount);

                    technicComboBox.SelectedIndex = -1;
                    discountTextBox.Text = "";
                }

                else
                {
                    bool messageResult = MessageBox.Show
                        ("Скидка на этот товар существует. Изменить существующую скидку?", "Изменнение скидки",
                        MessageBoxButton.YesNo) == MessageBoxResult.Yes;

                    if (messageResult)
                    {
                        dataBase.UpdateDiscount(technicComboBox.SelectedItem.ToString(), discountTextBox.Text);

                        discountDataGrid.Items.Clear();
                        dataBase.OutputTableDiscount(discountDataGrid);

                        technicComboBox.SelectedIndex = -1;
                        discountTextBox.Text = "";
                    }
                }
            }
        }

        private bool CheckFullProductDelete()
        {
            bool check = true;

            if (currentDiscount.SelectedIndex == -1)
            {
                check = false;

                secondObject.Visibility = Visibility.Visible;
                deleteToolTip.Visibility = Visibility.Visible;
            }

            return check;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CheckFullProductDelete())
            {
                DataBase dataBase = new DataBase(_dataBaseOption);

                dataBase.DeleteDiscount(currentDiscount.SelectedItem.ToString());

                discountDataGrid.Items.Clear();
                currentDiscount.Items.Clear();

                dataBase.OutputAllDiscount(currentDiscount);
                dataBase.OutputTableDiscount(discountDataGrid);

                MessageBox.Show("        Удаление прошло успешно");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            bool messageResult = MessageBox.Show
                        ("                    Удалить всё?", "Подтверждение операции",
                        MessageBoxButton.YesNo) == MessageBoxResult.Yes;

            if (messageResult)
            {
                DataBase dataBase = new DataBase(_dataBaseOption);

                dataBase.DeleteDiscount();

                currentDiscount.Items.Clear();
                discountDataGrid.Items.Clear();

                dataBase.OutputAllDiscount(currentDiscount);
                dataBase.OutputTableDiscount(discountDataGrid);

                MessageBox.Show("        Удаление прошло успешно");
            }
        }

        private void technicComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            discountTextBox.Text = "";
            productToolTip.Visibility = Visibility.Hidden;
            firstObejct.Visibility = Visibility.Hidden;
        }

        private void discountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            discountTextBox.BorderBrush = brush;

            discountToolTip.Visibility = Visibility.Hidden;

            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                (
                textBox.Text.Where
                (symb =>
                (symb >= '0' && symb <= '9'))
                .ToArray()
                );
            }
        }

        private void currentDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            deleteToolTip.Visibility = Visibility.Hidden;
            secondObject.Visibility = Visibility.Hidden;
        }
    }
}
