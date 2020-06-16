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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBase dataBase = new DataBase(_dataBaseOption);

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
    }
}
