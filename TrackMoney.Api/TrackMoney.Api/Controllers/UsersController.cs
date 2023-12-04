using Microsoft.AspNetCore.Mvc;
using TrackMoney.BLL.BL.User;
using TrackMoney.BLL.Models.Requests.User;
using TrackMoney.BLL.Models.Responses;

namespace TrackMoney.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserBl _userBl;

        public UsersController(IUserBl userBl)
        {
            _userBl = userBl;
        }

        [HttpPost]
        [Route("sign-up")]
        public async Task<ActionResult> SignUp(SignUpRequest request)
        {
            var response = await _userBl.SignUp(request);

            if (response is BadResponse)
                return BadRequest(response);

            return Created("", response);
        }
        [HttpPost]
        [Route("sign-in")]
        public async Task<ActionResult> SignIn(SignInRequest request)
        {
            var response = await _userBl.SignIn(request);

            if (response is BadResponse)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
