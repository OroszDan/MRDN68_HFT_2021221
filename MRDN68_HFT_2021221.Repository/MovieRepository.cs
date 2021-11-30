using MRDN68_HFT_2021221.Data;
using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MovieProgrammeDbContext context;

        public MovieRepository(MovieProgrammeDbContext context)
        {
            this.context = context;
        }

        public void Create(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
           
            context.Remove(Read(id));
            context.SaveChanges();

        }

        public IQueryable<Movie> ReadAll()
        {
            return context.Movies;
        }

        public Movie Read(int id)
        {
            return context
                .Movies
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Movie movie)
        {
            Movie movie_old = Read(movie.Id);

            if (movie != null)
            {
                movie_old.Name = movie.Name;
                movie_old.Rating = movie.Rating;
                movie_old.Year = movie.Year;

                context.SaveChanges();
            }
          
        }
    }
}
