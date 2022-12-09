namespace ExpenseTracker.Models
{
    public class ExpenseModel
    {
        private string ExpenseType { get; set; }

        private string Username { get; set; }

        private string UserId { get; set; }

        private string Amount { get; set; }

        private String Date { get; set; }

        public ExpenseModel(string expenseType, string username, string userId, string amount, string date)
        {
            ExpenseType = expenseType;
            Username = username;
            UserId = userId;
            Amount = amount;
            Date = date;
        }
    }
}
