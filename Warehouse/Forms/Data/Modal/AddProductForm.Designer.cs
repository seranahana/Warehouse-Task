namespace Warehouse.Forms.Data.Modal
{
    partial class AddProductForm
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
            nameLabel = new Label();
            nameTextBox = new TextBox();
            priceLabel = new Label();
            priceTextBox = new TextBox();
            confirmButton = new Button();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 69);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(177, 15);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Введите наименование товара:";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(12, 87);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(177, 23);
            nameTextBox.TabIndex = 1;
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(295, 69);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(122, 15);
            priceLabel.TabIndex = 2;
            priceLabel.Text = "Введите цену товара:";
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(295, 87);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(177, 23);
            priceTextBox.TabIndex = 3;
            // 
            // confirmButton
            // 
            confirmButton.Location = new Point(397, 226);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(75, 23);
            confirmButton.TabIndex = 4;
            confirmButton.Text = "Добавить";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 261);
            Controls.Add(confirmButton);
            Controls.Add(priceTextBox);
            Controls.Add(priceLabel);
            Controls.Add(nameTextBox);
            Controls.Add(nameLabel);
            Name = "AddProductForm";
            Text = "Add Product";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private TextBox nameTextBox;
        private Label priceLabel;
        private TextBox priceTextBox;
        private Button confirmButton;
    }
}