using TrackMoney.BLL.Models.Requests.Abstract;
using TrackMoney.Data.Models.Abstract;

namespace TrackMoney.BLL.Models.Requests.Transaction
{
    public class AddTransactionRequest : IRequestModel
    {
        public string Description { get; set; }
        public int Amount { get; set; }
        public TransactionType TypeOfTransaction { get; set; }
        public string Currency { get; set; }
        public async Task<List<string>> FindAllInvalidFields()
        {
            var messages = new List<string>();
            if (string.IsNullOrWhiteSpace(Description))
            {
                messages.Add("description cannot be null or empty");
            }
            if (Amount == 0)
            {
                messages.Add("amount cannot be equal to 0");
            }
            return messages;
        }
    }
}
