using TrackMoney.Data.Models.Abstract;

namespace TrackMoney.Data.Models.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Ballance { get; set; } = 0;
        public ICollection<Transaction> Transactions { get; set; }
    }
}
