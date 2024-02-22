
using money_tracking_school_work;
using System.Drawing;

string fileName = "budget_list.xml"; // Name of file, that then created can be found at "money_tracking_school_work\bin\Debug\net8.0" from project folder.

try
{
    MoneyBudget.BudgetList = ObjectFileManger.LoadViaDataContractSerialization<List<MoneyBudget>>(fileName); // load file
}
catch (Exception)
{
    Console.WriteLine("No save file found. One will be created with all budget entry then quiting this program.");
}

ConsoleKeyInfo cki; // used to store key pressed by the user

// menu for user to navigate the program.
while (true)
{
    Console.WriteLine("- press \"A\": To create a budget entry");
    Console.WriteLine("- press \"B\": To show list of all budget entry");
    Console.WriteLine("- press \"C\": To show list of income budget entry");
    Console.WriteLine("- press \"D\": To show list of expense budget entry");
    Console.WriteLine("- press \"E\": To manage budget entry");
    Console.WriteLine("- press \"Q\": To save and quit");
    cki = Console.ReadKey();
    Console.WriteLine();
    // Q quit and save
    if (cki.Key == ConsoleKey.Q)
    {
        ObjectFileManger.SaveViaDataContractSerialization(MoneyBudget.BudgetList, fileName); // save file
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
    // C show all MoneyBudget to user
    else if (cki.Key == ConsoleKey.C)
    {
        MoneyBudget.ShowBudgetList(true);
    }
    // D show all MoneyBudget to user
    else if (cki.Key == ConsoleKey.D)
    {
        MoneyBudget.ShowBudgetList(false);
    }
    // E show all MoneyBudget to user
    else if (cki.Key == ConsoleKey.E)
    {
        if (MoneyBudget.BudgetList.Count() > 0) { MoneyBudget.ManageBudgetList(); } // if BudgetList i not empty, then start manage BudgetList
        else { Display.DisplayColorMsg("There are no budget entry to manage.", "red"); }
    }
    else { Display.DisplayColorMsg("Not a valid choice, press a key for one of the listed options", "red"); }
}
