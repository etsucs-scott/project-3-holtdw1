using Minesweeper.Core;
using Xunit;
using System.IO;

namespace Minesweeper.Tests
{
    public class SaveGame
    {
        [Fact]
        public void SaveGame_Test()
        {
            // Arrange
            var filePath = Path.GetTempFileName();
            var fileIO = new FileIO();

            // Act
            fileIO.SaveGame(42, 10, 1234, Size.Small);

            // Assert
            string content = File.ReadAllText(filePath);
            Assert.Equal($"hs_42:moves_10:seed_1234:size_Small", content);
        }
    }
}