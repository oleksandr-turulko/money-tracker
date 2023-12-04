using TrackMoney.BLL.Models.Requests.User;

namespace TrackMoney.BLL.BL.User
{
    public interface IUserBl
    {
        public Task<object> SignUp(SignUpRequest request);
        public Task<object> SignIn(SignInRequest request);
    }
}
