using Minesweeper.Core;

namespace Minesweeper.Tests
{
    public class BoardGeneration
    {
        [Theory]
        [InlineData(Size.Small, 8)]
        [InlineData(Size.Medium, 12)]
        [InlineData(Size.Large, 16)]
        public void BoardGeneration_Test(Size size, int expectedLength)
        {
            var board = new Board(size, 1);

            board.GenerateBoard(size);

            Assert.Equal(expectedLength, board.Cells.GetLength(0));
            Assert.Equal(expectedLength, board.Cells.GetLength(1));
        }
    }
}