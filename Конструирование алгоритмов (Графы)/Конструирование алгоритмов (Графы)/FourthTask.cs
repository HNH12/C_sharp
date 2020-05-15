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
    public partial class FourthTask : Form
    {
        public FourthTask()
        {
            InitializeComponent();
        }

        private bool ExceptionHandling_Metod()
        {
            ExceptionHandling exception = new ExceptionHandling();
            if (!exception.CheckRightMatrix(graphRichTextBox))
            {
                return false;
            }
            if (!exception.UndirectedGraph(exception.GetMatrix(graphRichTextBox)))
            {
                return false;
            }
            return true;
        }

        private void runTaskButton_Click(object sender, EventArgs e)
        {
            string nameFileInput = @"C:\Test\graph4.txt";
            string nameFileOutput = @"C:\Test\graphOut4.txt";
            ReadAndWriteFile.ReadingFromFile(graphRichTextBox, nameFileInput);
            if (ExceptionHandling_Metod())
            {
                try
                {
                    Tasks tasks = new Tasks();
                    tasks.FourthTask(graphRichTextBox, outputTaskTextBox);
                    ReadAndWriteFile.WriteToFile(outputTaskTextBox, nameFileOutput);
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

        private void FourthTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu m = new Menu();
            m.StartPosition = FormStartPosition.Manual;
            m.Location = this.Location;
            m.Visible = true;
        }
    }
}
