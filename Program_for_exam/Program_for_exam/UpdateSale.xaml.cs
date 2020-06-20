using Microsoft.Office.Interop.Word;
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
    /// Логика взаимодействия для UpdateSale.xaml
    /// </summary>
    public partial class UpdateSale : System.Windows.Window
    {
        private string _dataBaseOption = "server = 127.0.0.1; user = root; database = market";

        public UpdateSale(int selectedIndex, DataGrid salesTable)
        {
            InitializeComponent();

            this.selectedIndex = selectedIndex;
            this.salesTable = salesTable;
        }

        int selectedIndex = new int();
        DataGrid salesTable;

        private bool CheckFullNumber()
        {
            bool check = true;

            if (numberSaleTextBox.Text == "")
            {
                numberSaleTextBox.BorderBrush = Brushes.Red;
                check = false;
            }

            return check;
        }

        private void UpdateSale_Click(object sender, RoutedEventArgs e)
        {
            DataBase dataBase = new DataBase(_dataBaseOption);

            if (CheckFullNumber())
            {
                if (dataBase.UpdateSale(numberSaleTextBox.Text))
                {
                    MessageBox.Show("Статус изменён");
                    dataBase.OutputTable(salesTable, selectedIndex);
                }
                else
                    MessageBox.Show("Невозможно изменить статус");
            }
        }

        private void numberSaleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            numberSaleTextBox.BorderBrush = brush;

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

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            changePopup.IsOpen = true;
        }
    }
}
