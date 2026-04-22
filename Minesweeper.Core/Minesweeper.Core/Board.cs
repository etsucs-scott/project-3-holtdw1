namespace Minesweeper.Core
{
    public class Board
    {
        /// <summary>
        /// The cells on the board
        /// </summary>
        public Cell[,] Cells { get; set; }
        /// <summary>
        /// The size of the board (small 8x8, medium 12x12, or large 16x16)
        /// </summary>
        public Size Size { get; set; }
        /// <summary>
        /// The number that determines the mine placement
        /// </summary>
        public int Seed { get; set; }
        public Board(Size size, int seed)
        {
            Size = size;
            Seed = seed;
            Cells = new Cell[0, 0]; //just make something so I can change it later without blowing up
        }
        /// <summary>
        /// Generates the board, taking in size, number of mines, and the seed
        /// </summary>
        /// <param name="size"></param>
        /// <param name="mines"></param>
        /// <param name="seed"></param>
        public void GenerateBoard()
        {
            int size = (int)Size;
            Cells = new Cell[size, size];//makes a 2d array of cells
            for (int y = 0; y < size; y++) //increment y0 to y7 (8 total)
            {
                for (int x = 0; x < size; x++)//increment x0 to x7 (8 total)
                {
                    Cell cell = new Cell(x, y, false, false, false, 0);//make a new cell with the coordinates and id
                    Cells[x, y] = cell; //at position x, y in the array, place the new cell
                                        //I should be able to use this type of indexing to change cell states
                                        //Not sure if I have to use x, y  or just the ID yet
                                        //Maybe I can add an option to swap between them, to make the console easier
                }
            }
        }
        /// <summary>
        /// Places mines at random
        /// </summary>
        /// <param name="size"></param>
        /// <param name="seed"></param>
        public void PlaceMines(int size, int seed)
        {
            int minesPlaced = 0;
            if (seed == null)
            {
                seed = DateTime.Now.Millisecond; //if the seed is null, just make something up
            }
            //this makes the random algorithim work the same with the given seed
            Random random = new Random(seed);

            if (size == 8)
            {
                while(minesPlaced < 11)
                {
                    int x = random.Next(0, size);
                    int y = random.Next(0, size);
                    Cells[x, y] = new Cell(x, y, true, false, false, 0);
                    minesPlaced++;
                }
            }
            if (size == 12)
            {
                while(minesPlaced < 26)
                {
                    int x = random.Next(0, size);
                    int y = random.Next(0, size);
                    Cells[x, y] = new Cell(x, y, true, false, false, 0);
                    minesPlaced++;
                }
            }
            if (size == 16)
            {
                while(minesPlaced < 41)
                {
                    int x = random.Next(0, size);
                    int y = random.Next(0, size);
                    Cells[x, y] = new Cell(x, y, true, false, false, 0);
                    minesPlaced++;
                }
            }
            /* I don't know what to do with it, though
            The mine count should be small = 10, medium = 25, large = 40

            */
        }
    }
}