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
        private string _dataBaseOption = "server = 127.0.0.1; user = root; database = market";

        public AddProduct()
        {
            InitializeComponent();

            DataBase dataBase = new DataBase(_dataBaseOption);
            dataBase.OutputTableTechnic(listProductDataGrid);
        }

        public bool CheckFullData()
        {
            bool check = true;

            if (nameProduct.Text=="")
            {
                check = false;
                nameProduct.BorderBrush = Brushes.Red;
                nameProductAddProductToolTip.Visibility = Visibility.Visible;
            }

            if(typeProduct.Text=="")
            {
                check = false;
                typeProduct.BorderBrush = Brushes.Red;
                typeProductAddProductToolTip.Visibility = Visibility.Visible;
            }

            if(nameFabricator.Text=="")
            {
                check = false;
                nameFabricator.BorderBrush = Brushes.Red;
                nameFabricatorAddProductToolTip.Visibility = Visibility.Visible;
            }

            if(priceProduct.Text=="")
            {
                check = false;
                priceProduct.BorderBrush = Brushes.Red;
                priceProductAddProductToolTip.Visibility = Visibility.Visible;
            }

            return check;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBase dataBase = new DataBase(_dataBaseOption);
            
            try
            {
                if (dataBase.CreateNewTechnic(nameProduct, typeProduct, priceProduct, nameFabricator))
                {
                    MessageBox.Show("Товар создан");
                    dataBase.OutputTableTechnic(listProductDataGrid);

                    nameProduct.Clear();
                    nameFabricator.Clear();
                    typeProduct.Clear();
                    priceProduct.Clear();
                }

                else
                {
                    MessageBox.Show("Такой товар уже существует");

                    nameProduct.Clear();
                    nameFabricator.Clear();
                    typeProduct.Clear();
                    priceProduct.Clear();
                }
            }
            catch
            {
                CheckFullData();
            }
        }

        private void nameProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            nameProduct.BorderBrush = brush;
            nameProductAddProductToolTip.Visibility = Visibility.Hidden;
        }

        private void typeProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            typeProduct.BorderBrush = brush;
            typeProductAddProductToolTip.Visibility = Visibility.Hidden;
        }

        private void nameFabricator_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            nameFabricator.BorderBrush = brush;
            nameFabricatorAddProductToolTip.Visibility = Visibility.Hidden;
        }

        private void priceProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFABADB3");
            priceProduct.BorderBrush = brush;
            priceProductAddProductToolTip.Visibility = Visibility.Hidden;
        }
    }
}
