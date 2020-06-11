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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportOrdersViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonSaveToPdf = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSaveToPdf
            // 
            this.buttonSaveToPdf.Location = new System.Drawing.Point(27, 24);
            this.buttonSaveToPdf.Name = "buttonSaveToPdf";
            this.buttonSaveToPdf.Size = new System.Drawing.Size(141, 23);
            this.buttonSaveToPdf.TabIndex = 1;
            this.buttonSaveToPdf.Text = "Сохранить в Pdf";
            this.buttonSaveToPdf.UseVisualStyleBackColor = true;
            this.buttonSaveToPdf.Click += new System.EventHandler(this.buttonSaveToPdf_Click);
            // 
            // reportViewer
            // 
            reportDataSource2.Name = "DataSetOrders";
            reportDataSource2.Value = this.ReportOrdersViewModelBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "GiftShopView.Report.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(1, 79);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(595, 425);
            this.reportViewer.TabIndex = 2;
            this.reportViewer.Load += new System.EventHandler(this.reportViewer_Load);
            // 
            // FormReportGiftSetComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 516);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.buttonSaveToPdf);
            this.Name = "FormReportGiftSetComponents";
            this.Text = "Компоненты по изделиям";
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSaveToPdf;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource ReportOrdersViewModelBindingSource;
    }
}