using MovieManager.Core.Contracts;
using MovieManager.Core.Entities;
using System.Linq;

namespace MovieManager.Persistence
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Movie LaengsterFilm()
        {
            return _dbContext.Movies.OrderByDescending(f => f.Duration)
                .ThenBy(f => f.Title
                ).FirstOrDefault();
        }

        public Movie KategorieMitDenMeistenFilmen()
        {
            return _dbContext.Movies.OrderByDescending(f => f.Category)
                .ThenBy(f => f.Title
                ).FirstOrDefault();
        }








    }
}