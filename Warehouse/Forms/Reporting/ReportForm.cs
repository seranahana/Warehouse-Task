using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse.Library;
using Warehouse.Library.Entities;
using Warehouse.Library.Services;

namespace Warehouse.Forms.Reporting
{
    public partial class ReportForm : Form
    {
        private readonly IWarehouseService _warehouseService;
        private string selectedStatus;
        private DateTime selectedFromDate;
        private DateTime selectedToDate;

        public ReportForm(IWarehouseService warehouseService)
        {
            InitializeComponent();
            _warehouseService = warehouseService;
            FillStatusesComboBox();
            fromTransitionDateTimePicker.Value = DateTime.UtcNow;
            toTransitionDateTimePicker.Value = DateTime.UtcNow;
        }

        private async void StatusesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedStatus = statusesComboBox.SelectedItem.ToString();
            await GetResult();
        }

        private async void FromTransitionDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            selectedFromDate = fromTransitionDateTimePicker.Value;
            await GetResult();
        }

        private async void ToTransitionDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            selectedToDate = toTransitionDateTimePicker.Value;
            await GetResult();
        }

        private async Task GetResult()
        {
            if (selectedFromDate < selectedToDate)
            {
                reportDataGridView.DataSource = null;
                reportDataGridView.DataSource = await _warehouseService.RetrieveAllProductsByFilter(selectedStatus, selectedFromDate, selectedToDate);
            }
        }
    }
}
