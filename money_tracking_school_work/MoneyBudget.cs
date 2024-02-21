
namespace money_tracking_school_work
{

    // MoneyBudget is used to track money budget by incomes and expenses.
    internal class MoneyBudget
    {

        private string title = "No title"; // title of incomes or expenses.
        private bool isIncome = true; // isIncome bool is income if true and expense if false.
        private string isIncomeStr = "income"; // isIncomeStr is string of income or expense based of and reflect isIncome. Used in consol output to user.
        private long amount = 0; // amount of incomes or expenses.
        private int month = 0; // month of incomes or expenses. Can only be 1-12 exept 0 that mean unspecified or unknown month. 
        private static int maxLength = 20; // max lenght for string input. Used for title.
        static public List<MoneyBudget> BudgetList { get; set; } = [];

        /* Constructor for creating new MoneyBudget and add it to BudgetList.
         * This is done by using set from properties what get input from user to set the values, making the part after = meaningless when used as 
         * long as it match the data type to avoid errors.
         * 
         * NOTE: I used this way to experiment this what can be done with set from properties. And as it work well i have choice to leave 
         * it this way instead of refactoring to handle input from user with method and send that into a more traditional use of set with properties.
         * This is so i can use it as part of my pressentation share that it can be done this way, even if it is not the most tradiational way, to show 
         * that there can often be intressting alternat way to solva problem with code.
         */
        public MoneyBudget()
        {
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

        // GetBudgetTypeStr method that return string of "Income" or "Expense" based on IsIncome.
        public string GetBudgetTypeStr ()
        {
            return IsIncome ? "Income" : "Expense";
        }

        public long Amount
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
                    if (!long.TryParse(newAmountStr, out amount))
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

        // ShowBudgetList show list of BudgetList.
        // If IsIncomeFilter is null show all.
        // If IsIncomeFilter is true show only income.
        // If IsIncomeFilter is false show only expense.
        static public void ShowBudgetList( bool? IsIncomeFilter = null)
        {
            int padRightAmount = 22; // Amount of Right padding used when showing BudgetList
            var sortedBudgetList = BudgetList.OrderBy(x => x.Month).ThenBy(x => x.IsIncome).ThenBy(x => x.Amount); // sort BudgetList by Month, IsIncome then Amount

            // if IsIncomeFilter is true then overwrite sortedBudgetList to filter so only income will show.
            if (IsIncomeFilter is true) 
            {
                //filter only income and sort BudgetList by Month, IsIncome then Amount
                sortedBudgetList = BudgetList.Where(x => x.IsIncome == true).OrderBy(x => x.Month).ThenBy(x => x.IsIncome).ThenBy(x => x.Amount);
            }
            // if IsIncomeFilter is false then overwrite sortedBudgetList to filter so only expense will show.
            else if (IsIncomeFilter is false)
            {
                //filter only expense and sort BudgetList by Month, IsIncome then Amount
                sortedBudgetList = BudgetList.Where(x => x.IsIncome == false).OrderBy(x => x.Month).ThenBy(x => x.IsIncome).ThenBy(x => x.Amount);
            }

            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine(
                "Title".PadRight(padRightAmount) +
                "Month".PadRight(padRightAmount) +
                "Income/Expense".PadRight(padRightAmount) +
                "Amount".PadRight(padRightAmount)   
                );
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");

            foreach (MoneyBudget budgetEntry in sortedBudgetList)
            {
                string color = budgetEntry.IsIncome ? "green" : "red"; // color to write out budgetEntry in will be green for income and red for expense

                // write out info for budgetEntry
                Display.DisplayColorMsg(
                budgetEntry.Title.PadRight(padRightAmount) +
                budgetEntry.Month.ToString().PadRight(padRightAmount) +
                budgetEntry.GetBudgetTypeStr().PadRight(padRightAmount) +
                budgetEntry.Amount.ToString().PadRight(padRightAmount)
                , color);
            }
        }
    }
}
