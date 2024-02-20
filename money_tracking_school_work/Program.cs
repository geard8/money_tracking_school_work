
using money_tracking_school_work;



Console.WriteLine("Hello, World!");

MoneyBudget test = new MoneyBudget();

Console.WriteLine(test);

foreach (var item in MoneyBudget.BudgetList)
{
    Console.WriteLine(item.Amount);
}

Console.WriteLine("Hello, World!");