using Microsoft.Win32;
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
    /// Логика взаимодействия для BackProduct.xaml
    /// </summary>
    public partial class BackProduct : Window
    {
        private string _dataBaseOption = "server = 127.0.0.1; user = root; database = market";

        public BackProduct(int selectedItem, DataGrid salesTable)
        {
            InitializeComponent();

            this.selectedItem = selectedItem;
            this.salesTable = salesTable;
        }

        int selectedItem = new int();
        DataGrid salesTable;

        private void productBackButton_Click(object sender, RoutedEventArgs e)
        {
            File file = new File();
            DataBase dataBase = new DataBase(_dataBaseOption);
            OpenFileDialog openFile = new OpenFileDialog();
            string numberSale = string.Empty; 
            if (openFile.ShowDialog() == true)
            {
                if (dataBase.IssueRefund(file.GetTextDocWord(openFile.FileName), ref numberSale))
                {
                    dataBase.DeleteSale(numberSale);
                    MessageBox.Show("Возврат выполнен");
                }
                else
                {
                    MessageBox.Show("Истёк срок");
                }
            }
        }
    }
}
