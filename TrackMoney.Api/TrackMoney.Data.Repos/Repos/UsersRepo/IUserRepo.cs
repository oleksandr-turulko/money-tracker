using TrackMoney.BLL.Models.Requests.User;

namespace TrackMoney.Data.Repos.Repos.UsersRepo
{
    public interface IUserRepo
    {
        Task<object> SignUp(SignUpRequest signUpDto);
        Task<object> SignIn(SignInRequest signInDto);
        Task<bool> DoesSameUserExists(SignUpRequest request);
    }
}
