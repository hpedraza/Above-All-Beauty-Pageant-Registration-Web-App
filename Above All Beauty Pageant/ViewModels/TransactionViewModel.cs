using Above_All_Beauty_Pageant.Models;

namespace Above_All_Beauty_Pageant.ViewModels
{
    public class TransactionViewModel
    {
        public bool PaymentMade { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Receipt Receipt { get; set; }

        public TransactionViewModel() { }

        public TransactionViewModel(bool made , string firstName, string lastName)
        {
            PaymentMade = made;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}