using TrackMoney.BLL.Models.Requests.Transaction;
using TrackMoney.BLL.Models.Responses;
using TrackMoney.Data.Models.Abstract;
using TrackMoney.Data.Repos.Repos.TransactionsRepo;
using TrackMoney.Services.Jwt;

namespace TrackMoney.BLL.BL.Transaction
{
    public class TransactionBl : ITransactionBl
    {
        private readonly ITransactionsRepo _transactionsRepo;

        public TransactionBl(ITransactionsRepo transactionsRepo)
        {
            _transactionsRepo = transactionsRepo;
        }

        public async Task<object> Add10000Transactions(string jwt)
        {
            var userId = await JwtReader.GetIdFromJwt(jwt);
            var response = await _transactionsRepo.Add10000Transactions(userId);
            return null;
        }

        public async Task<object> AddTransaction(string jwt, AddTransactionRequest request)
        {
            var userId = await JwtReader.GetIdFromJwt(jwt);
            var messages = await request.FindAllInvalidFields();
            if (messages.Count != 0)
            {
                return new BadResponse
                {
                    Message = string.Concat(messages)
                };
            }

            var response = await _transactionsRepo.AddTransaction(userId, request);

            return response;
        }

        public async Task<object> GetAllUserTransactions(string jwt, int pageNumber, int pageSize)
        {
            var userId = await JwtReader.GetIdFromJwt(jwt);

            return await _transactionsRepo.GetPageOfUserTransactions(userId, pageNumber, pageSize);
        }

        public async Task<object> GetAllUserTransactionsByType(string jwt, int pageNumber, int pageSize, TransactionType transactionType)
        {
            var userId = await JwtReader.GetIdFromJwt(jwt);

            return await _transactionsRepo.GetPageOfUserTransactionsByType(userId, pageNumber, pageSize, transactionType);
        }
    }
}
