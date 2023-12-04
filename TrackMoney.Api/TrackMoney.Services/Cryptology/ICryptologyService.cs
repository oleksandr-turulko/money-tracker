namespace TrackMoney.Data.Repos.Repos.Cryptology
{
    public interface ICryptologyService
    {
        Task<string> EncryptPassword(string password);
    }
}
