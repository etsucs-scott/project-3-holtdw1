using Minesweeper.Core;

namespace Minesweeper.Tests
{
    public class PlaceMines
    {
        [Theory]
        [InlineData(8, 10)]
        [InlineData(12, 25)]
        [InlineData(16, 40)]
        public void PlaceMines_Test(int size, int expectedMines)
        {
            var board = new Board(Size.Small, 10);
            board.GenerateBoard((Size)size);

            board.PlaceMines(size, 1);

            int mineCount = 0;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (board.Cells[x, y].isMine) mineCount++;

            Assert.Equal(expectedMines, mineCount);
            //if this one works, the other two probably do 
        }
    }
}