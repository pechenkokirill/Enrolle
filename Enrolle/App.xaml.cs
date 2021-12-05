using Enrolle.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            host.Start();

            MainWindow = new MainWindow()
            {
                DataContext = host.Services.GetRequiredService<MainViewModel>()
            };
        }

        protected override void OnExit(ExitEventArgs e)
        {
            host.Dispose();

            base.OnExit(e);
        }
    }
}
