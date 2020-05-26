using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace DataBase_Warehouse
{
    public partial class Form3 : Form
    {
        public Form3(DataGridView DGV, ComboBox CB)
        {
            InitializeComponent();
            this.DGV = DGV;
            this.CB = CB;
        }

        DataGridView DGV;
        ComboBox CB;

        private bool CheckFullTextBox()
        {
            bool full = (typeTextBox.Text == "" || nameProductTextBox.Text == "" || countTextBox.Text == ""
                || colorTextBox.Text == "" || nameFabricatorTextBox.Text == "" || countryFabricatorTextBox.Text == "" || cityFabricatorTextBox.Text == ""
                || streetFabricatorTextBox.Text == "" || phoneFabricatorTextBox.Text == "" || firstNameTextBox.Text == "" || secondNameTextBox.Text == ""
                || middleNameTextBox.Text == "" || countryBuyerTextBox.Text == "" || streetBuyerTextBox.Text == "" || phoneBuyerTextBox.Text == ""
                || priceTextBox.Text == "");

            if (full)
                return false;
            return true;
        }

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
        }

        private void addOrderButton_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (CheckFullTextBox())
                {
                    DataBaseClass DB = new DataBaseClass();

                    DB.NewOrderElectronics(typeTextBox, nameProductTextBox, countTextBox, colorTextBox, nameFabricatorTextBox, countryFabricatorTextBox,
                        cityFabricatorTextBox, streetFabricatorTextBox, phoneFabricatorTextBox, firstNameTextBox, secondNameTextBox, middleNameTextBox, countryBuyerTextBox, cityBuyerTextBox,
                        streetBuyerTextBox, phoneBuyerTextBox, priceTextBox);

                    MessageBox.Show("Выполнено");
                    DB.OutputTable(DGV, "electronics", CB.SelectedIndex);
                    ClearAllTextBox();
                }
                else
                {
                    MessageBox.Show("Заполнены не все поля");
                }
            //}
            //catch
            //{
            //    MessageBox.Show("Ошибка");
            //}
        }
    }
}
