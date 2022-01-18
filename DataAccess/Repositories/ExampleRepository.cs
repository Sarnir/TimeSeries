using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeSeries.Model;

namespace TimeSeries.DataAccess
{
    public class ExampleRepository : IExampleRepository
    {
        DataPointContext _dbContext;
        public ExampleRepository(DataPointContext dbContext)
        {
            _dbContext = dbContext;
        }

        async public Task AddDataPointsAsync(DataPoint[] dataPoints)
        {
            _dbContext.DataPoints.AddRange(dataPoints);

            await _dbContext.SaveChangesAsync();
        }

        async public Task<ActionResult<IEnumerable<DataPoint>>> GetAllAsync()
        {
            return await _dbContext.DataPoints.ToListAsync();
        }

        async public Task<ActionResult<List<DataPoint>>> GetExampleByIdAsync(string exampleId)
        {
            return await _dbContext.DataPoints.Where((p) => p.name != null && p.name.Equals(exampleId)).ToListAsync();
        }

        // TODO: other CRUD methods if necessary
    }
}
