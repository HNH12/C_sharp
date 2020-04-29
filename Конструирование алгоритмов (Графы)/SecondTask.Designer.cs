namespace Конструирование_алгоритмов__Графы_
{
    partial class SecondTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecondTask));
            this.runTaskButton = new System.Windows.Forms.Button();
            this.graphRichTextBox = new System.Windows.Forms.RichTextBox();
            this.graphLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // runTaskButton
            // 
            this.runTaskButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.runTaskButton.Location = new System.Drawing.Point(221, 267);
            this.runTaskButton.Name = "runTaskButton";
            this.runTaskButton.Size = new System.Drawing.Size(105, 23);
            this.runTaskButton.TabIndex = 0;
            this.runTaskButton.Text = "Построить";
            this.runTaskButton.UseVisualStyleBackColor = true;
            this.runTaskButton.Click += new System.EventHandler(this.runTaskButton_Click);
            // 
            // graphRichTextBox
            // 
            this.graphRichTextBox.Location = new System.Drawing.Point(197, 111);
            this.graphRichTextBox.Name = "graphRichTextBox";
            this.graphRichTextBox.Size = new System.Drawing.Size(150, 150);
            this.graphRichTextBox.TabIndex = 1;
            this.graphRichTextBox.Text = "";
            // 
            // graphLabel
            // 
            this.graphLabel.AutoSize = true;
            this.graphLabel.Location = new System.Drawing.Point(182, 91);
            this.graphLabel.Name = "graphLabel";
            this.graphLabel.Size = new System.Drawing.Size(185, 17);
            this.graphLabel.TabIndex = 2;
            this.graphLabel.Text = "Матрица смежности графа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "     Независимое \r\nмножество вершин";
            // 
            // outputTextBox
            // 
            this.outputTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.outputTextBox.Enabled = false;
            this.outputTextBox.Location = new System.Drawing.Point(434, 128);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(100, 22);
            this.outputTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 51);
            this.label1.TabIndex = 5;
            this.label1.Text = "Дан неориентированный граф. \r\nПостроить произвольное максимальное независимое \r\nм" +
    "ножество вершин графа.";
            // 
            // SecondTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.graphLabel);
            this.Controls.Add(this.graphRichTextBox);
            this.Controls.Add(this.runTaskButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SecondTask";
            this.Text = "Второе задание";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SecondTask_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runTaskButton;
        private System.Windows.Forms.RichTextBox graphRichTextBox;
        private System.Windows.Forms.Label graphLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label label1;
    }
}