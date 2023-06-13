using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse.Library.Services;

namespace Warehouse.Forms.Data
{
    public partial class SoldForm : Form
    {
        private readonly IWarehouseService _warehouseService;

        public SoldForm(IWarehouseService warehouseService)
        {
            InitializeComponent();
            _warehouseService = warehouseService;
        }
    }
}
