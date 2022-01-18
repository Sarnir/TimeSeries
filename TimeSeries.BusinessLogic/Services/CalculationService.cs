using Microsoft.AspNetCore.Mvc;
using TimeSeries.DataAccess;
using TimeSeries.Model;

namespace TimeSeries.BusinessLogic
{
    public class CalculationService : ICalculationService
    {
        readonly IExampleRepository repository;
        public CalculationService(IExampleRepository repository)
        {
            this.repository = repository;
        }

        async public Task AddAsync(DataPoint[] dataPoints)
        {
            await repository.AddDataPointsAsync(dataPoints);
        }

        async public ValueTask<DataPointCalc> CalculateExampleDataAsync(string exampleId, long? from, long? to)
        {
            var dataPoints = repository.GetExampleByIdAsync(exampleId).Result.Value;

            if (dataPoints == null || dataPoints.Count == 0)
            {
                return await new ValueTask<DataPointCalc>(); // is this ok?
            }
            var pointsInRange = dataPoints.Where((p) => (from == default || p.t >= from) && (to == default || p.t <= to));

            if (pointsInRange.Count() == 0)
                return await new ValueTask<DataPointCalc>(); // is this ok?

            var sum = pointsInRange.Sum((p) => p.v);
            var avg = pointsInRange.Average((p) => p.v);

            var calc = new DataPointCalc { sum = sum, avg = avg };

            return await new ValueTask<DataPointCalc>(calc);
        }

        public async Task<ActionResult<IEnumerable<DataPoint>>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
    }
}
