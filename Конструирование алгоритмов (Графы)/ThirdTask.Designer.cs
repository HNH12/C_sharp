namespace Конструирование_алгоритмов__Графы_
{
    partial class ThirdTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThirdTask));
            this.graphRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sortedGraphRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.runTaskButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // graphRichTextBox
            // 
            this.graphRichTextBox.Location = new System.Drawing.Point(33, 108);
            this.graphRichTextBox.Name = "graphRichTextBox";
            this.graphRichTextBox.Size = new System.Drawing.Size(150, 150);
            this.graphRichTextBox.TabIndex = 0;
            this.graphRichTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Матрица смежности графа";
            // 
            // sortedGraphRichTextBox
            // 
            this.sortedGraphRichTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sortedGraphRichTextBox.Enabled = false;
            this.sortedGraphRichTextBox.Location = new System.Drawing.Point(396, 108);
            this.sortedGraphRichTextBox.Name = "sortedGraphRichTextBox";
            this.sortedGraphRichTextBox.ReadOnly = true;
            this.sortedGraphRichTextBox.Size = new System.Drawing.Size(150, 150);
            this.sortedGraphRichTextBox.TabIndex = 2;
            this.sortedGraphRichTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "     Матрица смежности \r\nотсортированного графа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(409, 34);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дан ориентированный слабосвязный граф. \r\nПостроить топологическую сортировку верш" +
    "ин этого графа.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 34);
            this.label4.TabIndex = 5;
            this.label4.Text = "              Стек вершин \r\n(топологическая сортировка)";
            // 
            // outputTextBox
            // 
            this.outputTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.outputTextBox.Enabled = false;
            this.outputTextBox.Location = new System.Drawing.Point(215, 319);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(140, 22);
            this.outputTextBox.TabIndex = 6;
            // 
            // runTaskButton
            // 
            this.runTaskButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.runTaskButton.Location = new System.Drawing.Point(238, 148);
            this.runTaskButton.Name = "runTaskButton";
            this.runTaskButton.Size = new System.Drawing.Size(106, 67);
            this.runTaskButton.TabIndex = 7;
            this.runTaskButton.Text = "Выполнить \r\nсортировку";
            this.runTaskButton.UseVisualStyleBackColor = true;
            this.runTaskButton.Click += new System.EventHandler(this.runTaskButton_Click_1);
            // 
            // ThirdTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.runTaskButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sortedGraphRichTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.graphRichTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ThirdTask";
            this.Text = "Третье задание";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ThirdTask_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox graphRichTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox sortedGraphRichTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button runTaskButton;
    }
}