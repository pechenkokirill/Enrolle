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
            serviceCollection.AddSingleton<DataContext>(s => s.GetRequiredService<IDbContextFactory<DataContext>>().CreateDbContext());
            //Services
            serviceCollection.AddSingleton<INavigation, NavigationService>();
            serviceCollection.AddTransient<IRepository<Specialization>, SpecialtiesRepository>();
            serviceCollection.AddTransient<IRepository<Subject>, SubjectsRepository>();
            serviceCollection.AddTransient<IRepository<Benefit>, BenefitsRepository>();
            serviceCollection.AddTransient<IRepository<ApplicantBenefit>, ApplicantBenefitsRepository>();
            serviceCollection.AddTransient<IRepository<Applicant>, ApplicantsRepository>();
            serviceCollection.AddTransient<IRepository<Mark>, MarksRepository>();
            //States
            serviceCollection.AddSingleton<BusyStore>();
            //ViewModels
            serviceCollection.AddSingleton<MainViewModel>();
            serviceCollection.AddScoped<MainPageViewModel>();
            serviceCollection.AddScoped<TablesChooseViewModel>();
            serviceCollection.AddScoped<SpecialtiesViewModel>(s => SpecialtiesViewModel.BuildAndLoad(s));
            serviceCollection.AddScoped<SubjectsViewModel>(s => SubjectsViewModel.BuildAndLoad(s));
            serviceCollection.AddScoped<BenefitsViewModel>(s => BenefitsViewModel.BuildAndLoad(s));
            serviceCollection.AddScoped<ApplicantBenefitsViewModel>(s => ApplicantBenefitsViewModel.BuildAndLoad(s));
            serviceCollection.AddScoped<ApplicantsViewModel>(s => ApplicantsViewModel.BuildAndLoad(s));
            serviceCollection.AddScoped<MarksViewModel>(s => MarksViewModel.BuildAndLoad(s));
            serviceCollection.AddTransient<MarksAddViewModel>();
        }
    }
}
