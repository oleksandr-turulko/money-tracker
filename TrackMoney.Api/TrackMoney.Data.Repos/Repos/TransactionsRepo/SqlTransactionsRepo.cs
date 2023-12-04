using Microsoft.EntityFrameworkCore;
using TrackMoney.BLL.Models.Requests.Transaction;
using TrackMoney.BLL.Models.Responses.Transactions;
using TrackMoney.Data.Models.Abstract;
using TrackMoney.Data.Models.Dtos.Transactions;
using TrackMoney.Data.Models.Entities;
using TrackMoney.Data.Repos.Repos.Abstract;

namespace TrackMoney.Data.Repos.Repos.TransactionsRepo
{
    public class SqlTransactionsRepo : BaseRepository, ITransactionsRepo
    {
        public SqlTransactionsRepo(TrackMoneyDbContext db) : base(db)
        {
        }

        public async Task<object> Add10000Transactions(string userId)
        {

            var descriptionsAmounts = new Dictionary<string, MockTransaction>
            {
                { "phone", new MockTransaction{ Amount = 120,TransactionType = TransactionType.Expense } },
                { "internet", new MockTransaction{ Amount =200m, TransactionType = TransactionType.Expense } },
                { "creditCard",new MockTransaction{ Amount = 500m, TransactionType = TransactionType.Income }},
                { "gas", new MockTransaction{ Amount = 2400m, TransactionType = TransactionType.Expense }},
                { "spotify",new MockTransaction{ Amount = 200m, TransactionType = TransactionType.Expense } },
                { "debt", new MockTransaction{ Amount = 2400m, TransactionType = TransactionType.Income } }
            };

            var currency = _db.Currencies.FirstOrDefault(c => c.Name == "UAH");
            var listToAdd = new List<Transaction>();
            for (int i = 1; i <= 10000; i++)
            {
                var rand = new Random();
                var index = rand.Next(5);
                var newTransaction = new Transaction
                {
                    Id = Guid.NewGuid(),
                    Description = descriptionsAmounts.ElementAt(index).Key,
                    Amount = descriptionsAmounts.ElementAt(index).Value.Amount,
                    Date = DateTime.Now,
                    Сurrency = currency,
                    TransactionType = descriptionsAmounts.ElementAt(index).Value.TransactionType,
                    UserId = Guid.Parse(userId)
                };
                listToAdd.Add(newTransaction);
            }

            _db.Transactions.AddRange(listToAdd);
            await _db.SaveChangesAsync();
            return null;
        }

        public async Task<object> AddTransaction(string userId, AddTransactionRequest request)
        {
            var newTransaction = new Transaction
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                Amount = request.Amount,
                Date = DateTime.Now,
                TransactionType = request.TypeOfTransaction,
                UserId = Guid.Parse(userId)
            };

            var currency = _db.Currencies.FirstOrDefault(c => c.Name == request.Currency.ToUpper());

            if (currency != null)
            {
                newTransaction.Сurrency = currency;
            }
            else
            {
                newTransaction.Сurrency = new()
                {
                    Id = Guid.NewGuid(),
                    Name = request.Currency.ToUpper()
                };
            }

            _db.Transactions.Add(newTransaction);
            await _db.SaveChangesAsync();

            return new AddTransactionResponse(newTransaction);
        }


        public async Task<object> GetPageOfUserTransactionsByType(string userId, int pageNumber, int pageSize, TransactionType transactionType)
        => _db.Transactions
                .Include(t => t.Сurrency)
                .Where(t => t.TransactionType == transactionType && t.UserId.ToString() == userId)
                    .Select(t => new TransactionViewDto
                    {
                        Id = t.Id,
                        Description = t.Description,
                        Date = t.Date,
                        Amount = t.Amount,
                        Currency = t.Сurrency.Name,
                        TransactionType = Enum.GetName(t.TransactionType)
                    })
                .OrderByDescending(t => t.Date)
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .AsAsyncEnumerable();

        public async Task<object> GetPageOfUserTransactions(string userId, int pageNumber = 1, int pagesize = 8)
            => _db.Transactions
                    .Include(t => t.Сurrency)
                    .Where(t => t.UserId.ToString() == userId)
                        .Select(t => new TransactionViewDto
                        {
                            Id = t.Id,
                            Description = t.Description,
                            Date = t.Date,
                            Amount = t.Amount,
                            Currency = t.Сurrency.Name,
                            TransactionType = Enum.GetName(t.TransactionType)
                        })
                    .OrderByDescending(t => t.Date)
                .Skip(pageNumber * pagesize)
                .Take(pagesize)
                .AsAsyncEnumerable();

    }
}
