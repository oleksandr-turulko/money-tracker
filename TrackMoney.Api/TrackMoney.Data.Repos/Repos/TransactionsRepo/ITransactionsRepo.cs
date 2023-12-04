using TrackMoney.BLL.Models.Requests.Transaction;
using TrackMoney.Data.Models.Abstract;

namespace TrackMoney.Data.Repos.Repos.TransactionsRepo
{
    public interface ITransactionsRepo
    {
        Task<object> Add10000Transactions(string userId);
        Task<object> AddTransaction(string userId, AddTransactionRequest request);
        Task<object> GetPageOfUserTransactionsByType(string userId, int pageNumber, int pageSize, TransactionType transactionType);
        Task<object> GetPageOfUserTransactions(string userId, int pageNumber = 1, int pagesize = 8);
    }
}
