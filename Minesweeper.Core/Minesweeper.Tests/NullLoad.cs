using Minesweeper.Core;
using Xunit;
using System.IO;

namespace Minesweeper.Tests
{
    public class NullLoad
    {
        [Fact]
        public void NullLoad_Test()
        {
            var fileIO = new FileIO();

            var exception = Record.Exception(() => fileIO.LoadGame());

            Assert.Null(exception);
        }
    }
}