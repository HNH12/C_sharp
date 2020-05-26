namespace DataBase_Warehouse
{
    partial class Form7
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
            this.label1 = new System.Windows.Forms.Label();
            this.neededNumberTextBox = new System.Windows.Forms.TextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер заказа";
            // 
            // neededNumberTextBox
            // 
            this.neededNumberTextBox.Location = new System.Drawing.Point(94, 58);
            this.neededNumberTextBox.Name = "neededNumberTextBox";
            this.neededNumberTextBox.Size = new System.Drawing.Size(47, 22);
            this.neededNumberTextBox.TabIndex = 1;
            this.neededNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(67, 86);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(100, 23);
            this.runButton.TabIndex = 2;
            this.runButton.Text = "удалить";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 157);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.neededNumberTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form7";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox neededNumberTextBox;
        private System.Windows.Forms.Button runButton;
    }
}