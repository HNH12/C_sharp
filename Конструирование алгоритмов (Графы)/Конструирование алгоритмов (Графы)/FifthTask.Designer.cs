namespace Конструирование_алгоритмов__Графы_
{
    partial class FifthTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FifthTask));
            this.label1 = new System.Windows.Forms.Label();
            this.graphRichTextBox = new System.Windows.Forms.RichTextBox();
            this.outputTaskRichTextBox = new System.Windows.Forms.RichTextBox();
            this.getStartVertex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.runTaskButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Реализовать алгоритм Беллмана – Форда нахождения кратчайшего пути. \r\nОписать возм" +
    "ожности его применения.";
            // 
            // graphRichTextBox
            // 
            this.graphRichTextBox.Location = new System.Drawing.Point(42, 111);
            this.graphRichTextBox.Name = "graphRichTextBox";
            this.graphRichTextBox.Size = new System.Drawing.Size(150, 150);
            this.graphRichTextBox.TabIndex = 1;
            this.graphRichTextBox.Text = "";
            // 
            // outputTaskRichTextBox
            // 
            this.outputTaskRichTextBox.Location = new System.Drawing.Point(367, 111);
            this.outputTaskRichTextBox.Name = "outputTaskRichTextBox";
            this.outputTaskRichTextBox.Size = new System.Drawing.Size(176, 100);
            this.outputTaskRichTextBox.TabIndex = 2;
            this.outputTaskRichTextBox.Text = "";
            // 
            // getStartVertex
            // 
            this.getStartVertex.Location = new System.Drawing.Point(300, 284);
            this.getStartVertex.Name = "getStartVertex";
            this.getStartVertex.Size = new System.Drawing.Size(38, 22);
            this.getStartVertex.TabIndex = 3;
            this.getStartVertex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Исходная матрица смежности";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 34);
            this.label3.TabIndex = 5;
            this.label3.Text = "Кратчайшие пути до всех вершин \r\n                от указанной";
            // 
            // runTaskButton
            // 
            this.runTaskButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.runTaskButton.Location = new System.Drawing.Point(270, 312);
            this.runTaskButton.Name = "runTaskButton";
            this.runTaskButton.Size = new System.Drawing.Size(100, 23);
            this.runTaskButton.TabIndex = 6;
            this.runTaskButton.Text = "Выполнить";
            this.runTaskButton.UseVisualStyleBackColor = true;
            this.runTaskButton.Click += new System.EventHandler(this.runTaskButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 34);
            this.label4.TabIndex = 7;
            this.label4.Text = "     Вершина, для которой \r\nнаходятся кратчайшие пути";
            // 
            // FifthTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.runTaskButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.getStartVertex);
            this.Controls.Add(this.outputTaskRichTextBox);
            this.Controls.Add(this.graphRichTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FifthTask";
            this.Text = "Пятое задание";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FifthTask_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox graphRichTextBox;
        private System.Windows.Forms.RichTextBox outputTaskRichTextBox;
        private System.Windows.Forms.TextBox getStartVertex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button runTaskButton;
        private System.Windows.Forms.Label label4;
    }
}