using TrackMoney.BLL.Models.Requests.Transaction;
using TrackMoney.Data.Models.Abstract;

namespace TrackMoney.BLL.BL.Transaction
{
    public interface ITransactionBl
    {
        public Task<object> Add10000Transactions(string jwt);
        public Task<object> AddTransaction(string jwt, AddTransactionRequest request);
        public Task<object> GetAllUserTransactions(string jwt, int pageNumber, int pageSize);
        public Task<object> GetAllUserTransactionsByType(string jwt, int pageNumber, int pageSize, TransactionType transactionType);

    }
}
