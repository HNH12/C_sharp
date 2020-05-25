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
    public partial class Form5 : Form
    {
        public Form5(string data)
        {
            InitializeComponent();
            this.data = data;
        }

        string data;

        private void ClearAllTextBox()
        {
            typeTextBox.Clear();
            nameProductTextBox.Clear();
            countTextBox.Clear();
            colorTextBox.Clear();
            nameFabricatorTextBox.Clear();
            countryFabricatorTextBox.Clear();
            cityFabricatorTextBox.Clear();
            streetFabricatorTextBox.Clear();
            phoneFabricatorTextBox.Clear();
            firstNameTextBox.Clear();
            secondNameTextBox.Clear();
            middleNameTextBox.Clear();
            countryBuyerTextBox.Clear();
            cityBuyerTextBox.Clear();
            streetBuyerTextBox.Clear();
            phoneBuyerTextBox.Clear();
            priceTextBox.Clear();
            statusTextBox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearAllTextBox();
            try
            {
                switch (data)
                {
                    case "electronics":
                        DataBaseClass DB = new DataBaseClass();
                        DB.OrderInformationElectronic(typeTextBox, nameProductTextBox, countTextBox, colorTextBox,
                            nameFabricatorTextBox, countryFabricatorTextBox, cityFabricatorTextBox, streetFabricatorTextBox, phoneFabricatorTextBox,
                            firstNameTextBox, secondNameTextBox, middleNameTextBox, countryBuyerTextBox, cityBuyerTextBox, streetBuyerTextBox, phoneBuyerTextBox,
                            priceTextBox, statusTextBox, Convert.ToInt32(neededNumberTextBox.Text));
                        break;

                    case "cars":
                        DataBaseClass DBC = new DataBaseClass();
                        DBC.OrderInformationCar(typeTextBox, nameProductTextBox, countTextBox, colorTextBox,
                            nameFabricatorTextBox, countryFabricatorTextBox, cityFabricatorTextBox, streetFabricatorTextBox, phoneFabricatorTextBox,
                            firstNameTextBox, secondNameTextBox, middleNameTextBox, countryBuyerTextBox, cityBuyerTextBox, streetBuyerTextBox, phoneBuyerTextBox,
                            priceTextBox, statusTextBox, Convert.ToInt32(neededNumberTextBox.Text));
                        break;
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
