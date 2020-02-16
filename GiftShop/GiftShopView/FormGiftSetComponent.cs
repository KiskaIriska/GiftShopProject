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
    public partial class FormGiftSetComponent : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public GiftSetComponentViewModel ModelView { get; set; }
        private readonly IComponentLogic logic;
        public FormGiftSetComponent(IComponentLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormProductComponent_Load(object sender, EventArgs e)
        {
            try
            {
                List<ComponentViewModel> list = logic.GetList();
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
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            if (ModelView != null)
            {
                comboBoxComponent.Enabled = false;
                comboBoxComponent.SelectedValue = ModelView.ComponentId;
                textBoxCount.Text = ModelView.Count.ToString();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (ModelView == null)
                {
                    ModelView = new GiftSetComponentViewModel
                    {
                        ComponentId = Convert.ToInt32(comboBoxComponent.SelectedValue),
                        ComponentName = comboBoxComponent.Text,
                       
                    Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    ModelView.Count = Convert.ToInt32(textBoxCount.Text);
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
