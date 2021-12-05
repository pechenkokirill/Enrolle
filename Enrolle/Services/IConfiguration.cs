using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.Services
{
    public interface IConfiguration
    {
        void ConfigureServices(HostBuilderContext context,IServiceCollection serviceCollection);
    }
}
