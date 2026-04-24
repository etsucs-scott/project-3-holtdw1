Console.WriteLine("--------------------Minesweeper Clone V0.01 - Alpha Build--------------");
Console.WriteLine("|-------------------Main Menu-----------------------------------------|");
Console.WriteLine("|1. New Game                                                          |");
Console.WriteLine("|2. High Scores                                                       |");
Console.WriteLine("|3. Exit                                                              |");
Console.WriteLine("-----------------------------------------------------------------------");
Console.Write("Input a number, and press enter to continue: ");
while (true)
{
    string? input = Console.ReadLine();
    if (int.TryParse(input, out int choice) == false)
    {
        Console.WriteLine("Invalid input! You need a number. Please try again.");
    }
    else if ((choice != 1 && choice != 2 && choice != 3))
    {
        Console.WriteLine("Invalid input! Please try again.");
    }
    else
    {
        Console.WriteLine($"Dev test: number picked: {choice}");
    }
}