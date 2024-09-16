using Assignment1_PRN221_Library.IRepository;
using Assignment1_PRN221_Library.Models;
using Assignment1_PRN221_Library.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            //Config Configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            services.AddSingleton<IConfiguration>(configuration);
            //Config Database
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //Config Repository
            services.AddSingleton<IMemberRepository, MemberRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IOrderDetailRepository, OrderDetailRepository>();
            //Config Window
            services.AddTransient<LoginWindow>();
            services.AddTransient<MemberManagementWindow>();
            services.AddTransient<ManagementWindow>();
            services.AddTransient<MemberProfile>();
            services.AddTransient<OrderHistoryWindow>();
            services.AddTransient<CategoryManagementWindow>();
            services.AddTransient<ProductManagementWindow>();
            services.AddTransient<OrderManagementWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var loginWindow = serviceProvider.GetService<LoginWindow>();
            loginWindow.Show();
        }
    }

}
