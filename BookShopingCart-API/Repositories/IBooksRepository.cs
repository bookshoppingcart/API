namespace BookShopingCart_API.Repositories
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetBooks(string sTerm = "", int genreId = 0);
    }
}
