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

        public void Query5()
        {// budapesten vetített, legújabb, 1960 után született rendező által rendezett film évszáma
            string city = "Budapest";

            //var q4 = ReadAll()
            //    .Where(x => x.Showtimes.Where(x => x.City == city))

            var proba = ReadAll()
               //.Select(x => x.Movie)
               .GroupBy(x => x.Year).FirstOrDefault()
               .OrderByDescending(x => x.Year)
               .Select(x => x.Showtimes.Where(x => x.City == city))
               .Select(x => x.Select(x => x.DateTime));

            //.Where(x => x.City == city)
            //.Select(x => x.Movie)
            //.Where(x => x.Director.BirthYear > 1960)
            //.Max(x => x.Year);

            //var q4_2 = ReadAll()
            //    //.Select(x => x.Movie.Year == q4)
            //    .FirstOrDefault(x => x.Movie.Year == q4)
            //    .

        }

        public void Create(Movie movie)
        {
            if (movie != null && !String.IsNullOrEmpty(movie.Name) && movie.Rating !=default)
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
