using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Конструирование_алгоритмов__Графы_
{
    public partial class FirstTask : Form
    {
        public FirstTask()
        {
            InitializeComponent();
            textTaskLabel.Text = "Дан смешанный граф. Дано натуральное число n.\nНайти количество путей длины n";
        }

        private bool ExceptionHandling()
        {
            ExceptionHandling exception = new ExceptionHandling();

            if (!exception.OnlyNumbers(enterCountWayTextBox))
            {
                return false;
            }

            if (!exception.CheckRightMatrix(graphRichTextBox))
            {
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameFileInput = @"C:\Test\graph1.txt";
            string nameFileOutput = @"C:\Test\graphOut1.txt";
            ReadAndWriteFile.ReadingFromFile(graphRichTextBox, nameFileInput);
            if (ExceptionHandling())
            {
                try
                {
                    Tasks tasks = new Tasks();
                    tasks.FirstTask(graphRichTextBox, enterCountWayTextBox, outputCountWayTextBox);
                    ReadAndWriteFile.WriteFromFile(outputCountWayTextBox, nameFileOutput, "Длина пути: ");
                }
                catch 
                {
                    MessageBox.Show("   Неверные начальные данные", "   Ошибка");
                }
            }
            else
            {
                MessageBox.Show("   Неверные начальные данные", "   Ошибка");
            }
        }

        private void FirstTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu m = new Menu();
            m.StartPosition = FormStartPosition.Manual;
            m.Location = this.Location;
            m.Visible = true;
        }
    }
}
