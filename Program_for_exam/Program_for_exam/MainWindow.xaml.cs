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
        public MainWindow()
        {
            InitializeComponent();

            DataBaseClass.DataBase dataBase = new DataBaseClass.DataBase(DataBaseOption.dataBaseOption);
            dataBase.salesDataBase.OutputTable(salesDataBase);

            typeList.SelectedIndex = 0;
        }

        private void SaveTable_Click(object sender, RoutedEventArgs e)
        {
            FileClass saveFile = new FileClass();
            saveFile.SaveDocExcel(salesDataBase);
        }

        private void typeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataBaseClass.DataBase dataBase = new DataBaseClass.DataBase(DataBaseOption.dataBaseOption);
            dataBase.salesDataBase.OutputTable(salesDataBase, typeList.SelectedIndex);
            
        } 
        private void NewSale_Click(object sender, RoutedEventArgs e)
        {
            addSale form = new addSale(typeList.SelectedIndex, salesDataBase);
            form.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть программу?", "Подтверждение закрытия",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        delegate string TextFromFile(string path);

        private void BackSale_Click(object sender, RoutedEventArgs e)
        {
            FileClass file = new FileClass();
            DataBaseClass.DataBase dataBase = new DataBaseClass.DataBase(DataBaseOption.dataBaseOption);

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Выбрать чек";
            openFile.Filter = "Word documents(*.docx)|*.docx";

            string saleNumber = string.Empty;
            TextFromFile textFromFile = file.GetTextDocWord;

            if (openFile.ShowDialog() == true)
            {
                if (dataBase.salesDataBase.IssueRefund(textFromFile(openFile.FileName), ref saleNumber))
                {
                    dataBase.salesDataBase.DeleteSale(saleNumber);
                    MessageBox.Show("Возврат выполнен");

                    dataBase.salesDataBase.OutputTable(salesDataBase, Convert.ToInt32(typeList.SelectedItem));

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
            DeleteSale form = new DeleteSale(typeList.SelectedIndex, salesDataBase);
            form.ShowDialog();
        }

        private void UpdateSale_Click(object sender, RoutedEventArgs e)
        {
            UpdateSale form = new UpdateSale(typeList.SelectedIndex, salesDataBase);
            form.ShowDialog();
        }

        private void AddWorker_Click(object sender, RoutedEventArgs e)
        {
            CreateWorker form = new CreateWorker();
            form.ShowDialog();
        }

        private void AddDiscount_Click(object sender, RoutedEventArgs e)
        {
            AddDiscount form = new AddDiscount();
            form.ShowDialog();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct form = new AddProduct();
            form.ShowDialog();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            InfoAboutCreator form = new InfoAboutCreator();
            form.ShowDialog();
        }
    }
}
