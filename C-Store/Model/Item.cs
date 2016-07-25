using System;

namespace CStore.Model
{
    /// <summary>
    /// This is the Model for Item that contains all the data members
    /// </summary>
    public class Item 
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public int Qty { get; set; }

        public int TotalQty { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }
       
        public double Amount
        {
            get
            {
                double value = Qty * (Price - Price * Discount / 100);
                return Math.Round(value,2);
            }
        }

        public string RemainingQty
        {
            get { return "Balance " + this.Description + " : " + this.TotalQty + " and consumed : " + Qty;  }
        }
    }
}
