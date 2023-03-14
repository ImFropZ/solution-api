using web_api.Models;

namespace web_api.Repositories
{
    public interface ITicTacToeRepository
    {
        enum Player { x, o, draw, none };

        public bool IsValid(TicTacToeModel model);
        public Player Winner(TicTacToeModel model);
        public Player Turn(TicTacToeModel model);
    }
}