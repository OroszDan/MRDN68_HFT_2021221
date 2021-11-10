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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Movie> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Movie ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
