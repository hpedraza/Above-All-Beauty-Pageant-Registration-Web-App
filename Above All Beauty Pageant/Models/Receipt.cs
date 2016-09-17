using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Above_All_Beauty_Pageant.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public Participant Participant { get; set; }
        public int ParticipantId { get; set; }
        public double Amount { get; set; }
        public DateTime PurchaseDate { get; set; }

        public Receipt() { }
        public Receipt(int id , double amount , DateTime purchaseDate)
        {
            ParticipantId = id;
            Amount = amount;
            PurchaseDate = purchaseDate;
        }
    }
}