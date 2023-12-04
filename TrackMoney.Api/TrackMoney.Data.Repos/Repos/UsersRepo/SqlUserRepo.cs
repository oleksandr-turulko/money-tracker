using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using TrackMoney.BLL.Models.Requests.User;
using TrackMoney.BLL.Models.Responses;
using TrackMoney.BLL.Models.Responses.User;
using TrackMoney.Data.Models.Entities;
using TrackMoney.Data.Repos.Repos.Abstract;
using TrackMoney.Services.Jwt;

namespace TrackMoney.Data.Repos.Repos.UsersRepo
{
    public class SqlUserRepo : BaseRepository, IUserRepo
    {

        private readonly IPasswordHasher _passwordHasher;

        public SqlUserRepo(TrackMoneyDbContext db, IPasswordHasher passwordHasher) : base(db)
        {
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> DoesSameUserExists(SignUpRequest request)
        => _db.Users.Any(u => u.UserName.ToLower() == request.Username.ToLower()
                                    || u.Email.ToLower() == request.Email.ToLower());


        public async Task<object> SignIn(SignInRequest signInDto)
        {

            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == signInDto.Email.ToLower());

            bool isSamePasswords = _passwordHasher.VerifyHashedPassword(user.Password, signInDto.Password) != PasswordVerificationResult.Failed;

            if (user == null || !isSamePasswords)
            {
                return new BadResponse
                {
                    Message = "Invalid Email or password"
                };
            }


            return new AuthenticatedUser
            {
                Username = user.UserName,
                Token = JwtGenerator.GenerateJWT(user.UserName, user.Id)
            };
        }

        public async Task<object> SignUp(SignUpRequest signUpDto)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                UserName = signUpDto.Username,
                Email = signUpDto.Email,
                Password = _passwordHasher.HashPassword(signUpDto.Password)
            };

            _db.Users.Add(newUser);
            await _db.SaveChangesAsync();

            return new AuthenticatedUser
            {
                Username = signUpDto.Username,
                Token = JwtGenerator.GenerateJWT(newUser.UserName, newUser.Id)
            };
        }
    }
}
