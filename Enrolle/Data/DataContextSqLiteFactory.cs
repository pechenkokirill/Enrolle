using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.Data
{
    public class DataContextSqLiteFactory : IDbContextFactory<DataContext>
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;

        public DataContextSqLiteFactory(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DataContext CreateDbContext()
        {
            DbContextOptions dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseSqlite(configuration.GetConnectionString("SqLite"))
                .Options;

            return new DataContext(dbContextOptions);
        }
    }
}
