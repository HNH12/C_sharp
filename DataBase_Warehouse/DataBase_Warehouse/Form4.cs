using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase_Warehouse
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void addOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataBaseClass DB = new DataBaseClass();

                DB.NewOrderCars(typeTextBox, nameProductTextBox, countTextBox, colorTextBox, nameFabricatorTextBox, countryFabricatorTextBox,
                    cityFabricatorTextBox, streetFabricatorTextBox, phoneFabricatorTextBox, firstNameTextBox, secondNameTextBox, middleNameTextBox, countryBuyerTextBox, cityBuyerTextBox,
                    streetBuyerTextBox, phoneBuyerTextBox, priceTextBox);

                MessageBox.Show("Выполнено");
            }
            catch 
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
