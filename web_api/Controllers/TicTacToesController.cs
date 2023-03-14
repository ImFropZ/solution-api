using Microsoft.AspNetCore.Mvc;
using web_api.Exceptions;
using web_api.Models;
using web_api.Repositories;

namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicTacToesController : ControllerBase
    {
        private readonly ILogger<TicTacToesController> _logger;
        private readonly ITicTacToeRepository _ticTacToeRepository;

        public TicTacToesController(ILogger<TicTacToesController> logger, ITicTacToeRepository ticTacToeRepository)
        {
            _logger = logger;
            _ticTacToeRepository = ticTacToeRepository;
        }

        [HttpGet("is-winner")]
        public IActionResult IsWinner([FromQuery] TicTacToeModel model)
        {
            if (!_ticTacToeRepository.IsValid(model))
                throw new BadRequestException("The pattern of the TicTacToe is invalid");
            var player = _ticTacToeRepository.Winner(model);
            return Ok(player);
        }
    }
}
