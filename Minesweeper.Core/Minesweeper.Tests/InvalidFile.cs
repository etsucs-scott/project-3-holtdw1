using Minesweeper.Core;
using Xunit;
using System.IO;

namespace Minesweeper.Tests
{
    public class InvalidFile
    {
        [Fact]
        public void InvalidFile_Test()
        {
            // Arrange
            var filePath = Path.GetTempFileName();
            File.WriteAllText(filePath, "corrupted:data");
            var fileIO = new FileIO();

            // Act and Assert
            Assert.Throws<InvalidDataException>(() => fileIO.LoadGame());//should throw an exception because the data is wrong
        }
    }
    }
}