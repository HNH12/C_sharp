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
    public partial class FifthTask : Form
    {
        public FifthTask()
        {
            InitializeComponent();
        }

        private bool ExceptionHandling_Metod()
        {
            ExceptionHandling exception = new ExceptionHandling();
            if (!exception.CheckRightMatrixWeight(graphRichTextBox))
            {
                return false;
            }
            return true;
        }

        private void FifthTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu m = new Menu();
            m.StartPosition = FormStartPosition.Manual;
            m.Location = this.Location;
            m.Visible = true;
        }

        private void runTaskButton_Click(object sender, EventArgs e)
        {
            string nameFileInput = @"C:\Test\graph5.txt";
            string nameFileOutput = @"C:\Test\graphOut5.txt";
            ReadAndWriteFile.ReadingFromFile(graphRichTextBox, nameFileInput);
            if (ExceptionHandling_Metod())
            {
                try
                {
                    Tasks tasks = new Tasks();
                    tasks.FifthTask(graphRichTextBox, getStartVertex, outputTaskRichTextBox);
                    ReadAndWriteFile.WriteToFile(outputTaskRichTextBox, nameFileOutput, "Кратчайшие пути до вершин от указанной\n");
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
    }
}
