// See https://aka.ms/new-console-template for more information
// ==========================================
// 1. WELCOME & HOW IT WORKS SCREEN
// ==========================================
Console.Clear();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("==================================================");
Console.WriteLine("         WELCOME TO ENDLESS GUESSING GAME         ");
Console.WriteLine("==================================================");
Console.ResetColor();

Console.WriteLine("\n📖 HOW IT WORKS:");
Console.WriteLine("  1. Choose your range (1-10, 1-50, or 1-100).");
Console.WriteLine("  2. The computer picks a secret random number.");
Console.WriteLine("  3. Guess the secret number to build your streak!");
Console.WriteLine("  4. Track your wins, losses, and high score.");
Console.WriteLine("  5. Type 'exit' anytime during play to quit.\n");

Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("Press any key to select your difficulty...");
Console.ResetColor();
Console.ReadKey(true);


// ==========================================
// 2. DIFFICULTY SELECTION MENU
// ==========================================
int endNumber = 10;
string difficultyName = "Easy";
bool validChoice = false;

while (!validChoice)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("==================================================");
    Console.WriteLine("             SELECT YOUR DIFFICULTY               ");
    Console.WriteLine("==================================================");
    Console.ResetColor();

    Console.WriteLine("\nChoose a level:");
    Console.WriteLine("  1) Easy    (Range: 1 - 10)");
    Console.WriteLine("  2) Medium  (Range: 1 - 50)");
    Console.WriteLine("  3) Hard    (Range: 1 - 100)");
    Console.Write("\nEnter choice (1-3): ");

    string choiceInput = Console.ReadLine()?.Trim();

    switch (choiceInput)
    {
        case "1":
            endNumber = 10;
            difficultyName = "Easy (1-10)";
            validChoice = true;
            break;
        case "2":
            endNumber = 50;
            difficultyName = "Medium (1-50)";
            validChoice = true;
            break;
        case "3":
            endNumber = 100;
            difficultyName = "Hard (1-100)";
            validChoice = true;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInvalid option! Press any key to try again...");
            Console.ResetColor();
            Console.ReadKey(true);
            break;
    }
}


// ==========================================
// 3. MAIN GAME SETUP & LOOP
// ==========================================
Random random = new Random();
int correctCount = 0;
int incorrectCount = 0;

int currentSecretNumber = random.Next(1, endNumber + 1);
string lastGuessInput = "None";
string previousRoundMessage = "";
bool isFirstRound = true;

while (true)
{
    Console.Clear();

    // Header & Scoreboard
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("==================================================");
    Console.WriteLine($"   ENDLESS GUESSING GAME [{difficultyName}]");
    Console.WriteLine("==================================================");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"Score -> Correct: {correctCount} | Incorrect: {incorrectCount}");
    Console.ResetColor();
    Console.WriteLine("--------------------------------------------------");

    // State message from the previous round
    if (!isFirstRound && !string.IsNullOrEmpty(previousRoundMessage))
    {
        Console.WriteLine(previousRoundMessage);
        Console.WriteLine("--------------------------------------------------");
    }

    Console.WriteLine($"I'm thinking of a number between 1 and {endNumber}.");
    Console.Write("Enter your guess (or 'exit' to quit): ");

    string input = Console.ReadLine()?.Trim();

    // Check for exit
    if (input != null && input.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        break; // Exit game loop
    }

    // Input validation
    if (!int.TryParse(input, out int userGuess) || userGuess < 1 || userGuess > endNumber)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        previousRoundMessage = $"❌ Invalid input! Please enter a number between 1 and {endNumber}.";
        Console.ResetColor();
        isFirstRound = false;
        continue;
    }

    // Record the valid guess
    lastGuessInput = userGuess.ToString();

    // Win / Loss logic
    if (userGuess == currentSecretNumber)
    {
        correctCount++;
        previousRoundMessage = $"🎉 CORRECT! The secret number was {currentSecretNumber}. High five!";
        // Generate new secret number for next round
        currentSecretNumber = random.Next(1, endNumber + 1);
    }
    else
    {
        incorrectCount++;
        previousRoundMessage = $"❌ WRONG! You guessed {userGuess}, but the secret number was {currentSecretNumber}.";
        // Generate new secret number for next round
        currentSecretNumber = random.Next(1, endNumber + 1);
    }

    isFirstRound = false;
}


// ==========================================
// 4. GAME OVER & EXIT SUMMARY
// ==========================================
Console.Clear();
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("==================================================");
Console.WriteLine("                    GAME OVER                     ");
Console.WriteLine("==================================================");
Console.ResetColor();

Console.WriteLine($"\nLast difficulty played : {difficultyName}");
Console.WriteLine($"Last valid guess typed : {lastGuessInput}");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"Active target number   : {currentSecretNumber}");
Console.ResetColor();

Console.WriteLine($"\nFinal Score -> Correct: {correctCount} | Incorrect: {incorrectCount}");
Console.WriteLine("\nThanks for playing!");

Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("\nPress any key to exit program...");
Console.ResetColor();
Console.ReadKey(true);