using Enrolle.Data;
using Enrolle.ViewModels;
using Enrolle.Views.Pages;
using Microsoft.EntityFrameworkCore;
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
            serviceCollection.AddDbContextFactory<DataContext, DataContextSqLiteFactory>();
            serviceCollection.AddSingleton<DataContext>(x => x.GetRequiredService<IDbContextFactory<DataContext>>().CreateDbContext());
            //Services
            serviceCollection.AddSingleton<INavigation, NavigationService>();
            serviceCollection.AddSingleton<IRepository<Specialization>, SpecialtiesRepository>();
            serviceCollection.AddSingleton<IRepository<Subject>, SubjectsRepository>();
            serviceCollection.AddSingleton<IRepository<Benefit>, BenefitsRepository>();
            serviceCollection.AddSingleton<IRepository<ApplicantBenefit>, ApplicantBenefitsRepository>();
            serviceCollection.AddSingleton<IRepository<Applicant>, ApplicantsRepository>();
            serviceCollection.AddSingleton<IRepository<Mark>, MarksRepository>();
            //ViewModels
            serviceCollection.AddSingleton<MainViewModel>();
            serviceCollection.AddTransient<MainPageViewModel>();
            serviceCollection.AddTransient<TablesChooseViewModel>();
            serviceCollection.AddTransient<SpecialtiesViewModel>();
            serviceCollection.AddTransient<SubjectsViewModel>();
            serviceCollection.AddTransient<BenefitsViewModel>();
            serviceCollection.AddTransient<ApplicantBenefitsViewModel>();
            serviceCollection.AddTransient<ApplicantsViewModel>();
            serviceCollection.AddTransient<MarksViewModel>();
            serviceCollection.AddTransient<MarksAddViewModel>();
        }
    }
}
