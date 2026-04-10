namespace Minesweeper.Core
{
    public class Board
    {
        /// <summary>
        /// The size of the board (small 8x8, medium 12x12, or large 16x16)
        /// </summary>
        public Size Size { get; set; }
        /// <summary>
        /// The number of mines on the board (8x8 = 10, 12x12 = 25, 16x16 = 40)
        /// </summary>
        public int Mines { get; set; }
        /// <summary>
        /// The number that determines the mine placement
        /// </summary>
        public int Seed { get; set; }
        public Board(Size size, int mines, int seed)
        {
            Size = size;
            Mines = mines;
            Seed = seed;
        }
        public void GenerateBoard(Size size, int mines, int seed)
        {
            if (size == Size.Small)
            {
                string[,] Board = new string[8,8];
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        //8x8
                    }
                }
            }
            if (size == Size.Medium)
            {
                //12x12
            }
            if (size == Size.Large)
            {
                //16x16
            }
        }
    }
}
