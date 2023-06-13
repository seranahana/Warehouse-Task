using Microsoft.Extensions.DependencyInjection;
using Warehouse.Forms.Data;
using Warehouse.Forms.Reporting;

namespace Warehouse.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void navigateToRecievedFormButton_Click(object sender, EventArgs e)
        {
            RecievedForm recievedForm = ServicesProviderFactory.ServiceProvider.GetRequiredService<RecievedForm>();
            recievedForm.ShowDialog();
        }

        private void navigateToInStockFormButton_Click(object sender, EventArgs e)
        {
            InStockForm inStockForm = ServicesProviderFactory.ServiceProvider.GetRequiredService<InStockForm>();
            inStockForm.ShowDialog();
        }

        private void navigateToSoldFormButton_Click(object sender, EventArgs e)
        {
            SoldForm soldForm = ServicesProviderFactory.ServiceProvider.GetRequiredService<SoldForm>();
            soldForm.ShowDialog();
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = ServicesProviderFactory.ServiceProvider.GetRequiredService<ReportForm>();
            reportForm.ShowDialog();
        }
    }
}
