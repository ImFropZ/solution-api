using web_api.Models;
using web_api.Repositories;
using static web_api.Repositories.ITicTacToeRepository;

namespace web_api.UnitTest
{
    public class TicTacToeTest
    {
        [Fact]
        public void Check_Validation()
        {
            // Arrange
            TicTacToeRepository ticTacToeRepository = new TicTacToeRepository();
            List<bool> expectedValue = new List<bool> { true, true, false, false, false, true };

            List<string> patterns = new List<string> {
                "xxxoo----",
                "x--oo--x-",
                "x",
                "xxo",
                "oo----x--",
                "x--o---x-",
            };

            // Act
            List<bool> actual = new List<bool>();

            patterns.ForEach(pattern =>
            {
                actual.Add(ticTacToeRepository.IsValid(new TicTacToeModel() { Pattern = pattern }));
            });


            // Assert
            Assert.Equal(expectedValue, actual);
        }

        [Fact]
        public void Check_Who_Turn()
        {
            // Arrange
            TicTacToeRepository ticTacToeRepository = new TicTacToeRepository();
            List<Player> expectedValue = new List<Player> { Player.x, Player.o, Player.x, Player.none };

            List<string> patterns = new List<string> {
                "xx-oo----",
                "x-xoo--x-",
                "x--o---xo",
                "xxxoooxxo",
            };

            // Act
            List<Player> actual = new List<Player>();

            patterns.ForEach(pattern =>
            {
                actual.Add(ticTacToeRepository.Turn(new TicTacToeModel() { Pattern = pattern }));
            });


            // Assert
            Assert.Equal(expectedValue, actual);
        }
    }
}