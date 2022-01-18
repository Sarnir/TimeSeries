using Microsoft.AspNetCore.Mvc;
using TimeSeries.Model;

namespace TimeSeries.BusinessLogic
{
    public interface ICalculationService
    {
        ValueTask<DataPointCalc> CalculateExampleDataAsync(string exampleId, long? from, long? to);
        Task AddAsync(DataPoint[] dataPoints);
        Task<ActionResult<IEnumerable<DataPoint>>> GetAllAsync();
    }
}
