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
	public partial class Menu : Form
	{
		public Menu()
		{
			InitializeComponent();
		}

		private void firstTaskLabel_Click(object sender, EventArgs e)
		{ 
			FirstTask FT = new FirstTask();
			FT.Size = this.Size;
			FT.StartPosition = FormStartPosition.Manual;
			FT.Location = this.Location;
			FT.Show();
			this.Hide();
		}

		private void secondTaskLabel_Click_1(object sender, EventArgs e)
		{
			SecondTask ST = new SecondTask();
			ST.Size = this.Size;
			ST.StartPosition = FormStartPosition.Manual;
			ST.Location = this.Location;
			ST.Show();
			this.Hide();
		}

		private void thirdTaskLabel_Click(object sender, EventArgs e)
		{
			ThirdTask TT = new ThirdTask();
			TT.Size = this.Size;
			TT.StartPosition = FormStartPosition.Manual;
			TT.Location = this.Location;
			TT.Show();
			this.Hide();
		}

		private void FirstLabel_MouseEnter(object sender, EventArgs e)
		{
			firstTaskLabel.Font = new Font("Modern No.20", 11, FontStyle.Underline);
		}

		private void FirstLabel_MouseLeave(object sender, EventArgs e)
		{
			firstTaskLabel.Font = new Font("Modern No.20", 11);
		}

		private void SecondLabel_MouseEnter(object sender, EventArgs e)
		{
			secondTaskLabel.Font = new Font("Modern No.20", 11, FontStyle.Underline);
		}

		private void SecondLabel_MouseLeave(object sender, EventArgs e)
		{
			secondTaskLabel.Font = new Font("Modern No.20", 11);
		}

		private void ThirdLabel_MouseEnter(object sender, EventArgs e)
		{
			thirdTaskLabel.Font = new Font("Modern No.20", 11, FontStyle.Underline);
		}

		private void ThirdLabel_MouseLeave(object sender, EventArgs e)
		{
			thirdTaskLabel.Font = new Font("Modern No.20", 11);
		}

		private void FourthLabel_MouseEnter(object sender, EventArgs e)
		{
			fourthTaskLabel.Font = new Font("Modern No.20", 11, FontStyle.Underline);
		}

		private void FourthLabel_MouseLeave(object sender, EventArgs e)
		{
			fourthTaskLabel.Font = new Font("Modern No.20", 11);
		}

		private void fourthTaskLabel_Click(object sender, EventArgs e)
		{
			FourthTask FT = new FourthTask();
			FT.Size = this.Size;
			FT.StartPosition = FormStartPosition.Manual;
			FT.Location = this.Location;
			FT.Show();
			this.Hide();
		}

		private void Menu_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}