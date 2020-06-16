using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
    /// Логика взаимодействия для AddDiscount.xaml
    /// </summary>
    public partial class AddDiscount : Window
    {
        private string _dataBaseOption = "server = 127.0.0.1; user = root; database = market";

        public AddDiscount()
        {
            InitializeComponent();

            DataBase dataBase = new DataBase(_dataBaseOption);
            dataBase.OutputAllTechnic(technicComboBox);
            dataBase.OutputTableDiscount(listDiscountTextBox);
            dataBase.OutputAllDiscount(currentDiscount);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tuple<string, int> tuple = new Tuple<string, int>
                (technicComboBox.SelectedItem.ToString(), Convert.ToInt32(discountTextBox.Text));

            DataBase dataBase = new DataBase(_dataBaseOption);
            if (dataBase.AddDiscount(technicComboBox.Text, discountTextBox.Text))
            {
                listDiscountTextBox.Clear();
                dataBase.OutputTableDiscount(listDiscountTextBox);
                dataBase.OutputAllDiscount(currentDiscount);
            }            
            else
                MessageBox.Show("Net");
        }

        private string GetProductForIndex(string number)
        {
            char[] separators = new char[] {' ','\n'};

            string[] text = listDiscountTextBox.Text.Split(
                separators,StringSplitOptions.RemoveEmptyEntries);

            string nameProduct = "", typeProduct ="", nameFabricator = "";
            

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == number + ')')
                    return (text[i + 1] + " " + text[i + 2] + " " + text[i + 3] + " " + 
                        text[i+4].Remove(text[i+4].LastIndexOf(';')));
            }
            return "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataBase dataBase = new DataBase(_dataBaseOption);

            dataBase.DeleteDiscount(currentDiscount.SelectedItem.ToString());
            listDiscountTextBox.Clear();
            currentDiscount.Items.Clear();
            dataBase.OutputAllDiscount(currentDiscount);
            dataBase.OutputTableDiscount(listDiscountTextBox);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataBase dataBase = new DataBase(_dataBaseOption);

            dataBase.DeleteDiscount();
            currentDiscount.Items.Clear();
            listDiscountTextBox.Clear();
            dataBase.OutputAllDiscount(currentDiscount);
            dataBase.OutputTableDiscount(listDiscountTextBox);
        }
    }
}
