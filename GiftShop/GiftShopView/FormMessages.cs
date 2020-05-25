using GiftShopBusinessLogic.Interfaces;
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

namespace GiftShopView
{
    public partial class FormMessages : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IMessageInfoLogic messageLogic;

        public FormMessages(IMessageInfoLogic messageLogic)
        {
            InitializeComponent();
            this.messageLogic = messageLogic;
        }

        private void FormMessage_Load(object sender, EventArgs e)
        {
            try
            {
                var list = messageLogic.Read(null);

                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
