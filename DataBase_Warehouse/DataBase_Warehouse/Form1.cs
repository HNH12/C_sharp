using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
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

            currentTableDataGridView.ColumnHeadersDefaultCellStyle.Alignment = 
                DataGridViewContentAlignment.MiddleCenter;
            currentTableDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            typeTabelComboBox.SelectedIndex = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //DataBaseClass dataBase = new DataBaseClass();
            //dataBase.NewOrderFurniture(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10,
            //    textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //DataBaseClass dataBase = new DataBaseClass();
            //dataBase.NewOrderElectronics(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10,
            //    textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void selectTableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTableDataGridView.Focus();

            DataBaseClass DB = new DataBaseClass();

            switch (selectTableComboBox.SelectedIndex)
            {
                case 0: DB.OutputTable(currentTableDataGridView, "furniture"); break;
                case 1: DB.OutputTable(currentTableDataGridView, "electronics"); break;
                case 2: DB.OutputTable(currentTableDataGridView, "cars"); break;
            }

            currentTableDataGridView.ClearSelection();
        }

        private void typeTabelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTableDataGridView.Focus();

            if (selectTableComboBox.SelectedIndex > -1)
            {
                DataBaseClass DB = new DataBaseClass();
                string currentTable = String.Empty;

                switch (selectTableComboBox.SelectedIndex)
                {
                    case 0: currentTable = "furniture"; break;
                    case 1: currentTable = "electronics"; break;
                    case 2: currentTable = "cars"; break;
                }

                switch (typeTabelComboBox.SelectedIndex)
                {
                    case 0: DB.OutputTable(currentTableDataGridView, currentTable); break;
                    case 1: DB.OutputTable(currentTableDataGridView, currentTable,1); break;
                    case 2: DB.OutputTable(currentTableDataGridView, currentTable,2); break;
                }
            }

            currentTableDataGridView.ClearSelection();
        }

        private void newOrderLabel_Click(object sender, EventArgs e)
        {
            if (selectTableComboBox.SelectedIndex > -1)
            {
                switch (selectTableComboBox.SelectedIndex)
                {
                    case 0:
                        Form2 F2 = new Form2();
                        F2.Show();
                        break;
                    case 1:
                        Form3 F3 = new Form3();
                        F3.Show();
                        break;
                    case 2:
                        Form4 F4 = new Form4();
                        F4.Show();
                        break;
                }
            }
        }

        private void updateStatusLabel_Click(object sender, EventArgs e)
        {
            if (selectTableComboBox.SelectedIndex > -1)
            {
                DataBaseClass DB = new DataBaseClass();

                switch (selectTableComboBox.SelectedIndex)
                {
                    case 0:
                        StatusUpdateFurniture F1 = new StatusUpdateFurniture("furniture");
                        F1.Show();
                        break;
                    case 1:
                        StatusUpdateFurniture F2 = new StatusUpdateFurniture("electronics");
                        F2.Show();
                        break;
                    case 2:
                        StatusUpdateFurniture F3 = new StatusUpdateFurniture("cars");
                        F3.Show();
                        break;
                }
            }
        }
    }
}
