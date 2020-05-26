using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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

        private void newOrderLabel_MouseEnter(object sender, EventArgs e)
        {
            newOrderLabel.Font = new Font("Microsoft Sans Serif", 7.8f,FontStyle.Underline);
        }

        private void newOrderLabel_MouseLeave(object sender, EventArgs e)
        {
            newOrderLabel.Font = new Font("Microsoft Sans Serif", 7.8f);
        }

        private void updateStatusLabel_MouseEnter(object sender, EventArgs e)
        {
            updateStatusLabel.Font = new Font("Microsoft Sans Serif", 7.8f, FontStyle.Underline);
        }

        private void updateStatusLabel_MouseLeave(object sender, EventArgs e)
        {
            updateStatusLabel.Font = new Font("Microsoft Sans Serif", 7.8f);
        }

        private void checkInfoLabel_MouseEnter(object sender, EventArgs e)
        {
            checkInfoLabel.Font = new Font("Microsoft Sans Serif", 7.8f, FontStyle.Underline);
        }

        private void checkInfoLabel_MouseLeave(object sender, EventArgs e)
        {
            checkInfoLabel.Font = new Font("Microsoft Sans Serif", 7.8f);
        }

        private void warehouseInfoLabel_MouseEnter(object sender, EventArgs e)
        {
            warehouseInfoLabel.Font = new Font("Microsoft Sans Serif", 7.8f, FontStyle.Underline);
        }

        private void warehouseInfoLabel_MouseLeave(object sender, EventArgs e)
        {
            warehouseInfoLabel.Font = new Font("Microsoft Sans Serif", 7.8f);
        }

        private void deleteOrderLabel_MouseEnter(object sender, EventArgs e)
        {
            delete.Font = new Font("Microsoft Sans Serif", 7.8f, FontStyle.Underline);
        }

        private void deleteOrderLabel_MouseLeave(object sender, EventArgs e)
        {
            delete.Font = new Font("Microsoft Sans Serif", 7.8f);
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
                        Form2 F2 = new Form2(currentTableDataGridView,typeTabelComboBox);
                        F2.Show();
                        break;
                    case 1:
                        Form3 F3 = new Form3(currentTableDataGridView,typeTabelComboBox);
                        F3.Show();
                        break;
                    case 2:
                        Form4 F4 = new Form4(currentTableDataGridView,typeTabelComboBox);
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
                        StatusUpdateFurniture F1 = new StatusUpdateFurniture(currentTableDataGridView, typeTabelComboBox, "furniture");
                        F1.Show();
                        break;
                    case 1:
                        StatusUpdateFurniture F2 = new StatusUpdateFurniture(currentTableDataGridView, typeTabelComboBox, "electronics");
                        F2.Show();
                        break;
                    case 2:
                        StatusUpdateFurniture F3 = new StatusUpdateFurniture(currentTableDataGridView, typeTabelComboBox, "cars");
                        F3.Show();
                        break;
                }
            }
        }

        private void checkInfoLabel_Click(object sender, EventArgs e)
        {
            if (selectTableComboBox.SelectedIndex > -1)
            {
                switch (selectTableComboBox.SelectedIndex)
                {
                    case 0:
                        Form6 F = new Form6();
                        F.Show();
                        break;
                    case 1:
                        Form5 F5 = new Form5("electronics");
                        F5.Show();
                        break;
                    case 2:
                        Form5 F5c = new Form5("cars");
                        F5c.Show();
                        break;
                }
            }
        }

        private void warehouseInfoLabel_Click(object sender, EventArgs e)
        {
            warehouseInfo F = new warehouseInfo();
            F.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (selectTableComboBox.SelectedIndex > -1)
            {
                switch (selectTableComboBox.SelectedIndex)
                {
                    case 0:
                        Form7 F = new Form7("furniture",typeTabelComboBox,currentTableDataGridView);
                        F.Show();
                        break;
                    case 1:
                        Form7 F1 = new Form7("electronics",typeTabelComboBox,currentTableDataGridView);
                        F1.Show();
                        break;
                    case 2:
                        Form7 F2 = new Form7("cars",typeTabelComboBox,currentTableDataGridView);
                        F2.Show();
                        break;
                }
            }
        }
    }
}
