using Warehouse.Library.Services;

namespace Warehouse.Forms.Data.Modal
{
    public partial class AddProductForm : Form
    {
        private readonly IWarehouseService _warehouseService;

        public AddProductForm(IWarehouseService warehouseService)
        {
            InitializeComponent();
            _warehouseService = warehouseService;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string priceString = priceTextBox.Text;
            if (name is not null)
            {
                if (decimal.TryParse(priceString, out decimal price))
                {
                    _warehouseService.RecieveNewProduct(name, price);
                }
            }
        }
    }
}
