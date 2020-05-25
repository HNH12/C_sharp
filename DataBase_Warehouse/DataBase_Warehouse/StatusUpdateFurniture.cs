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
        public StatusUpdateFurniture(string data)
        {
            InitializeComponent();
            this.data = data;
        }

        string data;

        private void button1_Click(object sender, EventArgs e)
        {
            if (neededNumberTextBox.TextLength != 0)
            {
                try 
                {
                    DataBaseClass DB = new DataBaseClass();
                    DB.UpdateStatus(Convert.ToInt32(neededNumberTextBox.Text), data);
                    MessageBox.Show("Выполнено");
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }
    }
}
