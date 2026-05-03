using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core
{
    public class FileIO
    {
        /// <summary>
        /// The entire data string, delineated by a colon
        /// </summary>
        public string SaveData;
        /// <summary>
        /// The fastest completion time in seconds
        /// </summary>
        public int HighScore;
        /// <summary>
        /// Moves used during the run
        /// </summary>
        public int Moves;
        /// <summary>
        /// The seed that determined the mine placement
        /// </summary>
        public int Seed;
        /// <summary>
        /// The size of board used
        /// </summary>
        public Size Size;
        /// <summary>
        /// 
        /// </summary>
        string FilePath;
        public void SaveGame(int highScore, int moves, int seed, Size size)
        {
            SaveData = $"hs_{highScore}:moves_{moves}:seed_{seed}:size_{size}";
            FilePath = "./Minesweeper_Save.txt";
            File.WriteAllText(FilePath,SaveData);
        }
        public void LoadGame(Board board)
        {
            string content = File.ReadAllText(FilePath);
            var c = content.Split(':');
            board.Score = c[0];
            string moves = c[1];
        }
    }
}
