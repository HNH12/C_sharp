﻿using System;
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
        private string _dataBaseOption = "server = 127.0.0.1; user = root; database = market";

        public DeleteSale(int selectedIndex, DataGrid dataGrid)
        {
            InitializeComponent();

            this.selectedIndex = selectedIndex;
            this.dataGrid = dataGrid;
        }

        int selectedIndex = new int();
        DataGrid dataGrid;

        private void deleteSale_Click(object sender, RoutedEventArgs e)
        {
            DataBase dataBase = new DataBase(_dataBaseOption);

            if (dataBase.DeleteSale(numberSaleTextBox.Text))
            {
                MessageBox.Show("Удаление прошло успешно");
                dataBase.OutputTable(dataGrid, selectedIndex);
            }
            else
                MessageBox.Show("Неверныый номер покупки");
        }
    }
}
