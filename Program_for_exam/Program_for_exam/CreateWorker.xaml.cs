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
    /// Логика взаимодействия для CreateWorker.xaml
    /// </summary>
    public partial class CreateWorker : Window
    {
        private string _dataBaseOption = "server = 127.0.0.1; user = root; database = market";

        public CreateWorker()
        {
            InitializeComponent();

            DataBase dataBase = new DataBase(_dataBaseOption);
            dataBase.OutputTableStaff(staffTable);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBase dataBase = new DataBase(_dataBaseOption);
            
            if (dataBase.CheckFullStaff(secondName,firstName,middleName,position))
            {
                MessageBox.Show("Такой работник уже записан");
            }
            else
            {
                dataBase.CreateNewWorker(firstName,secondName,middleName,position);
                MessageBox.Show("Уcпешно создан");
                dataBase.OutputTableStaff(staffTable);
            }
        }
    }
}
