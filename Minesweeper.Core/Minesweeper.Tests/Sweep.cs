using Minesweeper.Core;
using Xunit;
using System.IO;

namespace Minesweeper.Tests
{
    public class Sweep
    {
        [Fact]
        public void Sweep_Test()
        {
            var board = new Board(Size.Small, 1);
            board.GenerateBoard(Size.Small);

            board.Cells[1, 1].Sweep(board, 1, 1);

            int sumAdjacent = board.Cells[0, 0].adjacentMines +
                              board.Cells[0, 1].adjacentMines +
                              board.Cells[0, 2].adjacentMines +
                              board.Cells[1, 0].adjacentMines +
                              board.Cells[1, 2].adjacentMines +
                              board.Cells[2, 0].adjacentMines +
                              board.Cells[2, 1].adjacentMines +
                              board.Cells[2, 2].adjacentMines;

            Assert.Equal(8, sumAdjacent);
        }
    }
}