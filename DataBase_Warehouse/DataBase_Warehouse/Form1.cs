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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = 
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseClass dataBase = new DataBaseClass();
            dataBase.NewOrderFurniture(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10,
                textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBaseClass dataBase = new DataBaseClass();
            dataBase.OutputFurnitureTable(dataGridView1);
        }
    }
}
