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

        public addSale(int selectedItem, DataGrid salesTable)
        {
            InitializeComponent();

            DataBase dataBase = new DataBase(_dataBaseOption);
            dataBase.GetStaff(workersListComboBox);
            
            this.selectedItem = selectedItem;
            this.salesTable = salesTable;
        }

        int selectedItem = new int();
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
            DataBase dataBase = new DataBase(_dataBaseOption);
            var Tuple = GetWorkerInformation();

            if (deliveryCheckBox.IsChecked == false)
            {
                dataBase.CreateNewSale(Tuple.Item2,Tuple.Item1,Tuple.Item3,Tuple.Item4,
                    nameProductTextBox,typeProductTextBox,nameFabricatorTextBox,priceProductTextBox);

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
            }
            else
            {
                dataBase.CreateNewSale(Tuple.Item2, Tuple.Item1, Tuple.Item3, Tuple.Item4,
                    nameProductTextBox, typeProductTextBox, nameFabricatorTextBox, priceProductTextBox,
                    countryTextBox,cityTextBox,streetTextBox);
            }

            dataBase.OutputTable(salesTable, selectedItem);
        }
    }
}
