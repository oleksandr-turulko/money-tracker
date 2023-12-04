using System.ComponentModel.DataAnnotations;
using TrackMoney.BLL.Models.Requests.Abstract;

namespace TrackMoney.BLL.Models.Requests.User
{
    public class SignUpRequest : IRequestModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public async Task<List<string>> FindAllInvalidFields()
        {
            var message = new List<string>();
            if (string.IsNullOrEmpty(Email))
                message.Add("email is null or empty; ");
            if (string.IsNullOrEmpty(Username))
                message.Add("username is null or empty; ");
            if (string.IsNullOrEmpty(Password))
                message.Add("password is null or empty; ");

            return message;
        }
    }
}
