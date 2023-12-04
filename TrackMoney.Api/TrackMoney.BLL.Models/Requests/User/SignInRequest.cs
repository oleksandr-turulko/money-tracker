using System.ComponentModel.DataAnnotations;
using TrackMoney.BLL.Models.Requests.Abstract;

namespace TrackMoney.BLL.Models.Requests.User
{
    public class SignInRequest : IRequestModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        public async Task<List<string>> FindAllInvalidFields()
        {
            var message = new List<string>();
            if (string.IsNullOrEmpty(Email))
                message.Add("email is null or empty;\n");
            if (string.IsNullOrEmpty(Password))
                message.Add("password is null or empty;\n");

            return message;
        }
    }
}
