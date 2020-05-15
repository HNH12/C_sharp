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
    public partial class SecondTask : Form
    {
        public SecondTask()
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
            string nameFileInput = @"C:\Test\graph2.txt";
            string nameFileOutput = @"C:\Test\graphOut2.txt";
            ReadAndWriteFile.ReadingFromFile(graphRichTextBox, nameFileInput);
            if (ExceptionHandling_Metod())
            {
                try
                {
                    Tasks tasks = new Tasks();
                    tasks.SecondTask(graphRichTextBox, outputTextBox);
                    ReadAndWriteFile.WriteToFile(outputTextBox, nameFileOutput, "Максимальное независимое множество: ");
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

        private void SecondTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu m = new Menu();
            m.StartPosition = FormStartPosition.Manual;
            m.Location = this.Location;
            m.Visible = true;
        }
    }
}
