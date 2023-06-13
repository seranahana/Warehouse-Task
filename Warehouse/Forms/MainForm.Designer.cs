namespace Warehouse.Forms
{
    partial class MainForm
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
            navigateToRecievedFormButton = new Button();
            navigateToInStockFormButton = new Button();
            navigateToSoldFormButton = new Button();
            reportButton = new Button();
            SuspendLayout();
            // 
            // navigateToRecievedFormButton
            // 
            navigateToRecievedFormButton.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            navigateToRecievedFormButton.Location = new Point(30, 150);
            navigateToRecievedFormButton.Name = "navigateToRecievedFormButton";
            navigateToRecievedFormButton.Size = new Size(200, 50);
            navigateToRecievedFormButton.TabIndex = 0;
            navigateToRecievedFormButton.Text = "Принят";
            navigateToRecievedFormButton.UseVisualStyleBackColor = true;
            navigateToRecievedFormButton.Click += navigateToRecievedFormButton_Click;
            // 
            // navigateToInStockFormButton
            // 
            navigateToInStockFormButton.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            navigateToInStockFormButton.Location = new Point(290, 150);
            navigateToInStockFormButton.Name = "navigateToInStockFormButton";
            navigateToInStockFormButton.Size = new Size(200, 50);
            navigateToInStockFormButton.TabIndex = 1;
            navigateToInStockFormButton.Text = "Склад";
            navigateToInStockFormButton.UseVisualStyleBackColor = true;
            navigateToInStockFormButton.Click += navigateToInStockFormButton_Click;
            // 
            // navigateToSoldFormButton
            // 
            navigateToSoldFormButton.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            navigateToSoldFormButton.Location = new Point(550, 150);
            navigateToSoldFormButton.Name = "navigateToSoldFormButton";
            navigateToSoldFormButton.Size = new Size(200, 50);
            navigateToSoldFormButton.TabIndex = 2;
            navigateToSoldFormButton.Text = "Продан";
            navigateToSoldFormButton.UseVisualStyleBackColor = true;
            navigateToSoldFormButton.Click += navigateToSoldFormButton_Click;
            // 
            // reportButton
            // 
            reportButton.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            reportButton.Location = new Point(290, 250);
            reportButton.Name = "reportButton";
            reportButton.Size = new Size(200, 50);
            reportButton.TabIndex = 3;
            reportButton.Text = "Отчёт";
            reportButton.UseVisualStyleBackColor = true;
            reportButton.Click += reportButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 361);
            Controls.Add(reportButton);
            Controls.Add(navigateToSoldFormButton);
            Controls.Add(navigateToInStockFormButton);
            Controls.Add(navigateToRecievedFormButton);
            Name = "MainForm";
            Text = "Main";
            ResumeLayout(false);
        }

        #endregion

        private Button navigateToRecievedFormButton;
        private Button navigateToInStockFormButton;
        private Button navigateToSoldFormButton;
        private Button reportButton;
    }
}