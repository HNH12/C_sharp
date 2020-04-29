namespace Конструирование_алгоритмов__Графы_
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.firstTaskLabel = new System.Windows.Forms.Label();
            this.secondTaskLabel = new System.Windows.Forms.Label();
            this.thirdTaskLabel = new System.Windows.Forms.Label();
            this.fourthTaskLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstTaskLabel
            // 
            this.firstTaskLabel.AutoSize = true;
            this.firstTaskLabel.BackColor = System.Drawing.Color.Transparent;
            this.firstTaskLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.firstTaskLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.firstTaskLabel.Location = new System.Drawing.Point(240, 121);
            this.firstTaskLabel.Name = "firstTaskLabel";
            this.firstTaskLabel.Size = new System.Drawing.Size(158, 24);
            this.firstTaskLabel.TabIndex = 0;
            this.firstTaskLabel.Text = "Первое задание";
            this.firstTaskLabel.Click += new System.EventHandler(this.firstTaskLabel_Click);
            this.firstTaskLabel.MouseEnter += new System.EventHandler(this.FirstLabel_MouseEnter);
            this.firstTaskLabel.MouseLeave += new System.EventHandler(this.FirstLabel_MouseLeave);
            // 
            // secondTaskLabel
            // 
            this.secondTaskLabel.AutoSize = true;
            this.secondTaskLabel.BackColor = System.Drawing.Color.Transparent;
            this.secondTaskLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.secondTaskLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.secondTaskLabel.Location = new System.Drawing.Point(240, 162);
            this.secondTaskLabel.Name = "secondTaskLabel";
            this.secondTaskLabel.Size = new System.Drawing.Size(156, 24);
            this.secondTaskLabel.TabIndex = 1;
            this.secondTaskLabel.Text = "Второе задание";
            this.secondTaskLabel.Click += new System.EventHandler(this.secondTaskLabel_Click_1);
            this.secondTaskLabel.MouseEnter += new System.EventHandler(this.SecondLabel_MouseEnter);
            this.secondTaskLabel.MouseLeave += new System.EventHandler(this.SecondLabel_MouseLeave);
            // 
            // thirdTaskLabel
            // 
            this.thirdTaskLabel.AutoSize = true;
            this.thirdTaskLabel.BackColor = System.Drawing.Color.Transparent;
            this.thirdTaskLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.thirdTaskLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.thirdTaskLabel.Location = new System.Drawing.Point(240, 203);
            this.thirdTaskLabel.Name = "thirdTaskLabel";
            this.thirdTaskLabel.Size = new System.Drawing.Size(156, 24);
            this.thirdTaskLabel.TabIndex = 2;
            this.thirdTaskLabel.Text = "Третье задание";
            this.thirdTaskLabel.Click += new System.EventHandler(this.thirdTaskLabel_Click);
            this.thirdTaskLabel.MouseEnter += new System.EventHandler(this.ThirdLabel_MouseEnter);
            this.thirdTaskLabel.MouseLeave += new System.EventHandler(this.ThirdLabel_MouseLeave);
            // 
            // fourthTaskLabel
            // 
            this.fourthTaskLabel.AutoSize = true;
            this.fourthTaskLabel.BackColor = System.Drawing.Color.Transparent;
            this.fourthTaskLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fourthTaskLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.fourthTaskLabel.Location = new System.Drawing.Point(226, 239);
            this.fourthTaskLabel.Name = "fourthTaskLabel";
            this.fourthTaskLabel.Size = new System.Drawing.Size(187, 24);
            this.fourthTaskLabel.TabIndex = 3;
            this.fourthTaskLabel.Text = "Четвёртое задание";
            this.fourthTaskLabel.Click += new System.EventHandler(this.fourthTaskLabel_Click);
            this.fourthTaskLabel.MouseEnter += new System.EventHandler(this.FourthLabel_MouseEnter);
            this.fourthTaskLabel.MouseLeave += new System.EventHandler(this.FourthLabel_MouseLeave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Ravie", 19.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(244, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 45);
            this.label1.TabIndex = 4;
            this.label1.Text = "МЕНЮ";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fourthTaskLabel);
            this.Controls.Add(this.thirdTaskLabel);
            this.Controls.Add(this.secondTaskLabel);
            this.Controls.Add(this.firstTaskLabel);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.MenuText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Menu";
            this.Text = "Меню программы";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstTaskLabel;
        private System.Windows.Forms.Label secondTaskLabel;
        private System.Windows.Forms.Label thirdTaskLabel;
        private System.Windows.Forms.Label fourthTaskLabel;
        private System.Windows.Forms.Label label1;
    }
}

