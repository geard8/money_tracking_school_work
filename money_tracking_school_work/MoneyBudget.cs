
namespace money_tracking_school_work
{

    // MoneyBudget is used to track money budget by incomes and expenses.
    internal class MoneyBudget
    {

        private string title = "No title"; // title of incomes or expenses.
        private bool isIncome = true; // isIncome bool is income if true and expense if false.
        private string isIncomeStr = "income"; // isIncomeStr is string of income or expense based of and reflect isIncome. Used in consol output to user.
        private int amount = 0; // amount of incomes or expenses.
        private int month = 0; // month of incomes or expenses. Can only be 1-12 exept 0 that mean unspecified or unknown month. 
        private static int maxLength = 25; // max lenght for string input. Used for title.
        static public List<MoneyBudget> BudgetList { get; set; } = [];

        public MoneyBudget()
        {
            // TODO ASK teacher if i can leave my testing set method or if i shall make it more probely with by creating set methods instead of set from property.
            Title = "user input"; // after = do not matter as input form user will be used instead as part of Title set.
            IsIncome = true; // after = do not matter as input form user will be used instead as part of IsIncome set.
            Amount = 1; // after = do not matter as input form user will be used instead as part of Amount set.
            Month = 1; // after = do not matter as input form user will be used instead as part of Month set.
            BudgetList.Add(this); // Add newly created MoneyBudget to BudgetList.
        }

        public string Title
        {
            get { return title; }
            // set title by input from user.
            set
            {
                // get user input for title 
                while (true)
                {
                    Console.Write($"Enter title: ");
                    title = Console.ReadLine();
                    if (title.Length > maxLength)
                    {
                        Display.DisplayColorMsg("Too long can't be longer then " + maxLength + " characters", "red");
                    }
                    else if (title.Trim().Length != 0) { break; }
                    else
                    {
                        Display.DisplayColorMsg("Name can not be empty", "red");
                    }
                }
                Console.WriteLine(); // For better spacing and readability 
            }
        }

        public bool IsIncome
        {
            get { return isIncome; }
            // set isIncome and in turn isIncomeStr by input from user.
            set
            {
                // get user input for isIncome
                while (true)
                {
                    // Ask user if it is a computer or phone where 1 for income or 2 for expense.
                    Console.Write("What is it budget entry for? Enter 1 for income or 2 for expense: ");
                    string assetTypeInput = Console.ReadLine();
                    if (assetTypeInput == "1") { isIncome = true; isIncomeStr = "income"; break; }
                    else if (assetTypeInput == "2") { isIncome = false; isIncomeStr = "expense"; break; }
                    else { Display.DisplayColorMsg("Please only input 1 for income or 2 for expense", "red"); }
                }
                Console.WriteLine(); // For better spacing and readability 
            }
        }

        public int Amount
        {
            get { return amount; }
            // set amount by input from user.
            set
            {
                // get user input for amount
                while (true)
                {
                    Console.Write($"What large amount is this {isIncomeStr} for: ");
                    string newAmountStr = Console.ReadLine();
                    if (!int.TryParse(newAmountStr, out amount))
                    {
                        Display.DisplayColorMsg("Not a valid price. Exemple of valid price is: 7 or 995000", "red");
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine(); // For better spacing and readability 
            }
        }

        public int Month
        {
            get { return month; }
            // set month by input from user.
            set
            {
                // get user input for month
                while (true)
                {
                    Console.Write($"What month is this {isIncomeStr} for: ");
                    string newMonthStr = Console.ReadLine();
                    if (!int.TryParse(newMonthStr, out month))
                    {
                        Display.DisplayColorMsg("Not a valid month. Exemple of valid month is: 4 or 12", "red");
                    }
                    else if (month >= 1 && month <= 12)
                    {
                        break;
                    }
                    else
                    {
                        Display.DisplayColorMsg("Not a valid month, can be 1-12", "red");
                    }
                }
                Console.WriteLine(); // For better spacing and readability 
            }
        }
    }
}
