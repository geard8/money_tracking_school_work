namespace money_tracking_school_work
{
    public static class Display
    {
        // DisplayColorMsg is used to write out text to consol with a selection pre defined amount of color ment to be used for diffrent purpose.
        public static void DisplayColorMsg(string msg, string color)
        {
            // red is ment to be used for misstakes or errors, ex something did not validate. Or red is ment for Asset that are 3 month or less in list of asset
            if (color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msg);
                Console.ResetColor();
            }

            // green is ment to be used to indicate something was done successfully.
            else if (color == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(msg);
                Console.ResetColor();
            }
            // yellow is ment for Asset that are 6 month or less in list of asset unless it less then 3, then it is red that is used.
            // Or yellow is ment for testing i shall not show up in public version unless something went wrong.
            else if (color == "yellow")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(msg);
                Console.ResetColor();
            }
            // If color is none above then give feedback that this color is not supported
            else
            {
                DisplayColorMsg("ERROR: Do not support color: " + color, "yellow");
            }
        }
    }
}
