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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : System.Windows.Window
    {

        public AddProduct()
        {
            InitializeComponent();

            DataBaseClass.DataBase dataBase = new DataBaseClass.DataBase(DataBaseOption.dataBaseOption);
            dataBase.OutputTableProduct(listProductDataGrid);
        }

        public bool CheckFullData()
        {
            bool check = true;

            if (nameProductTextBox.Text=="")
            {
                check = false;

                nameProductTextBox.BorderBrush = Brushes.Red;
                nameProductToolTip.Visibility = Visibility.Visible;
            }

            if(typeProductTextBox.Text=="")
            {
                check = false;

                typeProductTextBox.BorderBrush = Brushes.Red;
                typeProductToolTip.Visibility = Visibility.Visible;
            }

            if(nameFabricatorTextBox.Text=="")
            {
                check = false;

                nameFabricatorTextBox.BorderBrush = Brushes.Red;
                nameFabricatorToolTip.Visibility = Visibility.Visible;
            }

            if(priceProductTextBox.Text=="")
            {
                check = false;

                priceProductTextBox.BorderBrush = Brushes.Red;
                priceProductToolTip.Visibility = Visibility.Visible;
            }

            return check;
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseClass.DataBase dataBase = new DataBaseClass.DataBase(DataBaseOption.dataBaseOption);
            
            bool isSuccessfulAdd = dataBase.CreateNewTechnic(nameProductTextBox.Text, typeProductTextBox.Text, 
                priceProductTextBox.Text, nameFabricatorTextBox.Text);

            if(CheckFullData())
            { 
                if (isSuccessfulAdd)
                {
                    MessageBox.Show("Товар создан");
                    dataBase.OutputTableProduct(listProductDataGrid);

                    nameProductTextBox.Clear();
                    nameFabricatorTextBox.Clear();
                    typeProductTextBox.Clear();
                    priceProductTextBox.Clear();
                }

                else
                {
                    MessageBox.Show("Такой товар уже существует");

                    nameProductTextBox.Clear();
                    nameFabricatorTextBox.Clear();
                    typeProductTextBox.Clear();
                    priceProductTextBox.Clear();
                }
            }
        }

        private void nameProductTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            nameProductTextBox.BorderBrush = brush;

            nameProductToolTip.Visibility = Visibility.Hidden;
        }

        private void typeProductTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            typeProductTextBox.BorderBrush = brush;

            typeProductToolTip.Visibility = Visibility.Hidden;
        }

        private void nameFabricatorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            nameFabricatorTextBox.BorderBrush = brush;

            nameFabricatorToolTip.Visibility = Visibility.Hidden;
        }

        private void priceProductTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            priceProductTextBox.BorderBrush = brush;

            priceProductToolTip.Visibility = Visibility.Hidden;
        }
    }
}
