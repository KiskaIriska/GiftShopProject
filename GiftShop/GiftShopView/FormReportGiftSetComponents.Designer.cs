namespace GiftShopView
{
    partial class FormReportGiftSetComponents
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonSaveToExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(27, 93);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(732, 329);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonSaveToExcel
            // 
            this.buttonSaveToExcel.Location = new System.Drawing.Point(27, 24);
            this.buttonSaveToExcel.Name = "buttonSaveToExcel";
            this.buttonSaveToExcel.Size = new System.Drawing.Size(141, 23);
            this.buttonSaveToExcel.TabIndex = 1;
            this.buttonSaveToExcel.Text = "Сохранить в Excel";
            this.buttonSaveToExcel.UseVisualStyleBackColor = true;
            this.buttonSaveToExcel.Click += new System.EventHandler(this.buttonSaveToExcel_Click);
            // 
            // FormReportGiftSetComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSaveToExcel);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormReportGiftSetComponents";
            this.Text = "Компоненты по изделиям";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonSaveToExcel;
    }
}