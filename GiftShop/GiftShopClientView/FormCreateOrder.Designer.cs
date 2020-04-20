namespace GiftShopClientView
{
        partial class FormCreateOrder
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
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.textBoxCount = new System.Windows.Forms.TextBox();
                this.comboBoxGiftSet = new System.Windows.Forms.ComboBox();
                this.textBoxSum = new System.Windows.Forms.TextBox();
                this.buttonSave = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(13, 18);
                this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(54, 13);
                this.label1.TabIndex = 0;
                this.label1.Text = "Изделие:";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(13, 41);
                this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(69, 13);
                this.label2.TabIndex = 1;
                this.label2.Text = "Количество:";
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(13, 64);
                this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(44, 13);
                this.label3.TabIndex = 2;
                this.label3.Text = "Сумма:";
                // 
                // textBoxCount
                // 
                this.textBoxCount.Location = new System.Drawing.Point(101, 39);
                this.textBoxCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
                this.textBoxCount.Name = "textBoxCount";
                this.textBoxCount.Size = new System.Drawing.Size(199, 20);
                this.textBoxCount.TabIndex = 3;
                this.textBoxCount.TextChanged += new System.EventHandler(this.TextBoxCount_TextChanged);
                // 
                // comboBoxGiftSet
                // 
                this.comboBoxGiftSet.FormattingEnabled = true;
                this.comboBoxGiftSet.Location = new System.Drawing.Point(101, 17);
                this.comboBoxGiftSet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
                this.comboBoxGiftSet.Name = "comboBoxGiftSet";
                this.comboBoxGiftSet.Size = new System.Drawing.Size(199, 21);
                this.comboBoxGiftSet.TabIndex = 4;
                this.comboBoxGiftSet.SelectedIndexChanged += new System.EventHandler(this.ComboBoxGiftSet_SelectedIndexChanged);
                // 
                // textBoxSum
                // 
                this.textBoxSum.Location = new System.Drawing.Point(101, 62);
                this.textBoxSum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
                this.textBoxSum.Name = "textBoxSum";
                this.textBoxSum.ReadOnly = true;
                this.textBoxSum.Size = new System.Drawing.Size(199, 20);
                this.textBoxSum.TabIndex = 5;
                // 
                // buttonSave
                // 
                this.buttonSave.Location = new System.Drawing.Point(138, 90);
                this.buttonSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
                this.buttonSave.Name = "buttonSave";
                this.buttonSave.Size = new System.Drawing.Size(77, 25);
                this.buttonSave.TabIndex = 6;
                this.buttonSave.Text = "Сохранить";
                this.buttonSave.UseVisualStyleBackColor = true;
                this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
                // 
                // FormCreateOrder
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(327, 131);
                this.Controls.Add(this.buttonSave);
                this.Controls.Add(this.textBoxSum);
                this.Controls.Add(this.comboBoxGiftSet);
                this.Controls.Add(this.textBoxCount);
                this.Controls.Add(this.label3);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.label1);
                this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
                this.Name = "FormCreateOrder";
                this.Text = "Заказ";
                this.Load += new System.EventHandler(this.FormCreateOrder_Load);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.TextBox textBoxCount;
            private System.Windows.Forms.ComboBox comboBoxGiftSet;
            private System.Windows.Forms.TextBox textBoxSum;
            private System.Windows.Forms.Button buttonSave;
        }
    }