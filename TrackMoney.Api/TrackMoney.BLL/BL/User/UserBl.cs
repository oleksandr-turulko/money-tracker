using TrackMoney.BLL.Models.Requests.User;
using TrackMoney.BLL.Models.Responses;
using TrackMoney.Data.Repos.Repos.UsersRepo;

namespace TrackMoney.BLL.BL.User
{
    public class UserBl : IUserBl
    {
        private readonly IUserRepo _userRepo;

        public UserBl(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<object> SignIn(SignInRequest request)
        {
            var mistakes = await request.FindAllInvalidFields();
            if (mistakes.Count != 0)
            {
                return new BadResponse
                {
                    Message = string.Concat(mistakes)
                };
            }

            var response = await _userRepo.SignIn(request);

            return response;
        }

        public async Task<object> SignUp(SignUpRequest request)
        {
            var mistakes = await request.FindAllInvalidFields();
            if (mistakes.Count != 0)
            {
                return new BadResponse
                {
                    Message = string.Concat(mistakes)
                };
            }
            var doesSameUserExists = await _userRepo.DoesSameUserExists(request);
            if (doesSameUserExists)
            {
                return new BadResponse
                {
                    Message = "user with same credentials already exists"
                };
            }
            var response = await _userRepo.SignUp(request);

            return response;
        }

    }
}
