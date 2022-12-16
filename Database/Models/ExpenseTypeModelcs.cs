using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class ExpenseTypeModelcs
    {
        public string Groceries { get; set; }
        public string PhoneBill { get; set; }
        public string BusPass { get; set; }
        public string Subscriptions { get; set; }
        public string Alcohol { get; set; }
        public string Furniture { get; set; }
        public string TaxiorTravel { get; set; }
        public string Electricity { get; set; }
        public string Hydro { get; set; }
        public string Laundry { get; set; }
        public string Miscellaneous { get; set; }

        public ExpenseTypeModelcs()
        {
            Groceries = "0";
            PhoneBill = "0";
            BusPass = "0";
            Subscriptions = "0";
            Alcohol = "0";
            Furniture = "0";
            TaxiorTravel = "0";
            Electricity = "0";
            Hydro = "0";
            Laundry = "0";
            Miscellaneous = "0";
        }
    }
}
