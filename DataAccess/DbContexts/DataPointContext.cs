using Microsoft.EntityFrameworkCore;
using TimeSeries;
using TimeSeries.Model;

namespace TimeSeries.DataAccess
{
    public class DataPointContext : DbContext
    {
        public DataPointContext(DbContextOptions<DataPointContext> options) : base(options)
        {
        }

        public DbSet<DataPoint> DataPoints { get; set; }
    }
}
