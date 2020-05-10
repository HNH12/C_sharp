namespace Конструирование_алгоритмов__Графы_
{
    partial class FourthTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FourthTask));
            this.runTaskButton = new System.Windows.Forms.Button();
            this.graphRichTextBox = new System.Windows.Forms.RichTextBox();
            this.outputTaskTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // runTaskButton
            // 
            this.runTaskButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.runTaskButton.Location = new System.Drawing.Point(109, 278);
            this.runTaskButton.Name = "runTaskButton";
            this.runTaskButton.Size = new System.Drawing.Size(100, 31);
            this.runTaskButton.TabIndex = 0;
            this.runTaskButton.Text = "Проверка";
            this.runTaskButton.UseVisualStyleBackColor = true;
            this.runTaskButton.Click += new System.EventHandler(this.runTaskButton_Click);
            // 
            // graphRichTextBox
            // 
            this.graphRichTextBox.Location = new System.Drawing.Point(87, 122);
            this.graphRichTextBox.Name = "graphRichTextBox";
            this.graphRichTextBox.Size = new System.Drawing.Size(150, 150);
            this.graphRichTextBox.TabIndex = 1;
            this.graphRichTextBox.Text = "";
            // 
            // outputTaskTextBox
            // 
            this.outputTaskTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.outputTaskTextBox.Enabled = false;
            this.outputTaskTextBox.Location = new System.Drawing.Point(315, 122);
            this.outputTaskTextBox.Name = "outputTaskTextBox";
            this.outputTaskTextBox.ReadOnly = true;
            this.outputTaskTextBox.Size = new System.Drawing.Size(210, 22);
            this.outputTaskTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "Дан произвольный неориентированный граф, \r\nпроверить, будет ли он деревом.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Вывод";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Матрица смежности графа";
            // 
            // FourthTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputTaskTextBox);
            this.Controls.Add(this.graphRichTextBox);
            this.Controls.Add(this.runTaskButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FourthTask";
            this.Text = "Четвёртое задание";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FourthTask_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runTaskButton;
        private System.Windows.Forms.RichTextBox graphRichTextBox;
        private System.Windows.Forms.TextBox outputTaskTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}