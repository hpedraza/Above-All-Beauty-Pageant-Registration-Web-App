using Above_All_Beauty_Pageant.Models;

namespace Above_All_Beauty_Pageant.ViewModels
{
    public class TransactionViewModel
    {
        public bool PaymentMade { get; set; }
        public string Buyer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Error { get; set; }
        public Receipt Receipt { get; set; }
        public string EventName { get; set; }
        public TransactionViewModel() { }

        public TransactionViewModel(bool made , string firstName, string lastName, string error, string buyer, string eventName)
        {
            PaymentMade = made;
            FirstName = firstName;
            LastName = lastName;
            Error = error;
            Buyer = buyer;
            EventName = eventName;
        }
    }
}