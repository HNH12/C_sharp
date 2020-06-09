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
    /// Логика взаимодействия для AddDiscount.xaml
    /// </summary>
    public partial class AddDiscount : Window
    {
        private string _dataBaseOption = "server = 127.0.0.1; user = root; database = market";

        List<Tuple<string, int>> listDiscount = new List<Tuple<string, int>>();

        public AddDiscount()
        {
            InitializeComponent();

            DataBase dataBase = new DataBase(_dataBaseOption);
            dataBase.OutputAllTechnic(technicComboBox);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tuple<string, int> tuple = new Tuple<string, int>
                (technicComboBox.SelectedItem.ToString(), Convert.ToInt32(discountTextBox.Text));

            listDiscount.Add(tuple);
        }
    }
}
