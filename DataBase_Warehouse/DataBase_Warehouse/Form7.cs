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
    public partial class Form7 : Form
    {
        public Form7(string data, ComboBox CB, DataGridView DGV)
        {
            InitializeComponent();
            this.data = data;
            this.CB = CB;
            this.DGV = DGV;
        }

        string data;
        ComboBox CB;
        DataGridView DGV;

        private void runButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataBaseClass DB = new DataBaseClass();
                DB.DeleteOrder(neededNumberTextBox, data);
                MessageBox.Show("Выполнено");
                DB.OutputTable(DGV, data, CB.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
