using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Логика взаимодействия для addSale.xaml
    /// </summary>
    public partial class addSale : Window
    {
        private string _dataBaseOption = "server = 127.0.0.1; user = root; database = market";

        public addSale(int selectedIndex, DataGrid salesTable)
        {
            InitializeComponent();

            DataBase dataBase = new DataBase(_dataBaseOption);
            dataBase.GetStaff(workersListComboBox);
            dataBase.OutputProduct(productComboBox);

            this.selectedIndex = selectedIndex;
            this.salesTable = salesTable;
        }

        int selectedIndex = new int();
        DataGrid salesTable;

        private (string,string,string,string) GetWorkerInformation()
        {
            string secondName = "", firstName = "", 
                middleName = "", position = "";

            string information = workersListComboBox.SelectedItem.ToString();
            int length = information.Length;
            int countSpace = new int();

            for (int i = 0; i < length; i++)
            {
                if (information[i] == ' ' && countSpace < 3)
                    countSpace++;

                else
                {
                    switch (countSpace)
                    {
                        case 0:
                            secondName += information[i];
                            break;
                        case 1:
                            firstName += information[i];
                            break;
                        case 2:
                            middleName += information[i];
                            break;
                        case 3:
                            position += information[i];
                            break;
                    }
                }
            }

            return (secondName, firstName, middleName, position);
        }

        private bool CheckFullSale()
        {
            bool check = true;
            
            if (productComboBox.SelectedIndex==-1)
            {
                check = false;
                firstObject.Visibility = Visibility.Visible;
                productToolTip.Visibility = Visibility.Visible;
            }

            if (workersListComboBox.SelectedIndex==-1)
            {
                check = false;
                secondObject.Visibility = Visibility.Visible;
                nameWorkerToolTip.Visibility = Visibility.Visible;
            }

            return check;
        }

        private bool CheckFullAddress()
        {
            bool check = true;

            if (countryTextBox.Text=="")
            {
                check = false;
                countryTextBox.BorderBrush = Brushes.Red;
                countryToolTip.Visibility = Visibility.Visible;
            }

            if (cityTextBox.Text=="")
            {
                check = false;
                cityTextBox.BorderBrush = Brushes.Red;
                cityToolTip.Visibility = Visibility.Visible;
            }

            if (streetTextBox.Text=="")
            {
                check = false;
                streetTextBox.BorderBrush = Brushes.Red;
                streetToolTip.Visibility = Visibility.Visible;
;            }

            return check;
        }

        private void deliveryCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            addressExpander.IsEnabled = true;
            addressExpander.IsExpanded = true;
        }

        private void deliveryCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            addressExpander.IsExpanded = false;
            addressExpander.IsEnabled = false;

            countryTextBox.Clear();
            cityTextBox.Clear();
            streetTextBox.Clear();
        }

        private void addSaleButton_Click(object sender, RoutedEventArgs e)
        {
            if (deliveryCheckBox.IsChecked == false)
            {
                if (CheckFullSale())
                {
                    DataBase dataBase = new DataBase(_dataBaseOption);
                    var Tuple = GetWorkerInformation();

                    dataBase.CreateNewSale(Tuple.Item2, Tuple.Item1, Tuple.Item3, Tuple.Item4,
                        productComboBox.SelectedItem.ToString());

                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.Filter = "DocX document (.docx)|(*.docx)";
                    if (saveFile.ShowDialog() == true)
                    {
                        DateTime date = DateTime.Now;
                        string dateForMySql = date.ToString("yyyy-MM-dd");

                        string text = "Номер покупки: " + dataBase.GetLastSaleNumber() +
                            "\nДата покупки: " + dateForMySql;

                        File file = new File();
                        file.SaveDocWord(saveFile.FileName, text);
                    }
                    dataBase.OutputTable(salesTable, selectedIndex);
                }
            }
            else
            {
                // Переменные создаются для того, чтобы подсказки появлись
                // сразу и у ComboBox, и у TextBox-ов;

                bool checkFullAddress = CheckFullAddress();
                bool checkFullSale = CheckFullSale();

                if (checkFullAddress && checkFullSale)
                {
                    DataBase dataBase = new DataBase(_dataBaseOption);
                    var Tuple = GetWorkerInformation();

                    dataBase.CreateNewSale(Tuple.Item2, Tuple.Item1, Tuple.Item3, Tuple.Item4,
                        productComboBox.SelectedItem.ToString(), countryTextBox, cityTextBox, streetTextBox);
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.Filter = "DocX document (.docx)|(*.docx)";
                    if (saveFile.ShowDialog() == true)
                    {
                        DateTime date = DateTime.Now;
                        string dateForMySql = date.ToString("yyyy-MM-dd");

                        string text = "Номер покупки: " + dataBase.GetLastSaleNumber() +
                            "\nДата покупки: " + dateForMySql;

                        File file = new File();
                        file.SaveDocWord(saveFile.FileName, text);
                    }
                    dataBase.OutputTable(salesTable, selectedIndex);
                }
            }
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

        private void countryTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            countryTextBox.BorderBrush = brush;
            countryToolTip.Visibility = Visibility.Hidden;

            OnlyLetter(sender);
        }

        private void cityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            cityTextBox.BorderBrush = brush;
            cityToolTip.Visibility = Visibility.Hidden;

            OnlyLetter(sender);
        }

        private void streetTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            streetTextBox.BorderBrush = brush;
            streetToolTip.Visibility = Visibility.Hidden;
        }

        private void productComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            productToolTip.Visibility = Visibility.Hidden;
            firstObject.Visibility = Visibility.Hidden;
        }

        private void workersListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nameWorkerToolTip.Visibility = Visibility.Hidden;
            secondObject.Visibility = Visibility.Hidden;
        }

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            addPopup.IsOpen = true;
        }
    }
}
