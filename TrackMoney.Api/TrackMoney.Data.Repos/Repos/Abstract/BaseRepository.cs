namespace TrackMoney.Data.Repos.Repos.Abstract
{
    public abstract class BaseRepository(TrackMoneyDbContext db)
    {
        protected readonly TrackMoneyDbContext _db = db;
    }
}
