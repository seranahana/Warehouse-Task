using Warehouse.Library;
using Warehouse.Library.Services;

namespace Warehouse.Forms.Data
{
    public partial class InStockForm : Form
    {
        private readonly IWarehouseService _warehouseService;
        private Guid productToSellId = Guid.Empty;

        public InStockForm(IWarehouseService warehouseService)
        {
            InitializeComponent();
            _warehouseService = warehouseService;
        }

        private void InStockDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (Guid.TryParse(inStockDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString(), out productToSellId))
                {
                    inStockDataGridView.CurrentCell = inStockDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    contextMenuStrip1.Show(inStockDataGridView, e.Location);
                }
            }
        }

        private async void SellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productToSellId != Guid.Empty)
            {
                await _warehouseService.ChangeProductStatus(productToSellId, ProductStatus.Sold);
                inStockDataGridView.DataSource = await _warehouseService.RetrieveAllProductsByStatus(ProductStatus.InStock);
            }
        }
    }
}
