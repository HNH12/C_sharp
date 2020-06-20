using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.AvalonDock;

namespace Program_for_exam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _dataBaseOption = "server = 127.0.0.1; user = root; database = market";

        public MainWindow()
        {
            InitializeComponent();

            DataBase dataBase = new DataBase(_dataBaseOption);
            dataBase.OutputTable(salesDataBase);
            typeList.SelectedIndex = 0;
        }

        private void SaveAllTable_Click(object sender, RoutedEventArgs e)
        {
            File saveFile = new File();
            saveFile.SaveDocExcel(salesDataBase);
        }

        private void typeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataBase dataBase = new DataBase(_dataBaseOption);
            dataBase.OutputTable(salesDataBase, typeList.SelectedIndex);
        }

        private void NewSale_Click(object sender, RoutedEventArgs e)
        {
            addSale add = new addSale(typeList.SelectedIndex, salesDataBase);
            add.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть программу?", "Подтверждение закрытия",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void BackSale_Click(object sender, RoutedEventArgs e)
        {
            File file = new File();
            DataBase dataBase = new DataBase(_dataBaseOption);

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Выбрать чек";
            openFile.Filter = "Word documents(*.docx)|*.docx";

            string numberSale = string.Empty;

            if (openFile.ShowDialog() == true)
            {
                if (dataBase.IssueRefund(file.GetTextDocWord(openFile.FileName), ref numberSale))
                {
                    dataBase.DeleteSale(numberSale);
                    MessageBox.Show("Возврат выполнен");

                    dataBase.OutputTable(salesDataBase, Convert.ToInt32(typeList.SelectedItem));

                    FileInfo fileInf = new FileInfo(openFile.FileName);

                    if (fileInf.Exists)
                        fileInf.Delete();
                }

                else
                    MessageBox.Show("Истёк срок");
            }
        }

        private void DeleteSale_Click(object sender, RoutedEventArgs e)
        {
            DeleteSale delete = new DeleteSale(typeList.SelectedIndex, salesDataBase);
            delete.ShowDialog();
        }

        private void UpdateSale_Click(object sender, RoutedEventArgs e)
        {
            UpdateSale update = new UpdateSale(typeList.SelectedIndex, salesDataBase);
            update.ShowDialog();
        }

        private void CreateWorker_Click(object sender, RoutedEventArgs e)
        {
            CreateWorker createWorker = new CreateWorker();
            createWorker.ShowDialog();
        }

        private void AddDiscount_Click(object sender, RoutedEventArgs e)
        {
            AddDiscount addDiscount = new AddDiscount();
            addDiscount.ShowDialog();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            InfoAboutCreator info = new InfoAboutCreator();
            info.ShowDialog();
        }
    }
}
