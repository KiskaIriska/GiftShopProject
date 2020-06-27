using GiftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiftShopClientView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            LoadList();
        }

        private void LoadList()
        {
            try
            {
                dataGridView.DataSource = ClientApi.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={Program.Client.Id}");
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].Visible = false;
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[5].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormUpdateData();

            form.ShowDialog();
        }

        private void CreateOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCreateOrder();

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }

        private void RefreshOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadList();
        }
     

        private void сообщенияToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = new FormMessages();

            form.ShowDialog();
        }
    }
}
