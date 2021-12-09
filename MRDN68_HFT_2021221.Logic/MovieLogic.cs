using MRDN68_HFT_2021221.Models;
using MRDN68_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Logic
{
    public class MovieLogic : IMovieLogic
    {
        IMovieRepository repo;

        public MovieLogic(IMovieRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<KeyValuePair<string,int>> CountOfMoviesAfter2000ByDirectorNamesAndOrderedbyDirectorNames()
        {
            //2000 utáni filmek száma rendezőként csoportosítva, azon belül ábécé sorrendben
            return from x in ReadAll().Where(x => x.Year > 2001)
                   group x by x.Director.Name into g
                   orderby g.Key
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());

        }


        public void Create(Movie movie)
        {
            if (movie != null && !String.IsNullOrEmpty(movie.Name))
            {
                repo.Create(movie);
            }
            else
            {
                throw new ArgumentException("Object is insufficient");
            }
        }

        public void Delete(int movieId)
        {
            repo.Delete(movieId);
        }

        public Movie Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Movie> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Movie movie)
        {
            repo.Update(movie);
        }
    }
}
