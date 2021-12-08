using Enrolle.Data;
using Enrolle.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Enrolle
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost host;

        public App()
        {
            IConfiguration configuration = new ServiceConfiguration();

            host = Host.CreateDefaultBuilder()
                .ConfigureServices((h,s) => configuration.ConfigureServices(h,s))
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            host.Start();

            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            IDbContextFactory<DataContext> dataContextFactory = host.Services.GetRequiredService<IDbContextFactory<DataContext>>();

            using (DataContext dataContext = await dataContextFactory.CreateDbContextAsync())
            {
                await dataContext.Database.MigrateAsync();
            }

            MainWindow = new MainWindow()
            {
                DataContext = host.Services.GetRequiredService<MainViewModel>()
            };

            MainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            host.Dispose();

            base.OnExit(e);
        }
    }
}
