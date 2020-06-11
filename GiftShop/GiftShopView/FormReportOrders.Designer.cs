namespace GiftShopView
{
    partial class FormReportOrders
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
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiftSetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
         
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "С:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "По:";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(271, 6);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerTo.TabIndex = 2;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(35, 6);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFrom.TabIndex = 3;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(498, 4);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(108, 23);
            this.buttonCreate.TabIndex = 4;
            this.buttonCreate.Text = "Сформировать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.Location = new System.Drawing.Point(649, 4);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(75, 23);
            this.buttonExcel.TabIndex = 5;
            this.buttonExcel.Text = "В Excel";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.GiftSetName,
            this.Price});
            this.dataGridView.Location = new System.Drawing.Point(12, 42);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(776, 396);
            this.dataGridView.TabIndex = 6;
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            // 
            // GiftSetName
            // 
            this.GiftSetName.HeaderText = "Заказ";
            this.GiftSetName.Name = "GiftSetName";
            // 
            // Price
            // 
            this.Price.HeaderText = "Цена";
            this.Price.Name = "Price";
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormReportOrders";
            this.Text = "Заказы клиентов";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiftSetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}