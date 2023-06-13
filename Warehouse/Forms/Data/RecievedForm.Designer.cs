using Warehouse.Library;
using Warehouse.Library.Entities;

namespace Warehouse.Forms.Data
{
    partial class RecievedForm
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
            recievedDataGridView = new DataGridView();
            addButton = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            moveToInStockToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)recievedDataGridView).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // recievedDataGridView
            // 
            recievedDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            recievedDataGridView.Location = new Point(12, 12);
            recievedDataGridView.Name = "recievedDataGridView";
            recievedDataGridView.RowTemplate.Height = 25;
            recievedDataGridView.Size = new Size(776, 397);
            recievedDataGridView.TabIndex = 0;
            recievedDataGridView.CellMouseClick += RecievedDataGridView_CellMouseClick;
            // 
            // addButton
            // 
            addButton.Location = new Point(713, 415);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 1;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { moveToInStockToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(197, 26);
            // 
            // moveToInStockToolStripMenuItem
            // 
            moveToInStockToolStripMenuItem.Name = "moveToInStockToolStripMenuItem";
            moveToInStockToolStripMenuItem.Size = new Size(196, 22);
            moveToInStockToolStripMenuItem.Text = "Переместить на склад";
            moveToInStockToolStripMenuItem.Click += MoveToInStockToolStripMenuItem_Click;
            // 
            // RecievedForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(addButton);
            Controls.Add(recievedDataGridView);
            Name = "RecievedForm";
            Text = "Recieved";
            Load += RecievedForm_Load;
            ((System.ComponentModel.ISupportInitialize)recievedDataGridView).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private async void RecievedForm_Load(object sender, EventArgs e)
        {
            IEnumerable<Product> products = await _warehouseService.RetrieveAllProductsByStatus(ProductStatus.Recieved);
            recievedDataGridView.DataSource = products;
        }

        #endregion

        private DataGridView recievedDataGridView;
        private Button addButton;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem moveToInStockToolStripMenuItem;
    }
}