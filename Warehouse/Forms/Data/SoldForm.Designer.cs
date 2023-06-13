using Warehouse.Library.Entities;

namespace Warehouse.Forms.Data
{
    partial class SoldForm
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
            soldDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)soldDataGridView).BeginInit();
            SuspendLayout();
            // 
            // soldDataGridView
            // 
            soldDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            soldDataGridView.Location = new Point(12, 12);
            soldDataGridView.Name = "soldDataGridView";
            soldDataGridView.RowTemplate.Height = 25;
            soldDataGridView.Size = new Size(776, 426);
            soldDataGridView.TabIndex = 0;
            // 
            // SoldForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(soldDataGridView);
            Name = "SoldForm";
            Text = "Sold";
            Load += SoldForm_Load;
            ((System.ComponentModel.ISupportInitialize)soldDataGridView).EndInit();
            ResumeLayout(false);
        }

        private async void SoldForm_Load(object sender, EventArgs e)
        {
            IEnumerable<Product> products = await _warehouseService.RetrieveAllProductsByStatus(Library.ProductStatus.Sold);
            soldDataGridView.DataSource = products;
        }

        #endregion

        private DataGridView soldDataGridView;
    }
}