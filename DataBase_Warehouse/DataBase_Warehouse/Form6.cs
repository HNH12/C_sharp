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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void ClearAllTextBox()
        {
            typeTextBox.Clear();
            nameProductTextBox.Clear();
            materialTextbox.Clear();
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
            if (neededNumberTextBox.Text != "")
            {
                DataBaseClass DB = new DataBaseClass();
                DB.OrderInformationElectronic(typeTextBox, nameProductTextBox, countTextBox, colorTextBox,
                    nameFabricatorTextBox, countryFabricatorTextBox, cityFabricatorTextBox, streetFabricatorTextBox, phoneFabricatorTextBox,
                    firstNameTextBox, secondNameTextBox, middleNameTextBox, countryBuyerTextBox, cityBuyerTextBox, streetBuyerTextBox, phoneBuyerTextBox,
                    priceTextBox, statusTextBox, Convert.ToInt32(neededNumberTextBox.Text));
            }
            else
                MessageBox.Show("Ошибка");
        }
    }
}
