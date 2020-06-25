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
        public AddDiscount()
        {
            InitializeComponent();

            DataBaseClass.DataBase dataBase = new DataBaseClass.DataBase(DataBaseOption.dataBaseOption);

            technicComboBox.ItemsSource = dataBase.OutputAllTechnic();
            currentDiscountComboBox.ItemsSource = dataBase.OutputAllDiscount();

            dataBase.OutputTableDiscount(discountDataGrid);
        }

        private bool CheckRightDiscount()
        {
            bool check = true;

            int result;
            bool isInteger = Int32.TryParse(discountTextBox.Text, out result);

            bool isRightDiscount = (result > 0 && result < 100) && 
                (discountTextBox.Text[0] != '-' && discountTextBox.Text[0] != '0');

            if (!isInteger || !isRightDiscount)
                check = false;

            return check;
        }

        private bool CheckFullDiscount()
        {
            bool check = true;

            if(technicComboBox.SelectedIndex == -1)
            {
                check = false;

                firstObejctLabel.Visibility = Visibility.Visible;
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

        private void AddDiscountButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFullDiscount())
            {
                DataBaseClass.DataBase dataBase = new DataBaseClass.DataBase(DataBaseOption.dataBaseOption);

                if (dataBase.AddDiscount(technicComboBox.SelectedItem.ToString(), discountTextBox.Text))
                {
                    Tuple<string, int> tuple = new Tuple<string, int>
                        (technicComboBox.SelectedItem.ToString(), Convert.ToInt32(discountTextBox.Text));
             
                    discountDataGrid.Items.Clear();
                    currentDiscountComboBox.Items.Clear();

                    dataBase.OutputTableDiscount(discountDataGrid);
                    currentDiscountComboBox.ItemsSource = dataBase.OutputAllDiscount();

                    technicComboBox.SelectedIndex = -1;
                    discountTextBox.Text = "";
                }
                else
                {
                    bool isMessageResultAgree = MessageBox.Show
                        ("Скидка на этот товар существует. Изменить существующую скидку?", "Изменнение скидки",
                        MessageBoxButton.YesNo) == MessageBoxResult.Yes;

                    if (isMessageResultAgree)
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

            if (currentDiscountComboBox.SelectedIndex == -1)
            {
                check = false;

                secondObjectLabel.Visibility = Visibility.Visible;
                deleteToolTip.Visibility = Visibility.Visible;
            }

            return check;
        }

        private void DeleteDiscountButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFullProductDelete())
            {
                DataBaseClass.DataBase dataBase = new DataBaseClass.DataBase(DataBaseOption.dataBaseOption);

                dataBase.DeleteDiscount(currentDiscountComboBox.SelectedItem.ToString());

                discountDataGrid.Items.Clear();
                currentDiscountComboBox.Items.Clear();

                currentDiscountComboBox.ItemsSource = dataBase.OutputAllDiscount();
                dataBase.OutputTableDiscount(discountDataGrid);

                MessageBox.Show("        Удаление прошло успешно");
            }
        }

        private void DeleteAllDiscountButton_Click(object sender, RoutedEventArgs e)
        {
            bool isMessageResultAgree = MessageBox.Show
                        ("                    Удалить всё?", "Подтверждение операции",
                        MessageBoxButton.YesNo) == MessageBoxResult.Yes;

            if (isMessageResultAgree)
            {
                DataBaseClass.DataBase dataBase = new DataBaseClass.DataBase(DataBaseOption.dataBaseOption);

                dataBase.DeleteDiscount();

                currentDiscountComboBox.Items.Clear();
                discountDataGrid.Items.Clear();

                currentDiscountComboBox.ItemsSource = dataBase.OutputAllDiscount();
                dataBase.OutputTableDiscount(discountDataGrid);

                MessageBox.Show("        Удаление прошло успешно");
            }
        }

        private void technicComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            discountTextBox.Text = "";

            productToolTip.Visibility = Visibility.Hidden;
            firstObejctLabel.Visibility = Visibility.Hidden;
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

        private void currentDiscountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            deleteToolTip.Visibility = Visibility.Hidden;
            secondObjectLabel.Visibility = Visibility.Hidden;
        }
    }
}
