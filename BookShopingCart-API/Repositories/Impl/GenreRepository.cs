using Microsoft.EntityFrameworkCore;

namespace BookShopingCart_API.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _db;

        public GenreRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Genre>> Genres()
        {
            return await _db.Genres.ToListAsync();
        }
    }
}