using web_api.Exceptions;
using web_api.Models;
using static web_api.Repositories.ITicTacToeRepository;

namespace web_api.Repositories
{
    public class TicTacToeRepository : ITicTacToeRepository
    {
        public bool IsValid(TicTacToeModel model)
        {
            if (model.Pattern == null)
                throw new BadRequestException("The pattern is required");

            var array = model.Pattern.ToCharArray();

            if (array.Length != 9 )
                return false;

            int countX = 0;
            int countO = 0;

            foreach (char c in array)
            {
                if (c.Equals('x')) { countX++; }
                else if (c.Equals('o')) { countO++; }
                else if (!c.Equals('-')) { return false; }
            }

            if (countX == countO + 1 || countX == countO)
                return true;
            return false;
        }

        public Player Turn(TicTacToeModel model)
        {
            if (model.Pattern == null)
                throw new BadRequestException("The pattern is required");

            char[] array = model.Pattern.ToCharArray();
            int countX = 0;
            int countO = 0;

            if (IsBoardFull(model))
                return Player.none;

            foreach (char c in array)
            {
                if (c.Equals('x')) { countX++; }
                if (c.Equals('o')) { countO++; }
            }

            if (countX == countO + 1)
            {
                return Player.o;
            }
            return Player.x;
        }

        public Player Winner(TicTacToeModel model)
        {
            if (model.Pattern == null)
                throw new BadRequestException("The pattern is required");

            char[] array = model.Pattern.ToCharArray();

            // Diagonal
            if (
                array[4] != '-' &&
                (array[4] == array[0] && array[4] == array[8] ||
                array[4] == array[2] && array[4] == array[6]))
            {
                return (array[4] == 'x') ? Player.x : Player.o;
            }

            for (int i = 0; i < 3; i++)
            {
                // Horizontal
                if (array[i * 3] != '-' && array[i * 3] == array[i * 3 + 1] && array[i * 3] == array[i * 3 + 2])
                {
                    return (array[i * 3] == 'x') ? Player.x : Player.o;
                }

                // Vertical
                if (array[i] != '-' && array[i] == array[i + 3] && array[i] == array[i + 6])
                {
                    return (array[i] == 'x') ? Player.x : Player.o;
                }
            }

            return (IsBoardFull(model)) ? Player.draw : Player.none;
        }

        public bool IsBoardFull(TicTacToeModel model)
        {
            if (model.Pattern == null)
                throw new BadRequestException("The pattern is required");

            char[] array = model.Pattern.ToCharArray();
            foreach (char c in array)
                if (c.Equals('-')) return false;
            return true;
        }
    }
}
