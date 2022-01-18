using Microsoft.AspNetCore.Mvc;
using TimeSeries.BusinessLogic;
using TimeSeries.Model;

namespace TimeSeries.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    //[Authorize]
    // TODO: 
    public class APIController : ControllerBase
    {
        private readonly ICalculationService calculationService;

        public APIController(ICalculationService calculationService)
        {
            this.calculationService = calculationService;
        }

        // GET: api/example1
        [HttpGet("{exampleId}")]
        public async Task<ActionResult<DataPointCalc>> GetExampleAsync(string exampleId, long? from, long? to)
        {
            var calcs = await calculationService.CalculateExampleDataAsync(exampleId, from, to);


            if (calcs == null)
            {
                return NoContent();
            }

            return calcs;
        }

        // GET: api
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<DataPoint>>> GetDataPointsAsync()
        {
            return await calculationService.GetAllAsync();
        }

        // POST: api/
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostDataPointsAsync(DataPoint[] dataPoints)
        {
            await calculationService.AddAsync(dataPoints);

            return CreatedAtAction(null, null);
        }
    }
}
