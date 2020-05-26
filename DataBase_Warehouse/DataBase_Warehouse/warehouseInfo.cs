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
            DataBaseClass DB = new DataBaseClass();
            DB.OutputAllOrdersCount(allOrdersFurnitureTextBox,"furniture");
        }
    }
}
