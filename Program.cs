// See https://aka.ms/new-console-template for more information
Random random = new Random();

int startNumber = 1;
int endNumber = 10;
int scorePass = 0;
int scoreFail = 0;

string previousRoundMessage = "Welcome! Make your first guess below.";
ConsoleColor previousMessageColor = ConsoleColor.Gray;

// Main Game Loop
while (true)
{
    Console.Clear();

    // Print header in Cyan
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("=================================");
    Console.WriteLine("          GUESSING GAME          ");
    Console.WriteLine("=================================");
    Console.ResetColor();

    // Print live score in Yellow
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($" Score -> Correct: {scorePass} | Incorrect: {scoreFail}");
    Console.ResetColor();
    Console.WriteLine("---------------------------------");

    // Show previous round message with its specific color
    Console.ForegroundColor = previousMessageColor;
    Console.WriteLine(previousRoundMessage);
    Console.ResetColor();
    Console.WriteLine("---------------------------------\n");

    int randomNumber = random.Next(startNumber, endNumber + 1);

    Console.WriteLine($"Guess a number between {startNumber} and {endNumber}");
    Console.WriteLine($"(Or enter any number > {endNumber} to quit):");

    // Input Validation Loop
    int guessNumber;
    while (!int.TryParse(Console.ReadLine(), out guessNumber))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input! Please enter a valid whole number:");
        Console.ResetColor();
    }

    // Check Exit Condition
    if (guessNumber > endNumber)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=================================");
        Console.WriteLine("           GAME OVER             ");
        Console.WriteLine("=================================");
        Console.ResetColor();

        Console.WriteLine($"Final Score -> Correct: {scorePass} | Incorrect: {scoreFail}");
        Console.WriteLine("\nThanks for playing!");
        break;
    }

    // Evaluate the guess and set the message + color for the next round
    if (guessNumber == randomNumber)
    {
        scorePass++;
        previousMessageColor = ConsoleColor.Green;
        previousRoundMessage = $"✅ Last Guess: {guessNumber} | Result: CORRECT! (The number was {randomNumber})";
    }
    else
    {
        scoreFail++;
        previousMessageColor = ConsoleColor.Red;
        previousRoundMessage = $"❌ Last Guess: {guessNumber} | Result: WRONG! (The number was {randomNumber})";
    }
}