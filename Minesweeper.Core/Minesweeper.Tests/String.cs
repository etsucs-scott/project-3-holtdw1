using Minesweeper.Core;
using Xunit;
using System.IO;

namespace Minesweeper.Tests
{
    public class String
    {
        [Theory]
        [InlineData(true, false, false, 0, "b")]
        [InlineData(false, false, false, 0, "#")]
        [InlineData(false, true, false, 2, "2")]
        [InlineData(false, false, true, 0, "F")]
        public void ToString_Test(bool isMine, bool isRevealed, bool isFlagged, int adjacent, string expected)
        {
            var cell = new Cell(0, 0, isMine, isRevealed, isFlagged, adjacent);
            Assert.Equal(expected, cell.ToString());
        }
    }
}