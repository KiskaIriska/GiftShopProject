using GiftShopBusinessLogic.BingingModels;
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
    public partial class FormGiftSet : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IGiftSetLogic logic;
        private int? id;
        private List<GiftSetComponentViewModel> giftSetComponents;

        public FormGiftSet(IGiftSetLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }
        private void FormGiftSet_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    GiftSetViewModel view = logic.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.GiftSetName;
                        textBoxPrice.Text = view.Price.ToString();
                        giftSetComponents = view.GiftSetComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                giftSetComponents = new List<GiftSetComponentViewModel>();
            }
        }
            private void LoadData()
        {
            try
            {
                if (giftSetComponents != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = giftSetComponents;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormGiftSetComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.ModelView != null)
                {
                    if (id.HasValue)
                    {
                        form.ModelView.GiftSetId = id.Value;
                    }
                    giftSetComponents.Add(form.ModelView);
                }
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
               
 {
                var form = Container.Resolve<FormGiftSetComponent>();
                form.ModelView =
               giftSetComponents[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    giftSetComponents[dataGridView.SelectedRows[0].Cells[0].RowIndex] =
                   form.ModelView;
                    LoadData();
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        giftSetComponents.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (giftSetComponents == null || giftSetComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<GiftSetComponentBindingModel> productComponentBM = new
               List<GiftSetComponentBindingModel>();
                
            for (int i = 0; i < giftSetComponents.Count; ++i)
                {
                    productComponentBM.Add(new GiftSetComponentBindingModel
                    {
                        Id = giftSetComponents[i].Id,
                        GiftSetId = giftSetComponents[i].GiftSetId,
                        ComponentId = giftSetComponents[i].ComponentId,
                        Count = giftSetComponents[i].Count
                    });
                }
                if (id.HasValue)
                {
                    logic.UpdElement(new GiftSetBindingModel
                    {
                        Id = id.Value,
                        GiftSetName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        ProductComponents = productComponentBM
                    });
                }
                else
                {
                    logic.AddElement(new GiftSetBindingModel
                    {
                        GiftSetName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        ProductComponents = productComponentBM
                    });
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
