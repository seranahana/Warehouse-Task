using Warehouse.Library.Entities;
using Warehouse.Library;

namespace Warehouse.Forms.Data
{
    partial class InStockForm
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
            components = new System.ComponentModel.Container();
            inStockDataGridView = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            sellToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)inStockDataGridView).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // inStockDataGridView
            // 
            inStockDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inStockDataGridView.Location = new Point(12, 12);
            inStockDataGridView.Name = "inStockDataGridView";
            inStockDataGridView.Size = new Size(776, 426);
            inStockDataGridView.TabIndex = 0;
            inStockDataGridView.CellMouseClick += InStockDataGridView_CellMouseClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { sellToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(121, 26);
            // 
            // sellToolStripMenuItem
            // 
            sellToolStripMenuItem.Name = "sellToolStripMenuItem";
            sellToolStripMenuItem.Size = new Size(120, 22);
            sellToolStripMenuItem.Text = "Продать";
            sellToolStripMenuItem.Click += SellToolStripMenuItem_Click;
            // 
            // InStockForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(inStockDataGridView);
            Name = "InStockForm";
            Text = "In Stock";
            Load += InStockForm_Load;
            ((System.ComponentModel.ISupportInitialize)inStockDataGridView).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private async void InStockForm_Load(object sender, EventArgs e)
        {
            IEnumerable<Product> inStockProducts = await _warehouseService.RetrieveAllProductsByStatus(ProductStatus.InStock);
            inStockDataGridView.DataSource = inStockProducts;
        }

        #endregion

        private DataGridView inStockDataGridView;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem sellToolStripMenuItem;
    }
}