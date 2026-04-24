using System.Linq.Expressions;

namespace Minesweeper.Core
{
    public class Cell
    {
        /// <summary>
        /// If the cell contains a mine
        /// </summary>
        public bool isMine;
        /// <summary>
        /// If the cell has been revealed
        /// </summary>
        public bool isRevealed;
        /// <summary>
        /// If the cell has a flag on it
        /// </summary>
        public bool isFlagged;
        /// <summary>
        /// The number of mines adjacent to the cell
        /// </summary>
        public int adjacentMines;
        /// <summary>
        /// The x coodinate on the plane where the cell is
        /// </summary>
        public int X;
        /// <summary>
        /// The y coordinate on the plane where the cell is
        /// </summary>
        public int Y;
        public Cell(int x, int y, bool isMine, bool isRevealed, bool isFlagged, int adjacentMines)
        {
            X = x;
            Y = y;
            this.isMine = isMine;
            this.isRevealed = isRevealed;
            this.isFlagged = isFlagged;
            this.adjacentMines = adjacentMines;
        }
        /// <summary>
        /// Returns the actual representation of the cell's current state
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //pretty intuitive, if conditions show what the cell should display to the console
            if (isFlagged)
            {
                return "F"; //flag
            }
            if (!isRevealed)
            {
                return "#"; //not is revealed = hidden
            }
            if (isMine && isRevealed)
            {
                return "b"; //that means you hit a bomb
            }
            if (adjacentMines > 0)
            {
                return adjacentMines.ToString(); //should return the number of mines, showing the number
            }
            else return "."; //blank cell
        }
        public int Search(Board board, int x, int y)
        {
            int minesFound = 0;
            if (x - 1 !< 0) // make sure that you don't leave the bounds
            {
                if (board.Cells[x - 1, y].isMine == true) // search left
                {
                    minesFound++;
                }
                if (board.Cells[x - 1, y - 1].isMine == true) // search down left
                {
                    minesFound++;
                }
                if (board.Cells[x - 1, y + 1].isMine == true) // search up left
                {
                    minesFound++;
                }
            }
            if (board.Cells[x, y - 1].isMine == true) // search down
            {
                minesFound++;
            }
            if (board.Cells[x + 1, y].isMine == true) // search right
            {
                minesFound++;
            }
            if (board.Cells[x, y + 1].isMine == true) // search up
            {
                minesFound++;
            }
            if (board.Cells[x + 1, y + 1].isMine == true) // search up right
            {
                minesFound++;
            }
            if (board.Cells[x + 1, y - 1].isMine == true) // search down right
            {
                minesFound++;
            }
            return minesFound;
        }

    }
}
