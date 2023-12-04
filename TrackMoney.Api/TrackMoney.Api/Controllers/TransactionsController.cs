using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackMoney.BLL.BL.Transaction;
using TrackMoney.BLL.Models.Requests.Transaction;
using TrackMoney.BLL.Models.Responses;
using TrackMoney.Data.Models.Abstract;

namespace TrackMoney.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionBl _transactionBl;

        public TransactionsController(ITransactionBl transactionBl)
        {
            _transactionBl = transactionBl;
        }

        [HttpPost]
        public async Task<ActionResult> AddTransaction([FromBody] AddTransactionRequest request)
        {
            var jwt = HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");

            var response = await _transactionBl.AddTransaction(jwt, request);

            if (response is BadResponse)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Route("add10000Transactions")]
        [HttpPost]
        public async Task<ActionResult> Add10000Transactions()
        {
            var jwt = HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");

            var response = await _transactionBl.Add10000Transactions(jwt);

            if (response is BadResponse)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> GetTransactions(int pageNumber = 1, int pageSize = 8)
        {
            var jwt = HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");

            var response = await _transactionBl.GetAllUserTransactions(jwt, pageNumber, pageSize);

            return Ok(response);
        }

        [HttpGet]
        [Route("getTransactionsByType")]
        public async Task<ActionResult> GetTransactionsByType
            (TransactionType transactionType = TransactionType.Income,
                                    int pageNumber = 1, int pageSize = 8)

        {
            var jwt = HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");

            var response = await _transactionBl.GetAllUserTransactionsByType(jwt, pageNumber, pageSize, transactionType);

            return Ok(response);
        }
        [HttpDelete]
        [Route("removeTransactionById")]
        public async Task<ActionResult> RemoveTransaction
            (TransactionType transactionType = TransactionType.Income,
                                    int pageNumber = 1, int pageSize = 8)

        {
            var jwt = HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");

            var response = await _transactionBl.GetAllUserTransactionsByType(jwt, pageNumber, pageSize, transactionType);

            return Ok(response);
        }
    }
}
