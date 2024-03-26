namespace BookShopingCart_API.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> Genres();
    }
}
