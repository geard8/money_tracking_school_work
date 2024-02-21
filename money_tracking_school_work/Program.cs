
using money_tracking_school_work;
using System.Diagnostics;

//MoneyBudget test = new MoneyBudget(); // TEST CODE

//MoneyBudget.ShowBudgetList(); // TEST CODE

// TODO add restore MoneyBudget.ShowBudgetList by load from file that is used then to save when quit this program.

ConsoleKeyInfo cki; // used to store key pressed by the user

// meny for user to navigate the program.
while (true)
{
    Console.WriteLine("- press \"A\": To create a budget entry");
    Console.WriteLine("- press \"B\": To show list of all budget entry");
    Console.WriteLine("- press \"Q\": To save and quit");
    cki = Console.ReadKey();
    Console.WriteLine();
    // Q quit and save
    if (cki.Key == ConsoleKey.Q)
    {
        // TODO add save to file.
        break;
    }
    // A create a new MoneyBudget.
    else if (cki.Key == ConsoleKey.A)
    {
        new MoneyBudget();
    }
    // B show all MoneyBudget to user
    else if(cki.Key == ConsoleKey.B)
    {
        MoneyBudget.ShowBudgetList();
    }
}
