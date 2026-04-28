using Minesweeper.Core;
bool main = true;
while (main = true)
{
    //I think this little menu is cute
    Console.WriteLine("--------------------Minesweeper Clone V0.01 - Alpha Build--------------");
    Console.WriteLine("|-------------------Main Menu-----------------------------------------|");
    Console.WriteLine("|1. New Game                                                          |");
    Console.WriteLine("|2. High Scores                                                       |");
    Console.WriteLine("|3. Exit                                                              |");
    Console.WriteLine("-----------------------------------------------------------------------");
    Console.Write("Input a number, and press enter to continue: ");

    bool gameState = true;
    Board board;//was having scoping issues, so I'm defining it here, initializing later
    while (gameState == true) //set to false to break the entire loop
    {
        string? input = Console.ReadLine();
        Console.WriteLine(); //formatting

        if (int.TryParse(input, out int choice) == false) //with tryparse, it takes in the input. If it screws up
        {//, it returns a false bool. If it works, it returns true and assigns "choice" as a local int for use
            Console.WriteLine("Invalid input! You need a number. Please try again.");
        }
        else if ((choice != 1 && choice != 2 && choice != 3))//if choice doesn't do anything, try again
        {
            Console.WriteLine("Invalid input! Please try again.");
        }
        else
        {
            if (choice == 1)//new game, display menu for size choice
            {
                Console.Clear(); //empties the main menu that we're not using anymore
                Console.WriteLine("--------------------Choose the board size------------------------------");
                Console.WriteLine("|1. Small board - 8x8 with 10 mines                                   |");
                Console.WriteLine("|2. Medium board - 12x12 with 25 mines                                |");
                Console.WriteLine("|3. Large board - 16x16 with 40 mines                                 |");
                Console.WriteLine("|4. Back                                                              |");
                Console.WriteLine("-----------------------------------------------------------------------\n");
                Console.Write("Input a number, and press enter to continue: ");

                while (true) //this just keeps the loop going to recollect inputs
                {
                    string? input2 = Console.ReadLine(); //input is technically in the same scope, so I made a new one
                    Console.WriteLine();//formatting

                    if (int.TryParse(input2, out int choice2) == false)//same with choice
                    {
                        Console.WriteLine("Invalid input! You need a number. Please try again.");
                    }
                    else if ((choice2 != 1 && choice2 != 2 && choice2 != 3 && choice2 != 4))
                    {
                        Console.WriteLine("Invalid input! Please try again.");
                    }
                    else
                    {
                        //-------This section is the logic for small maps----------------
                        if (choice2 == 1)
                        {
                            Console.WriteLine("Please input the map seed here, or leave blank for a random one: ");
                            string? input3 = Console.ReadLine();//same scoping issue
                            if (int.TryParse(input3, out int seed) == false)//false means the parsing didn't work
                            {
                                Console.WriteLine("Input was not a number, or was left blank. Generating random seed...");
                                board = new Board(Size.Small, null);
                                Thread.Sleep(500);//pauses for half a second to pretend we're doing something
                                                  //slight issue: the user only gets one shot here
                            }
                            else//meaning if the parsing works
                            {
                                Console.WriteLine($"Generating board with seed: {seed}\n");
                                board = new Board(Size.Small, seed);
                            }
                            board.GenerateBoard(Size.Small);//makes the grid
                            board.PlaceMines((int)Size.Small, board.Seed);//handles if the seed is null by itself
                                                                          //that little (int) means to treat the size as an int, not as an enum. This works
                                                                          //because each size has a number tied to it. Size.Small is just easier to read

                            bool running = true;
                            while (running == true)
                            {
                                board.ShowBoard();//show the updated board on each loop

                                //-------This section validates user input for changing tile states-----------------
                                Console.WriteLine("Input the action for the tile - flag (f), reveal (r): ");
                                string action = Console.ReadLine().ToLower();
                                while (true)
                                {
                                    while (action.ToLower() != "f" && action.ToLower() != "r" && action.ToLower() != "q")
                                    {
                                        Console.WriteLine("Invalid input! Please input just 'f' or 'r' (or 'q' to quit)");
                                        action = Console.ReadLine().ToLower();
                                    }
                                    if (action.ToLower() == "q")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Returning to main menu...");
                                        Thread.Sleep(500);
                                        running = false; //basically goes back to main menu
                                    }
                                    break;
                                }

                                Console.WriteLine($"Input the row to interact with (1 - {(int)board.Size}) or q to quit:");
                                string row = Console.ReadLine().ToLower();
                                while (true)
                                {
                                    if (row.ToLower() == "q")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Returning to main menu...");
                                        Thread.Sleep(500);
                                        running = false; //basically goes back to main menu
                                    }
                                    if (int.TryParse(row, out int y) == false)//false means the parsing didn't work
                                    {
                                        Console.WriteLine("Input was not a number, please try again");
                                        row = Console.ReadLine().ToLower();
                                    }
                                    else//meaning if the parsing works
                                    {
                                        while (y < 1 || y > (int)board.Size)//checks bounds
                                        {
                                            Console.WriteLine("Input was out of bounds, please try again");
                                            row = Console.ReadLine().ToLower();
                                        }
                                        break;
                                    }
                                }

                                Console.WriteLine($"Input the column to interact with (1 - {(int)board.Size}) or q to quit:");
                                string column = Console.ReadLine().ToLower();
                                while (true)
                                {
                                    if (column.ToLower() == "q")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Returning to main menu...");
                                        Thread.Sleep(500);
                                        running = false; //basically goes back to main menu
                                    }
                                    if (int.TryParse(column, out int x) == false)//false means the parsing didn't work
                                    {
                                        Console.WriteLine("Input was not a number, please try again");
                                        column = Console.ReadLine().ToLower();
                                    }
                                    else//meaning if the parsing works
                                    {
                                        while (x < 1 || x > (int)board.Size)//checks bounds
                                        {
                                            Console.WriteLine("Input was out of bounds, please try again");
                                            column = Console.ReadLine().ToLower();
                                        }
                                        break;
                                    }
                                }
                                //I tried string.Split, but I couldn't really figure it out. Hope this works!

                                //-------This section handles the actual game logic for changing tile states--------------
                                if (action.ToLower() == "f")
                                {
                                    if (board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isFlagged == true)
                                    {
                                        board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isFlagged = false;
                                        Console.WriteLine("Flag removed");
                                    }
                                    board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isFlagged = true;//-1 is because the user inputs 1-8, but the array is 0-7
                                    Console.WriteLine("Flag placed");
                                }
                                else if (action.ToLower() == "r")
                                {
                                    if (board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isRevealed == true)
                                    {
                                        Console.WriteLine("You've already revealed that one");
                                    }
                                    else if (board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isMine == true)
                                    {
                                        Console.WriteLine("You hit a mine! Game over!");
                                        Console.Clear();
                                        gameState = false; //breaks the game loop, but not the main menu loop
                                    }
                                    else
                                    {
                                        board.Cells[(int.Parse(column) - 1), (int.Parse(row) - 1)].isRevealed = true;//reveals the cell. The -1 is because the user inputs 1-8, but the array is 0-7
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}