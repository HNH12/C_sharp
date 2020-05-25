namespace DataBase_Warehouse
{
    partial class Form1
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
            this.currentTableDataGridView = new System.Windows.Forms.DataGridView();
            this.selectTableComboBox = new System.Windows.Forms.ComboBox();
            this.newOrderLabel = new System.Windows.Forms.Label();
            this.checkInfoLabel = new System.Windows.Forms.Label();
            this.warehouseInfoLabel = new System.Windows.Forms.Label();
            this.updateStatusLabel = new System.Windows.Forms.Label();
            this.typeTabelComboBox = new System.Windows.Forms.ComboBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.currentTableDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // currentTableDataGridView
            // 
            this.currentTableDataGridView.AllowUserToAddRows = false;
            this.currentTableDataGridView.AllowUserToDeleteRows = false;
            this.currentTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currentTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.currentTableDataGridView.Location = new System.Drawing.Point(45, 76);
            this.currentTableDataGridView.Name = "currentTableDataGridView";
            this.currentTableDataGridView.ReadOnly = true;
            this.currentTableDataGridView.RowHeadersWidth = 51;
            this.currentTableDataGridView.RowTemplate.Height = 24;
            this.currentTableDataGridView.Size = new System.Drawing.Size(1134, 424);
            this.currentTableDataGridView.TabIndex = 5;
            // 
            // selectTableComboBox
            // 
            this.selectTableComboBox.FormattingEnabled = true;
            this.selectTableComboBox.Items.AddRange(new object[] {
            "Мебель",
            "Электроника",
            "Автомобили"});
            this.selectTableComboBox.Location = new System.Drawing.Point(45, 21);
            this.selectTableComboBox.Name = "selectTableComboBox";
            this.selectTableComboBox.Size = new System.Drawing.Size(121, 24);
            this.selectTableComboBox.TabIndex = 6;
            this.selectTableComboBox.SelectedIndexChanged += new System.EventHandler(this.selectTableComboBox_SelectedIndexChanged);
            // 
            // newOrderLabel
            // 
            this.newOrderLabel.AutoSize = true;
            this.newOrderLabel.Location = new System.Drawing.Point(1220, 76);
            this.newOrderLabel.Name = "newOrderLabel";
            this.newOrderLabel.Size = new System.Drawing.Size(164, 17);
            this.newOrderLabel.TabIndex = 8;
            this.newOrderLabel.Text = "Оформить новый товар";
            this.newOrderLabel.Click += new System.EventHandler(this.newOrderLabel_Click);
            // 
            // checkInfoLabel
            // 
            this.checkInfoLabel.AutoSize = true;
            this.checkInfoLabel.Location = new System.Drawing.Point(1220, 154);
            this.checkInfoLabel.Name = "checkInfoLabel";
            this.checkInfoLabel.Size = new System.Drawing.Size(148, 34);
            this.checkInfoLabel.TabIndex = 9;
            this.checkInfoLabel.Text = "Узнать информацию \r\nо заказе";
            // 
            // warehouseInfoLabel
            // 
            this.warehouseInfoLabel.AutoSize = true;
            this.warehouseInfoLabel.Location = new System.Drawing.Point(1220, 483);
            this.warehouseInfoLabel.Name = "warehouseInfoLabel";
            this.warehouseInfoLabel.Size = new System.Drawing.Size(163, 17);
            this.warehouseInfoLabel.TabIndex = 10;
            this.warehouseInfoLabel.Text = "Информация по складу";
            // 
            // updateStatusLabel
            // 
            this.updateStatusLabel.AutoSize = true;
            this.updateStatusLabel.Location = new System.Drawing.Point(1220, 120);
            this.updateStatusLabel.Name = "updateStatusLabel";
            this.updateStatusLabel.Size = new System.Drawing.Size(169, 17);
            this.updateStatusLabel.TabIndex = 11;
            this.updateStatusLabel.Text = "Изменить статус товара";
            this.updateStatusLabel.Click += new System.EventHandler(this.updateStatusLabel_Click);
            // 
            // typeTabelComboBox
            // 
            this.typeTabelComboBox.FormattingEnabled = true;
            this.typeTabelComboBox.Items.AddRange(new object[] {
            "все",
            "действующие",
            "завершенные"});
            this.typeTabelComboBox.Location = new System.Drawing.Point(1058, 21);
            this.typeTabelComboBox.Name = "typeTabelComboBox";
            this.typeTabelComboBox.Size = new System.Drawing.Size(121, 24);
            this.typeTabelComboBox.TabIndex = 12;
            this.typeTabelComboBox.SelectedIndexChanged += new System.EventHandler(this.typeTabelComboBox_SelectedIndexChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID товара";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ID продукции";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Количество";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ID цвета";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ID производителя";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ID покупателя";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Цена (руб.)";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Статус товара";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 550);
            this.Controls.Add(this.typeTabelComboBox);
            this.Controls.Add(this.updateStatusLabel);
            this.Controls.Add(this.warehouseInfoLabel);
            this.Controls.Add(this.checkInfoLabel);
            this.Controls.Add(this.newOrderLabel);
            this.Controls.Add(this.selectTableComboBox);
            this.Controls.Add(this.currentTableDataGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.currentTableDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView currentTableDataGridView;
        private System.Windows.Forms.ComboBox selectTableComboBox;
        private System.Windows.Forms.Label newOrderLabel;
        private System.Windows.Forms.Label checkInfoLabel;
        private System.Windows.Forms.Label warehouseInfoLabel;
        private System.Windows.Forms.Label updateStatusLabel;
        private System.Windows.Forms.ComboBox typeTabelComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}

