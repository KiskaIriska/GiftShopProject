using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.BusinessLogics;
using GiftShopBusinessLogic.Interfaces;
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
using Unity;

namespace GiftShopView
{
    public partial class FormReplenishWarehouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly MainLogic logic;
        private readonly IComponentLogic componentLogic;
        private readonly IWarehouseLogic warehouseLogic;

        public FormReplenishWarehouse(MainLogic logic, IComponentLogic componenmtLogic, IWarehouseLogic warehouseLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.componentLogic = componenmtLogic;
            this.warehouseLogic = warehouseLogic;
        }

        private void FormReplenishWarehouse_Load(object sender, EventArgs e)
        {
            try
            {
                List<ComponentViewModel> list = componentLogic.Read(null);
                if (list != null)
                {
                    comboBoxComponent.DisplayMember = "ComponentName";
                    comboBoxComponent.ValueMember = "Id";
                    comboBoxComponent.DataSource = list;
                    comboBoxComponent.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                List<WarehouseViewModel> list = warehouseLogic.GetList();
                if (list != null)
                {
                    comboBoxWarehouse.DisplayMember = "WarehouseName";
                    comboBoxWarehouse.ValueMember = "Id";
                    comboBoxWarehouse.DataSource = list;
                    comboBoxWarehouse.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                logic.ReplanishWarehouse(new WarehouseComponentBindingModel
                {
                    Id = 0,
                    WarehouseId = Convert.ToInt32(comboBoxWarehouse.SelectedValue),
                    ComponentId = Convert.ToInt32(comboBoxComponent.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
