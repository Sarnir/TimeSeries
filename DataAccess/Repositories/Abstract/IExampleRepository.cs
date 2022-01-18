using Microsoft.AspNetCore.Mvc;
using TimeSeries.Model;

namespace TimeSeries.DataAccess
{
    public interface IExampleRepository
    {
        Task<ActionResult<List<DataPoint>>> GetExampleByIdAsync(string exampleId);
        Task AddDataPointsAsync(DataPoint[] dataPoints);
        Task<ActionResult<IEnumerable<DataPoint>>> GetAllAsync();
    }
}
