using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Warehouse.Forms.Data;
using Warehouse.Forms.Data.Modal;
using Warehouse.Forms.Reporting;
using Warehouse.Library.Services;
using Warehouse.Library.Storage;
using Warehouse.Library.Storage.Context;

namespace Warehouse
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WarehouseContext>(options => options.UseSqlServer(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString));

            // Form
            services.AddScoped<InStockForm>();
            services.AddScoped<RecievedForm>();
            services.AddScoped<SoldForm>();
            services.AddScoped<ReportForm>();
            services.AddScoped<AddProductForm>();

            // Repositories
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IStatusesRepository, StatusesRepository>();
            services.AddScoped<ITransitionsRepository, TransitionsRepository>();

            // Services
            services.AddScoped<IWarehouseService, WarehouseService>();
        }
    }
}
