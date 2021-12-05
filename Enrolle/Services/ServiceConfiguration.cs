using Enrolle.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.Services
{
    public class ServiceConfiguration : IConfiguration
    {
        public void ConfigureServices(HostBuilderContext context, IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<MainViewModel>();
        }
    }
}
