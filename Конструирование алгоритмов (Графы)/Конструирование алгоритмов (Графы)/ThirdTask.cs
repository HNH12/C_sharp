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
    public partial class ThirdTask : Form
    {
        public ThirdTask()
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
            if (!exception.DirectedGraph(exception.GetMatrix(graphRichTextBox)))
            {
                return false;
            }
            return true;
        }
        
        private void ThirdTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu m = new Menu();
            m.StartPosition = FormStartPosition.Manual;
            m.Location = this.Location;
            m.Visible = true;
        }

        private void runTaskButton_Click_1(object sender, EventArgs e)
        {
            if (ExceptionHandling_Metod())
            {
                try
                {
                    Tasks tasks = new Tasks();
                    tasks.ThirdTask(graphRichTextBox, outputTextBox, sortedGraphRichTextBox);
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
