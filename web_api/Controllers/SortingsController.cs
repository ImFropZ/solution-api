using Microsoft.AspNetCore.Mvc;
using web_api.Exceptions;
using web_api.Models;

namespace web_api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class SortingsController : ControllerBase
    {
        private readonly ILogger<TicTacToesController> _logger;
        private System.Timers.Timer? aTimer;

        public SortingsController(ILogger<TicTacToesController> logger)
        {
            _logger = logger;
        }

        [HttpPost("bubble-sort")]
        public IActionResult BubleSort([FromBody] SortingModel<double> sortingModel)
        {
            if (sortingModel.Data == null)
                throw new BadRequestException("The data is required");

            List<string> step = new List<string>();
            // Initialize first step of the sorting
            step.Add(string.Join(' ', sortingModel.Data));

            // If data is not enough it will response with same data
            if (sortingModel.Data.Count == 1)
                return Ok(new
                {
                    step,
                    result = sortingModel.Data[0]
                });

            // bubble sorting
            for (int i = 0; i < sortingModel.Data.Count - 1; i++)
                for (int j = i + 1; j < sortingModel.Data.Count; j++)
                    if (sortingModel.Data[i] > sortingModel.Data[j])
                    {
                        double temp = sortingModel.Data[i];
                        sortingModel.Data[i] = sortingModel.Data[j];
                        sortingModel.Data[j] = temp;
                        step.Add(string.Join(' ', sortingModel.Data));
                    }

            return Ok(new { step, result = sortingModel.Data });
        }
    }
}