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

        public void Query()
        {
            //var q0 = ReadAll()
            //    .ToList()
            //    .GroupBy(x => x.Director)
            //    .Select(x => new KeyValuePair<string,int>
            //    (
            //        x.Key.Name,
            //        x.Count()
            //    ));
                
        }

        public void Create(Movie movie)
        {
            if (movie != null)
            {
                repo.Create(movie);
            }
            else
            {
                throw new ArgumentException("Object cannot be null");
            }
        }

        public void Delete(int movieId)
        {
            repo.Delete(movieId);
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
