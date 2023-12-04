using TrackMoney.Data.Models.Abstract;

namespace TrackMoney.Data.Models.Entities
{
    public class Сurrency : BaseEntity
    {
        public decimal Value { get; set; } = 0;
        public string Name { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
