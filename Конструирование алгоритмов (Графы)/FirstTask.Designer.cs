namespace Конструирование_алгоритмов__Графы_
{
    partial class FirstTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstTask));
            this.textTaskLabel = new System.Windows.Forms.Label();
            this.outputCountWayTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.runTaskButton = new System.Windows.Forms.Button();
            this.enterCountWayTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.graphRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textTaskLabel
            // 
            this.textTaskLabel.AutoSize = true;
            this.textTaskLabel.Location = new System.Drawing.Point(21, 22);
            this.textTaskLabel.Name = "textTaskLabel";
            this.textTaskLabel.Size = new System.Drawing.Size(0, 17);
            this.textTaskLabel.TabIndex = 7;
            // 
            // outputCountWayTextBox
            // 
            this.outputCountWayTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.outputCountWayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputCountWayTextBox.Enabled = false;
            this.outputCountWayTextBox.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.outputCountWayTextBox.Location = new System.Drawing.Point(346, 248);
            this.outputCountWayTextBox.Name = "outputCountWayTextBox";
            this.outputCountWayTextBox.ReadOnly = true;
            this.outputCountWayTextBox.ShortcutsEnabled = false;
            this.outputCountWayTextBox.Size = new System.Drawing.Size(43, 22);
            this.outputCountWayTextBox.TabIndex = 2;
            this.outputCountWayTextBox.TabStop = false;
            this.outputCountWayTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Количество путей";
            // 
            // runTaskButton
            // 
            this.runTaskButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.runTaskButton.Location = new System.Drawing.Point(326, 145);
            this.runTaskButton.Name = "runTaskButton";
            this.runTaskButton.Size = new System.Drawing.Size(90, 23);
            this.runTaskButton.TabIndex = 0;
            this.runTaskButton.Text = "Найти";
            this.runTaskButton.UseVisualStyleBackColor = true;
            this.runTaskButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // enterCountWayTextBox
            // 
            this.enterCountWayTextBox.Location = new System.Drawing.Point(346, 117);
            this.enterCountWayTextBox.Name = "enterCountWayTextBox";
            this.enterCountWayTextBox.Size = new System.Drawing.Size(43, 22);
            this.enterCountWayTextBox.TabIndex = 3;
            this.enterCountWayTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Длина путей";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Матрица смежности графа";
            // 
            // graphRichTextBox
            // 
            this.graphRichTextBox.Location = new System.Drawing.Point(80, 120);
            this.graphRichTextBox.Name = "graphRichTextBox";
            this.graphRichTextBox.Size = new System.Drawing.Size(150, 150);
            this.graphRichTextBox.TabIndex = 1;
            this.graphRichTextBox.Text = "";
            // 
            // FirstTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.textTaskLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enterCountWayTextBox);
            this.Controls.Add(this.outputCountWayTextBox);
            this.Controls.Add(this.graphRichTextBox);
            this.Controls.Add(this.runTaskButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FirstTask";
            this.Text = "Первое задание";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FirstTask_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label textTaskLabel;
        private System.Windows.Forms.TextBox outputCountWayTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button runTaskButton;
        private System.Windows.Forms.TextBox enterCountWayTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox graphRichTextBox;
    }
}