using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.BusinessLogics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Microsoft.Reporting.WinForms;

namespace GiftShopView
{
    public partial class FormReportGiftSetComponents : Form
    {
        public FormReportGiftSetComponents()
        {
            InitializeComponent();
        }
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportGiftSetComponents(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        
        private void buttonSaveToPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveGiftSetComponentToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                        });

                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void reportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                var dataSource = logic.GetGiftSetComponent();
                ReportDataSource source = new ReportDataSource("DataSetProductComponent", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
