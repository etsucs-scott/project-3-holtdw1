using Minesweeper.Core;
using Xunit;
using System.IO;

namespace Minesweeper.Tests
{
    public class LoadGame
    {
        [Fact]
        public void LoadGame_Test()
        {
            // Arrange
            var filePath = Path.GetTempFileName();
            File.WriteAllText(filePath, "hs_50:moves_15:seed_5678:size_Medium");
            var fileIO = new FileIO();

            // Act
            fileIO.LoadGame();

            // Assert
            Assert.Equal(50, fileIO.HighScore);
            Assert.Equal(15, fileIO.Moves);
            Assert.Equal(5678, fileIO.Seed);
            Assert.Equal(Size.Medium, fileIO.Size);
        }
    }
}