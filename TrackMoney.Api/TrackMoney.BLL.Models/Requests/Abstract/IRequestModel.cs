namespace TrackMoney.BLL.Models.Requests.Abstract
{
    public interface IRequestModel
    {
        Task<List<string>> FindAllInvalidFields();
    }
}
