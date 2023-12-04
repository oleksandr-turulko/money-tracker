using TrackMoney.Data.Models.Abstract;

namespace TrackMoney.Data.Models.Entities
{
    public class Transaction : BaseEntity
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public TransactionType TransactionType { get; set; }

        public Guid СurrencyId { get; set; }
        public Сurrency Сurrency { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
