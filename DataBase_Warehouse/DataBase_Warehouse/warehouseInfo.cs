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
    public partial class warehouseInfo : Form
    {
        public warehouseInfo()
        {
            InitializeComponent();

            FullTextBoxFurniture();
            FullTextBoxElectronics();
            FullTextBoxCars();
        }

        private void FullTextBoxFurniture()
        {
            DataBaseClass DB = new DataBaseClass();
            DB.OutputAllOrdersCount(allOrdersFurnitureTextBox, "furniture");
            DB.OutputCurrentOrdersCount(currentOrdersFurnitureTextBox, "furniture");
            DB.OutputEndedOrdersCount(endedOrderFurnitureTextBox, "furniture");
            DB.OutputAllObjectsCount(allObjectsFurnitureTextBox, "furniture");
            DB.OutputCurrentObjectsCount(onWareObjectsFurnitureTextBox, "furniture");
            DB.OutputEndedObjectsCount(buyerObjectsTextBox, "furniture");
            DB.MostExpensiveItem(mostExpensiveFurnitureTextBox,"furniture");
            DB.CheapestItem(cheapestFurnitureTextBox, "furniture");
        }

        private void FullTextBoxElectronics()
        {
            DataBaseClass DB = new DataBaseClass();
            DB.OutputAllOrdersCount(allOrdersElectronicsTextBox, "electronics");
            DB.OutputCurrentOrdersCount(currentOrdersElectronicsTextBox, "electronics");
            DB.OutputEndedOrdersCount(endedOrdersElectronicsTextBox, "electronics");
            DB.OutputAllObjectsCount(allObjectsElectronicsTextBox, "electronics");
            DB.OutputCurrentObjectsCount(onWareObjectsElectronicsTextBox, "electronics");
            DB.OutputEndedObjectsCount(buyerObjectsElectronicsTextBox, "electronics");
            DB.MostExpensiveItem(mostExpensiveObjectsElectronicsTextBox, "electronics");
            DB.CheapestItem(cheapestObjectElectronicsTextBox, "electronics");
        }

        private void FullTextBoxCars()
        {
            DataBaseClass DB = new DataBaseClass();
            DB.OutputAllOrdersCount(allOrdersCarsTextBox, "cars");
            DB.OutputCurrentOrdersCount(currentOrdersCarsTextBox, "cars");
            DB.OutputEndedOrdersCount(endedOrdersCarsTextBox, "cars");
            DB.OutputAllObjectsCount(allObjectsCarsTextBox, "cars");
            DB.OutputCurrentObjectsCount(onWareObjectsCarsTextBox, "cars");
            DB.OutputEndedObjectsCount(buyerObjectCarsTextBox, "cars");
            DB.MostExpensiveItem(mostExpensiveObjectCarsTextBox, "cars");
            DB.CheapestItem(cheapestObjectsCarsTextBox, "cars");
        }

    }
}
