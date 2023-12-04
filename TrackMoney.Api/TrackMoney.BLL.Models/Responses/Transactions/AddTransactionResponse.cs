using TrackMoney.Data.Models.Entities;

namespace TrackMoney.BLL.Models.Responses.Transactions
{
    public class AddTransactionResponse
    {
        public AddTransactionResponse(Transaction transaction)
        {
            Description = transaction.Description;
            Amount = transaction.Amount;
            Date = transaction.Date;
            TransactionType = Enum.GetName(transaction.TransactionType) ?? "";
            СurrencyId = transaction.СurrencyId;
            CurrencyCode = transaction.Сurrency.Name ?? "";
        }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string TransactionType { get; set; }
        public Guid СurrencyId { get; set; }
        public string CurrencyCode { get; set; }
    }
}
