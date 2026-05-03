using Minesweeper.Core;
using Xunit;
using System.IO;

namespace Minesweeper.Tests
{
    public class Search
    {
        [Fact]
        public void Search_Test()
        {
            var board = new Board(Size.Small, 1);
            board.GenerateBoard(Size.Small);
            board.Cells[0, 0].isMine = false;

            board.Search(board, 0, 0);

            Assert.True(board.Cells[0, 0].isRevealed);
            //arrange act assert, I don't want to type it out for all ten of them
        }
    }
    }
}