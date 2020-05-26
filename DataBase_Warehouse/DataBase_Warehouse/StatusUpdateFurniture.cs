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
    public partial class StatusUpdateFurniture : Form
    {
        public StatusUpdateFurniture(DataGridView DGV, ComboBox CB, string data)
        {
            InitializeComponent();
            this.data = data;
            this.DGV = DGV;
            this.CB = CB;
        }

        string data;
        DataGridView DGV;
        ComboBox CB;

        private void button1_Click(object sender, EventArgs e)
        {
            if (neededNumberTextBox.TextLength != 0)
            {
                try 
                {
                    DataBaseClass DB = new DataBaseClass();
                    DB.UpdateStatus(Convert.ToInt32(neededNumberTextBox.Text), data);
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
}
