using TrackMoney.Data.Models.Abstract;

namespace TrackMoney.Data.Models.Dtos.Transactions
{
    public class MockTransaction
    {
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
