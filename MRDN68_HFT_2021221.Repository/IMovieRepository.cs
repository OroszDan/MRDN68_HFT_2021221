using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Repository
{
    public interface IMovieRepository
    {
        // C(R)RUD
        void Create(Movie movie);
        Movie Read(int id);
        IQueryable<Movie> ReadAll(); // altalaban: query
        void Update(Movie movie);
        void Delete(int id);
    }
}
