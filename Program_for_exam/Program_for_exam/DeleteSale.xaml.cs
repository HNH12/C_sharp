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
    /// Логика взаимодействия для DeleteSale.xaml
    /// </summary>
    public partial class DeleteSale : Window
    {

        public DeleteSale(int selectedIndex, DataGrid dataGrid)
        {
            InitializeComponent();

            this.selectedIndex = selectedIndex;
            this.dataGrid = dataGrid;
        }

        int selectedIndex = new int();
        DataGrid dataGrid;

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

        private void deleteSaleButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseClass.DataBase dataBase = new DataBaseClass.DataBase(DataBaseOption.dataBaseOption);

            if (CheckFullNumber())
            {
                if (dataBase.DeleteSale(numberSaleTextBox.Text))
                {
                    MessageBox.Show("Удаление прошло успешно");
                    dataBase.OutputTable(dataGrid, selectedIndex);

                    numberSaleTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Неверный номер покупки");
                    numberSaleTextBox.Clear();
                }
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
                (symb >= '0' && symb <='9'))
                .ToArray()
                );
            }
        }
    }
}
