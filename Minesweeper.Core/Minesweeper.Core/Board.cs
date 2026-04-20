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
            int ID = 0;//reset the cell id's
            for (int y = 0; y < size; y++) //increment y0 to y7 (8 total)
            {
                for (int x = 0; x < size; x++)//increment x0 to x7 (8 total)
                {
                    ID++;//increment the cell id for each cell, starting at 1 for readability
                    Cell cell = new Cell(x, y, ID);//make a new cell with the coordinates and id
                    Cells[x, y] = cell; //at position x, y in the array, place the new cell
                                        //I should be able to use this type of indexing to change cell states
                                        //Not sure if I have to use x, y  or just the ID yet
                                        //Maybe I can add an option to swap between them, to make the console easier
                }
            }
        }
        public void PlaceMines(int size, int seed)
        {
            if (seed == null)
            {
                seed = DateTime.Now.Millisecond; //if the seed is null, just make something up
            }
            //this makes the random algorithim work the same with the given seed
            Random random = new Random(seed);
            int x = random.Next(0, size);
            int y = random.Next(0, size);
            Cells[x, y] = ;
            /* I don't know what to do with it, though
            The mine count should be small = 10, medium = 25, large = 40

            */
        }
    }
}