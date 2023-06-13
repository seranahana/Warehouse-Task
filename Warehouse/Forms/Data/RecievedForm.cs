using Microsoft.Extensions.DependencyInjection;
using Warehouse.Forms.Data.Modal;
using Warehouse.Library;
using Warehouse.Library.Services;

namespace Warehouse.Forms.Data
{
    public partial class RecievedForm : Form
    {
        private readonly IWarehouseService _warehouseService;
        private Guid productToMoveInStockId = Guid.Empty;

        public RecievedForm(IWarehouseService warehouseService)
        {
            InitializeComponent();
            _warehouseService = warehouseService;
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = ServicesProviderFactory.ServiceProvider.GetRequiredService<AddProductForm>();
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                recievedDataGridView.DataSource = await _warehouseService.RetrieveAllProductsByStatus(ProductStatus.Recieved);
            }
        }

        private void RecievedDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (Guid.TryParse(recievedDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString(), out productToMoveInStockId))
                {
                    recievedDataGridView.CurrentCell = recievedDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    contextMenuStrip1.Show(recievedDataGridView, e.Location);
                }
            }
        }

        private async void MoveToInStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productToMoveInStockId != Guid.Empty)
            {
                await _warehouseService.ChangeProductStatus(productToMoveInStockId, ProductStatus.InStock);
                recievedDataGridView.DataSource = await _warehouseService.RetrieveAllProductsByStatus(ProductStatus.Recieved);
            }
        }
    }
}
