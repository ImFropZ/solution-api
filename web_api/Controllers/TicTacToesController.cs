using Microsoft.AspNetCore.Mvc;
using web_api.Exceptions;
using web_api.Models;
using web_api.Repositories;
using static web_api.Repositories.ITicTacToeRepository;

namespace web_api.Controllers
{
    [ApiController]
    [Produces("application/json")]
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

        [HttpGet("resolve")]
        public IActionResult Resolve([FromQuery] TicTacToeModel model)
        {
            if (!_ticTacToeRepository.IsValid(model))
                throw new BadRequestException("The pattern of the TicTacToe is invalid");
            var player = _ticTacToeRepository.Winner(model);

            string state = "Game doesn't end yet.";

            switch (player)
            {
                case Player.o:
                    state = "Player 'O' is the winner.";
                    break;
                case Player.x:
                    state = "Player 'X' is the winner.";
                    break;
                case Player.draw:
                    state = "It's draw.";
                    break;
            }

            return Ok(new
            {
                state
            });
        }
    }
}
