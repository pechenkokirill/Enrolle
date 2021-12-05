using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.Data
{
    public class DesignTimeDataContextSqLiteFactory : IDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext()
        {
            return new DataContext(new DbContextOptionsBuilder<DataContext>().UseSqlite("Data Source=data.db").Options);
        }
    }
}
