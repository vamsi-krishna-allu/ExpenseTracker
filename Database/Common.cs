namespace Database
{
    public class Common
    {
        public static string getExpenseType(string expenseType)
        {
            string expense = "";
            switch(expenseType)
            {
                case "0":
                    expense = "Groceries";
                    break;
                case "1":
                    expense = "Phone Bill";
                    break;
                case "2":
                    expense = "Bus Pass";
                    break;
                case "3":
                    expense = "Subscriptions";
                    break;
                case "4":
                    expense = "Alcohol";
                    break;
                case "5":
                    expense = "Furniture";
                    break;
                case "6":
                    expense = "Taxi or Travel";
                    break;
                case "7":
                    expense = "Electricity";
                    break;
                case "8":
                    expense = "Hydro";
                    break;
                case "9":
                    expense = "Laundry";
                    break;
                case "10":
                    expense = "Miscellaneous";
                    break;
            }
            return expense;
        }
    }
}
